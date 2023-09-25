using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v6030;

namespace Eddy.x12.Tests.Models.v6030;

public class ZRTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "ZR*8*z*H*2*xImocdDb*w*dX*AFbdV8LC*dF*ij*U*7*F0*9*n*Y";

		var expected = new ZR_WaybillReferenceIdentification()
		{
			WaybillResponseCode = "8",
			EquipmentInitial = "z",
			EquipmentNumber = "H",
			WaybillNumber = 2,
			Date = "xImocdDb",
			FreeFormMessage = "w",
			StandardCarrierAlphaCode = "dX",
			Date2 = "AFbdV8LC",
			InterlineSettlementSystemStatusActionOrDisputeCode = "dF",
			InterlineSettlementSystemStatusActionOrDisputeCode2 = "ij",
			ReferenceIdentification = "U",
			ReferenceIdentification2 = "7",
			CorrectionIndicatorCode = "F0",
			EquipmentNumberCheckDigit = 9,
			EquipmentInitial2 = "n",
			EquipmentNumber2 = "Y",
		};

		var actual = Map.MapObject<ZR_WaybillReferenceIdentification>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("8", true)]
	public void Validation_RequiredWaybillResponseCode(string waybillResponseCode, bool isValidExpected)
	{
		var subject = new ZR_WaybillReferenceIdentification();
		//Required fields
		subject.EquipmentInitial = "z";
		subject.EquipmentNumber = "H";
		//Test Parameters
		subject.WaybillResponseCode = waybillResponseCode;
		//At Least one
		subject.FreeFormMessage = "w";
		//If one filled, all required
		if(subject.WaybillNumber > 0 || subject.WaybillNumber > 0 || !string.IsNullOrEmpty(subject.Date))
		{
			subject.WaybillNumber = 2;
			subject.Date = "xImocdDb";
		}
		if(!string.IsNullOrEmpty(subject.EquipmentInitial2) || !string.IsNullOrEmpty(subject.EquipmentInitial2) || !string.IsNullOrEmpty(subject.EquipmentNumber2))
		{
			subject.EquipmentInitial2 = "n";
			subject.EquipmentNumber2 = "Y";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("z", true)]
	public void Validation_RequiredEquipmentInitial(string equipmentInitial, bool isValidExpected)
	{
		var subject = new ZR_WaybillReferenceIdentification();
		//Required fields
		subject.WaybillResponseCode = "8";
		subject.EquipmentNumber = "H";
		//Test Parameters
		subject.EquipmentInitial = equipmentInitial;
		//At Least one
		subject.FreeFormMessage = "w";
		//If one filled, all required
		if(subject.WaybillNumber > 0 || subject.WaybillNumber > 0 || !string.IsNullOrEmpty(subject.Date))
		{
			subject.WaybillNumber = 2;
			subject.Date = "xImocdDb";
		}
		if(!string.IsNullOrEmpty(subject.EquipmentInitial2) || !string.IsNullOrEmpty(subject.EquipmentInitial2) || !string.IsNullOrEmpty(subject.EquipmentNumber2))
		{
			subject.EquipmentInitial2 = "n";
			subject.EquipmentNumber2 = "Y";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("H", true)]
	public void Validation_RequiredEquipmentNumber(string equipmentNumber, bool isValidExpected)
	{
		var subject = new ZR_WaybillReferenceIdentification();
		//Required fields
		subject.WaybillResponseCode = "8";
		subject.EquipmentInitial = "z";
		//Test Parameters
		subject.EquipmentNumber = equipmentNumber;
		//At Least one
		subject.FreeFormMessage = "w";
		//If one filled, all required
		if(subject.WaybillNumber > 0 || subject.WaybillNumber > 0 || !string.IsNullOrEmpty(subject.Date))
		{
			subject.WaybillNumber = 2;
			subject.Date = "xImocdDb";
		}
		if(!string.IsNullOrEmpty(subject.EquipmentInitial2) || !string.IsNullOrEmpty(subject.EquipmentInitial2) || !string.IsNullOrEmpty(subject.EquipmentNumber2))
		{
			subject.EquipmentInitial2 = "n";
			subject.EquipmentNumber2 = "Y";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData(0, "", true)]
	[InlineData(2, "xImocdDb", true)]
	[InlineData(2, "", false)]
	[InlineData(0, "xImocdDb", false)]
	public void Validation_AllAreRequiredWaybillNumber(int waybillNumber, string date, bool isValidExpected)
	{
		var subject = new ZR_WaybillReferenceIdentification();
		//Required fields
		subject.WaybillResponseCode = "8";
		subject.EquipmentInitial = "z";
		subject.EquipmentNumber = "H";
		//Test Parameters
		if (waybillNumber > 0) 
			subject.WaybillNumber = waybillNumber;
		subject.Date = date;
		//At Least one
		subject.FreeFormMessage = "w";
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.EquipmentInitial2) || !string.IsNullOrEmpty(subject.EquipmentInitial2) || !string.IsNullOrEmpty(subject.EquipmentNumber2))
		{
			subject.EquipmentInitial2 = "n";
			subject.EquipmentNumber2 = "Y";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

	[Theory]
	[InlineData("", "", false)]
	[InlineData("w", "dX", true)]
	[InlineData("w", "", true)]
	[InlineData("", "dX", true)]
	public void Validation_AtLeastOneFreeFormMessage(string freeFormMessage, string standardCarrierAlphaCode, bool isValidExpected)
	{
		var subject = new ZR_WaybillReferenceIdentification();
		//Required fields
		subject.WaybillResponseCode = "8";
		subject.EquipmentInitial = "z";
		subject.EquipmentNumber = "H";
		//Test Parameters
		subject.FreeFormMessage = freeFormMessage;
		subject.StandardCarrierAlphaCode = standardCarrierAlphaCode;
		//If one filled, all required
		if(subject.WaybillNumber > 0 || subject.WaybillNumber > 0 || !string.IsNullOrEmpty(subject.Date))
		{
			subject.WaybillNumber = 2;
			subject.Date = "xImocdDb";
		}
		if(!string.IsNullOrEmpty(subject.EquipmentInitial2) || !string.IsNullOrEmpty(subject.EquipmentInitial2) || !string.IsNullOrEmpty(subject.EquipmentNumber2))
		{
			subject.EquipmentInitial2 = "n";
			subject.EquipmentNumber2 = "Y";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.AtLeastOneIsRequired);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("n", "Y", true)]
	[InlineData("n", "", false)]
	[InlineData("", "Y", false)]
	public void Validation_AllAreRequiredEquipmentInitial2(string equipmentInitial2, string equipmentNumber2, bool isValidExpected)
	{
		var subject = new ZR_WaybillReferenceIdentification();
		//Required fields
		subject.WaybillResponseCode = "8";
		subject.EquipmentInitial = "z";
		subject.EquipmentNumber = "H";
		//Test Parameters
		subject.EquipmentInitial2 = equipmentInitial2;
		subject.EquipmentNumber2 = equipmentNumber2;
		//At Least one
		subject.FreeFormMessage = "w";
		//If one filled, all required
		if(subject.WaybillNumber > 0 || subject.WaybillNumber > 0 || !string.IsNullOrEmpty(subject.Date))
		{
			subject.WaybillNumber = 2;
			subject.Date = "xImocdDb";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

}
