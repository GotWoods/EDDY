using Eddy.Core.Validation;
using Eddy.Edifact.Mapping;
using Eddy.Edifact.Models.D00A;
using Eddy.Edifact.Models.D00A.Composites;

namespace Eddy.Edifact.Tests.Models.D00A.Composites;

public class E020Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string line = "b:h:g";

		var expected = new E020_TaxDetails()
		{
			DutyOrTaxOrFeeTypeNameCode = "b",
			MonetaryAmount = "h",
			DutyOrTaxOrFeeRateDescription = "g",
		};

		var actual = Map.MapComposite<E020_TaxDetails>(line, MapOptionsForTesting.EdifactDefaultEndsWithSingleQuote);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("b", true)]
	public void Validation_RequiredDutyOrTaxOrFeeTypeNameCode(string dutyOrTaxOrFeeTypeNameCode, bool isValidExpected)
	{
		var subject = new E020_TaxDetails();
		//Required fields
		//Test Parameters
		subject.DutyOrTaxOrFeeTypeNameCode = dutyOrTaxOrFeeTypeNameCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
