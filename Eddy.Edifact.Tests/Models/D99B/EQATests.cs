using Eddy.Core.Validation;
using Eddy.Edifact.Mapping;
using Eddy.Edifact.Models.D99B;
using Eddy.Edifact.Models.D99B.Composites;

namespace Eddy.Edifact.Tests.Models.D99B;

public class EQATests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string line = "EQA+C+";

		var expected = new EQA_AttachedEquipment()
		{
			EquipmentTypeCodeQualifier = "C",
			EquipmentIdentification = null,
		};

		var actual = Map.MapObject<EQA_AttachedEquipment>(line, MapOptionsForTesting.EdifactDefaultEndsWithSingleQuote);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("C", true)]
	public void Validation_RequiredEquipmentTypeCodeQualifier(string equipmentTypeCodeQualifier, bool isValidExpected)
	{
		var subject = new EQA_AttachedEquipment();
		//Required fields
		//Test Parameters
		subject.EquipmentTypeCodeQualifier = equipmentTypeCodeQualifier;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
