using Eddy.Core.Validation;
using Eddy.Edifact.Mapping;
using Eddy.Edifact.Models.D00A;
using Eddy.Edifact.Models.D00A.Composites;

namespace Eddy.Edifact.Tests.Models.D00A.Composites;

public class E998Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string line = "D:S:0:g";

		var expected = new E998_DiscountInformation()
		{
			AdjustmentReasonDescriptionCode = "D",
			Percentage = "S",
			PartyName = "0",
			UnitsQuantity = "g",
		};

		var actual = Map.MapComposite<E998_DiscountInformation>(line, MapOptionsForTesting.EdifactDefaultEndsWithSingleQuote);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("D", true)]
	public void Validation_RequiredAdjustmentReasonDescriptionCode(string adjustmentReasonDescriptionCode, bool isValidExpected)
	{
		var subject = new E998_DiscountInformation();
		//Required fields
		//Test Parameters
		subject.AdjustmentReasonDescriptionCode = adjustmentReasonDescriptionCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
