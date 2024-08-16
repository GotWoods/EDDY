using Eddy.Core.Validation;
using Eddy.Edifact.Mapping;
using Eddy.Edifact.Models.D00B;
using Eddy.Edifact.Models.D00B.Composites;

namespace Eddy.Edifact.Tests.Models.D00B.Composites;

public class E020Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string line = "S:X:X";

		var expected = new E020_TaxDetails()
		{
			DutyOrTaxOrFeeTypeNameCode = "S",
			MonetaryAmount = "X",
			DutyOrTaxOrFeeRate = "X",
		};

		var actual = Map.MapComposite<E020_TaxDetails>(line, MapOptionsForTesting.EdifactDefaultEndsWithSingleQuote);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("S", true)]
	public void Validation_RequiredDutyOrTaxOrFeeTypeNameCode(string dutyOrTaxOrFeeTypeNameCode, bool isValidExpected)
	{
		var subject = new E020_TaxDetails();
		//Required fields
		//Test Parameters
		subject.DutyOrTaxOrFeeTypeNameCode = dutyOrTaxOrFeeTypeNameCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
