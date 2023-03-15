namespace Draw.DrawLayer.Concrete
{
    public class DrawMemoryMultiton
    {
        private static Dictionary<string, DrawMemory> _drawMemory = new Dictionary<string, DrawMemory>();

        private static object _lock = new object();

        private DrawMemoryMultiton(){}

        public static DrawMemory GetDrawMemory(string name)
        {
            lock (_lock)
            {
                if (!_drawMemory.ContainsKey(name))
                {
                    _drawMemory.Add(name, new DrawMemory(name));
                }
            }
            return _drawMemory[name];
        }
    }

    
}
