using game_center_backend_cs.Domain.Models.FillWord;
using game_center_backend_cs.Domain.Models.Pattern;
using game_center_backend_cs.Domain.Repositories;

namespace game_center_backend_cs.Domain.Services.FillWord;

public class FillWordCreateService
{
    private readonly IFillWordRepository _fillWordRepository;

    public FillWordCreateService(
        IFillWordRepository fillWordRepository
    )
    {
        _fillWordRepository = fillWordRepository;
    }

    public FillWordModel Create(int size)
    {
        var id = 0;
        var rnd = new Random();
        var pattern = GetPattern(size);

        // Reversing
        for (var i = 0; i < pattern.Count; i++)
        {
            if (!(rnd.NextDouble() > 0.5)) continue;

            var wordRev = new List<PatternElement>();
            for (var j = 0; j < pattern[i].Count; j++) wordRev.Insert(0, pattern[i][j]);
            pattern[i] = wordRev;
        }

        // Matrix
        var matrix = new FillWordElement[size][];
        for (var i = 0; i < size; i++)
        {
            matrix[i] = new FillWordElement[size];
            for (var j = 0; j < size; j++)
                matrix[i][j] = new FillWordElement(
                    0,
                    '#'
                );
        }

        // Answers
        var answersIds = new List<List<int>>();
        foreach (var wordPattern in pattern)
        {
            var wordLengthInBase = wordPattern.Count - 3;
            var wordFromBase = Words.Collection[wordLengthInBase][
                (int)Math.Floor(rnd.NextDouble() * Words.Collection[wordLengthInBase].Length)
            ];
            var answerIds = new List<int>();

            for (var index = 0; index < wordPattern.Count; index++)
            {
                matrix[wordPattern[index].Row][wordPattern[index].Ceil] = new FillWordElement(id, wordFromBase[index]);
                answerIds.Add(id++);
            }

            answersIds.Add(answerIds);
        }

        var model = new FillWordModel(
            null,
            matrix,
            answersIds
        );

        _fillWordRepository.Create(model);

        return model;
    }

    private static List<List<PatternElement>> GetFlipPattern(int width)
    {
        var rnd = new Random();
        var matrixSize = width + "x" + width;
        var patternNumber = (int)Math.Floor(
            rnd.NextDouble() * Pattern.Collection[matrixSize].Length
        );
        var pattern = new List<List<PatternElement>>();
        var rawPattern = Pattern.Collection[matrixSize][patternNumber];
        var putCase = (int)Math.Floor(rnd.NextDouble() * 4);

        foreach (var rawWordPattern in rawPattern)
        {
            pattern.Insert(pattern.Count, new List<PatternElement>());
            var patternWord = pattern[^1];

            foreach (var symbol in rawWordPattern)
            {
                var symbolPattern = putCase switch
                {
                    0 => new PatternElement(symbol.Row, symbol.Ceil),
                    1 => new PatternElement(width - 1 - symbol.Row, width - 1 - symbol.Ceil),
                    2 => new PatternElement(width - 1 - symbol.Ceil, symbol.Row),
                    3 => new PatternElement(symbol.Ceil, width - 1 - symbol.Row),
                    _ => patternWord[patternWord.Count]
                };
                patternWord.Insert(patternWord.Count, symbolPattern);
            }
        }

        return pattern;
    }

