namespace Person.Models;

public class PersonModel
{
    public Guid Id { get; init; }
    public string Name { get; private set; }

    public PersonModel(string name)
    {
        Id = Guid.NewGuid();
        Name = name;
    }

    public void UpdateName(string name)
    {
        Name = name;
    }

    public void SetInactive()
    {
        Name = "desativado";
    }
}