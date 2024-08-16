using Eddy.Core.Validation;
using Eddy.Edifact.Mapping;
using Eddy.Edifact.Models.D99B;
using Eddy.Edifact.Models.D99B.Composites;

namespace Eddy.Edifact.Tests.Models.D99B.Composites;

public class C242Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		var line = "D:g:a:c:1";

		var expected = new C242_ProcessTypeAndDescription()
		{
			ProcessTypeDescriptionCode = "D",
			CodeListIdentificationCode = "g",
			CodeListResponsibleAgencyCode = "a",
			ProcessTypeDescription = "c",
			ProcessTypeDescription2 = "1",
		};

		var actual = Map.MapComposite<C242_ProcessTypeAndDescription>(line, MapOptionsForTesting.EdifactDefaultEndsWithSingleQuote);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("D", true)]
	public void Validation_RequiredProcessTypeDescriptionCode(string processTypeDescriptionCode, bool isValidExpected)
	{
		var subject = new C242_ProcessTypeAndDescription();
		//Required fields
		//Test Parameters
		subject.ProcessTypeDescriptionCode = processTypeDescriptionCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
