using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v4010;

namespace Eddy.x12.Tests.Models.v4010;

public class SV5Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "SV5**xv*9*2*9*N*5";

		var expected = new SV5_DurableMedicalEquipmentService()
		{
			CompositeMedicalProcedureIdentifier = null,
			UnitOrBasisForMeasurementCode = "xv",
			Quantity = 9,
			MonetaryAmount = 2,
			MonetaryAmount2 = 9,
			FrequencyCode = "N",
			PrognosisCode = "5",
		};

		var actual = Map.MapObject<SV5_DurableMedicalEquipmentService>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("A", true)]
	public void Validation_RequiredCompositeMedicalProcedureIdentifier(string compositeMedicalProcedureIdentifier, bool isValidExpected)
	{
		var subject = new SV5_DurableMedicalEquipmentService();
		//Required fields
		subject.UnitOrBasisForMeasurementCode = "xv";
		subject.Quantity = 9;
		//Test Parameters
		if (compositeMedicalProcedureIdentifier != "") 
			subject.CompositeMedicalProcedureIdentifier = new C003_CompositeMedicalProcedureIdentifier();
		//At Least one
		subject.MonetaryAmount = 2;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("xv", true)]
	public void Validation_RequiredUnitOrBasisForMeasurementCode(string unitOrBasisForMeasurementCode, bool isValidExpected)
	{
		var subject = new SV5_DurableMedicalEquipmentService();
		//Required fields
		subject.CompositeMedicalProcedureIdentifier = new C003_CompositeMedicalProcedureIdentifier();
		subject.Quantity = 9;
		//Test Parameters
		subject.UnitOrBasisForMeasurementCode = unitOrBasisForMeasurementCode;
		//At Least one
		subject.MonetaryAmount = 2;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData(0, false)]
	[InlineData(9, true)]
	public void Validation_RequiredQuantity(decimal quantity, bool isValidExpected)
	{
		var subject = new SV5_DurableMedicalEquipmentService();
		//Required fields
		subject.CompositeMedicalProcedureIdentifier = new C003_CompositeMedicalProcedureIdentifier();
		subject.UnitOrBasisForMeasurementCode = "xv";
		//Test Parameters
		if (quantity > 0) 
			subject.Quantity = quantity;
		//At Least one
		subject.MonetaryAmount = 2;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData(0, 0, false)]
	[InlineData(2, 9, true)]
	[InlineData(2, 0, true)]
	[InlineData(0, 9, true)]
	public void Validation_AtLeastOneMonetaryAmount(decimal monetaryAmount, decimal monetaryAmount2, bool isValidExpected)
	{
		var subject = new SV5_DurableMedicalEquipmentService();
		//Required fields
		subject.CompositeMedicalProcedureIdentifier = new C003_CompositeMedicalProcedureIdentifier();
		subject.UnitOrBasisForMeasurementCode = "xv";
		subject.Quantity = 9;
		//Test Parameters
		if (monetaryAmount > 0) 
			subject.MonetaryAmount = monetaryAmount;
		if (monetaryAmount2 > 0) 
			subject.MonetaryAmount2 = monetaryAmount2;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.AtLeastOneIsRequired);
	}

	[Theory]
	[InlineData("", 0, true)]
	[InlineData("N", 2, true)]
	[InlineData("N", 0, false)]
	[InlineData("", 2, true)]
	public void Validation_ARequiresBFrequencyCode(string frequencyCode, decimal monetaryAmount, bool isValidExpected)
	{
		var subject = new SV5_DurableMedicalEquipmentService();
		//Required fields
		subject.CompositeMedicalProcedureIdentifier = new C003_CompositeMedicalProcedureIdentifier();
		subject.UnitOrBasisForMeasurementCode = "xv";
		subject.Quantity = 9;
		//Test Parameters
		subject.FrequencyCode = frequencyCode;
		if (monetaryAmount > 0) 
			subject.MonetaryAmount = monetaryAmount;
		//At Least one
		subject.MonetaryAmount2 = 9;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
	}

}
