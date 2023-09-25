using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3050;

namespace Eddy.x12.Tests.Models.v3050;

public class XHTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "XH*Ms5*g*8Up*y*i*cA*3";

		var expected = new XH_ProFormaB13Information()
		{
			CurrencyCode = "Ms5",
			RelatedCompanyIndicationCode = "g",
			SpecialChargeOrAllowanceCode = "8Up",
			Amount = "y",
			Block20Code = "i",
			ChemicalAnalysisPercentage = "cA",
			UnitPrice = 3,
		};

		var actual = Map.MapObject<XH_ProFormaB13Information>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("Ms5", true)]
	public void Validation_RequiredCurrencyCode(string currencyCode, bool isValidExpected)
	{
		var subject = new XH_ProFormaB13Information();
		//Required fields
		//Test Parameters
		subject.CurrencyCode = currencyCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
