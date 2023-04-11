using Eddy.Core.Validation;
using Eddy.x12.Mapping;
using Eddy.x12.Models;

namespace Eddy.Tests.x12.Models;

public class G5Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "G5*u*z*9*Z79zeWYv*6*x*422*E*22*C*4*Eo*H*f*CS*v*rvGkwae2";

		var expected = new G5_ScaleInformation()
		{
			EquipmentInitial = "u",
			EquipmentNumber = "z",
			WaybillNumber = 9,
			Date = "Z79zeWYv",
			Weight = 6,
			WeightQualifier = "x",
			TareWeight = 422,
			TareQualifierCode = "E",
			WeightAllowance = 22,
			WeightAllowanceTypeCode = "C",
			FreightRate = 4,
			RateValueQualifier = "Eo",
			InterchangeTrainIdentification = "H",
			CommodityCode = "f",
			ReferenceIdentificationQualifier = "CS",
			ReferenceIdentification = "v",
			Date2 = "rvGkwae2",
		};

		var actual = Map.MapObject<G5_ScaleInformation>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("u", true)]
	public void Validation_RequiredEquipmentInitial(string equipmentInitial, bool isValidExpected)
	{
		var subject = new G5_ScaleInformation();
		subject.EquipmentNumber = "z";
		subject.Weight = 6;
		subject.WeightQualifier = "x";
		subject.EquipmentInitial = equipmentInitial;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("z", true)]
	public void Validation_RequiredEquipmentNumber(string equipmentNumber, bool isValidExpected)
	{
		var subject = new G5_ScaleInformation();
		subject.EquipmentInitial = "u";
		subject.Weight = 6;
		subject.WeightQualifier = "x";
		subject.EquipmentNumber = equipmentNumber;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData(0,"", true)]
	[InlineData(9, "Z79zeWYv", true)]
	[InlineData(0, "Z79zeWYv", false)]
	[InlineData(9, "", false)]
	public void Validation_AllAreRequiredWaybillNumber(int waybillNumber, string date, bool isValidExpected)
	{
		var subject = new G5_ScaleInformation();
		subject.EquipmentInitial = "u";
		subject.EquipmentNumber = "z";
		subject.Weight = 6;
		subject.WeightQualifier = "x";
		if (waybillNumber > 0)
		subject.WaybillNumber = waybillNumber;
		subject.Date = date;

		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

	[Theory]
	[InlineData(0, false)]
	[InlineData(6, true)]
	public void Validation_RequiredWeight(decimal weight, bool isValidExpected)
	{
		var subject = new G5_ScaleInformation();
		subject.EquipmentInitial = "u";
		subject.EquipmentNumber = "z";
		subject.WeightQualifier = "x";
		if (weight > 0)
		subject.Weight = weight;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("x", true)]
	public void Validation_RequiredWeightQualifier(string weightQualifier, bool isValidExpected)
	{
		var subject = new G5_ScaleInformation();
		subject.EquipmentInitial = "u";
		subject.EquipmentNumber = "z";
		subject.Weight = 6;
		subject.WeightQualifier = weightQualifier;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData(0,"", true)]
	[InlineData(422, "E", true)]
	[InlineData(0, "E", false)]
	[InlineData(422, "", false)]
	public void Validation_AllAreRequiredTareWeight(int tareWeight, string tareQualifierCode, bool isValidExpected)
	{
		var subject = new G5_ScaleInformation();
		subject.EquipmentInitial = "u";
		subject.EquipmentNumber = "z";
		subject.Weight = 6;
		subject.WeightQualifier = "x";
		if (tareWeight > 0)
		subject.TareWeight = tareWeight;
		subject.TareQualifierCode = tareQualifierCode;

		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

	[Theory]
	[InlineData(0,"", true)]
	[InlineData(22, "C", true)]
	[InlineData(0, "C", false)]
	[InlineData(22, "", false)]
	public void Validation_AllAreRequiredWeightAllowance(int weightAllowance, string weightAllowanceTypeCode, bool isValidExpected)
	{
		var subject = new G5_ScaleInformation();
		subject.EquipmentInitial = "u";
		subject.EquipmentNumber = "z";
		subject.Weight = 6;
		subject.WeightQualifier = "x";
		if (weightAllowance > 0)
		subject.WeightAllowance = weightAllowance;
		subject.WeightAllowanceTypeCode = weightAllowanceTypeCode;

		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

	[Theory]
	[InlineData(0,"", true)]
	[InlineData(4, "Eo", true)]
	[InlineData(0, "Eo", false)]
	[InlineData(4, "", false)]
	public void Validation_AllAreRequiredFreightRate(decimal freightRate, string rateValueQualifier, bool isValidExpected)
	{
		var subject = new G5_ScaleInformation();
		subject.EquipmentInitial = "u";
		subject.EquipmentNumber = "z";
		subject.Weight = 6;
		subject.WeightQualifier = "x";
		if (freightRate > 0)
		subject.FreightRate = freightRate;
		subject.RateValueQualifier = rateValueQualifier;

		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

	[Theory]
	[InlineData("","", true)]
	[InlineData("CS", "v", true)]
	[InlineData("", "v", false)]
	[InlineData("CS", "", false)]
	public void Validation_AllAreRequiredReferenceIdentificationQualifier(string referenceIdentificationQualifier, string referenceIdentification, bool isValidExpected)
	{
		var subject = new G5_ScaleInformation();
		subject.EquipmentInitial = "u";
		subject.EquipmentNumber = "z";
		subject.Weight = 6;
		subject.WeightQualifier = "x";
		subject.ReferenceIdentificationQualifier = referenceIdentificationQualifier;
		subject.ReferenceIdentification = referenceIdentification;

		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

}
