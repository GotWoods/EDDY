using System.Collections.Generic;
using System.Text;
using EdiParser.x12.Models;

namespace EdiParser.x12.DomainModels._210
{
    public class StopOffDetails
    {
        //S5
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

        //L11
        public List<KeyValuePair<string, string>> ReferenceNumbers { get; set; } = new();

        //G62
        public List<Date> Dates { get; set; } = new();

        //n1/n2/n3/n4/g61
        public Entity Entity {  get; set; }

        public List<Note> Notes { get; set; } = new();
        public List<StopDetails> Details { get; set; } = new();
        public List<DescriptionMarksAndNumbers> DescriptionAndMarks { get; set; } = new();
        public AT8_ShipmentWeightPackagingAndQuantityData ShipmentWeightPackagingAndQuantityData { get; set; }

        //details

    }
}
