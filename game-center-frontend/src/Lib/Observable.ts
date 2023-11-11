/**
 * Our subscription type. This is to manage teardowns.
 */
export class Subscription {
    private teardowns = new Set<() => void>();

    add(teardown: () => void) {
        this.teardowns.add(teardown);
    }

    unsubscribe() {
        for (const teardown of this.teardowns) {
            teardown();
        }
        this.teardowns.clear();
    }
}

export interface Observer<T> {
    next?: (value: T) => void;
    complete?: () => void;
    error?: (error: Error) => void;
}

export class SafeSubscriber<T> {
    closed = false;

    constructor(
        private destination: Partial<Observer<T>>,
        private subscription: Subscription,
    ) {
        // Make sure that if the subscription is unsubscribed,
        // we don't let any more notifications through this subscriber.
        subscription.add(() => (this.closed = true));
    }

    next(value: T) {
        if (!this.closed) {
            this.destination.next?.(value);
        }
    }

    complete() {
        if (!this.closed) {
            this.closed = true;
            this.destination.complete?.();
            this.subscription.unsubscribe();
        }
    }

    error(err: never) {
        if (!this.closed) {
            this.closed = true;
            this.destination.error?.(err);
            this.subscription.unsubscribe();
        }
    }
}

export class Observable<T> {
    constructor(private _wrappedFunc: (subscriber: Observer<T>) => () => void) {
    }

    subscribe(observer: Observer<T>) {
        const subscription = new Subscription();
        const subscriber = new SafeSubscriber(observer, subscription);
        subscription.add(this._wrappedFunc(subscriber));
        return subscription;
    }
}