using Draw.Core.CrosCuttingConcers.Handling;
using Draw.Entities.Concrete.Draw;
using Newtonsoft.Json.Linq;
using System.Text;

namespace Draw.DrawLayer.Concrete.FileCommands
{
    public enum ModelType
    {
        drawBox,layer,element,point,radius,ssangle,pen,penstyle,pointtype
    }

    internal class DrawBoxBuilder
    {
        private DrawBox _drawBox { get; set; }
        private Layer? _lastLayer { get; set; }
        private Element? _lastElement { get; set; }
        private Point? _lastPoint { get; set; }
        private Radius? _lastRadius { get; set; }
        private SSAngle? _lastSSAngle { get; set; }
        private Pen? _lastPen { get; set; }
        private PenStyle? _lastPenStyle { get; set; }
        private int _layerIndex { get; set; } = 0;
        private int _elementIndex { get; set; } = 0;
        private int _radiusIndex { get; set; } = 0;
        private int _pointIndex { get; set; } = 0;
        private int _ssangleIndex { get; set; } = 0;
        private int _penIndex { get; set; } = 0;
        private int _penStyleIndex { get; set; } = 0;
        private ModelType? _model { get; set; }
        public DrawBoxBuilder(string drawBoxName)
        {
            _drawBox = new DrawBox { Name=drawBoxName};
        }

        public bool AddInfo(string info)
        {
            switch (_model)
            {
                case ModelType.layer:
                    return BuildLayer(_lastLayer, info);
                case ModelType.pen:
                    return BuildPen(_lastPen, info);
                case ModelType.penstyle:
                    return BuildPenStyle(_lastPenStyle, info);
                case ModelType.element:
                    return BuildElement(_lastElement, info);
                case ModelType.point:
                    return BuildPoint(_lastPoint, info);
                case ModelType.radius:
                    return BuildRadius(_lastRadius, info);
                case ModelType.ssangle:
                    return BuildSSAngle(_lastSSAngle, info);
                default:
                    return false;
            };
        }

        public void SetModel(ModelType model)
        {
            this._model= model;
      
            switch (_model)
            {
                case ModelType.layer:
                    _lastLayer = new Layer();
                    break;
                case ModelType.pen:
                    _lastPen = new Pen();
                    break;
                case ModelType.penstyle:
                    _lastPenStyle = new PenStyle();
                    break;
                case ModelType.element:
                    _lastElement = new Element();
                    break;
                case ModelType.point:
                    _lastPoint = new Point();
                    break;
                case ModelType.radius:
                    _lastRadius = new Radius();
                    break;
                case ModelType.ssangle:
                    _lastSSAngle = new SSAngle();
                    break;
                default:
                    _model = null;
                    break;
            };
        }

        public DrawBox Build() => this._drawBox;

        private bool BuildLayer(Layer layer, string info)
        {
            bool value;
            int value1;
            float value2;
            switch (_layerIndex)
            {
                case 0:
                    if (info == "" || info == null) return false;
                    layer.Name = info;
                    break;
                case 1:
                    if (bool.TryParse(info, out value)) layer.Lock = value;
                    else return false;
                    break;
                case 2:
                    if (bool.TryParse(info, out value)) layer.Visibility = value;
                    else return false;
                    break;
                case 3:
                    if (float.TryParse(info, out value2))
                    {
                        layer.Thickness = value2;
                        _layerIndex = 0;
                        _drawBox.Layers.Add(layer);
                        _model = null;
                        return true;
                    }
                    else return false;
                default:
                    return false;
            };
            _layerIndex++;
            return true;
        }

        private bool BuildElement(Element element, string info)
        {
            bool value;
            int value1;
            switch (_elementIndex)
            {
                case 0:
                    if (Int32.TryParse(info, out value1)) element.TypeId = value1;
                    else return false;
                    break;
                case 1:
                    if (Int32.TryParse(info, out value1))
                    {
                        element.PenId = value1;
                        _elementIndex = 0;
                        _lastLayer.Elements.Add(element);
                        _model = null;
                        return true;
                    }
                    else return false;
                default:
                    return false;
                
            };
            _elementIndex++;
            return true;
        }
        
