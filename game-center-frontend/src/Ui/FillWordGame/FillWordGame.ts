import template from "./FillWordGame.html?raw";

export default class FillWordGame extends HTMLElement {
    private _shadowRoot: ShadowRoot;

    constructor() {
        super();
        this._shadowRoot = this.attachShadow({mode: 'open'});
    }

    connectedCallback() {
        this._shadowRoot.innerHTML = template;
        this.onInit();
    }

    private onInit(): void {

    }
}

window.customElements.define('fill-word-game', FillWordGame);