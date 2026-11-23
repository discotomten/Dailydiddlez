public class TodoModell
{
    public long Id {get; set;}
    public string Titel {get; set;} = string.Empty;
    public string? Beskrivning {get; set;} = string.Empty;
    public bool ÄrFärdig {get; set;}
    public DateOnly? Slutdatum {get; set;}
    public DateTime Skapad {get; set;} = DateTime.UtcNow;
}