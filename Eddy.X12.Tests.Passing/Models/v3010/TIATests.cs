using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3010;

namespace Eddy.x12.Tests.Models.v3010;

public class TIATests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "TIA*g*2*a";

		var expected = new TIA_TaxInformationAndAmount()
		{
			TaxInformationCode = "g",
			MonetaryAmount = 2,
			FixedFormatInformation = "a",
		};

		var actual = Map.MapObject<TIA_TaxInformationAndAmount>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("g", true)]
	public void Validation_RequiredTaxInformationCode(string taxInformationCode, bool isValidExpected)
	{
		var subject = new TIA_TaxInformationAndAmount();
		//Required fields
		//Test Parameters
		subject.TaxInformationCode = taxInformationCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
