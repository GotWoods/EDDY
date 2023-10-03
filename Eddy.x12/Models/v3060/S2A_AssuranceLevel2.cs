using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.v3060.Composites;

namespace Eddy.x12.Models.v3060;

[Segment("S2A")]
public class S2A_AssuranceLevel2 : EdiX12Segment
{
	[Position(01)]
	public string BusinessPurposeOfAssurance { get; set; }

	[Position(02)]
	public C034_ComputationMethods ComputationMethods { get; set; }

	[Position(03)]
	public string DomainOfComputationOfAssuranceDigest { get; set; }

	[Position(04)]
	public string AssuranceOriginator { get; set; }

	[Position(05)]
	public string AssuranceRecipient { get; set; }

	[Position(06)]
	public string AssuranceReferenceNumber { get; set; }

	[Position(07)]
	public string DateTimeReference { get; set; }

	[Position(08)]
	public string AssuranceText { get; set; }

	[Position(09)]
	public C028_AssuranceTokenParameters AssuranceTokenParameters { get; set; }

	[Position(10)]
	public string AssuranceDigest { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<S2A_AssuranceLevel2>(this);
		validator.Required(x=>x.BusinessPurposeOfAssurance);
		validator.Required(x=>x.ComputationMethods);
		validator.Required(x=>x.DomainOfComputationOfAssuranceDigest);
		validator.Length(x => x.BusinessPurposeOfAssurance, 3);
		validator.Length(x => x.DomainOfComputationOfAssuranceDigest, 1, 2);
		validator.Length(x => x.AssuranceOriginator, 1, 64);
		validator.Length(x => x.AssuranceRecipient, 1, 64);
		validator.Length(x => x.AssuranceReferenceNumber, 1, 35);
		validator.Length(x => x.DateTimeReference, 17, 25);
		validator.Length(x => x.AssuranceText, 1, 64);
		validator.Length(x => x.AssuranceDigest, 1, 512);
		return validator.Results;
	}
}
