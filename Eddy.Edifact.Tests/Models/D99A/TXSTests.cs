using Eddy.Core.Validation;
using Eddy.Edifact.Mapping;
using Eddy.Edifact.Models.D99A;
using Eddy.Edifact.Models.D99A.Composites;

namespace Eddy.Edifact.Tests.Models.D99A;

public class TXSTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string line = "TXS+";

		var expected = new TXS_Taxes()
		{
			TaxDetails = null,
		};

		var actual = Map.MapObject<TXS_Taxes>(line, MapOptionsForTesting.EdifactDefaultEndsWithSingleQuote);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("A", true)]
	public void Validation_RequiredTaxDetails(string taxDetails, bool isValidExpected)
	{
		var subject = new TXS_Taxes();
		//Required fields
		//Test Parameters
		if (taxDetails != "") 
			subject.TaxDetails = new E020_TaxDetails();
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
