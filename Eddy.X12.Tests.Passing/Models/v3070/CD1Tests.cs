using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3070;

namespace Eddy.x12.Tests.Models.v3070;

public class CD1Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "CD1*L*6*uvDM*U*j7*z*H*a2lQ2D*m*8*7kb*1h*hG*gZ*M*oU*4*0*SO*9*p*St*6*Mro*9qLkK4*E*pU*ae*6*Aj*N";

		var expected = new CD1_CargoDetail()
		{
			EquipmentInitial = "L",
			EquipmentNumber = "6",
			EquipmentType = "uvDM",
			BillOfLadingWaybillNumber = "U",
			TypeOfServiceCode = "j7",
			HazardousMaterialCodeQualifier = "z",
			HazardousMaterialClassCode = "H",
			Date = "a2lQ2D",
			LocationIdentifier = "m",
			Quantity = 8,
			PackagingCode = "7kb",
			DispositionCode = "1h",
			DispositionCode2 = "hG",
			DispositionCode3 = "gZ",
			RateClassCode = "M",
			RateValueQualifier = "oU",
			Rate = 4,
			RateClassCode2 = "0",
			RateValueQualifier2 = "SO",
			Rate2 = 9,
			RateClassCode3 = "p",
			RateValueQualifier3 = "St",
			Rate3 = 6,
			DateTimeQualifier = "Mro",
			Date2 = "9qLkK4",
			ShipmentStatusCode = "E",
			StandardCarrierAlphaCode = "pU",
			ReferenceIdentificationQualifier = "ae",
			ReferenceIdentification = "6",
			ReferenceIdentificationQualifier2 = "Aj",
			ReferenceIdentification2 = "N",
		};

		var actual = Map.MapObject<CD1_CargoDetail>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("L", true)]
	public void Validation_RequiredEquipmentInitial(string equipmentInitial, bool isValidExpected)
	{
		var subject = new CD1_CargoDetail();
		subject.EquipmentNumber = "6";
		subject.BillOfLadingWaybillNumber = "U";
		subject.TypeOfServiceCode = "j7";
		subject.LocationIdentifier = "m";
		subject.Quantity = 8;
		subject.PackagingCode = "7kb";
		subject.DispositionCode = "1h";
		subject.StandardCarrierAlphaCode = "pU";
		subject.ReferenceIdentificationQualifier = "ae";
		subject.ReferenceIdentification = "6";
		subject.ReferenceIdentificationQualifier2 = "Aj";
		subject.ReferenceIdentification2 = "N";
		subject.EquipmentInitial = equipmentInitial;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("6", true)]
	public void Validation_RequiredEquipmentNumber(string equipmentNumber, bool isValidExpected)
	{
		var subject = new CD1_CargoDetail();
		subject.EquipmentInitial = "L";
		subject.BillOfLadingWaybillNumber = "U";
		subject.TypeOfServiceCode = "j7";
		subject.LocationIdentifier = "m";
		subject.Quantity = 8;
		subject.PackagingCode = "7kb";
		subject.DispositionCode = "1h";
		subject.StandardCarrierAlphaCode = "pU";
		subject.ReferenceIdentificationQualifier = "ae";
		subject.ReferenceIdentification = "6";
		subject.ReferenceIdentificationQualifier2 = "Aj";
		subject.ReferenceIdentification2 = "N";
		subject.EquipmentNumber = equipmentNumber;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("U", true)]
	public void Validation_RequiredBillOfLadingWaybillNumber(string billOfLadingWaybillNumber, bool isValidExpected)
	{
		var subject = new CD1_CargoDetail();
		subject.EquipmentInitial = "L";
		subject.EquipmentNumber = "6";
		subject.TypeOfServiceCode = "j7";
		subject.LocationIdentifier = "m";
		subject.Quantity = 8;
		subject.PackagingCode = "7kb";
		subject.DispositionCode = "1h";
		subject.StandardCarrierAlphaCode = "pU";
		subject.ReferenceIdentificationQualifier = "ae";
		subject.ReferenceIdentification = "6";
		subject.ReferenceIdentificationQualifier2 = "Aj";
		subject.ReferenceIdentification2 = "N";
		subject.BillOfLadingWaybillNumber = billOfLadingWaybillNumber;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("j7", true)]
	public void Validation_RequiredTypeOfServiceCode(string typeOfServiceCode, bool isValidExpected)
	{
		var subject = new CD1_CargoDetail();
		subject.EquipmentInitial = "L";
		subject.EquipmentNumber = "6";
		subject.BillOfLadingWaybillNumber = "U";
		subject.LocationIdentifier = "m";
		subject.Quantity = 8;
		subject.PackagingCode = "7kb";
		subject.DispositionCode = "1h";
		subject.StandardCarrierAlphaCode = "pU";
		subject.ReferenceIdentificationQualifier = "ae";
		subject.ReferenceIdentification = "6";
		subject.ReferenceIdentificationQualifier2 = "Aj";
		subject.ReferenceIdentification2 = "N";
		subject.TypeOfServiceCode = typeOfServiceCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("m", true)]
	public void Validation_RequiredLocationIdentifier(string locationIdentifier, bool isValidExpected)
	{
		var subject = new CD1_CargoDetail();
		subject.EquipmentInitial = "L";
		subject.EquipmentNumber = "6";
		subject.BillOfLadingWaybillNumber = "U";
		subject.TypeOfServiceCode = "j7";
		subject.Quantity = 8;
		subject.PackagingCode = "7kb";
		subject.DispositionCode = "1h";
		subject.StandardCarrierAlphaCode = "pU";
		subject.ReferenceIdentificationQualifier = "ae";
		subject.ReferenceIdentification = "6";
		subject.ReferenceIdentificationQualifier2 = "Aj";
		subject.ReferenceIdentification2 = "N";
		subject.LocationIdentifier = locationIdentifier;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData(0, false)]
	[InlineData(8, true)]
	public void Validation_RequiredQuantity(decimal quantity, bool isValidExpected)
	{
		var subject = new CD1_CargoDetail();
		subject.EquipmentInitial = "L";
		subject.EquipmentNumber = "6";
		subject.BillOfLadingWaybillNumber = "U";
		subject.TypeOfServiceCode = "j7";
		subject.LocationIdentifier = "m";
		subject.PackagingCode = "7kb";
		subject.DispositionCode = "1h";
		subject.StandardCarrierAlphaCode = "pU";
		subject.ReferenceIdentificationQualifier = "ae";
		subject.ReferenceIdentification = "6";
		subject.ReferenceIdentificationQualifier2 = "Aj";
		subject.ReferenceIdentification2 = "N";
		if (quantity > 0)
			subject.Quantity = quantity;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("7kb", true)]
	public void Validation_RequiredPackagingCode(string packagingCode, bool isValidExpected)
	{
		var subject = new CD1_CargoDetail();
		subject.EquipmentInitial = "L";
		subject.EquipmentNumber = "6";
		subject.BillOfLadingWaybillNumber = "U";
		subject.TypeOfServiceCode = "j7";
		subject.LocationIdentifier = "m";
		subject.Quantity = 8;
		subject.DispositionCode = "1h";
		subject.StandardCarrierAlphaCode = "pU";
		subject.ReferenceIdentificationQualifier = "ae";
		subject.ReferenceIdentification = "6";
		subject.ReferenceIdentificationQualifier2 = "Aj";
		subject.ReferenceIdentification2 = "N";
		subject.PackagingCode = packagingCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("1h", true)]
	public void Validation_RequiredDispositionCode(string dispositionCode, bool isValidExpected)
	{
		var subject = new CD1_CargoDetail();
		subject.EquipmentInitial = "L";
		subject.EquipmentNumber = "6";
		subject.BillOfLadingWaybillNumber = "U";
		subject.TypeOfServiceCode = "j7";
		subject.LocationIdentifier = "m";
		subject.Quantity = 8;
		subject.PackagingCode = "7kb";
		subject.StandardCarrierAlphaCode = "pU";
		subject.ReferenceIdentificationQualifier = "ae";
		subject.ReferenceIdentification = "6";
		subject.ReferenceIdentificationQualifier2 = "Aj";
		subject.ReferenceIdentification2 = "N";
		subject.DispositionCode = dispositionCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("pU", true)]
	public void Validation_RequiredStandardCarrierAlphaCode(string standardCarrierAlphaCode, bool isValidExpected)
	{
		var subject = new CD1_CargoDetail();
		subject.EquipmentInitial = "L";
		subject.EquipmentNumber = "6";
		subject.BillOfLadingWaybillNumber = "U";
		subject.TypeOfServiceCode = "j7";
		subject.LocationIdentifier = "m";
		subject.Quantity = 8;
		subject.PackagingCode = "7kb";
		subject.DispositionCode = "1h";
		subject.ReferenceIdentificationQualifier = "ae";
		subject.ReferenceIdentification = "6";
		subject.ReferenceIdentificationQualifier2 = "Aj";
		subject.ReferenceIdentification2 = "N";
		subject.StandardCarrierAlphaCode = standardCarrierAlphaCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("ae", true)]
	public void Validation_RequiredReferenceIdentificationQualifier(string referenceIdentificationQualifier, bool isValidExpected)
	{
		var subject = new CD1_CargoDetail();
		subject.EquipmentInitial = "L";
		subject.EquipmentNumber = "6";
		subject.BillOfLadingWaybillNumber = "U";
		subject.TypeOfServiceCode = "j7";
		subject.LocationIdentifier = "m";
		subject.Quantity = 8;
		subject.PackagingCode = "7kb";
		subject.DispositionCode = "1h";
		subject.StandardCarrierAlphaCode = "pU";
		subject.ReferenceIdentification = "6";
		subject.ReferenceIdentificationQualifier2 = "Aj";
		subject.ReferenceIdentification2 = "N";
		subject.ReferenceIdentificationQualifier = referenceIdentificationQualifier;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("6", true)]
	public void Validation_RequiredReferenceIdentification(string referenceIdentification, bool isValidExpected)
	{
		var subject = new CD1_CargoDetail();
		subject.EquipmentInitial = "L";
		subject.EquipmentNumber = "6";
		subject.BillOfLadingWaybillNumber = "U";
		subject.TypeOfServiceCode = "j7";
		subject.LocationIdentifier = "m";
		subject.Quantity = 8;
		subject.PackagingCode = "7kb";
		subject.DispositionCode = "1h";
		subject.StandardCarrierAlphaCode = "pU";
		subject.ReferenceIdentificationQualifier = "ae";
		subject.ReferenceIdentificationQualifier2 = "Aj";
		subject.ReferenceIdentification2 = "N";
		subject.ReferenceIdentification = referenceIdentification;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("Aj", true)]
	public void Validation_RequiredReferenceIdentificationQualifier2(string referenceIdentificationQualifier2, bool isValidExpected)
	{
		var subject = new CD1_CargoDetail();
		subject.EquipmentInitial = "L";
		subject.EquipmentNumber = "6";
		subject.BillOfLadingWaybillNumber = "U";
		subject.TypeOfServiceCode = "j7";
		subject.LocationIdentifier = "m";
		subject.Quantity = 8;
		subject.PackagingCode = "7kb";
		subject.DispositionCode = "1h";
		subject.StandardCarrierAlphaCode = "pU";
		subject.ReferenceIdentificationQualifier = "ae";
		subject.ReferenceIdentification = "6";
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
		subject.EquipmentInitial = "L";
		subject.EquipmentNumber = "6";
		subject.BillOfLadingWaybillNumber = "U";
		subject.TypeOfServiceCode = "j7";
		subject.LocationIdentifier = "m";
		subject.Quantity = 8;
		subject.PackagingCode = "7kb";
		subject.DispositionCode = "1h";
		subject.StandardCarrierAlphaCode = "pU";
		subject.ReferenceIdentificationQualifier = "ae";
		subject.ReferenceIdentification = "6";
		subject.ReferenceIdentificationQualifier2 = "Aj";
		subject.ReferenceIdentification2 = referenceIdentification2;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
