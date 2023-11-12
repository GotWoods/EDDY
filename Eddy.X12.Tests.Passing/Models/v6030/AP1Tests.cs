using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v6030;

namespace Eddy.x12.Tests.Models.v6030;

public class AP1Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "AP1*zS*wj*AxW*9*4*zAT*qtK*Ii*9*1*j*x*8";

		var expected = new AP1_AlternateParts()
		{
			ConditionIndicatorCode = "zS",
			StateOrProvinceCode = "wj",
			PriceIdentifierCode = "AxW",
			PercentageAsDecimal = 9,
			MonetaryAmount = 4,
			PostalCode = "zAT",
			PostalCode2 = "qtK",
			PrintOptionCode = "Ii",
			Number = 9,
			Quantity = 1,
			FreeFormInformation = "j",
			ProductServiceID = "x",
			Description = "8",
		};

		var actual = Map.MapObject<AP1_AlternateParts>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("zS", true)]
	public void Validation_RequiredConditionIndicatorCode(string conditionIndicatorCode, bool isValidExpected)
	{
		var subject = new AP1_AlternateParts();
		//Required fields
		//Test Parameters
		subject.ConditionIndicatorCode = conditionIndicatorCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("qtK", "zAT", true)]
	[InlineData("qtK", "", false)]
	[InlineData("", "zAT", true)]
	public void Validation_ARequiresBPostalCode2(string postalCode2, string postalCode, bool isValidExpected)
	{
		var subject = new AP1_AlternateParts();
		//Required fields
		subject.ConditionIndicatorCode = "zS";
		//Test Parameters
		subject.PostalCode2 = postalCode2;
		subject.PostalCode = postalCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
	}

}
