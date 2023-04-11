using Eddy.Core.Attributes;
using Eddy.Core.Validation;

namespace Eddy.x12.Models;

[Segment("BSF")]
public class BSF_BusinessFunction : EdiX12Segment
{
	[Position(01)]
	public string ClassOfTradeCode { get; set; }

	[Position(02)]
	public string CodeListQualifierCode { get; set; }

	[Position(03)]
	public string IndustryCode { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<BSF_BusinessFunction>(this);
		validator.AtLeastOneIsRequired(x=>x.ClassOfTradeCode, x=>x.CodeListQualifierCode);
		validator.OnlyOneOf(x=>x.ClassOfTradeCode, x=>x.CodeListQualifierCode);
		validator.IfOneIsFilled_AllAreRequired(x=>x.CodeListQualifierCode, x=>x.IndustryCode);
		validator.Length(x => x.ClassOfTradeCode, 2);
		validator.Length(x => x.CodeListQualifierCode, 1, 3);
		validator.Length(x => x.IndustryCode, 1, 30);
		return validator.Results;
	}
}
