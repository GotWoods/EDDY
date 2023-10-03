using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.v3050.Composites;

namespace Eddy.x12.Models.v3050;

[Segment("III")]
public class III_Information : EdiX12Segment
{
	[Position(01)]
	public string CodeListQualifierCode { get; set; }

	[Position(02)]
	public string IndustryCode { get; set; }

	[Position(03)]
	public string CodeCategory { get; set; }

	[Position(04)]
	public string FreeFormMessageText { get; set; }

	[Position(05)]
	public decimal? Quantity { get; set; }

	[Position(06)]
	public C001_CompositeUnitOfMeasure CompositeUnitOfMeasure { get; set; }

	[Position(07)]
	public string SurfaceLayerPositionCode { get; set; }

	[Position(08)]
	public string SurfaceLayerPositionCode2 { get; set; }

	[Position(09)]
	public string SurfaceLayerPositionCode3 { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<III_Information>(this);
		validator.IfOneIsFilled_AllAreRequired(x=>x.CodeListQualifierCode, x=>x.IndustryCode);
		validator.IfOneIsFilledThenAtLeastOne(x=>x.CodeCategory, x=>x.FreeFormMessageText, x=>x.Quantity);
		validator.Length(x => x.CodeListQualifierCode, 1, 3);
		validator.Length(x => x.IndustryCode, 1, 20);
		validator.Length(x => x.CodeCategory, 2);
		validator.Length(x => x.FreeFormMessageText, 1, 264);
		validator.Length(x => x.Quantity, 1, 15);
		validator.Length(x => x.SurfaceLayerPositionCode, 2);
		validator.Length(x => x.SurfaceLayerPositionCode2, 2);
		validator.Length(x => x.SurfaceLayerPositionCode3, 2);
		return validator.Results;
	}
}
