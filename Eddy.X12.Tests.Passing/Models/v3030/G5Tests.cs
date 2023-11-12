using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3030;

namespace Eddy.x12.Tests.Models.v3030;

public class G5Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "G5*q*Z*2*UGuQaJ*7*M*952*W*95*O*7*M5*i*L*VA*4*wor0N9";

		var expected = new G5_WeightInformation()
		{
			EquipmentInitial = "q",
			EquipmentNumber = "Z",
			WaybillNumber = 2,
			Date = "UGuQaJ",
			Weight = 7,
			WeightQualifier = "M",
			TareWeight = 952,
			TareQualifierCode = "W",
			WeightAllowance = 95,
			WeightAllowanceTypeCode = "O",
			FreightRate = 7,
			RateValueQualifier = "M5",
			InterchangeTrainIdentification = "i",
			CommodityCode = "L",
			ReferenceNumberQualifier = "VA",
			ReferenceNumber = "4",
			Date2 = "wor0N9",
		};

		var actual = Map.MapObject<G5_WeightInformation>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("q", true)]
	public void Validation_RequiredEquipmentInitial(string equipmentInitial, bool isValidExpected)
	{
		var subject = new G5_WeightInformation();
		subject.EquipmentNumber = "Z";
		subject.Weight = 7;
		subject.WeightQualifier = "M";
		subject.EquipmentInitial = equipmentInitial;
		//If one is filled, all are required
		if(subject.WaybillNumber > 0 || subject.WaybillNumber > 0 || !string.IsNullOrEmpty(subject.Date))
		{
			subject.WaybillNumber = 2;
			subject.Date = "UGuQaJ";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("Z", true)]
	public void Validation_RequiredEquipmentNumber(string equipmentNumber, bool isValidExpected)
	{
		var subject = new G5_WeightInformation();
		subject.EquipmentInitial = "q";
		subject.Weight = 7;
		subject.WeightQualifier = "M";
		subject.EquipmentNumber = equipmentNumber;
		//If one is filled, all are required
		if(subject.WaybillNumber > 0 || subject.WaybillNumber > 0 || !string.IsNullOrEmpty(subject.Date))
		{
			subject.WaybillNumber = 2;
			subject.Date = "UGuQaJ";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData(0, "", true)]
	[InlineData(2, "UGuQaJ", true)]
	[InlineData(2, "", false)]
	[InlineData(0, "UGuQaJ", false)]
	public void Validation_AllAreRequiredWaybillNumber(int waybillNumber, string date, bool isValidExpected)
	{
		var subject = new G5_WeightInformation();
		subject.EquipmentInitial = "q";
		subject.EquipmentNumber = "Z";
		subject.Weight = 7;
		subject.WeightQualifier = "M";
		if (waybillNumber > 0)
			subject.WaybillNumber = waybillNumber;
		subject.Date = date;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

	[Theory]
	[InlineData(0, false)]
	[InlineData(7, true)]
	public void Validation_RequiredWeight(decimal weight, bool isValidExpected)
	{
		var subject = new G5_WeightInformation();
		subject.EquipmentInitial = "q";
		subject.EquipmentNumber = "Z";
		subject.WeightQualifier = "M";
		if (weight > 0)
			subject.Weight = weight;
		//If one is filled, all are required
		if(subject.WaybillNumber > 0 || subject.WaybillNumber > 0 || !string.IsNullOrEmpty(subject.Date))
		{
			subject.WaybillNumber = 2;
			subject.Date = "UGuQaJ";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("M", true)]
	public void Validation_RequiredWeightQualifier(string weightQualifier, bool isValidExpected)
	{
		var subject = new G5_WeightInformation();
		subject.EquipmentInitial = "q";
		subject.EquipmentNumber = "Z";
		subject.Weight = 7;
		subject.WeightQualifier = weightQualifier;
		//If one is filled, all are required
		if(subject.WaybillNumber > 0 || subject.WaybillNumber > 0 || !string.IsNullOrEmpty(subject.Date))
		{
			subject.WaybillNumber = 2;
			subject.Date = "UGuQaJ";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
