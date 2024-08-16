using Eddy.Core.Validation;
using Eddy.Edifact.Mapping;
using Eddy.Edifact.Models.D00A;
using Eddy.Edifact.Models.D00A.Composites;

namespace Eddy.Edifact.Tests.Models.D00A.Composites;

public class E025Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string line = "I:m:C:L:T:J";

		var expected = new E025_BasisOfServiceInformation()
		{
			ServiceBasisCodeQualifier = "I",
			ProductIdentifier = "m",
			CodeListIdentificationCode = "C",
			DateOrTimeOrPeriodValue = "L",
			DateOrTimeOrPeriodFormatCode = "T",
			MonetaryAmount = "J",
		};

		var actual = Map.MapComposite<E025_BasisOfServiceInformation>(line, MapOptionsForTesting.EdifactDefaultEndsWithSingleQuote);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("I", true)]
	public void Validation_RequiredServiceBasisCodeQualifier(string serviceBasisCodeQualifier, bool isValidExpected)
	{
		var subject = new E025_BasisOfServiceInformation();
		//Required fields
		subject.ProductIdentifier = "m";
		//Test Parameters
		subject.ServiceBasisCodeQualifier = serviceBasisCodeQualifier;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("m", true)]
	public void Validation_RequiredProductIdentifier(string productIdentifier, bool isValidExpected)
	{
		var subject = new E025_BasisOfServiceInformation();
		//Required fields
		subject.ServiceBasisCodeQualifier = "I";
		//Test Parameters
		subject.ProductIdentifier = productIdentifier;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
