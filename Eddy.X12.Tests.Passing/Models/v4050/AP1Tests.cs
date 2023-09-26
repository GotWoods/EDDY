using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v4050;

namespace Eddy.x12.Tests.Models.v4050;

public class AP1Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "AP1*05*5a*XbQ*6*3*yq9*fqh*YQ*7*4*n*k*S";

		var expected = new AP1_AlternateParts()
		{
			ConditionIndicator = "05",
			StateOrProvinceCode = "5a",
			PriceIdentifierCode = "XbQ",
			PercentageAsDecimal = 6,
			MonetaryAmount = 3,
			PostalCode = "yq9",
			PostalCode2 = "fqh",
			PrintOptionCode = "YQ",
			Number = 7,
			Quantity = 4,
			FreeFormMessage = "n",
			ProductServiceID = "k",
			Description = "S",
		};

		var actual = Map.MapObject<AP1_AlternateParts>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("05", true)]
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
	[InlineData("fqh", "yq9", true)]
	[InlineData("fqh", "", false)]
	[InlineData("", "yq9", true)]
	public void Validation_ARequiresBPostalCode2(string postalCode2, string postalCode, bool isValidExpected)
	{
		var subject = new AP1_AlternateParts();
		//Required fields
		subject.ConditionIndicator = "05";
		//Test Parameters
		subject.PostalCode2 = postalCode2;
		subject.PostalCode = postalCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
	}

}
