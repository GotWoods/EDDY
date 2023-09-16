using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.Elements;

namespace Eddy.x12.Models.v4020;

[Segment("SA")]
public class SA_StatusAction : EdiX12Segment
{
	[Position(01)]
	public string Date { get; set; }

	[Position(02)]
	public string ActionCode { get; set; }

	[Position(03)]
	public string StandardCarrierAlphaCode { get; set; }

	[Position(04)]
	public string Name { get; set; }

	[Position(05)]
	public string Date2 { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<SA_StatusAction>(this);
		validator.Required(x=>x.Date);
		validator.Required(x=>x.ActionCode);
		validator.Required(x=>x.StandardCarrierAlphaCode);
		validator.Length(x => x.Date, 8);
		validator.Length(x => x.ActionCode, 1, 2);
		validator.Length(x => x.StandardCarrierAlphaCode, 2, 4);
		validator.Length(x => x.Name, 1, 60);
		validator.Length(x => x.Date2, 8);
		return validator.Results;
	}
}
