using Eddy.Core.Validation;
using Eddy.Edifact.Mapping;
using Eddy.Edifact.Models.D00A;
using Eddy.Edifact.Models.D00A.Composites;

namespace Eddy.Edifact.Tests.Models.D00A.Composites;

public class C901Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		var line = "9:J:f";

		var expected = new C901_ApplicationErrorDetail()
		{
			ApplicationErrorCode = "9",
			CodeListIdentificationCode = "J",
			CodeListResponsibleAgencyCode = "f",
		};

		var actual = Map.MapComposite<C901_ApplicationErrorDetail>(line, MapOptionsForTesting.EdifactDefaultEndsWithSingleQuote);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("9", true)]
	public void Validation_RequiredApplicationErrorCode(string applicationErrorCode, bool isValidExpected)
	{
		var subject = new C901_ApplicationErrorDetail();
		//Required fields
		//Test Parameters
		subject.ApplicationErrorCode = applicationErrorCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
