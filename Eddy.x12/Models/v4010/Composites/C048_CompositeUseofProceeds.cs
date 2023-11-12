using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.Elements;

namespace Eddy.x12.Models.v4010.Composites;

[Segment("C048")]
public class C048_CompositeUseOfProceeds : EdiX12Component
{
	[Position(00)]
	public string UseOfProceedsCode { get; set; }

	[Position(01)]
	public string RefinanceTypeCode { get; set; }

	[Position(02)]
	public string UseOfProceedsCode2 { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<C048_CompositeUseOfProceeds>(this);
		validator.Required(x=>x.UseOfProceedsCode);
		validator.Length(x => x.UseOfProceedsCode, 2);
		validator.Length(x => x.RefinanceTypeCode, 2);
		validator.Length(x => x.UseOfProceedsCode2, 2);
		return validator.Results;
	}
}
