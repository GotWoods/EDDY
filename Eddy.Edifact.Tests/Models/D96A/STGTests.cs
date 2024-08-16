using Eddy.Core.Validation;
using Eddy.Edifact.Mapping;
using Eddy.Edifact.Models.D96A;
using Eddy.Edifact.Models.D96A.Composites;

namespace Eddy.Edifact.Tests.Models.D96A;

public class STGTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string line = "STG+j+c+t";

		var expected = new STG_Stages()
		{
			StagesQualifier = "j",
			NumberOfStages = "c",
			ActualStageCount = "t",
		};

		var actual = Map.MapObject<STG_Stages>(line, MapOptionsForTesting.EdifactDefaultEndsWithSingleQuote);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("j", true)]
	public void Validation_RequiredStagesQualifier(string stagesQualifier, bool isValidExpected)
	{
		var subject = new STG_Stages();
		//Required fields
		//Test Parameters
		subject.StagesQualifier = stagesQualifier;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
