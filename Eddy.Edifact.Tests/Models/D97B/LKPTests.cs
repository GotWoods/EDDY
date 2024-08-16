using Eddy.Core.Validation;
using Eddy.Edifact.Mapping;
using Eddy.Edifact.Models.D97B;
using Eddy.Edifact.Models.D97B.Composites;

namespace Eddy.Edifact.Tests.Models.D97B;

public class LKPTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string line = "LKP+";

		var expected = new LKP_LevelIndication()
		{
			PositionIdentification = null,
		};

		var actual = Map.MapObject<LKP_LevelIndication>(line, MapOptionsForTesting.EdifactDefaultEndsWithSingleQuote);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("A", true)]
	public void Validation_RequiredPositionIdentification(string positionIdentification, bool isValidExpected)
	{
		var subject = new LKP_LevelIndication();
		//Required fields
		//Test Parameters
		if (positionIdentification != "") 
			subject.PositionIdentification = new E778_PositionIdentification();
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
