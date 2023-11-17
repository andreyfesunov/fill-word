import {Pattern, patterns} from "@api/FillWord/Mock/Assets/Patterns.db";
import {db} from "@api/FillWord/Mock/Assets/Words.db";
import {IFillWordElementModel, IFillWordModel} from "@domain/FillWord/FillWord.models";
import {ID} from "@domain/SharedKernel.types";

export class FillWordCreateService {
    private static getFlipPattern(width: number): Pattern {
        const matrixSize: string = width.toString() + 'x' + width.toString();
        const patternNumber: number = Math.floor(Math.random() * patterns[width + 'x' + width].length);
        const pattern: Pattern = [];
        const rawPattern: Pattern = patterns[matrixSize][patternNumber];
        const putCase: number = Math.floor(Math.random() * 4);

        rawPattern.forEach(word => {
            pattern[pattern.length] = [];
            const patternWord = pattern[pattern.length - 1];

            word.forEach(symbol => {
                switch (putCase) {
                    case 0:
                        patternWord[patternWord.length] = [symbol[0], symbol[1]];
                        break;
                    case 1:
                        patternWord[patternWord.length] = [width - 1 - symbol[0], width - 1 - symbol[1]];
                        break;
                    case 2:
                        patternWord[patternWord.length] = [width - 1 - symbol[1], symbol[0]];
                        break;
                    case 3:
                        patternWord[patternWord.length] = [symbol[1], width - 1 - symbol[0]];
                        break;
                    default:
                        break;
                }
            });
        });

        return pattern;
    }

    private static getFlipNoSquarePattern(ShortSide: number, TallSide: number, FallOnSide = false): Pattern {
        const matrixSize: string = ShortSide.toString() + 'x' + TallSide.toString();
        const patternNumber: number = Math.floor(Math.random() * patterns[matrixSize].length);
        const pattern: Pattern = [];
        const rawPattern: Pattern = patterns[matrixSize][patternNumber];
        const patCase: number = Math.floor(Math.random() * 4);

        rawPattern.forEach(word => {
            pattern[pattern.length] = [];
            const patternWord = pattern[pattern.length - 1];
            word.forEach(symbol => {
                switch (patCase) {
                    case 0:
                        patternWord[patternWord.length] = [symbol[0], symbol[1]];
                        break;
                    case 1:
                        patternWord[patternWord.length] = [ShortSide - 1 - symbol[0], TallSide - 1 - symbol[1]];
                        break;
                    case 2:
                        patternWord[patternWord.length] = [ShortSide - 1 - symbol[0], symbol[1]];
                        break;
                    case 3:
                        patternWord[patternWord.length] = [symbol[0], TallSide - 1 - symbol[1]];
                        break;
                    default:
                        break;
                }
            });
        });

        if (FallOnSide) {
            pattern.forEach(word => {
                word.forEach(symbol => {
                    const temp = symbol[0];
                    symbol[0] = symbol[1];
                    symbol[1] = ShortSide - 1 - temp;
                });
            });
        }

        return pattern;
    }


    private static getSixPattern(): Pattern {
        const pattern: Pattern = this.getFlipPattern(3);
        let rawPattern: Pattern = this.getFlipPattern(3);

        for (let i = 1; i < 4; i++) {
            rawPattern.forEach(word => {
                pattern[pattern.length] = [];
                const patternWord = pattern[pattern.length - 1];
                word.forEach(symbol => {
                    switch (i) {
                        case 1:
                            patternWord[patternWord.length] = [symbol[0], symbol[1] + 3];
                            break;
                        case 2:
                            patternWord[patternWord.length] = [symbol[0] + 3, symbol[1]];
                            break;
                        case 3:
                            patternWord[patternWord.length] = [symbol[0] + 3, symbol[1] + 3];
                            break;
                        default:
                            break;
                    }
                });
            });
            rawPattern = this.getFlipPattern(3);
        }

        return pattern;
    }

    private static getSevenPattern(): Pattern {
        // 4x4 as top left corner
        const pattern: Pattern = this.getFlipPattern(4);
        // 3x3 as right bottom
        let rawPattern: Pattern = this.getFlipPattern(3);

        rawPattern.forEach(word => {
            pattern[pattern.length] = [];
            const patternWord = pattern[pattern.length - 1];
            word.forEach(symbol => {
                patternWord[patternWord.length] = [symbol[0] + 4, symbol[1] + 4];
            });
        });

        // 3x4 as left bottom
        rawPattern = this.getFlipNoSquarePattern(3, 4);
        rawPattern.forEach(word => {
            pattern[pattern.length] = [];
            const patternWord = pattern[pattern.length - 1];
            word.forEach(symbol => patternWord[patternWord.length] = [symbol[0] + 4, symbol[1]]);
        });

        // 4x3 as right top
        rawPattern = this.getFlipNoSquarePattern(3, 4, true);
        rawPattern.forEach(word => {
            pattern[pattern.length] = [];
            const patternWord = pattern[pattern.length - 1];
            word.forEach(symbol => patternWord[patternWord.length] = [symbol[0], symbol[1] + 4]);
        });

        return pattern;
    }

