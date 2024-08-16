using Eddy.Core.Validation;
using Eddy.Edifact.Mapping;
using Eddy.Edifact.Models.D99B;
using Eddy.Edifact.Models.D99B.Composites;

namespace Eddy.Edifact.Tests.Models.D99B.Composites;

public class E020Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string line = "E:N:3";

		var expected = new E020_TaxDetails()
		{
			DutyTaxFeeTypeNameCode = "E",
			MonetaryAmountValue = "N",
			DutyTaxFeeRate = "3",
		};

		var actual = Map.MapComposite<E020_TaxDetails>(line, MapOptionsForTesting.EdifactDefaultEndsWithSingleQuote);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("E", true)]
	public void Validation_RequiredDutyTaxFeeTypeNameCode(string dutyTaxFeeTypeNameCode, bool isValidExpected)
	{
		var subject = new E020_TaxDetails();
		//Required fields
		//Test Parameters
		subject.DutyTaxFeeTypeNameCode = dutyTaxFeeTypeNameCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
