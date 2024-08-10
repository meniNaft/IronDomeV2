using Microsoft.EntityFrameworkCore;
using System.Security.Policy;

namespace IronDomeV2.Models;

[Index(nameof(Name), IsUnique = true)]
public class Attacker
{
    public int Id { get; set; }
    public string Name { get; set; }
    public int Distance { get; set; }
    public IEnumerable<Volley> Volleys { get; set; }
}

