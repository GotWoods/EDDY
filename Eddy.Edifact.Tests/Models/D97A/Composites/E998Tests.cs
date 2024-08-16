using Eddy.Core.Validation;
using Eddy.Edifact.Mapping;
using Eddy.Edifact.Models.D97A;
using Eddy.Edifact.Models.D97A.Composites;

namespace Eddy.Edifact.Tests.Models.D97A.Composites;

public class E998Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string line = "9:n:p:5";

		var expected = new E998_DiscountInformation()
		{
			AdjustmentReasonCoded = "9",
			Percentage = "n",
			PartyName = "p",
			NumberOfUnits = "5",
		};

		var actual = Map.MapComposite<E998_DiscountInformation>(line, MapOptionsForTesting.EdifactDefaultEndsWithSingleQuote);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("9", true)]
	public void Validation_RequiredAdjustmentReasonCoded(string adjustmentReasonCoded, bool isValidExpected)
	{
		var subject = new E998_DiscountInformation();
		//Required fields
		//Test Parameters
		subject.AdjustmentReasonCoded = adjustmentReasonCoded;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
