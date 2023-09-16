using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.Elements;

namespace Eddy.x12.Models.v4010;

[Segment("S1")]
public class S1_StopOffName : EdiX12Segment
{
	[Position(01)]
	public int? StopSequenceNumber { get; set; }

	[Position(02)]
	public string Name30CharacterFormat { get; set; }

	[Position(03)]
	public string IdentificationCodeQualifier { get; set; }

	[Position(04)]
	public string IdentificationCode { get; set; }

	[Position(05)]
	public string StandardCarrierAlphaCode { get; set; }

	[Position(06)]
	public string AccomplishCode { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<S1_StopOffName>(this);
		validator.Required(x=>x.StopSequenceNumber);
		validator.Required(x=>x.Name30CharacterFormat);
		validator.IfOneIsFilled_AllAreRequired(x=>x.IdentificationCodeQualifier, x=>x.IdentificationCode);
		validator.Required(x=>x.AccomplishCode);
		validator.Length(x => x.StopSequenceNumber, 1, 3);
		validator.Length(x => x.Name30CharacterFormat, 2, 30);
		validator.Length(x => x.IdentificationCodeQualifier, 1, 2);
		validator.Length(x => x.IdentificationCode, 2, 80);
		validator.Length(x => x.StandardCarrierAlphaCode, 2, 4);
		validator.Length(x => x.AccomplishCode, 1);
		return validator.Results;
	}
}
