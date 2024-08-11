using System.ComponentModel.DataAnnotations;

namespace IronDomeV2.Models;

public class Volley
{
    [Display(Name = "Volley Name")]
    public int Id { get; set; }

    // Foreign key
    public int AttackerId { get; set; }
    public Attacker Attacker { get; set; }

    // Navigation property
    public IEnumerable<MethodOfAttack> MethodsOfAttack { get; set; }
}
