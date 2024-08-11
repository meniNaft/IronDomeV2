namespace IronDomeV2.Models
{
    public class MethodOfAttackTemplate
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public double Range { get; set; }
        public double Velocity { get; set; }

        // Navigation property for countermeasure
        public Countermeasure? Countermeasure { get; set; }
    }
}
