using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v6010;

namespace Eddy.x12.Tests.Models.v6010;

public class AP1Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "AP1*EY*lW*qIl*1*7*XA2*Agj*Gh*1*9*M*W*W";

		var expected = new AP1_AlternateParts()
		{
			ConditionIndicator = "EY",
			StateOrProvinceCode = "lW",
			PriceIdentifierCode = "qIl",
			PercentageAsDecimal = 1,
			MonetaryAmount = 7,
			PostalCode = "XA2",
			PostalCode2 = "Agj",
			PrintOptionCode = "Gh",
			Number = 1,
			Quantity = 9,
			FreeFormInformation = "M",
			ProductServiceID = "W",
			Description = "W",
		};

		var actual = Map.MapObject<AP1_AlternateParts>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("EY", true)]
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
	[InlineData("Agj", "XA2", true)]
	[InlineData("Agj", "", false)]
	[InlineData("", "XA2", true)]
	public void Validation_ARequiresBPostalCode2(string postalCode2, string postalCode, bool isValidExpected)
	{
		var subject = new AP1_AlternateParts();
		//Required fields
		subject.ConditionIndicator = "EY";
		//Test Parameters
		subject.PostalCode2 = postalCode2;
		subject.PostalCode = postalCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
	}

}
