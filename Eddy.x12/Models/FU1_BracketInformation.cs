using Eddy.Core.Attributes;
using Eddy.Core.Validation;


namespace Eddy.x12.Models;

[Segment("FU1")]
public class FU1_BracketInformation : EdiX12Segment
{
	[Position(01)]
	public string PriceBracketIdentifier { get; set; }

	[Position(02)]
	public decimal? RangeMinimum { get; set; }

	[Position(03)]
	public decimal? RangeMaximum { get; set; }

	[Position(04)]
	public string AssignedIdentification { get; set; }

	[Position(05)]
	public string FreeFormDescription { get; set; }

	[Position(06)]
	public string WeightQualifier { get; set; }

	[Position(07)]
	public string UnitOrBasisForMeasurementCode { get; set; }

	[Position(08)]
	public string ConditionIndicatorCode { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<FU1_BracketInformation>(this);
		validator.Required(x=>x.PriceBracketIdentifier);
		validator.Required(x=>x.RangeMinimum);
		validator.Length(x => x.PriceBracketIdentifier, 1, 3);
		validator.Length(x => x.RangeMinimum, 1, 20);
		validator.Length(x => x.RangeMaximum, 1, 20);
		validator.Length(x => x.AssignedIdentification, 1, 20);
		validator.Length(x => x.FreeFormDescription, 1, 45);
		validator.Length(x => x.WeightQualifier, 1, 2);
		validator.Length(x => x.UnitOrBasisForMeasurementCode, 2);
		validator.Length(x => x.ConditionIndicatorCode, 2, 3);
		return validator.Results;
	}
}
