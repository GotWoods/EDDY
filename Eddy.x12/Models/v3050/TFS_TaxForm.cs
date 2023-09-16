using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.Elements;

namespace Eddy.x12.Models.v3050;

[Segment("TFS")]
public class TFS_TaxForm : EdiX12Segment
{
	[Position(01)]
	public string ReferenceNumberQualifier { get; set; }

	[Position(02)]
	public string ReferenceNumber { get; set; }

	[Position(03)]
	public string ReferenceNumberQualifier2 { get; set; }

	[Position(04)]
	public string ReferenceNumber2 { get; set; }

	[Position(05)]
	public string IdentificationCodeQualifier { get; set; }

	[Position(06)]
	public string IdentificationCode { get; set; }

	[Position(07)]
	public string Date { get; set; }

	[Position(08)]
	public string NameControlIdentifier { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<TFS_TaxForm>(this);
		validator.Required(x=>x.ReferenceNumberQualifier);
		validator.Required(x=>x.ReferenceNumber);
		validator.IfOneIsFilled_AllAreRequired(x=>x.ReferenceNumberQualifier2, x=>x.ReferenceNumber2);
		validator.IfOneIsFilled_AllAreRequired(x=>x.IdentificationCodeQualifier, x=>x.IdentificationCode);
		validator.Length(x => x.ReferenceNumberQualifier, 2);
		validator.Length(x => x.ReferenceNumber, 1, 30);
		validator.Length(x => x.ReferenceNumberQualifier2, 2);
		validator.Length(x => x.ReferenceNumber2, 1, 30);
		validator.Length(x => x.IdentificationCodeQualifier, 1, 2);
		validator.Length(x => x.IdentificationCode, 2, 20);
		validator.Length(x => x.Date, 6);
		validator.Length(x => x.NameControlIdentifier, 4);
		return validator.Results;
	}
}
