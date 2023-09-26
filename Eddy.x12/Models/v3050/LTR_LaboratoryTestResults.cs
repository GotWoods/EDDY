using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.Elements;

namespace Eddy.x12.Models.v3050;

[Segment("LTR")]
public class LTR_LaboratoryTestResults : EdiX12Segment
{
	[Position(01)]
	public string CodeListQualifierCode { get; set; }

	[Position(02)]
	public string IndustryCode { get; set; }

	[Position(03)]
	public decimal? MeasurementValue { get; set; }

	[Position(04)]
	public string UnitOrBasisForMeasurementCode { get; set; }

	[Position(05)]
	public string CodeListQualifierCode2 { get; set; }

	[Position(06)]
	public string IndustryCode2 { get; set; }

	[Position(07)]
	public string StatusCode { get; set; }

	[Position(08)]
	public decimal? RangeMinimum { get; set; }

	[Position(09)]
	public decimal? RangeMaximum { get; set; }

	[Position(10)]
	public string GenderCode { get; set; }

	[Position(11)]
	public decimal? RangeMinimum2 { get; set; }

	[Position(12)]
	public decimal? RangeMaximum2 { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<LTR_LaboratoryTestResults>(this);
		validator.Required(x=>x.CodeListQualifierCode);
		validator.Required(x=>x.IndustryCode);
		validator.ARequiresB(x=>x.UnitOrBasisForMeasurementCode, x=>x.MeasurementValue);
		validator.ARequiresB(x=>x.CodeListQualifierCode2, x=>x.IndustryCode2);
		validator.IfOneIsFilledThenAtLeastOne(x=>x.GenderCode, x=>x.RangeMinimum, x=>x.RangeMaximum);
		validator.IfOneIsFilledThenAtLeastOne(x=>x.RangeMinimum2, x=>x.RangeMinimum, x=>x.RangeMaximum);
		validator.IfOneIsFilledThenAtLeastOne(x=>x.RangeMaximum2, x=>x.RangeMinimum, x=>x.RangeMaximum);
		validator.Length(x => x.CodeListQualifierCode, 1, 3);
		validator.Length(x => x.IndustryCode, 1, 20);
		validator.Length(x => x.MeasurementValue, 1, 20);
		validator.Length(x => x.UnitOrBasisForMeasurementCode, 2);
		validator.Length(x => x.CodeListQualifierCode2, 1, 3);
		validator.Length(x => x.IndustryCode2, 1, 20);
		validator.Length(x => x.StatusCode, 1, 2);
		validator.Length(x => x.RangeMinimum, 1, 20);
		validator.Length(x => x.RangeMaximum, 1, 20);
		validator.Length(x => x.GenderCode, 1);
		validator.Length(x => x.RangeMinimum2, 1, 20);
		validator.Length(x => x.RangeMaximum2, 1, 20);
		return validator.Results;
	}
}
