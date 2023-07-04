

using Newtonsoft.Json;

namespace Draw.Web.Models
{
    public class TitleListViewModel
    {
        public string url { get; set; }
        public List<MainTitle> MainTitles { get; set; }
    }
}
