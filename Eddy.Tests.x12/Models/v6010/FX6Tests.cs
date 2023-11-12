using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v6010;

namespace Eddy.x12.Tests.Models.v6010;

public class FX6Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "FX6*a*M*Q";

		var expected = new FX6_BrandLabel()
		{
			YesNoConditionOrResponseCode = "a",
			BrandName = "M",
			Description = "Q",
		};

		var actual = Map.MapObject<FX6_BrandLabel>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("a", true)]
	public void Validation_RequiredYesNoConditionOrResponseCode(string yesNoConditionOrResponseCode, bool isValidExpected)
	{
		var subject = new FX6_BrandLabel();
		//Required fields
		//Test Parameters
		subject.YesNoConditionOrResponseCode = yesNoConditionOrResponseCode;
		//At Least one
		subject.BrandName = "M";
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", "", false)]
	[InlineData("M", "Q", true)]
	[InlineData("M", "", true)]
	[InlineData("", "Q", true)]
	public void Validation_AtLeastOneBrandName(string brandName, string description, bool isValidExpected)
	{
		var subject = new FX6_BrandLabel();
		//Required fields
		subject.YesNoConditionOrResponseCode = "a";
		//Test Parameters
		subject.BrandName = brandName;
		subject.Description = description;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.AtLeastOneIsRequired);
	}

}
