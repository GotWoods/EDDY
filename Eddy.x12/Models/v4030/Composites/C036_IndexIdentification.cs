using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.Elements;

namespace Eddy.x12.Models.v4030.Composites;

[Segment("C036")]
public class C036_IndexIdentification : EdiX12Component
{
	[Position(00)]
	public string ConfigurationTypeCode { get; set; }

	[Position(01)]
	public string ReferenceIdentification { get; set; }

	[Position(02)]
	public string ReferenceIdentification2 { get; set; }

	[Position(03)]
	public decimal? XPeg { get; set; }

	[Position(04)]
	public decimal? YPeg { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<C036_IndexIdentification>(this);
		validator.AtLeastOneIsRequired(x=>x.ReferenceIdentification, x=>x.XPeg);
		validator.IfOneIsFilled_AllAreRequired(x=>x.ReferenceIdentification, x=>x.ReferenceIdentification2);
		validator.IfOneIsFilled_AllAreRequired(x=>x.XPeg, x=>x.YPeg);
		validator.Length(x => x.ConfigurationTypeCode, 1);
		validator.Length(x => x.ReferenceIdentification, 1, 50);
		validator.Length(x => x.ReferenceIdentification2, 1, 50);
		validator.Length(x => x.XPeg, 1, 6);
		validator.Length(x => x.YPeg, 1, 6);
		return validator.Results;
	}
}
