using Eddy.Core.Validation;
using Eddy.Edifact.Mapping;
using Eddy.Edifact.Models.D00B;
using Eddy.Edifact.Models.D00B.Composites;

namespace Eddy.Edifact.Tests.Models.D00B.Composites;

public class E029Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string line = "j:6:I";

		var expected = new E029_Diagnosis()
		{
			ProductIdentifier = "j",
			DiagnosisTypeCode = "6",
			CodeListIdentificationCode = "I",
		};

		var actual = Map.MapComposite<E029_Diagnosis>(line, MapOptionsForTesting.EdifactDefaultEndsWithSingleQuote);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("j", true)]
	public void Validation_RequiredProductIdentifier(string productIdentifier, bool isValidExpected)
	{
		var subject = new E029_Diagnosis();
		//Required fields
		//Test Parameters
		subject.ProductIdentifier = productIdentifier;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
