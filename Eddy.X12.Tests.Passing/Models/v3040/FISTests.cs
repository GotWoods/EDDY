using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3040;

namespace Eddy.x12.Tests.Models.v3040;

public class FISTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "FIS*9*6*3*4";

		var expected = new FIS_MortgageLoanFiscalData()
		{
			AmountQualifierCode = "9",
			MonetaryAmount = 6,
			MonetaryAmount2 = 3,
			MonetaryAmount3 = 4,
		};

		var actual = Map.MapObject<FIS_MortgageLoanFiscalData>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("9", true)]
	public void Validation_RequiredAmountQualifierCode(string amountQualifierCode, bool isValidExpected)
	{
		var subject = new FIS_MortgageLoanFiscalData();
		//Required fields
		//Test Parameters
		subject.AmountQualifierCode = amountQualifierCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
