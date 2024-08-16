using Eddy.Core.Validation;
using Eddy.Edifact.Mapping;
using Eddy.Edifact.Models.D96A;
using Eddy.Edifact.Models.D96A.Composites;

namespace Eddy.Edifact.Tests.Models.D96A.Composites;

public class C901Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		var line = "1:L:o";

		var expected = new C901_ApplicationErrorDetail()
		{
			ApplicationErrorIdentification = "1",
			CodeListQualifier = "L",
			CodeListResponsibleAgencyCoded = "o",
		};

		var actual = Map.MapComposite<C901_ApplicationErrorDetail>(line, MapOptionsForTesting.EdifactDefaultEndsWithSingleQuote);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("1", true)]
	public void Validation_RequiredApplicationErrorIdentification(string applicationErrorIdentification, bool isValidExpected)
	{
		var subject = new C901_ApplicationErrorDetail();
		//Required fields
		//Test Parameters
		subject.ApplicationErrorIdentification = applicationErrorIdentification;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
