using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v5030;

namespace Eddy.x12.Tests.Models.v5030;

public class CD1Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "CD1*9*5*IGKF*9*T0*7*T*K3uxqnyG*S*3*8sg*0B*Qs*PI*E*xo*7*t*yV*6*W*zN*3*EEB*Gzq2hEFQ*6*mQ*9H*s*6b*N";

		var expected = new CD1_CargoDetail()
		{
			EquipmentInitial = "9",
			EquipmentNumber = "5",
			EquipmentType = "IGKF",
			BillOfLadingWaybillNumber = "9",
			TypeOfServiceCode = "T0",
			HazardousMaterialCodeQualifier = "7",
			HazardousMaterialClassCode = "T",
			Date = "K3uxqnyG",
			LocationIdentifier = "S",
			Quantity = 3,
			PackagingCode = "8sg",
			BillOfLadingDispositionCode = "0B",
			BillOfLadingDispositionCode2 = "Qs",
			BillOfLadingDispositionCode3 = "PI",
			RateClassCode = "E",
			RateValueQualifier = "xo",
			Rate = 7,
			RateClassCode2 = "t",
			RateValueQualifier2 = "yV",
			Rate2 = 6,
			RateClassCode3 = "W",
			RateValueQualifier3 = "zN",
			Rate3 = 3,
			DateTimeQualifier = "EEB",
			Date2 = "Gzq2hEFQ",
			ShipmentStatusCode = "6",
			StandardCarrierAlphaCode = "mQ",
			ReferenceIdentificationQualifier = "9H",
			ReferenceIdentification = "s",
			ReferenceIdentificationQualifier2 = "6b",
			ReferenceIdentification2 = "N",
		};

		var actual = Map.MapObject<CD1_CargoDetail>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("9", true)]
	public void Validation_RequiredEquipmentInitial(string equipmentInitial, bool isValidExpected)
	{
		var subject = new CD1_CargoDetail();
		subject.EquipmentNumber = "5";
		subject.BillOfLadingWaybillNumber = "9";
		subject.TypeOfServiceCode = "T0";
		subject.LocationIdentifier = "S";
		subject.Quantity = 3;
		subject.PackagingCode = "8sg";
		subject.BillOfLadingDispositionCode = "0B";
		subject.StandardCarrierAlphaCode = "mQ";
		subject.ReferenceIdentificationQualifier = "9H";
		subject.ReferenceIdentification = "s";
		subject.ReferenceIdentificationQualifier2 = "6b";
		subject.ReferenceIdentification2 = "N";
		subject.EquipmentInitial = equipmentInitial;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("5", true)]
	public void Validation_RequiredEquipmentNumber(string equipmentNumber, bool isValidExpected)
	{
		var subject = new CD1_CargoDetail();
		subject.EquipmentInitial = "9";
		subject.BillOfLadingWaybillNumber = "9";
		subject.TypeOfServiceCode = "T0";
		subject.LocationIdentifier = "S";
		subject.Quantity = 3;
		subject.PackagingCode = "8sg";
		subject.BillOfLadingDispositionCode = "0B";
		subject.StandardCarrierAlphaCode = "mQ";
		subject.ReferenceIdentificationQualifier = "9H";
		subject.ReferenceIdentification = "s";
		subject.ReferenceIdentificationQualifier2 = "6b";
		subject.ReferenceIdentification2 = "N";
		subject.EquipmentNumber = equipmentNumber;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("9", true)]
	public void Validation_RequiredBillOfLadingWaybillNumber(string billOfLadingWaybillNumber, bool isValidExpected)
	{
		var subject = new CD1_CargoDetail();
		subject.EquipmentInitial = "9";
		subject.EquipmentNumber = "5";
		subject.TypeOfServiceCode = "T0";
		subject.LocationIdentifier = "S";
		subject.Quantity = 3;
		subject.PackagingCode = "8sg";
		subject.BillOfLadingDispositionCode = "0B";
		subject.StandardCarrierAlphaCode = "mQ";
		subject.ReferenceIdentificationQualifier = "9H";
		subject.ReferenceIdentification = "s";
		subject.ReferenceIdentificationQualifier2 = "6b";
		subject.ReferenceIdentification2 = "N";
		subject.BillOfLadingWaybillNumber = billOfLadingWaybillNumber;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("T0", true)]
	public void Validation_RequiredTypeOfServiceCode(string typeOfServiceCode, bool isValidExpected)
	{
		var subject = new CD1_CargoDetail();
		subject.EquipmentInitial = "9";
		subject.EquipmentNumber = "5";
		subject.BillOfLadingWaybillNumber = "9";
		subject.LocationIdentifier = "S";
		subject.Quantity = 3;
		subject.PackagingCode = "8sg";
		subject.BillOfLadingDispositionCode = "0B";
		subject.StandardCarrierAlphaCode = "mQ";
		subject.ReferenceIdentificationQualifier = "9H";
		subject.ReferenceIdentification = "s";
		subject.ReferenceIdentificationQualifier2 = "6b";
		subject.ReferenceIdentification2 = "N";
		subject.TypeOfServiceCode = typeOfServiceCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("S", true)]
	public void Validation_RequiredLocationIdentifier(string locationIdentifier, bool isValidExpected)
	{
		var subject = new CD1_CargoDetail();
		subject.EquipmentInitial = "9";
		subject.EquipmentNumber = "5";
		subject.BillOfLadingWaybillNumber = "9";
		subject.TypeOfServiceCode = "T0";
		subject.Quantity = 3;
		subject.PackagingCode = "8sg";
		subject.BillOfLadingDispositionCode = "0B";
		subject.StandardCarrierAlphaCode = "mQ";
		subject.ReferenceIdentificationQualifier = "9H";
		subject.ReferenceIdentification = "s";
		subject.ReferenceIdentificationQualifier2 = "6b";
		subject.ReferenceIdentification2 = "N";
		subject.LocationIdentifier = locationIdentifier;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData(0, false)]
	[InlineData(3, true)]
	public void Validation_RequiredQuantity(decimal quantity, bool isValidExpected)
	{
		var subject = new CD1_CargoDetail();
		subject.EquipmentInitial = "9";
		subject.EquipmentNumber = "5";
		subject.BillOfLadingWaybillNumber = "9";
		subject.TypeOfServiceCode = "T0";
		subject.LocationIdentifier = "S";
		subject.PackagingCode = "8sg";
		subject.BillOfLadingDispositionCode = "0B";
		subject.StandardCarrierAlphaCode = "mQ";
		subject.ReferenceIdentificationQualifier = "9H";
		subject.ReferenceIdentification = "s";
		subject.ReferenceIdentificationQualifier2 = "6b";
		subject.ReferenceIdentification2 = "N";
		if (quantity > 0)
			subject.Quantity = quantity;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("8sg", true)]
	public void Validation_RequiredPackagingCode(string packagingCode, bool isValidExpected)
	{
		var subject = new CD1_CargoDetail();
		subject.EquipmentInitial = "9";
		subject.EquipmentNumber = "5";
		subject.BillOfLadingWaybillNumber = "9";
		subject.TypeOfServiceCode = "T0";
		subject.LocationIdentifier = "S";
		subject.Quantity = 3;
		subject.BillOfLadingDispositionCode = "0B";
		subject.StandardCarrierAlphaCode = "mQ";
		subject.ReferenceIdentificationQualifier = "9H";
		subject.ReferenceIdentification = "s";
		subject.ReferenceIdentificationQualifier2 = "6b";
		subject.ReferenceIdentification2 = "N";
		subject.PackagingCode = packagingCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("0B", true)]
	public void Validation_RequiredBillOfLadingDispositionCode(string billOfLadingDispositionCode, bool isValidExpected)
	{
		var subject = new CD1_CargoDetail();
		subject.EquipmentInitial = "9";
		subject.EquipmentNumber = "5";
		subject.BillOfLadingWaybillNumber = "9";
		subject.TypeOfServiceCode = "T0";
		subject.LocationIdentifier = "S";
		subject.Quantity = 3;
		subject.PackagingCode = "8sg";
		subject.StandardCarrierAlphaCode = "mQ";
		subject.ReferenceIdentificationQualifier = "9H";
		subject.ReferenceIdentification = "s";
		subject.ReferenceIdentificationQualifier2 = "6b";
		subject.ReferenceIdentification2 = "N";
		subject.BillOfLadingDispositionCode = billOfLadingDispositionCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("mQ", true)]
	public void Validation_RequiredStandardCarrierAlphaCode(string standardCarrierAlphaCode, bool isValidExpected)
	{
		var subject = new CD1_CargoDetail();
		subject.EquipmentInitial = "9";
		subject.EquipmentNumber = "5";
		subject.BillOfLadingWaybillNumber = "9";
		subject.TypeOfServiceCode = "T0";
		subject.LocationIdentifier = "S";
		subject.Quantity = 3;
		subject.PackagingCode = "8sg";
		subject.BillOfLadingDispositionCode = "0B";
		subject.ReferenceIdentificationQualifier = "9H";
		subject.ReferenceIdentification = "s";
		subject.ReferenceIdentificationQualifier2 = "6b";
		subject.ReferenceIdentification2 = "N";
		subject.StandardCarrierAlphaCode = standardCarrierAlphaCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("9H", true)]
	public void Validation_RequiredReferenceIdentificationQualifier(string referenceIdentificationQualifier, bool isValidExpected)
	{
		var subject = new CD1_CargoDetail();
		subject.EquipmentInitial = "9";
		subject.EquipmentNumber = "5";
		subject.BillOfLadingWaybillNumber = "9";
		subject.TypeOfServiceCode = "T0";
		subject.LocationIdentifier = "S";
		subject.Quantity = 3;
		subject.PackagingCode = "8sg";
		subject.BillOfLadingDispositionCode = "0B";
		subject.StandardCarrierAlphaCode = "mQ";
		subject.ReferenceIdentification = "s";
		subject.ReferenceIdentificationQualifier2 = "6b";
		subject.ReferenceIdentification2 = "N";
		subject.ReferenceIdentificationQualifier = referenceIdentificationQualifier;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("s", true)]
	public void Validation_RequiredReferenceIdentification(string referenceIdentification, bool isValidExpected)
	{
		var subject = new CD1_CargoDetail();
		subject.EquipmentInitial = "9";
		subject.EquipmentNumber = "5";
		subject.BillOfLadingWaybillNumber = "9";
		subject.TypeOfServiceCode = "T0";
		subject.LocationIdentifier = "S";
		subject.Quantity = 3;
		subject.PackagingCode = "8sg";
		subject.BillOfLadingDispositionCode = "0B";
		subject.StandardCarrierAlphaCode = "mQ";
		subject.ReferenceIdentificationQualifier = "9H";
		subject.ReferenceIdentificationQualifier2 = "6b";
		subject.ReferenceIdentification2 = "N";
		subject.ReferenceIdentification = referenceIdentification;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("6b", true)]
	public void Validation_RequiredReferenceIdentificationQualifier2(string referenceIdentificationQualifier2, bool isValidExpected)
	{
		var subject = new CD1_CargoDetail();
		subject.EquipmentInitial = "9";
		subject.EquipmentNumber = "5";
		subject.BillOfLadingWaybillNumber = "9";
		subject.TypeOfServiceCode = "T0";
		subject.LocationIdentifier = "S";
		subject.Quantity = 3;
		subject.PackagingCode = "8sg";
		subject.BillOfLadingDispositionCode = "0B";
		subject.StandardCarrierAlphaCode = "mQ";
		subject.ReferenceIdentificationQualifier = "9H";
		subject.ReferenceIdentification = "s";
		subject.ReferenceIdentification2 = "N";
		subject.ReferenceIdentificationQualifier2 = referenceIdentificationQualifier2;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("N", true)]
	public void Validation_RequiredReferenceIdentification2(string referenceIdentification2, bool isValidExpected)
	{
		var subject = new CD1_CargoDetail();
		subject.EquipmentInitial = "9";
		subject.EquipmentNumber = "5";
		subject.BillOfLadingWaybillNumber = "9";
		subject.TypeOfServiceCode = "T0";
		subject.LocationIdentifier = "S";
		subject.Quantity = 3;
		subject.PackagingCode = "8sg";
		subject.BillOfLadingDispositionCode = "0B";
		subject.StandardCarrierAlphaCode = "mQ";
		subject.ReferenceIdentificationQualifier = "9H";
		subject.ReferenceIdentification = "s";
		subject.ReferenceIdentificationQualifier2 = "6b";
		subject.ReferenceIdentification2 = referenceIdentification2;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
