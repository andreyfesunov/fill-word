export interface StorageInterface<T> {
    put(key: string, value: T): void;
    get(key: string): T;
}