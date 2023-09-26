using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3030;

namespace Eddy.x12.Tests.Models.v3030;

public class BTSTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "BTS*Z*4*4*4*r*O*9*85*1*5";

		var expected = new BTS_BeginningSegmentForTrainSheets()
		{
			InterchangeTrainIdentification = "Z",
			TotalEquipment = 4,
			EquipmentStatusCode = "4",
			TotalEquipment2 = 4,
			EquipmentStatusCode2 = "r",
			WeightUnitCode = "O",
			Weight = 9,
			UnitOrBasisForMeasurementCode = "85",
			Length = 1,
			Horsepower = 5,
		};

		var actual = Map.MapObject<BTS_BeginningSegmentForTrainSheets>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("Z", true)]
	public void Validation_RequiredInterchangeTrainIdentification(string interchangeTrainIdentification, bool isValidExpected)
	{
		var subject = new BTS_BeginningSegmentForTrainSheets();
		//Required fields
		subject.TotalEquipment = 4;
		subject.EquipmentStatusCode = "4";
		subject.TotalEquipment2 = 4;
		subject.EquipmentStatusCode2 = "r";
		subject.WeightUnitCode = "O";
		subject.Weight = 9;
		subject.UnitOrBasisForMeasurementCode = "85";
		subject.Length = 1;
		subject.Horsepower = 5;
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
		subject.InterchangeTrainIdentification = "Z";
		subject.EquipmentStatusCode = "4";
		subject.TotalEquipment2 = 4;
		subject.EquipmentStatusCode2 = "r";
		subject.WeightUnitCode = "O";
		subject.Weight = 9;
		subject.UnitOrBasisForMeasurementCode = "85";
		subject.Length = 1;
		subject.Horsepower = 5;
		//Test Parameters
		if (totalEquipment > 0) 
			subject.TotalEquipment = totalEquipment;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("4", true)]
	public void Validation_RequiredEquipmentStatusCode(string equipmentStatusCode, bool isValidExpected)
	{
		var subject = new BTS_BeginningSegmentForTrainSheets();
		//Required fields
		subject.InterchangeTrainIdentification = "Z";
		subject.TotalEquipment = 4;
		subject.TotalEquipment2 = 4;
		subject.EquipmentStatusCode2 = "r";
		subject.WeightUnitCode = "O";
		subject.Weight = 9;
		subject.UnitOrBasisForMeasurementCode = "85";
		subject.Length = 1;
		subject.Horsepower = 5;
		//Test Parameters
		subject.EquipmentStatusCode = equipmentStatusCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData(0, false)]
	[InlineData(4, true)]
	public void Validation_RequiredTotalEquipment2(int totalEquipment2, bool isValidExpected)
	{
		var subject = new BTS_BeginningSegmentForTrainSheets();
		//Required fields
		subject.InterchangeTrainIdentification = "Z";
		subject.TotalEquipment = 4;
		subject.EquipmentStatusCode = "4";
		subject.EquipmentStatusCode2 = "r";
		subject.WeightUnitCode = "O";
		subject.Weight = 9;
		subject.UnitOrBasisForMeasurementCode = "85";
		subject.Length = 1;
		subject.Horsepower = 5;
		//Test Parameters
		if (totalEquipment2 > 0) 
			subject.TotalEquipment2 = totalEquipment2;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("r", true)]
	public void Validation_RequiredEquipmentStatusCode2(string equipmentStatusCode2, bool isValidExpected)
	{
		var subject = new BTS_BeginningSegmentForTrainSheets();
		//Required fields
		subject.InterchangeTrainIdentification = "Z";
		subject.TotalEquipment = 4;
		subject.EquipmentStatusCode = "4";
		subject.TotalEquipment2 = 4;
		subject.WeightUnitCode = "O";
		subject.Weight = 9;
		subject.UnitOrBasisForMeasurementCode = "85";
		subject.Length = 1;
		subject.Horsepower = 5;
		//Test Parameters
		subject.EquipmentStatusCode2 = equipmentStatusCode2;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("O", true)]
	public void Validation_RequiredWeightUnitCode(string weightUnitCode, bool isValidExpected)
	{
		var subject = new BTS_BeginningSegmentForTrainSheets();
		//Required fields
		subject.InterchangeTrainIdentification = "Z";
		subject.TotalEquipment = 4;
		subject.EquipmentStatusCode = "4";
		subject.TotalEquipment2 = 4;
		subject.EquipmentStatusCode2 = "r";
		subject.Weight = 9;
		subject.UnitOrBasisForMeasurementCode = "85";
		subject.Length = 1;
		subject.Horsepower = 5;
		//Test Parameters
		subject.WeightUnitCode = weightUnitCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData(0, false)]
	[InlineData(9, true)]
	public void Validation_RequiredWeight(decimal weight, bool isValidExpected)
	{
		var subject = new BTS_BeginningSegmentForTrainSheets();
		//Required fields
		subject.InterchangeTrainIdentification = "Z";
		subject.TotalEquipment = 4;
		subject.EquipmentStatusCode = "4";
		subject.TotalEquipment2 = 4;
		subject.EquipmentStatusCode2 = "r";
		subject.WeightUnitCode = "O";
		subject.UnitOrBasisForMeasurementCode = "85";
		subject.Length = 1;
		subject.Horsepower = 5;
		//Test Parameters
		if (weight > 0) 
			subject.Weight = weight;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("85", true)]
	public void Validation_RequiredUnitOrBasisForMeasurementCode(string unitOrBasisForMeasurementCode, bool isValidExpected)
	{
		var subject = new BTS_BeginningSegmentForTrainSheets();
		//Required fields
		subject.InterchangeTrainIdentification = "Z";
		subject.TotalEquipment = 4;
		subject.EquipmentStatusCode = "4";
		subject.TotalEquipment2 = 4;
		subject.EquipmentStatusCode2 = "r";
		subject.WeightUnitCode = "O";
		subject.Weight = 9;
		subject.Length = 1;
		subject.Horsepower = 5;
		//Test Parameters
		subject.UnitOrBasisForMeasurementCode = unitOrBasisForMeasurementCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData(0, false)]
	[InlineData(1, true)]
	public void Validation_RequiredLength(decimal length, bool isValidExpected)
	{
		var subject = new BTS_BeginningSegmentForTrainSheets();
		//Required fields
		subject.InterchangeTrainIdentification = "Z";
		subject.TotalEquipment = 4;
		subject.EquipmentStatusCode = "4";
		subject.TotalEquipment2 = 4;
		subject.EquipmentStatusCode2 = "r";
		subject.WeightUnitCode = "O";
		subject.Weight = 9;
		subject.UnitOrBasisForMeasurementCode = "85";
		subject.Horsepower = 5;
		//Test Parameters
		if (length > 0) 
			subject.Length = length;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData(0, false)]
	[InlineData(5, true)]
	public void Validation_RequiredHorsepower(int horsepower, bool isValidExpected)
	{
		var subject = new BTS_BeginningSegmentForTrainSheets();
		//Required fields
		subject.InterchangeTrainIdentification = "Z";
		subject.TotalEquipment = 4;
		subject.EquipmentStatusCode = "4";
		subject.TotalEquipment2 = 4;
		subject.EquipmentStatusCode2 = "r";
		subject.WeightUnitCode = "O";
		subject.Weight = 9;
		subject.UnitOrBasisForMeasurementCode = "85";
		subject.Length = 1;
		//Test Parameters
		if (horsepower > 0) 
			subject.Horsepower = horsepower;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
