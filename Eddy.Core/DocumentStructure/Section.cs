using System.Collections.Generic;

namespace Eddy.Core.DocumentStructure;

public class Section
{
    //public int SectionPosition { get; set; }
    public string Name { get; set; }
    public string Code { get; set; }
    public SectionType SectionType { get; set; }
    public List<Section> Sections { get; set; } = new();
    public List<Segment> Segments { get; set; } = new();
}