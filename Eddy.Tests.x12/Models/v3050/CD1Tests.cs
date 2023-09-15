using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3050;

namespace Eddy.x12.Tests.Models.v3050;

public class CD1Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "CD1*p*p*V09Q*F*Vr*I*Fv*M7OxtQ*I*9*TgZ*xf*VM*dN*R*AE*6*4*Tx*7*E*hK*1*eDS*ATru3K*V*fV*T1*0*rJ*f";

		var expected = new CD1_CargoDetail()
		{
			EquipmentInitial = "p",
			EquipmentNumber = "p",
			EquipmentType = "V09Q",
			BillOfLadingWaybillNumber = "F",
			TypeOfServiceCode = "Vr",
			HazardousMaterialCodeQualifier = "I",
			HazardousMaterialClassCode = "Fv",
			Date = "M7OxtQ",
			LocationIdentifier = "I",
			Quantity = 9,
			PackagingCode = "TgZ",
			DispositionCode = "xf",
			DispositionCode2 = "VM",
			DispositionCode3 = "dN",
			RateClassCode = "R",
			RateValueQualifier = "AE",
			Rate = 6,
			RateClassCode2 = "4",
			RateValueQualifier2 = "Tx",
			Rate2 = 7,
			RateClassCode3 = "E",
			RateValueQualifier3 = "hK",
			Rate3 = 1,
			DateTimeQualifier = "eDS",
			Date2 = "ATru3K",
			StatusCode = "V",
			StandardCarrierAlphaCode = "fV",
			ReferenceNumberQualifier = "T1",
			ReferenceNumber = "0",
			ReferenceNumberQualifier2 = "rJ",
			ReferenceNumber2 = "f",
		};

		var actual = Map.MapObject<CD1_CargoDetail>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("p", true)]
	public void Validation_RequiredEquipmentInitial(string equipmentInitial, bool isValidExpected)
	{
		var subject = new CD1_CargoDetail();
		subject.EquipmentNumber = "p";
		subject.BillOfLadingWaybillNumber = "F";
		subject.TypeOfServiceCode = "Vr";
		subject.LocationIdentifier = "I";
		subject.Quantity = 9;
		subject.PackagingCode = "TgZ";
		subject.DispositionCode = "xf";
		subject.StandardCarrierAlphaCode = "fV";
		subject.ReferenceNumberQualifier = "T1";
		subject.ReferenceNumber = "0";
		subject.ReferenceNumberQualifier2 = "rJ";
		subject.ReferenceNumber2 = "f";
		subject.EquipmentInitial = equipmentInitial;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("p", true)]
	public void Validation_RequiredEquipmentNumber(string equipmentNumber, bool isValidExpected)
	{
		var subject = new CD1_CargoDetail();
		subject.EquipmentInitial = "p";
		subject.BillOfLadingWaybillNumber = "F";
		subject.TypeOfServiceCode = "Vr";
		subject.LocationIdentifier = "I";
		subject.Quantity = 9;
		subject.PackagingCode = "TgZ";
		subject.DispositionCode = "xf";
		subject.StandardCarrierAlphaCode = "fV";
		subject.ReferenceNumberQualifier = "T1";
		subject.ReferenceNumber = "0";
		subject.ReferenceNumberQualifier2 = "rJ";
		subject.ReferenceNumber2 = "f";
		subject.EquipmentNumber = equipmentNumber;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("F", true)]
	public void Validation_RequiredBillOfLadingWaybillNumber(string billOfLadingWaybillNumber, bool isValidExpected)
	{
		var subject = new CD1_CargoDetail();
		subject.EquipmentInitial = "p";
		subject.EquipmentNumber = "p";
		subject.TypeOfServiceCode = "Vr";
		subject.LocationIdentifier = "I";
		subject.Quantity = 9;
		subject.PackagingCode = "TgZ";
		subject.DispositionCode = "xf";
		subject.StandardCarrierAlphaCode = "fV";
		subject.ReferenceNumberQualifier = "T1";
		subject.ReferenceNumber = "0";
		subject.ReferenceNumberQualifier2 = "rJ";
		subject.ReferenceNumber2 = "f";
		subject.BillOfLadingWaybillNumber = billOfLadingWaybillNumber;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("Vr", true)]
	public void Validation_RequiredTypeOfServiceCode(string typeOfServiceCode, bool isValidExpected)
	{
		var subject = new CD1_CargoDetail();
		subject.EquipmentInitial = "p";
		subject.EquipmentNumber = "p";
		subject.BillOfLadingWaybillNumber = "F";
		subject.LocationIdentifier = "I";
		subject.Quantity = 9;
		subject.PackagingCode = "TgZ";
		subject.DispositionCode = "xf";
		subject.StandardCarrierAlphaCode = "fV";
		subject.ReferenceNumberQualifier = "T1";
		subject.ReferenceNumber = "0";
		subject.ReferenceNumberQualifier2 = "rJ";
		subject.ReferenceNumber2 = "f";
		subject.TypeOfServiceCode = typeOfServiceCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("I", true)]
	public void Validation_RequiredLocationIdentifier(string locationIdentifier, bool isValidExpected)
	{
		var subject = new CD1_CargoDetail();
		subject.EquipmentInitial = "p";
		subject.EquipmentNumber = "p";
		subject.BillOfLadingWaybillNumber = "F";
		subject.TypeOfServiceCode = "Vr";
		subject.Quantity = 9;
		subject.PackagingCode = "TgZ";
		subject.DispositionCode = "xf";
		subject.StandardCarrierAlphaCode = "fV";
		subject.ReferenceNumberQualifier = "T1";
		subject.ReferenceNumber = "0";
		subject.ReferenceNumberQualifier2 = "rJ";
		subject.ReferenceNumber2 = "f";
		subject.LocationIdentifier = locationIdentifier;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData(0, false)]
	[InlineData(9, true)]
	public void Validation_RequiredQuantity(decimal quantity, bool isValidExpected)
	{
		var subject = new CD1_CargoDetail();
		subject.EquipmentInitial = "p";
		subject.EquipmentNumber = "p";
		subject.BillOfLadingWaybillNumber = "F";
		subject.TypeOfServiceCode = "Vr";
		subject.LocationIdentifier = "I";
		subject.PackagingCode = "TgZ";
		subject.DispositionCode = "xf";
		subject.StandardCarrierAlphaCode = "fV";
		subject.ReferenceNumberQualifier = "T1";
		subject.ReferenceNumber = "0";
		subject.ReferenceNumberQualifier2 = "rJ";
		subject.ReferenceNumber2 = "f";
		if (quantity > 0)
			subject.Quantity = quantity;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("TgZ", true)]
	public void Validation_RequiredPackagingCode(string packagingCode, bool isValidExpected)
	{
		var subject = new CD1_CargoDetail();
		subject.EquipmentInitial = "p";
		subject.EquipmentNumber = "p";
		subject.BillOfLadingWaybillNumber = "F";
		subject.TypeOfServiceCode = "Vr";
		subject.LocationIdentifier = "I";
		subject.Quantity = 9;
		subject.DispositionCode = "xf";
		subject.StandardCarrierAlphaCode = "fV";
		subject.ReferenceNumberQualifier = "T1";
		subject.ReferenceNumber = "0";
		subject.ReferenceNumberQualifier2 = "rJ";
		subject.ReferenceNumber2 = "f";
		subject.PackagingCode = packagingCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("xf", true)]
	public void Validation_RequiredDispositionCode(string dispositionCode, bool isValidExpected)
	{
		var subject = new CD1_CargoDetail();
		subject.EquipmentInitial = "p";
		subject.EquipmentNumber = "p";
		subject.BillOfLadingWaybillNumber = "F";
		subject.TypeOfServiceCode = "Vr";
		subject.LocationIdentifier = "I";
		subject.Quantity = 9;
		subject.PackagingCode = "TgZ";
		subject.StandardCarrierAlphaCode = "fV";
		subject.ReferenceNumberQualifier = "T1";
		subject.ReferenceNumber = "0";
		subject.ReferenceNumberQualifier2 = "rJ";
		subject.ReferenceNumber2 = "f";
		subject.DispositionCode = dispositionCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("fV", true)]
	public void Validation_RequiredStandardCarrierAlphaCode(string standardCarrierAlphaCode, bool isValidExpected)
	{
		var subject = new CD1_CargoDetail();
		subject.EquipmentInitial = "p";
		subject.EquipmentNumber = "p";
		subject.BillOfLadingWaybillNumber = "F";
		subject.TypeOfServiceCode = "Vr";
		subject.LocationIdentifier = "I";
		subject.Quantity = 9;
		subject.PackagingCode = "TgZ";
		subject.DispositionCode = "xf";
		subject.ReferenceNumberQualifier = "T1";
		subject.ReferenceNumber = "0";
		subject.ReferenceNumberQualifier2 = "rJ";
		subject.ReferenceNumber2 = "f";
		subject.StandardCarrierAlphaCode = standardCarrierAlphaCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("T1", true)]
	public void Validation_RequiredReferenceNumberQualifier(string referenceNumberQualifier, bool isValidExpected)
	{
		var subject = new CD1_CargoDetail();
		subject.EquipmentInitial = "p";
		subject.EquipmentNumber = "p";
		subject.BillOfLadingWaybillNumber = "F";
		subject.TypeOfServiceCode = "Vr";
		subject.LocationIdentifier = "I";
		subject.Quantity = 9;
		subject.PackagingCode = "TgZ";
		subject.DispositionCode = "xf";
		subject.StandardCarrierAlphaCode = "fV";
		subject.ReferenceNumber = "0";
		subject.ReferenceNumberQualifier2 = "rJ";
		subject.ReferenceNumber2 = "f";
		subject.ReferenceNumberQualifier = referenceNumberQualifier;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("0", true)]
	public void Validation_RequiredReferenceNumber(string referenceNumber, bool isValidExpected)
	{
		var subject = new CD1_CargoDetail();
		subject.EquipmentInitial = "p";
		subject.EquipmentNumber = "p";
		subject.BillOfLadingWaybillNumber = "F";
		subject.TypeOfServiceCode = "Vr";
		subject.LocationIdentifier = "I";
		subject.Quantity = 9;
		subject.PackagingCode = "TgZ";
		subject.DispositionCode = "xf";
		subject.StandardCarrierAlphaCode = "fV";
		subject.ReferenceNumberQualifier = "T1";
		subject.ReferenceNumberQualifier2 = "rJ";
		subject.ReferenceNumber2 = "f";
		subject.ReferenceNumber = referenceNumber;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("rJ", true)]
	public void Validation_RequiredReferenceNumberQualifier2(string referenceNumberQualifier2, bool isValidExpected)
	{
		var subject = new CD1_CargoDetail();
		subject.EquipmentInitial = "p";
		subject.EquipmentNumber = "p";
		subject.BillOfLadingWaybillNumber = "F";
		subject.TypeOfServiceCode = "Vr";
		subject.LocationIdentifier = "I";
		subject.Quantity = 9;
		subject.PackagingCode = "TgZ";
		subject.DispositionCode = "xf";
		subject.StandardCarrierAlphaCode = "fV";
		subject.ReferenceNumberQualifier = "T1";
		subject.ReferenceNumber = "0";
		subject.ReferenceNumber2 = "f";
		subject.ReferenceNumberQualifier2 = referenceNumberQualifier2;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("f", true)]
	public void Validation_RequiredReferenceNumber2(string referenceNumber2, bool isValidExpected)
	{
		var subject = new CD1_CargoDetail();
		subject.EquipmentInitial = "p";
		subject.EquipmentNumber = "p";
		subject.BillOfLadingWaybillNumber = "F";
		subject.TypeOfServiceCode = "Vr";
		subject.LocationIdentifier = "I";
		subject.Quantity = 9;
		subject.PackagingCode = "TgZ";
		subject.DispositionCode = "xf";
		subject.StandardCarrierAlphaCode = "fV";
		subject.ReferenceNumberQualifier = "T1";
		subject.ReferenceNumber = "0";
		subject.ReferenceNumberQualifier2 = "rJ";
		subject.ReferenceNumber2 = referenceNumber2;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
