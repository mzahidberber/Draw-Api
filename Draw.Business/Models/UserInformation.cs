

using Draw.DrawManager.Concrete;

namespace Draw.Business.Models
{
    public class UserInformation
    {
        public string UserName { get; set; }
        public bool IsStartCommand { get; set; }
        public int? IsSelectedUserDrawBoxId { get; set; }
        public int? IsSelectedUserLayerId { get; set; }
        public DrawM DrawManager {get;set;}
        public UserInformation(string UserName, bool isStartCommand,int? selectedUserDrawBoxId,int? selectedUserLayerId, DrawM drawManager) 
        { 
            this.UserName = UserName;
            this.IsStartCommand = isStartCommand;
            this.IsSelectedUserDrawBoxId = selectedUserDrawBoxId;
            this.IsSelectedUserLayerId = selectedUserLayerId;
            this.DrawManager = drawManager;
        }
    }
}
