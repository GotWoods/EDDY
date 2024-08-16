using Eddy.Core.Validation;
using Eddy.Edifact.Mapping;
using Eddy.Edifact.Models.D98B;
using Eddy.Edifact.Models.D98B.Composites;

namespace Eddy.Edifact.Tests.Models.D98B;

public class CDVTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string line = "CDV+k+5+9+d+E";

		var expected = new CDV_CodeValueDefinition()
		{
			CodeValue = "k",
			CodeName = "5",
			MaintenanceOperationCoded = "9",
			CodeValueSourceCoded = "d",
			RequirementDesignatorCoded = "E",
		};

		var actual = Map.MapObject<CDV_CodeValueDefinition>(line, MapOptionsForTesting.EdifactDefaultEndsWithSingleQuote);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("k", true)]
	public void Validation_RequiredCodeValue(string codeValue, bool isValidExpected)
	{
		var subject = new CDV_CodeValueDefinition();
		//Required fields
		//Test Parameters
		subject.CodeValue = codeValue;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
