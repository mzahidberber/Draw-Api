using Draw.Entities.Concrete.Helpers;
using Draw.Entities.Concrete.Users;

namespace Draw.Api.Models.ElementTypeRequest
{
    public class UserElementTypeRequest
    {
        public User user { get; set; }
        public List<ElementType> elementTypes { get; set; }
    }
}
