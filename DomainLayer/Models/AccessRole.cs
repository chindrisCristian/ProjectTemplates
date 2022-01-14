namespace DomainLayer.Models;

public class AccessRole : BaseModel
{
    public string RoleName { get; set; }

    public override string? ToString() => RoleName;
}
