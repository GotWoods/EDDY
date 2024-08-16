using Eddy.Core.Validation;
using Eddy.Edifact.Mapping;
using Eddy.Edifact.Models.D00A;
using Eddy.Edifact.Models.D00A.Composites;

namespace Eddy.Edifact.Tests.Models.D00A;

public class IHCTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string line = "IHC+6+";

		var expected = new IHC_PersonCharacteristic()
		{
			PersonCharacteristicCodeQualifier = "6",
			PersonInheritedCharacteristicDetails = null,
		};

		var actual = Map.MapObject<IHC_PersonCharacteristic>(line, MapOptionsForTesting.EdifactDefaultEndsWithSingleQuote);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("6", true)]
	public void Validation_RequiredPersonCharacteristicCodeQualifier(string personCharacteristicCodeQualifier, bool isValidExpected)
	{
		var subject = new IHC_PersonCharacteristic();
		//Required fields
		//Test Parameters
		subject.PersonCharacteristicCodeQualifier = personCharacteristicCodeQualifier;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
