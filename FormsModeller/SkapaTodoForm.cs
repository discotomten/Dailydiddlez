using System.ComponentModel.DataAnnotations;

public class SkapaTodoForm
{
    [Required(ErrorMessage = "Titel krävs")]
    public string Titel {get; set;} = string.Empty;
    public string? Beskrivning {get; set;}
    public DateOnly? Slutdatum {get; set;}
}