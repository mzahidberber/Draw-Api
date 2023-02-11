using Draw.Entities.Concrete.Commands;

namespace Draw.DataAccess.Abstract.Commands
{
    internal interface IDrawCommandDal : IEntityRepository<DrawCommand>
    {
    }
}
