export class Utils {
    public static shuffle(array: Array<unknown>): Array<unknown> {
        array.sort(() => Math.random() - 0.5);
        return array;
    }

    public static getRandomInt(min: number, max: number): number {
        return Math.floor(Math.random() * (max - min + 1)) + min;
    }

    public static getRandomValueWithMap(map: boolean[]): number {
        let val: number;
        while (true) {
            val = this.getRandomInt(0, map.length - 1);
            if (!map[val]) {
                map[val] = true;
                return val;
            }
        }
    }
}