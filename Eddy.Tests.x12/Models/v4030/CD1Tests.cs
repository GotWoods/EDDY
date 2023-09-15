using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v4030;

namespace Eddy.x12.Tests.Models.v4030;

public class CD1Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "CD1*Q*p*NOZB*M*FU*f*6*3eCdhU8v*t*3*2dW*oj*GZ*OF*d*uq*9*C*dp*6*q*ss*2*Piq*qsJiowgJ*8*lE*4e*e*UD*4";

		var expected = new CD1_CargoDetail()
		{
			EquipmentInitial = "Q",
			EquipmentNumber = "p",
			EquipmentType = "NOZB",
			BillOfLadingWaybillNumber = "M",
			TypeOfServiceCode = "FU",
			HazardousMaterialCodeQualifier = "f",
			HazardousMaterialClassCode = "6",
			Date = "3eCdhU8v",
			LocationIdentifier = "t",
			Quantity = 3,
			PackagingCode = "2dW",
			DispositionCode = "oj",
			DispositionCode2 = "GZ",
			DispositionCode3 = "OF",
			RateClassCode = "d",
			RateValueQualifier = "uq",
			Rate = 9,
			RateClassCode2 = "C",
			RateValueQualifier2 = "dp",
			Rate2 = 6,
			RateClassCode3 = "q",
			RateValueQualifier3 = "ss",
			Rate3 = 2,
			DateTimeQualifier = "Piq",
			Date2 = "qsJiowgJ",
			ShipmentStatusCode = "8",
			StandardCarrierAlphaCode = "lE",
			ReferenceIdentificationQualifier = "4e",
			ReferenceIdentification = "e",
			ReferenceIdentificationQualifier2 = "UD",
			ReferenceIdentification2 = "4",
		};

		var actual = Map.MapObject<CD1_CargoDetail>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("Q", true)]
	public void Validation_RequiredEquipmentInitial(string equipmentInitial, bool isValidExpected)
	{
		var subject = new CD1_CargoDetail();
		subject.EquipmentNumber = "p";
		subject.BillOfLadingWaybillNumber = "M";
		subject.TypeOfServiceCode = "FU";
		subject.LocationIdentifier = "t";
		subject.Quantity = 3;
		subject.PackagingCode = "2dW";
		subject.DispositionCode = "oj";
		subject.StandardCarrierAlphaCode = "lE";
		subject.ReferenceIdentificationQualifier = "4e";
		subject.ReferenceIdentification = "e";
		subject.ReferenceIdentificationQualifier2 = "UD";
		subject.ReferenceIdentification2 = "4";
		subject.EquipmentInitial = equipmentInitial;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("p", true)]
	public void Validation_RequiredEquipmentNumber(string equipmentNumber, bool isValidExpected)
	{
		var subject = new CD1_CargoDetail();
		subject.EquipmentInitial = "Q";
		subject.BillOfLadingWaybillNumber = "M";
		subject.TypeOfServiceCode = "FU";
		subject.LocationIdentifier = "t";
		subject.Quantity = 3;
		subject.PackagingCode = "2dW";
		subject.DispositionCode = "oj";
		subject.StandardCarrierAlphaCode = "lE";
		subject.ReferenceIdentificationQualifier = "4e";
		subject.ReferenceIdentification = "e";
		subject.ReferenceIdentificationQualifier2 = "UD";
		subject.ReferenceIdentification2 = "4";
		subject.EquipmentNumber = equipmentNumber;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("M", true)]
	public void Validation_RequiredBillOfLadingWaybillNumber(string billOfLadingWaybillNumber, bool isValidExpected)
	{
		var subject = new CD1_CargoDetail();
		subject.EquipmentInitial = "Q";
		subject.EquipmentNumber = "p";
		subject.TypeOfServiceCode = "FU";
		subject.LocationIdentifier = "t";
		subject.Quantity = 3;
		subject.PackagingCode = "2dW";
		subject.DispositionCode = "oj";
		subject.StandardCarrierAlphaCode = "lE";
		subject.ReferenceIdentificationQualifier = "4e";
		subject.ReferenceIdentification = "e";
		subject.ReferenceIdentificationQualifier2 = "UD";
		subject.ReferenceIdentification2 = "4";
		subject.BillOfLadingWaybillNumber = billOfLadingWaybillNumber;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("FU", true)]
	public void Validation_RequiredTypeOfServiceCode(string typeOfServiceCode, bool isValidExpected)
	{
		var subject = new CD1_CargoDetail();
		subject.EquipmentInitial = "Q";
		subject.EquipmentNumber = "p";
		subject.BillOfLadingWaybillNumber = "M";
		subject.LocationIdentifier = "t";
		subject.Quantity = 3;
		subject.PackagingCode = "2dW";
		subject.DispositionCode = "oj";
		subject.StandardCarrierAlphaCode = "lE";
		subject.ReferenceIdentificationQualifier = "4e";
		subject.ReferenceIdentification = "e";
		subject.ReferenceIdentificationQualifier2 = "UD";
		subject.ReferenceIdentification2 = "4";
		subject.TypeOfServiceCode = typeOfServiceCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("t", true)]
	public void Validation_RequiredLocationIdentifier(string locationIdentifier, bool isValidExpected)
	{
		var subject = new CD1_CargoDetail();
		subject.EquipmentInitial = "Q";
		subject.EquipmentNumber = "p";
		subject.BillOfLadingWaybillNumber = "M";
		subject.TypeOfServiceCode = "FU";
		subject.Quantity = 3;
		subject.PackagingCode = "2dW";
		subject.DispositionCode = "oj";
		subject.StandardCarrierAlphaCode = "lE";
		subject.ReferenceIdentificationQualifier = "4e";
		subject.ReferenceIdentification = "e";
		subject.ReferenceIdentificationQualifier2 = "UD";
		subject.ReferenceIdentification2 = "4";
		subject.LocationIdentifier = locationIdentifier;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData(0, false)]
	[InlineData(3, true)]
	public void Validation_RequiredQuantity(decimal quantity, bool isValidExpected)
	{
		var subject = new CD1_CargoDetail();
		subject.EquipmentInitial = "Q";
		subject.EquipmentNumber = "p";
		subject.BillOfLadingWaybillNumber = "M";
		subject.TypeOfServiceCode = "FU";
		subject.LocationIdentifier = "t";
		subject.PackagingCode = "2dW";
		subject.DispositionCode = "oj";
		subject.StandardCarrierAlphaCode = "lE";
		subject.ReferenceIdentificationQualifier = "4e";
		subject.ReferenceIdentification = "e";
		subject.ReferenceIdentificationQualifier2 = "UD";
		subject.ReferenceIdentification2 = "4";
		if (quantity > 0)
			subject.Quantity = quantity;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("2dW", true)]
	public void Validation_RequiredPackagingCode(string packagingCode, bool isValidExpected)
	{
		var subject = new CD1_CargoDetail();
		subject.EquipmentInitial = "Q";
		subject.EquipmentNumber = "p";
		subject.BillOfLadingWaybillNumber = "M";
		subject.TypeOfServiceCode = "FU";
		subject.LocationIdentifier = "t";
		subject.Quantity = 3;
		subject.DispositionCode = "oj";
		subject.StandardCarrierAlphaCode = "lE";
		subject.ReferenceIdentificationQualifier = "4e";
		subject.ReferenceIdentification = "e";
		subject.ReferenceIdentificationQualifier2 = "UD";
		subject.ReferenceIdentification2 = "4";
		subject.PackagingCode = packagingCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("oj", true)]
	public void Validation_RequiredDispositionCode(string dispositionCode, bool isValidExpected)
	{
		var subject = new CD1_CargoDetail();
		subject.EquipmentInitial = "Q";
		subject.EquipmentNumber = "p";
		subject.BillOfLadingWaybillNumber = "M";
		subject.TypeOfServiceCode = "FU";
		subject.LocationIdentifier = "t";
		subject.Quantity = 3;
		subject.PackagingCode = "2dW";
		subject.StandardCarrierAlphaCode = "lE";
		subject.ReferenceIdentificationQualifier = "4e";
		subject.ReferenceIdentification = "e";
		subject.ReferenceIdentificationQualifier2 = "UD";
		subject.ReferenceIdentification2 = "4";
		subject.DispositionCode = dispositionCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("lE", true)]
	public void Validation_RequiredStandardCarrierAlphaCode(string standardCarrierAlphaCode, bool isValidExpected)
	{
		var subject = new CD1_CargoDetail();
		subject.EquipmentInitial = "Q";
		subject.EquipmentNumber = "p";
		subject.BillOfLadingWaybillNumber = "M";
		subject.TypeOfServiceCode = "FU";
		subject.LocationIdentifier = "t";
		subject.Quantity = 3;
		subject.PackagingCode = "2dW";
		subject.DispositionCode = "oj";
		subject.ReferenceIdentificationQualifier = "4e";
		subject.ReferenceIdentification = "e";
		subject.ReferenceIdentificationQualifier2 = "UD";
		subject.ReferenceIdentification2 = "4";
		subject.StandardCarrierAlphaCode = standardCarrierAlphaCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("4e", true)]
	public void Validation_RequiredReferenceIdentificationQualifier(string referenceIdentificationQualifier, bool isValidExpected)
	{
		var subject = new CD1_CargoDetail();
		subject.EquipmentInitial = "Q";
		subject.EquipmentNumber = "p";
		subject.BillOfLadingWaybillNumber = "M";
		subject.TypeOfServiceCode = "FU";
		subject.LocationIdentifier = "t";
		subject.Quantity = 3;
		subject.PackagingCode = "2dW";
		subject.DispositionCode = "oj";
		subject.StandardCarrierAlphaCode = "lE";
		subject.ReferenceIdentification = "e";
		subject.ReferenceIdentificationQualifier2 = "UD";
		subject.ReferenceIdentification2 = "4";
		subject.ReferenceIdentificationQualifier = referenceIdentificationQualifier;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("e", true)]
	public void Validation_RequiredReferenceIdentification(string referenceIdentification, bool isValidExpected)
	{
		var subject = new CD1_CargoDetail();
		subject.EquipmentInitial = "Q";
		subject.EquipmentNumber = "p";
		subject.BillOfLadingWaybillNumber = "M";
		subject.TypeOfServiceCode = "FU";
		subject.LocationIdentifier = "t";
		subject.Quantity = 3;
		subject.PackagingCode = "2dW";
		subject.DispositionCode = "oj";
		subject.StandardCarrierAlphaCode = "lE";
		subject.ReferenceIdentificationQualifier = "4e";
		subject.ReferenceIdentificationQualifier2 = "UD";
		subject.ReferenceIdentification2 = "4";
		subject.ReferenceIdentification = referenceIdentification;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("UD", true)]
	public void Validation_RequiredReferenceIdentificationQualifier2(string referenceIdentificationQualifier2, bool isValidExpected)
	{
		var subject = new CD1_CargoDetail();
		subject.EquipmentInitial = "Q";
		subject.EquipmentNumber = "p";
		subject.BillOfLadingWaybillNumber = "M";
		subject.TypeOfServiceCode = "FU";
		subject.LocationIdentifier = "t";
		subject.Quantity = 3;
		subject.PackagingCode = "2dW";
		subject.DispositionCode = "oj";
		subject.StandardCarrierAlphaCode = "lE";
		subject.ReferenceIdentificationQualifier = "4e";
		subject.ReferenceIdentification = "e";
		subject.ReferenceIdentification2 = "4";
		subject.ReferenceIdentificationQualifier2 = referenceIdentificationQualifier2;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("4", true)]
	public void Validation_RequiredReferenceIdentification2(string referenceIdentification2, bool isValidExpected)
	{
		var subject = new CD1_CargoDetail();
		subject.EquipmentInitial = "Q";
		subject.EquipmentNumber = "p";
		subject.BillOfLadingWaybillNumber = "M";
		subject.TypeOfServiceCode = "FU";
		subject.LocationIdentifier = "t";
		subject.Quantity = 3;
		subject.PackagingCode = "2dW";
		subject.DispositionCode = "oj";
		subject.StandardCarrierAlphaCode = "lE";
		subject.ReferenceIdentificationQualifier = "4e";
		subject.ReferenceIdentification = "e";
		subject.ReferenceIdentificationQualifier2 = "UD";
		subject.ReferenceIdentification2 = referenceIdentification2;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
