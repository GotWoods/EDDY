using Eddy.Core.Attributes;
using Eddy.Core.Validation;


namespace Eddy.x12.Models;

[Segment("ITS")]
public class ITS_ItemSelection : EdiX12Segment
{
	[Position(01)]
	public string ItemSelectionTypeCode { get; set; }

	[Position(02)]
	public string Description { get; set; }

	[Position(03)]
	public string ItemSelectionTypeCode2 { get; set; }

	[Position(04)]
	public string Description2 { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<ITS_ItemSelection>(this);
		validator.Required(x=>x.ItemSelectionTypeCode);
		validator.ARequiresB(x=>x.Description2, x=>x.ItemSelectionTypeCode2);
		validator.Length(x => x.ItemSelectionTypeCode, 2);
		validator.Length(x => x.Description, 1, 80);
		validator.Length(x => x.ItemSelectionTypeCode2, 2);
		validator.Length(x => x.Description2, 1, 80);
		return validator.Results;
	}
}
