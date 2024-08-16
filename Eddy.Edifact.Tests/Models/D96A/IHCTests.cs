using Eddy.Core.Validation;
using Eddy.Edifact.Mapping;
using Eddy.Edifact.Models.D96A;
using Eddy.Edifact.Models.D96A.Composites;

namespace Eddy.Edifact.Tests.Models.D96A;

public class IHCTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string line = "IHC+4+";

		var expected = new IHC_PersonCharacteristic()
		{
			PersonCharacteristicQualifier = "4",
			PersonInheritedCharacteristicDetails = null,
		};

		var actual = Map.MapObject<IHC_PersonCharacteristic>(line, MapOptionsForTesting.EdifactDefaultEndsWithSingleQuote);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("4", true)]
	public void Validation_RequiredPersonCharacteristicQualifier(string personCharacteristicQualifier, bool isValidExpected)
	{
		var subject = new IHC_PersonCharacteristic();
		//Required fields
		//Test Parameters
		subject.PersonCharacteristicQualifier = personCharacteristicQualifier;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
