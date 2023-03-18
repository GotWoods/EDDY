using EdiParser.x12.Models.Internals;
using System;
using System.Collections.Generic;
using System.Text;
using EdiParser.Attributes;
using EdiParser.Validation;

namespace EdiParser.x12.Models
{
    [Segment("MS1")]
    public class MS1_EquipmentShipmentOrRealPropertyLocation : EdiX12Segment
    {
		[Position(01)]
        public string CityName { get; set; }

        [Position(02)]
        public string StateOrProvinceCode { get; set; }

        [Position(03)]
        public string CountryCode { get; set; }

        [Position(04)]
        public string LongitudeCode { get; set; }

        [Position(05)]
        public string LatitudeCode { get; set; }

        [Position(06)]
        public string LongitudeDirectionIdentifierCode { get; set; }

        [Position(07)]
        public string LatitudeDirectionIdentifierCode { get; set; }

        [Position(08)]
        public string PostalCode { get; set; }

        [Position(09)]
        public string LongitudeDecimalFormat { get; set; }

        [Position(10)]
        public string LatitudeDecimalFormat { get; set; }

        public override ValidationResult Validate()
        {
            var validator = new BasicValidator<MS1_EquipmentShipmentOrRealPropertyLocation>(this);
            validator.IfOneIsFilledThenAtLeastOne(x=>x.CityName, x=>x.StateOrProvinceCode, x=>x.CountryCode);
            validator.IfOneIsFilledThenAtLeastOne(x => x.LongitudeDirectionIdentifierCode, x => x.LongitudeCode, x => x.LongitudeDecimalFormat);
            validator.IfOneIsFilledThenAtLeastOne(x => x.LatitudeDirectionIdentifierCode, x => x.LatitudeCode, x => x.LatitudeDecimalFormat);

            validator.IfOneIsFilled_AllAreRequired(x => x.LongitudeDecimalFormat, x => x.LatitudeDecimalFormat);
            validator.IfOneIsFilled_AllAreRequired(x => x.LongitudeCode, x => x.LatitudeCode);

            validator.ARequiresB(x => x.StateOrProvinceCode, x => x.CityName);
            validator.ARequiresB(x => x.CountryCode, x => x.CityName);
            validator.ARequiresB(x => x.PostalCode, x => x.CityName);
            
            validator.Length(x => x.CityName, 2, 30);
            validator.Length(x => x.StateOrProvinceCode, 2);
            validator.Length(x => x.CountryCode, 2, 3);
            validator.Length(x => x.LongitudeCode, 7, 10);
            validator.Length(x => x.LatitudeCode, 7, 10);
            validator.Length(x => x.LongitudeDirectionIdentifierCode, 1);
            validator.Length(x => x.LongitudeDirectionIdentifierCode, 1);
            validator.Length(x => x.PostalCode, 3, 15);
            validator.Length(x => x.LongitudeDecimalFormat, 1, 10);
            validator.Length(x => x.LatitudeDecimalFormat, 1, 10);
            return validator.Results;
        }

        
    }

}
