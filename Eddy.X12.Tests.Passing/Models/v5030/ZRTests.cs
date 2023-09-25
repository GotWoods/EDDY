using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v5030;

namespace Eddy.x12.Tests.Models.v5030;

public class ZRTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "ZR*F*E*W*3*ab3Ri8yl*Z*Op*bQW98kew*bh*rF*q*n*U7*8*7*T";

		var expected = new ZR_WaybillReferenceIdentification()
		{
			WaybillResponseCode = "F",
			EquipmentInitial = "E",
			EquipmentNumber = "W",
			WaybillNumber = 3,
			Date = "ab3Ri8yl",
			FreeFormMessage = "Z",
			StandardCarrierAlphaCode = "Op",
			Date2 = "bQW98kew",
			InterlineSettlementSystemStatusActionOrDisputeCode = "bh",
			InterlineSettlementSystemStatusActionOrDisputeCode2 = "rF",
			ReferenceIdentification = "q",
			ReferenceIdentification2 = "n",
			CorrectionIndicator = "U7",
			EquipmentNumberCheckDigit = 8,
			EquipmentInitial2 = "7",
			EquipmentNumber2 = "T",
		};

		var actual = Map.MapObject<ZR_WaybillReferenceIdentification>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("F", true)]
	public void Validation_RequiredWaybillResponseCode(string waybillResponseCode, bool isValidExpected)
	{
		var subject = new ZR_WaybillReferenceIdentification();
		//Required fields
		subject.EquipmentInitial = "E";
		subject.EquipmentNumber = "W";
		//Test Parameters
		subject.WaybillResponseCode = waybillResponseCode;
		//At Least one
		subject.FreeFormMessage = "Z";
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.EquipmentInitial2) || !string.IsNullOrEmpty(subject.EquipmentInitial2) || !string.IsNullOrEmpty(subject.EquipmentNumber2))
		{
			subject.EquipmentInitial2 = "7";
			subject.EquipmentNumber2 = "T";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("E", true)]
	public void Validation_RequiredEquipmentInitial(string equipmentInitial, bool isValidExpected)
	{
		var subject = new ZR_WaybillReferenceIdentification();
		//Required fields
		subject.WaybillResponseCode = "F";
		subject.EquipmentNumber = "W";
		//Test Parameters
		subject.EquipmentInitial = equipmentInitial;
		//At Least one
		subject.FreeFormMessage = "Z";
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.EquipmentInitial2) || !string.IsNullOrEmpty(subject.EquipmentInitial2) || !string.IsNullOrEmpty(subject.EquipmentNumber2))
		{
			subject.EquipmentInitial2 = "7";
			subject.EquipmentNumber2 = "T";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("W", true)]
	public void Validation_RequiredEquipmentNumber(string equipmentNumber, bool isValidExpected)
	{
		var subject = new ZR_WaybillReferenceIdentification();
		//Required fields
		subject.WaybillResponseCode = "F";
		subject.EquipmentInitial = "E";
		//Test Parameters
		subject.EquipmentNumber = equipmentNumber;
		//At Least one
		subject.FreeFormMessage = "Z";
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.EquipmentInitial2) || !string.IsNullOrEmpty(subject.EquipmentInitial2) || !string.IsNullOrEmpty(subject.EquipmentNumber2))
		{
			subject.EquipmentInitial2 = "7";
			subject.EquipmentNumber2 = "T";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", "", false)]
	[InlineData("Z", "Op", true)]
	[InlineData("Z", "", true)]
	[InlineData("", "Op", true)]
	public void Validation_AtLeastOneFreeFormMessage(string freeFormMessage, string standardCarrierAlphaCode, bool isValidExpected)
	{
		var subject = new ZR_WaybillReferenceIdentification();
		//Required fields
		subject.WaybillResponseCode = "F";
		subject.EquipmentInitial = "E";
		subject.EquipmentNumber = "W";
		//Test Parameters
		subject.FreeFormMessage = freeFormMessage;
		subject.StandardCarrierAlphaCode = standardCarrierAlphaCode;
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.EquipmentInitial2) || !string.IsNullOrEmpty(subject.EquipmentInitial2) || !string.IsNullOrEmpty(subject.EquipmentNumber2))
		{
			subject.EquipmentInitial2 = "7";
			subject.EquipmentNumber2 = "T";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.AtLeastOneIsRequired);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("7", "T", true)]
	[InlineData("7", "", false)]
	[InlineData("", "T", false)]
	public void Validation_AllAreRequiredEquipmentInitial2(string equipmentInitial2, string equipmentNumber2, bool isValidExpected)
	{
		var subject = new ZR_WaybillReferenceIdentification();
		//Required fields
		subject.WaybillResponseCode = "F";
		subject.EquipmentInitial = "E";
		subject.EquipmentNumber = "W";
		//Test Parameters
		subject.EquipmentInitial2 = equipmentInitial2;
		subject.EquipmentNumber2 = equipmentNumber2;
		//At Least one
		subject.FreeFormMessage = "Z";
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

}
