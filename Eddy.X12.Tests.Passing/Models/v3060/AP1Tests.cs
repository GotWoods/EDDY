using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3060;

namespace Eddy.x12.Tests.Models.v3060;

public class AP1Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "AP1*f6*W9*uxB*5*2*tQe*v24*YT*6*5*p*5*8";

		var expected = new AP1_AlternateParts()
		{
			ConditionIndicator = "f6",
			StateOrProvinceCode = "W9",
			PriceIdentifierCode = "uxB",
			Percent = 5,
			MonetaryAmount = 2,
			PostalCode = "tQe",
			PostalCode2 = "v24",
			PrintOptionCode = "YT",
			Number = 6,
			Quantity = 5,
			FreeFormMessage = "p",
			ProductServiceID = "5",
			Description = "8",
		};

		var actual = Map.MapObject<AP1_AlternateParts>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("f6", true)]
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
	[InlineData("v24", "tQe", true)]
	[InlineData("v24", "", false)]
	[InlineData("", "tQe", true)]
	public void Validation_ARequiresBPostalCode2(string postalCode2, string postalCode, bool isValidExpected)
	{
		var subject = new AP1_AlternateParts();
		//Required fields
		subject.ConditionIndicator = "f6";
		//Test Parameters
		subject.PostalCode2 = postalCode2;
		subject.PostalCode = postalCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
	}

}
