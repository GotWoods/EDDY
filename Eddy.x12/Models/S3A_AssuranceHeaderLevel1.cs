using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.Elements;

namespace Eddy.x12.Models;

[Segment("S3A")]
public class S3A_AssuranceHeaderLevel1 : EdiX12Segment
{
	[Position(01)]
	public string SecurityVersionReleaseIdentifierCode { get; set; }

	[Position(02)]
	public string BusinessPurposeOfAssuranceCode { get; set; }

	[Position(03)]
	public C034_ComputationMethods ComputationMethods { get; set; }

	[Position(04)]
	public string DomainOfComputationOfAssuranceCode { get; set; }

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
		var validator = new BasicValidator<S3A_AssuranceHeaderLevel1>(this);
		validator.Required(x=>x.SecurityVersionReleaseIdentifierCode);
		validator.Required(x=>x.BusinessPurposeOfAssuranceCode);
		validator.Required(x=>x.ComputationMethods);
		validator.Required(x=>x.DomainOfComputationOfAssuranceCode);
		validator.Length(x => x.SecurityVersionReleaseIdentifierCode, 6);
		validator.Length(x => x.BusinessPurposeOfAssuranceCode, 3);
		validator.Length(x => x.DomainOfComputationOfAssuranceCode, 1, 2);
		validator.Length(x => x.AssuranceOriginator, 1, 64);
		validator.Length(x => x.AssuranceRecipient, 1, 64);
		validator.Length(x => x.AssuranceReferenceNumber, 1, 35);
		validator.Length(x => x.DateTimeStamp, 17, 25);
		validator.Length(x => x.AssuranceText, 1, 64);
		return validator.Results;
	}
}
