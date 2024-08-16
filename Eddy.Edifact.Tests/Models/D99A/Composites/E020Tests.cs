using Eddy.Core.Validation;
using Eddy.Edifact.Mapping;
using Eddy.Edifact.Models.D99A;
using Eddy.Edifact.Models.D99A.Composites;

namespace Eddy.Edifact.Tests.Models.D99A.Composites;

public class E020Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string line = "o:U:L";

		var expected = new E020_TaxDetails()
		{
			DutyTaxFeeTypeCoded = "o",
			MonetaryAmount = "U",
			DutyTaxFeeRate = "L",
		};

		var actual = Map.MapComposite<E020_TaxDetails>(line, MapOptionsForTesting.EdifactDefaultEndsWithSingleQuote);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("o", true)]
	public void Validation_RequiredDutyTaxFeeTypeCoded(string dutyTaxFeeTypeCoded, bool isValidExpected)
	{
		var subject = new E020_TaxDetails();
		//Required fields
		//Test Parameters
		subject.DutyTaxFeeTypeCoded = dutyTaxFeeTypeCoded;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
