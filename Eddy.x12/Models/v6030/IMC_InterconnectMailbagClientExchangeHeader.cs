using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.Elements;

namespace Eddy.x12.Models.v6030;

[Segment("IMC")]
public class IMC_InterconnectMailbagClientExchangeHeader : EdiX12Segment
{
	[Position(01)]
	public int? ExchangeBlockSequence { get; set; }

	[Position(02)]
	public string ExchangeBlockTypeIdentifierCode { get; set; }

	[Position(03)]
	public string InterchangeIDQualifier { get; set; }

	[Position(04)]
	public string InterchangeSenderID { get; set; }

	[Position(05)]
	public string InterchangeIDQualifier2 { get; set; }

	[Position(06)]
	public string InterchangeReceiverID { get; set; }

	[Position(07)]
	public string InterchangeDate { get; set; }

	[Position(08)]
	public string InterchangeTime { get; set; }

	[Position(09)]
	public int? InterchangeControlNumber { get; set; }

	[Position(10)]
	public int? ExchangeBlockLength { get; set; }

	[Position(11)]
	public string FilterIDCode { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<IMC_InterconnectMailbagClientExchangeHeader>(this);
		validator.Required(x=>x.ExchangeBlockSequence);
		validator.Length(x => x.ExchangeBlockSequence, 1, 9);
		validator.Length(x => x.ExchangeBlockTypeIdentifierCode, 1, 3);
		validator.Length(x => x.InterchangeIDQualifier, 2);
		validator.Length(x => x.InterchangeSenderID, 15);
		validator.Length(x => x.InterchangeIDQualifier2, 2);
		validator.Length(x => x.InterchangeReceiverID, 15);
		validator.Length(x => x.InterchangeDate, 6);
		validator.Length(x => x.InterchangeTime, 4);
		validator.Length(x => x.InterchangeControlNumber, 9);
		validator.Length(x => x.ExchangeBlockLength, 1, 9);
		validator.Length(x => x.FilterIDCode, 3);
		return validator.Results;
	}
}
