namespace Draw.Core.Services.Model
{
    public class GeoRequest<T>
    {
        public T? data { get; set; }
        public int statusCode { get; set; }
        public string? error { get; set; }
    }
}
