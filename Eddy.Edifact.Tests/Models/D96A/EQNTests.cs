using Eddy.Core.Validation;
using Eddy.Edifact.Mapping;
using Eddy.Edifact.Models.D96A;
using Eddy.Edifact.Models.D96A.Composites;

namespace Eddy.Edifact.Tests.Models.D96A;

public class EQNTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string line = "EQN+";

		var expected = new EQN_NumberOfUnits()
		{
			NumberOfUnitDetails = null,
		};

		var actual = Map.MapObject<EQN_NumberOfUnits>(line, MapOptionsForTesting.EdifactDefaultEndsWithSingleQuote);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("A", true)]
	public void Validation_RequiredNumberOfUnitDetails(string numberOfUnitDetails, bool isValidExpected)
	{
		var subject = new EQN_NumberOfUnits();
		//Required fields
		//Test Parameters
		if (numberOfUnitDetails != "") 
			subject.NumberOfUnitDetails = new C523_NumberOfUnitDetails();
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
