using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.Edifact.Models.D00A.Composites;

namespace Eddy.Edifact.Models.D00A;

[Segment("NAT")]
public class NAT_Nationality : EdifactSegment
{
	[Position(1)]
	public string NationalityCodeQualifier { get; set; }

	[Position(2)]
	public C042_NationalityDetails NationalityDetails { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<NAT_Nationality>(this);
		validator.Required(x=>x.NationalityCodeQualifier);
		validator.Length(x => x.NationalityCodeQualifier, 1, 3);
		return validator.Results;
	}
}
