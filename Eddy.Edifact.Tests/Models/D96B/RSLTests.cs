using Eddy.Core.Validation;
using Eddy.Edifact.Mapping;
using Eddy.Edifact.Models.D96B;
using Eddy.Edifact.Models.D96B.Composites;

namespace Eddy.Edifact.Tests.Models.D96B;

public class RSLTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string line = "RSL+t+m++++f";

		var expected = new RSL_Result()
		{
			ResultQualifier = "t",
			ResultTypeCoded = "m",
			ResultDetails = null,
			ResultDetails2 = null,
			MeasurementUnitDetails = null,
			ResultNormalcyIndicatorCoded = "f",
		};

		var actual = Map.MapObject<RSL_Result>(line, MapOptionsForTesting.EdifactDefaultEndsWithSingleQuote);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("t", true)]
	public void Validation_RequiredResultQualifier(string resultQualifier, bool isValidExpected)
	{
		var subject = new RSL_Result();
		//Required fields
		//Test Parameters
		subject.ResultQualifier = resultQualifier;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
