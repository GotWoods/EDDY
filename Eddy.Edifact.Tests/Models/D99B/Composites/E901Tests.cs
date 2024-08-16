using Eddy.Core.Validation;
using Eddy.Edifact.Mapping;
using Eddy.Edifact.Models.D99B;
using Eddy.Edifact.Models.D99B.Composites;

namespace Eddy.Edifact.Tests.Models.D99B.Composites;

public class E901Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string line = "S:a:0";

		var expected = new E901_ApplicationErrorDetails()
		{
			ApplicationErrorIdentification = "S",
			CodeListIdentificationCode = "a",
			CodeListResponsibleAgencyCode = "0",
		};

		var actual = Map.MapComposite<E901_ApplicationErrorDetails>(line, MapOptionsForTesting.EdifactDefaultEndsWithSingleQuote);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("S", true)]
	public void Validation_RequiredApplicationErrorIdentification(string applicationErrorIdentification, bool isValidExpected)
	{
		var subject = new E901_ApplicationErrorDetails();
		//Required fields
		//Test Parameters
		subject.ApplicationErrorIdentification = applicationErrorIdentification;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
