using Eddy.Core.Validation;
using Eddy.Edifact.Mapping;
using Eddy.Edifact.Models.D08B;
using Eddy.Edifact.Models.D08B.Composites;

namespace Eddy.Edifact.Tests.Models.D08B.Composites;

public class E998Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string line = "6:u:h:e";

		var expected = new E998_DiscountInformation()
		{
			AdjustmentReasonDescriptionCode = "6",
			Percentage = "u",
			PartyName = "h",
			UnitsQuantity = "e",
		};

		var actual = Map.MapComposite<E998_DiscountInformation>(line, MapOptionsForTesting.EdifactDefaultEndsWithSingleQuote);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("6", true)]
	public void Validation_RequiredAdjustmentReasonDescriptionCode(string adjustmentReasonDescriptionCode, bool isValidExpected)
	{
		var subject = new E998_DiscountInformation();
		//Required fields
		//Test Parameters
		subject.AdjustmentReasonDescriptionCode = adjustmentReasonDescriptionCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
