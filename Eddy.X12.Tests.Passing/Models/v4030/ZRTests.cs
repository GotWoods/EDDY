using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v4030;

namespace Eddy.x12.Tests.Models.v4030;

public class ZRTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "ZR*h*F*M*9*NteV0ChE*b*5u*2IH28Fn4*4k*el*X*d*sU*5*Z*3";

		var expected = new ZR_WaybillReferenceIdentification()
		{
			WaybillResponseCode = "h",
			EquipmentInitial = "F",
			EquipmentNumber = "M",
			WaybillNumber = 9,
			Date = "NteV0ChE",
			FreeFormMessage = "b",
			StandardCarrierAlphaCode = "5u",
			Date2 = "2IH28Fn4",
			InterlineSettlementSystemStatusActionOrDisputeCode = "4k",
			InterlineSettlementSystemStatusActionOrDisputeCode2 = "el",
			ReferenceIdentification = "X",
			ReferenceIdentification2 = "d",
			CorrectionIndicator = "sU",
			EquipmentNumberCheckDigit = 5,
			EquipmentInitial2 = "Z",
			EquipmentNumber2 = "3",
		};

		var actual = Map.MapObject<ZR_WaybillReferenceIdentification>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("h", true)]
	public void Validation_RequiredWaybillResponseCode(string waybillResponseCode, bool isValidExpected)
	{
		var subject = new ZR_WaybillReferenceIdentification();
		//Required fields
		subject.EquipmentInitial = "F";
		subject.EquipmentNumber = "M";
		//Test Parameters
		subject.WaybillResponseCode = waybillResponseCode;
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.EquipmentInitial2) || !string.IsNullOrEmpty(subject.EquipmentInitial2) || !string.IsNullOrEmpty(subject.EquipmentNumber2))
		{
			subject.EquipmentInitial2 = "Z";
			subject.EquipmentNumber2 = "3";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("F", true)]
	public void Validation_RequiredEquipmentInitial(string equipmentInitial, bool isValidExpected)
	{
		var subject = new ZR_WaybillReferenceIdentification();
		//Required fields
		subject.WaybillResponseCode = "h";
		subject.EquipmentNumber = "M";
		//Test Parameters
		subject.EquipmentInitial = equipmentInitial;
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.EquipmentInitial2) || !string.IsNullOrEmpty(subject.EquipmentInitial2) || !string.IsNullOrEmpty(subject.EquipmentNumber2))
		{
			subject.EquipmentInitial2 = "Z";
			subject.EquipmentNumber2 = "3";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("M", true)]
	public void Validation_RequiredEquipmentNumber(string equipmentNumber, bool isValidExpected)
	{
		var subject = new ZR_WaybillReferenceIdentification();
		//Required fields
		subject.WaybillResponseCode = "h";
		subject.EquipmentInitial = "F";
		//Test Parameters
		subject.EquipmentNumber = equipmentNumber;
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.EquipmentInitial2) || !string.IsNullOrEmpty(subject.EquipmentInitial2) || !string.IsNullOrEmpty(subject.EquipmentNumber2))
		{
			subject.EquipmentInitial2 = "Z";
			subject.EquipmentNumber2 = "3";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("Z", "3", true)]
	[InlineData("Z", "", false)]
	[InlineData("", "3", false)]
	public void Validation_AllAreRequiredEquipmentInitial2(string equipmentInitial2, string equipmentNumber2, bool isValidExpected)
	{
		var subject = new ZR_WaybillReferenceIdentification();
		//Required fields
		subject.WaybillResponseCode = "h";
		subject.EquipmentInitial = "F";
		subject.EquipmentNumber = "M";
		//Test Parameters
		subject.EquipmentInitial2 = equipmentInitial2;
		subject.EquipmentNumber2 = equipmentNumber2;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

}
