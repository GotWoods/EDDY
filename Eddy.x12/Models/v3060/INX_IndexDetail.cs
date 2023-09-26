using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.Elements;

namespace Eddy.x12.Models.v3060;

[Segment("INX")]
public class INX_IndexDetail : EdiX12Segment
{
	[Position(01)]
	public string IndexQualifier { get; set; }

	[Position(02)]
	public C036_IndexIdentification IndexIdentification { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<INX_IndexDetail>(this);
		validator.Required(x=>x.IndexQualifier);
		validator.Required(x=>x.IndexIdentification);
		validator.Length(x => x.IndexQualifier, 1, 2);
		return validator.Results;
	}
}
