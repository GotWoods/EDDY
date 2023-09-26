using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v6030;

namespace Eddy.x12.Tests.Models.v6030;

public class FA1Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "FA1*BM*TaLJ*2";

		var expected = new FA1_TypeOfFinancialAccountingData()
		{
			AgencyQualifierCode = "BM",
			ServicePromotionAllowanceOrChargeCode = "TaLJ",
			AllowanceOrChargeIndicatorCode = "2",
		};

		var actual = Map.MapObject<FA1_TypeOfFinancialAccountingData>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("BM", true)]
	public void Validation_RequiredAgencyQualifierCode(string agencyQualifierCode, bool isValidExpected)
	{
		var subject = new FA1_TypeOfFinancialAccountingData();
		//Required fields
		//Test Parameters
		subject.AgencyQualifierCode = agencyQualifierCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
