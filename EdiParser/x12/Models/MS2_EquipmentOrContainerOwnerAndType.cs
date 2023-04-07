using System;
using System.Collections.Generic;
using System.Text;
using EdiParser.Attributes;
using EdiParser.Validation;
using EdiParser.x12.Internals;

namespace EdiParser.x12.Models
{
    [Segment("MS2")]
    public class MS2_EquipmentOrContainerOwnerAndType : EdiX12Segment
    {
        [Position(01)]
        public string StandardCarrierAlphaCode { get; set; }

        [Position(02)]
        public string EquipmentNumber { get; set; }

        [Position(03)]
        public string EquipmentDescriptionCode { get; set; }

        [Position(04)]
        public string EquipmentNumberCheckDigit { get; set; }

        public override ValidationResult Validate()
        {
            var validator = new BasicValidator<MS2_EquipmentOrContainerOwnerAndType>(this);
            validator.IfOneIsFilled_AllAreRequired(x => x.StandardCarrierAlphaCode, x => x.EquipmentNumber);
            validator.ARequiresB(x => x.EquipmentNumberCheckDigit, x => x.EquipmentNumber);
            validator.Length(x => x.StandardCarrierAlphaCode, 2, 4);
            validator.Length(x => x.EquipmentNumber, 1, 15);
            validator.Length(x => x.EquipmentDescriptionCode, 2);
            validator.Length(x => x.EquipmentNumberCheckDigit, 1);
            return validator.Results;
        }
    }

}

