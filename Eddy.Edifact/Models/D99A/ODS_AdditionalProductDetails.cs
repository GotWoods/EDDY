using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.Edifact.Models.D99A.Composites;

namespace Eddy.Edifact.Models.D99A;

[Segment("ODS")]
public class ODS_AdditionalProductDetails : EdifactSegment
{
	[Position(1)]
	public string DataQualifier { get; set; }

	[Position(2)]
	public E015_ProductDataInformation ProductDataInformation { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<ODS_AdditionalProductDetails>(this);
		validator.Required(x=>x.DataQualifier);
		validator.Required(x=>x.ProductDataInformation);
		validator.Length(x => x.DataQualifier, 1, 3);
		return validator.Results;
	}
}
