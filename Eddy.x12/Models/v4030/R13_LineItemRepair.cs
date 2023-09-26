using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.Elements;

namespace Eddy.x12.Models.v4030;

[Segment("R13")]
public class R13_LineItemRepair : EdiX12Segment
{
	[Position(01)]
	public string AssignedIdentification { get; set; }

	[Position(02)]
	public string IndustryCode { get; set; }

	[Position(03)]
	public string IndustryCode2 { get; set; }

	[Position(04)]
	public string IndustryCode3 { get; set; }

	[Position(05)]
	public string IndustryCode4 { get; set; }

	[Position(06)]
	public string IndustryCode5 { get; set; }

	[Position(07)]
	public string UnitOrBasisForMeasurementCode { get; set; }

	[Position(08)]
	public decimal? Quantity { get; set; }

	[Position(09)]
	public string YesNoConditionOrResponseCode { get; set; }

	[Position(10)]
	public string Description { get; set; }

	[Position(11)]
	public string Description2 { get; set; }

	[Position(12)]
	public decimal? Quantity2 { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<R13_LineItemRepair>(this);
		validator.Required(x=>x.AssignedIdentification);
		validator.Required(x=>x.IndustryCode);
		validator.Required(x=>x.IndustryCode2);
		validator.Required(x=>x.IndustryCode3);
		validator.Required(x=>x.IndustryCode4);
		validator.Required(x=>x.IndustryCode5);
		validator.IfOneIsFilled_AllAreRequired(x=>x.UnitOrBasisForMeasurementCode, x=>x.Quantity);
		validator.Length(x => x.AssignedIdentification, 1, 20);
		validator.Length(x => x.IndustryCode, 1, 30);
		validator.Length(x => x.IndustryCode2, 1, 30);
		validator.Length(x => x.IndustryCode3, 1, 30);
		validator.Length(x => x.IndustryCode4, 1, 30);
		validator.Length(x => x.IndustryCode5, 1, 30);
		validator.Length(x => x.UnitOrBasisForMeasurementCode, 2);
		validator.Length(x => x.Quantity, 1, 15);
		validator.Length(x => x.YesNoConditionOrResponseCode, 1);
		validator.Length(x => x.Description, 1, 80);
		validator.Length(x => x.Description2, 1, 80);
		validator.Length(x => x.Quantity2, 1, 15);
		return validator.Results;
	}
}
