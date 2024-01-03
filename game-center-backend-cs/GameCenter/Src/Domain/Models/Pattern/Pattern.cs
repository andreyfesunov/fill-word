namespace game_center_backend_cs.Domain.Models.Pattern;

public static class Pattern
{
    public static readonly Dictionary<string, PatternElement[][][]> Collection = new()
    {
        {
            "3x3", new[]
            {
                new[]
                {
                    new[]
                    {
                        new PatternElement(0, 0),
                        new PatternElement(1, 0),
                        new PatternElement(1, 1)
                    },
                    new[]
                    {
                        new PatternElement(0, 1),
                        new PatternElement(0, 2),
                        new PatternElement(1, 2)
                    },
                    new[]
                    {
                        new PatternElement(2, 0),
                        new PatternElement(2, 1),
                        new PatternElement(2, 2)
                    }
                },
                new[]
                {
                    new[]
                    {
                        new PatternElement(0, 0),
                        new PatternElement(0, 1),
                        new PatternElement(0, 2)
                    },
                    new[]
                    {
                        new PatternElement(1, 0),
                        new PatternElement(1, 1),
                        new PatternElement(1, 2)
                    },
                    new[]
                    {
                        new PatternElement(2, 0),
                        new PatternElement(2, 1),
                        new PatternElement(2, 2)
                    }
                },
                new[]
                {
                    new[]
                    {
                        new PatternElement(0, 0),
                        new PatternElement(0, 1),
                        new PatternElement(0, 2),
                        new PatternElement(1, 2),
                        new PatternElement(2, 2)
                    },
                    new[]
                    {
                        new PatternElement(1, 0),
                        new PatternElement(2, 0),
                        new PatternElement(2, 1),
                        new PatternElement(1, 1)
                    }
                },
                new[]
                {
                    new[]
                    {
                        new PatternElement(0, 0),
                        new PatternElement(0, 1),
                        new PatternElement(0, 2),
                        new PatternElement(1, 2),
                        new PatternElement(1, 1)
                    },
                    new[]
                    {
                        new PatternElement(1, 0),
                        new PatternElement(2, 0),
                        new PatternElement(2, 1),
                        new PatternElement(2, 2)
                    }
                },
                new[]
                {
                    new[]
                    {
                        new PatternElement(0, 0),
                        new PatternElement(1, 0),
                        new PatternElement(2, 0)
                    },
                    new[]
                    {
                        new PatternElement(0, 1),
                        new PatternElement(0, 2),
                        new PatternElement(1, 2),
                        new PatternElement(1, 1),
                        new PatternElement(2, 1),
                        new PatternElement(2, 2)
                    }
                },
                new[]
                {
                    new[]
                    {
                        new PatternElement(2, 0),
                        new PatternElement(1, 0),
                        new PatternElement(1, 1)
                    },
                    new[]
                    {
                        new PatternElement(0, 0),
                        new PatternElement(0, 1),
                        new PatternElement(0, 2),
                        new PatternElement(1, 2),
                        new PatternElement(2, 2),
                        new PatternElement(2, 1)
                    }
                },
                new[]
                {
                    new[]
                    {
                        new PatternElement(0, 0),
                        new PatternElement(0, 1),
                        new PatternElement(0, 2),
                        new PatternElement(1, 2),
                        new PatternElement(1, 1),
                        new PatternElement(1, 0),
                        new PatternElement(2, 0),
                        new PatternElement(2, 1),
                        new PatternElement(2, 2)
                    }
                }
            }
        },
        {
            "3x4", new[]
            {
                new[]
                {
                    new[]
                    {
                        new PatternElement(1, 0),
                        new PatternElement(2, 0),
                        new PatternElement(2, 1),
                        new PatternElement(2, 2),
                        new PatternElement(2, 3)
                    },
                    new[]
                    {
                        new PatternElement(0, 0),
                        new PatternElement(0, 1),
                        new PatternElement(0, 2),
                        new PatternElement(0, 3),
                        new PatternElement(1, 3),
                        new PatternElement(1, 2),
                        new PatternElement(1, 1)
                    }
                },
                new[]
                {
                    new[]
                    {
                        new PatternElement(0, 0),
                        new PatternElement(0, 1),
                        new PatternElement(0, 2)
                    },
                    new[]
                    {
                        new PatternElement(1, 0),
                        new PatternElement(2, 0),
                        new PatternElement(2, 1),
                        new PatternElement(1, 1)
                    },
                    new[]
                    {
                        new PatternElement(0, 3),
                        new PatternElement(1, 3),
                        new PatternElement(2, 3),
                        new PatternElement(2, 2),
                        new PatternElement(1, 2)
                    }
                },
                new[]
                {
                    new[]
                    {
                        new PatternElement(1, 2),
                        new PatternElement(1, 1),
                        new PatternElement(1, 0),
                        new PatternElement(2, 0),
                        new PatternElement(2, 1)
                    },
                    new[]
                    {
                        new PatternElement(0, 0),
                        new PatternElement(0, 1),
                        new PatternElement(0, 2),
                        new PatternElement(0, 3),
                        new PatternElement(1, 3),
                        new PatternElement(2, 3),
                        new PatternElement(2, 2)
                    }
                },
                new[]
                {
                    new[]
                    {
                        new PatternElement(0, 0),
                        new PatternElement(1, 0),
                        new PatternElement(2, 0)
                    },
                    new[]
                    {
                        new PatternElement(1, 1),
                        new PatternElement(2, 1),
                        new PatternElement(2, 2),
                        new PatternElement(2, 3)
                    },
                    new[]
                    {
                        new PatternElement(0, 1),
                        new PatternElement(0, 2),
                        new PatternElement(0, 3),
                        new PatternElement(1, 3),
                        new PatternElement(1, 2)
                    }
                },
                new[]
                {
                    new[]
                    {
                        new PatternElement(0, 0),
                        new PatternElement(1, 0),
                        new PatternElement(2, 0),
                        new PatternElement(2, 1),
                        new PatternElement(1, 1),
                        new PatternElement(1, 2)
                    },
                    new[]
                    {
                        new PatternElement(0, 1),
                        new PatternElement(0, 2),
                        new PatternElement(0, 3),
                        new PatternElement(1, 3),
                        new PatternElement(2, 3),
                        new PatternElement(2, 2)
                    }
                },
                new[]
                {
                    new[]
                    {
                        new PatternElement(0, 1),
                        new PatternElement(0, 2),
                        new PatternElement(0, 3),
                        new PatternElement(1, 3),
                        new PatternElement(2, 3)
                    },
                    new[]
                    {
                        new PatternElement(0, 0),
                        new PatternElement(1, 0),
                        new PatternElement(2, 0),
                        new PatternElement(2, 1),
                        new PatternElement(2, 2),
                        new PatternElement(1, 2),
                        new PatternElement(1, 1)
                    }
                },
                new[]
                {
                    new[]
                    {
                        new PatternElement(0, 0),
                        new PatternElement(1, 0),
                        new PatternElement(2, 0),
                        new PatternElement(2, 1),
                        new PatternElement(1, 1),
                        new PatternElement(0, 1)
                    },
                    new[]
                    {
                        new PatternElement(2, 2),
                        new PatternElement(1, 2),
                        new PatternElement(0, 2),
                        new PatternElement(0, 3),
                        new PatternElement(1, 3),
                        new PatternElement(2, 3)
                    }
                },
                new[]
                {
                    new[]
                    {
                        new PatternElement(0, 3),
                        new PatternElement(1, 3),
                        new PatternElement(1, 2),
                        new PatternElement(1, 1)
                    },
                    new[]
                    {
                        new PatternElement(0, 2),
                        new PatternElement(0, 1),
                        new PatternElement(0, 0),
                        new PatternElement(1, 0),
                        new PatternElement(2, 0),
                        new PatternElement(2, 1),
                        new PatternElement(2, 2),
                        new PatternElement(2, 3)
                    }
                }
            }
        },
        {
            "3x5", new[]
            {
                new[]
                {
                    new[]
                    {
                        new PatternElement(1, 1),
                        new PatternElement(1, 2),
                        new PatternElement(1, 3)
                    },
                    new[]
                    {
                        new PatternElement(0, 0),
                        new PatternElement(0, 1),
                        new PatternElement(0, 2),
                        new PatternElement(0, 3),
                        new PatternElement(0, 4),
                        new PatternElement(1, 4)
                    },
                    new[]
                    {
                        new PatternElement(1, 0),
                        new PatternElement(2, 0),
                        new PatternElement(2, 1),
                        new PatternElement(2, 2),
                        new PatternElement(2, 3),
                        new PatternElement(2, 4)
                    }
                },
                new[]
                {
                    new[]
                    {
                        new PatternElement(1, 3),
                        new PatternElement(1, 2),
                        new PatternElement(1, 1),
                        new PatternElement(1, 0),
                        new PatternElement(2, 0),
                        new PatternElement(2, 1)
                    },
                    new[]
                    {
                        new PatternElement(0, 0),
                        new PatternElement(0, 1),
                        new PatternElement(0, 2),
                        new PatternElement(0, 3),
                        new PatternElement(0, 4),
                        new PatternElement(1, 4),
                        new PatternElement(2, 4),
                        new PatternElement(2, 3),
                        new PatternElement(2, 2)
                    }
                },
                new[]
                {
                    new[]
                    {
                        new PatternElement(0, 0),
                        new PatternElement(1, 0),
                        new PatternElement(2, 0)
                    },
                    new[]
                    {
                        new PatternElement(0, 1),
                        new PatternElement(0, 2),
                        new PatternElement(0, 3),
                        new PatternElement(0, 4),
                        new PatternElement(1, 4)
                    },
                    new[]
                    {
                        new PatternElement(1, 3),
                        new PatternElement(1, 2),
                        new PatternElement(1, 1),
                        new PatternElement(2, 1),
                        new PatternElement(2, 2),
                        new PatternElement(2, 3),
                        new PatternElement(2, 4)
                    }
                },
                new[]
                {
                    new[]
                    {
                        new PatternElement(1, 1),
                        new PatternElement(1, 2),
                        new PatternElement(1, 3),
                        new PatternElement(2, 3)
                    },
                    new[]
                    {
                        new PatternElement(0, 2),
                        new PatternElement(0, 3),
                        new PatternElement(0, 4),
                        new PatternElement(1, 4),
                        new PatternElement(2, 4)
                    },
                    new[]
                    {
                        new PatternElement(0, 1),
                        new PatternElement(0, 0),
                        new PatternElement(1, 0),
                        new PatternElement(2, 0),
                        new PatternElement(2, 1),
                        new PatternElement(2, 2)
                    }
                },
                new[]
                {
                    new[]
                    {
                        new PatternElement(0, 4),
                        new PatternElement(0, 3),
                        new PatternElement(0, 2),
                        new PatternElement(0, 1),
                        new PatternElement(1, 1),
                        new PatternElement(1, 2),
                        new PatternElement(1, 3)
                    },
                    new[]
                    {
                        new PatternElement(0, 0),
                        new PatternElement(1, 0),
                        new PatternElement(2, 0),
                        new PatternElement(2, 1),
                        new PatternElement(2, 2),
                        new PatternElement(2, 3),
                        new PatternElement(2, 4),
                        new PatternElement(1, 4)
                    }
                },
                new[]
                {
                    new[]
                    {
                        new PatternElement(0, 1),
                        new PatternElement(0, 2),
                        new PatternElement(0, 3)
                    },
                    new[]
                    {
                        new PatternElement(0, 0),
                        new PatternElement(1, 0),
                        new PatternElement(1, 1),
                        new PatternElement(1, 2),
                        new PatternElement(1, 3)
                    },
                    new[]
                    {
                        new PatternElement(0, 4),
                        new PatternElement(1, 4),
                        new PatternElement(2, 4),
                        new PatternElement(2, 3),
                        new PatternElement(2, 2),
                        new PatternElement(2, 1),
                        new PatternElement(2, 0)
                    }
                },
                new[]
                {
                    new[]
                    {
                        new PatternElement(0, 0),
                        new PatternElement(1, 0),
                        new PatternElement(2, 0),
                        new PatternElement(2, 1),
                        new PatternElement(1, 1),
                        new PatternElement(1, 2),
                        new PatternElement(1, 3)
                    },
                    new[]
                    {
                        new PatternElement(0, 1),
                        new PatternElement(0, 2),
                        new PatternElement(0, 3),
                        new PatternElement(0, 4),
                        new PatternElement(1, 4),
                        new PatternElement(2, 4),
                        new PatternElement(2, 3),
                        new PatternElement(2, 2)
                    }
                },
                new[]
                {
                    new[]
                    {
                        new PatternElement(0, 1),
                        new PatternElement(0, 2),
                        new PatternElement(0, 3),
                        new PatternElement(0, 4),
                        new PatternElement(1, 4),
                        new PatternElement(2, 4)
                    },
                    new[]
                    {
                        new PatternElement(0, 0),
                        new PatternElement(1, 0),
                        new PatternElement(1, 1),
                        new PatternElement(1, 2),
                        new PatternElement(1, 3),
                        new PatternElement(2, 3),
                        new PatternElement(2, 2),
                        new PatternElement(2, 1),
                        new PatternElement(2, 0)
                    }
                }
            }
        },
        {
            "3x6", new[]
            {
                new[]
                {
                    new[]
                    {
                        new PatternElement(2, 3),
                        new PatternElement(2, 4),
                        new PatternElement(2, 5)
                    },
                    new[]
                    {
                        new PatternElement(2, 0),
                        new PatternElement(2, 1),
                        new PatternElement(2, 2)
                    },
                    new[]
                    {
                        new PatternElement(0, 0),
                        new PatternElement(0, 1),
                        new PatternElement(0, 2),
                        new PatternElement(0, 3),
                        new PatternElement(0, 4)
                    },
                    new[]
                    {
                        new PatternElement(0, 5),
                        new PatternElement(1, 5),
                        new PatternElement(1, 4),
                        new PatternElement(1, 3),
                        new PatternElement(1, 2),
                        new PatternElement(1, 1),
                        new PatternElement(1, 0)
                    }
                },
                new[]
                {
                    new[]
                    {
                        new PatternElement(1, 3),
                        new PatternElement(1, 4),
                        new PatternElement(2, 4),
                        new PatternElement(2, 3)
                    },
                    new[]
                    {
                        new PatternElement(1, 1),
                        new PatternElement(1, 0),
                        new PatternElement(2, 0),
                        new PatternElement(2, 1)
                    },
                    new[]
                    {
                        new PatternElement(0, 0),
                        new PatternElement(0, 1),
                        new PatternElement(0, 2),
                        new PatternElement(1, 2),
                        new PatternElement(2, 2)
                    },
                    new[]
                    {
                        new PatternElement(0, 3),
                        new PatternElement(0, 4),
                        new PatternElement(0, 5),
                        new PatternElement(1, 5),
                        new PatternElement(2, 5)
                    }
                },
                new[]
                {
                    new[]
                    {
                        new PatternElement(1, 0),
                        new PatternElement(2, 0),
                        new PatternElement(2, 1),
                        new PatternElement(2, 2)
                    },
                    new[]
                    {
                        new PatternElement(0, 0),
                        new PatternElement(0, 1),
                        new PatternElement(0, 2),
                        new PatternElement(0, 3),
                        new PatternElement(0, 4),
                        new PatternElement(1, 4)
                    },
                    new[]
                    {
                        new PatternElement(1, 1),
                        new PatternElement(1, 2),
                        new PatternElement(1, 3),
                        new PatternElement(2, 3),
                        new PatternElement(2, 4),
                        new PatternElement(2, 5),
                        new PatternElement(1, 5),
                        new PatternElement(0, 5)
                    }
                },
                new[]
                {
                    new[]
                    {
                        new PatternElement(0, 4),
                        new PatternElement(0, 3),
                        new PatternElement(1, 3),
                        new PatternElement(1, 4)
                    },
                    new[]
                    {
                        new PatternElement(0, 0),
                        new PatternElement(1, 0),
                        new PatternElement(1, 1),
                        new PatternElement(2, 1),
                        new PatternElement(2, 0)
                    },
                    new[]
                    {
                        new PatternElement(0, 1),
                        new PatternElement(0, 2),
                        new PatternElement(1, 2),
                        new PatternElement(2, 2),
                        new PatternElement(2, 3),
                        new PatternElement(2, 4),
                        new PatternElement(2, 5),
                        new PatternElement(1, 5),
                        new PatternElement(0, 5)
                    }
                },
                new[]
                {
                    new[]
                    {
                        new PatternElement(2, 1),
                        new PatternElement(2, 2),
                        new PatternElement(2, 3)
                    },
                    new[]
                    {
                        new PatternElement(0, 4),
                        new PatternElement(0, 5),
                        new PatternElement(1, 5)
                    },
                    new[]
                    {
                        new PatternElement(2, 0),
                        new PatternElement(1, 0),
                        new PatternElement(1, 1),
                        new PatternElement(1, 2)
                    },
                    new[]
                    {
                        new PatternElement(0, 0),
                        new PatternElement(0, 1),
                        new PatternElement(0, 2),
                        new PatternElement(0, 3),
                        new PatternElement(1, 3),
                        new PatternElement(1, 4),
                        new PatternElement(2, 4),
                        new PatternElement(2, 5)
                    }
                },
                new[]
                {
                    new[]
                    {
                        new PatternElement(0, 0),
                        new PatternElement(1, 0),
                        new PatternElement(1, 1),
                        new PatternElement(2, 1),
                        new PatternElement(2, 0)
                    },
                    new[]
                    {
                        new PatternElement(0, 3),
                        new PatternElement(1, 3),
                        new PatternElement(1, 4),
                        new PatternElement(0, 4),
                        new PatternElement(0, 5),
                        new PatternElement(1, 5)
                    },
                    new[]
                    {
                        new PatternElement(0, 1),
                        new PatternElement(0, 2),
                        new PatternElement(1, 2),
                        new PatternElement(2, 2),
                        new PatternElement(2, 3),
                        new PatternElement(2, 4),
                        new PatternElement(2, 5)
                    }
                },
                new[]
                {
                    new[]
                    {
                        new PatternElement(0, 0),
                        new PatternElement(0, 1),
                        new PatternElement(0, 2)
                    },
                    new[]
                    {
                        new PatternElement(2, 1),
                        new PatternElement(2, 2),
                        new PatternElement(2, 3),
                        new PatternElement(2, 4),
                        new PatternElement(2, 5),
                        new PatternElement(1, 5),
                        new PatternElement(1, 4)
                    },
                    new[]
                    {
                        new PatternElement(2, 0),
                        new PatternElement(1, 0),
                        new PatternElement(1, 1),
                        new PatternElement(1, 2),
                        new PatternElement(1, 3),
                        new PatternElement(0, 3),
                        new PatternElement(0, 4),
                        new PatternElement(0, 5)
                    }
                },
                new[]
                {
                    new[]
                    {
                        new PatternElement(0, 1),
                        new PatternElement(1, 1),
                        new PatternElement(1, 2),
                        new PatternElement(0, 2)
                    },
                    new[]
                    {
                        new PatternElement(0, 4),
                        new PatternElement(1, 4),
                        new PatternElement(2, 4),
                        new PatternElement(2, 5),
                        new PatternElement(1, 5),
                        new PatternElement(0, 5)
                    },
                    new[]
                    {
                        new PatternElement(0, 0),
                        new PatternElement(1, 0),
                        new PatternElement(2, 0),
                        new PatternElement(2, 1),
                        new PatternElement(2, 2),
                        new PatternElement(2, 3),
                        new PatternElement(1, 3),
                        new PatternElement(0, 3)
                    }
                }
            }
        },
        {
            "4x4", new[]
            {
                new[]
                {
                    new[]
                    {
                        new PatternElement(0, 0),
                        new PatternElement(0, 1),
                        new PatternElement(0, 2),
                        new PatternElement(0, 3)
                    },
                    new[]
                    {
                        new PatternElement(3, 0),
                        new PatternElement(2, 0),
                        new PatternElement(2, 1),
                        new PatternElement(2, 2)
                    },
                    new[]
                    {
                        new PatternElement(1, 0),
                        new PatternElement(1, 1),
                        new PatternElement(1, 2),
                        new PatternElement(1, 3),
                        new PatternElement(2, 3),
                        new PatternElement(3, 3),
                        new PatternElement(3, 2),
                        new PatternElement(3, 1)
                    }
                },
                new[]
                {
                    new[]
                    {
                        new PatternElement(1, 0),
                        new PatternElement(1, 1),
                        new PatternElement(1, 2)
                    },
                    new[]
                    {
                        new PatternElement(2, 2),
                        new PatternElement(2, 1),
                        new PatternElement(2, 0),
                        new PatternElement(3, 0),
                        new PatternElement(3, 1),
                        new PatternElement(3, 2)
                    },
                    new[]
                    {
                        new PatternElement(0, 0),
                        new PatternElement(0, 1),
                        new PatternElement(0, 2),
                        new PatternElement(0, 3),
                        new PatternElement(1, 3),
                        new PatternElement(2, 3),
                        new PatternElement(3, 3)
                    }
                },
                new[]
                {
                    new[]
                    {
                        new PatternElement(1, 0),
                        new PatternElement(1, 1),
                        new PatternElement(1, 2),
                        new PatternElement(2, 2)
                    },
                    new[]
                    {
                        new PatternElement(2, 1),
                        new PatternElement(2, 0),
                        new PatternElement(3, 0),
                        new PatternElement(3, 1),
                        new PatternElement(3, 2)
                    },
                    new[]
                    {
                        new PatternElement(0, 0),
                        new PatternElement(0, 1),
                        new PatternElement(0, 2),
                        new PatternElement(0, 3),
                        new PatternElement(1, 3),
                        new PatternElement(2, 3),
                        new PatternElement(3, 3)
                    }
                },
                new[]
                {
                    new[]
                    {
                        new PatternElement(1, 2),
                        new PatternElement(1, 1),
                        new PatternElement(2, 1),
                        new PatternElement(2, 2)
                    },
                    new[]
                    {
                        new PatternElement(0, 1),
                        new PatternElement(0, 0),
                        new PatternElement(1, 0),
                        new PatternElement(2, 0),
                        new PatternElement(3, 0)
                    },
                    new[]
                    {
                        new PatternElement(0, 2),
                        new PatternElement(0, 3),
                        new PatternElement(1, 3),
                        new PatternElement(2, 3),
                        new PatternElement(3, 3),
                        new PatternElement(3, 2),
                        new PatternElement(3, 1)
                    }
                },
                new[]
                {
                    new[]
                    {
                        new PatternElement(0, 0),
                        new PatternElement(1, 0),
                        new PatternElement(1, 1)
                    },
                    new[]
                    {
                        new PatternElement(0, 1),
                        new PatternElement(0, 2),
                        new PatternElement(1, 2),
                        new PatternElement(2, 2),
                        new PatternElement(2, 1),
                        new PatternElement(2, 0)
                    },
                    new[]
                    {
                        new PatternElement(0, 3),
                        new PatternElement(1, 3),
                        new PatternElement(2, 3),
                        new PatternElement(3, 3),
                        new PatternElement(3, 2),
                        new PatternElement(3, 1),
                        new PatternElement(3, 0)
                    }
                },
                new[]
                {
                    new[]
                    {
                        new PatternElement(1, 0),
                        new PatternElement(1, 1),
                        new PatternElement(2, 1)
                    },
                    new[]
                    {
                        new PatternElement(0, 0),
                        new PatternElement(0, 1),
                        new PatternElement(0, 2),
                        new PatternElement(1, 2),
                        new PatternElement(2, 2)
                    },
                    new[]
                    {
                        new PatternElement(2, 0),
                        new PatternElement(3, 0),
                        new PatternElement(3, 1),
                        new PatternElement(3, 2),
                        new PatternElement(3, 3),
                        new PatternElement(2, 3),
                        new PatternElement(1, 3),
                        new PatternElement(0, 3)
                    }
                }
            }
        },
        {
            "4x5", new[]
            {
                new[]
                {
                    new[]
                    {
                        new PatternElement(2, 2),
                        new PatternElement(2, 3),
                        new PatternElement(2, 4),
                        new PatternElement(3, 4),
                        new PatternElement(3, 3),
                        new PatternElement(3, 2)
                    },
                    new[]
                    {
                        new PatternElement(3, 1),
                        new PatternElement(2, 1),
                        new PatternElement(1, 1),
                        new PatternElement(1, 2),
                        new PatternElement(1, 3),
                        new PatternElement(1, 4),
                        new PatternElement(0, 4)
                    },
                    new[]
                    {
                        new PatternElement(0, 3),
                        new PatternElement(0, 2),
                        new PatternElement(0, 1),
                        new PatternElement(0, 0),
                        new PatternElement(1, 0),
                        new PatternElement(2, 0),
                        new PatternElement(3, 0)
                    }
                },
                new[]
                {
                    new[]
                    {
                        new PatternElement(3, 0),
                        new PatternElement(3, 1),
                        new PatternElement(3, 2),
                        new PatternElement(3, 3),
                        new PatternElement(3, 4)
                    },
                    new[]
                    {
                        new PatternElement(1, 0),
                        new PatternElement(2, 0),
                        new PatternElement(2, 1),
                        new PatternElement(2, 2),
                        new PatternElement(2, 3),
                        new PatternElement(2, 4)
                    },
                    new[]
                    {
                        new PatternElement(0, 0),
                        new PatternElement(0, 1),
                        new PatternElement(0, 2),
                        new PatternElement(0, 3),
                        new PatternElement(0, 4),
                        new PatternElement(1, 4),
                        new PatternElement(1, 3),
                        new PatternElement(1, 2),
                        new PatternElement(1, 1)
                    }
                },
                new[]
                {
                    new[]
                    {
                        new PatternElement(3, 4),
                        new PatternElement(2, 4),
                        new PatternElement(1, 4),
                        new PatternElement(0, 4),
                        new PatternElement(0, 3),
                        new PatternElement(1, 3)
                    },
                    new[]
                    {
                        new PatternElement(0, 0),
                        new PatternElement(1, 0),
                        new PatternElement(2, 0),
                        new PatternElement(2, 1),
                        new PatternElement(1, 1),
                        new PatternElement(0, 1),
                        new PatternElement(0, 2)
                    },
                    new[]
                    {
                        new PatternElement(3, 0),
                        new PatternElement(3, 1),
                        new PatternElement(3, 2),
                        new PatternElement(3, 3),
                        new PatternElement(2, 3),
                        new PatternElement(2, 2),
                        new PatternElement(1, 2)
                    }
                },
                new[]
                {
                    new[]
                    {
                        new PatternElement(2, 0),
                        new PatternElement(3, 0),
                        new PatternElement(3, 1),
                        new PatternElement(3, 2),
                        new PatternElement(3, 3)
                    },
                    new[]
                    {
                        new PatternElement(1, 0),
                        new PatternElement(1, 1),
                        new PatternElement(1, 2),
                        new PatternElement(1, 3),
                        new PatternElement(2, 3),
                        new PatternElement(2, 2),
                        new PatternElement(2, 1)
                    },
                    new[]
                    {
                        new PatternElement(0, 0),
                        new PatternElement(0, 1),
                        new PatternElement(0, 2),
                        new PatternElement(0, 3),
                        new PatternElement(0, 4),
                        new PatternElement(1, 4),
                        new PatternElement(2, 4),
                        new PatternElement(3, 4)
                    }
                },
                new[]
                {
                    new[]
                    {
                        new PatternElement(3, 3),
                        new PatternElement(3, 2),
                        new PatternElement(3, 1),
                        new PatternElement(3, 0),
                        new PatternElement(2, 0),
                        new PatternElement(2, 1)
                    },
                    new[]
                    {
                        new PatternElement(0, 1),
                        new PatternElement(0, 2),
                        new PatternElement(0, 3),
                        new PatternElement(0, 4),
                        new PatternElement(1, 4),
                        new PatternElement(2, 4),
                        new PatternElement(3, 4)
                    },
                    new[]
                    {
                        new PatternElement(0, 0),
                        new PatternElement(1, 0),
                        new PatternElement(1, 1),
                        new PatternElement(1, 2),
                        new PatternElement(1, 3),
                        new PatternElement(2, 3),
                        new PatternElement(2, 2)
                    }
                },
                new[]
                {
                    new[]
                    {
                        new PatternElement(3, 2),
                        new PatternElement(3, 3),
                        new PatternElement(3, 4),
                        new PatternElement(2, 4),
                        new PatternElement(1, 4),
                        new PatternElement(0, 4)
                    },
                    new[]
                    {
                        new PatternElement(2, 0),
                        new PatternElement(3, 0),
                        new PatternElement(3, 1),
                        new PatternElement(2, 1),
                        new PatternElement(1, 1),
                        new PatternElement(1, 0),
                        new PatternElement(0, 0)
                    },
                    new[]
                    {
                        new PatternElement(0, 1),
                        new PatternElement(0, 2),
                        new PatternElement(0, 3),
                        new PatternElement(1, 3),
                        new PatternElement(2, 3),
                        new PatternElement(2, 2),
                        new PatternElement(1, 2)
                    }
                }
            }
        },
        {
            "4x6", new[]
            {
                new[]
                {
                    new[]
                    {
                        new PatternElement(0, 2),
                        new PatternElement(0, 3),
                        new PatternElement(0, 4),
                        new PatternElement(0, 5)
                    },
                    new[]
                    {
                        new PatternElement(1, 5),
                        new PatternElement(2, 5),
                        new PatternElement(3, 5),
                        new PatternElement(3, 4),
                        new PatternElement(3, 3)
                    },
                    new[]
                    {
                        new PatternElement(3, 2),
                        new PatternElement(3, 1),
                        new PatternElement(2, 1),
                        new PatternElement(2, 2),
                        new PatternElement(2, 3),
                        new PatternElement(2, 4)
                    },
                    new[]
                    {
                        new PatternElement(3, 0),
                        new PatternElement(2, 0),
                        new PatternElement(1, 0),
                        new PatternElement(0, 0),
                        new PatternElement(0, 1),
                        new PatternElement(1, 1),
                        new PatternElement(1, 2),
                        new PatternElement(1, 3),
                        new PatternElement(1, 4)
                    }
                },
                new[]
                {
                    new[]
                    {
                        new PatternElement(2, 0),
                        new PatternElement(3, 0),
                        new PatternElement(3, 1),
                        new PatternElement(3, 2)
                    },
                    new[]
                    {
                        new PatternElement(1, 0),
                        new PatternElement(1, 1),
                        new PatternElement(2, 1),
                        new PatternElement(2, 2),
                        new PatternElement(2, 3)
                    },
                    new[]
                    {
                        new PatternElement(0, 3),
                        new PatternElement(0, 4),
                        new PatternElement(0, 5),
                        new PatternElement(1, 5),
                        new PatternElement(2, 5),
                        new PatternElement(3, 5)
                    },
                    new[]
                    {
                        new PatternElement(0, 0),
                        new PatternElement(0, 1),
                        new PatternElement(0, 2),
                        new PatternElement(1, 2),
                        new PatternElement(1, 3),
                        new PatternElement(1, 4),
                        new PatternElement(2, 4),
                        new PatternElement(3, 4),
                        new PatternElement(3, 3)
                    }
                },
                new[]
                {
                    new[]
                    {
                        new PatternElement(1, 2),
                        new PatternElement(2, 2),
                        new PatternElement(2, 3),
                        new PatternElement(1, 3)
                    },
                    new[]
                    {
                        new PatternElement(0, 5),
                        new PatternElement(1, 5),
                        new PatternElement(2, 5),
                        new PatternElement(3, 5)
                    },
                    new[]
                    {
                        new PatternElement(0, 0),
                        new PatternElement(0, 1),
                        new PatternElement(0, 2),
                        new PatternElement(0, 3),
                        new PatternElement(0, 4),
                        new PatternElement(1, 4),
                        new PatternElement(2, 4),
                        new PatternElement(3, 4)
                    },
                    new[]
                    {
                        new PatternElement(1, 0),
                        new PatternElement(1, 1),
                        new PatternElement(2, 1),
                        new PatternElement(2, 0),
                        new PatternElement(3, 0),
                        new PatternElement(3, 1),
                        new PatternElement(3, 2),
                        new PatternElement(3, 3)
                    }
                },
                new[]
                {
                    new[]
                    {
                        new PatternElement(0, 3),
                        new PatternElement(0, 4),
                        new PatternElement(0, 5),
                        new PatternElement(1, 5)
                    },
                    new[]
                    {
                        new PatternElement(2, 0),
                        new PatternElement(3, 0),
                        new PatternElement(3, 1),
                        new PatternElement(3, 2)
                    },
                    new[]
                    {
                        new PatternElement(0, 0),
                        new PatternElement(0, 1),
                        new PatternElement(0, 2),
                        new PatternElement(1, 2),
                        new PatternElement(1, 3),
                        new PatternElement(1, 4),
                        new PatternElement(2, 4),
                        new PatternElement(2, 5)
                    },
                    new[]
                    {
                        new PatternElement(1, 0),
                        new PatternElement(1, 1),
                        new PatternElement(2, 1),
                        new PatternElement(2, 2),
                        new PatternElement(2, 3),
                        new PatternElement(3, 3),
                        new PatternElement(3, 4),
                        new PatternElement(3, 5)
                    }
                },
                new[]
                {
                    new[]
                    {
                        new PatternElement(0, 2),
                        new PatternElement(0, 3),
                        new PatternElement(0, 4)
                    },
                    new[]
                    {
                        new PatternElement(1, 0),
                        new PatternElement(2, 0),
                        new PatternElement(3, 0),
                        new PatternElement(3, 1),
                        new PatternElement(3, 2),
                        new PatternElement(3, 3)
                    },
                    new[]
                    {
                        new PatternElement(2, 1),
                        new PatternElement(2, 2),
                        new PatternElement(2, 3),
                        new PatternElement(2, 4),
                        new PatternElement(3, 4),
                        new PatternElement(3, 5),
                        new PatternElement(2, 5)
                    },
                    new[]
                    {
                        new PatternElement(0, 0),
                        new PatternElement(0, 1),
                        new PatternElement(1, 1),
                        new PatternElement(1, 2),
                        new PatternElement(1, 3),
                        new PatternElement(1, 4),
                        new PatternElement(1, 5),
                        new PatternElement(0, 5)
                    }
                },
                new[]
                {
                    new[]
                    {
                        new PatternElement(0, 5),
                        new PatternElement(1, 5),
                        new PatternElement(2, 5),
                        new PatternElement(3, 5)
                    },
                    new[]
                    {
                        new PatternElement(0, 0),
                        new PatternElement(1, 0),
                        new PatternElement(1, 1),
                        new PatternElement(1, 2),
                        new PatternElement(1, 3)
                    },
                    new[]
                    {
                        new PatternElement(2, 0),
                        new PatternElement(3, 0),
                        new PatternElement(3, 1),
                        new PatternElement(3, 2),
                        new PatternElement(3, 3),
                        new PatternElement(3, 4)
                    },
                    new[]
                    {
                        new PatternElement(0, 1),
                        new PatternElement(0, 2),
                        new PatternElement(0, 3),
                        new PatternElement(0, 4),
                        new PatternElement(1, 4),
                        new PatternElement(2, 4),
                        new PatternElement(2, 3),
                        new PatternElement(2, 2),
                        new PatternElement(2, 1)
                    }
                },
                new[]
                {
                    new[]
                    {
                        new PatternElement(3, 1),
                        new PatternElement(3, 2),
                        new PatternElement(3, 3)
                    },
                    new[]
                    {
                        new PatternElement(2, 1),
                        new PatternElement(2, 2),
                        new PatternElement(2, 3),
                        new PatternElement(2, 4),
                        new PatternElement(3, 4)
                    },
                    new[]
                    {
                        new PatternElement(3, 0),
                        new PatternElement(2, 0),
                        new PatternElement(1, 0),
                        new PatternElement(0, 0),
                        new PatternElement(0, 1),
                        new PatternElement(0, 2),
                        new PatternElement(0, 3)
                    },
                    new[]
                    {
                        new PatternElement(1, 1),
                        new PatternElement(1, 2),
                        new PatternElement(1, 3),
                        new PatternElement(1, 4),
                        new PatternElement(0, 4),
                        new PatternElement(0, 5),
                        new PatternElement(1, 5),
                        new PatternElement(2, 5),
                        new PatternElement(3, 5)
                    }
                },
                new[]
                {
                    new[]
                    {
                        new PatternElement(0, 0),
                        new PatternElement(1, 0),
                        new PatternElement(2, 0),
                        new PatternElement(2, 1),
                        new PatternElement(3, 1),
                        new PatternElement(3, 0)
                    },
                    new[]
                    {
                        new PatternElement(0, 2),
                        new PatternElement(0, 3),
                        new PatternElement(1, 3),
                        new PatternElement(2, 3),
                        new PatternElement(2, 4),
                        new PatternElement(1, 4),
                        new PatternElement(1, 5),
                        new PatternElement(0, 5),
                        new PatternElement(0, 4)
                    },
                    new[]
                    {
                        new PatternElement(0, 1),
                        new PatternElement(1, 1),
                        new PatternElement(1, 2),
                        new PatternElement(2, 2),
                        new PatternElement(3, 2),
                        new PatternElement(3, 3),
                        new PatternElement(3, 4),
                        new PatternElement(3, 5),
                        new PatternElement(2, 5)
                    }
                }
            }
        },
        {
            "5x5", new[]
            {
                new[]
                {
                    new[]
                    {
                        new PatternElement(4, 1),
                        new PatternElement(4, 0),
                        new PatternElement(3, 0),
                        new PatternElement(3, 1),
                        new PatternElement(3, 2)
                    },
                    new[]
                    {
                        new PatternElement(0, 0),
                        new PatternElement(0, 1),
                        new PatternElement(0, 2),
                        new PatternElement(0, 3),
                        new PatternElement(0, 4)
                    },
                    new[]
                    {
                        new PatternElement(1, 1),
                        new PatternElement(1, 2),
                        new PatternElement(1, 3),
                        new PatternElement(1, 4),
                        new PatternElement(2, 4),
                        new PatternElement(3, 4),
                        new PatternElement(4, 4)
                    },
                    new[]
                    {
                        new PatternElement(1, 0),
                        new PatternElement(2, 0),
                        new PatternElement(2, 1),
                        new PatternElement(2, 2),
                        new PatternElement(2, 3),
                        new PatternElement(3, 3),
                        new PatternElement(4, 3),
                        new PatternElement(4, 2)
                    }
                },
                new[]
                {
                    new[]
                    {
                        new PatternElement(4, 0),
                        new PatternElement(4, 1),
                        new PatternElement(4, 2),
                        new PatternElement(3, 2)
                    },
                    new[]
                    {
                        new PatternElement(1, 1),
                        new PatternElement(1, 2),
                        new PatternElement(1, 3),
                        new PatternElement(1, 4),
                        new PatternElement(2, 4)
                    },
                    new[]
                    {
                        new PatternElement(2, 0),
                        new PatternElement(1, 0),
                        new PatternElement(0, 0),
                        new PatternElement(0, 1),
                        new PatternElement(0, 2),
                        new PatternElement(0, 3),
                        new PatternElement(0, 4)
                    },
                    new[]
                    {
                        new PatternElement(3, 0),
                        new PatternElement(3, 1),
                        new PatternElement(2, 1),
                        new PatternElement(2, 2),
                        new PatternElement(2, 3),
                        new PatternElement(3, 3),
                        new PatternElement(4, 3),
                        new PatternElement(4, 4),
                        new PatternElement(3, 4)
                    }
                },
                new[]
                {
                    new[]
                    {
                        new PatternElement(1, 0),
                        new PatternElement(1, 1),
                        new PatternElement(2, 1)
                    },
                    new[]
                    {
                        new PatternElement(2, 0),
                        new PatternElement(3, 0),
                        new PatternElement(4, 0),
                        new PatternElement(4, 1),
                        new PatternElement(4, 2),
                        new PatternElement(4, 3),
                        new PatternElement(4, 4)
                    },
                    new[]
                    {
                        new PatternElement(3, 1),
                        new PatternElement(3, 2),
                        new PatternElement(3, 3),
                        new PatternElement(3, 4),
                        new PatternElement(2, 4),
                        new PatternElement(1, 4),
                        new PatternElement(0, 4)
                    },
                    new[]
                    {
                        new PatternElement(0, 0),
                        new PatternElement(0, 1),
                        new PatternElement(0, 2),
                        new PatternElement(0, 3),
                        new PatternElement(1, 3),
                        new PatternElement(2, 3),
                        new PatternElement(2, 2),
                        new PatternElement(1, 2)
                    }
                },
                new[]
                {
                    new[]
                    {
                        new PatternElement(3, 1),
                        new PatternElement(3, 2),
                        new PatternElement(2, 2),
                        new PatternElement(1, 2),
                        new PatternElement(0, 2)
                    },
                    new[]
                    {
                        new PatternElement(4, 0),
                        new PatternElement(4, 1),
                        new PatternElement(4, 2),
                        new PatternElement(4, 3),
                        new PatternElement(3, 3),
                        new PatternElement(2, 3)
                    },
                    new[]
                    {
                        new PatternElement(3, 0),
                        new PatternElement(2, 0),
                        new PatternElement(2, 1),
                        new PatternElement(1, 1),
                        new PatternElement(0, 1),
                        new PatternElement(0, 0),
                        new PatternElement(1, 0)
                    },
                    new[]
                    {
                        new PatternElement(1, 3),
                        new PatternElement(0, 3),
                        new PatternElement(0, 4),
                        new PatternElement(1, 4),
                        new PatternElement(2, 4),
                        new PatternElement(3, 4),
                        new PatternElement(4, 4)
                    }
                },
                new[]
                {
                    new[]
                    {
                        new PatternElement(4, 4),
                        new PatternElement(3, 4),
                        new PatternElement(3, 3),
                        new PatternElement(3, 2),
                        new PatternElement(3, 1)
                    },
                    new[]
                    {
                        new PatternElement(2, 0),
                        new PatternElement(3, 0),
                        new PatternElement(4, 0),
                        new PatternElement(4, 1),
                        new PatternElement(4, 2),
                        new PatternElement(4, 3)
                    },
                    new[]
                    {
                        new PatternElement(1, 1),
                        new PatternElement(1, 0),
                        new PatternElement(0, 0),
                        new PatternElement(0, 1),
                        new PatternElement(0, 2),
                        new PatternElement(0, 3),
                        new PatternElement(0, 4)
                    },
                    new[]
                    {
                        new PatternElement(1, 2),
                        new PatternElement(1, 3),
                        new PatternElement(1, 4),
                        new PatternElement(2, 4),
                        new PatternElement(2, 3),
                        new PatternElement(2, 2),
                        new PatternElement(2, 1)
                    }
                },
                new[]
                {
                    new[]
                    {
                        new PatternElement(0, 1),
                        new PatternElement(1, 1),
                        new PatternElement(1, 2),
                        new PatternElement(0, 2)
                    },
                    new[]
                    {
                        new PatternElement(0, 0),
                        new PatternElement(1, 0),
                        new PatternElement(2, 0),
                        new PatternElement(3, 0),
                        new PatternElement(3, 1),
                        new PatternElement(4, 1),
                        new PatternElement(4, 0)
                    },
                    new[]
                    {
                        new PatternElement(2, 1),
                        new PatternElement(2, 2),
                        new PatternElement(3, 2),
                        new PatternElement(3, 3),
                        new PatternElement(2, 3),
                        new PatternElement(1, 3),
                        new PatternElement(0, 3)
                    },
                    new[]
                    {
                        new PatternElement(4, 2),
                        new PatternElement(4, 3),
                        new PatternElement(4, 4),
                        new PatternElement(3, 4),
                        new PatternElement(2, 4),
                        new PatternElement(1, 4),
                        new PatternElement(0, 4)
                    }
                },
                new[]
                {
                    new[]
                    {
                        new PatternElement(0, 4),
                        new PatternElement(1, 4),
                        new PatternElement(2, 4),
                        new PatternElement(3, 4),
                        new PatternElement(4, 4)
                    },
                    new[]
                    {
                        new PatternElement(4, 0),
                        new PatternElement(4, 1),
                        new PatternElement(4, 2),
                        new PatternElement(4, 3),
                        new PatternElement(3, 3),
                        new PatternElement(2, 3)
                    },
                    new[]
                    {
                        new PatternElement(0, 0),
                        new PatternElement(1, 0),
                        new PatternElement(1, 1),
                        new PatternElement(2, 1),
                        new PatternElement(2, 0),
                        new PatternElement(3, 0),
                        new PatternElement(3, 1)
                    },
                    new[]
                    {
                        new PatternElement(0, 1),
                        new PatternElement(0, 2),
                        new PatternElement(0, 3),
                        new PatternElement(1, 3),
                        new PatternElement(1, 2),
                        new PatternElement(2, 2),
                        new PatternElement(3, 2)
                    }
                },
                new[]
                {
                    new[]
                    {
                        new PatternElement(0, 0),
                        new PatternElement(1, 0),
                        new PatternElement(2, 0),
                        new PatternElement(3, 0),
                        new PatternElement(4, 0)
                    },
                    new[]
                    {
                        new PatternElement(1, 2),
                        new PatternElement(1, 1),
                        new PatternElement(2, 1),
                        new PatternElement(3, 1),
                        new PatternElement(3, 2),
                        new PatternElement(3, 3)
                    },
                    new[]
                    {
                        new PatternElement(4, 1),
                        new PatternElement(4, 2),
                        new PatternElement(4, 3),
                        new PatternElement(4, 4),
                        new PatternElement(3, 4),
                        new PatternElement(2, 4)
                    },
                    new[]
                    {
                        new PatternElement(0, 1),
                        new PatternElement(0, 2),
                        new PatternElement(0, 3),
                        new PatternElement(0, 4),
                        new PatternElement(1, 4),
                        new PatternElement(1, 3),
                        new PatternElement(2, 3),
                        new PatternElement(2, 2)
                    }
                },
                new[]
                {
                    new[]
                    {
                        new PatternElement(1, 0),
                        new PatternElement(2, 0),
                        new PatternElement(3, 0),
                        new PatternElement(3, 1),
                        new PatternElement(2, 1),
                        new PatternElement(2, 2)
                    },
                    new[]
                    {
                        new PatternElement(1, 1),
                        new PatternElement(1, 2),
                        new PatternElement(1, 3),
                        new PatternElement(2, 3),
                        new PatternElement(3, 3),
                        new PatternElement(3, 2)
                    },
                    new[]
                    {
                        new PatternElement(4, 0),
                        new PatternElement(4, 1),
                        new PatternElement(4, 2),
                        new PatternElement(4, 3),
                        new PatternElement(4, 4),
                        new PatternElement(3, 4)
                    },
                    new[]
                    {
                        new PatternElement(0, 0),
                        new PatternElement(0, 1),
                        new PatternElement(0, 2),
                        new PatternElement(0, 3),
                        new PatternElement(0, 4),
                        new PatternElement(1, 4),
                        new PatternElement(2, 4)
                    }
                }
            }
        }
    };
}