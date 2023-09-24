using Eddy.Core.Validation;
using Eddy.x12.Mapping;
using Eddy.x12.Models;

namespace Eddy.Tests.x12.Models;

public class IMCTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "IMC*6*5*VM*xcunILvQQQXlwgC*v1*StUJF43LUcYwXHN*ddNk1v*RGDw*674594382*3*jnE";

		var expected = new IMC_InterconnectMailbagClientExchangeHeader()
		{
			ExchangeBlockSequence = 6,
			ExchangeBlockTypeIdentifierCode = "5",
			InterchangeIDQualifier = "VM",
			InterchangeSenderID = "xcunILvQQQXlwgC",
			InterchangeIDQualifier2 = "v1",
			InterchangeReceiverID = "StUJF43LUcYwXHN",
			InterchangeDate = "ddNk1v",
			InterchangeTime = "RGDw",
			InterchangeControlNumber = 674594382,
			ExchangeBlockLength = 3,
			FilterIDCode = "jnE",
		};

		var actual = Map.MapObject<IMC_InterconnectMailbagClientExchangeHeader>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData(0, false)]
	[InlineData(6, true)]
	public void Validation_RequiredExchangeBlockSequence(int exchangeBlockSequence, bool isValidExpected)
	{
		var subject = new IMC_InterconnectMailbagClientExchangeHeader();
		if (exchangeBlockSequence > 0)
		subject.ExchangeBlockSequence = exchangeBlockSequence;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
