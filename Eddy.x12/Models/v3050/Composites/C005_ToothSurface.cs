using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.Elements;

namespace Eddy.x12.Models.v3050.Composites;

[Segment("C005")]
public class C005_ToothSurface : EdiX12Component
{
	[Position(00)]
	public string ToothSurfaceCode { get; set; }

	[Position(01)]
	public string ToothSurfaceCode2 { get; set; }

	[Position(02)]
	public string ToothSurfaceCode3 { get; set; }

	[Position(03)]
	public string ToothSurfaceCode4 { get; set; }

	[Position(04)]
	public string ToothSurfaceCode5 { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<C005_ToothSurface>(this);
		validator.Required(x=>x.ToothSurfaceCode);
		validator.Length(x => x.ToothSurfaceCode, 1, 2);
		validator.Length(x => x.ToothSurfaceCode2, 1, 2);
		validator.Length(x => x.ToothSurfaceCode3, 1, 2);
		validator.Length(x => x.ToothSurfaceCode4, 1, 2);
		validator.Length(x => x.ToothSurfaceCode5, 1, 2);
		return validator.Results;
	}
}
