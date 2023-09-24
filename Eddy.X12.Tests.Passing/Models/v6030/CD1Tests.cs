using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v6030;

namespace Eddy.x12.Tests.Models.v6030;

public class CD1Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "CD1*M*S*MGcI*Z*21*6*D*8TJP1mWg*p*3*lhs*LN*mh*xv*0*bu*8*g*xS*1*J*2l*5*3zJ*5WZkQjSM*v*2g*ka*u*yE*W";

		var expected = new CD1_CargoDetail()
		{
			EquipmentInitial = "M",
			EquipmentNumber = "S",
			EquipmentTypeCode = "MGcI",
			BillOfLadingWaybillNumber = "Z",
			TypeOfServiceCode = "21",
			HazardousMaterialCodeQualifier = "6",
			HazardousMaterialClassCode = "D",
			Date = "8TJP1mWg",
			LocationIdentifier = "p",
			Quantity = 3,
			PackagingCode = "lhs",
			BillOfLadingDispositionCode = "LN",
			BillOfLadingDispositionCode2 = "mh",
			BillOfLadingDispositionCode3 = "xv",
			RateClassCode = "0",
			RateValueQualifier = "bu",
			Rate = 8,
			RateClassCode2 = "g",
			RateValueQualifier2 = "xS",
			Rate2 = 1,
			RateClassCode3 = "J",
			RateValueQualifier3 = "2l",
			Rate3 = 5,
			DateTimeQualifier = "3zJ",
			Date2 = "5WZkQjSM",
			ShipmentStatusCode = "v",
			StandardCarrierAlphaCode = "2g",
			ReferenceIdentificationQualifier = "ka",
			ReferenceIdentification = "u",
			ReferenceIdentificationQualifier2 = "yE",
			ReferenceIdentification2 = "W",
		};

		var actual = Map.MapObject<CD1_CargoDetail>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("M", true)]
	public void Validation_RequiredEquipmentInitial(string equipmentInitial, bool isValidExpected)
	{
		var subject = new CD1_CargoDetail();
		subject.EquipmentNumber = "S";
		subject.BillOfLadingWaybillNumber = "Z";
		subject.TypeOfServiceCode = "21";
		subject.LocationIdentifier = "p";
		subject.Quantity = 3;
		subject.PackagingCode = "lhs";
		subject.BillOfLadingDispositionCode = "LN";
		subject.StandardCarrierAlphaCode = "2g";
		subject.ReferenceIdentificationQualifier = "ka";
		subject.ReferenceIdentification = "u";
		subject.ReferenceIdentificationQualifier2 = "yE";
		subject.ReferenceIdentification2 = "W";
		subject.EquipmentInitial = equipmentInitial;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("S", true)]
	public void Validation_RequiredEquipmentNumber(string equipmentNumber, bool isValidExpected)
	{
		var subject = new CD1_CargoDetail();
		subject.EquipmentInitial = "M";
		subject.BillOfLadingWaybillNumber = "Z";
		subject.TypeOfServiceCode = "21";
		subject.LocationIdentifier = "p";
		subject.Quantity = 3;
		subject.PackagingCode = "lhs";
		subject.BillOfLadingDispositionCode = "LN";
		subject.StandardCarrierAlphaCode = "2g";
		subject.ReferenceIdentificationQualifier = "ka";
		subject.ReferenceIdentification = "u";
		subject.ReferenceIdentificationQualifier2 = "yE";
		subject.ReferenceIdentification2 = "W";
		subject.EquipmentNumber = equipmentNumber;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("Z", true)]
	public void Validation_RequiredBillOfLadingWaybillNumber(string billOfLadingWaybillNumber, bool isValidExpected)
	{
		var subject = new CD1_CargoDetail();
		subject.EquipmentInitial = "M";
		subject.EquipmentNumber = "S";
		subject.TypeOfServiceCode = "21";
		subject.LocationIdentifier = "p";
		subject.Quantity = 3;
		subject.PackagingCode = "lhs";
		subject.BillOfLadingDispositionCode = "LN";
		subject.StandardCarrierAlphaCode = "2g";
		subject.ReferenceIdentificationQualifier = "ka";
		subject.ReferenceIdentification = "u";
		subject.ReferenceIdentificationQualifier2 = "yE";
		subject.ReferenceIdentification2 = "W";
		subject.BillOfLadingWaybillNumber = billOfLadingWaybillNumber;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("21", true)]
	public void Validation_RequiredTypeOfServiceCode(string typeOfServiceCode, bool isValidExpected)
	{
		var subject = new CD1_CargoDetail();
		subject.EquipmentInitial = "M";
		subject.EquipmentNumber = "S";
		subject.BillOfLadingWaybillNumber = "Z";
		subject.LocationIdentifier = "p";
		subject.Quantity = 3;
		subject.PackagingCode = "lhs";
		subject.BillOfLadingDispositionCode = "LN";
		subject.StandardCarrierAlphaCode = "2g";
		subject.ReferenceIdentificationQualifier = "ka";
		subject.ReferenceIdentification = "u";
		subject.ReferenceIdentificationQualifier2 = "yE";
		subject.ReferenceIdentification2 = "W";
		subject.TypeOfServiceCode = typeOfServiceCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("p", true)]
	public void Validation_RequiredLocationIdentifier(string locationIdentifier, bool isValidExpected)
	{
		var subject = new CD1_CargoDetail();
		subject.EquipmentInitial = "M";
		subject.EquipmentNumber = "S";
		subject.BillOfLadingWaybillNumber = "Z";
		subject.TypeOfServiceCode = "21";
		subject.Quantity = 3;
		subject.PackagingCode = "lhs";
		subject.BillOfLadingDispositionCode = "LN";
		subject.StandardCarrierAlphaCode = "2g";
		subject.ReferenceIdentificationQualifier = "ka";
		subject.ReferenceIdentification = "u";
		subject.ReferenceIdentificationQualifier2 = "yE";
		subject.ReferenceIdentification2 = "W";
		subject.LocationIdentifier = locationIdentifier;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData(0, false)]
	[InlineData(3, true)]
	public void Validation_RequiredQuantity(decimal quantity, bool isValidExpected)
	{
		var subject = new CD1_CargoDetail();
		subject.EquipmentInitial = "M";
		subject.EquipmentNumber = "S";
		subject.BillOfLadingWaybillNumber = "Z";
		subject.TypeOfServiceCode = "21";
		subject.LocationIdentifier = "p";
		subject.PackagingCode = "lhs";
		subject.BillOfLadingDispositionCode = "LN";
		subject.StandardCarrierAlphaCode = "2g";
		subject.ReferenceIdentificationQualifier = "ka";
		subject.ReferenceIdentification = "u";
		subject.ReferenceIdentificationQualifier2 = "yE";
		subject.ReferenceIdentification2 = "W";
		if (quantity > 0)
			subject.Quantity = quantity;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("lhs", true)]
	public void Validation_RequiredPackagingCode(string packagingCode, bool isValidExpected)
	{
		var subject = new CD1_CargoDetail();
		subject.EquipmentInitial = "M";
		subject.EquipmentNumber = "S";
		subject.BillOfLadingWaybillNumber = "Z";
		subject.TypeOfServiceCode = "21";
		subject.LocationIdentifier = "p";
		subject.Quantity = 3;
		subject.BillOfLadingDispositionCode = "LN";
		subject.StandardCarrierAlphaCode = "2g";
		subject.ReferenceIdentificationQualifier = "ka";
		subject.ReferenceIdentification = "u";
		subject.ReferenceIdentificationQualifier2 = "yE";
		subject.ReferenceIdentification2 = "W";
		subject.PackagingCode = packagingCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("LN", true)]
	public void Validation_RequiredBillOfLadingDispositionCode(string billOfLadingDispositionCode, bool isValidExpected)
	{
		var subject = new CD1_CargoDetail();
		subject.EquipmentInitial = "M";
		subject.EquipmentNumber = "S";
		subject.BillOfLadingWaybillNumber = "Z";
		subject.TypeOfServiceCode = "21";
		subject.LocationIdentifier = "p";
		subject.Quantity = 3;
		subject.PackagingCode = "lhs";
		subject.StandardCarrierAlphaCode = "2g";
		subject.ReferenceIdentificationQualifier = "ka";
		subject.ReferenceIdentification = "u";
		subject.ReferenceIdentificationQualifier2 = "yE";
		subject.ReferenceIdentification2 = "W";
		subject.BillOfLadingDispositionCode = billOfLadingDispositionCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("2g", true)]
	public void Validation_RequiredStandardCarrierAlphaCode(string standardCarrierAlphaCode, bool isValidExpected)
	{
		var subject = new CD1_CargoDetail();
		subject.EquipmentInitial = "M";
		subject.EquipmentNumber = "S";
		subject.BillOfLadingWaybillNumber = "Z";
		subject.TypeOfServiceCode = "21";
		subject.LocationIdentifier = "p";
		subject.Quantity = 3;
		subject.PackagingCode = "lhs";
		subject.BillOfLadingDispositionCode = "LN";
		subject.ReferenceIdentificationQualifier = "ka";
		subject.ReferenceIdentification = "u";
		subject.ReferenceIdentificationQualifier2 = "yE";
		subject.ReferenceIdentification2 = "W";
		subject.StandardCarrierAlphaCode = standardCarrierAlphaCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("ka", true)]
	public void Validation_RequiredReferenceIdentificationQualifier(string referenceIdentificationQualifier, bool isValidExpected)
	{
		var subject = new CD1_CargoDetail();
		subject.EquipmentInitial = "M";
		subject.EquipmentNumber = "S";
		subject.BillOfLadingWaybillNumber = "Z";
		subject.TypeOfServiceCode = "21";
		subject.LocationIdentifier = "p";
		subject.Quantity = 3;
		subject.PackagingCode = "lhs";
		subject.BillOfLadingDispositionCode = "LN";
		subject.StandardCarrierAlphaCode = "2g";
		subject.ReferenceIdentification = "u";
		subject.ReferenceIdentificationQualifier2 = "yE";
		subject.ReferenceIdentification2 = "W";
		subject.ReferenceIdentificationQualifier = referenceIdentificationQualifier;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("u", true)]
	public void Validation_RequiredReferenceIdentification(string referenceIdentification, bool isValidExpected)
	{
		var subject = new CD1_CargoDetail();
		subject.EquipmentInitial = "M";
		subject.EquipmentNumber = "S";
		subject.BillOfLadingWaybillNumber = "Z";
		subject.TypeOfServiceCode = "21";
		subject.LocationIdentifier = "p";
		subject.Quantity = 3;
		subject.PackagingCode = "lhs";
		subject.BillOfLadingDispositionCode = "LN";
		subject.StandardCarrierAlphaCode = "2g";
		subject.ReferenceIdentificationQualifier = "ka";
		subject.ReferenceIdentificationQualifier2 = "yE";
		subject.ReferenceIdentification2 = "W";
		subject.ReferenceIdentification = referenceIdentification;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("yE", true)]
	public void Validation_RequiredReferenceIdentificationQualifier2(string referenceIdentificationQualifier2, bool isValidExpected)
	{
		var subject = new CD1_CargoDetail();
		subject.EquipmentInitial = "M";
		subject.EquipmentNumber = "S";
		subject.BillOfLadingWaybillNumber = "Z";
		subject.TypeOfServiceCode = "21";
		subject.LocationIdentifier = "p";
		subject.Quantity = 3;
		subject.PackagingCode = "lhs";
		subject.BillOfLadingDispositionCode = "LN";
		subject.StandardCarrierAlphaCode = "2g";
		subject.ReferenceIdentificationQualifier = "ka";
		subject.ReferenceIdentification = "u";
		subject.ReferenceIdentification2 = "W";
		subject.ReferenceIdentificationQualifier2 = referenceIdentificationQualifier2;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("W", true)]
	public void Validation_RequiredReferenceIdentification2(string referenceIdentification2, bool isValidExpected)
	{
		var subject = new CD1_CargoDetail();
		subject.EquipmentInitial = "M";
		subject.EquipmentNumber = "S";
		subject.BillOfLadingWaybillNumber = "Z";
		subject.TypeOfServiceCode = "21";
		subject.LocationIdentifier = "p";
		subject.Quantity = 3;
		subject.PackagingCode = "lhs";
		subject.BillOfLadingDispositionCode = "LN";
		subject.StandardCarrierAlphaCode = "2g";
		subject.ReferenceIdentificationQualifier = "ka";
		subject.ReferenceIdentification = "u";
		subject.ReferenceIdentificationQualifier2 = "yE";
		subject.ReferenceIdentification2 = referenceIdentification2;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
