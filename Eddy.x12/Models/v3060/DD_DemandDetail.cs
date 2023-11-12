using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.Elements;

namespace Eddy.x12.Models.v3060;

[Segment("DD")]
public class DD_DemandDetail : EdiX12Segment
{
	[Position(01)]
	public string IndustryCode { get; set; }

	[Position(02)]
	public string CodeListQualifierCode { get; set; }

	[Position(03)]
	public string ReferenceIdentificationQualifier { get; set; }

	[Position(04)]
	public string ReferenceIdentification { get; set; }

	[Position(05)]
	public string IndustryCode2 { get; set; }

	[Position(06)]
	public string CodeListQualifierCode2 { get; set; }

	[Position(07)]
	public decimal? Quantity { get; set; }

	[Position(08)]
	public string YesNoConditionOrResponseCode { get; set; }

	[Position(09)]
	public string IndustryCode3 { get; set; }

	[Position(10)]
	public string CodeListQualifierCode3 { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<DD_DemandDetail>(this);
		validator.ARequiresB(x=>x.CodeListQualifierCode, x=>x.IndustryCode);
		validator.ARequiresB(x=>x.CodeListQualifierCode2, x=>x.IndustryCode2);
		validator.ARequiresB(x=>x.CodeListQualifierCode3, x=>x.IndustryCode3);
		validator.Length(x => x.IndustryCode, 1, 30);
		validator.Length(x => x.CodeListQualifierCode, 1, 3);
		validator.Length(x => x.ReferenceIdentificationQualifier, 2, 3);
		validator.Length(x => x.ReferenceIdentification, 1, 30);
		validator.Length(x => x.IndustryCode2, 1, 30);
		validator.Length(x => x.CodeListQualifierCode2, 1, 3);
		validator.Length(x => x.Quantity, 1, 15);
		validator.Length(x => x.YesNoConditionOrResponseCode, 1);
		validator.Length(x => x.IndustryCode3, 1, 30);
		validator.Length(x => x.CodeListQualifierCode3, 1, 3);
		return validator.Results;
	}
}
