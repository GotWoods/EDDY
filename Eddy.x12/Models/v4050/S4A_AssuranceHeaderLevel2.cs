using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.Elements;

namespace Eddy.x12.Models.v4050;

[Segment("S4A")]
public class S4A_AssuranceHeaderLevel2 : EdiX12Segment
{
	[Position(01)]
	public string SecurityVersionReleaseIdentifierCode { get; set; }

	[Position(02)]
	public string BusinessPurposeOfAssurance { get; set; }

	[Position(03)]
	public C034_ComputationMethods ComputationMethods { get; set; }

	[Position(04)]
	public string DomainOfComputationOfAssurance { get; set; }

	[Position(05)]
	public string AssuranceOriginator { get; set; }

	[Position(06)]
	public string AssuranceRecipient { get; set; }

	[Position(07)]
	public string AssuranceReferenceNumber { get; set; }

	[Position(08)]
	public string DateTimeStamp { get; set; }

	[Position(09)]
	public string AssuranceText { get; set; }

	[Position(10)]
	public C050_CertificateLookUpInformation CertificateLookUpInformation { get; set; }

	[Position(11)]
	public C028_AssuranceTokenParameters AssuranceTokenParameters { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<S4A_AssuranceHeaderLevel2>(this);
		validator.Required(x=>x.SecurityVersionReleaseIdentifierCode);
		validator.Required(x=>x.BusinessPurposeOfAssurance);
		validator.Required(x=>x.ComputationMethods);
		validator.Required(x=>x.DomainOfComputationOfAssurance);
		validator.Length(x => x.SecurityVersionReleaseIdentifierCode, 6);
		validator.Length(x => x.BusinessPurposeOfAssurance, 3);
		validator.Length(x => x.DomainOfComputationOfAssurance, 1, 2);
		validator.Length(x => x.AssuranceOriginator, 1, 64);
		validator.Length(x => x.AssuranceRecipient, 1, 64);
		validator.Length(x => x.AssuranceReferenceNumber, 1, 35);
		validator.Length(x => x.DateTimeStamp, 17, 25);
		validator.Length(x => x.AssuranceText, 1, 64);
		return validator.Results;
	}
}
