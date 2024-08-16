using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.Edifact.Models.D96A.Composites;

namespace Eddy.Edifact.Models.D96A;

[Segment("CST")]
public class CST_CustomsStatusOfGoods : EdifactSegment
{
	[Position(1)]
	public string GoodsItemNumber { get; set; }

	[Position(2)]
	public C246_CustomsIdentityCodes CustomsIdentityCodes { get; set; }

	[Position(3)]
	public C246_CustomsIdentityCodes CustomsIdentityCodes2 { get; set; }

	[Position(4)]
	public C246_CustomsIdentityCodes CustomsIdentityCodes3 { get; set; }

	[Position(5)]
	public C246_CustomsIdentityCodes CustomsIdentityCodes4 { get; set; }

	[Position(6)]
	public C246_CustomsIdentityCodes CustomsIdentityCodes5 { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<CST_CustomsStatusOfGoods>(this);
		validator.Length(x => x.GoodsItemNumber, 1, 5);
		return validator.Results;
	}
}
