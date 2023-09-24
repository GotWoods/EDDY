using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3050;

namespace Eddy.x12.Tests.Models.v3050;

public class G5Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "G5*O*u*3*8sjP8S*5*H*917*H*84*S*5*2M*q*r*Jp*d*ViiqCE";

		var expected = new G5_WeightInformation()
		{
			EquipmentInitial = "O",
			EquipmentNumber = "u",
			WaybillNumber = 3,
			Date = "8sjP8S",
			Weight = 5,
			WeightQualifier = "H",
			TareWeight = 917,
			TareQualifierCode = "H",
			WeightAllowance = 84,
			WeightAllowanceTypeCode = "S",
			FreightRate = 5,
			RateValueQualifier = "2M",
			InterchangeTrainIdentification = "q",
			CommodityCode = "r",
			ReferenceNumberQualifier = "Jp",
			ReferenceNumber = "d",
			Date2 = "ViiqCE",
		};

		var actual = Map.MapObject<G5_WeightInformation>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("O", true)]
	public void Validation_RequiredEquipmentInitial(string equipmentInitial, bool isValidExpected)
	{
		var subject = new G5_WeightInformation();
		subject.EquipmentNumber = "u";
		subject.Weight = 5;
		subject.WeightQualifier = "H";
		subject.EquipmentInitial = equipmentInitial;
		//If one is filled, all are required
		if(subject.WaybillNumber > 0 || subject.WaybillNumber > 0 || !string.IsNullOrEmpty(subject.Date))
		{
			subject.WaybillNumber = 3;
			subject.Date = "8sjP8S";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("u", true)]
	public void Validation_RequiredEquipmentNumber(string equipmentNumber, bool isValidExpected)
	{
		var subject = new G5_WeightInformation();
		subject.EquipmentInitial = "O";
		subject.Weight = 5;
		subject.WeightQualifier = "H";
		subject.EquipmentNumber = equipmentNumber;
		//If one is filled, all are required
		if(subject.WaybillNumber > 0 || subject.WaybillNumber > 0 || !string.IsNullOrEmpty(subject.Date))
		{
			subject.WaybillNumber = 3;
			subject.Date = "8sjP8S";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData(0, "", true)]
	[InlineData(3, "8sjP8S", true)]
	[InlineData(3, "", false)]
	[InlineData(0, "8sjP8S", false)]
	public void Validation_AllAreRequiredWaybillNumber(int waybillNumber, string date, bool isValidExpected)
	{
		var subject = new G5_WeightInformation();
		subject.EquipmentInitial = "O";
		subject.EquipmentNumber = "u";
		subject.Weight = 5;
		subject.WeightQualifier = "H";
		if (waybillNumber > 0)
			subject.WaybillNumber = waybillNumber;
		subject.Date = date;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

	[Theory]
	[InlineData(0, false)]
	[InlineData(5, true)]
	public void Validation_RequiredWeight(decimal weight, bool isValidExpected)
	{
		var subject = new G5_WeightInformation();
		subject.EquipmentInitial = "O";
		subject.EquipmentNumber = "u";
		subject.WeightQualifier = "H";
		if (weight > 0)
			subject.Weight = weight;
		//If one is filled, all are required
		if(subject.WaybillNumber > 0 || subject.WaybillNumber > 0 || !string.IsNullOrEmpty(subject.Date))
		{
			subject.WaybillNumber = 3;
			subject.Date = "8sjP8S";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("H", true)]
	public void Validation_RequiredWeightQualifier(string weightQualifier, bool isValidExpected)
	{
		var subject = new G5_WeightInformation();
		subject.EquipmentInitial = "O";
		subject.EquipmentNumber = "u";
		subject.Weight = 5;
		subject.WeightQualifier = weightQualifier;
		//If one is filled, all are required
		if(subject.WaybillNumber > 0 || subject.WaybillNumber > 0 || !string.IsNullOrEmpty(subject.Date))
		{
			subject.WaybillNumber = 3;
			subject.Date = "8sjP8S";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
