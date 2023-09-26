using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v5030;

namespace Eddy.x12.Tests.Models.v5030;

public class R12Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "R12*2*V*r*1*jntxMGfn*C*j*a*9*5";

		var expected = new R12_WorkOrderInformation()
		{
			NumberOfLineItems = 2,
			EquipmentInitial = "V",
			EquipmentNumber = "r",
			ReferenceIdentification = "1",
			Date = "jntxMGfn",
			LocationIdentifier = "C",
			LoadEmptyStatusCode = "j",
			EquipmentInitial2 = "a",
			EquipmentNumber2 = "9",
			EquipmentNumberCheckDigit = 5,
		};

		var actual = Map.MapObject<R12_WorkOrderInformation>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData(0, false)]
	[InlineData(2, true)]
	public void Validation_RequiredNumberOfLineItems(int numberOfLineItems, bool isValidExpected)
	{
		var subject = new R12_WorkOrderInformation();
		//Required fields
		subject.EquipmentInitial = "V";
		subject.EquipmentNumber = "r";
		subject.ReferenceIdentification = "1";
		subject.Date = "jntxMGfn";
		//Test Parameters
		if (numberOfLineItems > 0) 
			subject.NumberOfLineItems = numberOfLineItems;
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.EquipmentInitial2) || !string.IsNullOrEmpty(subject.EquipmentInitial2) || !string.IsNullOrEmpty(subject.EquipmentNumber2))
		{
			subject.EquipmentInitial2 = "a";
			subject.EquipmentNumber2 = "9";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("V", true)]
	public void Validation_RequiredEquipmentInitial(string equipmentInitial, bool isValidExpected)
	{
		var subject = new R12_WorkOrderInformation();
		//Required fields
		subject.NumberOfLineItems = 2;
		subject.EquipmentNumber = "r";
		subject.ReferenceIdentification = "1";
		subject.Date = "jntxMGfn";
		//Test Parameters
		subject.EquipmentInitial = equipmentInitial;
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.EquipmentInitial2) || !string.IsNullOrEmpty(subject.EquipmentInitial2) || !string.IsNullOrEmpty(subject.EquipmentNumber2))
		{
			subject.EquipmentInitial2 = "a";
			subject.EquipmentNumber2 = "9";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("r", true)]
	public void Validation_RequiredEquipmentNumber(string equipmentNumber, bool isValidExpected)
	{
		var subject = new R12_WorkOrderInformation();
		//Required fields
		subject.NumberOfLineItems = 2;
		subject.EquipmentInitial = "V";
		subject.ReferenceIdentification = "1";
		subject.Date = "jntxMGfn";
		//Test Parameters
		subject.EquipmentNumber = equipmentNumber;
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.EquipmentInitial2) || !string.IsNullOrEmpty(subject.EquipmentInitial2) || !string.IsNullOrEmpty(subject.EquipmentNumber2))
		{
			subject.EquipmentInitial2 = "a";
			subject.EquipmentNumber2 = "9";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("1", true)]
	public void Validation_RequiredReferenceIdentification(string referenceIdentification, bool isValidExpected)
	{
		var subject = new R12_WorkOrderInformation();
		//Required fields
		subject.NumberOfLineItems = 2;
		subject.EquipmentInitial = "V";
		subject.EquipmentNumber = "r";
		subject.Date = "jntxMGfn";
		//Test Parameters
		subject.ReferenceIdentification = referenceIdentification;
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.EquipmentInitial2) || !string.IsNullOrEmpty(subject.EquipmentInitial2) || !string.IsNullOrEmpty(subject.EquipmentNumber2))
		{
			subject.EquipmentInitial2 = "a";
			subject.EquipmentNumber2 = "9";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("jntxMGfn", true)]
	public void Validation_RequiredDate(string date, bool isValidExpected)
	{
		var subject = new R12_WorkOrderInformation();
		//Required fields
		subject.NumberOfLineItems = 2;
		subject.EquipmentInitial = "V";
		subject.EquipmentNumber = "r";
		subject.ReferenceIdentification = "1";
		//Test Parameters
		subject.Date = date;
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.EquipmentInitial2) || !string.IsNullOrEmpty(subject.EquipmentInitial2) || !string.IsNullOrEmpty(subject.EquipmentNumber2))
		{
			subject.EquipmentInitial2 = "a";
			subject.EquipmentNumber2 = "9";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("a", "9", true)]
	[InlineData("a", "", false)]
	[InlineData("", "9", false)]
	public void Validation_AllAreRequiredEquipmentInitial2(string equipmentInitial2, string equipmentNumber2, bool isValidExpected)
	{
		var subject = new R12_WorkOrderInformation();
		//Required fields
		subject.NumberOfLineItems = 2;
		subject.EquipmentInitial = "V";
		subject.EquipmentNumber = "r";
		subject.ReferenceIdentification = "1";
		subject.Date = "jntxMGfn";
		//Test Parameters
		subject.EquipmentInitial2 = equipmentInitial2;
		subject.EquipmentNumber2 = equipmentNumber2;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

}
