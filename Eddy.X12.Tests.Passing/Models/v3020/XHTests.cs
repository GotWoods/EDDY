using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3020;

namespace Eddy.x12.Tests.Models.v3020;

public class XHTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "XH*ype*f*c8i*j*C*rn*7";

		var expected = new XH_ProFormaB13Information()
		{
			CurrencyCode = "ype",
			RelatedCompanyIndicationCode = "f",
			SpecialChargeOrAllowanceCode = "c8i",
			Charge = "j",
			Block20Code = "C",
			ChemicalAnalysisPercentage = "rn",
			UnitPrice = 7,
		};

		var actual = Map.MapObject<XH_ProFormaB13Information>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("ype", true)]
	public void Validation_RequiredCurrencyCode(string currencyCode, bool isValidExpected)
	{
		var subject = new XH_ProFormaB13Information();
		//Required fields
		//Test Parameters
		subject.CurrencyCode = currencyCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
