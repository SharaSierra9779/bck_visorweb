using NetTopologySuite.Geometries;

namespace webApiPostgrees.Model;

public class Predio
{
    public int Id { get; set; }
    public string Código { get; set; }
    public int Estrato { get; set; }
    public Polygon Geom { get; set; }
}
