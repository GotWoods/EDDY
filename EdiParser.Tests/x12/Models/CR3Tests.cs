using EdiParser.Validation;
using EdiParser.x12.Mapping;
using EdiParser.x12.Models;

namespace EdiParser.Tests.x12.Models;

public class CR3Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "CR3*p*aK*1*B*Q";

		var expected = new CR3_DurableMedicalEquipmentCertification()
		{
			CertificationTypeCode = "p",
			UnitOrBasisForMeasurementCode = "aK",
			Quantity = 1,
			InsulinDependentCode = "B",
			Description = "Q",
		};

		var actual = Map.MapObject<CR3_DurableMedicalEquipmentCertification>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("",0, true)]
	[InlineData("aK", 1, true)]
	[InlineData("", 1, false)]
	[InlineData("aK", 0, false)]
	public void Validation_AllAreRequiredUnitOrBasisForMeasurementCode(string unitOrBasisForMeasurementCode, decimal quantity, bool isValidExpected)
	{
		var subject = new CR3_DurableMedicalEquipmentCertification();
		subject.UnitOrBasisForMeasurementCode = unitOrBasisForMeasurementCode;
		if (quantity > 0)
		subject.Quantity = quantity;

		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

}
