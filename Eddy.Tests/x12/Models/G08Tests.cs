using Eddy.Core.Validation;
using Eddy.x12.Mapping;
using Eddy.x12.Models;

namespace Eddy.Tests.x12.Models;

public class G08Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "G08*3*4*8*Do";

		var expected = new G08_PalletReceiptDisposition()
		{
			QuantityOfPalletsReceived = 3,
			QuantityOfPalletsReturned = 4,
			QuantityContested = 8,
			ReceivingConditionCode = "Do",
		};

		var actual = Map.MapObject<G08_PalletReceiptDisposition>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData(0,"", true)]
	[InlineData(8, "Do", true)]
	[InlineData(0, "Do", false)]
	[InlineData(8, "", false)]
	public void Validation_AllAreRequiredQuantityContested(decimal quantityContested, string receivingConditionCode, bool isValidExpected)
	{
		var subject = new G08_PalletReceiptDisposition();
		if (quantityContested > 0)
		subject.QuantityContested = quantityContested;
		subject.ReceivingConditionCode = receivingConditionCode;

		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

}
