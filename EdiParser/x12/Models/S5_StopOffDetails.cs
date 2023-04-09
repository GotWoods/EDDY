using System;
using System.Collections.Generic;
using System.Text;
using EdiParser.Attributes;
using EdiParser.Validation;

namespace EdiParser.x12.Models
{
    [Segment("S5")]
    public class S5_StopOffDetails : EdiX12Segment
    {
        [Position(01)]
        public int? StopSequenceNumber { get; set; }

        [Position(02)]
        public string StopReasonCode { get; set; }

        [Position(03)]
        public decimal? Weight { get; set; }

        [Position(04)]
        public string WeightUnitCode { get; set; }

        [Position(05)]
        public decimal? NumberOfUnitsShipped { get; set; }

        [Position(06)]
        public string UnitOrBasisForMeasurementCode { get; set; }

        [Position(07)]
        public decimal? Volume { get; set; }

        [Position(08)]
        public string VolumeUnitQualifier { get; set; }

        [Position(09)]
        public string Description { get; set; }

        [Position(10)]
        public string StandardPointLocationCode { get; set; }

        [Position(11)]
        public string AccomplishCode { get; set; }

        public override ValidationResult Validate()
        {
            var validator = new BasicValidator<S5_StopOffDetails>(this);
            validator.Required(x => x.StopSequenceNumber);
            validator.Required(x => x.StopReasonCode);
            validator.IfOneIsFilled_AllAreRequired(x => x.Weight, x => x.WeightUnitCode);
            validator.IfOneIsFilled_AllAreRequired(x => x.NumberOfUnitsShipped, x => x.UnitOrBasisForMeasurementCode);
            validator.IfOneIsFilled_AllAreRequired(x => x.Volume, x => x.VolumeUnitQualifier);
            validator.Length(x => x.StopSequenceNumber, 1, 3);
            validator.Length(x => x.StopReasonCode, 2);
            validator.Length(x => x.Weight, 1, 10);
            validator.Length(x => x.WeightUnitCode, 1);
            validator.Length(x => x.NumberOfUnitsShipped, 1, 10);
            validator.Length(x => x.UnitOrBasisForMeasurementCode, 2);
            validator.Length(x => x.Volume, 1, 8);
            validator.Length(x => x.VolumeUnitQualifier, 1);
            validator.Length(x => x.Description, 1, 80);
            validator.Length(x => x.StandardPointLocationCode, 6, 9);
            validator.Length(x => x.AccomplishCode, 1);
            return validator.Results;
        }


    }
}
