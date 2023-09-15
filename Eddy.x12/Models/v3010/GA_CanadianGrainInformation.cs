using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.Elements;

namespace Eddy.x12.Models.v3010;

[Segment("GA")]
public class GA_CanadianGrainInformation : EdiX12Segment
{
	[Position(01)]
	public string CommodityCodeQualifier { get; set; }

	[Position(02)]
	public string CommodityCode { get; set; }

	[Position(03)]
	public string WeightQualifier { get; set; }

	[Position(04)]
	public string ReferenceNumberQualifier { get; set; }

	[Position(05)]
	public string ReferenceNumber { get; set; }

	[Position(06)]
	public int? Week { get; set; }

	[Position(07)]
	public string UnloadTerminal { get; set; }

	[Position(08)]
	public string Date { get; set; }

	[Position(09)]
	public string IncentiveGrainRateIndicator { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<GA_CanadianGrainInformation>(this);
		validator.Required(x=>x.CommodityCode);
		validator.Length(x => x.CommodityCodeQualifier, 1);
		validator.Length(x => x.CommodityCode, 1, 16);
		validator.Length(x => x.WeightQualifier, 1, 2);
		validator.Length(x => x.ReferenceNumberQualifier, 2);
		validator.Length(x => x.ReferenceNumber, 1, 30);
		validator.Length(x => x.Week, 1, 2);
		validator.Length(x => x.UnloadTerminal, 3);
		validator.Length(x => x.Date, 6);
		validator.Length(x => x.IncentiveGrainRateIndicator, 1);
		return validator.Results;
	}
}
