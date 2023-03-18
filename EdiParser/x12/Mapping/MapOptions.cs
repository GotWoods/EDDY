namespace EdiParser.x12.Mapping;

public class MapOptions
{
    public string LineEnding { get; set; }
    public string Separator { get; set; }
    public string StandardsVersion { get; set; }

    public bool PerformValidations { get; set; } = true;
}