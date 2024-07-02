using GestaoLivraria.Enum;

namespace GestaoLivraria.Communication.Response;

public class ResponseCreatedBook
{
    public Guid Id { get; set; }
    public string Title { get; set; }
    public string Autor { get; set; }
    public string Generous { get; set; }
    public double Price { get; set; }
}
