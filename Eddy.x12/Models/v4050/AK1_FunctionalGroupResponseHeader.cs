using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.Elements;

namespace Eddy.x12.Models.v4050;

[Segment("AK1")]
public class AK1_FunctionalGroupResponseHeader : EdiX12Segment
{
	[Position(01)]
	public string FunctionalIdentifierCode { get; set; }

	[Position(02)]
	public int? GroupControlNumber { get; set; }

	[Position(03)]
	public string VersionReleaseIndustryIdentifierCode { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<AK1_FunctionalGroupResponseHeader>(this);
		validator.Required(x=>x.FunctionalIdentifierCode);
		validator.Required(x=>x.GroupControlNumber);
		validator.Length(x => x.FunctionalIdentifierCode, 2);
		validator.Length(x => x.GroupControlNumber, 1, 9);
		validator.Length(x => x.VersionReleaseIndustryIdentifierCode, 1, 12);
		return validator.Results;
	}
}
