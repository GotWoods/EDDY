using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3060;

namespace Eddy.x12.Tests.Models.v3060;

public class BTSTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "BTS*l*4*L*8*B*9*6*7*gN*rl*fr*n";

		var expected = new BTS_BeginningSegmentForTrainSheets()
		{
			InterchangeTrainIdentification = "l",
			TotalEquipment = 4,
			EquipmentStatusCode = "L",
			TotalEquipment2 = 8,
			EquipmentStatusCode2 = "B",
			Weight = 9,
			Length = 6,
			Horsepower = 7,
			StandardCarrierAlphaCode = "gN",
			TransactionSetPurposeCode = "rl",
			ServiceLevelCode = "fr",
			YesNoConditionOrResponseCode = "n",
		};

		var actual = Map.MapObject<BTS_BeginningSegmentForTrainSheets>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("l", true)]
	public void Validation_RequiredInterchangeTrainIdentification(string interchangeTrainIdentification, bool isValidExpected)
	{
		var subject = new BTS_BeginningSegmentForTrainSheets();
		//Required fields
		subject.TotalEquipment = 4;
		subject.EquipmentStatusCode = "L";
		subject.TotalEquipment2 = 8;
		subject.EquipmentStatusCode2 = "B";
		subject.Weight = 9;
		subject.Length = 6;
		subject.Horsepower = 7;
		subject.StandardCarrierAlphaCode = "gN";
		subject.TransactionSetPurposeCode = "rl";
		//Test Parameters
		subject.InterchangeTrainIdentification = interchangeTrainIdentification;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData(0, false)]
	[InlineData(4, true)]
	public void Validation_RequiredTotalEquipment(int totalEquipment, bool isValidExpected)
	{
		var subject = new BTS_BeginningSegmentForTrainSheets();
		//Required fields
		subject.InterchangeTrainIdentification = "l";
		subject.EquipmentStatusCode = "L";
		subject.TotalEquipment2 = 8;
		subject.EquipmentStatusCode2 = "B";
		subject.Weight = 9;
		subject.Length = 6;
		subject.Horsepower = 7;
		subject.StandardCarrierAlphaCode = "gN";
		subject.TransactionSetPurposeCode = "rl";
		//Test Parameters
		if (totalEquipment > 0) 
			subject.TotalEquipment = totalEquipment;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("L", true)]
	public void Validation_RequiredEquipmentStatusCode(string equipmentStatusCode, bool isValidExpected)
	{
		var subject = new BTS_BeginningSegmentForTrainSheets();
		//Required fields
		subject.InterchangeTrainIdentification = "l";
		subject.TotalEquipment = 4;
		subject.TotalEquipment2 = 8;
		subject.EquipmentStatusCode2 = "B";
		subject.Weight = 9;
		subject.Length = 6;
		subject.Horsepower = 7;
		subject.StandardCarrierAlphaCode = "gN";
		subject.TransactionSetPurposeCode = "rl";
		//Test Parameters
		subject.EquipmentStatusCode = equipmentStatusCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData(0, false)]
	[InlineData(8, true)]
	public void Validation_RequiredTotalEquipment2(int totalEquipment2, bool isValidExpected)
	{
		var subject = new BTS_BeginningSegmentForTrainSheets();
		//Required fields
		subject.InterchangeTrainIdentification = "l";
		subject.TotalEquipment = 4;
		subject.EquipmentStatusCode = "L";
		subject.EquipmentStatusCode2 = "B";
		subject.Weight = 9;
		subject.Length = 6;
		subject.Horsepower = 7;
		subject.StandardCarrierAlphaCode = "gN";
		subject.TransactionSetPurposeCode = "rl";
		//Test Parameters
		if (totalEquipment2 > 0) 
			subject.TotalEquipment2 = totalEquipment2;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("B", true)]
	public void Validation_RequiredEquipmentStatusCode2(string equipmentStatusCode2, bool isValidExpected)
	{
		var subject = new BTS_BeginningSegmentForTrainSheets();
		//Required fields
		subject.InterchangeTrainIdentification = "l";
		subject.TotalEquipment = 4;
		subject.EquipmentStatusCode = "L";
		subject.TotalEquipment2 = 8;
		subject.Weight = 9;
		subject.Length = 6;
		subject.Horsepower = 7;
		subject.StandardCarrierAlphaCode = "gN";
		subject.TransactionSetPurposeCode = "rl";
		//Test Parameters
		subject.EquipmentStatusCode2 = equipmentStatusCode2;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData(0, false)]
	[InlineData(9, true)]
	public void Validation_RequiredWeight(decimal weight, bool isValidExpected)
	{
		var subject = new BTS_BeginningSegmentForTrainSheets();
		//Required fields
		subject.InterchangeTrainIdentification = "l";
		subject.TotalEquipment = 4;
		subject.EquipmentStatusCode = "L";
		subject.TotalEquipment2 = 8;
		subject.EquipmentStatusCode2 = "B";
		subject.Length = 6;
		subject.Horsepower = 7;
		subject.StandardCarrierAlphaCode = "gN";
		subject.TransactionSetPurposeCode = "rl";
		//Test Parameters
		if (weight > 0) 
			subject.Weight = weight;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData(0, false)]
	[InlineData(6, true)]
	public void Validation_RequiredLength(decimal length, bool isValidExpected)
	{
		var subject = new BTS_BeginningSegmentForTrainSheets();
		//Required fields
		subject.InterchangeTrainIdentification = "l";
		subject.TotalEquipment = 4;
		subject.EquipmentStatusCode = "L";
		subject.TotalEquipment2 = 8;
		subject.EquipmentStatusCode2 = "B";
		subject.Weight = 9;
		subject.Horsepower = 7;
		subject.StandardCarrierAlphaCode = "gN";
		subject.TransactionSetPurposeCode = "rl";
		//Test Parameters
		if (length > 0) 
			subject.Length = length;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData(0, false)]
	[InlineData(7, true)]
	public void Validation_RequiredHorsepower(int horsepower, bool isValidExpected)
	{
		var subject = new BTS_BeginningSegmentForTrainSheets();
		//Required fields
		subject.InterchangeTrainIdentification = "l";
		subject.TotalEquipment = 4;
		subject.EquipmentStatusCode = "L";
		subject.TotalEquipment2 = 8;
		subject.EquipmentStatusCode2 = "B";
		subject.Weight = 9;
		subject.Length = 6;
		subject.StandardCarrierAlphaCode = "gN";
		subject.TransactionSetPurposeCode = "rl";
		//Test Parameters
		if (horsepower > 0) 
			subject.Horsepower = horsepower;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("gN", true)]
	public void Validation_RequiredStandardCarrierAlphaCode(string standardCarrierAlphaCode, bool isValidExpected)
	{
		var subject = new BTS_BeginningSegmentForTrainSheets();
		//Required fields
		subject.InterchangeTrainIdentification = "l";
		subject.TotalEquipment = 4;
		subject.EquipmentStatusCode = "L";
		subject.TotalEquipment2 = 8;
		subject.EquipmentStatusCode2 = "B";
		subject.Weight = 9;
		subject.Length = 6;
		subject.Horsepower = 7;
		subject.TransactionSetPurposeCode = "rl";
		//Test Parameters
		subject.StandardCarrierAlphaCode = standardCarrierAlphaCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("rl", true)]
	public void Validation_RequiredTransactionSetPurposeCode(string transactionSetPurposeCode, bool isValidExpected)
	{
		var subject = new BTS_BeginningSegmentForTrainSheets();
		//Required fields
		subject.InterchangeTrainIdentification = "l";
		subject.TotalEquipment = 4;
		subject.EquipmentStatusCode = "L";
		subject.TotalEquipment2 = 8;
		subject.EquipmentStatusCode2 = "B";
		subject.Weight = 9;
		subject.Length = 6;
		subject.Horsepower = 7;
		subject.StandardCarrierAlphaCode = "gN";
		//Test Parameters
		subject.TransactionSetPurposeCode = transactionSetPurposeCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
