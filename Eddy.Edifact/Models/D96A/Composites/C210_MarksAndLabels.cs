using Eddy.Core.Attributes;
using Eddy.Core.Validation;

namespace Eddy.Edifact.Models.D96A.Composites;

[Segment("C210")]
public class C210_MarksAndLabels : EdifactComponent
{
	[Position(1)]
	public string ShippingMarks { get; set; }

	[Position(2)]
	public string ShippingMarks2 { get; set; }

	[Position(3)]
	public string ShippingMarks3 { get; set; }

	[Position(4)]
	public string ShippingMarks4 { get; set; }

	[Position(5)]
	public string ShippingMarks5 { get; set; }

	[Position(6)]
	public string ShippingMarks6 { get; set; }

	[Position(7)]
	public string ShippingMarks7 { get; set; }

	[Position(8)]
	public string ShippingMarks8 { get; set; }

	[Position(9)]
	public string ShippingMarks9 { get; set; }

	[Position(10)]
	public string ShippingMarks10 { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<C210_MarksAndLabels>(this);
		validator.Required(x=>x.ShippingMarks);
		validator.Length(x => x.ShippingMarks, 1, 35);
		validator.Length(x => x.ShippingMarks2, 1, 35);
		validator.Length(x => x.ShippingMarks3, 1, 35);
		validator.Length(x => x.ShippingMarks4, 1, 35);
		validator.Length(x => x.ShippingMarks5, 1, 35);
		validator.Length(x => x.ShippingMarks6, 1, 35);
		validator.Length(x => x.ShippingMarks7, 1, 35);
		validator.Length(x => x.ShippingMarks8, 1, 35);
		validator.Length(x => x.ShippingMarks9, 1, 35);
		validator.Length(x => x.ShippingMarks10, 1, 35);
		return validator.Results;
	}
}
