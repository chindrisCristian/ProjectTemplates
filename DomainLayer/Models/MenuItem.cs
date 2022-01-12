namespace DomainLayer.Models;

public class MenuItem : BaseModel
{
    public string Title { get; set; }

    public int? IdParent { get; set; }
}
