using EdiParser.Validation;
using EdiParser.x12.Mapping;
using EdiParser.x12.Models;

namespace EdiParser.Tests.x12.Models;

public class BTSTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "BTS*F*5*o*8*D*5*9*6*7o*U4*Mj*K*1mBMLT7u*9*9*oO1ec2wZ";

		var expected = new BTS_BeginningSegmentForTrainSheets()
		{
			InterchangeTrainIdentification = "F",
			TotalEquipment = 5,
			EquipmentStatusCode = "o",
			TotalEquipment2 = 8,
			EquipmentStatusCode2 = "D",
			Weight = 5,
			Length = 9,
			Horsepower = 6,
			StandardCarrierAlphaCode = "7o",
			TransactionSetPurposeCode = "U4",
			ServiceLevelCode = "Mj",
			YesNoConditionOrResponseCode = "K",
			Date = "1mBMLT7u",
			InterchangeTrainIdentification2 = "9",
			Number = 9,
			Date2 = "oO1ec2wZ",
		};

		var actual = Map.MapObject<BTS_BeginningSegmentForTrainSheets>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		try
		{
			Assert.Equivalent(expected, actual);
		}
		catch
		{
			Assert.Fail(actual.ValidationResult.ToString());
		}
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("F", true)]
	public void Validatation_RequiredInterchangeTrainIdentification(string interchangeTrainIdentification, bool isValidExpected)
	{
		var subject = new BTS_BeginningSegmentForTrainSheets();
		subject.InterchangeTrainIdentification = interchangeTrainIdentification;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData(0,"", true)]
	[InlineData(5, "o", true)]
	[InlineData(0, "o", false)]
	[InlineData(5, "", false)]
	public void Validation_AllAreRequiredTotalEquipment(int totalEquipment, string equipmentStatusCode, bool isValidExpected)
	{
		var subject = new BTS_BeginningSegmentForTrainSheets();
		subject.InterchangeTrainIdentification = "F";
		if (totalEquipment > 0)
		subject.TotalEquipment = totalEquipment;
		subject.EquipmentStatusCode = equipmentStatusCode;

		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

	[Theory]
	[InlineData(0,"", true)]
	[InlineData(8, "D", true)]
	[InlineData(0, "D", false)]
	[InlineData(8, "", false)]
	public void Validation_AllAreRequiredTotalEquipment2(int totalEquipment2, string equipmentStatusCode2, bool isValidExpected)
	{
		var subject = new BTS_BeginningSegmentForTrainSheets();
		subject.InterchangeTrainIdentification = "F";
		if (totalEquipment2 > 0)
		subject.TotalEquipment2 = totalEquipment2;
		subject.EquipmentStatusCode2 = equipmentStatusCode2;

		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

}
