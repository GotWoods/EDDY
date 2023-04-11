using EdiParser.Validation;
using EdiParser.x12.Mapping;
using EdiParser.x12.Models;

namespace EdiParser.Tests.x12.Models;

public class FA1Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "FA1*bh*BOXl*I";

		var expected = new FA1_TypeOfFinancialAccountingData()
		{
			AgencyQualifierCode = "bh",
			ServicePromotionAllowanceOrChargeCode = "BOXl",
			AllowanceOrChargeIndicatorCode = "I",
		};

		var actual = Map.MapObject<FA1_TypeOfFinancialAccountingData>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("bh", true)]
	public void Validatation_RequiredAgencyQualifierCode(string agencyQualifierCode, bool isValidExpected)
	{
		var subject = new FA1_TypeOfFinancialAccountingData();
		subject.AgencyQualifierCode = agencyQualifierCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
