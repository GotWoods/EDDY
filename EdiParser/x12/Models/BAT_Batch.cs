using EdiParser.Attributes;
using EdiParser.Validation;
using EdiParser.x12.Internals;

namespace EdiParser.x12.Models;

[Segment("BAT")]
public class BAT_Batch : EdiX12Segment 
{
	[Position(01)]
	public string Date { get; set; }

	[Position(02)]
	public string Time { get; set; }

	[Position(03)]
	public string ReferenceIdentification { get; set; }

	[Position(04)]
	public string BatchTypeCode { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<BAT_Batch>(this);
		validator.AtLeastOneIsRequired(x=>x.Date, x=>x.ReferenceIdentification);
		validator.Length(x => x.Date, 8);
		validator.Length(x => x.Time, 4, 8);
		validator.Length(x => x.ReferenceIdentification, 1, 80);
		validator.Length(x => x.BatchTypeCode, 2);
		return validator.Results;
	}
}
