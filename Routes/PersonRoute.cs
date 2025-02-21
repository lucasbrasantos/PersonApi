using Microsoft.EntityFrameworkCore;
using Person.Data;
using Person.Models;

namespace Person.Routes;

public static class PersonRoute
{

    public static void PersonRoutes(this WebApplication app)
    {
        var route = app.MapGroup("person");
        
        route.MapGet("", async (PersonContext context) =>
        {
            var people = await context.People.ToListAsync();
            return Results.Ok(people);
        });

        route.MapPost("", async (PersonRequest req, PersonContext context) =>
        {
            var person = new PersonModel(req.name);
            await context.AddAsync(person);
            await context.SaveChangesAsync(); // "commit" ira salvar os dados no banco de dados
        });

        route.MapPut("{id:guid}", async (Guid id, PersonRequest req, PersonContext context) =>
        {
            var person = await context.People.FirstOrDefaultAsync(x => x.Id == id);

            if (person == null)
            {
                return Results.NotFound();
            }
            
            person.UpdateName(req.name);
            await context.SaveChangesAsync();
            return Results.Ok(person);
            
        });

        route.MapDelete("{id:guid}", async (Guid id, PersonContext context) =>
        {
            var person = await context.People.FirstOrDefaultAsync(x => x.Id == id);
            
            if (person == null)
            {
                return Results.NotFound();
            }
            
            person.SetInactive();
            await context.SaveChangesAsync();
            return Results.Ok(person);

        });
    }
    
}