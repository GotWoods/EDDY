using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v8020;

namespace Eddy.x12.Tests.Models.v8020;

public class BTSTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "BTS*g*7*7*3*a*3*9*1*tl*yu*ZA*v*GgXKCKci*T*7*89GZERYb";

		var expected = new BTS_BeginningSegmentForTrainSheets()
		{
			InterchangeTrainIdentification = "g",
			TotalEquipment = 7,
			EquipmentStatusCode = "7",
			TotalEquipment2 = 3,
			EquipmentStatusCode2 = "a",
			Weight = 3,
			Length = 9,
			Horsepower = 1,
			StandardCarrierAlphaCode = "tl",
			TransactionSetPurposeCode = "yu",
			ServiceLevelCode = "ZA",
			YesNoConditionOrResponseCode = "v",
			Date = "GgXKCKci",
			InterchangeTrainIdentification2 = "T",
			Number = 7,
			Date2 = "89GZERYb",
		};

		var actual = Map.MapObject<BTS_BeginningSegmentForTrainSheets>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("g", true)]
	public void Validation_RequiredInterchangeTrainIdentification(string interchangeTrainIdentification, bool isValidExpected)
	{
		var subject = new BTS_BeginningSegmentForTrainSheets();
		//Required fields
		//Test Parameters
		subject.InterchangeTrainIdentification = interchangeTrainIdentification;
		//If one filled, all required
		if(subject.TotalEquipment > 0 || subject.TotalEquipment > 0 || !string.IsNullOrEmpty(subject.EquipmentStatusCode))
		{
			subject.TotalEquipment = 7;
			subject.EquipmentStatusCode = "7";
		}
		if(subject.TotalEquipment2 > 0 || subject.TotalEquipment2 > 0 || !string.IsNullOrEmpty(subject.EquipmentStatusCode2))
		{
			subject.TotalEquipment2 = 3;
			subject.EquipmentStatusCode2 = "a";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData(0, "", true)]
	[InlineData(7, "7", true)]
	[InlineData(7, "", false)]
	[InlineData(0, "7", false)]
	public void Validation_AllAreRequiredTotalEquipment(int totalEquipment, string equipmentStatusCode, bool isValidExpected)
	{
		var subject = new BTS_BeginningSegmentForTrainSheets();
		//Required fields
		subject.InterchangeTrainIdentification = "g";
		//Test Parameters
		if (totalEquipment > 0) 
			subject.TotalEquipment = totalEquipment;
		subject.EquipmentStatusCode = equipmentStatusCode;
		//If one filled, all required
		if(subject.TotalEquipment2 > 0 || subject.TotalEquipment2 > 0 || !string.IsNullOrEmpty(subject.EquipmentStatusCode2))
		{
			subject.TotalEquipment2 = 3;
			subject.EquipmentStatusCode2 = "a";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

	[Theory]
	[InlineData(0, "", true)]
	[InlineData(3, "a", true)]
	[InlineData(3, "", false)]
	[InlineData(0, "a", false)]
	public void Validation_AllAreRequiredTotalEquipment2(int totalEquipment2, string equipmentStatusCode2, bool isValidExpected)
	{
		var subject = new BTS_BeginningSegmentForTrainSheets();
		//Required fields
		subject.InterchangeTrainIdentification = "g";
		//Test Parameters
		if (totalEquipment2 > 0) 
			subject.TotalEquipment2 = totalEquipment2;
		subject.EquipmentStatusCode2 = equipmentStatusCode2;
		//If one filled, all required
		if(subject.TotalEquipment > 0 || subject.TotalEquipment > 0 || !string.IsNullOrEmpty(subject.EquipmentStatusCode))
		{
			subject.TotalEquipment = 7;
			subject.EquipmentStatusCode = "7";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

}
