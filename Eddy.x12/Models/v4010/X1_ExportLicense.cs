using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.Elements;

namespace Eddy.x12.Models.v4010;

[Segment("X1")]
public class X1_ExportLicense : EdiX12Segment
{
	[Position(01)]
	public string LicensingAgencyCode { get; set; }

	[Position(02)]
	public string ExportLicenseNumber { get; set; }

	[Position(03)]
	public string ExportLicenseStatusCode { get; set; }

	[Position(04)]
	public string Date { get; set; }

	[Position(05)]
	public string ExportLicenseSymbolCode { get; set; }

	[Position(06)]
	public string ExportLicenseControlCode { get; set; }

	[Position(07)]
	public string CountryCode { get; set; }

	[Position(08)]
	public string ScheduleBCode { get; set; }

	[Position(09)]
	public string InternationalDomesticCode { get; set; }

	[Position(10)]
	public int? LadingQuantity { get; set; }

	[Position(11)]
	public decimal? LadingValue { get; set; }

	[Position(12)]
	public string ExportFilingKeyCode { get; set; }

	[Position(13)]
	public string UnitOrBasisForMeasurementCode { get; set; }

	[Position(14)]
	public decimal? UnitPrice { get; set; }

	[Position(15)]
	public string USGovernmentLicenseType { get; set; }

	[Position(16)]
	public string IdentificationCode { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<X1_ExportLicense>(this);
		validator.Length(x => x.LicensingAgencyCode, 1);
		validator.Length(x => x.ExportLicenseNumber, 6, 12);
		validator.Length(x => x.ExportLicenseStatusCode, 1);
		validator.Length(x => x.Date, 8);
		validator.Length(x => x.ExportLicenseSymbolCode, 1, 2);
		validator.Length(x => x.ExportLicenseControlCode, 1);
		validator.Length(x => x.CountryCode, 2, 3);
		validator.Length(x => x.ScheduleBCode, 7, 10);
		validator.Length(x => x.InternationalDomesticCode, 1);
		validator.Length(x => x.LadingQuantity, 1, 7);
		validator.Length(x => x.LadingValue, 2, 9);
		validator.Length(x => x.ExportFilingKeyCode, 1);
		validator.Length(x => x.UnitOrBasisForMeasurementCode, 2);
		validator.Length(x => x.UnitPrice, 1, 17);
		validator.Length(x => x.USGovernmentLicenseType, 1);
		validator.Length(x => x.IdentificationCode, 2, 80);
		return validator.Results;
	}
}
