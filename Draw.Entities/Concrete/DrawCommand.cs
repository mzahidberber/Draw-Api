using Draw.Entities.Abstract;

namespace Draw.Entities.Concrete
{
    public class DrawCommand : IEntity
    {
        public int DrawCommandId { get; set; }
        public string DrawCommandName { get; set; } = null!;

        public int DrawCommandDrawBoxId { get; set; }
        public DrawBox DrawCommandDrawBox { get; set; } = null!;
    }
}
