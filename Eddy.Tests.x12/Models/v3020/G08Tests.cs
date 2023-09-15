using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3020;

namespace Eddy.x12.Tests.Models.v3020;

public class G08Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "G08*5*7*9*KF";

		var expected = new G08_PalletInformation()
		{
			QuantityOfPalletsReceived = 5,
			QuantityOfPalletsReturned = 7,
			QuantityContested = 9,
			ReceivingConditionCode = "KF",
		};

		var actual = Map.MapObject<G08_PalletInformation>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData(0, "", true)]
	[InlineData(9, "KF", true)]
	[InlineData(9, "", false)]
	[InlineData(0, "KF", false)]
	public void Validation_AllAreRequiredQuantityContested(decimal quantityContested, string receivingConditionCode, bool isValidExpected)
	{
		var subject = new G08_PalletInformation();
		if (quantityContested > 0)
			subject.QuantityContested = quantityContested;
		subject.ReceivingConditionCode = receivingConditionCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

}
