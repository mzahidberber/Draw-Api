using Draw.Entities.Abstract;
using Microsoft.AspNetCore.Identity;

namespace Draw.Entities.Concrete.Draw
{
    public class User : IdentityUser, IEntity
    {
        public User()
        {
            DrawBoxs = new List<DrawBox>();
            Pens = new List<Pen>();
        }
        public int DrawLimit { get; set; }
        public int NumberDraw { get; set; }
        public int DrawRemainder { get; set; }
        public int DrawElements { get; set; }
        public ICollection<DrawBox> DrawBoxs { get; set; }
        public ICollection<Pen> Pens { get; set; }
        int IEntity.Id { get; set; }

        public void CalculateDraw()=> DrawRemainder = DrawLimit - NumberDraw;
        public void CaclulateElements()=> DrawElements = DrawBoxs.Sum(x => x.NumberOfLayerElements);
    }
}
