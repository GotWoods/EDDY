using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.Elements;

namespace Eddy.x12.Models.v5050;

[Segment("L7")]
public class L7_TariffReference : EdiX12Segment
{
	[Position(01)]
	public int? LadingLineItemNumber { get; set; }

	[Position(02)]
	public string TariffAgencyCode { get; set; }

	[Position(03)]
	public string TariffNumber { get; set; }

	[Position(04)]
	public string TariffSectionNumber { get; set; }

	[Position(05)]
	public string TariffItemNumber { get; set; }

	[Position(06)]
	public int? TariffItemPart { get; set; }

	[Position(07)]
	public string FreightClassCode { get; set; }

	[Position(08)]
	public string TariffSupplementIdentifier { get; set; }

	[Position(09)]
	public string ExParte { get; set; }

	[Position(10)]
	public string Date { get; set; }

	[Position(11)]
	public string RateBasisNumber { get; set; }

	[Position(12)]
	public string TariffColumn { get; set; }

	[Position(13)]
	public int? TariffDistance { get; set; }

	[Position(14)]
	public string DistanceQualifier { get; set; }

	[Position(15)]
	public string CityName { get; set; }

	[Position(16)]
	public string StateOrProvinceCode { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<L7_TariffReference>(this);
		validator.Length(x => x.LadingLineItemNumber, 1, 6);
		validator.Length(x => x.TariffAgencyCode, 1, 4);
		validator.Length(x => x.TariffNumber, 1, 7);
		validator.Length(x => x.TariffSectionNumber, 1, 2);
		validator.Length(x => x.TariffItemNumber, 1, 16);
		validator.Length(x => x.TariffItemPart, 1, 2);
		validator.Length(x => x.FreightClassCode, 2, 5);
		validator.Length(x => x.TariffSupplementIdentifier, 1, 4);
		validator.Length(x => x.ExParte, 4);
		validator.Length(x => x.Date, 8);
		validator.Length(x => x.RateBasisNumber, 1, 6);
		validator.Length(x => x.TariffColumn, 1, 2);
		validator.Length(x => x.TariffDistance, 1, 5);
		validator.Length(x => x.DistanceQualifier, 1);
		validator.Length(x => x.CityName, 2, 30);
		validator.Length(x => x.StateOrProvinceCode, 2);
		return validator.Results;
	}
}
