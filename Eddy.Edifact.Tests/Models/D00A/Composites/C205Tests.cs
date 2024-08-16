using Eddy.Core.Validation;
using Eddy.Edifact.Mapping;
using Eddy.Edifact.Models.D00A;
using Eddy.Edifact.Models.D00A.Composites;

namespace Eddy.Edifact.Tests.Models.D00A.Composites;

public class C205Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		var line = "I:l:u";

		var expected = new C205_HazardCode()
		{
			HazardIdentificationCode = "I",
			AdditionalHazardClassificationIdentifier = "l",
			HazardCodeVersionIdentifier = "u",
		};

		var actual = Map.MapComposite<C205_HazardCode>(line, MapOptionsForTesting.EdifactDefaultEndsWithSingleQuote);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("I", true)]
	public void Validation_RequiredHazardIdentificationCode(string hazardIdentificationCode, bool isValidExpected)
	{
		var subject = new C205_HazardCode();
		//Required fields
		//Test Parameters
		subject.HazardIdentificationCode = hazardIdentificationCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
