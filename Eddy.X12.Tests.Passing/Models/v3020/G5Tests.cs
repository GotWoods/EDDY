using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3020;

namespace Eddy.x12.Tests.Models.v3020;

public class G5Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "G5*C*t*9*t4rnrf*3*i*243*W*75*J*1*5w*z*d*Pd*K*7I6E4U";

		var expected = new G5_ScaleInformationSegment()
		{
			EquipmentInitial = "C",
			EquipmentNumber = "t",
			WaybillNumber = 9,
			Date = "t4rnrf",
			Weight = 3,
			WeightQualifier = "i",
			TareWeight = 243,
			TareQualifierCode = "W",
			WeightAllowance = 75,
			WeightAllowanceTypeCode = "J",
			FreightRate = 1,
			RateValueQualifier = "5w",
			InterchangeTrainIdentification = "z",
			CommodityCode = "d",
			ReferenceNumberQualifier = "Pd",
			ReferenceNumber = "K",
			Date2 = "7I6E4U",
		};

		var actual = Map.MapObject<G5_ScaleInformationSegment>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("C", true)]
	public void Validation_RequiredEquipmentInitial(string equipmentInitial, bool isValidExpected)
	{
		var subject = new G5_ScaleInformationSegment();
		subject.EquipmentNumber = "t";
		subject.Weight = 3;
		subject.WeightQualifier = "i";
		subject.EquipmentInitial = equipmentInitial;
		//If one is filled, all are required
		if(subject.WaybillNumber > 0 || subject.WaybillNumber > 0 || !string.IsNullOrEmpty(subject.Date))
		{
			subject.WaybillNumber = 9;
			subject.Date = "t4rnrf";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("t", true)]
	public void Validation_RequiredEquipmentNumber(string equipmentNumber, bool isValidExpected)
	{
		var subject = new G5_ScaleInformationSegment();
		subject.EquipmentInitial = "C";
		subject.Weight = 3;
		subject.WeightQualifier = "i";
		subject.EquipmentNumber = equipmentNumber;
		//If one is filled, all are required
		if(subject.WaybillNumber > 0 || subject.WaybillNumber > 0 || !string.IsNullOrEmpty(subject.Date))
		{
			subject.WaybillNumber = 9;
			subject.Date = "t4rnrf";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData(0, "", true)]
	[InlineData(9, "t4rnrf", true)]
	[InlineData(9, "", false)]
	[InlineData(0, "t4rnrf", false)]
	public void Validation_AllAreRequiredWaybillNumber(int waybillNumber, string date, bool isValidExpected)
	{
		var subject = new G5_ScaleInformationSegment();
		subject.EquipmentInitial = "C";
		subject.EquipmentNumber = "t";
		subject.Weight = 3;
		subject.WeightQualifier = "i";
		if (waybillNumber > 0)
			subject.WaybillNumber = waybillNumber;
		subject.Date = date;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

	[Theory]
	[InlineData(0, false)]
	[InlineData(3, true)]
	public void Validation_RequiredWeight(decimal weight, bool isValidExpected)
	{
		var subject = new G5_ScaleInformationSegment();
		subject.EquipmentInitial = "C";
		subject.EquipmentNumber = "t";
		subject.WeightQualifier = "i";
		if (weight > 0)
			subject.Weight = weight;
		//If one is filled, all are required
		if(subject.WaybillNumber > 0 || subject.WaybillNumber > 0 || !string.IsNullOrEmpty(subject.Date))
		{
			subject.WaybillNumber = 9;
			subject.Date = "t4rnrf";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("i", true)]
	public void Validation_RequiredWeightQualifier(string weightQualifier, bool isValidExpected)
	{
		var subject = new G5_ScaleInformationSegment();
		subject.EquipmentInitial = "C";
		subject.EquipmentNumber = "t";
		subject.Weight = 3;
		subject.WeightQualifier = weightQualifier;
		//If one is filled, all are required
		if(subject.WaybillNumber > 0 || subject.WaybillNumber > 0 || !string.IsNullOrEmpty(subject.Date))
		{
			subject.WaybillNumber = 9;
			subject.Date = "t4rnrf";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
