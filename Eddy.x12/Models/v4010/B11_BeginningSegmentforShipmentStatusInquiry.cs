using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.Elements;

namespace Eddy.x12.Models.v4010;

[Segment("B11")]
public class B11_BeginningSegmentForShipmentStatusInquiry : EdiX12Segment
{
	[Position(01)]
	public string IdentificationCodeQualifier { get; set; }

	[Position(02)]
	public string IdentificationCode { get; set; }

	[Position(03)]
	public string Date { get; set; }

	[Position(04)]
	public string UnitOrBasisForMeasurementCode { get; set; }

	[Position(05)]
	public decimal? Quantity { get; set; }

	[Position(06)]
	public string AmountQualifierCode { get; set; }

	[Position(07)]
	public decimal? MonetaryAmount { get; set; }

	[Position(08)]
	public string ItemDescriptionType { get; set; }

	[Position(09)]
	public string Description { get; set; }

	[Position(10)]
	public string ServiceLevelCode { get; set; }

	[Position(11)]
	public string ReportTransmissionCode { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<B11_BeginningSegmentForShipmentStatusInquiry>(this);
		validator.Required(x=>x.IdentificationCodeQualifier);
		validator.Required(x=>x.IdentificationCode);
		validator.IfOneIsFilled_AllAreRequired(x=>x.UnitOrBasisForMeasurementCode, x=>x.Quantity);
		validator.IfOneIsFilled_AllAreRequired(x=>x.AmountQualifierCode, x=>x.MonetaryAmount);
		validator.IfOneIsFilled_AllAreRequired(x=>x.ItemDescriptionType, x=>x.Description);
		validator.Length(x => x.IdentificationCodeQualifier, 1, 2);
		validator.Length(x => x.IdentificationCode, 2, 80);
		validator.Length(x => x.Date, 8);
		validator.Length(x => x.UnitOrBasisForMeasurementCode, 2);
		validator.Length(x => x.Quantity, 1, 15);
		validator.Length(x => x.AmountQualifierCode, 1, 3);
		validator.Length(x => x.MonetaryAmount, 1, 18);
		validator.Length(x => x.ItemDescriptionType, 1);
		validator.Length(x => x.Description, 1, 80);
		validator.Length(x => x.ServiceLevelCode, 2);
		validator.Length(x => x.ReportTransmissionCode, 1, 2);
		return validator.Results;
	}
}
