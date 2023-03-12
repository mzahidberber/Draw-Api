using Draw.DrawManager.Concrete.BaseCommand;
using Draw.Manager.Concrete.DrawElements;

namespace Draw.DataAccess.Abstract.Commands
{
    public interface IBaseCommand
    {
        object AddPoint(MouseInformation mouseInformation);
        void SetCommandMemory(CommandMemory commandProxy);
        void FinishCommand();
        //void SetRadius(double radius);
        //void SetPen(int penId);
        //void SetEditElementsId(List<int> editElementsId);
        //void SetLayerId(int layerId);
        //void SetUserName(string userName);
    }
}
