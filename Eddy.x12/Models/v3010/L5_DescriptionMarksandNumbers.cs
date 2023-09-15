using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.Elements;

namespace Eddy.x12.Models.v3010;

[Segment("L5")]
public class L5_DescriptionMarksAndNumbers : EdiX12Segment
{
	[Position(01)]
	public int? LadingLineItemNumber { get; set; }

	[Position(02)]
	public string LadingDescription { get; set; }

	[Position(03)]
	public string CommodityCode { get; set; }

	[Position(04)]
	public string CommodityCodeQualifier { get; set; }

	[Position(05)]
	public string PackagingCode { get; set; }

	[Position(06)]
	public string MarksAndNumbers { get; set; }

	[Position(07)]
	public string MarksAndNumbersQualifier { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<L5_DescriptionMarksAndNumbers>(this);
		validator.Length(x => x.LadingLineItemNumber, 1, 3);
		validator.Length(x => x.LadingDescription, 1, 50);
		validator.Length(x => x.CommodityCode, 1, 16);
		validator.Length(x => x.CommodityCodeQualifier, 1);
		validator.Length(x => x.PackagingCode, 5);
		validator.Length(x => x.MarksAndNumbers, 1, 45);
		validator.Length(x => x.MarksAndNumbersQualifier, 1, 2);
		return validator.Results;
	}
}