    private static List<List<PatternElement>> GetFlipNoSquarePattern(
        int shortSide,
        int tallSide,
        bool fallOnSide = false
    )
    {
        var rnd = new Random();
        var matrixSize = shortSide + "x" + tallSide;
        var patternNumber = (int)Math.Floor(
            rnd.NextDouble() * Pattern.Collection[matrixSize].Length
        );
        var pattern = new List<List<PatternElement>>();
        var rawPattern = Pattern.Collection[matrixSize][patternNumber];
        var patCase = (int)Math.Floor(rnd.NextDouble() * 4);

        foreach (var rawWordPattern in rawPattern)
        {
            pattern.Insert(pattern.Count, new List<PatternElement>());
            var patternWord = pattern[^1];

            foreach (var symbol in rawWordPattern)
            {
                var symbolPattern = patCase switch
                {
                    0 => new PatternElement(symbol.Row, symbol.Ceil),
                    1 => new PatternElement(shortSide - 1 - symbol.Row, tallSide - 1 - symbol.Ceil),
                    2 => new PatternElement(shortSide - 1 - symbol.Row, symbol.Ceil),
                    3 => new PatternElement(symbol.Row, tallSide - 1 - symbol.Ceil),
                    _ => patternWord[patternWord.Count]
                };
                patternWord.Insert(patternWord.Count, symbolPattern);
            }
        }

        if (fallOnSide)
            foreach (var wordPattern in pattern)
            foreach (var symbol in wordPattern)
            {
                var temp = symbol.Row;
                symbol.Row = symbol.Ceil;
                symbol.Ceil = shortSide - 1 - temp;
            }

        return pattern;
    }

    private static List<List<PatternElement>> GetSixPattern()
    {
        var pattern = GetFlipPattern(3);
        var rawPattern = GetFlipPattern(3);

        for (var i = 1; i < 4; i++)
        {
            foreach (var rawWordPattern in rawPattern)
            {
                pattern.Insert(pattern.Count, new List<PatternElement>());
                var patternWord = pattern[^1];

                foreach (var symbol in rawWordPattern)
                {
                    var symbolPattern = i switch
                    {
                        1 => new PatternElement(symbol.Row, symbol.Ceil + 3),
                        2 => new PatternElement(symbol.Row + 3, symbol.Ceil),
                        3 => new PatternElement(symbol.Row + 3, symbol.Ceil + 3),
                        _ => patternWord[patternWord.Count]
                    };
                    patternWord.Insert(patternWord.Count, symbolPattern);
                }
            }

            rawPattern = GetFlipPattern(3);
        }

        return pattern;
    }

    private static List<List<PatternElement>> GetSevenPattern()
    {
        // 4x4 as top left corner
        var pattern = GetFlipPattern(4);
        // 3x3 as right bottom
        var rawPattern = GetFlipPattern(3);
        foreach (var rawWordPattern in rawPattern)
        {
            pattern.Insert(pattern.Count, new List<PatternElement>());
            var patternWord = pattern[^1];

            foreach (var symbol in rawWordPattern)
                patternWord.Insert(patternWord.Count, new PatternElement(symbol.Row + 4, symbol.Ceil + 4));
        }

        // 3x4 as left bottom
        rawPattern = GetFlipNoSquarePattern(3, 4);
        foreach (var rawWordPattern in rawPattern)
        {
            pattern.Insert(pattern.Count, new List<PatternElement>());
            var patternWord = pattern[^1];

            foreach (var symbol in rawWordPattern)
                patternWord[patternWord.Count] = new PatternElement(symbol.Row + 4, symbol.Ceil);
        }

        // 4x3 as right top
        rawPattern = GetFlipNoSquarePattern(3, 4, true);
        foreach (var rawWordPattern in rawPattern)
        {
            pattern.Insert(pattern.Count, new List<PatternElement>());
            var patternWord = pattern[^1];

            foreach (var symbol in rawWordPattern)
                patternWord.Insert(patternWord.Count, new PatternElement(symbol.Row, symbol.Ceil + 4));
        }

        return pattern;
    }

