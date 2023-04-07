﻿using System;
using System.Collections.Generic;
using System.Text;
using EdiParser.Attributes;
using EdiParser.Validation;
using EdiParser.x12.Internals;

namespace EdiParser.x12.Models
{
    [Segment("G61")]
    public class G61_Contact : EdiX12Segment
    {
        [Position(01)]
        public string ContactFunctionCode { get; set; }

        [Position(02)]
        public string Name { get; set; }

        [Position(03)]
        public string CommunicationNumberQualifier { get; set; }

        [Position(04)]
        public string CommunicationNumber { get; set; }

        [Position(05)]
        public string ContactInquiryReference { get; set; }

        public override ValidationResult Validate()
        {
            var validator = new BasicValidator<G61_Contact>(this);

            validator.Required(x => x.ContactFunctionCode);
            validator.Required(x => x.Name);
            validator.IfOneIsFilled_AllAreRequired(x => x.CommunicationNumberQualifier, x => x.CommunicationNumber);

            validator.Length(x => x.ContactFunctionCode, 2);
            validator.Length(x => x.Name, 1, 60);
            validator.Length(x => x.CommunicationNumberQualifier, 2);
            validator.Length(x => x.CommunicationNumber, 1, 2048);
            validator.Length(x => x.ContactInquiryReference, 1, 20);
            return validator.Results;
        }


    }

}
