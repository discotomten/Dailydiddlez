using Microsoft.EntityFrameworkCore;
using blazorHome.Data;
using Microsoft.EntityFrameworkCore.Query;

public class TodoService(IDbContextFactory<AppDbContext> factory)
{

    public async Task<List<TodoModell>> GetAllAsync(bool inkluderaKlar = false)
        {        
        await using var db = await factory.CreateDbContextAsync();
        return await db.Todos.Where(todo => inkluderaKlar || !todo.ÄrFärdig)
        .OrderBy(todo => todo.Slutdatum)
        .ToListAsync();
        }
    
    public async Task<List<TodoModell>> GetRangeAsync(DateOnly from, DateOnly to)
        {
        await using var db = await factory.CreateDbContextAsync();
        return await db.Todos
        .Where(todo => todo.Slutdatum >= from && todo.Slutdatum <= to)
        .ToListAsync();        
        }

    public async Task CreateAsync(SkapaTodoForm form)
        {
        await using var db = await factory.CreateDbContextAsync();
        db.Todos.Add(new TodoModell
        {
                Titel = form.Titel.Trim(),
                Beskrivning = form.Beskrivning,
                Slutdatum = form.Slutdatum,
                ÄrFärdig = false,
                Skapad = DateTime.UtcNow
        });

        await db.SaveChangesAsync();
        }
}