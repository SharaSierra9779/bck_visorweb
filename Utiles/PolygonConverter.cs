using NetTopologySuite.Geometries;
using NetTopologySuite.IO;
using System.Text.Json.Serialization;
using System.Text.Json;

namespace webApiPostgrees.Utiles;

public class PolygonConverter : JsonConverter<Polygon>
{
    public override Polygon Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
    {
        var wkt = reader.GetString();
        return new WKTReader().Read(wkt) as Polygon;
    }

    public override void Write(Utf8JsonWriter writer, Polygon value, JsonSerializerOptions options)
    {
        writer.WriteStringValue(value.ToText());
    }
}
