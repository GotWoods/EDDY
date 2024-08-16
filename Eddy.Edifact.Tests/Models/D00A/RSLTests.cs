using Eddy.Core.Validation;
using Eddy.Edifact.Mapping;
using Eddy.Edifact.Models.D00A;
using Eddy.Edifact.Models.D00A.Composites;

namespace Eddy.Edifact.Tests.Models.D00A;

public class RSLTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string line = "RSL+e+7++++k";

		var expected = new RSL_Result()
		{
			ResultValueTypeCodeQualifier = "e",
			ResultRepresentationCode = "7",
			ResultDetails = null,
			ResultDetails2 = null,
			MeasurementUnitDetails = null,
			ResultNormalcyCode = "k",
		};

		var actual = Map.MapObject<RSL_Result>(line, MapOptionsForTesting.EdifactDefaultEndsWithSingleQuote);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("e", true)]
	public void Validation_RequiredResultValueTypeCodeQualifier(string resultValueTypeCodeQualifier, bool isValidExpected)
	{
		var subject = new RSL_Result();
		//Required fields
		//Test Parameters
		subject.ResultValueTypeCodeQualifier = resultValueTypeCodeQualifier;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
