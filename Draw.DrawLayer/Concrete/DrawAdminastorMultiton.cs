namespace Draw.DrawLayer.Concrete
{
    public class DrawAdminastorMultiton
    {
        private static Dictionary<string,DrawAdminastor> _drawAdminastorMemory = new Dictionary<string, DrawAdminastor>();

        private static object _lock = new object();

        private DrawAdminastorMultiton() { }

        public static DrawAdminastor GetDrawAdminastor(string userId)
        {
            DataControl();
            lock (_lock)
            {
                if (!_drawAdminastorMemory.ContainsKey(userId))
                {
                    _drawAdminastorMemory.Add(userId, new DrawAdminastor(userId));
                }
            }
            return _drawAdminastorMemory[userId];
        }

        private static void DataControl()
        {
            var deleteList=new List<string>();
            foreach (var item in _drawAdminastorMemory)
            {
                var userTime= item.Value.GetUseTime();

                if((DateTime.Now.Minute-15) > userTime.Minute) 
                {
                    deleteList.Add(item.Key);
                }
            }
            deleteList.ForEach(item => { _drawAdminastorMemory.Remove(item); });
        }
    }
}
