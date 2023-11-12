using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.Elements;

namespace Eddy.x12.Models.v3050;

[Segment("BA1")]
public class BA1_BeginningSegmentForShippersExportDeclaration : EdiX12Segment
{
	[Position(01)]
	public string RelatedCompanyIndicationCode { get; set; }

	[Position(02)]
	public string CensusMerchandiseTypeCode { get; set; }

	[Position(03)]
	public string TransportationMethodTypeCode { get; set; }

	[Position(04)]
	public string CensusStatisticalMonthCode { get; set; }

	[Position(05)]
	public string CountryCode { get; set; }

	[Position(06)]
	public string CensusTradeIdentifierCode { get; set; }

	[Position(07)]
	public string CensusExportLicenseIdentifierCode { get; set; }

	[Position(08)]
	public string PostalCode { get; set; }

	[Position(09)]
	public string CensusContainerCode { get; set; }

	[Position(10)]
	public string CensusSpecialIdentifierCode { get; set; }

	[Position(11)]
	public string CountryCode2 { get; set; }

	[Position(12)]
	public string StateOrProvinceCode { get; set; }

	[Position(13)]
	public string Authority { get; set; }

	[Position(14)]
	public string StandardCarrierAlphaCode { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<BA1_BeginningSegmentForShippersExportDeclaration>(this);
		validator.Required(x=>x.RelatedCompanyIndicationCode);
		validator.Required(x=>x.CensusMerchandiseTypeCode);
		validator.Required(x=>x.TransportationMethodTypeCode);
		validator.Required(x=>x.CensusStatisticalMonthCode);
		validator.Required(x=>x.CountryCode);
		validator.Required(x=>x.CensusTradeIdentifierCode);
		validator.Required(x=>x.CensusExportLicenseIdentifierCode);
		validator.Required(x=>x.PostalCode);
		validator.Length(x => x.RelatedCompanyIndicationCode, 1);
		validator.Length(x => x.CensusMerchandiseTypeCode, 1);
		validator.Length(x => x.TransportationMethodTypeCode, 1, 2);
		validator.Length(x => x.CensusStatisticalMonthCode, 2);
		validator.Length(x => x.CountryCode, 2, 3);
		validator.Length(x => x.CensusTradeIdentifierCode, 1);
		validator.Length(x => x.CensusExportLicenseIdentifierCode, 1);
		validator.Length(x => x.PostalCode, 3, 11);
		validator.Length(x => x.CensusContainerCode, 1);
		validator.Length(x => x.CensusSpecialIdentifierCode, 1);
		validator.Length(x => x.CountryCode2, 2, 3);
		validator.Length(x => x.StateOrProvinceCode, 2);
		validator.Length(x => x.Authority, 1, 20);
		validator.Length(x => x.StandardCarrierAlphaCode, 2, 4);
		return validator.Results;
	}
}
