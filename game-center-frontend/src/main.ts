import './style.css'
import {FillWordGameModel, FillWordGameStatus, IFillWordCreateModel} from "@domain/FillWord/FillWord.models";
import {fillWordModule} from "@adapter/FillWord/FillWord.module";
import {css, CSSResult, html, LitElement, TemplateResult} from "lit";
import {customElement, query} from "lit/decorators.js"
import {Observable, Subscription} from "./Lib/Observable.ts";
import {ID} from "@domain/SharedKernel.types";
import {WordPattern} from "@api/FillWord/Mock/Assets/Patterns.db";

const domChange = (element: HTMLElement) => new Observable<string>((observer) => {
    const onChange: (e: Event) => void = (e: Event) => observer.next?.((e.target as HTMLInputElement).value);
    element.onchange = onChange;
    return () => element.removeEventListener('change', onChange);
});

@customElement('fill-word-game')
export class MainComponent extends LitElement {
    private size: number = 5;
    private subscription: Subscription | null = null;
    private draw: boolean = false;
    private word: string[] = [];

    private model: FillWordGameModel;
    private line: ID[] = [];

    @query('#size-input') sizeInput!: HTMLInputElement;
    @query('.game-grid') field!: HTMLDivElement;
    @query('.range__label') rangeLabel!: HTMLSpanElement;
    @query('.win') win!: HTMLElement;

    protected render(): TemplateResult {
        return html`
            <div class="container">
                <div class="range">
                    <label for="range-row">Current field size: <span class="range__label">${this.size}</span></label>
                    <input type="range" id="size-input" min="3" max="10" value="${this.size}">
                </div>
                <div @mouseleave="${this.onMouseUp}" class="game-grid"></div>
                <div class="win win--hidden">
                    <p>You win!</p>
                    <button @click="${() => {
                        this.drawField(this.size);
                        this.hideWin()
                    }}" class="win__button">Restart
                    </button>
                </div>
            </div>
        `;
    }

    static styles: CSSResult = css`
      .game-grid {
        contain: content;
        width: min-content;
        display: grid;
        grid-template-columns: repeat(var(--size), 1fr);
        grid-template-rows: repeat(var(--size), 1fr);
        border-radius: 16px;
      }

      .game-grid > .game-grid__item {
        display: flex;
        justify-content: center;
        align-items: center;
        background-color: var(--_color, white);

        width: 80px;
        height: 80px;
        border: 1px solid #e7e7e7;
      }

      .range {
        border-radius: 12px;
        background-color: white;
        display: flex;
        justify-content: center;
        padding: 12px;
      }

      .container {
        padding: 12px;
        display: flex;
        flex-direction: column;
        align-items: center;
        gap: 12px;
      }

      .win {
        display: flex;
        flex-direction: column;
        padding: 12px;
        border-radius: 12px;
        background-color: white;
      }

      .win--hidden {
        display: none;
      }

      .win > .win__button {
      }

      * {
        user-select: none;
        margin: 0;
        padding: 0;
      }
    `

    connectedCallback() {
        super.connectedCallback();

        this.updateComplete.then(() => this.onInit());
    }

    disconnectedCallback() {
        if (this.subscription !== null) {
            this.subscription.unsubscribe();
        }
    }

    private onInit(): void {
        this.subscription = domChange(this.sizeInput).subscribe({
            next: (v: string) => {
                this.size = parseInt(v);
                this.rangeLabel.innerHTML = v;
                this.drawField(this.size);
            }
        })
        this.drawField(this.size);
    }

    private drawField(size: number): void {
        this.hideWin();
        this.field.innerHTML = '';
        this.style.setProperty(
            '--size',
            size.toString()
        );

        const creationModel: IFillWordCreateModel = {
            size: size,
        }
        fillWordModule.createGame(creationModel).then((result) => {
            const model = FillWordGameModel.createFromBaseModel(result);
            console.log(model);
            this.mutateView(model);
        })
    }

    private mutateView(model: FillWordGameModel): void {
        this.model = model;

        model.matrix.forEach((row, rowIndex) => {
            row.forEach((ceil, ceilIndex) => {
                const div = document.createElement('div');

                div.innerHTML = ceil.content;
                div.classList.add('game-grid__item');
                div.dataset.row = String(rowIndex);
                div.dataset.ceil = String(ceilIndex);
                div.onmouseover = this.onMouseOver.bind(this);
                div.onmousedown = this.onMouseDown.bind(this);
                div.onmouseup = this.onMouseUp.bind(this);

                this.field.appendChild(div);
            })
        })
    }