    private static getEightPattern(): Pattern {
        let pattern: Pattern = [];

        // Random pattern picking
        if (Math.floor(Math.random() * 4) > 1) {
            // 4x4 as 2x2 scheme
            pattern = this.getFlipPattern(4);
            let rawPattern: Pattern = this.getFlipPattern(4);

            for (let i = 1; i < 4; i++) {
                rawPattern.forEach(word => {
                    pattern[pattern.length] = [];
                    const patternWord = pattern[pattern.length - 1];
                    word.forEach(symbol => {
                        switch (i) {
                            case 1:
                                patternWord[patternWord.length] = [symbol[0], symbol[1] + 4];
                                break;
                            case 2:
                                patternWord[patternWord.length] = [symbol[0] + 4, symbol[1]];
                                break;
                            case 3:
                                patternWord[patternWord.length] = [symbol[0] + 4, symbol[1] + 4];
                                break;
                            default:
                                break;
                        }
                    });
                });
                rawPattern = this.getFlipPattern(4);
            }
        } else {
            // 5х5, 5х3, 3х5, 3х3
            // 5x5 as left top
            pattern = this.getFlipPattern(5);
            // 3x3 as right bottom
            let rawPattern: Pattern = this.getFlipPattern(3);
            rawPattern.forEach(word => {
                pattern[pattern.length] = [];
                const patternWord = pattern[pattern.length - 1];
                word.forEach(symbol => {
                    patternWord[patternWord.length] = [symbol[0] + 5, symbol[1] + 5];
                });
            });

            // 3x5 as left bottom
            rawPattern = this.getFlipNoSquarePattern(3, 5);
            rawPattern.forEach(word => {
                pattern[pattern.length] = [];
                const patternWord = pattern[pattern.length - 1];
                word.forEach(symbol => patternWord[patternWord.length] = [symbol[0] + 5, symbol[1]]);
            });

            // 5x3 as right top
            rawPattern = this.getFlipNoSquarePattern(3, 5, true);
            rawPattern.forEach(word => {
                pattern[pattern.length] = [];
                const patternWord = pattern[pattern.length - 1];
                word.forEach(symbol => patternWord[patternWord.length] = [symbol[0], symbol[1] + 5]);
            });
        }

        return pattern;
    }

    private static getNinePattern(): Pattern {
        let pattern: Pattern = [];

        // Random pattern picking
        if (Math.floor(Math.random() * 4) > 1) {
            // 6x6, 3x3, 6x3, 3x6
            // 6x6 as left top
            pattern = this.getSixPattern();

            // 3x3 as right bottom
            let rawPattern: Pattern = this.getFlipPattern(3);
            rawPattern.forEach(word => {
                pattern[pattern.length] = [];
                const patternWord = pattern[pattern.length - 1];
                word.forEach(symbol => {
                    patternWord[patternWord.length] = [symbol[0] + 6, symbol[1] + 6];
                });
            });

            // 3x6 as left bottom
            rawPattern = this.getFlipNoSquarePattern(3, 6);
            rawPattern.forEach(word => {
                pattern[pattern.length] = [];
                const patternWord = pattern[pattern.length - 1];
                word.forEach(symbol => patternWord[patternWord.length] = [symbol[0] + 6, symbol[1]]);
            });

            // 6x3 as right top
            rawPattern = this.getFlipNoSquarePattern(3, 6, true);
            rawPattern.forEach(word => {
                pattern[pattern.length] = [];
                const patternWord = pattern[pattern.length - 1];
                word.forEach(symbol => patternWord[patternWord.length] = [symbol[0], symbol[1] + 6]);
            });
        } else {
            // 5х5, 5х4, 4х5, 4х4
            // 5x5 as left top
            pattern = this.getFlipPattern(5);
            // 4x4 as right bottom
            let rawPattern: Pattern = this.getFlipPattern(4);
            rawPattern.forEach(word => {
                pattern[pattern.length] = [];
                const patternWord = pattern[pattern.length - 1];
                word.forEach(symbol => {
                    patternWord[patternWord.length] = [symbol[0] + 5, symbol[1] + 5];
                });
            });
            // 4x5 as left bottom
            rawPattern = this.getFlipNoSquarePattern(4, 5);
            rawPattern.forEach(word => {
                pattern[pattern.length] = [];
                const patternWord = pattern[pattern.length - 1];
                word.forEach(symbol => patternWord[patternWord.length] = [symbol[0] + 5, symbol[1]]);
            });
            // 5x4 as right top
            rawPattern = this.getFlipNoSquarePattern(4, 5, true);
            rawPattern.forEach(word => {
                pattern[pattern.length] = [];
                const patternWord = pattern[pattern.length - 1];
                word.forEach(symbol => patternWord[patternWord.length] = [symbol[0], symbol[1] + 5]);
            });
        }

        return pattern;
    }

