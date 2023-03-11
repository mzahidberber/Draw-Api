using PostSharp.Aspects;
using PostSharp.Serialization;

namespace Draw.Core.Aspects.PostSharp.LoginAspects
{
    [PSerializable]
    public class LoginAspect : OnMethodBoundaryAspect
    {
        Type _validatorType;
        public LoginAspect(Type validatorType)
        {
            _validatorType = validatorType;
        }
        public override void OnEntry(MethodExecutionArgs args)
        {
            Console.WriteLine("Enty");
            //var validator = (IUserService?)Activator.CreateInstance(_validatorType);
            var entityType = _validatorType.BaseType.GetGenericArguments()[0];
            var att = args.Arguments.Where(u=>u.GetType()==entityType);
            Console.WriteLine(att);
            //foreach (var item in att)
            //{
            //    Console.WriteLine(validator.IsLoggedUser((User)item));
            //    if (validator.IsLoggedUser((User)item)!=true)
            //            throw new Exception("giriş yap");
            //}
        }
    }
}
