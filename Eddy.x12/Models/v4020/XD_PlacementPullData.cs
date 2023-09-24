using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.Elements;

namespace Eddy.x12.Models.v4020;

[Segment("XD")]
public class XD_PlacementPullData : EdiX12Segment
{
	[Position(01)]
	public string SwitchTypeCode { get; set; }

	[Position(02)]
	public string LocationIdentifier { get; set; }

	[Position(03)]
	public string LocationIdentifier2 { get; set; }

	[Position(04)]
	public string LoadEmptyStatusCode { get; set; }

	[Position(05)]
	public string RejectReasonCode { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<XD_PlacementPullData>(this);
		validator.Length(x => x.SwitchTypeCode, 2);
		validator.Length(x => x.LocationIdentifier, 1, 30);
		validator.Length(x => x.LocationIdentifier2, 1, 30);
		validator.Length(x => x.LoadEmptyStatusCode, 1);
		validator.Length(x => x.RejectReasonCode, 2);
		return validator.Results;
	}
}
