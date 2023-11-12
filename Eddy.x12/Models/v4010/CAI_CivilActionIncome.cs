using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.Elements;

namespace Eddy.x12.Models.v4010;

[Segment("CAI")]
public class CAI_CivilActionIncome : EdiX12Segment
{
	[Position(01)]
	public string PublicRecordOrObligationCode { get; set; }

	[Position(02)]
	public string Name { get; set; }

	[Position(03)]
	public string Name2 { get; set; }

	[Position(04)]
	public string AmountQualifierCode { get; set; }

	[Position(05)]
	public decimal? MonetaryAmount { get; set; }

	[Position(06)]
	public string RateValueQualifier { get; set; }

	[Position(07)]
	public string ReferenceIdentification { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<CAI_CivilActionIncome>(this);
		validator.Required(x=>x.PublicRecordOrObligationCode);
		validator.Required(x=>x.Name);
		validator.Length(x => x.PublicRecordOrObligationCode, 2);
		validator.Length(x => x.Name, 1, 60);
		validator.Length(x => x.Name2, 1, 60);
		validator.Length(x => x.AmountQualifierCode, 1, 3);
		validator.Length(x => x.MonetaryAmount, 1, 18);
		validator.Length(x => x.RateValueQualifier, 2);
		validator.Length(x => x.ReferenceIdentification, 1, 30);
		return validator.Results;
	}
}
