using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v6030;

namespace Eddy.x12.Tests.Models.v6030;

public class IMCTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "IMC*1*w*jk*bmB6GJi3j1w8Lx1*eB*UGusp3Dj4wMm5IK*hcbNFS*tL9Z*118855495*2*exk";

		var expected = new IMC_InterconnectMailbagClientExchangeHeader()
		{
			ExchangeBlockSequence = 1,
			ExchangeBlockTypeIdentifierCode = "w",
			InterchangeIDQualifier = "jk",
			InterchangeSenderID = "bmB6GJi3j1w8Lx1",
			InterchangeIDQualifier2 = "eB",
			InterchangeReceiverID = "UGusp3Dj4wMm5IK",
			InterchangeDate = "hcbNFS",
			InterchangeTime = "tL9Z",
			InterchangeControlNumber = 118855495,
			ExchangeBlockLength = 2,
			FilterIDCode = "exk",
		};

		var actual = Map.MapObject<IMC_InterconnectMailbagClientExchangeHeader>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData(0, false)]
	[InlineData(1, true)]
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
