using Draw.Core.CrosCuttingConcers.Logging.Nlog;
using NLog;
using PostSharp.Aspects;
using PostSharp.Serialization;
using System.Text.Json;

namespace Draw.Core.Aspects.PostSharp.LoggingAspects
{
    [PSerializable]
    public class LogAspect: OnMethodBoundaryAspect
    {
        private static Logger _logger = LogManager.GetCurrentClassLogger();

        private string GetParams(MethodExecutionArgs args)
        {
            var parametres = "";

            foreach (var argument in args.Arguments.ToList())
            {
                if (argument != null)
                {
                    parametres += $"{argument.GetType().Name}:{argument.ToString()} | ";

                    if (argument.GetType().GetProperties().Length > 0 && argument.GetType().Name!="String")
                    {
                        if(argument.GetType()!=typeof(List<int>))
                        {
                            foreach (var prop in argument.GetType().GetProperties())
                            {
                                parametres += $"{prop.Name}:{prop.GetValue(argument)} ";
                            };
                        }
                        
                    }
                }
                else
                {
                    parametres += $"{argument?.GetType().Name}:<Null>";
                }
            }
            return parametres;
        }

        private string? GetUserInfo(MethodExecutionArgs args)
        {
            var userName = new object();
            var userId = new object();
            if (args.Instance is ILog)
            {
                userName = args.Instance.GetType().GetMethod("GetUserName")?.Invoke(args.Instance, new object[] { });
                userId = args.Instance.GetType().GetMethod("GetUserId")?.Invoke(args.Instance, new object[] { });
                return $"{userId} -- {userName}";
            }
            return null;
        }

        public override void OnEntry(MethodExecutionArgs args)
        {
            var message = string.Format("{0} | {1} | {2} | {3} | {4}",
            args.Method.ReflectedType?.Namespace,
            args.Method.ReflectedType?.Name,
            args.Method.Name,
            GetUserInfo(args),
            GetParams(args)
            );
            
            _logger.Info(message);
            base.OnEntry(args);
        }

        public override void OnSuccess(MethodExecutionArgs args)
        {
            base.OnSuccess(args);
            if(args.ReturnValue != null)
            {
                var result = JsonSerializer.Serialize(args.ReturnValue);
                var message = string.Format("{0} | {1} | {2} | {3} | {4} | {5}",args.Method.ReflectedType?.Namespace,
                    args.Method.ReflectedType?.Name,
                    args.Method.Name,
                    GetUserInfo(args),
                    "RETURN",
                    result
                    );
                _logger.Info(message);
            }
            
            
        }
    }
}
