using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v5010;

namespace Eddy.x12.Tests.Models.v5010;

public class IMCTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "IMC*3*z*nL*P6uUE0WufBJgzxq*43*DIDYu1ewJQj0F7U*Qh5EEv*R5H4*263113416*3*reO";

		var expected = new IMC_InterconnectMailbagClientExchangeHeader()
		{
			ExchangeBlockSequence = 3,
			ExchangeBlockTypeIdentifier = "z",
			InterchangeIDQualifier = "nL",
			InterchangeSenderID = "P6uUE0WufBJgzxq",
			InterchangeIDQualifier2 = "43",
			InterchangeReceiverID = "DIDYu1ewJQj0F7U",
			InterchangeDate = "Qh5EEv",
			InterchangeTime = "R5H4",
			InterchangeControlNumber = 263113416,
			ExchangeBlockLength = 3,
			FilterIDCode = "reO",
		};

		var actual = Map.MapObject<IMC_InterconnectMailbagClientExchangeHeader>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData(0, false)]
	[InlineData(3, true)]
	public void Validation_RequiredExchangeBlockSequence(int exchangeBlockSequence, bool isValidExpected)
	{
		var subject = new IMC_InterconnectMailbagClientExchangeHeader();
		//Required fields
		//Test Parameters
		if (exchangeBlockSequence > 0) 
			subject.ExchangeBlockSequence = exchangeBlockSequence;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
