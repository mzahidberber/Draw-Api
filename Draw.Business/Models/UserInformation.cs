using Draw.DrawManager.Concrete;

namespace Draw.DrawManager.Models
{
    public class UserInformation
    {
        public string UserName { get; set; }
        public bool IsStartCommand { get; set; }
        public int? IsSelectedUserDrawBoxId { get; set; }
        public int? IsSelectedUserLayerId { get; set; }
        //private DrawBoxManager _drawBoxManager { get; set; }
        public DrawM DrawManager {get;set;}
        public UserInformation(string UserName, bool isStartCommand,int? selectedUserDrawBoxId,int? selectedUserLayerId,DrawM drawManager) 
        { 
            this.UserName = UserName;
            this.IsStartCommand = isStartCommand;
            this.IsSelectedUserDrawBoxId = selectedUserDrawBoxId;
            this.IsSelectedUserLayerId = selectedUserLayerId;
            this.DrawManager = drawManager;
            //this._drawBoxManager = new DrawBoxManager();
        }

        //internal DrawBoxManager GetDrawBoxManager() { return this._drawBoxManager; }
        //public void SetIsStartCommand(bool isStartCommand) => this._isStartCommand = isStartCommand;
        //public void SetSelectedDrawBox(int selectedDrawBoxId) => this._selectedUserDrawBoxId = selectedDrawBoxId;
        //public void SetSelectedLayer(int selectedLayerId) => this._selectedUserLayerId = selectedLayerId;
    }
}
