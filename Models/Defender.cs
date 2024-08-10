namespace IronDomeV2.Models;

public class Defender
{
    public int Id { get; set; }
    public string Name { get; set; }

    // Navigation property
    public List<Countermeasure> Countermeasures { get; set; }
}
