using EdiParser.Validation;
using EdiParser.x12.Mapping;
using EdiParser.x12.Models;

namespace EdiParser.Tests.x12.Models;

public class CD1Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "CD1*9*p*2GON*p*Dn*0*B*nCkH71WK*I*2*V8Y*So*Q9*R4*y*GF*8*n*9E*1*q*We*2*nAY*3kJlx5Ze*N*jy*sG*g*ZV*h";

		var expected = new CD1_CargoDetail()
		{
			EquipmentInitial = "9",
			EquipmentNumber = "p",
			EquipmentTypeCode = "2GON",
			BillOfLadingWaybillNumber = "p",
			TypeOfServiceCode = "Dn",
			HazardousMaterialCodeQualifier = "0",
			HazardousMaterialClassCode = "B",
			Date = "nCkH71WK",
			LocationIdentifier = "I",
			Quantity = 2,
			PackagingCode = "V8Y",
			BillOfLadingDispositionCode = "So",
			BillOfLadingDispositionCode2 = "Q9",
			BillOfLadingDispositionCode3 = "R4",
			RateClassCode = "y",
			RateValueQualifier = "GF",
			Rate = 8,
			RateClassCode2 = "n",
			RateValueQualifier2 = "9E",
			Rate2 = 1,
			RateClassCode3 = "q",
			RateValueQualifier3 = "We",
			Rate3 = 2,
			DateTimeQualifier = "nAY",
			Date2 = "3kJlx5Ze",
			ShipmentStatusCode = "N",
			StandardCarrierAlphaCode = "jy",
			ReferenceIdentificationQualifier = "sG",
			ReferenceIdentification = "g",
			ReferenceIdentificationQualifier2 = "ZV",
			ReferenceIdentification2 = "h",
		};

		var actual = Map.MapObject<CD1_CargoDetail>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("9", true)]
	public void Validatation_RequiredEquipmentInitial(string equipmentInitial, bool isValidExpected)
	{
		var subject = new CD1_CargoDetail();
		subject.EquipmentNumber = "p";
		subject.BillOfLadingWaybillNumber = "p";
		subject.TypeOfServiceCode = "Dn";
		subject.LocationIdentifier = "I";
		subject.Quantity = 2;
		subject.PackagingCode = "V8Y";
		subject.BillOfLadingDispositionCode = "So";
		subject.StandardCarrierAlphaCode = "jy";
		subject.ReferenceIdentificationQualifier = "sG";
		subject.ReferenceIdentification = "g";
		subject.ReferenceIdentificationQualifier2 = "ZV";
		subject.ReferenceIdentification2 = "h";
		subject.EquipmentInitial = equipmentInitial;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("p", true)]
	public void Validatation_RequiredEquipmentNumber(string equipmentNumber, bool isValidExpected)
	{
		var subject = new CD1_CargoDetail();
		subject.EquipmentInitial = "9";
		subject.BillOfLadingWaybillNumber = "p";
		subject.TypeOfServiceCode = "Dn";
		subject.LocationIdentifier = "I";
		subject.Quantity = 2;
		subject.PackagingCode = "V8Y";
		subject.BillOfLadingDispositionCode = "So";
		subject.StandardCarrierAlphaCode = "jy";
		subject.ReferenceIdentificationQualifier = "sG";
		subject.ReferenceIdentification = "g";
		subject.ReferenceIdentificationQualifier2 = "ZV";
		subject.ReferenceIdentification2 = "h";
		subject.EquipmentNumber = equipmentNumber;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("p", true)]
	public void Validatation_RequiredBillOfLadingWaybillNumber(string billOfLadingWaybillNumber, bool isValidExpected)
	{
		var subject = new CD1_CargoDetail();
		subject.EquipmentInitial = "9";
		subject.EquipmentNumber = "p";
		subject.TypeOfServiceCode = "Dn";
		subject.LocationIdentifier = "I";
		subject.Quantity = 2;
		subject.PackagingCode = "V8Y";
		subject.BillOfLadingDispositionCode = "So";
		subject.StandardCarrierAlphaCode = "jy";
		subject.ReferenceIdentificationQualifier = "sG";
		subject.ReferenceIdentification = "g";
		subject.ReferenceIdentificationQualifier2 = "ZV";
		subject.ReferenceIdentification2 = "h";
		subject.BillOfLadingWaybillNumber = billOfLadingWaybillNumber;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("Dn", true)]
	public void Validatation_RequiredTypeOfServiceCode(string typeOfServiceCode, bool isValidExpected)
	{
		var subject = new CD1_CargoDetail();
		subject.EquipmentInitial = "9";
		subject.EquipmentNumber = "p";
		subject.BillOfLadingWaybillNumber = "p";
		subject.LocationIdentifier = "I";
		subject.Quantity = 2;
		subject.PackagingCode = "V8Y";
		subject.BillOfLadingDispositionCode = "So";
		subject.StandardCarrierAlphaCode = "jy";
		subject.ReferenceIdentificationQualifier = "sG";
		subject.ReferenceIdentification = "g";
		subject.ReferenceIdentificationQualifier2 = "ZV";
		subject.ReferenceIdentification2 = "h";
		subject.TypeOfServiceCode = typeOfServiceCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("I", true)]
	public void Validatation_RequiredLocationIdentifier(string locationIdentifier, bool isValidExpected)
	{
		var subject = new CD1_CargoDetail();
		subject.EquipmentInitial = "9";
		subject.EquipmentNumber = "p";
		subject.BillOfLadingWaybillNumber = "p";
		subject.TypeOfServiceCode = "Dn";
		subject.Quantity = 2;
		subject.PackagingCode = "V8Y";
		subject.BillOfLadingDispositionCode = "So";
		subject.StandardCarrierAlphaCode = "jy";
		subject.ReferenceIdentificationQualifier = "sG";
		subject.ReferenceIdentification = "g";
		subject.ReferenceIdentificationQualifier2 = "ZV";
		subject.ReferenceIdentification2 = "h";
		subject.LocationIdentifier = locationIdentifier;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData(0, false)]
	[InlineData(2, true)]
	public void Validatation_RequiredQuantity(decimal quantity, bool isValidExpected)
	{
		var subject = new CD1_CargoDetail();
		subject.EquipmentInitial = "9";
		subject.EquipmentNumber = "p";
		subject.BillOfLadingWaybillNumber = "p";
		subject.TypeOfServiceCode = "Dn";
		subject.LocationIdentifier = "I";
		subject.PackagingCode = "V8Y";
		subject.BillOfLadingDispositionCode = "So";
		subject.StandardCarrierAlphaCode = "jy";
		subject.ReferenceIdentificationQualifier = "sG";
		subject.ReferenceIdentification = "g";
		subject.ReferenceIdentificationQualifier2 = "ZV";
		subject.ReferenceIdentification2 = "h";
		if (quantity > 0)
		subject.Quantity = quantity;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("V8Y", true)]
	public void Validatation_RequiredPackagingCode(string packagingCode, bool isValidExpected)
	{
		var subject = new CD1_CargoDetail();
		subject.EquipmentInitial = "9";
		subject.EquipmentNumber = "p";
		subject.BillOfLadingWaybillNumber = "p";
		subject.TypeOfServiceCode = "Dn";
		subject.LocationIdentifier = "I";
		subject.Quantity = 2;
		subject.BillOfLadingDispositionCode = "So";
		subject.StandardCarrierAlphaCode = "jy";
		subject.ReferenceIdentificationQualifier = "sG";
		subject.ReferenceIdentification = "g";
		subject.ReferenceIdentificationQualifier2 = "ZV";
		subject.ReferenceIdentification2 = "h";
		subject.PackagingCode = packagingCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("So", true)]
	public void Validatation_RequiredBillOfLadingDispositionCode(string billOfLadingDispositionCode, bool isValidExpected)
	{
		var subject = new CD1_CargoDetail();
		subject.EquipmentInitial = "9";
		subject.EquipmentNumber = "p";
		subject.BillOfLadingWaybillNumber = "p";
		subject.TypeOfServiceCode = "Dn";
		subject.LocationIdentifier = "I";
		subject.Quantity = 2;
		subject.PackagingCode = "V8Y";
		subject.StandardCarrierAlphaCode = "jy";
		subject.ReferenceIdentificationQualifier = "sG";
		subject.ReferenceIdentification = "g";
		subject.ReferenceIdentificationQualifier2 = "ZV";
		subject.ReferenceIdentification2 = "h";
		subject.BillOfLadingDispositionCode = billOfLadingDispositionCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("jy", true)]
	public void Validatation_RequiredStandardCarrierAlphaCode(string standardCarrierAlphaCode, bool isValidExpected)
	{
		var subject = new CD1_CargoDetail();
		subject.EquipmentInitial = "9";
		subject.EquipmentNumber = "p";
		subject.BillOfLadingWaybillNumber = "p";
		subject.TypeOfServiceCode = "Dn";
		subject.LocationIdentifier = "I";
		subject.Quantity = 2;
		subject.PackagingCode = "V8Y";
		subject.BillOfLadingDispositionCode = "So";
		subject.ReferenceIdentificationQualifier = "sG";
		subject.ReferenceIdentification = "g";
		subject.ReferenceIdentificationQualifier2 = "ZV";
		subject.ReferenceIdentification2 = "h";
		subject.StandardCarrierAlphaCode = standardCarrierAlphaCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("sG", true)]
	public void Validatation_RequiredReferenceIdentificationQualifier(string referenceIdentificationQualifier, bool isValidExpected)
	{
		var subject = new CD1_CargoDetail();
		subject.EquipmentInitial = "9";
		subject.EquipmentNumber = "p";
		subject.BillOfLadingWaybillNumber = "p";
		subject.TypeOfServiceCode = "Dn";
		subject.LocationIdentifier = "I";
		subject.Quantity = 2;
		subject.PackagingCode = "V8Y";
		subject.BillOfLadingDispositionCode = "So";
		subject.StandardCarrierAlphaCode = "jy";
		subject.ReferenceIdentification = "g";
		subject.ReferenceIdentificationQualifier2 = "ZV";
		subject.ReferenceIdentification2 = "h";
		subject.ReferenceIdentificationQualifier = referenceIdentificationQualifier;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("g", true)]
	public void Validatation_RequiredReferenceIdentification(string referenceIdentification, bool isValidExpected)
	{
		var subject = new CD1_CargoDetail();
		subject.EquipmentInitial = "9";
		subject.EquipmentNumber = "p";
		subject.BillOfLadingWaybillNumber = "p";
		subject.TypeOfServiceCode = "Dn";
		subject.LocationIdentifier = "I";
		subject.Quantity = 2;
		subject.PackagingCode = "V8Y";
		subject.BillOfLadingDispositionCode = "So";
		subject.StandardCarrierAlphaCode = "jy";
		subject.ReferenceIdentificationQualifier = "sG";
		subject.ReferenceIdentificationQualifier2 = "ZV";
		subject.ReferenceIdentification2 = "h";
		subject.ReferenceIdentification = referenceIdentification;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("ZV", true)]
	public void Validatation_RequiredReferenceIdentificationQualifier2(string referenceIdentificationQualifier2, bool isValidExpected)
	{
		var subject = new CD1_CargoDetail();
		subject.EquipmentInitial = "9";
		subject.EquipmentNumber = "p";
		subject.BillOfLadingWaybillNumber = "p";
		subject.TypeOfServiceCode = "Dn";
		subject.LocationIdentifier = "I";
		subject.Quantity = 2;
		subject.PackagingCode = "V8Y";
		subject.BillOfLadingDispositionCode = "So";
		subject.StandardCarrierAlphaCode = "jy";
		subject.ReferenceIdentificationQualifier = "sG";
		subject.ReferenceIdentification = "g";
		subject.ReferenceIdentification2 = "h";
		subject.ReferenceIdentificationQualifier2 = referenceIdentificationQualifier2;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("h", true)]
	public void Validatation_RequiredReferenceIdentification2(string referenceIdentification2, bool isValidExpected)
	{
		var subject = new CD1_CargoDetail();
		subject.EquipmentInitial = "9";
		subject.EquipmentNumber = "p";
		subject.BillOfLadingWaybillNumber = "p";
		subject.TypeOfServiceCode = "Dn";
		subject.LocationIdentifier = "I";
		subject.Quantity = 2;
		subject.PackagingCode = "V8Y";
		subject.BillOfLadingDispositionCode = "So";
		subject.StandardCarrierAlphaCode = "jy";
		subject.ReferenceIdentificationQualifier = "sG";
		subject.ReferenceIdentification = "g";
		subject.ReferenceIdentificationQualifier2 = "ZV";
		subject.ReferenceIdentification2 = referenceIdentification2;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
