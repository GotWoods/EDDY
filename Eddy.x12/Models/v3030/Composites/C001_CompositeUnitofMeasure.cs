using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.Elements;

namespace Eddy.x12.Models.v3030.Composites;

[Segment("C001")]
public class C001_CompositeUnitOfMeasure : EdiX12Component
{
	[Position(00)]
	public string UnitOrBasisForMeasurementCode { get; set; }

	[Position(01)]
	public decimal? Exponent { get; set; }

	[Position(02)]
	public decimal? Multiplier { get; set; }

	[Position(03)]
	public string UnitOrBasisForMeasurementCode2 { get; set; }

	[Position(04)]
	public decimal? Exponent2 { get; set; }

	[Position(05)]
	public decimal? Multiplier2 { get; set; }

	[Position(06)]
	public string UnitOrBasisForMeasurementCode3 { get; set; }

	[Position(07)]
	public decimal? Exponent3 { get; set; }

	[Position(08)]
	public decimal? Multiplier3 { get; set; }

	[Position(09)]
	public string UnitOrBasisForMeasurementCode4 { get; set; }

	[Position(10)]
	public decimal? Exponent4 { get; set; }

	[Position(11)]
	public decimal? Multiplier4 { get; set; }

	[Position(12)]
	public string UnitOrBasisForMeasurementCode5 { get; set; }

	[Position(13)]
	public decimal? Exponent5 { get; set; }

	[Position(14)]
	public decimal? Multiplier5 { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<C001_CompositeUnitOfMeasure>(this);
		validator.Required(x=>x.UnitOrBasisForMeasurementCode);
		validator.Length(x => x.UnitOrBasisForMeasurementCode, 2);
		validator.Length(x => x.Exponent, 1, 15);
		validator.Length(x => x.Multiplier, 1, 10);
		validator.Length(x => x.UnitOrBasisForMeasurementCode2, 2);
		validator.Length(x => x.Exponent2, 1, 15);
		validator.Length(x => x.Multiplier2, 1, 10);
		validator.Length(x => x.UnitOrBasisForMeasurementCode3, 2);
		validator.Length(x => x.Exponent3, 1, 15);
		validator.Length(x => x.Multiplier3, 1, 10);
		validator.Length(x => x.UnitOrBasisForMeasurementCode4, 2);
		validator.Length(x => x.Exponent4, 1, 15);
		validator.Length(x => x.Multiplier4, 1, 10);
		validator.Length(x => x.UnitOrBasisForMeasurementCode5, 2);
		validator.Length(x => x.Exponent5, 1, 15);
		validator.Length(x => x.Multiplier5, 1, 10);
		return validator.Results;
	}
}
