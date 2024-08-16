using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.Edifact.Models.D00A.Composites;

namespace Eddy.Edifact.Models.D00A;

[Segment("ODS")]
public class ODS_AdditionalProductDetails : EdifactSegment
{
	[Position(1)]
	public string DataCodeQualifier { get; set; }

	[Position(2)]
	public E015_ProductDataInformation ProductDataInformation { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<ODS_AdditionalProductDetails>(this);
		validator.Required(x=>x.DataCodeQualifier);
		validator.Required(x=>x.ProductDataInformation);
		validator.Length(x => x.DataCodeQualifier, 1, 3);
		return validator.Results;
	}
}
