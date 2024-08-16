using Eddy.Core.Validation;
using Eddy.Edifact.Mapping;
using Eddy.Edifact.Models.D96A;
using Eddy.Edifact.Models.D96A.Composites;

namespace Eddy.Edifact.Tests.Models.D96A;

public class EQATests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string line = "EQA+P+";

		var expected = new EQA_AttachedEquipment()
		{
			EquipmentQualifier = "P",
			EquipmentIdentification = null,
		};

		var actual = Map.MapObject<EQA_AttachedEquipment>(line, MapOptionsForTesting.EdifactDefaultEndsWithSingleQuote);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("P", true)]
	public void Validation_RequiredEquipmentQualifier(string equipmentQualifier, bool isValidExpected)
	{
		var subject = new EQA_AttachedEquipment();
		//Required fields
		//Test Parameters
		subject.EquipmentQualifier = equipmentQualifier;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