        private bool BuildPoint(Point point, string info)
        {
            int value1;
            double value2;
            switch (_pointIndex)
            {
                case 0:
                    if (double.TryParse(info, out value2)) point.X = Math.Round(value2, 4);
                    else return false;
                    break;
                case 1:
                    if (double.TryParse(info, out value2)) point.Y = Math.Round(value2, 4);
                    else return false;
                    break;
                case 2:
                    if (int.TryParse(info, out value1))
                    {
                        point.PointTypeId = value1;
                        _pointIndex = 0;
                        _lastElement.Points.Add(point);
                        _model = null;
                        return true;
                    }
                    else return false;
                default:
                    break;
            };
            _pointIndex++;
            return true;
        }

        private bool BuildRadius(Radius radius, string info)
        {
            double value;
            switch (_radiusIndex)
            {
                case 0:
                    if (double.TryParse(info, out value))
                    {
                        radius.Value = Math.Round(value, 4);
                        _radiusIndex = 0;
                        _lastElement.Radiuses.Add(radius);
                        _model = null;
                        return true;
                    }
                    else return false;
                default:
                    break;
            };
            _radiusIndex++;
            return true;
        }

        private bool BuildSSAngle(SSAngle ssangle, string info)
        {
            double value;
            switch (_ssangleIndex)
            {
                case 0:
                    if (info == "" || info == null) return false;
                    ssangle.Type = info;
                    break;
                case 1:
                    if (double.TryParse(info, out value))
                    {
                        ssangle.Value = Math.Round(value, 4);
                        _ssangleIndex = 0;
                        _lastElement.SSAngles.Add(ssangle);
                        _model = null;
                        return true;
                    }
                    else return false;
                default:
                    break;
            };
            _ssangleIndex++;
            return true;
        }

        private bool BuildPen(Pen pen, string info)
        {
            int value;
            switch (_penIndex)
            {
                case 0:
                    if (info == "" || info == null) return false;
                    pen.Name = info;
                    break;
                case 1:
                    if (int.TryParse(info, out value)) pen.Red = value;
                    else return false;
                    break;
                case 2:
                    if (int.TryParse(info, out value)) pen.Blue = value;
                    else return false;
                    break;
                case 3:
                    if (int.TryParse(info, out value)) pen.Green = value;
                    else return false;
                    break;
                case 4:
                    if (int.TryParse(info, out value)) 
                    { 
                        pen.PenStyleId = value;
                        _penIndex = 0;
                        _lastLayer.Pen = pen;
                        _model = null;
                        return true;
                    }
                    else return false;
                    
                default:
                    break;
            };
            _penIndex++;
            return true;
        }

        private bool BuildPenStyle(PenStyle penStyle,string info)
        {
            int value;
            switch (_penStyleIndex)
            {
                case 0:
                    if (int.TryParse(info, out value)) penStyle.Id = value;
                    else return false;
                    break;
                case 1:
                    if (info == "" || info == null) return false;
                    penStyle.Name = info;
                    _penStyleIndex = 0;
                    _lastPen.PenStyle = penStyle;
                    _model = null;
                    return true;
                default:
                    break;
            };
            _penStyleIndex++;
            return true;
        }
    }

    public static class DrawFile
    {
        
