namespace Person.Models;

public class PersonModel
{
    public Guid Id { get; init; }
    public string Name { get; set; }

    public PersonModel(string name)
    {
        Id = Guid.NewGuid();
        Name = name;
    }
}