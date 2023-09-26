using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.Elements;

namespace Eddy.x12.Models.v4020;

[Segment("INI")]
public class INI_IncorporationInformation : EdiX12Segment
{
	[Position(01)]
	public string StateOrProvinceCode { get; set; }

	[Position(02)]
	public string Date { get; set; }

	[Position(03)]
	public string EntityTypeQualifier { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<INI_IncorporationInformation>(this);
		validator.Required(x=>x.StateOrProvinceCode);
		validator.Required(x=>x.Date);
		validator.Length(x => x.StateOrProvinceCode, 2);
		validator.Length(x => x.Date, 8);
		validator.Length(x => x.EntityTypeQualifier, 1);
		return validator.Results;
	}
}
