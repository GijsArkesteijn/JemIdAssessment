using System.ComponentModel.DataAnnotations;

public class Artiekel{
    //Weet niet hoe ik een error message kan krijgen wanneer het id niet uniek is via data annotations
    [Key]
    [Range(1,13,ErrorMessage="Rating must between 1 to 10")] 
    [Required]
    public int Id{get;set;}

    [Required]
    [MaxLength(50)]
    public string Naam{get;set;}

    [Required]
    [Range(0, int.MaxValue, ErrorMessage = "Please enter valid integer Number")]
    public int Potmaat{get;set;}

    [Required]
    public int Planthoogte{get;set;}

    public string? Kleur{get;set;}
    
    [Required]
    public string Productgroep{get;set;}
}