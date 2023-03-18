using EdiParser.Attributes;
using EdiParser.Validation;
using EdiParser.x12.Models.Internals;

namespace EdiParser.x12.Models;

[Segment("N3")]
public class N3_PartyLocation : EdiX12Segment
{
	
        [Position(01)]
        public string AddressInformation { get; set; }

        [Position(02)]
        public string AddressInformation2 { get; set; }

        public override ValidationResult Validate()
        {
            var validator = new BasicValidator<N3_PartyLocation>(this);
            validator.Required(x => x.AddressInformation);
            validator.Length(x => x.AddressInformation, 1, 55);
            validator.Length(x => x.AddressInformation, 1, 55);
            return validator.Results;
    }

        
}