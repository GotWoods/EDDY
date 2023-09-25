using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v4040;

namespace Eddy.x12.Tests.Models.v4040;

public class BTSTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "BTS*7*9*E*8*A*7*1*6*Y4*1m*42*T*ruTBRGCI*O*8";

		var expected = new BTS_BeginningSegmentForTrainSheets()
		{
			InterchangeTrainIdentification = "7",
			TotalEquipment = 9,
			EquipmentStatusCode = "E",
			TotalEquipment2 = 8,
			EquipmentStatusCode2 = "A",
			Weight = 7,
			Length = 1,
			Horsepower = 6,
			StandardCarrierAlphaCode = "Y4",
			TransactionSetPurposeCode = "1m",
			ServiceLevelCode = "42",
			YesNoConditionOrResponseCode = "T",
			Date = "ruTBRGCI",
			InterchangeTrainIdentification2 = "O",
			Number = 8,
		};

		var actual = Map.MapObject<BTS_BeginningSegmentForTrainSheets>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("7", true)]
	public void Validation_RequiredInterchangeTrainIdentification(string interchangeTrainIdentification, bool isValidExpected)
	{
		var subject = new BTS_BeginningSegmentForTrainSheets();
		//Required fields
		//Test Parameters
		subject.InterchangeTrainIdentification = interchangeTrainIdentification;
		//If one filled, all required
		if(subject.TotalEquipment > 0 || subject.TotalEquipment > 0 || !string.IsNullOrEmpty(subject.EquipmentStatusCode))
		{
			subject.TotalEquipment = 9;
			subject.EquipmentStatusCode = "E";
		}
		if(subject.TotalEquipment2 > 0 || subject.TotalEquipment2 > 0 || !string.IsNullOrEmpty(subject.EquipmentStatusCode2))
		{
			subject.TotalEquipment2 = 8;
			subject.EquipmentStatusCode2 = "A";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData(0, "", true)]
	[InlineData(9, "E", true)]
	[InlineData(9, "", false)]
	[InlineData(0, "E", false)]
	public void Validation_AllAreRequiredTotalEquipment(int totalEquipment, string equipmentStatusCode, bool isValidExpected)
	{
		var subject = new BTS_BeginningSegmentForTrainSheets();
		//Required fields
		subject.InterchangeTrainIdentification = "7";
		//Test Parameters
		if (totalEquipment > 0) 
			subject.TotalEquipment = totalEquipment;
		subject.EquipmentStatusCode = equipmentStatusCode;
		//If one filled, all required
		if(subject.TotalEquipment2 > 0 || subject.TotalEquipment2 > 0 || !string.IsNullOrEmpty(subject.EquipmentStatusCode2))
		{
			subject.TotalEquipment2 = 8;
			subject.EquipmentStatusCode2 = "A";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

	[Theory]
	[InlineData(0, "", true)]
	[InlineData(8, "A", true)]
	[InlineData(8, "", false)]
	[InlineData(0, "A", false)]
	public void Validation_AllAreRequiredTotalEquipment2(int totalEquipment2, string equipmentStatusCode2, bool isValidExpected)
	{
		var subject = new BTS_BeginningSegmentForTrainSheets();
		//Required fields
		subject.InterchangeTrainIdentification = "7";
		//Test Parameters
		if (totalEquipment2 > 0) 
			subject.TotalEquipment2 = totalEquipment2;
		subject.EquipmentStatusCode2 = equipmentStatusCode2;
		//If one filled, all required
		if(subject.TotalEquipment > 0 || subject.TotalEquipment > 0 || !string.IsNullOrEmpty(subject.EquipmentStatusCode))
		{
			subject.TotalEquipment = 9;
			subject.EquipmentStatusCode = "E";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

}