    private static getTenPattern(): Pattern {
        let pattern: Pattern = [];

        // Random pattern picking
        if (Math.floor(Math.random() * 4) > 1) {
            // 6x6, 4x4, 6x4, 4x6
            // 6x6 as top left
            pattern = this.getSixPattern();

            // 4x4 as right bottom
            let rawPattern: Pattern = this.getFlipPattern(4);
            rawPattern.forEach(word => {
                pattern[pattern.length] = [];
                const patternWord = pattern[pattern.length - 1];
                word.forEach(symbol => {
                    patternWord[patternWord.length] = [symbol[0] + 6, symbol[1] + 6];
                });
            });

            // 4x6 as left bottom
            rawPattern = this.getFlipNoSquarePattern(4, 6);
            rawPattern.forEach(word => {
                pattern[pattern.length] = [];
                const patternWord = pattern[pattern.length - 1];
                word.forEach(symbol => patternWord[patternWord.length] = [symbol[0] + 6, symbol[1]]);
            });

            // 6x4 as top right
            rawPattern = this.getFlipNoSquarePattern(4, 6, true);
            rawPattern.forEach(word => {
                pattern[pattern.length] = [];
                const patternWord = pattern[pattern.length - 1];
                word.forEach(symbol => patternWord[patternWord.length] = [symbol[0], symbol[1] + 6]);
            });
        } else {
            // 5x5 as 2x2
            pattern = this.getFlipPattern(5);
            let rawPattern: Pattern = this.getFlipPattern(5);

            for (let i = 1; i < 4; i++) {
                rawPattern.forEach(word => {
                    pattern[pattern.length] = [];
                    const patternWord = pattern[pattern.length - 1];
                    word.forEach(symbol => {
                        switch (i) {
                            case 1:
                                patternWord[patternWord.length] = [symbol[0], symbol[1] + 5];
                                break;
                            case 2:
                                patternWord[patternWord.length] = [symbol[0] + 5, symbol[1]];
                                break;
                            case 3:
                                patternWord[patternWord.length] = [symbol[0] + 5, symbol[1] + 5];
                                break;
                            default:
                                break;
                        }
                    });
                });
                rawPattern = this.getFlipPattern(5);
            }
        }

        return pattern;
    }

    private static getPattern(width: number): Pattern {
        switch (width) {
            case 3:
                return this.getFlipPattern(3);
            case 4:
                return this.getFlipPattern(4);
            case 5:
                return this.getFlipPattern(5);
            case 6:
                return this.getSixPattern();
            case 7:
                return this.getSevenPattern();
            case 8:
                return this.getEightPattern();
            case 9:
                return this.getNinePattern();
            case 10:
                return this.getTenPattern();
            default:
                throw new Error('Invalid value of width param')
        }
    }

    public static makeGame(width: number): IFillWordModel {
        const pattern: Pattern = this.getPattern(width);

        // Reversing
        for (let i = 0; i < pattern.length; i++) {
            if (Math.random() > 0.5) {
                const wordRev = [];
                for (let j = 0; j < pattern[i].length; j++) {
                    wordRev.unshift(pattern[i][j]);
                }
                pattern[i] = wordRev;
            }
        }

        const map: IFillWordElementModel[][] = [];

        for (let i = 0; i < width; i++) {
            map[i] = [];
            for (let j = 0; j < width; j++) {
                map[i][j] = {content: '#', id: 0};
            }
        }

        let id: ID = 0;
        const idPattern: ID[][] = pattern.map(word => {
            const wordLengthInBase = word.length - 3;
            const wordFromBase = db[wordLengthInBase][Math.floor(Math.random() * db[wordLengthInBase].length)];
            const idPattern: ID[] = [];

            for (let index = 0; index < word.length; index++) {
                map[word[index][0]][word[index][1]] = {content: `${wordFromBase[index]}`, id: id++};
                idPattern.push(id);
            }

            return idPattern;
        });

        return {
            matrix: map,
            col: map.length,
            row: map.length,
            wordsIds: idPattern
        }
    }
}
