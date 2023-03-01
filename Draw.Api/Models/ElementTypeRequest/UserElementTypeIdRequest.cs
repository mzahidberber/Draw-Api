using Draw.Entities.Concrete.Users;

namespace Draw.Api.Models.ElementTypeRequest
{
    public class UserElementTypeIdRequest
    {
        public User user { get; set; }
        public int elementTypeId { get; set; }
    }
}
