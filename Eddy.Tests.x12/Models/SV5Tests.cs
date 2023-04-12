using Eddy.Core.Validation;
using Eddy.x12.Mapping;
using Eddy.x12.Models;
using Eddy.x12.Models.Elements;

namespace Eddy.Tests.x12.Models;

public class SV5Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "SV5**NE*8*8*6*D*9";

		var expected = new SV5_DurableMedicalEquipmentService()
		{
			CompositeMedicalProcedureIdentifier = "",
			UnitOrBasisForMeasurementCode = "NE",
			Quantity = 8,
			MonetaryAmount = 8,
			MonetaryAmount2 = 6,
			FrequencyCode = "D",
			PrognosisCode = "9",
		};

		var actual = Map.MapObject<SV5_DurableMedicalEquipmentService>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("", true)]
	public void Validation_RequiredCompositeMedicalProcedureIdentifier(C003_CompositeMedicalProcedureIdentifier compositeMedicalProcedureIdentifier, bool isValidExpected)
	{
		var subject = new SV5_DurableMedicalEquipmentService();
		subject.UnitOrBasisForMeasurementCode = "NE";
		subject.Quantity = 8;
		subject.CompositeMedicalProcedureIdentifier = compositeMedicalProcedureIdentifier;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("NE", true)]
	public void Validation_RequiredUnitOrBasisForMeasurementCode(string unitOrBasisForMeasurementCode, bool isValidExpected)
	{
		var subject = new SV5_DurableMedicalEquipmentService();
		subject.CompositeMedicalProcedureIdentifier = "";
		subject.Quantity = 8;
		subject.UnitOrBasisForMeasurementCode = unitOrBasisForMeasurementCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData(0, false)]
	[InlineData(8, true)]
	public void Validation_RequiredQuantity(decimal quantity, bool isValidExpected)
	{
		var subject = new SV5_DurableMedicalEquipmentService();
		subject.CompositeMedicalProcedureIdentifier = "";
		subject.UnitOrBasisForMeasurementCode = "NE";
		if (quantity > 0)
		subject.Quantity = quantity;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData(0,0, false)]
	[InlineData(8,6, true)]
	[InlineData(0, 6, true)]
	[InlineData(8, 0, true)]
	public void Validation_AtLeastOneMonetaryAmount(decimal monetaryAmount, decimal monetaryAmount2, bool isValidExpected)
	{
		var subject = new SV5_DurableMedicalEquipmentService();
		subject.CompositeMedicalProcedureIdentifier = "";
		subject.UnitOrBasisForMeasurementCode = "NE";
		subject.Quantity = 8;
		if (monetaryAmount > 0)
		subject.MonetaryAmount = monetaryAmount;
		if (monetaryAmount2 > 0)
		subject.MonetaryAmount2 = monetaryAmount2;

		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.AtLeastOneIsRequired);
	}

	[Theory]
	[InlineData("", 0, true)]
	[InlineData("", 8, true)]
	[InlineData("D", 0, false)]
	public void Validation_ARequiresBFrequencyCode(string frequencyCode, decimal monetaryAmount, bool isValidExpected)
	{
		var subject = new SV5_DurableMedicalEquipmentService();
		subject.CompositeMedicalProcedureIdentifier = "";
		subject.UnitOrBasisForMeasurementCode = "NE";
		subject.Quantity = 8;
		subject.FrequencyCode = frequencyCode;
		if (monetaryAmount > 0)
		subject.MonetaryAmount = monetaryAmount;

		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
	}

}
