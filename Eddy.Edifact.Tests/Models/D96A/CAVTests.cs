using Eddy.Core.Validation;
using Eddy.Edifact.Mapping;
using Eddy.Edifact.Models.D96A;
using Eddy.Edifact.Models.D96A.Composites;

namespace Eddy.Edifact.Tests.Models.D96A;

public class CAVTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string line = "CAV+";

		var expected = new CAV_CharacteristicValue()
		{
			CharacteristicValue = null,
		};

		var actual = Map.MapObject<CAV_CharacteristicValue>(line, MapOptionsForTesting.EdifactDefaultEndsWithSingleQuote);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("A", true)]
	public void Validation_RequiredCharacteristicValue(string characteristicValue, bool isValidExpected)
	{
		var subject = new CAV_CharacteristicValue();
		//Required fields
		//Test Parameters
		if (characteristicValue != "") 
			subject.CharacteristicValue = new C889_CharacteristicValue();
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