    private static List<List<PatternElement>> GetEightPattern()
    {
        var rnd = new Random();
        List<List<PatternElement>> pattern;

        // Random pattern picking
        if ((int)Math.Floor(rnd.NextDouble() * 4) > 1)
        {
            // 4x4 as 2x2 scheme
            pattern = GetFlipPattern(4);
            var rawPattern = GetFlipPattern(4);

            for (var i = 1; i < 4; i++)
            {
                foreach (var rawWordPattern in rawPattern)
                {
                    pattern.Insert(pattern.Count, new List<PatternElement>());
                    var patternWord = pattern[^1];

                    foreach (var symbol in rawWordPattern)
                    {
                        var symbolPattern = i switch
                        {
                            1 => new PatternElement(symbol.Row, symbol.Ceil + 4),
                            2 => new PatternElement(symbol.Row + 4, symbol.Ceil),
                            3 => new PatternElement(symbol.Row + 4, symbol.Ceil + 4),
                            _ => patternWord[patternWord.Count]
                        };
                        patternWord.Insert(patternWord.Count, symbolPattern);
                    }
                }

                rawPattern = GetFlipPattern(4);
            }
        }
        else
        {
            // 5х5, 5х3, 3х5, 3х3
            // 5x5 as left top
            pattern = GetFlipPattern(5);
            // 3x3 as right bottom
            var rawPattern = GetFlipPattern(3);

            foreach (var rawWordPattern in rawPattern)
            {
                pattern.Insert(pattern.Count, new List<PatternElement>());
                var patternWord = pattern[^1];

                foreach (var symbol in rawWordPattern)
                    patternWord.Insert(patternWord.Count, new PatternElement(symbol.Row + 5, symbol.Ceil + 5));
            }

            // 3x5 as left bottom
            rawPattern = GetFlipNoSquarePattern(3, 5);
            foreach (var rawWordPattern in rawPattern)
            {
                pattern.Insert(pattern.Count, new List<PatternElement>());
                var patternWord = pattern[^1];

                foreach (var symbol in rawWordPattern)
                    patternWord.Insert(patternWord.Count, new PatternElement(symbol.Row + 5, symbol.Ceil));
            }

            // 5x3 as right top
            rawPattern = GetFlipNoSquarePattern(3, 5, true);
            foreach (var rawWordPattern in rawPattern)
            {
                pattern.Insert(pattern.Count, new List<PatternElement>());
                var patternWord = pattern[^1];

                foreach (var symbol in rawWordPattern)
                    patternWord.Insert(patternWord.Count, new PatternElement(symbol.Row, symbol.Ceil + 5));
            }
        }

        return pattern;
    }

    private static List<List<PatternElement>> GetNinePattern()
    {
        var rnd = new Random();
        List<List<PatternElement>> pattern;

        // Random pattern picking
        if ((int)Math.Floor(rnd.NextDouble() * 4) > 1)
        {
            // 6x6, 3x3, 6x3, 3x6
            // 6x6 as left top
            pattern = GetSixPattern();

            // 3x3 as right bottom
            var rawPattern = GetFlipPattern(3);
            foreach (var rawWordPattern in rawPattern)
            {
                pattern.Insert(pattern.Count, new List<PatternElement>());
                var patternWord = pattern[^1];

                foreach (var symbol in rawWordPattern)
                    patternWord.Insert(patternWord.Count, new PatternElement(symbol.Row + 6, symbol.Ceil + 6));
            }

            // 3x6 as left bottom
            rawPattern = GetFlipNoSquarePattern(3, 6);
            foreach (var rawWordPattern in rawPattern)
            {
                pattern.Insert(pattern.Count, new List<PatternElement>());
                var patternWord = pattern[^1];

                foreach (var symbol in rawWordPattern)
                    patternWord.Insert(patternWord.Count, new PatternElement(symbol.Row + 6, symbol.Ceil));
            }

            // 6x3 as right top
            rawPattern = GetFlipNoSquarePattern(3, 6, true);
            foreach (var rawWordPattern in rawPattern)
            {
                pattern.Insert(pattern.Count, new List<PatternElement>());
                var patternWord = pattern[^1];

                foreach (var symbol in rawWordPattern)
                    patternWord.Insert(patternWord.Count, new PatternElement(symbol.Row, symbol.Ceil + 6));
            }
        }
        else
        {
            // 5х5, 5х4, 4х5, 4х4
            // 5x5 as left top
            pattern = GetFlipPattern(5);

            // 4x4 as right bottom
            var rawPattern = GetFlipPattern(4);
            foreach (var rawWordPattern in rawPattern)
            {
                pattern.Insert(pattern.Count, new List<PatternElement>());
                var patternWord = pattern[^1];

                foreach (var symbol in rawWordPattern)
                    patternWord.Insert(patternWord.Count, new PatternElement(symbol.Row + 5, symbol.Ceil + 5));
            }

            // 4x5 as left bottom
            rawPattern = GetFlipNoSquarePattern(4, 5);
            foreach (var rawWordPattern in rawPattern)
            {
                pattern.Insert(pattern.Count, new List<PatternElement>());
                var patternWord = pattern[^1];

                foreach (var symbol in rawWordPattern)
                    patternWord.Insert(patternWord.Count, new PatternElement(symbol.Row + 5, symbol.Ceil));
            }

            // 5x4 as right top
            rawPattern = GetFlipNoSquarePattern(4, 5, true);
            foreach (var rawWordPattern in rawPattern)
            {
                pattern.Insert(pattern.Count, new List<PatternElement>());
                var patternWord = pattern[^1];

                foreach (var symbol in rawWordPattern)
                    patternWord.Insert(patternWord.Count, new PatternElement(symbol.Row, symbol.Ceil + 5));
            }
        }

        return pattern;
    }

