using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.Elements;

namespace Eddy.x12.Models;

[Segment("TSI")]
public class TSI_AutomaticEquipmentTagStatusInformation : EdiX12Segment
{
	[Position(01)]
	public string TagStatusCode { get; set; }

	[Position(02)]
	public string IndustryCode { get; set; }

	[Position(03)]
	public decimal? Quantity { get; set; }

	[Position(04)]
	public decimal? Quantity2 { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<TSI_AutomaticEquipmentTagStatusInformation>(this);
		validator.Length(x => x.TagStatusCode, 1);
		validator.Length(x => x.IndustryCode, 1, 30);
		validator.Length(x => x.Quantity, 1, 15);
		validator.Length(x => x.Quantity2, 1, 15);
		return validator.Results;
	}
}
