using Eddy.Core.Validation;
using Eddy.Edifact.Mapping;
using Eddy.Edifact.Models.D00B;
using Eddy.Edifact.Models.D00B.Composites;

namespace Eddy.Edifact.Tests.Models.D00B.Composites;

public class C555Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		var line = "r:i:3:6";

		var expected = new C555_Status()
		{
			StatusDescriptionCode = "r",
			CodeListIdentificationCode = "i",
			CodeListResponsibleAgencyCode = "3",
			StatusDescription = "6",
		};

		var actual = Map.MapComposite<C555_Status>(line, MapOptionsForTesting.EdifactDefaultEndsWithSingleQuote);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("r", true)]
	public void Validation_RequiredStatusDescriptionCode(string statusDescriptionCode, bool isValidExpected)
	{
		var subject = new C555_Status();
		//Required fields
		//Test Parameters
		subject.StatusDescriptionCode = statusDescriptionCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
