using Eddy.Core.Validation;
using Eddy.x12.Mapping;
using Eddy.x12.Models;

namespace Eddy.Tests.x12.Models;

public class XHTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "XH*GMF*Z*7ie*n*j*zK*4";

		var expected = new XH_ProFormaB13Information()
		{
			CurrencyCode = "GMF",
			RelatedCompanyIndicationCode = "Z",
			SpecialChargeOrAllowanceCode = "7ie",
			Amount = "n",
			Block20Code = "j",
			ChemicalAnalysisPercentage = "zK",
			UnitPrice = 4,
		};

		var actual = Map.MapObject<XH_ProFormaB13Information>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("GMF", true)]
	public void Validation_RequiredCurrencyCode(string currencyCode, bool isValidExpected)
	{
		var subject = new XH_ProFormaB13Information();
		subject.CurrencyCode = currencyCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
