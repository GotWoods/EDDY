using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.Elements;

namespace Eddy.x12.Models.v3020;

[Segment("G77")]
public class G77_RemittanceAdviceIdentification : EdiX12Segment
{
	[Position(01)]
	public string CheckNumber { get; set; }

	[Position(02)]
	public string CheckDate { get; set; }

	[Position(03)]
	public string CheckAmount { get; set; }

	[Position(04)]
	public long? MICRNumber { get; set; }

	[Position(05)]
	public string ReferenceNumberQualifier { get; set; }

	[Position(06)]
	public string ReferenceNumber { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<G77_RemittanceAdviceIdentification>(this);
		validator.Required(x=>x.CheckNumber);
		validator.Required(x=>x.CheckDate);
		validator.Required(x=>x.CheckAmount);
		validator.IfOneIsFilled_AllAreRequired(x=>x.ReferenceNumberQualifier, x=>x.ReferenceNumber);
		validator.Length(x => x.CheckNumber, 1, 16);
		validator.Length(x => x.CheckDate, 6);
		validator.Length(x => x.CheckAmount, 2, 10);
		validator.Length(x => x.MICRNumber, 16);
		validator.Length(x => x.ReferenceNumberQualifier, 2);
		validator.Length(x => x.ReferenceNumber, 1, 30);
		return validator.Results;
	}
}
