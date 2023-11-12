using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.Elements;

namespace Eddy.x12.Models.v3070;

[Segment("GID")]
public class GID_GroupIdentification : EdiX12Segment
{
	[Position(01)]
	public string Name { get; set; }

	[Position(02)]
	public string GenderCode { get; set; }

	[Position(03)]
	public string Name2 { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<GID_GroupIdentification>(this);
		validator.Required(x=>x.Name);
		validator.Required(x=>x.GenderCode);
		validator.Length(x => x.Name, 1, 60);
		validator.Length(x => x.GenderCode, 1);
		validator.Length(x => x.Name2, 1, 60);
		return validator.Results;
	}
}
