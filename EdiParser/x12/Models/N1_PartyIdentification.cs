using System;
using System.Collections.Generic;
using System.Text;
using EdiParser.Attributes;
using EdiParser.Validation;
using EdiParser.x12.Internals;

namespace EdiParser.x12.Models
{
	[Segment("N1")]
    public class N1_PartyIdentification : EdiX12Segment
    {
        [Position(01)]
        public string EntityIdentifierCode { get; set; }

        [Position(02)]
        public string Name { get; set; }

        [Position(03)]
        public string IdentificationCodeQualifier { get; set; }

        [Position(04)]
        public string IdentificationCode { get; set; }

        [Position(05)]
        public string EntityRelationshipCode { get; set; }

        [Position(06)]
        public string EntityIdentifierCode2 { get; set; }


        //TODO: How to handle composites in x12
        //[Position(07)]
        //public C076_CompositeIdentificationCodes CompositeIdentificationCodes { get; set; }

        public override ValidationResult Validate()
        {
            var validator = new BasicValidator<N1_PartyIdentification>(this);
            validator.Required(x => x.EntityIdentifierCode);
            validator.AtLeastOneIsRequired(x => x.Name, x => x.IdentificationCodeQualifier);
            validator.IfOneIsFilled_AllAreRequired(x => x.IdentificationCodeQualifier, x => x.IdentificationCode);
            validator.Length(x => x.EntityIdentifierCode, 2, 3);
            validator.Length(x => x.Name, 1, 60);
            validator.Length(x => x.IdentificationCodeQualifier, 1, 2);
            validator.Length(x => x.IdentificationCode, 2, 80);
            validator.Length(x => x.EntityRelationshipCode, 2);
            validator.Length(x => x.EntityIdentifierCode, 2, 3);
            return validator.Results;
        }

        
    }

}
