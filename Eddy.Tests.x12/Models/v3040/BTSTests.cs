using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3040;

namespace Eddy.x12.Tests.Models.v3040;

public class BTSTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "BTS*r*7*6*2*z*1*7*2";

		var expected = new BTS_BeginningSegmentForTrainSheets()
		{
			InterchangeTrainIdentification = "r",
			TotalEquipment = 7,
			EquipmentStatusCode = "6",
			TotalEquipment2 = 2,
			EquipmentStatusCode2 = "z",
			Weight = 1,
			Length = 7,
			Horsepower = 2,
		};

		var actual = Map.MapObject<BTS_BeginningSegmentForTrainSheets>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("r", true)]
	public void Validation_RequiredInterchangeTrainIdentification(string interchangeTrainIdentification, bool isValidExpected)
	{
		var subject = new BTS_BeginningSegmentForTrainSheets();
		//Required fields
		subject.TotalEquipment = 7;
		subject.EquipmentStatusCode = "6";
		subject.TotalEquipment2 = 2;
		subject.EquipmentStatusCode2 = "z";
		subject.Weight = 1;
		subject.Length = 7;
		subject.Horsepower = 2;
		//Test Parameters
		subject.InterchangeTrainIdentification = interchangeTrainIdentification;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData(0, false)]
	[InlineData(7, true)]
	public void Validation_RequiredTotalEquipment(int totalEquipment, bool isValidExpected)
	{
		var subject = new BTS_BeginningSegmentForTrainSheets();
		//Required fields
		subject.InterchangeTrainIdentification = "r";
		subject.EquipmentStatusCode = "6";
		subject.TotalEquipment2 = 2;
		subject.EquipmentStatusCode2 = "z";
		subject.Weight = 1;
		subject.Length = 7;
		subject.Horsepower = 2;
		//Test Parameters
		if (totalEquipment > 0) 
			subject.TotalEquipment = totalEquipment;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("6", true)]
	public void Validation_RequiredEquipmentStatusCode(string equipmentStatusCode, bool isValidExpected)
	{
		var subject = new BTS_BeginningSegmentForTrainSheets();
		//Required fields
		subject.InterchangeTrainIdentification = "r";
		subject.TotalEquipment = 7;
		subject.TotalEquipment2 = 2;
		subject.EquipmentStatusCode2 = "z";
		subject.Weight = 1;
		subject.Length = 7;
		subject.Horsepower = 2;
		//Test Parameters
		subject.EquipmentStatusCode = equipmentStatusCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData(0, false)]
	[InlineData(2, true)]
	public void Validation_RequiredTotalEquipment2(int totalEquipment2, bool isValidExpected)
	{
		var subject = new BTS_BeginningSegmentForTrainSheets();
		//Required fields
		subject.InterchangeTrainIdentification = "r";
		subject.TotalEquipment = 7;
		subject.EquipmentStatusCode = "6";
		subject.EquipmentStatusCode2 = "z";
		subject.Weight = 1;
		subject.Length = 7;
		subject.Horsepower = 2;
		//Test Parameters
		if (totalEquipment2 > 0) 
			subject.TotalEquipment2 = totalEquipment2;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("z", true)]
	public void Validation_RequiredEquipmentStatusCode2(string equipmentStatusCode2, bool isValidExpected)
	{
		var subject = new BTS_BeginningSegmentForTrainSheets();
		//Required fields
		subject.InterchangeTrainIdentification = "r";
		subject.TotalEquipment = 7;
		subject.EquipmentStatusCode = "6";
		subject.TotalEquipment2 = 2;
		subject.Weight = 1;
		subject.Length = 7;
		subject.Horsepower = 2;
		//Test Parameters
		subject.EquipmentStatusCode2 = equipmentStatusCode2;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData(0, false)]
	[InlineData(1, true)]
	public void Validation_RequiredWeight(decimal weight, bool isValidExpected)
	{
		var subject = new BTS_BeginningSegmentForTrainSheets();
		//Required fields
		subject.InterchangeTrainIdentification = "r";
		subject.TotalEquipment = 7;
		subject.EquipmentStatusCode = "6";
		subject.TotalEquipment2 = 2;
		subject.EquipmentStatusCode2 = "z";
		subject.Length = 7;
		subject.Horsepower = 2;
		//Test Parameters
		if (weight > 0) 
			subject.Weight = weight;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData(0, false)]
	[InlineData(7, true)]
	public void Validation_RequiredLength(decimal length, bool isValidExpected)
	{
		var subject = new BTS_BeginningSegmentForTrainSheets();
		//Required fields
		subject.InterchangeTrainIdentification = "r";
		subject.TotalEquipment = 7;
		subject.EquipmentStatusCode = "6";
		subject.TotalEquipment2 = 2;
		subject.EquipmentStatusCode2 = "z";
		subject.Weight = 1;
		subject.Horsepower = 2;
		//Test Parameters
		if (length > 0) 
			subject.Length = length;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData(0, false)]
	[InlineData(2, true)]
	public void Validation_RequiredHorsepower(int horsepower, bool isValidExpected)
	{
		var subject = new BTS_BeginningSegmentForTrainSheets();
		//Required fields
		subject.InterchangeTrainIdentification = "r";
		subject.TotalEquipment = 7;
		subject.EquipmentStatusCode = "6";
		subject.TotalEquipment2 = 2;
		subject.EquipmentStatusCode2 = "z";
		subject.Weight = 1;
		subject.Length = 7;
		//Test Parameters
		if (horsepower > 0) 
			subject.Horsepower = horsepower;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