    private onMouseUp(
        e: Event
    ) {
        this.draw = false;
        const hasWord = fillWordModule.attempt({
            model: this.model,
            ids: this.line
        });

        hasWord.then(
            (status) => {
                if (status !== FillWordGameStatus.WRONG_MOVE) {
                    this.line = [];

                    if (status === FillWordGameStatus.END_GAME) {
                        this.showWin();
                    }
                } else {
                    this.clearTimeLine();
                }
            }
        )
    }

    private onMouseDown(
        e: Event
    ): void {
        const target: HTMLElement = (e.target as HTMLElement);
        this.draw = true;

        const row: number = +target.dataset.row;
        const ceil: number = +target.dataset.ceil;

        if (this.isActive(row, ceil)) return;

        this.activate(row, ceil);
    }

    private onMouseOver(
        e: Event
    ): void {
        const target: HTMLElement = (e.target as HTMLElement);
        if (!this.draw) {
            return;
        }

        const row: number = +target.dataset.row;
        const ceil: number = +target.dataset.ceil;

        if (!this.isActive(row, ceil) && this.lastCeilLengthEqualOneCeil(row, ceil)) {
            this.activate(row, ceil);
        } else {
            if (this.isPrevCeil(row, ceil)) {
                const lastCeilId: ID = this.lastCeil();
                const lastCeilCoords = this.findInMatrix(lastCeilId);

                this.disable(lastCeilCoords[0], lastCeilCoords[1]);
                this.removeLastMoveInTimeline();
            }
        }
    }

    private isActive(row: number, ceil: number): boolean {
        return this.model.matrix[row][ceil].active;
    }

    private activate(row: number, ceil: number): void {
        this.model.matrix[row][ceil].active = true;
        this.getHtmlElement(row, ceil).style.setProperty('--_color', '#abd1dc');

        this.addTimeline(row, ceil);
        this.addChar(this.model.matrix[row][ceil].content);
    }

    private disable(row: number, ceil: number) {
        this.model.matrix[row][ceil].active = false;
        this.getHtmlElement(row, ceil).style.setProperty('--_color', 'white');

        this.removeLastChar();
    }

    private addTimeline(row: number, ceil: number): void {
        this.line.push(this.model.matrix[row][ceil].id);
    }

    private lastCeilLengthEqualOneCeil(row: number, ceil: number): boolean {
        const lastCeilId: ID = this.lastCeil();
        const lastCeilCoords = this.findInMatrix(lastCeilId);
        const lastRow = lastCeilCoords[0];
        const lastCeil = lastCeilCoords[1];

        return (
            ((lastRow === row - 1 || lastRow === row + 1) && lastCeil === ceil) ||
            ((lastCeil === ceil - 1 || lastCeil === ceil + 1) && lastRow === row)
        );
    }

    private removeLastMoveInTimeline(): void {
        this.line.splice(this.line.length - 1, 1);
    }

    private prevCeil(): ID | null {
        return this.line[this.line.length - 2];
    }

    private lastCeil(): ID {
        return this.line[this.line.length - 1];
    }

    private isPrevCeil(row: number, ceil: number): boolean {
        if (!this.prevCeil()) return false;

        return this.prevCeil() === this.model.matrix[row][ceil].id;
    }

    private clearTimeLine(): void {
        this.line.forEach(id => {
            this.model.matrix.forEach((row) => {
                const el = row.find((model) => model.id === id);
                if (el) {
                    el.active = false;
                    const wordPattern: WordPattern = this.findInMatrix(el.id);
                    const htmlElement: HTMLElement = this.getHtmlElement(wordPattern[0], wordPattern[1]);

                    htmlElement.style.setProperty('--_color', 'white');
                }
            });
        });

        this.line = [];
    }

    private findInMatrix(id: ID): WordPattern {
        let coords: WordPattern = [];
        this.model.matrix.forEach((row, rowIndex) => row.forEach((ceil, ceilIndex) => {
            if (coords.length !== 0) return;
            if (ceil.id === id) {
                coords = [rowIndex, ceilIndex];
            }
        }))

        if (coords.length !== 0) {
            return coords;
        }

        throw new Error('Not found element with such id');
    }

    private getHtmlElement(row: number, ceil: number): HTMLElement {
        for (const element: HTMLElement of this.field.children) {
            const elRow = parseInt(element.dataset.row);
            const elCeil = parseInt(element.dataset.ceil);

            if (elRow === row && elCeil === ceil) {
                return element;
            }
        }

        throw new Error('Not found element');
    }

    private hideWin(): void {
        this.win.classList.add('win--hidden');
    }

    private showWin(): void {
        this.win.classList.remove('win--hidden');
    }
}