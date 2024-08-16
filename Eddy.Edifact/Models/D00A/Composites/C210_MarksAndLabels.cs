using Eddy.Core.Attributes;
using Eddy.Core.Validation;

namespace Eddy.Edifact.Models.D00A.Composites;

[Segment("C210")]
public class C210_MarksAndLabels : EdifactComponent
{
	[Position(1)]
	public string ShippingMarksDescription { get; set; }

	[Position(2)]
	public string ShippingMarksDescription2 { get; set; }

	[Position(3)]
	public string ShippingMarksDescription3 { get; set; }

	[Position(4)]
	public string ShippingMarksDescription4 { get; set; }

	[Position(5)]
	public string ShippingMarksDescription5 { get; set; }

	[Position(6)]
	public string ShippingMarksDescription6 { get; set; }

	[Position(7)]
	public string ShippingMarksDescription7 { get; set; }

	[Position(8)]
	public string ShippingMarksDescription8 { get; set; }

	[Position(9)]
	public string ShippingMarksDescription9 { get; set; }

	[Position(10)]
	public string ShippingMarksDescription10 { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<C210_MarksAndLabels>(this);
		validator.Required(x=>x.ShippingMarksDescription);
		validator.Length(x => x.ShippingMarksDescription, 1, 35);
		validator.Length(x => x.ShippingMarksDescription2, 1, 35);
		validator.Length(x => x.ShippingMarksDescription3, 1, 35);
		validator.Length(x => x.ShippingMarksDescription4, 1, 35);
		validator.Length(x => x.ShippingMarksDescription5, 1, 35);
		validator.Length(x => x.ShippingMarksDescription6, 1, 35);
		validator.Length(x => x.ShippingMarksDescription7, 1, 35);
		validator.Length(x => x.ShippingMarksDescription8, 1, 35);
		validator.Length(x => x.ShippingMarksDescription9, 1, 35);
		validator.Length(x => x.ShippingMarksDescription10, 1, 35);
		return validator.Results;
	}
}
