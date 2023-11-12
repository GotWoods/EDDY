using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.Elements;

namespace Eddy.x12.Models.v3070;

[Segment("PRI")]
public class PRI_ExternalReferenceIdentifier : EdiX12Segment
{
	[Position(01)]
	public string PrimaryPublicationAuthorityCode { get; set; }

	[Position(02)]
	public string TariffAgencyCode { get; set; }

	[Position(03)]
	public string TariffNumber { get; set; }

	[Position(04)]
	public string TariffNumberSuffix { get; set; }

	[Position(05)]
	public string TariffSupplementIdentifier { get; set; }

	[Position(06)]
	public string TariffSection { get; set; }

	[Position(07)]
	public string TariffItemNumber { get; set; }

	[Position(08)]
	public string ReferenceIdentificationQualifier { get; set; }

	[Position(09)]
	public string ReferenceIdentification { get; set; }

	[Position(10)]
	public string StandardCarrierAlphaCode { get; set; }

	[Position(11)]
	public string DocketControlNumber { get; set; }

	[Position(12)]
	public string DocketIdentification { get; set; }

	[Position(13)]
	public int? RevisionNumber { get; set; }

	[Position(14)]
	public string GroupTitle { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<PRI_ExternalReferenceIdentifier>(this);
		validator.Required(x=>x.PrimaryPublicationAuthorityCode);
		validator.Required(x=>x.TariffAgencyCode);
		validator.Required(x=>x.TariffNumber);
		validator.IfOneIsFilled_AllAreRequired(x=>x.ReferenceIdentificationQualifier, x=>x.ReferenceIdentification);
		validator.Length(x => x.PrimaryPublicationAuthorityCode, 2);
		validator.Length(x => x.TariffAgencyCode, 1, 4);
		validator.Length(x => x.TariffNumber, 1, 7);
		validator.Length(x => x.TariffNumberSuffix, 1, 2);
		validator.Length(x => x.TariffSupplementIdentifier, 1, 4);
		validator.Length(x => x.TariffSection, 1, 2);
		validator.Length(x => x.TariffItemNumber, 1, 16);
		validator.Length(x => x.ReferenceIdentificationQualifier, 2, 3);
		validator.Length(x => x.ReferenceIdentification, 1, 30);
		validator.Length(x => x.StandardCarrierAlphaCode, 2, 4);
		validator.Length(x => x.DocketControlNumber, 1, 7);
		validator.Length(x => x.DocketIdentification, 1, 11);
		validator.Length(x => x.RevisionNumber, 1, 4);
		validator.Length(x => x.GroupTitle, 2, 30);
		return validator.Results;
	}
}
