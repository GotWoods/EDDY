using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.Elements;

namespace Eddy.x12.Models.v3030;

[Segment("L7A")]
public class L7A_ContractReferenceIdentifier : EdiX12Segment
{
	[Position(01)]
	public string ReferenceNumberQualifier { get; set; }

	[Position(02)]
	public string RegulatoryAgencyCode { get; set; }

	[Position(03)]
	public string StandardCarrierAlphaCode { get; set; }

	[Position(04)]
	public string IssuingCarrierIdentifier { get; set; }

	[Position(05)]
	public string ContractNumber { get; set; }

	[Position(06)]
	public string ContractSuffix { get; set; }

	[Position(07)]
	public string Date { get; set; }

	[Position(08)]
	public string Date2 { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<L7A_ContractReferenceIdentifier>(this);
		validator.Length(x => x.ReferenceNumberQualifier, 2);
		validator.Length(x => x.RegulatoryAgencyCode, 3, 5);
		validator.Length(x => x.StandardCarrierAlphaCode, 2, 4);
		validator.Length(x => x.IssuingCarrierIdentifier, 1, 5);
		validator.Length(x => x.ContractNumber, 1, 30);
		validator.Length(x => x.ContractSuffix, 1, 12);
		validator.Length(x => x.Date, 6);
		validator.Length(x => x.Date2, 6);
		return validator.Results;
	}
}
