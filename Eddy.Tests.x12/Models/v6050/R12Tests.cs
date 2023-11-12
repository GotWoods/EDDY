using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v6050;

namespace Eddy.x12.Tests.Models.v6050;

public class R12Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "R12*1*l*1*X*8qHeyBgS*d*z*f*G*5*1*OJ";

		var expected = new R12_WorkOrderInformation()
		{
			NumberOfLineItems = 1,
			EquipmentInitial = "l",
			EquipmentNumber = "1",
			ReferenceIdentification = "X",
			Date = "8qHeyBgS",
			LocationIdentifier = "d",
			LoadEmptyStatusCode = "z",
			EquipmentInitial2 = "f",
			EquipmentNumber2 = "G",
			EquipmentNumberCheckDigit = 5,
			EquipmentNumberCheckDigit2 = 1,
			EquipmentDescriptionCode = "OJ",
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
		//Required fields
		subject.EquipmentInitial = "l";
		subject.EquipmentNumber = "1";
		subject.ReferenceIdentification = "X";
		subject.Date = "8qHeyBgS";
		subject.EquipmentDescriptionCode = "OJ";
		//Test Parameters
		if (numberOfLineItems > 0) 
			subject.NumberOfLineItems = numberOfLineItems;
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.EquipmentInitial2) || !string.IsNullOrEmpty(subject.EquipmentInitial2) || !string.IsNullOrEmpty(subject.EquipmentNumber2))
		{
			subject.EquipmentInitial2 = "f";
			subject.EquipmentNumber2 = "G";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("l", true)]
	public void Validation_RequiredEquipmentInitial(string equipmentInitial, bool isValidExpected)
	{
		var subject = new R12_WorkOrderInformation();
		//Required fields
		subject.NumberOfLineItems = 1;
		subject.EquipmentNumber = "1";
		subject.ReferenceIdentification = "X";
		subject.Date = "8qHeyBgS";
		subject.EquipmentDescriptionCode = "OJ";
		//Test Parameters
		subject.EquipmentInitial = equipmentInitial;
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.EquipmentInitial2) || !string.IsNullOrEmpty(subject.EquipmentInitial2) || !string.IsNullOrEmpty(subject.EquipmentNumber2))
		{
			subject.EquipmentInitial2 = "f";
			subject.EquipmentNumber2 = "G";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("1", true)]
	public void Validation_RequiredEquipmentNumber(string equipmentNumber, bool isValidExpected)
	{
		var subject = new R12_WorkOrderInformation();
		//Required fields
		subject.NumberOfLineItems = 1;
		subject.EquipmentInitial = "l";
		subject.ReferenceIdentification = "X";
		subject.Date = "8qHeyBgS";
		subject.EquipmentDescriptionCode = "OJ";
		//Test Parameters
		subject.EquipmentNumber = equipmentNumber;
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.EquipmentInitial2) || !string.IsNullOrEmpty(subject.EquipmentInitial2) || !string.IsNullOrEmpty(subject.EquipmentNumber2))
		{
			subject.EquipmentInitial2 = "f";
			subject.EquipmentNumber2 = "G";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("X", true)]
	public void Validation_RequiredReferenceIdentification(string referenceIdentification, bool isValidExpected)
	{
		var subject = new R12_WorkOrderInformation();
		//Required fields
		subject.NumberOfLineItems = 1;
		subject.EquipmentInitial = "l";
		subject.EquipmentNumber = "1";
		subject.Date = "8qHeyBgS";
		subject.EquipmentDescriptionCode = "OJ";
		//Test Parameters
		subject.ReferenceIdentification = referenceIdentification;
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.EquipmentInitial2) || !string.IsNullOrEmpty(subject.EquipmentInitial2) || !string.IsNullOrEmpty(subject.EquipmentNumber2))
		{
			subject.EquipmentInitial2 = "f";
			subject.EquipmentNumber2 = "G";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("8qHeyBgS", true)]
	public void Validation_RequiredDate(string date, bool isValidExpected)
	{
		var subject = new R12_WorkOrderInformation();
		//Required fields
		subject.NumberOfLineItems = 1;
		subject.EquipmentInitial = "l";
		subject.EquipmentNumber = "1";
		subject.ReferenceIdentification = "X";
		subject.EquipmentDescriptionCode = "OJ";
		//Test Parameters
		subject.Date = date;
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.EquipmentInitial2) || !string.IsNullOrEmpty(subject.EquipmentInitial2) || !string.IsNullOrEmpty(subject.EquipmentNumber2))
		{
			subject.EquipmentInitial2 = "f";
			subject.EquipmentNumber2 = "G";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("f", "G", true)]
	[InlineData("f", "", false)]
	[InlineData("", "G", false)]
	public void Validation_AllAreRequiredEquipmentInitial2(string equipmentInitial2, string equipmentNumber2, bool isValidExpected)
	{
		var subject = new R12_WorkOrderInformation();
		//Required fields
		subject.NumberOfLineItems = 1;
		subject.EquipmentInitial = "l";
		subject.EquipmentNumber = "1";
		subject.ReferenceIdentification = "X";
		subject.Date = "8qHeyBgS";
		subject.EquipmentDescriptionCode = "OJ";
		//Test Parameters
		subject.EquipmentInitial2 = equipmentInitial2;
		subject.EquipmentNumber2 = equipmentNumber2;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

	[Theory]
	[InlineData(0, "", true)]
	[InlineData(1, "G", true)]
	[InlineData(1, "", false)]
	[InlineData(0, "G", true)]
	public void Validation_ARequiresBEquipmentNumberCheckDigit2(int equipmentNumberCheckDigit2, string equipmentNumber2, bool isValidExpected)
	{
		var subject = new R12_WorkOrderInformation();
		//Required fields
		subject.NumberOfLineItems = 1;
		subject.EquipmentInitial = "l";
		subject.EquipmentNumber = "1";
		subject.ReferenceIdentification = "X";
		subject.Date = "8qHeyBgS";
		subject.EquipmentDescriptionCode = "OJ";
		//Test Parameters
		if (equipmentNumberCheckDigit2 > 0) 
			subject.EquipmentNumberCheckDigit2 = equipmentNumberCheckDigit2;
		subject.EquipmentNumber2 = equipmentNumber2;
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.EquipmentInitial2) || !string.IsNullOrEmpty(subject.EquipmentInitial2) || !string.IsNullOrEmpty(subject.EquipmentNumber2))
		{
			subject.EquipmentInitial2 = "f";
			subject.EquipmentNumber2 = "G";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("OJ", true)]
	public void Validation_RequiredEquipmentDescriptionCode(string equipmentDescriptionCode, bool isValidExpected)
	{
		var subject = new R12_WorkOrderInformation();
		//Required fields
		subject.NumberOfLineItems = 1;
		subject.EquipmentInitial = "l";
		subject.EquipmentNumber = "1";
		subject.ReferenceIdentification = "X";
		subject.Date = "8qHeyBgS";
		//Test Parameters
		subject.EquipmentDescriptionCode = equipmentDescriptionCode;
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.EquipmentInitial2) || !string.IsNullOrEmpty(subject.EquipmentInitial2) || !string.IsNullOrEmpty(subject.EquipmentNumber2))
		{
			subject.EquipmentInitial2 = "f";
			subject.EquipmentNumber2 = "G";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
