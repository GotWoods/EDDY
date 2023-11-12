using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.Elements;

namespace Eddy.x12.Models.v3040;

[Segment("IEA")]
public class IEA_InterchangeControlTrailer : EdiX12Segment
{
	[Position(01)]
	public int? NumberOfIncludedFunctionalGroups { get; set; }

	[Position(02)]
	public int? InterchangeControlNumber { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<IEA_InterchangeControlTrailer>(this);
		validator.Required(x=>x.NumberOfIncludedFunctionalGroups);
		validator.Required(x=>x.InterchangeControlNumber);
		validator.Length(x => x.NumberOfIncludedFunctionalGroups, 1, 5);
		validator.Length(x => x.InterchangeControlNumber, 9);
		return validator.Results;
	}
}
