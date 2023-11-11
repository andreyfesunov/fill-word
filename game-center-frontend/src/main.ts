import './style.css'
import {FillWordGameModel} from "./Core/Domain/FillWord/Models/FillWordGameModel";
import {FillWordCreateService} from "./Core/Services/FillWord/FillWordCreateService";
import {FillWordElementModel} from "./Core/Domain/FillWord/Models/FillWordElementModel";
import {Observable} from "./Lib/Observable";

const words: string[] = ['java', 'php', 'csharp', 'roblox', 'dotnet'];
const wordsLength: number = words.reduce((acc, cur) => acc + cur.length, 0);
const row: number = 5;
const col: number = 5;

if (row * col !== wordsLength) {
    throw new Error;
}

const model: FillWordGameModel = FillWordGameModel.createFromBaseModel(FillWordCreateService.CreateFillWordMatrix(row, col, words));
const $el = document.querySelector('#app');

const gridDiv = document.createElement('div');
gridDiv.classList.add('grid');
const $grid = $el.appendChild(gridDiv);

console.log(model);

const flatMatrix: FillWordElementModel[] = model.matrix.flat();

flatMatrix.forEach((element) => {
    const div = document.createElement('div');
    div.innerHTML = element.getContent();
    div.classList.add('grid__item');
    $grid.appendChild(div);
})

const domInputChange = (selector: string) => new Observable<string>((observer) => {
    const input: HTMLInputElement = document.querySelector(selector);
    const onChange: (e: Event) => void = (e: Event) => observer.next?.((e.target as HTMLInputElement).value);
    input.onchange = onChange;
    return () => input.removeEventListener('change', onChange);
});

const row$ = domInputChange('#range-row');
const col$ = domInputChange('#range-col');

row$.subscribe({
    next: console.log,
    complete: () => console.log("hell yeah")
});

col$.subscribe({
    next: console.log,
    complete: () => console.log("hell yeah")
})