import {ID} from "../../../shared-kernel";

export class FillWordElementModel {
    public constructor(
        private id: ID,
        private content: string,
        private next: ID | null = null
    ) {
    }

    public getId(): ID {
        return this.id;
    }

    public getContent(): string {
        return this.content;
    }

    public setContent(content: string): this {
        this.content = content;
        return this;
    }

    public getNext(): ID | null {
        return this.next;
    }

    public setNext(next: ID | null): this {
        this.next = next;
        return this;
    }
}

export const FILL_WORD_DEFAULT_CONTENT = "#";