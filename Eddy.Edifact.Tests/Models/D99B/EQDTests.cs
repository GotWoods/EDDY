using Eddy.Core.Validation;
using Eddy.Edifact.Mapping;
using Eddy.Edifact.Models.D99B;
using Eddy.Edifact.Models.D99B.Composites;

namespace Eddy.Edifact.Tests.Models.D99B;

public class EQDTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string line = "EQD+x+++A+7+I";

		var expected = new EQD_EquipmentDetails()
		{
			EquipmentTypeCodeQualifier = "x",
			EquipmentIdentification = null,
			EquipmentSizeAndType = null,
			EquipmentSupplierCoded = "A",
			EquipmentStatusCode = "7",
			FullEmptyIndicatorCoded = "I",
		};

		var actual = Map.MapObject<EQD_EquipmentDetails>(line, MapOptionsForTesting.EdifactDefaultEndsWithSingleQuote);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("x", true)]
	public void Validation_RequiredEquipmentTypeCodeQualifier(string equipmentTypeCodeQualifier, bool isValidExpected)
	{
		var subject = new EQD_EquipmentDetails();
		//Required fields
		//Test Parameters
		subject.EquipmentTypeCodeQualifier = equipmentTypeCodeQualifier;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
