using Eddy.Core.Validation;
using Eddy.x12.Mapping;
using Eddy.x12.Models;

namespace Eddy.Tests.x12.Models;

public class R12Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "R12*1*e*Z*G*CUXKI3Rd*f*M*t*j*1*5*Xy";

		var expected = new R12_WorkOrderInformation()
		{
			NumberOfLineItems = 1,
			EquipmentInitial = "e",
			EquipmentNumber = "Z",
			ReferenceIdentification = "G",
			Date = "CUXKI3Rd",
			LocationIdentifier = "f",
			LoadEmptyStatusCode = "M",
			EquipmentInitial2 = "t",
			EquipmentNumber2 = "j",
			EquipmentNumberCheckDigit = 1,
			EquipmentNumberCheckDigit2 = 5,
			EquipmentDescriptionCode = "Xy",
		};

		var actual = Map.MapObject<R12_WorkOrderInformation>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData(0, false)]
	[InlineData(1, true)]
	public void Validation_RequiredNumberOfLineItems(int numberOfLineItems, bool isValidExpected)
	{
		var subject = new R12_WorkOrderInformation();
		subject.EquipmentInitial = "e";
		subject.EquipmentNumber = "Z";
		subject.ReferenceIdentification = "G";
		subject.Date = "CUXKI3Rd";
		subject.EquipmentDescriptionCode = "Xy";
		if (numberOfLineItems > 0)
		subject.NumberOfLineItems = numberOfLineItems;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("e", true)]
	public void Validation_RequiredEquipmentInitial(string equipmentInitial, bool isValidExpected)
	{
		var subject = new R12_WorkOrderInformation();
		subject.NumberOfLineItems = 1;
		subject.EquipmentNumber = "Z";
		subject.ReferenceIdentification = "G";
		subject.Date = "CUXKI3Rd";
		subject.EquipmentDescriptionCode = "Xy";
		subject.EquipmentInitial = equipmentInitial;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("Z", true)]
	public void Validation_RequiredEquipmentNumber(string equipmentNumber, bool isValidExpected)
	{
		var subject = new R12_WorkOrderInformation();
		subject.NumberOfLineItems = 1;
		subject.EquipmentInitial = "e";
		subject.ReferenceIdentification = "G";
		subject.Date = "CUXKI3Rd";
		subject.EquipmentDescriptionCode = "Xy";
		subject.EquipmentNumber = equipmentNumber;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("G", true)]
	public void Validation_RequiredReferenceIdentification(string referenceIdentification, bool isValidExpected)
	{
		var subject = new R12_WorkOrderInformation();
		subject.NumberOfLineItems = 1;
		subject.EquipmentInitial = "e";
		subject.EquipmentNumber = "Z";
		subject.Date = "CUXKI3Rd";
		subject.EquipmentDescriptionCode = "Xy";
		subject.ReferenceIdentification = referenceIdentification;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("CUXKI3Rd", true)]
	public void Validation_RequiredDate(string date, bool isValidExpected)
	{
		var subject = new R12_WorkOrderInformation();
		subject.NumberOfLineItems = 1;
		subject.EquipmentInitial = "e";
		subject.EquipmentNumber = "Z";
		subject.ReferenceIdentification = "G";
		subject.EquipmentDescriptionCode = "Xy";
		subject.Date = date;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("","", true)]
	[InlineData("t", "j", true)]
	[InlineData("", "j", false)]
	[InlineData("t", "", false)]
	public void Validation_AllAreRequiredEquipmentInitial2(string equipmentInitial2, string equipmentNumber2, bool isValidExpected)
	{
		var subject = new R12_WorkOrderInformation();
		subject.NumberOfLineItems = 1;
		subject.EquipmentInitial = "e";
		subject.EquipmentNumber = "Z";
		subject.ReferenceIdentification = "G";
		subject.Date = "CUXKI3Rd";
		subject.EquipmentDescriptionCode = "Xy";
		subject.EquipmentInitial2 = equipmentInitial2;
		subject.EquipmentNumber2 = equipmentNumber2;

		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

	[Theory]
	[InlineData(0, "", true)]
	[InlineData(0, "j", true)]
	[InlineData(5, "", false)]
	public void Validation_ARequiresBEquipmentNumberCheckDigit2(int equipmentNumberCheckDigit2, string equipmentNumber2, bool isValidExpected)
	{
		var subject = new R12_WorkOrderInformation();
		subject.NumberOfLineItems = 1;
		subject.EquipmentInitial = "e";
		subject.EquipmentNumber = "Z";
		subject.ReferenceIdentification = "G";
		subject.Date = "CUXKI3Rd";
		subject.EquipmentDescriptionCode = "Xy";
		if (equipmentNumberCheckDigit2 > 0)
		subject.EquipmentNumberCheckDigit2 = equipmentNumberCheckDigit2;
		subject.EquipmentNumber2 = equipmentNumber2;

		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("Xy", true)]
	public void Validation_RequiredEquipmentDescriptionCode(string equipmentDescriptionCode, bool isValidExpected)
	{
		var subject = new R12_WorkOrderInformation();
		subject.NumberOfLineItems = 1;
		subject.EquipmentInitial = "e";
		subject.EquipmentNumber = "Z";
		subject.ReferenceIdentification = "G";
		subject.Date = "CUXKI3Rd";
		subject.EquipmentDescriptionCode = equipmentDescriptionCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
