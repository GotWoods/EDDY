using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v4030;

namespace Eddy.x12.Tests.Models.v4030;

public class R12Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "R12*8*e*g*p*TEJy9xmR*9*a*l*l*1";

		var expected = new R12_WorkOrderInformation()
		{
			NumberOfLineItems = 8,
			EquipmentInitial = "e",
			EquipmentNumber = "g",
			ReferenceIdentification = "p",
			Date = "TEJy9xmR",
			LocationIdentifier = "9",
			LoadEmptyStatusCode = "a",
			EquipmentInitial2 = "l",
			EquipmentNumber2 = "l",
			EquipmentNumberCheckDigit = 1,
		};

		var actual = Map.MapObject<R12_WorkOrderInformation>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData(0, false)]
	[InlineData(8, true)]
	public void Validation_RequiredNumberOfLineItems(int numberOfLineItems, bool isValidExpected)
	{
		var subject = new R12_WorkOrderInformation();
		//Required fields
		subject.EquipmentInitial = "e";
		subject.EquipmentNumber = "g";
		subject.ReferenceIdentification = "p";
		subject.Date = "TEJy9xmR";
		//Test Parameters
		if (numberOfLineItems > 0) 
			subject.NumberOfLineItems = numberOfLineItems;
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.EquipmentInitial2) || !string.IsNullOrEmpty(subject.EquipmentInitial2) || !string.IsNullOrEmpty(subject.EquipmentNumber2))
		{
			subject.EquipmentInitial2 = "l";
			subject.EquipmentNumber2 = "l";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("e", true)]
	public void Validation_RequiredEquipmentInitial(string equipmentInitial, bool isValidExpected)
	{
		var subject = new R12_WorkOrderInformation();
		//Required fields
		subject.NumberOfLineItems = 8;
		subject.EquipmentNumber = "g";
		subject.ReferenceIdentification = "p";
		subject.Date = "TEJy9xmR";
		//Test Parameters
		subject.EquipmentInitial = equipmentInitial;
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.EquipmentInitial2) || !string.IsNullOrEmpty(subject.EquipmentInitial2) || !string.IsNullOrEmpty(subject.EquipmentNumber2))
		{
			subject.EquipmentInitial2 = "l";
			subject.EquipmentNumber2 = "l";
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
		subject.NumberOfLineItems = 8;
		subject.EquipmentInitial = "e";
		subject.ReferenceIdentification = "p";
		subject.Date = "TEJy9xmR";
		//Test Parameters
		subject.EquipmentNumber = equipmentNumber;
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.EquipmentInitial2) || !string.IsNullOrEmpty(subject.EquipmentInitial2) || !string.IsNullOrEmpty(subject.EquipmentNumber2))
		{
			subject.EquipmentInitial2 = "l";
			subject.EquipmentNumber2 = "l";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("p", true)]
	public void Validation_RequiredReferenceIdentification(string referenceIdentification, bool isValidExpected)
	{
		var subject = new R12_WorkOrderInformation();
		//Required fields
		subject.NumberOfLineItems = 8;
		subject.EquipmentInitial = "e";
		subject.EquipmentNumber = "g";
		subject.Date = "TEJy9xmR";
		//Test Parameters
		subject.ReferenceIdentification = referenceIdentification;
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.EquipmentInitial2) || !string.IsNullOrEmpty(subject.EquipmentInitial2) || !string.IsNullOrEmpty(subject.EquipmentNumber2))
		{
			subject.EquipmentInitial2 = "l";
			subject.EquipmentNumber2 = "l";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("TEJy9xmR", true)]
	public void Validation_RequiredDate(string date, bool isValidExpected)
	{
		var subject = new R12_WorkOrderInformation();
		//Required fields
		subject.NumberOfLineItems = 8;
		subject.EquipmentInitial = "e";
		subject.EquipmentNumber = "g";
		subject.ReferenceIdentification = "p";
		//Test Parameters
		subject.Date = date;
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.EquipmentInitial2) || !string.IsNullOrEmpty(subject.EquipmentInitial2) || !string.IsNullOrEmpty(subject.EquipmentNumber2))
		{
			subject.EquipmentInitial2 = "l";
			subject.EquipmentNumber2 = "l";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("l", "l", true)]
	[InlineData("l", "", false)]
	[InlineData("", "l", false)]
	public void Validation_AllAreRequiredEquipmentInitial2(string equipmentInitial2, string equipmentNumber2, bool isValidExpected)
	{
		var subject = new R12_WorkOrderInformation();
		//Required fields
		subject.NumberOfLineItems = 8;
		subject.EquipmentInitial = "e";
		subject.EquipmentNumber = "g";
		subject.ReferenceIdentification = "p";
		subject.Date = "TEJy9xmR";
		//Test Parameters
		subject.EquipmentInitial2 = equipmentInitial2;
		subject.EquipmentNumber2 = equipmentNumber2;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

}
