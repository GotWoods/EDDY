using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v4040;

namespace Eddy.x12.Tests.Models.v4040;

public class R12Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "R12*6*A*g*R*oYDGAMfk*W*8*X*A*8";

		var expected = new R12_WorkOrderInformation()
		{
			NumberOfLineItems = 6,
			EquipmentInitial = "A",
			EquipmentNumber = "g",
			ReferenceIdentification = "R",
			Date = "oYDGAMfk",
			LocationIdentifier = "W",
			LoadEmptyStatusCode = "8",
			EquipmentInitial2 = "X",
			EquipmentNumber2 = "A",
			EquipmentNumberCheckDigit = 8,
		};

		var actual = Map.MapObject<R12_WorkOrderInformation>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData(0, false)]
	[InlineData(6, true)]
	public void Validation_RequiredNumberOfLineItems(int numberOfLineItems, bool isValidExpected)
	{
		var subject = new R12_WorkOrderInformation();
		//Required fields
		subject.EquipmentInitial = "A";
		subject.EquipmentNumber = "g";
		subject.ReferenceIdentification = "R";
		subject.Date = "oYDGAMfk";
		//Test Parameters
		if (numberOfLineItems > 0) 
			subject.NumberOfLineItems = numberOfLineItems;
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.EquipmentInitial2) || !string.IsNullOrEmpty(subject.EquipmentInitial2) || !string.IsNullOrEmpty(subject.EquipmentNumber2))
		{
			subject.EquipmentInitial2 = "X";
			subject.EquipmentNumber2 = "A";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("A", true)]
	public void Validation_RequiredEquipmentInitial(string equipmentInitial, bool isValidExpected)
	{
		var subject = new R12_WorkOrderInformation();
		//Required fields
		subject.NumberOfLineItems = 6;
		subject.EquipmentNumber = "g";
		subject.ReferenceIdentification = "R";
		subject.Date = "oYDGAMfk";
		//Test Parameters
		subject.EquipmentInitial = equipmentInitial;
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.EquipmentInitial2) || !string.IsNullOrEmpty(subject.EquipmentInitial2) || !string.IsNullOrEmpty(subject.EquipmentNumber2))
		{
			subject.EquipmentInitial2 = "X";
			subject.EquipmentNumber2 = "A";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("g", true)]
	public void Validation_RequiredEquipmentNumber(string equipmentNumber, bool isValidExpected)
	{
		var subject = new R12_WorkOrderInformation();
		//Required fields
		subject.NumberOfLineItems = 6;
		subject.EquipmentInitial = "A";
		subject.ReferenceIdentification = "R";
		subject.Date = "oYDGAMfk";
		//Test Parameters
		subject.EquipmentNumber = equipmentNumber;
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.EquipmentInitial2) || !string.IsNullOrEmpty(subject.EquipmentInitial2) || !string.IsNullOrEmpty(subject.EquipmentNumber2))
		{
			subject.EquipmentInitial2 = "X";
			subject.EquipmentNumber2 = "A";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("R", true)]
	public void Validation_RequiredReferenceIdentification(string referenceIdentification, bool isValidExpected)
	{
		var subject = new R12_WorkOrderInformation();
		//Required fields
		subject.NumberOfLineItems = 6;
		subject.EquipmentInitial = "A";
		subject.EquipmentNumber = "g";
		subject.Date = "oYDGAMfk";
		//Test Parameters
		subject.ReferenceIdentification = referenceIdentification;
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.EquipmentInitial2) || !string.IsNullOrEmpty(subject.EquipmentInitial2) || !string.IsNullOrEmpty(subject.EquipmentNumber2))
		{
			subject.EquipmentInitial2 = "X";
			subject.EquipmentNumber2 = "A";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("oYDGAMfk", true)]
	public void Validation_RequiredDate(string date, bool isValidExpected)
	{
		var subject = new R12_WorkOrderInformation();
		//Required fields
		subject.NumberOfLineItems = 6;
		subject.EquipmentInitial = "A";
		subject.EquipmentNumber = "g";
		subject.ReferenceIdentification = "R";
		//Test Parameters
		subject.Date = date;
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.EquipmentInitial2) || !string.IsNullOrEmpty(subject.EquipmentInitial2) || !string.IsNullOrEmpty(subject.EquipmentNumber2))
		{
			subject.EquipmentInitial2 = "X";
			subject.EquipmentNumber2 = "A";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("X", "A", true)]
	[InlineData("X", "", false)]
	[InlineData("", "A", false)]
	public void Validation_AllAreRequiredEquipmentInitial2(string equipmentInitial2, string equipmentNumber2, bool isValidExpected)
	{
		var subject = new R12_WorkOrderInformation();
		//Required fields
		subject.NumberOfLineItems = 6;
		subject.EquipmentInitial = "A";
		subject.EquipmentNumber = "g";
		subject.ReferenceIdentification = "R";
		subject.Date = "oYDGAMfk";
		//Test Parameters
		subject.EquipmentInitial2 = equipmentInitial2;
		subject.EquipmentNumber2 = equipmentNumber2;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

}
