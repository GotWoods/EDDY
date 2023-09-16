using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3050;

namespace Eddy.x12.Tests.Models.v3050;

public class TD3Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "TD3*Xv*v*X*4*4*L8*T*gb*mB";

		var expected = new TD3_CarrierDetailsEquipment()
		{
			EquipmentDescriptionCode = "Xv",
			EquipmentInitial = "v",
			EquipmentNumber = "X",
			WeightQualifier = "4",
			Weight = 4,
			UnitOrBasisForMeasurementCode = "L8",
			OwnershipCode = "T",
			SealStatusCode = "gb",
			SealNumber = "mB",
		};

		var actual = Map.MapObject<TD3_CarrierDetailsEquipment>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("Xv", true)]
	public void Validation_RequiredEquipmentDescriptionCode(string equipmentDescriptionCode, bool isValidExpected)
	{
		var subject = new TD3_CarrierDetailsEquipment();
		subject.EquipmentDescriptionCode = equipmentDescriptionCode;
		//If one is filled, all are required
		if(subject.Weight > 0 || subject.Weight > 0 || !string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode))
		{
			subject.Weight = 4;
			subject.UnitOrBasisForMeasurementCode = "L8";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("v", "X", true)]
	[InlineData("v", "", false)]
	[InlineData("", "X", true)]
	public void Validation_ARequiresBEquipmentInitial(string equipmentInitial, string equipmentNumber, bool isValidExpected)
	{
		var subject = new TD3_CarrierDetailsEquipment();
		subject.EquipmentDescriptionCode = "Xv";
		subject.EquipmentInitial = equipmentInitial;
		subject.EquipmentNumber = equipmentNumber;
		//If one is filled, all are required
		if(subject.Weight > 0 || subject.Weight > 0 || !string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode))
		{
			subject.Weight = 4;
			subject.UnitOrBasisForMeasurementCode = "L8";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
	}

	[Theory]
	[InlineData("", 0, true)]
	[InlineData("4", 4, true)]
	[InlineData("4", 0, false)]
	[InlineData("", 4, true)]
	public void Validation_ARequiresBWeightQualifier(string weightQualifier, decimal weight, bool isValidExpected)
	{
		var subject = new TD3_CarrierDetailsEquipment();
		subject.EquipmentDescriptionCode = "Xv";
		subject.WeightQualifier = weightQualifier;
		if (weight > 0)
			subject.Weight = weight;
		//If one is filled, all are required
		if(subject.Weight > 0 || subject.Weight > 0 || !string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode))
		{
			subject.Weight = 4;
			subject.UnitOrBasisForMeasurementCode = "L8";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
	}

	[Theory]
	[InlineData(0, "", true)]
	[InlineData(4, "L8", true)]
	[InlineData(4, "", false)]
	[InlineData(0, "L8", false)]
	public void Validation_AllAreRequiredWeight(decimal weight, string unitOrBasisForMeasurementCode, bool isValidExpected)
	{
		var subject = new TD3_CarrierDetailsEquipment();
		subject.EquipmentDescriptionCode = "Xv";
		if (weight > 0)
			subject.Weight = weight;
		subject.UnitOrBasisForMeasurementCode = unitOrBasisForMeasurementCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

}
