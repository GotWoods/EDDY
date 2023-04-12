using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.Elements;

namespace Eddy.x12.Models;

[Segment("WIN")]
public class WIN_WineInformation : EdiX12Segment
{
	[Position(01)]
	public C073_CompositeGrapeVarietalSequence CompositeGrapeVarietalSequence { get; set; }

	[Position(02)]
	public string Color { get; set; }

	[Position(03)]
	public C074_CompositeDateTimePeriod CompositeDateTimePeriod { get; set; }

	[Position(04)]
	public string WineQualityDesignation { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<WIN_WineInformation>(this);
		validator.Length(x => x.Color, 2, 3);
		validator.Length(x => x.WineQualityDesignation, 2, 3);
		return validator.Results;
	}
}
