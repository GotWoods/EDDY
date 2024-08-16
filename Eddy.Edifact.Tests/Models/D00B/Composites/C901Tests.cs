using Eddy.Core.Validation;
using Eddy.Edifact.Mapping;
using Eddy.Edifact.Models.D00B;
using Eddy.Edifact.Models.D00B.Composites;

namespace Eddy.Edifact.Tests.Models.D00B.Composites;

public class C901Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		var line = "j:w:8";

		var expected = new C901_ApplicationErrorDetail()
		{
			ApplicationErrorCode = "j",
			CodeListIdentificationCode = "w",
			CodeListResponsibleAgencyCode = "8",
		};

		var actual = Map.MapComposite<C901_ApplicationErrorDetail>(line, MapOptionsForTesting.EdifactDefaultEndsWithSingleQuote);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("j", true)]
	public void Validation_RequiredApplicationErrorCode(string applicationErrorCode, bool isValidExpected)
	{
		var subject = new C901_ApplicationErrorDetail();
		//Required fields
		//Test Parameters
		subject.ApplicationErrorCode = applicationErrorCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
