using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v4040;

namespace Eddy.x12.Tests.Models.v4040;

public class AP1Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "AP1*jD*gt*iT0*2*7*Ysu*JV8*9o*4*9*W*1*y";

		var expected = new AP1_AlternateParts()
		{
			ConditionIndicator = "jD",
			StateOrProvinceCode = "gt",
			PriceIdentifierCode = "iT0",
			Percent = 2,
			MonetaryAmount = 7,
			PostalCode = "Ysu",
			PostalCode2 = "JV8",
			PrintOptionCode = "9o",
			Number = 4,
			Quantity = 9,
			FreeFormMessage = "W",
			ProductServiceID = "1",
			Description = "y",
		};

		var actual = Map.MapObject<AP1_AlternateParts>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("jD", true)]
	public void Validation_RequiredConditionIndicator(string conditionIndicator, bool isValidExpected)
	{
		var subject = new AP1_AlternateParts();
		//Required fields
		//Test Parameters
		subject.ConditionIndicator = conditionIndicator;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("JV8", "Ysu", true)]
	[InlineData("JV8", "", false)]
	[InlineData("", "Ysu", true)]
	public void Validation_ARequiresBPostalCode2(string postalCode2, string postalCode, bool isValidExpected)
	{
		var subject = new AP1_AlternateParts();
		//Required fields
		subject.ConditionIndicator = "jD";
		//Test Parameters
		subject.PostalCode2 = postalCode2;
		subject.PostalCode = postalCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
	}

}
