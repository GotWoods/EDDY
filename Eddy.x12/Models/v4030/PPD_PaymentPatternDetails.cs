using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.Elements;

namespace Eddy.x12.Models.v4030;

[Segment("PPD")]
public class PPD_PaymentPatternDetails : EdiX12Segment
{
	[Position(01)]
	public string PaymentPattern { get; set; }

	[Position(02)]
	public string DateTimePeriodFormatQualifier { get; set; }

	[Position(03)]
	public string DateTimePeriod { get; set; }

	[Position(04)]
	public string ReferenceIdentification { get; set; }

	[Position(05)]
	public string ReferenceIdentification2 { get; set; }

	[Position(06)]
	public string RatingCode { get; set; }

	[Position(07)]
	public string DateTimePeriod2 { get; set; }

	[Position(08)]
	public int? Number { get; set; }

	[Position(09)]
	public int? Number2 { get; set; }

	[Position(10)]
	public int? Number3 { get; set; }

	[Position(11)]
	public int? Number4 { get; set; }

	[Position(12)]
	public int? Number5 { get; set; }

	[Position(13)]
	public int? Number6 { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<PPD_PaymentPatternDetails>(this);
		validator.Length(x => x.PaymentPattern, 1, 84);
		validator.Length(x => x.DateTimePeriodFormatQualifier, 2, 3);
		validator.Length(x => x.DateTimePeriod, 1, 35);
		validator.Length(x => x.ReferenceIdentification, 1, 50);
		validator.Length(x => x.ReferenceIdentification2, 1, 50);
		validator.Length(x => x.RatingCode, 2);
		validator.Length(x => x.DateTimePeriod2, 1, 35);
		validator.Length(x => x.Number, 1, 9);
		validator.Length(x => x.Number2, 1, 9);
		validator.Length(x => x.Number3, 1, 9);
		validator.Length(x => x.Number4, 1, 9);
		validator.Length(x => x.Number5, 1, 9);
		validator.Length(x => x.Number6, 1, 9);
		return validator.Results;
	}
}
