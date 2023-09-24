using Eddy.Core.Validation;
using Eddy.x12.Mapping;
using Eddy.x12.Models;

namespace Eddy.Tests.x12.Models;

public class ZRTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "ZR*n*m*L*1*ZSuesUBZ*k*fV*mvWoUF5o*fM*vF*4*R*t3*4*4*Z";

		var expected = new ZR_WaybillReferenceIdentification()
		{
			WaybillResponseCode = "n",
			EquipmentInitial = "m",
			EquipmentNumber = "L",
			WaybillNumber = 1,
			Date = "ZSuesUBZ",
			FreeFormMessage = "k",
			StandardCarrierAlphaCode = "fV",
			Date2 = "mvWoUF5o",
			InterlineSettlementSystemStatusActionOrDisputeCode = "fM",
			InterlineSettlementSystemStatusActionOrDisputeCode2 = "vF",
			ReferenceIdentification = "4",
			ReferenceIdentification2 = "R",
			CorrectionIndicatorCode = "t3",
			EquipmentNumberCheckDigit = 4,
			EquipmentInitial2 = "4",
			EquipmentNumber2 = "Z",
		};

		var actual = Map.MapObject<ZR_WaybillReferenceIdentification>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("n", true)]
	public void Validation_RequiredWaybillResponseCode(string waybillResponseCode, bool isValidExpected)
	{
		var subject = new ZR_WaybillReferenceIdentification();
		subject.EquipmentInitial = "m";
		subject.EquipmentNumber = "L";
		subject.WaybillResponseCode = waybillResponseCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("m", true)]
	public void Validation_RequiredEquipmentInitial(string equipmentInitial, bool isValidExpected)
	{
		var subject = new ZR_WaybillReferenceIdentification();
		subject.WaybillResponseCode = "n";
		subject.EquipmentNumber = "L";
		subject.EquipmentInitial = equipmentInitial;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("L", true)]
	public void Validation_RequiredEquipmentNumber(string equipmentNumber, bool isValidExpected)
	{
		var subject = new ZR_WaybillReferenceIdentification();
		subject.WaybillResponseCode = "n";
		subject.EquipmentInitial = "m";
		subject.EquipmentNumber = equipmentNumber;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData(0,"", true)]
	[InlineData(1, "ZSuesUBZ", true)]
	[InlineData(0, "ZSuesUBZ", false)]
	[InlineData(1, "", false)]
	public void Validation_AllAreRequiredWaybillNumber(int waybillNumber, string date, bool isValidExpected)
	{
		var subject = new ZR_WaybillReferenceIdentification();
		subject.WaybillResponseCode = "n";
		subject.EquipmentInitial = "m";
		subject.EquipmentNumber = "L";
		if (waybillNumber > 0)
		subject.WaybillNumber = waybillNumber;
		subject.Date = date;

		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

	[Theory]
	[InlineData("","", true)]
	[InlineData("4", "Z", true)]
	[InlineData("", "Z", false)]
	[InlineData("4", "", false)]
	public void Validation_AllAreRequiredEquipmentInitial2(string equipmentInitial2, string equipmentNumber2, bool isValidExpected)
	{
		var subject = new ZR_WaybillReferenceIdentification();
		subject.WaybillResponseCode = "n";
		subject.EquipmentInitial = "m";
		subject.EquipmentNumber = "L";
		subject.EquipmentInitial2 = equipmentInitial2;
		subject.EquipmentNumber2 = equipmentNumber2;

		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

}
