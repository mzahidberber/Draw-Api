using Draw.Entities.Concrete.Commands;

namespace Draw.DataAccess.Abstract.Commands
{
    public interface IDrawCommandDal : IEntityRepository<DrawCommand>
    {
    }
}
