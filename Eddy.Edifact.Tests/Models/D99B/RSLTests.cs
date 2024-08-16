using Eddy.Core.Validation;
using Eddy.Edifact.Mapping;
using Eddy.Edifact.Models.D99B;
using Eddy.Edifact.Models.D99B.Composites;

namespace Eddy.Edifact.Tests.Models.D99B;

public class RSLTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string line = "RSL+t+i++++D";

		var expected = new RSL_Result()
		{
			ResultValueTypeCodeQualifier = "t",
			ResultTypeCoded = "i",
			ResultDetails = null,
			ResultDetails2 = null,
			MeasurementUnitDetails = null,
			ResultNormalcyIndicatorCoded = "D",
		};

		var actual = Map.MapObject<RSL_Result>(line, MapOptionsForTesting.EdifactDefaultEndsWithSingleQuote);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("t", true)]
	public void Validation_RequiredResultValueTypeCodeQualifier(string resultValueTypeCodeQualifier, bool isValidExpected)
	{
		var subject = new RSL_Result();
		//Required fields
		//Test Parameters
		subject.ResultValueTypeCodeQualifier = resultValueTypeCodeQualifier;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
