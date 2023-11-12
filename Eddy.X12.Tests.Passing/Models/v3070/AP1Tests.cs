using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3070;

namespace Eddy.x12.Tests.Models.v3070;

public class AP1Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "AP1*tM*uQ*Gcl*5*5*auw*aIJ*F3*4*8*a*P*O";

		var expected = new AP1_AlternateParts()
		{
			ConditionIndicator = "tM",
			StateOrProvinceCode = "uQ",
			PriceIdentifierCode = "Gcl",
			Percent = 5,
			MonetaryAmount = 5,
			PostalCode = "auw",
			PostalCode2 = "aIJ",
			PrintOptionCode = "F3",
			Number = 4,
			Quantity = 8,
			FreeFormMessage = "a",
			ProductServiceID = "P",
			Description = "O",
		};

		var actual = Map.MapObject<AP1_AlternateParts>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("tM", true)]
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
	[InlineData("aIJ", "auw", true)]
	[InlineData("aIJ", "", false)]
	[InlineData("", "auw", true)]
	public void Validation_ARequiresBPostalCode2(string postalCode2, string postalCode, bool isValidExpected)
	{
		var subject = new AP1_AlternateParts();
		//Required fields
		subject.ConditionIndicator = "tM";
		//Test Parameters
		subject.PostalCode2 = postalCode2;
		subject.PostalCode = postalCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
	}

}
