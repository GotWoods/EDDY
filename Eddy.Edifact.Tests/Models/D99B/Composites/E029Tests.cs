using Eddy.Core.Validation;
using Eddy.Edifact.Mapping;
using Eddy.Edifact.Models.D99B;
using Eddy.Edifact.Models.D99B.Composites;

namespace Eddy.Edifact.Tests.Models.D99B.Composites;

public class E029Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string line = "p:q:f";

		var expected = new E029_Diagnosis()
		{
			ProductIdentifier = "p",
			DiagnosisTypeCode = "q",
			CodeListIdentificationCode = "f",
		};

		var actual = Map.MapComposite<E029_Diagnosis>(line, MapOptionsForTesting.EdifactDefaultEndsWithSingleQuote);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("p", true)]
	public void Validation_RequiredProductIdentifier(string productIdentifier, bool isValidExpected)
	{
		var subject = new E029_Diagnosis();
		//Required fields
		//Test Parameters
		subject.ProductIdentifier = productIdentifier;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
