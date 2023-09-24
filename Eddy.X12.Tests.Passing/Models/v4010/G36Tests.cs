using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v4010;

namespace Eddy.x12.Tests.Models.v4010;

public class G36Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "G36*a*V*LoEzQe7B*MfF";

		var expected = new G36_PriceListReference()
		{
			PriceListNumber = "a",
			PriceListIssueNumber = "V",
			Date = "LoEzQe7B",
			PriceConditionAppliesCode = "MfF",
		};

		var actual = Map.MapObject<G36_PriceListReference>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("a", true)]
	public void Validation_RequiredPriceListNumber(string priceListNumber, bool isValidExpected)
	{
		var subject = new G36_PriceListReference();
		subject.Date = "LoEzQe7B";
		subject.PriceListNumber = priceListNumber;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("LoEzQe7B", true)]
	public void Validation_RequiredDate(string date, bool isValidExpected)
	{
		var subject = new G36_PriceListReference();
		subject.PriceListNumber = "a";
		subject.Date = date;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
