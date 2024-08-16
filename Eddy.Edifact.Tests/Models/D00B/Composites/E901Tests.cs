using Eddy.Core.Validation;
using Eddy.Edifact.Mapping;
using Eddy.Edifact.Models.D00B;
using Eddy.Edifact.Models.D00B.Composites;

namespace Eddy.Edifact.Tests.Models.D00B.Composites;

public class E901Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string line = "P:i:3";

		var expected = new E901_ApplicationErrorDetails()
		{
			ApplicationErrorCode = "P",
			CodeListIdentificationCode = "i",
			CodeListResponsibleAgencyCode = "3",
		};

		var actual = Map.MapComposite<E901_ApplicationErrorDetails>(line, MapOptionsForTesting.EdifactDefaultEndsWithSingleQuote);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("P", true)]
	public void Validation_RequiredApplicationErrorCode(string applicationErrorCode, bool isValidExpected)
	{
		var subject = new E901_ApplicationErrorDetails();
		//Required fields
		//Test Parameters
		subject.ApplicationErrorCode = applicationErrorCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
