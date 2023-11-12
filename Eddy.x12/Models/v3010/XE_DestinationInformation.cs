using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.Elements;

namespace Eddy.x12.Models.v3010;

[Segment("XE")]
public class XE_DestinationInformation : EdiX12Segment
{
	[Position(01)]
	public string ReferencedPatternIdentifier { get; set; }

	[Position(02)]
	public string CityName { get; set; }

	[Position(03)]
	public string StandardCarrierAlphaCode { get; set; }

	[Position(04)]
	public string Name30CharacterFormat { get; set; }

	[Position(05)]
	public string DestinationStation { get; set; }

	[Position(06)]
	public string StateOrProvinceCode { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<XE_DestinationInformation>(this);
		validator.Length(x => x.ReferencedPatternIdentifier, 1, 13);
		validator.Length(x => x.CityName, 2, 19);
		validator.Length(x => x.StandardCarrierAlphaCode, 2, 4);
		validator.Length(x => x.Name30CharacterFormat, 2, 30);
		validator.Length(x => x.DestinationStation, 2, 19);
		validator.Length(x => x.StateOrProvinceCode, 2);
		return validator.Results;
	}
}
