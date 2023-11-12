using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.v3060;
using Eddy.x12.Models.v3060.Composites;

namespace Eddy.x12.Tests.Models.v3060.Composites;

public class C037Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		var x12Line = "N*A";

		var expected = new C037_TaxFieldIdentification()
		{
			TaxInformationIdentificationNumber = "N",
			ApplicationErrorConditionCode = "A",
		};

		var actual = Map.MapObject<C037_TaxFieldIdentification>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("N", true)]
	public void Validation_RequiredTaxInformationIdentificationNumber(string taxInformationIdentificationNumber, bool isValidExpected)
	{
		var subject = new C037_TaxFieldIdentification();
		//Required fields
		//Test Parameters
		subject.TaxInformationIdentificationNumber = taxInformationIdentificationNumber;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
