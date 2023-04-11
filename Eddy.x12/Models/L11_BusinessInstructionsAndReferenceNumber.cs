using Eddy.Core.Attributes;
using Eddy.Core.Validation;

namespace Eddy.x12.Models
{
    [Segment("L11")]
    public class L11_BusinessInstructionsAndReferenceNumber : EdiX12Segment
    {
        /// <summary>
        /// The reference ID used
        /// </summary>
        [Position(1)]
        public string ReferenceIdentification { get; set; }

        /// <summary>
        /// The type of reference (E.g. BM Bill of Lading, Carrier Assigned Shipper Number)
        /// </summary>
        [Position(2)]
        public string ReferenceIdentificationQualifier { get; set; }

        /// <summary>
        /// Open text description
        /// </summary>
        [Position(3)]
        public string Description { get; set; }

        /// <summary>
        /// Date Of Shipment?
        /// </summary>
        [Position(4)]
        public string Date { get; set; }

        /// <summary>
        /// Y means the carrier used the shipper provided reference to create this record, a N means the carrier used other information
        /// </summary>
        [Position(5)]
        public string YesNoConditionOrResponseCode { get; set; }

        public override ValidationResult Validate()
        {
            var validator = new BasicValidator<L11_BusinessInstructionsAndReferenceNumber>(this);
            
            validator.AtLeastOneIsRequired(x => x.ReferenceIdentification, x => x.Description);
            validator.IfOneIsFilled_AllAreRequired(x => x.ReferenceIdentification, x => x.ReferenceIdentificationQualifier);

            validator.Length(x => x.ReferenceIdentification, 1, 80);
            validator.Length(x => x.ReferenceIdentificationQualifier, 2, 3);
            validator.Length(x => x.Description, 1, 80);
            validator.Length(x => x.Date, 8);
            validator.Length(x => x.YesNoConditionOrResponseCode, 1);
            return validator.Results;
        }

        
    }
}
