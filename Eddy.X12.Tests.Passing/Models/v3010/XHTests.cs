using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3010;

namespace Eddy.x12.Tests.Models.v3010;

public class XHTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "XH*Q4b*h*Hux*9*K*4l*1";

		var expected = new XH_ProFormaB13Information()
		{
			CurrencyCode = "Q4b",
			RelatedCompanyIndicationCode = "h",
			SpecialChargeCode = "Hux",
			Charge = "9",
			Block20Code = "K",
			ChemicalAnalysisPercentage = "4l",
			UnitPrice = 1,
		};

		var actual = Map.MapObject<XH_ProFormaB13Information>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("Q4b", true)]
	public void Validation_RequiredCurrencyCode(string currencyCode, bool isValidExpected)
	{
		var subject = new XH_ProFormaB13Information();
		//Required fields
		//Test Parameters
		subject.CurrencyCode = currencyCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
