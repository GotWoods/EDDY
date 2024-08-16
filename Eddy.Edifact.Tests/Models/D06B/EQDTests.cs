using Eddy.Core.Validation;
using Eddy.Edifact.Mapping;
using Eddy.Edifact.Models.D06B;
using Eddy.Edifact.Models.D06B.Composites;

namespace Eddy.Edifact.Tests.Models.D06B;

public class EQDTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string line = "EQD+v+++d+K+C+B";

		var expected = new EQD_EquipmentDetails()
		{
			EquipmentTypeCodeQualifier = "v",
			EquipmentIdentification = null,
			EquipmentSizeAndType = null,
			EquipmentSupplierCode = "d",
			EquipmentStatusCode = "K",
			FullOrEmptyIndicatorCode = "C",
			MarkingInstructionsCode = "B",
		};

		var actual = Map.MapObject<EQD_EquipmentDetails>(line, MapOptionsForTesting.EdifactDefaultEndsWithSingleQuote);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("v", true)]
	public void Validation_RequiredEquipmentTypeCodeQualifier(string equipmentTypeCodeQualifier, bool isValidExpected)
	{
		var subject = new EQD_EquipmentDetails();
		//Required fields
		//Test Parameters
		subject.EquipmentTypeCodeQualifier = equipmentTypeCodeQualifier;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
