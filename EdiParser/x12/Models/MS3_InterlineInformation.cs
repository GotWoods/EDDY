using System;
using System.Collections.Generic;
using System.Text;
using EdiParser.Attributes;
using EdiParser.Validation;

namespace EdiParser.x12.Models
{
    [Segment("MS3")]
    public class MS3_InterlineInformation : EdiX12Segment
    {
        [Position(01)]
        public string StandardCarrierAlphaCode { get; set; }

        [Position(02)]
        public string RoutingSequenceCode { get; set; }

        [Position(03)]
        public string CityName { get; set; }

        [Position(04)]
        public string TransportationMethodTypeCode { get; set; }

        [Position(05)]
        public string StateOrProvinceCode { get; set; }

        public override ValidationResult Validate()
        {
            var validator = new BasicValidator<MS3_InterlineInformation>(this);
            validator.Required(x => x.StandardCarrierAlphaCode);
            validator.Required(x => x.RoutingSequenceCode);
            validator.ARequiresB(x => x.StateOrProvinceCode, x => x.CityName);
            validator.Length(x => x.StandardCarrierAlphaCode, 2, 4);
            validator.Length(x => x.RoutingSequenceCode, 1, 2);
            validator.Length(x => x.CityName, 2, 30);
            validator.Length(x => x.TransportationMethodTypeCode, 1, 2);
            validator.Length(x => x.StateOrProvinceCode, 2);
            return validator.Results;
        }


    }

}
