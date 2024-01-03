namespace game_center_backend_cs.Domain.Models.Pattern;

public class PatternElement
{
    public PatternElement(int row, int ceil)
    {
        Row = row;
        Ceil = ceil;
    }

    public int Row { get; set; }
    public int Ceil { get; set; }
}