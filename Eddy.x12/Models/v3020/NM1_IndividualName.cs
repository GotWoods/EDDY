using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.Elements;

namespace Eddy.x12.Models.v3020;

[Segment("NM1")]
public class NM1_IndividualName : EdiX12Segment
{
	[Position(01)]
	public string NameTypeCode { get; set; }

	[Position(02)]
	public string NameLast { get; set; }

	[Position(03)]
	public string NameFirst { get; set; }

	[Position(04)]
	public string NameMiddle { get; set; }

	[Position(05)]
	public string NamePrefix { get; set; }

	[Position(06)]
	public string NameSuffix { get; set; }

	[Position(07)]
	public string IdentificationCodeQualifier { get; set; }

	[Position(08)]
	public string IdentificationCode { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<NM1_IndividualName>(this);
		validator.Required(x=>x.NameTypeCode);
		validator.Required(x=>x.NameLast);
		validator.Required(x=>x.NameFirst);
		validator.Length(x => x.NameTypeCode, 2);
		validator.Length(x => x.NameLast, 1, 25);
		validator.Length(x => x.NameFirst, 1, 16);
		validator.Length(x => x.NameMiddle, 1, 16);
		validator.Length(x => x.NamePrefix, 1, 10);
		validator.Length(x => x.NameSuffix, 1, 10);
		validator.Length(x => x.IdentificationCodeQualifier, 1, 2);
		validator.Length(x => x.IdentificationCode, 2, 17);
		return validator.Results;
	}
}
