using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v8010;

namespace Eddy.x12.Tests.Models.v8010;

public class BVITests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "BVI*Ji*s*0*7f*EB";

		var expected = new BVI_BeverageInformation()
		{
			BeverageCategory = "Ji",
			YesNoConditionOrResponseCode = "s",
			YesNoConditionOrResponseCode2 = "0",
			CiderType = "7f",
			PreMixDrinkCode = "EB",
		};

		var actual = Map.MapObject<BVI_BeverageInformation>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("Ji", true)]
	public void Validation_RequiredBeverageCategory(string beverageCategory, bool isValidExpected)
	{
		var subject = new BVI_BeverageInformation();
		//Required fields
		//Test Parameters
		subject.BeverageCategory = beverageCategory;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
