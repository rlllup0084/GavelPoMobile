namespace GavelPoMobile.Domain.Aggregates;
public sealed class User {
    public Guid Oid { get; set; }

    public string? No { get; set; }

    public string? Name { get; set; }

    public string? Email { get; set; }

    public string? Popassword { get; set; }
}
