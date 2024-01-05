import {filter, OperatorFunction} from "rxjs";

export function filterTruthy<TValue>(): OperatorFunction<TValue | null | undefined, TValue> {
  return filter((src) => !!src) as OperatorFunction<TValue | null | undefined, TValue>;
}
