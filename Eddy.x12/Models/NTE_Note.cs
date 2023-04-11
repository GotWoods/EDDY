using Eddy.Core.Attributes;
using Eddy.Core.Validation;

namespace Eddy.x12.Models
{
    [Segment("NTE")]
    public class NTE_Note : EdiX12Segment
    {
        [Position(01)]
        public string NoteReferenceCode { get; set; }

        [Position(02)]
        public string Description { get; set; }

        public override ValidationResult Validate()
        {
            var validator = new BasicValidator<NTE_Note>(this);
            validator.Required(x => x.Description);
            validator.Length(x => x.NoteReferenceCode, 3);
            validator.Length(x => x.Description, 1, 80);
            return validator.Results;
        }


    }
}


