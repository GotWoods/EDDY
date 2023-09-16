using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.Elements;

namespace Eddy.x12.Models.v3010;

[Segment("S2")]
public class S2_StopOffAddress : EdiX12Segment
{
	[Position(01)]
	public int? StopSequenceNumber { get; set; }

	[Position(02)]
	public string AdditionalNameAddressData { get; set; }

	[Position(03)]
	public string AdditionalNameAddressData2 { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<S2_StopOffAddress>(this);
		validator.Required(x=>x.StopSequenceNumber);
		validator.Required(x=>x.AdditionalNameAddressData);
		validator.Length(x => x.StopSequenceNumber, 1, 2);
		validator.Length(x => x.AdditionalNameAddressData, 1, 30);
		validator.Length(x => x.AdditionalNameAddressData2, 1, 30);
		return validator.Results;
	}
}
