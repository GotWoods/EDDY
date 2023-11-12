using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.Elements;

namespace Eddy.x12.Models.v5030;

[Segment("PI")]
public class PI_PriceAuthorityIdentification : EdiX12Segment
{
	[Position(01)]
	public string ReferenceIdentificationQualifier { get; set; }

	[Position(02)]
	public string ReferenceIdentification { get; set; }

	[Position(03)]
	public string PrimaryPublicationAuthorityCode { get; set; }

	[Position(04)]
	public string RegulatoryAgencyCode { get; set; }

	[Position(05)]
	public string TariffAgencyCode { get; set; }

	[Position(06)]
	public string IssuingCarrierIdentifier { get; set; }

	[Position(07)]
	public string ContractSuffix { get; set; }

	[Position(08)]
	public string TariffItemNumber { get; set; }

	[Position(09)]
	public string TariffSupplementIdentifier { get; set; }

	[Position(10)]
	public string TariffSectionNumber { get; set; }

	[Position(11)]
	public string ContractSuffix2 { get; set; }

	[Position(12)]
	public string Date { get; set; }

	[Position(13)]
	public string Date2 { get; set; }

	[Position(14)]
	public string AlternationPrecedenceCode { get; set; }

	[Position(15)]
	public string AlternationPrecedenceCode2 { get; set; }

	[Position(16)]
	public string ServiceLevelCode { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<PI_PriceAuthorityIdentification>(this);
		validator.Required(x=>x.ReferenceIdentificationQualifier);
		validator.Required(x=>x.ReferenceIdentification);
		validator.Length(x => x.ReferenceIdentificationQualifier, 2, 3);
		validator.Length(x => x.ReferenceIdentification, 1, 80);
		validator.Length(x => x.PrimaryPublicationAuthorityCode, 2);
		validator.Length(x => x.RegulatoryAgencyCode, 3, 5);
		validator.Length(x => x.TariffAgencyCode, 1, 4);
		validator.Length(x => x.IssuingCarrierIdentifier, 1, 10);
		validator.Length(x => x.ContractSuffix, 1, 2);
		validator.Length(x => x.TariffItemNumber, 1, 16);
		validator.Length(x => x.TariffSupplementIdentifier, 1, 4);
		validator.Length(x => x.TariffSectionNumber, 1, 2);
		validator.Length(x => x.ContractSuffix2, 1, 2);
		validator.Length(x => x.Date, 8);
		validator.Length(x => x.Date2, 8);
		validator.Length(x => x.AlternationPrecedenceCode, 1);
		validator.Length(x => x.AlternationPrecedenceCode2, 1);
		validator.Length(x => x.ServiceLevelCode, 2);
		return validator.Results;
	}
}
