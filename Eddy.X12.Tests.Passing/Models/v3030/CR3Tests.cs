using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3030;

namespace Eddy.x12.Tests.Models.v3030;

public class CR3Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "CR3*G*TW*9*D*N";

		var expected = new CR3_DurableMedicalEquipmentCertification()
		{
			CertificationTypeCode = "G",
			UnitOrBasisForMeasurementCode = "TW",
			Quantity = 9,
			InsulinDependentCode = "D",
			Description = "N",
		};

		var actual = Map.MapObject<CR3_DurableMedicalEquipmentCertification>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", 0, true)]
	[InlineData("TW", 9, true)]
	[InlineData("TW", 0, false)]
	[InlineData("", 9, false)]
	public void Validation_AllAreRequiredUnitOrBasisForMeasurementCode(string unitOrBasisForMeasurementCode, decimal quantity, bool isValidExpected)
	{
		var subject = new CR3_DurableMedicalEquipmentCertification();
		//Required fields
		//Test Parameters
		subject.UnitOrBasisForMeasurementCode = unitOrBasisForMeasurementCode;
		if (quantity > 0) 
			subject.Quantity = quantity;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

}
