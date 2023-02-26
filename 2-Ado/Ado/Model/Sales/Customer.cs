namespace Ado.Model.Base;

public class Customer : EntityBase
{
    public string? FirstName { get; set; }
    public string? LastName { get; set; }
    public string? Phone { get; set; }
    public string? Email { get; set; }
    public string? Street { get; set; }
    public string? City { get; set; }
    public string? State { get; set; }
    public string? ZipCode { get; set; }

    public override string ToString()
    {
        return $"{FirstName} {LastName}";
    }
}