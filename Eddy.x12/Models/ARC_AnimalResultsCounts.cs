using Eddy.Core.Attributes;
using Eddy.Core.Validation;

namespace Eddy.x12.Models;

[Segment("ARC")]
public class ARC_AnimalResultsCounts : EdiX12Segment 
{
	[Position(01)]
	public int? Count { get; set; }

	[Position(02)]
	public string TestTypeCode { get; set; }

	[Position(03)]
	public string ObservationTypeCode { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<ARC_AnimalResultsCounts>(this);
		validator.Required(x=>x.Count);
		validator.AtLeastOneIsRequired(x=>x.TestTypeCode, x=>x.ObservationTypeCode);
		validator.OnlyOneOf(x=>x.TestTypeCode, x=>x.ObservationTypeCode);
		validator.Length(x => x.Count, 1, 9);
		validator.Length(x => x.TestTypeCode, 2);
		validator.Length(x => x.ObservationTypeCode, 2);
		return validator.Results;
	}
}
