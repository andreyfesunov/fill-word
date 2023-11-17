import './style.css'
import {FillWordGameModel, IFillWordCreateModel} from "@domain/FillWord/FillWord.models";
import {fillWordModule} from "@adapter/FillWord/FillWord.module";
import {css, CSSResult, html, LitElement, TemplateResult} from "lit";
import {customElement, query} from "lit/decorators.js"
import {Observable, Subscription} from "./Lib/Observable.ts";

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

    @query('#size-input') sizeInput!: HTMLInputElement;
    @query('.game-grid') field!: HTMLDivElement;
    @query('.range__label') rangeLabel!: HTMLSpanElement;

    protected render(): TemplateResult {
        return html`
            <div class="range">
                <label for="range-row">Current field size: <span class="range__label">${this.size}</span></label>
                <input type="range" id="size-input" min="3" max="8" value="${this.size}">
            </div>
            <div @mouseleave="${this.onMouseOver}" class="game-grid"></div>
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
        background-color: white;

        width: 100px;
        height: 100px;
        border: 1px solid #e7e7e7;
      }
      
      .range {
        border-radius: 12px;
        background-color: white;
        display: flex;
        justify-content: center;
        padding: 12px;
        margin-bottom: 12px;
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
        model.matrix.forEach((row, rowIndex) => {
            row.forEach((ceil, ceilIndex) => {
                const div = document.createElement('div');

                div.innerHTML = ceil.content;
                div.classList.add('game-grid__item');
                div.dataset.row = String(rowIndex);
                div.dataset.ceil = String(ceilIndex);
                div.onmouseover = this.onMouseOver;
                div.onmousedown = this.onMouseDown;
                div.onmouseup = this.onMouseUp;

                this.field.appendChild(div);
            })
        })
    }

    private onMouseUp(
        {target}: Event
    ): void {
        this.draw = false;
    }

    private onMouseDown(
        {target}: Event
    ): void {
        this.draw = true;
    }

    private onMouseOver(
        {target}: Event
    ): void {
        if (!this.draw) {
            return;
        }

        const row: number = +target!.dataset.row;
        const ceil: number = +target!.dataset.ceil;
    }
}