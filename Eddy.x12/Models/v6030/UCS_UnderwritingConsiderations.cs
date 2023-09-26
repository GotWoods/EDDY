using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.Elements;

namespace Eddy.x12.Models.v6030;

[Segment("UCS")]
public class UCS_UnderwritingConsiderations : EdiX12Segment
{
	[Position(01)]
	public string CodeCategory { get; set; }

	[Position(02)]
	public string Description { get; set; }

	[Position(03)]
	public string ItemDescriptionTypeCode { get; set; }

	[Position(04)]
	public string Description2 { get; set; }

	[Position(05)]
	public string ProductServiceIDQualifier { get; set; }

	[Position(06)]
	public string ProductServiceID { get; set; }

	[Position(07)]
	public int? Number { get; set; }

	[Position(08)]
	public C001_CompositeUnitOfMeasure CompositeUnitOfMeasure { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<UCS_UnderwritingConsiderations>(this);
		validator.IfOneIsFilled_AllAreRequired(x=>x.ItemDescriptionTypeCode, x=>x.Description2);
		validator.IfOneIsFilled_AllAreRequired(x=>x.ProductServiceIDQualifier, x=>x.ProductServiceID);
		validator.IfOneIsFilled_AllAreRequired(x=>x.Number, x=>x.CompositeUnitOfMeasure);
		validator.Length(x => x.CodeCategory, 2);
		validator.Length(x => x.Description, 1, 80);
		validator.Length(x => x.ItemDescriptionTypeCode, 1);
		validator.Length(x => x.Description2, 1, 80);
		validator.Length(x => x.ProductServiceIDQualifier, 2);
		validator.Length(x => x.ProductServiceID, 1, 80);
		validator.Length(x => x.Number, 1, 9);
		return validator.Results;
	}
}
