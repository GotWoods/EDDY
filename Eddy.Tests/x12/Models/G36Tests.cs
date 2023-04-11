using Eddy.Core.Validation;
using Eddy.x12.Mapping;
using Eddy.x12.Models;

namespace Eddy.Tests.x12.Models;

public class G36Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "G36*T*3*JFDvMNXL*7ib";

		var expected = new G36_PriceListReference()
		{
			PriceListNumber = "T",
			PriceListIssueNumber = "3",
			Date = "JFDvMNXL",
			PriceConditionAppliesCode = "7ib",
		};

		var actual = Map.MapObject<G36_PriceListReference>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("T", true)]
	public void Validation_RequiredPriceListNumber(string priceListNumber, bool isValidExpected)
	{
		var subject = new G36_PriceListReference();
		subject.Date = "JFDvMNXL";
		subject.PriceListNumber = priceListNumber;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("JFDvMNXL", true)]
	public void Validation_RequiredDate(string date, bool isValidExpected)
	{
		var subject = new G36_PriceListReference();
		subject.PriceListNumber = "T";
		subject.Date = date;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
