using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.Elements;

namespace Eddy.x12.Models.v3050;

[Segment("CR2")]
public class CR2_ChiropracticCertification : EdiX12Segment
{
	[Position(01)]
	public int? Count { get; set; }

	[Position(02)]
	public decimal? Quantity { get; set; }

	[Position(03)]
	public string SubluxationLevelCode { get; set; }

	[Position(04)]
	public string SubluxationLevelCode2 { get; set; }

	[Position(05)]
	public string UnitOrBasisForMeasurementCode { get; set; }

	[Position(06)]
	public decimal? Quantity2 { get; set; }

	[Position(07)]
	public decimal? Quantity3 { get; set; }

	[Position(08)]
	public string NatureOfConditionCode { get; set; }

	[Position(09)]
	public string YesNoConditionOrResponseCode { get; set; }

	[Position(10)]
	public string Description { get; set; }

	[Position(11)]
	public string Description2 { get; set; }

	[Position(12)]
	public string YesNoConditionOrResponseCode2 { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<CR2_ChiropracticCertification>(this);
		validator.IfOneIsFilled_AllAreRequired(x=>x.Count, x=>x.Quantity);
		validator.ARequiresB(x=>x.SubluxationLevelCode2, x=>x.SubluxationLevelCode);
		validator.IfOneIsFilled_AllAreRequired(x=>x.UnitOrBasisForMeasurementCode, x=>x.Quantity2);
		validator.Length(x => x.Count, 1, 9);
		validator.Length(x => x.Quantity, 1, 15);
		validator.Length(x => x.SubluxationLevelCode, 2, 3);
		validator.Length(x => x.SubluxationLevelCode2, 2, 3);
		validator.Length(x => x.UnitOrBasisForMeasurementCode, 2);
		validator.Length(x => x.Quantity2, 1, 15);
		validator.Length(x => x.Quantity3, 1, 15);
		validator.Length(x => x.NatureOfConditionCode, 1);
		validator.Length(x => x.YesNoConditionOrResponseCode, 1);
		validator.Length(x => x.Description, 1, 80);
		validator.Length(x => x.Description2, 1, 80);
		validator.Length(x => x.YesNoConditionOrResponseCode2, 1);
		return validator.Results;
	}
}
