using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.Elements;

namespace Eddy.x12.Models.v3010;

[Segment("TC1")]
public class TC1_TariffCommodity : EdiX12Segment
{
	[Position(01)]
	public string TariffItemNumber { get; set; }

	[Position(02)]
	public int? LineNumber { get; set; }

	[Position(03)]
	public string FreeFormDescription { get; set; }

	[Position(04)]
	public string NoteReferenceCode { get; set; }

	[Position(05)]
	public int? LadingLineItemNumber { get; set; }

	[Position(06)]
	public string CommodityCode { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<TC1_TariffCommodity>(this);
		validator.Required(x=>x.TariffItemNumber);
		validator.Required(x=>x.LineNumber);
		validator.Required(x=>x.FreeFormDescription);
		validator.Required(x=>x.NoteReferenceCode);
		validator.Required(x=>x.LadingLineItemNumber);
		validator.Length(x => x.TariffItemNumber, 1, 16);
		validator.Length(x => x.LineNumber, 1, 3);
		validator.Length(x => x.FreeFormDescription, 1, 45);
		validator.Length(x => x.NoteReferenceCode, 3);
		validator.Length(x => x.LadingLineItemNumber, 1, 3);
		validator.Length(x => x.CommodityCode, 1, 16);
		return validator.Results;
	}
}
