using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.v3010;

namespace Eddy.x12.Tests.Models.v3010;

public class CD1Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "CD1*O*6*jrMa*K*5H*f*K9*pn6tEi*V*6*nFLW5*r7*YH*5f*c*QD*7*i*uL*9*w*bs*5*K0X*Eot4F2*k*R9*0w*K*Y1*0";

		var expected = new CD1_CargoDetail()
		{
			EquipmentInitial = "O",
			EquipmentNumber = "6",
			EquipmentType = "jrMa",
			BillOfLadingWaybillNumber = "K",
			TypeOfServiceCode = "5H",
			HazardousMaterialCodeQualifier = "f",
			HazardousMaterialClassCode = "K9",
			Date = "pn6tEi",
			LocationIdentifier = "V",
			Quantity = 6,
			PackagingCode = "nFLW5",
			DispositionCode = "r7",
			DispositionCode2 = "YH",
			DispositionCode3 = "5f",
			RateClassCode = "c",
			RateValueQualifier = "QD",
			Rate = 7,
			RateClassCode2 = "i",
			RateValueQualifier2 = "uL",
			Rate2 = 9,
			RateClassCode3 = "w",
			RateValueQualifier3 = "bs",
			Rate3 = 5,
			DateTimeQualifier = "K0X",
			DeliveryDate = "Eot4F2",
			StatusCode = "k",
			StandardCarrierAlphaCode = "R9",
			ReferenceNumberQualifier = "0w",
			ReferenceNumber = "K",
			ReferenceNumberQualifier2 = "Y1",
			ReferenceNumber2 = "0",
		};

		var actual = Map.MapObject<CD1_CargoDetail>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("O", true)]
	public void Validation_RequiredEquipmentInitial(string equipmentInitial, bool isValidExpected)
	{
		var subject = new CD1_CargoDetail();
		subject.EquipmentNumber = "6";
		subject.BillOfLadingWaybillNumber = "K";
		subject.TypeOfServiceCode = "5H";
		subject.LocationIdentifier = "V";
		subject.Quantity = 6;
		subject.PackagingCode = "nFLW5";
		subject.DispositionCode = "r7";
		subject.StandardCarrierAlphaCode = "R9";
		subject.ReferenceNumberQualifier = "0w";
		subject.ReferenceNumber = "K";
		subject.ReferenceNumberQualifier2 = "Y1";
		subject.ReferenceNumber2 = "0";
		subject.EquipmentInitial = equipmentInitial;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("6", true)]
	public void Validation_RequiredEquipmentNumber(string equipmentNumber, bool isValidExpected)
	{
		var subject = new CD1_CargoDetail();
		subject.EquipmentInitial = "O";
		subject.BillOfLadingWaybillNumber = "K";
		subject.TypeOfServiceCode = "5H";
		subject.LocationIdentifier = "V";
		subject.Quantity = 6;
		subject.PackagingCode = "nFLW5";
		subject.DispositionCode = "r7";
		subject.StandardCarrierAlphaCode = "R9";
		subject.ReferenceNumberQualifier = "0w";
		subject.ReferenceNumber = "K";
		subject.ReferenceNumberQualifier2 = "Y1";
		subject.ReferenceNumber2 = "0";
		subject.EquipmentNumber = equipmentNumber;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("K", true)]
	public void Validation_RequiredBillOfLadingWaybillNumber(string billOfLadingWaybillNumber, bool isValidExpected)
	{
		var subject = new CD1_CargoDetail();
		subject.EquipmentInitial = "O";
		subject.EquipmentNumber = "6";
		subject.TypeOfServiceCode = "5H";
		subject.LocationIdentifier = "V";
		subject.Quantity = 6;
		subject.PackagingCode = "nFLW5";
		subject.DispositionCode = "r7";
		subject.StandardCarrierAlphaCode = "R9";
		subject.ReferenceNumberQualifier = "0w";
		subject.ReferenceNumber = "K";
		subject.ReferenceNumberQualifier2 = "Y1";
		subject.ReferenceNumber2 = "0";
		subject.BillOfLadingWaybillNumber = billOfLadingWaybillNumber;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("5H", true)]
	public void Validation_RequiredTypeOfServiceCode(string typeOfServiceCode, bool isValidExpected)
	{
		var subject = new CD1_CargoDetail();
		subject.EquipmentInitial = "O";
		subject.EquipmentNumber = "6";
		subject.BillOfLadingWaybillNumber = "K";
		subject.LocationIdentifier = "V";
		subject.Quantity = 6;
		subject.PackagingCode = "nFLW5";
		subject.DispositionCode = "r7";
		subject.StandardCarrierAlphaCode = "R9";
		subject.ReferenceNumberQualifier = "0w";
		subject.ReferenceNumber = "K";
		subject.ReferenceNumberQualifier2 = "Y1";
		subject.ReferenceNumber2 = "0";
		subject.TypeOfServiceCode = typeOfServiceCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("V", true)]
	public void Validation_RequiredLocationIdentifier(string locationIdentifier, bool isValidExpected)
	{
		var subject = new CD1_CargoDetail();
		subject.EquipmentInitial = "O";
		subject.EquipmentNumber = "6";
		subject.BillOfLadingWaybillNumber = "K";
		subject.TypeOfServiceCode = "5H";
		subject.Quantity = 6;
		subject.PackagingCode = "nFLW5";
		subject.DispositionCode = "r7";
		subject.StandardCarrierAlphaCode = "R9";
		subject.ReferenceNumberQualifier = "0w";
		subject.ReferenceNumber = "K";
		subject.ReferenceNumberQualifier2 = "Y1";
		subject.ReferenceNumber2 = "0";
		subject.LocationIdentifier = locationIdentifier;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData(0, false)]
	[InlineData(6, true)]
	public void Validation_RequiredQuantity(decimal quantity, bool isValidExpected)
	{
		var subject = new CD1_CargoDetail();
		subject.EquipmentInitial = "O";
		subject.EquipmentNumber = "6";
		subject.BillOfLadingWaybillNumber = "K";
		subject.TypeOfServiceCode = "5H";
		subject.LocationIdentifier = "V";
		subject.PackagingCode = "nFLW5";
		subject.DispositionCode = "r7";
		subject.StandardCarrierAlphaCode = "R9";
		subject.ReferenceNumberQualifier = "0w";
		subject.ReferenceNumber = "K";
		subject.ReferenceNumberQualifier2 = "Y1";
		subject.ReferenceNumber2 = "0";
		if (quantity > 0)
		subject.Quantity = quantity;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("nFLW5", true)]
	public void Validation_RequiredPackagingCode(string packagingCode, bool isValidExpected)
	{
		var subject = new CD1_CargoDetail();
		subject.EquipmentInitial = "O";
		subject.EquipmentNumber = "6";
		subject.BillOfLadingWaybillNumber = "K";
		subject.TypeOfServiceCode = "5H";
		subject.LocationIdentifier = "V";
		subject.Quantity = 6;
		subject.DispositionCode = "r7";
		subject.StandardCarrierAlphaCode = "R9";
		subject.ReferenceNumberQualifier = "0w";
		subject.ReferenceNumber = "K";
		subject.ReferenceNumberQualifier2 = "Y1";
		subject.ReferenceNumber2 = "0";
		subject.PackagingCode = packagingCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("r7", true)]
	public void Validation_RequiredDispositionCode(string dispositionCode, bool isValidExpected)
	{
		var subject = new CD1_CargoDetail();
		subject.EquipmentInitial = "O";
		subject.EquipmentNumber = "6";
		subject.BillOfLadingWaybillNumber = "K";
		subject.TypeOfServiceCode = "5H";
		subject.LocationIdentifier = "V";
		subject.Quantity = 6;
		subject.PackagingCode = "nFLW5";
		subject.StandardCarrierAlphaCode = "R9";
		subject.ReferenceNumberQualifier = "0w";
		subject.ReferenceNumber = "K";
		subject.ReferenceNumberQualifier2 = "Y1";
		subject.ReferenceNumber2 = "0";
		subject.DispositionCode = dispositionCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("R9", true)]
	public void Validation_RequiredStandardCarrierAlphaCode(string standardCarrierAlphaCode, bool isValidExpected)
	{
		var subject = new CD1_CargoDetail();
		subject.EquipmentInitial = "O";
		subject.EquipmentNumber = "6";
		subject.BillOfLadingWaybillNumber = "K";
		subject.TypeOfServiceCode = "5H";
		subject.LocationIdentifier = "V";
		subject.Quantity = 6;
		subject.PackagingCode = "nFLW5";
		subject.DispositionCode = "r7";
		subject.ReferenceNumberQualifier = "0w";
		subject.ReferenceNumber = "K";
		subject.ReferenceNumberQualifier2 = "Y1";
		subject.ReferenceNumber2 = "0";
		subject.StandardCarrierAlphaCode = standardCarrierAlphaCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("0w", true)]
	public void Validation_RequiredReferenceNumberQualifier(string referenceNumberQualifier, bool isValidExpected)
	{
		var subject = new CD1_CargoDetail();
		subject.EquipmentInitial = "O";
		subject.EquipmentNumber = "6";
		subject.BillOfLadingWaybillNumber = "K";
		subject.TypeOfServiceCode = "5H";
		subject.LocationIdentifier = "V";
		subject.Quantity = 6;
		subject.PackagingCode = "nFLW5";
		subject.DispositionCode = "r7";
		subject.StandardCarrierAlphaCode = "R9";
		subject.ReferenceNumber = "K";
		subject.ReferenceNumberQualifier2 = "Y1";
		subject.ReferenceNumber2 = "0";
		subject.ReferenceNumberQualifier = referenceNumberQualifier;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("K", true)]
	public void Validation_RequiredReferenceNumber(string referenceNumber, bool isValidExpected)
	{
		var subject = new CD1_CargoDetail();
		subject.EquipmentInitial = "O";
		subject.EquipmentNumber = "6";
		subject.BillOfLadingWaybillNumber = "K";
		subject.TypeOfServiceCode = "5H";
		subject.LocationIdentifier = "V";
		subject.Quantity = 6;
		subject.PackagingCode = "nFLW5";
		subject.DispositionCode = "r7";
		subject.StandardCarrierAlphaCode = "R9";
		subject.ReferenceNumberQualifier = "0w";
		subject.ReferenceNumberQualifier2 = "Y1";
		subject.ReferenceNumber2 = "0";
		subject.ReferenceNumber = referenceNumber;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("Y1", true)]
	public void Validation_RequiredReferenceNumberQualifier2(string referenceNumberQualifier2, bool isValidExpected)
	{
		var subject = new CD1_CargoDetail();
		subject.EquipmentInitial = "O";
		subject.EquipmentNumber = "6";
		subject.BillOfLadingWaybillNumber = "K";
		subject.TypeOfServiceCode = "5H";
		subject.LocationIdentifier = "V";
		subject.Quantity = 6;
		subject.PackagingCode = "nFLW5";
		subject.DispositionCode = "r7";
		subject.StandardCarrierAlphaCode = "R9";
		subject.ReferenceNumberQualifier = "0w";
		subject.ReferenceNumber = "K";
		subject.ReferenceNumber2 = "0";
		subject.ReferenceNumberQualifier2 = referenceNumberQualifier2;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("0", true)]
	public void Validation_RequiredReferenceNumber2(string referenceNumber2, bool isValidExpected)
	{
		var subject = new CD1_CargoDetail();
		subject.EquipmentInitial = "O";
		subject.EquipmentNumber = "6";
		subject.BillOfLadingWaybillNumber = "K";
		subject.TypeOfServiceCode = "5H";
		subject.LocationIdentifier = "V";
		subject.Quantity = 6;
		subject.PackagingCode = "nFLW5";
		subject.DispositionCode = "r7";
		subject.StandardCarrierAlphaCode = "R9";
		subject.ReferenceNumberQualifier = "0w";
		subject.ReferenceNumber = "K";
		subject.ReferenceNumberQualifier2 = "Y1";
		subject.ReferenceNumber2 = referenceNumber2;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
