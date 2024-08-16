using Eddy.Core.Validation;
using Eddy.Edifact.Mapping;
using Eddy.Edifact.Models.D99B;
using Eddy.Edifact.Models.D99B.Composites;

namespace Eddy.Edifact.Tests.Models.D99B.Composites;

public class E025Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string line = "F:V:o:s:f:P";

		var expected = new E025_BasisOfServiceInformation()
		{
			BasisOfServiceCodeQualifier = "F",
			ProductIdentifier = "V",
			CodeListIdentificationCode = "o",
			DateTimePeriodValue = "s",
			DateTimePeriodFormatCode = "f",
			MonetaryAmountValue = "P",
		};

		var actual = Map.MapComposite<E025_BasisOfServiceInformation>(line, MapOptionsForTesting.EdifactDefaultEndsWithSingleQuote);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("F", true)]
	public void Validation_RequiredBasisOfServiceCodeQualifier(string basisOfServiceCodeQualifier, bool isValidExpected)
	{
		var subject = new E025_BasisOfServiceInformation();
		//Required fields
		subject.ProductIdentifier = "V";
		//Test Parameters
		subject.BasisOfServiceCodeQualifier = basisOfServiceCodeQualifier;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("V", true)]
	public void Validation_RequiredProductIdentifier(string productIdentifier, bool isValidExpected)
	{
		var subject = new E025_BasisOfServiceInformation();
		//Required fields
		subject.BasisOfServiceCodeQualifier = "F";
		//Test Parameters
		subject.ProductIdentifier = productIdentifier;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