        public static Task<MemoryStream> SaveDrawFile(DrawBox drawBox)
        {
            var builder = new StringBuilder();
            builder.AppendLine(drawBox.Name);

            foreach (var layer in drawBox.Layers)
            {
                builder.AppendLine("#L");
                builder.AppendLine(layer.Name.ToString());
                builder.AppendLine(layer.Lock.ToString());
                builder.AppendLine(layer.Visibility.ToString());
                builder.AppendLine(layer.Thickness.ToString());
                builder.AppendLine("#PEN");
                builder.AppendLine(layer.Pen.Name.ToString());
                builder.AppendLine(layer.Pen.Red.ToString());
                builder.AppendLine(layer.Pen.Blue.ToString());
                builder.AppendLine(layer.Pen.Green.ToString());
                builder.AppendLine(layer.Pen.PenStyleId.ToString());
                builder.AppendLine("#PS");
                builder.AppendLine(layer.Pen.PenStyle.Id.ToString());
                builder.AppendLine(layer.Pen.PenStyle.Name.ToString());

                foreach (var element in layer.Elements)
                {
                    builder.AppendLine("#E");
                    builder.AppendLine(element.TypeId.ToString());
                    builder.AppendLine(element.PenId.ToString());

                    foreach (var point in element.Points)
                    {
                        builder.AppendLine("#P");
                        builder.AppendLine(point.X.ToString());
                        builder.AppendLine(point.Y.ToString());
                        builder.AppendLine(point.PointTypeId.ToString());
                    }


                    foreach (var radius in element.Radiuses)
                    {
                        builder.AppendLine("#R");
                        builder.AppendLine(radius.Value.ToString());
                    }


                    foreach (var ssangle in element.SSAngles)
                    {
                        builder.AppendLine("#SS");
                        builder.AppendLine(ssangle.Type.ToString());
                        builder.AppendLine(ssangle.Value.ToString());
                    }
                }


            }
            var stream = new MemoryStream();
            var writer = new StreamWriter(stream);
            writer.Write(builder.ToString());
            writer.Flush();
            stream.Position = 0;

            return Task.FromResult(stream);
        }

        public static bool CheckFile(Stream draw)
        {
            StreamReader reader = new StreamReader(draw);
            string line = reader.ReadLine();
            int index = 0;
            if (line == null || line == "" ) { return false; }
            while ((line = reader.ReadLine()) != null)
            {
                if (line == "")
                    continue;
                switch (line)
                {
                    case "#L":
                        index = 0;
                        break;
                    case "#PEN":
                        if (index != 4 )
                            return false;
                        index = -1;
                        break;
                    case "#PS":
                        if (index != 5)
                            return false;
                        index = -1;
                        break;
                    case "#E":
                        if (index != 2)
                            return false;
                        index = -1;
                        break;
                    case "#P":
                        break;
                    case "#R":
                        break;
                    case "#SS":
                        break;
                    default:
                        break;
                };

                index++;
            }
            return true;
        }
        
        public static Task<DrawBox?> ReadDraw(Stream draw)
        {
            try
            {
                StreamReader reader = new StreamReader(draw);
                var builder = new DrawBoxBuilder(reader.ReadLine());
                string line = "";
                while ((line = reader.ReadLine()) != null)
                {
                    if (line == "")
                        continue;
                    switch (line)
                    {
                        case "#L":
                            builder.SetModel(ModelType.layer);
                            break;
                        case "#PEN":
                            builder.SetModel(ModelType.pen);
                            break;
                        case "#PS":
                            builder.SetModel(ModelType.penstyle);
                            break;
                        case "#E":
                            builder.SetModel(ModelType.element);
                            break;
                        case "#P":
                            builder.SetModel(ModelType.point);
                            break;
                        case "#R":
                            builder.SetModel(ModelType.radius);
                            break;
                        case "#SS":
                            builder.SetModel(ModelType.ssangle);
                            break;
                        default:
                            if(!builder.AddInfo(line))
                                return Task.FromResult<DrawBox?>(null);
                            break;
                    };

                    
                }
                return Task.FromResult<DrawBox?>(builder.Build());
            }
            catch (Exception)
            {
                throw new CustomException("The File is Corrupt!");
            }
        }
    }
}
