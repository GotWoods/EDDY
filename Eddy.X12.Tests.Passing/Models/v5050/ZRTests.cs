using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v5050;

namespace Eddy.x12.Tests.Models.v5050;

public class ZRTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "ZR*1*9*u*4*k6YlrD4T*P*n3*OdtKYLBt*Mo*4T*g*b*BT*5*6*H";

		var expected = new ZR_WaybillReferenceIdentification()
		{
			WaybillResponseCode = "1",
			EquipmentInitial = "9",
			EquipmentNumber = "u",
			WaybillNumber = 4,
			Date = "k6YlrD4T",
			FreeFormMessage = "P",
			StandardCarrierAlphaCode = "n3",
			Date2 = "OdtKYLBt",
			InterlineSettlementSystemStatusActionOrDisputeCode = "Mo",
			InterlineSettlementSystemStatusActionOrDisputeCode2 = "4T",
			ReferenceIdentification = "g",
			ReferenceIdentification2 = "b",
			CorrectionIndicator = "BT",
			EquipmentNumberCheckDigit = 5,
			EquipmentInitial2 = "6",
			EquipmentNumber2 = "H",
		};

		var actual = Map.MapObject<ZR_WaybillReferenceIdentification>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("1", true)]
	public void Validation_RequiredWaybillResponseCode(string waybillResponseCode, bool isValidExpected)
	{
		var subject = new ZR_WaybillReferenceIdentification();
		//Required fields
		subject.EquipmentInitial = "9";
		subject.EquipmentNumber = "u";
		//Test Parameters
		subject.WaybillResponseCode = waybillResponseCode;
		//At Least one
		subject.FreeFormMessage = "P";
		//If one filled, all required
		if(subject.WaybillNumber > 0 || subject.WaybillNumber > 0 || !string.IsNullOrEmpty(subject.Date))
		{
			subject.WaybillNumber = 4;
			subject.Date = "k6YlrD4T";
		}
		if(!string.IsNullOrEmpty(subject.EquipmentInitial2) || !string.IsNullOrEmpty(subject.EquipmentInitial2) || !string.IsNullOrEmpty(subject.EquipmentNumber2))
		{
			subject.EquipmentInitial2 = "6";
			subject.EquipmentNumber2 = "H";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("9", true)]
	public void Validation_RequiredEquipmentInitial(string equipmentInitial, bool isValidExpected)
	{
		var subject = new ZR_WaybillReferenceIdentification();
		//Required fields
		subject.WaybillResponseCode = "1";
		subject.EquipmentNumber = "u";
		//Test Parameters
		subject.EquipmentInitial = equipmentInitial;
		//At Least one
		subject.FreeFormMessage = "P";
		//If one filled, all required
		if(subject.WaybillNumber > 0 || subject.WaybillNumber > 0 || !string.IsNullOrEmpty(subject.Date))
		{
			subject.WaybillNumber = 4;
			subject.Date = "k6YlrD4T";
		}
		if(!string.IsNullOrEmpty(subject.EquipmentInitial2) || !string.IsNullOrEmpty(subject.EquipmentInitial2) || !string.IsNullOrEmpty(subject.EquipmentNumber2))
		{
			subject.EquipmentInitial2 = "6";
			subject.EquipmentNumber2 = "H";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("u", true)]
	public void Validation_RequiredEquipmentNumber(string equipmentNumber, bool isValidExpected)
	{
		var subject = new ZR_WaybillReferenceIdentification();
		//Required fields
		subject.WaybillResponseCode = "1";
		subject.EquipmentInitial = "9";
		//Test Parameters
		subject.EquipmentNumber = equipmentNumber;
		//At Least one
		subject.FreeFormMessage = "P";
		//If one filled, all required
		if(subject.WaybillNumber > 0 || subject.WaybillNumber > 0 || !string.IsNullOrEmpty(subject.Date))
		{
			subject.WaybillNumber = 4;
			subject.Date = "k6YlrD4T";
		}
		if(!string.IsNullOrEmpty(subject.EquipmentInitial2) || !string.IsNullOrEmpty(subject.EquipmentInitial2) || !string.IsNullOrEmpty(subject.EquipmentNumber2))
		{
			subject.EquipmentInitial2 = "6";
			subject.EquipmentNumber2 = "H";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData(0, "", true)]
	[InlineData(4, "k6YlrD4T", true)]
	[InlineData(4, "", false)]
	[InlineData(0, "k6YlrD4T", false)]
	public void Validation_AllAreRequiredWaybillNumber(int waybillNumber, string date, bool isValidExpected)
	{
		var subject = new ZR_WaybillReferenceIdentification();
		//Required fields
		subject.WaybillResponseCode = "1";
		subject.EquipmentInitial = "9";
		subject.EquipmentNumber = "u";
		//Test Parameters
		if (waybillNumber > 0) 
			subject.WaybillNumber = waybillNumber;
		subject.Date = date;
		//At Least one
		subject.FreeFormMessage = "P";
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.EquipmentInitial2) || !string.IsNullOrEmpty(subject.EquipmentInitial2) || !string.IsNullOrEmpty(subject.EquipmentNumber2))
		{
			subject.EquipmentInitial2 = "6";
			subject.EquipmentNumber2 = "H";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

	[Theory]
	[InlineData("", "", false)]
	[InlineData("P", "n3", true)]
	[InlineData("P", "", true)]
	[InlineData("", "n3", true)]
	public void Validation_AtLeastOneFreeFormMessage(string freeFormMessage, string standardCarrierAlphaCode, bool isValidExpected)
	{
		var subject = new ZR_WaybillReferenceIdentification();
		//Required fields
		subject.WaybillResponseCode = "1";
		subject.EquipmentInitial = "9";
		subject.EquipmentNumber = "u";
		//Test Parameters
		subject.FreeFormMessage = freeFormMessage;
		subject.StandardCarrierAlphaCode = standardCarrierAlphaCode;
		//If one filled, all required
		if(subject.WaybillNumber > 0 || subject.WaybillNumber > 0 || !string.IsNullOrEmpty(subject.Date))
		{
			subject.WaybillNumber = 4;
			subject.Date = "k6YlrD4T";
		}
		if(!string.IsNullOrEmpty(subject.EquipmentInitial2) || !string.IsNullOrEmpty(subject.EquipmentInitial2) || !string.IsNullOrEmpty(subject.EquipmentNumber2))
		{
			subject.EquipmentInitial2 = "6";
			subject.EquipmentNumber2 = "H";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.AtLeastOneIsRequired);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("6", "H", true)]
	[InlineData("6", "", false)]
	[InlineData("", "H", false)]
	public void Validation_AllAreRequiredEquipmentInitial2(string equipmentInitial2, string equipmentNumber2, bool isValidExpected)
	{
		var subject = new ZR_WaybillReferenceIdentification();
		//Required fields
		subject.WaybillResponseCode = "1";
		subject.EquipmentInitial = "9";
		subject.EquipmentNumber = "u";
		//Test Parameters
		subject.EquipmentInitial2 = equipmentInitial2;
		subject.EquipmentNumber2 = equipmentNumber2;
		//At Least one
		subject.FreeFormMessage = "P";
		//If one filled, all required
		if(subject.WaybillNumber > 0 || subject.WaybillNumber > 0 || !string.IsNullOrEmpty(subject.Date))
		{
			subject.WaybillNumber = 4;
			subject.Date = "k6YlrD4T";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

}
