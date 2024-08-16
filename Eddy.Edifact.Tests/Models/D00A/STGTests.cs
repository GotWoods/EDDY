using Eddy.Core.Validation;
using Eddy.Edifact.Mapping;
using Eddy.Edifact.Models.D00A;
using Eddy.Edifact.Models.D00A.Composites;

namespace Eddy.Edifact.Tests.Models.D00A;

public class STGTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string line = "STG+X+f+v";

		var expected = new STG_Stages()
		{
			ProcessStageCodeQualifier = "X",
			ProcessStagesQuantity = "f",
			ProcessStagesActualQuantity = "v",
		};

		var actual = Map.MapObject<STG_Stages>(line, MapOptionsForTesting.EdifactDefaultEndsWithSingleQuote);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("X", true)]
	public void Validation_RequiredProcessStageCodeQualifier(string processStageCodeQualifier, bool isValidExpected)
	{
		var subject = new STG_Stages();
		//Required fields
		//Test Parameters
		subject.ProcessStageCodeQualifier = processStageCodeQualifier;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
