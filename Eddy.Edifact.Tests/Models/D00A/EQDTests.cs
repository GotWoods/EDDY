using Eddy.Core.Validation;
using Eddy.Edifact.Mapping;
using Eddy.Edifact.Models.D00A;
using Eddy.Edifact.Models.D00A.Composites;

namespace Eddy.Edifact.Tests.Models.D00A;

public class EQDTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string line = "EQD+3+++e+i+O";

		var expected = new EQD_EquipmentDetails()
		{
			EquipmentTypeCodeQualifier = "3",
			EquipmentIdentification = null,
			EquipmentSizeAndType = null,
			EquipmentSupplierCode = "e",
			EquipmentStatusCode = "i",
			FullOrEmptyIndicatorCode = "O",
		};

		var actual = Map.MapObject<EQD_EquipmentDetails>(line, MapOptionsForTesting.EdifactDefaultEndsWithSingleQuote);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("3", true)]
	public void Validation_RequiredEquipmentTypeCodeQualifier(string equipmentTypeCodeQualifier, bool isValidExpected)
	{
		var subject = new EQD_EquipmentDetails();
		//Required fields
		//Test Parameters
		subject.EquipmentTypeCodeQualifier = equipmentTypeCodeQualifier;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
