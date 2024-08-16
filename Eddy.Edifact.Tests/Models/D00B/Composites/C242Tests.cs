using Eddy.Core.Validation;
using Eddy.Edifact.Mapping;
using Eddy.Edifact.Models.D00B;
using Eddy.Edifact.Models.D00B.Composites;

namespace Eddy.Edifact.Tests.Models.D00B.Composites;

public class C242Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		var line = "i:u:X:i:U";

		var expected = new C242_ProcessTypeAndDescription()
		{
			ProcessTypeDescriptionCode = "i",
			CodeListIdentificationCode = "u",
			CodeListResponsibleAgencyCode = "X",
			ProcessTypeDescription = "i",
			ProcessTypeDescription2 = "U",
		};

		var actual = Map.MapComposite<C242_ProcessTypeAndDescription>(line, MapOptionsForTesting.EdifactDefaultEndsWithSingleQuote);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("i", true)]
	public void Validation_RequiredProcessTypeDescriptionCode(string processTypeDescriptionCode, bool isValidExpected)
	{
		var subject = new C242_ProcessTypeAndDescription();
		//Required fields
		//Test Parameters
		subject.ProcessTypeDescriptionCode = processTypeDescriptionCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
