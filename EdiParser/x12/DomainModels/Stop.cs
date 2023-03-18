using System.Collections.Generic;

namespace EdiParser.x12.DomainModels;

public class Stop
{
    public int? StopSequenceNumber { get; set; }

    public string StopReasonCode { get; set; }

    public decimal? Weight { get; set; }

    public string WeightUnitCode { get; set; }

    public decimal? NumberOfUnitsShipped { get; set; }

    public string UnitOrBasisForMeasurementCode { get; set; }

    public decimal? Volume { get; set; }

    public string VolumeUnitQualifier { get; set; }

    public string Description { get; set; }

    public string StandardPointLocationCode { get; set; }

    public string AccomplishCode { get; set; }

    public List<KeyValuePair<string, string>> ReferenceNumbers { get; set; } = new();
}