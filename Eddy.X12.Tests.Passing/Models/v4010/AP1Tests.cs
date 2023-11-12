using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v4010;

namespace Eddy.x12.Tests.Models.v4010;

public class AP1Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "AP1*JH*Yv*ppP*2*1*Ku5*zVq*Sg*8*8*c*v*0";

		var expected = new AP1_AlternateParts()
		{
			ConditionIndicator = "JH",
			StateOrProvinceCode = "Yv",
			PriceIdentifierCode = "ppP",
			Percent = 2,
			MonetaryAmount = 1,
			PostalCode = "Ku5",
			PostalCode2 = "zVq",
			PrintOptionCode = "Sg",
			Number = 8,
			Quantity = 8,
			FreeFormMessage = "c",
			ProductServiceID = "v",
			Description = "0",
		};

		var actual = Map.MapObject<AP1_AlternateParts>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("JH", true)]
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
	[InlineData("zVq", "Ku5", true)]
	[InlineData("zVq", "", false)]
	[InlineData("", "Ku5", true)]
	public void Validation_ARequiresBPostalCode2(string postalCode2, string postalCode, bool isValidExpected)
	{
		var subject = new AP1_AlternateParts();
		//Required fields
		subject.ConditionIndicator = "JH";
		//Test Parameters
		subject.PostalCode2 = postalCode2;
		subject.PostalCode = postalCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
	}

}
