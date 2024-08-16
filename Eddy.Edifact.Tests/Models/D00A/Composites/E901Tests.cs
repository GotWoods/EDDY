using Eddy.Core.Validation;
using Eddy.Edifact.Mapping;
using Eddy.Edifact.Models.D00A;
using Eddy.Edifact.Models.D00A.Composites;

namespace Eddy.Edifact.Tests.Models.D00A.Composites;

public class E901Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string line = "l:2:g";

		var expected = new E901_ApplicationErrorDetails()
		{
			ApplicationErrorCode = "l",
			CodeListIdentificationCode = "2",
			CodeListResponsibleAgencyCode = "g",
		};

		var actual = Map.MapComposite<E901_ApplicationErrorDetails>(line, MapOptionsForTesting.EdifactDefaultEndsWithSingleQuote);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("l", true)]
	public void Validation_RequiredApplicationErrorCode(string applicationErrorCode, bool isValidExpected)
	{
		var subject = new E901_ApplicationErrorDetails();
		//Required fields
		//Test Parameters
		subject.ApplicationErrorCode = applicationErrorCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
