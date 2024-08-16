using Eddy.Core.Validation;
using Eddy.Edifact.Mapping;
using Eddy.Edifact.Models.D96A;
using Eddy.Edifact.Models.D96A.Composites;

namespace Eddy.Edifact.Tests.Models.D96A;

public class CDVTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string line = "CDV+x+p+T";

		var expected = new CDV_CodeValueDefinition()
		{
			CodeValue = "x",
			CodeName = "p",
			MaintenanceOperationCoded = "T",
		};

		var actual = Map.MapObject<CDV_CodeValueDefinition>(line, MapOptionsForTesting.EdifactDefaultEndsWithSingleQuote);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("x", true)]
	public void Validation_RequiredCodeValue(string codeValue, bool isValidExpected)
	{
		var subject = new CDV_CodeValueDefinition();
		//Required fields
		//Test Parameters
		subject.CodeValue = codeValue;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