    private static List<List<PatternElement>> GetTenPattern()
    {
        var rnd = new Random();
        List<List<PatternElement>> pattern;

        // Random pattern picking
        if ((int)Math.Floor(rnd.NextDouble() * 4) > 1)
        {
            // 6x6, 4x4, 6x4, 4x6
            // 6x6 as top left
            pattern = GetSixPattern();

            // 4x4 as right bottom
            var rawPattern = GetFlipPattern(4);
            foreach (var rawWordPattern in rawPattern)
            {
                pattern.Insert(pattern.Count, new List<PatternElement>());
                var patternWord = pattern[^1];

                foreach (var symbol in rawWordPattern)
                    patternWord.Insert(patternWord.Count, new PatternElement(symbol.Row + 6, symbol.Ceil + 6));
            }

            // 4x6 as left bottom
            rawPattern = GetFlipNoSquarePattern(4, 6);
            foreach (var rawWordPattern in rawPattern)
            {
                pattern.Insert(pattern.Count, new List<PatternElement>());
                var patternWord = pattern[^1];

                foreach (var symbol in rawWordPattern)
                    patternWord.Insert(patternWord.Count, new PatternElement(symbol.Row + 6, symbol.Ceil));
            }

            // 6x4 as top right
            rawPattern = GetFlipNoSquarePattern(4, 6, true);
            foreach (var rawWordPattern in rawPattern)
            {
                pattern.Insert(pattern.Count, new List<PatternElement>());
                var patternWord = pattern[^1];

                foreach (var symbol in rawWordPattern)
                    patternWord.Insert(patternWord.Count, new PatternElement(symbol.Row, symbol.Ceil + 6));
            }
        }
        else
        {
            // 5x5 as 2x2
            pattern = GetFlipPattern(5);
            var rawPattern = GetFlipPattern(5);

            for (var i = 1; i < 4; i++)
            {
                foreach (var rawWordPattern in rawPattern)
                {
                    pattern.Insert(pattern.Count, new List<PatternElement>());
                    var patternWord = pattern[^1];

                    foreach (var symbol in rawWordPattern)
                    {
                        var symbolPattern = i switch
                        {
                            1 => new PatternElement(symbol.Row, symbol.Ceil + 5),
                            2 => new PatternElement(symbol.Row + 5, symbol.Ceil),
                            3 => new PatternElement(symbol.Ceil + 5, symbol.Row + 5),
                            _ => patternWord[patternWord.Count]
                        };
                        patternWord.Insert(patternWord.Count, symbolPattern);
                    }
                }

                rawPattern = GetFlipPattern(5);
            }
        }

        return pattern;
    }

    private static List<List<PatternElement>> GetPattern(int width)
    {
        return width switch
        {
            3 => GetFlipPattern(3),
            4 => GetFlipPattern(4),
            5 => GetFlipPattern(5),
            6 => GetSixPattern(),
            7 => GetSevenPattern(),
            8 => GetEightPattern(),
            9 => GetNinePattern(),
            10 => GetTenPattern(),
            _ => throw new Exception("Invalid value of width param")
        };
    }
}