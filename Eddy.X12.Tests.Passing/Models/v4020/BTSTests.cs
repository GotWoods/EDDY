using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v4020;

namespace Eddy.x12.Tests.Models.v4020;

public class BTSTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "BTS*U*4*b*5*J*3*1*8*SW*Td*N2*F";

		var expected = new BTS_BeginningSegmentForTrainSheets()
		{
			InterchangeTrainIdentification = "U",
			TotalEquipment = 4,
			EquipmentStatusCode = "b",
			TotalEquipment2 = 5,
			EquipmentStatusCode2 = "J",
			Weight = 3,
			Length = 1,
			Horsepower = 8,
			StandardCarrierAlphaCode = "SW",
			TransactionSetPurposeCode = "Td",
			ServiceLevelCode = "N2",
			YesNoConditionOrResponseCode = "F",
		};

		var actual = Map.MapObject<BTS_BeginningSegmentForTrainSheets>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("U", true)]
	public void Validation_RequiredInterchangeTrainIdentification(string interchangeTrainIdentification, bool isValidExpected)
	{
		var subject = new BTS_BeginningSegmentForTrainSheets();
		//Required fields
		//Test Parameters
		subject.InterchangeTrainIdentification = interchangeTrainIdentification;
		//If one filled, all required
		if(subject.TotalEquipment > 0 || subject.TotalEquipment > 0 || !string.IsNullOrEmpty(subject.EquipmentStatusCode))
		{
			subject.TotalEquipment = 4;
			subject.EquipmentStatusCode = "b";
		}
		if(subject.TotalEquipment2 > 0 || subject.TotalEquipment2 > 0 || !string.IsNullOrEmpty(subject.EquipmentStatusCode2))
		{
			subject.TotalEquipment2 = 5;
			subject.EquipmentStatusCode2 = "J";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData(0, "", true)]
	[InlineData(4, "b", true)]
	[InlineData(4, "", false)]
	[InlineData(0, "b", false)]
	public void Validation_AllAreRequiredTotalEquipment(int totalEquipment, string equipmentStatusCode, bool isValidExpected)
	{
		var subject = new BTS_BeginningSegmentForTrainSheets();
		//Required fields
		subject.InterchangeTrainIdentification = "U";
		//Test Parameters
		if (totalEquipment > 0) 
			subject.TotalEquipment = totalEquipment;
		subject.EquipmentStatusCode = equipmentStatusCode;
		//If one filled, all required
		if(subject.TotalEquipment2 > 0 || subject.TotalEquipment2 > 0 || !string.IsNullOrEmpty(subject.EquipmentStatusCode2))
		{
			subject.TotalEquipment2 = 5;
			subject.EquipmentStatusCode2 = "J";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

	[Theory]
	[InlineData(0, "", true)]
	[InlineData(5, "J", true)]
	[InlineData(5, "", false)]
	[InlineData(0, "J", false)]
	public void Validation_AllAreRequiredTotalEquipment2(int totalEquipment2, string equipmentStatusCode2, bool isValidExpected)
	{
		var subject = new BTS_BeginningSegmentForTrainSheets();
		//Required fields
		subject.InterchangeTrainIdentification = "U";
		//Test Parameters
		if (totalEquipment2 > 0) 
			subject.TotalEquipment2 = totalEquipment2;
		subject.EquipmentStatusCode2 = equipmentStatusCode2;
		//If one filled, all required
		if(subject.TotalEquipment > 0 || subject.TotalEquipment > 0 || !string.IsNullOrEmpty(subject.EquipmentStatusCode))
		{
			subject.TotalEquipment = 4;
			subject.EquipmentStatusCode = "b";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

}
