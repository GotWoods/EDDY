using Eddy.Core.Validation;
using Eddy.x12.Mapping;
using Eddy.x12.Models;

namespace Eddy.Tests.x12.Models;

public class FX6Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "FX6*A*l*M";

		var expected = new FX6_BrandLabel()
		{
			YesNoConditionOrResponseCode = "A",
			BrandName = "l",
			Description = "M",
		};

		var actual = Map.MapObject<FX6_BrandLabel>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("A", true)]
	public void Validation_RequiredYesNoConditionOrResponseCode(string yesNoConditionOrResponseCode, bool isValidExpected)
	{
		var subject = new FX6_BrandLabel();
		subject.YesNoConditionOrResponseCode = yesNoConditionOrResponseCode;
        subject.Description = "AB";
        TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("","", false)]
	[InlineData("l","M", true)]
	[InlineData("", "M", true)]
	[InlineData("l", "", true)]
	public void Validation_AtLeastOneBrandName(string brandName, string description, bool isValidExpected)
	{
		var subject = new FX6_BrandLabel();
		subject.YesNoConditionOrResponseCode = "A";
		subject.BrandName = brandName;
		subject.Description = description;

		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.AtLeastOneIsRequired);
	}

}
