using Eddy.Core.Validation;
using Eddy.Edifact.Mapping;
using Eddy.Edifact.Models.D00B;
using Eddy.Edifact.Models.D00B.Composites;

namespace Eddy.Edifact.Tests.Models.D00B.Composites;

public class E025Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string line = "D:y:e:2:g:e";

		var expected = new E025_BasisOfServiceInformation()
		{
			ServiceBasisCodeQualifier = "D",
			ProductIdentifier = "y",
			CodeListIdentificationCode = "e",
			DateOrTimeOrPeriodValue = "2",
			DateOrTimeOrPeriodFormatCode = "g",
			MonetaryAmount = "e",
		};

		var actual = Map.MapComposite<E025_BasisOfServiceInformation>(line, MapOptionsForTesting.EdifactDefaultEndsWithSingleQuote);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("D", true)]
	public void Validation_RequiredServiceBasisCodeQualifier(string serviceBasisCodeQualifier, bool isValidExpected)
	{
		var subject = new E025_BasisOfServiceInformation();
		//Required fields
		subject.ProductIdentifier = "y";
		//Test Parameters
		subject.ServiceBasisCodeQualifier = serviceBasisCodeQualifier;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("y", true)]
	public void Validation_RequiredProductIdentifier(string productIdentifier, bool isValidExpected)
	{
		var subject = new E025_BasisOfServiceInformation();
		//Required fields
		subject.ServiceBasisCodeQualifier = "D";
		//Test Parameters
		subject.ProductIdentifier = productIdentifier;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
