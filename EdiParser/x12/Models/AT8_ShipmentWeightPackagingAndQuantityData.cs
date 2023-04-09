using System;
using System.Collections.Generic;
using System.Text;
using EdiParser.Attributes;
using EdiParser.Validation;

namespace EdiParser.x12.Models
{
    [Segment("AT8")]
    public class AT8_ShipmentWeightPackagingAndQuantityData : EdiX12Segment
    {
        [Position(1)]
        public string WeightQualifier { get; set; }
        [Position(2)]
        public string WeightUnitCode { get; set; }

        [Position(3)]
        public decimal? Weight { get; set; }
        [Position(4)]
        public int? LadingQuantity { get; set; }
        [Position(5)]
        public int? LadingQuantityUnitized { get; set; }

        [Position(6)]
        public string VolumeUnitQualifier { get; set; }
        
        [Position(7)]
        public decimal? Volume { get; set; }
        
        public override ValidationResult Validate()
        {
            var validator = new BasicValidator<AT8_ShipmentWeightPackagingAndQuantityData>(this);

            validator.Length(x => x.WeightQualifier, 1, 2);
            validator.Length(x => x.WeightUnitCode, 1);
            validator.Length(x => x.Weight, 1, 10);
            validator.Length(x => x.LadingQuantity, 1, 7);
            validator.Length(x => x.LadingQuantityUnitized, 1, 7);
            validator.Length(x => x.VolumeUnitQualifier, 1);
            validator.Length(x => x.Volume, 1, 8);

            //If 1 or 2 or 3 are present, all are required
            validator.IfOneIsFilled_AllAreRequired(x => x.WeightQualifier, x => x.WeightUnitCode, x => x.Weight);
            validator.IfOneIsFilled_AllAreRequired(x => x.VolumeUnitQualifier, x => x.Volume);
            return validator.Results;
        }


    }
}
