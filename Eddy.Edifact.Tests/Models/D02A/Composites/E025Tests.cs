using Eddy.Core.Validation;
using Eddy.Edifact.Mapping;
using Eddy.Edifact.Models.D02A;
using Eddy.Edifact.Models.D02A.Composites;

namespace Eddy.Edifact.Tests.Models.D02A.Composites;

public class E025Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string line = "7:q:r:7:4:E";

		var expected = new E025_BasisOfServiceInformation()
		{
			ServiceBasisCodeQualifier = "7",
			ProductIdentifier = "q",
			CodeListIdentificationCode = "r",
			DateOrTimeOrPeriodText = "7",
			DateOrTimeOrPeriodFormatCode = "4",
			MonetaryAmount = "E",
		};

		var actual = Map.MapComposite<E025_BasisOfServiceInformation>(line, MapOptionsForTesting.EdifactDefaultEndsWithSingleQuote);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("7", true)]
	public void Validation_RequiredServiceBasisCodeQualifier(string serviceBasisCodeQualifier, bool isValidExpected)
	{
		var subject = new E025_BasisOfServiceInformation();
		//Required fields
		subject.ProductIdentifier = "q";
		//Test Parameters
		subject.ServiceBasisCodeQualifier = serviceBasisCodeQualifier;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("q", true)]
	public void Validation_RequiredProductIdentifier(string productIdentifier, bool isValidExpected)
	{
		var subject = new E025_BasisOfServiceInformation();
		//Required fields
		subject.ServiceBasisCodeQualifier = "7";
		//Test Parameters
		subject.ProductIdentifier = productIdentifier;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
