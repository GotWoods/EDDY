using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.Elements;

namespace Eddy.x12.Models.v3010;

[Segment("W28")]
public class W28_ConsolidationInformation : EdiX12Segment
{
	[Position(01)]
	public string ConsolidationCode { get; set; }

	[Position(02)]
	public decimal? Weight { get; set; }

	[Position(03)]
	public string WeightQualifier { get; set; }

	[Position(04)]
	public string WeightUnitQualifier { get; set; }

	[Position(05)]
	public int? TotalStopoffs { get; set; }

	[Position(06)]
	public string LocationIdentifier { get; set; }

	[Position(07)]
	public string LocationQualifier { get; set; }

	[Position(08)]
	public string MasterBillOfLadingNumber { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<W28_ConsolidationInformation>(this);
		validator.Required(x=>x.ConsolidationCode);
		validator.Length(x => x.ConsolidationCode, 1);
		validator.Length(x => x.Weight, 1, 8);
		validator.Length(x => x.WeightQualifier, 1, 2);
		validator.Length(x => x.WeightUnitQualifier, 1);
		validator.Length(x => x.TotalStopoffs, 1, 2);
		validator.Length(x => x.LocationIdentifier, 1, 25);
		validator.Length(x => x.LocationQualifier, 1, 2);
		validator.Length(x => x.MasterBillOfLadingNumber, 1, 12);
		return validator.Results;
	}
}
