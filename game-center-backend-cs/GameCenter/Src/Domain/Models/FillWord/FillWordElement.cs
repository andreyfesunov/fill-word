namespace game_center_backend_cs.Domain.Models.FillWord;

public class FillWordElement
{
    public FillWordElement(int id, char content)
    {
        Content = content;
        Id = id;
    }

    public char Content { get; set; }
    public int Id { get; set; }
}