using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.Elements;

namespace Eddy.x12.Models.v3040;

[Segment("PI")]
public class PI_PriceAuthorityIdentification : EdiX12Segment
{
	[Position(01)]
	public string ReferenceNumberQualifier { get; set; }

	[Position(02)]
	public string ReferenceNumber { get; set; }

	[Position(03)]
	public string ReferenceUsageCode { get; set; }

	[Position(04)]
	public string RegulatoryAgencyCode { get; set; }

	[Position(05)]
	public string StandardCarrierAlphaCode { get; set; }

	[Position(06)]
	public string IssuingCarrierIdentifier { get; set; }

	[Position(07)]
	public string ContractSuffix { get; set; }

	[Position(08)]
	public string TariffItemNumber { get; set; }

	[Position(09)]
	public string TariffSupplementIdentifier { get; set; }

	[Position(10)]
	public string TariffSection { get; set; }

	[Position(11)]
	public string ContractSuffix2 { get; set; }

	[Position(12)]
	public string Date { get; set; }

	[Position(13)]
	public string Date2 { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<PI_PriceAuthorityIdentification>(this);
		validator.Required(x=>x.ReferenceNumberQualifier);
		validator.Required(x=>x.ReferenceNumber);
		validator.Length(x => x.ReferenceNumberQualifier, 2);
		validator.Length(x => x.ReferenceNumber, 1, 30);
		validator.Length(x => x.ReferenceUsageCode, 2);
		validator.Length(x => x.RegulatoryAgencyCode, 3, 5);
		validator.Length(x => x.StandardCarrierAlphaCode, 2, 4);
		validator.Length(x => x.IssuingCarrierIdentifier, 1, 5);
		validator.Length(x => x.ContractSuffix, 1, 12);
		validator.Length(x => x.TariffItemNumber, 1, 16);
		validator.Length(x => x.TariffSupplementIdentifier, 1, 4);
		validator.Length(x => x.TariffSection, 1, 2);
		validator.Length(x => x.ContractSuffix2, 1, 12);
		validator.Length(x => x.Date, 6);
		validator.Length(x => x.Date2, 6);
		return validator.Results;
	}
}
