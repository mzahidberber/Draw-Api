using Draw.Entities.Abstract;
using Draw.Entities.Concrete.Draw;

namespace Draw.Entities.Concrete.Commands
{
    public class DrawCommand:IEntity
    {
        public int DrawCommandId { get; set; }
        public string DrawCommandName { get; set; }
        
        public int DrawCommandDrawBoxId { get; set; }
        public DrawBox DrawCommandDrawBox { get; set; }
    }
}
