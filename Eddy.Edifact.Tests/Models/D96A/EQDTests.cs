using Eddy.Core.Validation;
using Eddy.Edifact.Mapping;
using Eddy.Edifact.Models.D96A;
using Eddy.Edifact.Models.D96A.Composites;

namespace Eddy.Edifact.Tests.Models.D96A;

public class EQDTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string line = "EQD+2+++j+J+X";

		var expected = new EQD_EquipmentDetails()
		{
			EquipmentQualifier = "2",
			EquipmentIdentification = null,
			EquipmentSizeAndType = null,
			EquipmentSupplierCoded = "j",
			EquipmentStatusCoded = "J",
			FullEmptyIndicatorCoded = "X",
		};

		var actual = Map.MapObject<EQD_EquipmentDetails>(line, MapOptionsForTesting.EdifactDefaultEndsWithSingleQuote);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("2", true)]
	public void Validation_RequiredEquipmentQualifier(string equipmentQualifier, bool isValidExpected)
	{
		var subject = new EQD_EquipmentDetails();
		//Required fields
		//Test Parameters
		subject.EquipmentQualifier = equipmentQualifier;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
