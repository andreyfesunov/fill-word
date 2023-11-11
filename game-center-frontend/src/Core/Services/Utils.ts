export class Utils {
    public static shuffle(array: Array<any>): Array<any> {
        array.sort(() => Math.random() - 0.5);
        return array;
    }

    public static getRandomInt(max): number {
        return Math.floor(Math.random() * max);
    }

    public static getRandomValueWithMap(map: boolean[]): number {
        let val: number;
        while (true) {
            val = this.getRandomInt(map.length);
            if (!map[val]) {
                map[val] = true;
                return val;
            }
        }
    }
}