using IronDomeV2.Models;

namespace IronDomeV2.ViewModel
{
    public class VMVolley
    {
        public int AttackerId { get; set; }
        public IEnumerable<MethodOfAttack> MethodsOfAttack { get; set; }
    }
}
