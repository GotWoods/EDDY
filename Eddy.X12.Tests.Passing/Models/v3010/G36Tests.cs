using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3010;

namespace Eddy.x12.Tests.Models.v3010;

public class G36Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "G36*2*w*NDO6N3*49I";

		var expected = new G36_PriceListReference()
		{
			PriceListNumber = "2",
			PriceListIssueNumber = "w",
			Date = "NDO6N3",
			PriceConditionAppliesCode = "49I",
		};

		var actual = Map.MapObject<G36_PriceListReference>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("2", true)]
	public void Validation_RequiredPriceListNumber(string priceListNumber, bool isValidExpected)
	{
		var subject = new G36_PriceListReference();
		subject.Date = "NDO6N3";
		subject.PriceListNumber = priceListNumber;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("NDO6N3", true)]
	public void Validation_RequiredDate(string date, bool isValidExpected)
	{
		var subject = new G36_PriceListReference();
		subject.PriceListNumber = "2";
		subject.Date = date;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
