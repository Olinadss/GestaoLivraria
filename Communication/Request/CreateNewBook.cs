using GestaoLivraria.Enum;

namespace GestaoLivraria.Communication.Request;

public class CreateNewBook
{
    public string Title { get; set; } = string.Empty;
    public string Autor { get; set; } = string.Empty;
    public int Generous { get; set; }
    public double Price { get; set; }
}
