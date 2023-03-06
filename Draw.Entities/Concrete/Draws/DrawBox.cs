using Draw.Entities.Abstract;
using Draw.Entities.Concrete.Commands;
using Draw.Entities.Concrete.Elements;
using Draw.Entities.Concrete.Helpers;
using Draw.Entities.Concrete.Users;

namespace Draw.Entities.Concrete.Draw
{
    public class DrawBox:IEntity
    {
        public DrawBox()
        {
            this.Layers= new List<Layer>();
            this.DrawCommands= new List<DrawCommand>();
        }
        public int DrawBoxId { get; set; }
        public string DrawName { get; set; }= null!;

        public string UserId { get; set; } = null!;

        //public User User { get; set; } = null!;

        public ICollection<DrawCommand> DrawCommands { get; set; }

        public ICollection<Layer> Layers { get; set; }
    }
}
