using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v4020;

namespace Eddy.x12.Tests.Models.v4020;

public class CD1Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "CD1*y*U*5d16*e*PW*z*j*GSOHgiL9*y*3*ECP*YY*Lh*If*R*iY*6*m*8J*2*J*xI*8*Ygk*fQSgrfJu*X*7X*gV*6*vh*Q";

		var expected = new CD1_CargoDetail()
		{
			EquipmentInitial = "y",
			EquipmentNumber = "U",
			EquipmentType = "5d16",
			BillOfLadingWaybillNumber = "e",
			TypeOfServiceCode = "PW",
			HazardousMaterialCodeQualifier = "z",
			HazardousMaterialClassCode = "j",
			Date = "GSOHgiL9",
			LocationIdentifier = "y",
			Quantity = 3,
			PackagingCode = "ECP",
			DispositionCode = "YY",
			DispositionCode2 = "Lh",
			DispositionCode3 = "If",
			RateClassCode = "R",
			RateValueQualifier = "iY",
			Rate = 6,
			RateClassCode2 = "m",
			RateValueQualifier2 = "8J",
			Rate2 = 2,
			RateClassCode3 = "J",
			RateValueQualifier3 = "xI",
			Rate3 = 8,
			DateTimeQualifier = "Ygk",
			Date2 = "fQSgrfJu",
			ShipmentStatusCode = "X",
			StandardCarrierAlphaCode = "7X",
			ReferenceIdentificationQualifier = "gV",
			ReferenceIdentification = "6",
			ReferenceIdentificationQualifier2 = "vh",
			ReferenceIdentification2 = "Q",
		};

		var actual = Map.MapObject<CD1_CargoDetail>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("y", true)]
	public void Validation_RequiredEquipmentInitial(string equipmentInitial, bool isValidExpected)
	{
		var subject = new CD1_CargoDetail();
		subject.EquipmentNumber = "U";
		subject.BillOfLadingWaybillNumber = "e";
		subject.TypeOfServiceCode = "PW";
		subject.LocationIdentifier = "y";
		subject.Quantity = 3;
		subject.PackagingCode = "ECP";
		subject.DispositionCode = "YY";
		subject.StandardCarrierAlphaCode = "7X";
		subject.ReferenceIdentificationQualifier = "gV";
		subject.ReferenceIdentification = "6";
		subject.ReferenceIdentificationQualifier2 = "vh";
		subject.ReferenceIdentification2 = "Q";
		subject.EquipmentInitial = equipmentInitial;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("U", true)]
	public void Validation_RequiredEquipmentNumber(string equipmentNumber, bool isValidExpected)
	{
		var subject = new CD1_CargoDetail();
		subject.EquipmentInitial = "y";
		subject.BillOfLadingWaybillNumber = "e";
		subject.TypeOfServiceCode = "PW";
		subject.LocationIdentifier = "y";
		subject.Quantity = 3;
		subject.PackagingCode = "ECP";
		subject.DispositionCode = "YY";
		subject.StandardCarrierAlphaCode = "7X";
		subject.ReferenceIdentificationQualifier = "gV";
		subject.ReferenceIdentification = "6";
		subject.ReferenceIdentificationQualifier2 = "vh";
		subject.ReferenceIdentification2 = "Q";
		subject.EquipmentNumber = equipmentNumber;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("e", true)]
	public void Validation_RequiredBillOfLadingWaybillNumber(string billOfLadingWaybillNumber, bool isValidExpected)
	{
		var subject = new CD1_CargoDetail();
		subject.EquipmentInitial = "y";
		subject.EquipmentNumber = "U";
		subject.TypeOfServiceCode = "PW";
		subject.LocationIdentifier = "y";
		subject.Quantity = 3;
		subject.PackagingCode = "ECP";
		subject.DispositionCode = "YY";
		subject.StandardCarrierAlphaCode = "7X";
		subject.ReferenceIdentificationQualifier = "gV";
		subject.ReferenceIdentification = "6";
		subject.ReferenceIdentificationQualifier2 = "vh";
		subject.ReferenceIdentification2 = "Q";
		subject.BillOfLadingWaybillNumber = billOfLadingWaybillNumber;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("PW", true)]
	public void Validation_RequiredTypeOfServiceCode(string typeOfServiceCode, bool isValidExpected)
	{
		var subject = new CD1_CargoDetail();
		subject.EquipmentInitial = "y";
		subject.EquipmentNumber = "U";
		subject.BillOfLadingWaybillNumber = "e";
		subject.LocationIdentifier = "y";
		subject.Quantity = 3;
		subject.PackagingCode = "ECP";
		subject.DispositionCode = "YY";
		subject.StandardCarrierAlphaCode = "7X";
		subject.ReferenceIdentificationQualifier = "gV";
		subject.ReferenceIdentification = "6";
		subject.ReferenceIdentificationQualifier2 = "vh";
		subject.ReferenceIdentification2 = "Q";
		subject.TypeOfServiceCode = typeOfServiceCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("y", true)]
	public void Validation_RequiredLocationIdentifier(string locationIdentifier, bool isValidExpected)
	{
		var subject = new CD1_CargoDetail();
		subject.EquipmentInitial = "y";
		subject.EquipmentNumber = "U";
		subject.BillOfLadingWaybillNumber = "e";
		subject.TypeOfServiceCode = "PW";
		subject.Quantity = 3;
		subject.PackagingCode = "ECP";
		subject.DispositionCode = "YY";
		subject.StandardCarrierAlphaCode = "7X";
		subject.ReferenceIdentificationQualifier = "gV";
		subject.ReferenceIdentification = "6";
		subject.ReferenceIdentificationQualifier2 = "vh";
		subject.ReferenceIdentification2 = "Q";
		subject.LocationIdentifier = locationIdentifier;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData(0, false)]
	[InlineData(3, true)]
	public void Validation_RequiredQuantity(decimal quantity, bool isValidExpected)
	{
		var subject = new CD1_CargoDetail();
		subject.EquipmentInitial = "y";
		subject.EquipmentNumber = "U";
		subject.BillOfLadingWaybillNumber = "e";
		subject.TypeOfServiceCode = "PW";
		subject.LocationIdentifier = "y";
		subject.PackagingCode = "ECP";
		subject.DispositionCode = "YY";
		subject.StandardCarrierAlphaCode = "7X";
		subject.ReferenceIdentificationQualifier = "gV";
		subject.ReferenceIdentification = "6";
		subject.ReferenceIdentificationQualifier2 = "vh";
		subject.ReferenceIdentification2 = "Q";
		if (quantity > 0)
			subject.Quantity = quantity;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("ECP", true)]
	public void Validation_RequiredPackagingCode(string packagingCode, bool isValidExpected)
	{
		var subject = new CD1_CargoDetail();
		subject.EquipmentInitial = "y";
		subject.EquipmentNumber = "U";
		subject.BillOfLadingWaybillNumber = "e";
		subject.TypeOfServiceCode = "PW";
		subject.LocationIdentifier = "y";
		subject.Quantity = 3;
		subject.DispositionCode = "YY";
		subject.StandardCarrierAlphaCode = "7X";
		subject.ReferenceIdentificationQualifier = "gV";
		subject.ReferenceIdentification = "6";
		subject.ReferenceIdentificationQualifier2 = "vh";
		subject.ReferenceIdentification2 = "Q";
		subject.PackagingCode = packagingCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("YY", true)]
	public void Validation_RequiredDispositionCode(string dispositionCode, bool isValidExpected)
	{
		var subject = new CD1_CargoDetail();
		subject.EquipmentInitial = "y";
		subject.EquipmentNumber = "U";
		subject.BillOfLadingWaybillNumber = "e";
		subject.TypeOfServiceCode = "PW";
		subject.LocationIdentifier = "y";
		subject.Quantity = 3;
		subject.PackagingCode = "ECP";
		subject.StandardCarrierAlphaCode = "7X";
		subject.ReferenceIdentificationQualifier = "gV";
		subject.ReferenceIdentification = "6";
		subject.ReferenceIdentificationQualifier2 = "vh";
		subject.ReferenceIdentification2 = "Q";
		subject.DispositionCode = dispositionCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("7X", true)]
	public void Validation_RequiredStandardCarrierAlphaCode(string standardCarrierAlphaCode, bool isValidExpected)
	{
		var subject = new CD1_CargoDetail();
		subject.EquipmentInitial = "y";
		subject.EquipmentNumber = "U";
		subject.BillOfLadingWaybillNumber = "e";
		subject.TypeOfServiceCode = "PW";
		subject.LocationIdentifier = "y";
		subject.Quantity = 3;
		subject.PackagingCode = "ECP";
		subject.DispositionCode = "YY";
		subject.ReferenceIdentificationQualifier = "gV";
		subject.ReferenceIdentification = "6";
		subject.ReferenceIdentificationQualifier2 = "vh";
		subject.ReferenceIdentification2 = "Q";
		subject.StandardCarrierAlphaCode = standardCarrierAlphaCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("gV", true)]
	public void Validation_RequiredReferenceIdentificationQualifier(string referenceIdentificationQualifier, bool isValidExpected)
	{
		var subject = new CD1_CargoDetail();
		subject.EquipmentInitial = "y";
		subject.EquipmentNumber = "U";
		subject.BillOfLadingWaybillNumber = "e";
		subject.TypeOfServiceCode = "PW";
		subject.LocationIdentifier = "y";
		subject.Quantity = 3;
		subject.PackagingCode = "ECP";
		subject.DispositionCode = "YY";
		subject.StandardCarrierAlphaCode = "7X";
		subject.ReferenceIdentification = "6";
		subject.ReferenceIdentificationQualifier2 = "vh";
		subject.ReferenceIdentification2 = "Q";
		subject.ReferenceIdentificationQualifier = referenceIdentificationQualifier;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("6", true)]
	public void Validation_RequiredReferenceIdentification(string referenceIdentification, bool isValidExpected)
	{
		var subject = new CD1_CargoDetail();
		subject.EquipmentInitial = "y";
		subject.EquipmentNumber = "U";
		subject.BillOfLadingWaybillNumber = "e";
		subject.TypeOfServiceCode = "PW";
		subject.LocationIdentifier = "y";
		subject.Quantity = 3;
		subject.PackagingCode = "ECP";
		subject.DispositionCode = "YY";
		subject.StandardCarrierAlphaCode = "7X";
		subject.ReferenceIdentificationQualifier = "gV";
		subject.ReferenceIdentificationQualifier2 = "vh";
		subject.ReferenceIdentification2 = "Q";
		subject.ReferenceIdentification = referenceIdentification;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("vh", true)]
	public void Validation_RequiredReferenceIdentificationQualifier2(string referenceIdentificationQualifier2, bool isValidExpected)
	{
		var subject = new CD1_CargoDetail();
		subject.EquipmentInitial = "y";
		subject.EquipmentNumber = "U";
		subject.BillOfLadingWaybillNumber = "e";
		subject.TypeOfServiceCode = "PW";
		subject.LocationIdentifier = "y";
		subject.Quantity = 3;
		subject.PackagingCode = "ECP";
		subject.DispositionCode = "YY";
		subject.StandardCarrierAlphaCode = "7X";
		subject.ReferenceIdentificationQualifier = "gV";
		subject.ReferenceIdentification = "6";
		subject.ReferenceIdentification2 = "Q";
		subject.ReferenceIdentificationQualifier2 = referenceIdentificationQualifier2;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("Q", true)]
	public void Validation_RequiredReferenceIdentification2(string referenceIdentification2, bool isValidExpected)
	{
		var subject = new CD1_CargoDetail();
		subject.EquipmentInitial = "y";
		subject.EquipmentNumber = "U";
		subject.BillOfLadingWaybillNumber = "e";
		subject.TypeOfServiceCode = "PW";
		subject.LocationIdentifier = "y";
		subject.Quantity = 3;
		subject.PackagingCode = "ECP";
		subject.DispositionCode = "YY";
		subject.StandardCarrierAlphaCode = "7X";
		subject.ReferenceIdentificationQualifier = "gV";
		subject.ReferenceIdentification = "6";
		subject.ReferenceIdentificationQualifier2 = "vh";
		subject.ReferenceIdentification2 = referenceIdentification2;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
