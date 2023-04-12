using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.Elements;

namespace Eddy.x12.Models;

[Segment("STP")]
public class STP_StudyParameters : EdiX12Segment
{
	[Position(01)]
	public string Date { get; set; }

	[Position(02)]
	public string EntityTitle { get; set; }

	[Position(03)]
	public string ReferenceIdentification { get; set; }

	[Position(04)]
	public string ReferenceIdentification2 { get; set; }

	[Position(05)]
	public int? Number { get; set; }

	[Position(06)]
	public int? Number2 { get; set; }

	[Position(07)]
	public int? Number3 { get; set; }

	[Position(08)]
	public int? Number4 { get; set; }

	[Position(09)]
	public string ReferenceIdentification3 { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<STP_StudyParameters>(this);
		validator.Required(x=>x.Date);
		validator.Required(x=>x.EntityTitle);
		validator.Required(x=>x.ReferenceIdentification);
		validator.Required(x=>x.ReferenceIdentification2);
		validator.Required(x=>x.Number);
		validator.Required(x=>x.Number2);
		validator.Required(x=>x.Number3);
		validator.Length(x => x.Date, 8);
		validator.Length(x => x.EntityTitle, 1, 132);
		validator.Length(x => x.ReferenceIdentification, 1, 80);
		validator.Length(x => x.ReferenceIdentification2, 1, 80);
		validator.Length(x => x.Number, 1, 9);
		validator.Length(x => x.Number2, 1, 9);
		validator.Length(x => x.Number3, 1, 9);
		validator.Length(x => x.Number4, 1, 9);
		validator.Length(x => x.ReferenceIdentification3, 1, 80);
		return validator.Results;
	}
}
