using Draw.Entities.Abstract;
using Draw.Entities.Concrete.Commands;
using Draw.Entities.Concrete.Helpers;
using Draw.Entities.Concrete.Users;
using System.Collections.Generic;

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
        public string DrawName { get; set; }

        public int UserId { get; set; }
        public User User { get; set; }

        public ICollection<DrawCommand> DrawCommands { get; set; }

        public ICollection<Layer> Layers { get; set; }
    }
}
