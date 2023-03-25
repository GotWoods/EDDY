namespace EdiParser.x12.Models.Internals;

public interface ISegmentConverter<T>
{
    bool CanConvert(EdiX12Segment segment);
    T From(EdiX12Segment segment);
}