using Eddy.Core.Attributes;
using Eddy.Core.Validation;


namespace Eddy.x12.Models;

[Segment("LCD")]
public class LCD_PlaceLocationDescription : EdiX12Segment
{
	[Position(01)]
	public string AssignedIdentification { get; set; }

	[Position(02)]
	public string EntityIdentifierCode { get; set; }

	[Position(03)]
	public string ActionCode { get; set; }

	[Position(04)]
	public string Date { get; set; }

	[Position(05)]
	public string IdentificationCodeQualifier { get; set; }

	[Position(06)]
	public string IdentificationCode { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<LCD_PlaceLocationDescription>(this);
		validator.IfOneIsFilled_AllAreRequired(x=>x.IdentificationCodeQualifier, x=>x.IdentificationCode);
		validator.Length(x => x.AssignedIdentification, 1, 20);
		validator.Length(x => x.EntityIdentifierCode, 2, 3);
		validator.Length(x => x.ActionCode, 1, 2);
		validator.Length(x => x.Date, 8);
		validator.Length(x => x.IdentificationCodeQualifier, 1, 2);
		validator.Length(x => x.IdentificationCode, 2, 80);
		return validator.Results;
	}
}
