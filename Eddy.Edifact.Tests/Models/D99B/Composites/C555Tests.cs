using Eddy.Core.Validation;
using Eddy.Edifact.Mapping;
using Eddy.Edifact.Models.D99B;
using Eddy.Edifact.Models.D99B.Composites;

namespace Eddy.Edifact.Tests.Models.D99B.Composites;

public class C555Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		var line = "u:8:S:4";

		var expected = new C555_Status()
		{
			StatusDescriptionCode = "u",
			CodeListIdentificationCode = "8",
			CodeListResponsibleAgencyCode = "S",
			StatusDescription = "4",
		};

		var actual = Map.MapComposite<C555_Status>(line, MapOptionsForTesting.EdifactDefaultEndsWithSingleQuote);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("u", true)]
	public void Validation_RequiredStatusDescriptionCode(string statusDescriptionCode, bool isValidExpected)
	{
		var subject = new C555_Status();
		//Required fields
		//Test Parameters
		subject.StatusDescriptionCode = statusDescriptionCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
