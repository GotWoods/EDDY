using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3060;

namespace Eddy.x12.Tests.Models.v3060;

public class CD1Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "CD1*Y*j*M03N*U*iC*I*Z*3mXpIo*M*9*ict*GG*3n*HJ*Q*ML*6*7*hO*7*U*hD*7*cGx*6fNzfL*1*xV*88*P*gX*D";

		var expected = new CD1_CargoDetail()
		{
			EquipmentInitial = "Y",
			EquipmentNumber = "j",
			EquipmentType = "M03N",
			BillOfLadingWaybillNumber = "U",
			TypeOfServiceCode = "iC",
			HazardousMaterialCodeQualifier = "I",
			HazardousMaterialClassCode = "Z",
			Date = "3mXpIo",
			LocationIdentifier = "M",
			Quantity = 9,
			PackagingCode = "ict",
			DispositionCode = "GG",
			DispositionCode2 = "3n",
			DispositionCode3 = "HJ",
			RateClassCode = "Q",
			RateValueQualifier = "ML",
			Rate = 6,
			RateClassCode2 = "7",
			RateValueQualifier2 = "hO",
			Rate2 = 7,
			RateClassCode3 = "U",
			RateValueQualifier3 = "hD",
			Rate3 = 7,
			DateTimeQualifier = "cGx",
			Date2 = "6fNzfL",
			StatusCode = "1",
			StandardCarrierAlphaCode = "xV",
			ReferenceIdentificationQualifier = "88",
			ReferenceIdentification = "P",
			ReferenceIdentificationQualifier2 = "gX",
			ReferenceIdentification2 = "D",
		};

		var actual = Map.MapObject<CD1_CargoDetail>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("Y", true)]
	public void Validation_RequiredEquipmentInitial(string equipmentInitial, bool isValidExpected)
	{
		var subject = new CD1_CargoDetail();
		subject.EquipmentNumber = "j";
		subject.BillOfLadingWaybillNumber = "U";
		subject.TypeOfServiceCode = "iC";
		subject.LocationIdentifier = "M";
		subject.Quantity = 9;
		subject.PackagingCode = "ict";
		subject.DispositionCode = "GG";
		subject.StandardCarrierAlphaCode = "xV";
		subject.ReferenceIdentificationQualifier = "88";
		subject.ReferenceIdentification = "P";
		subject.ReferenceIdentificationQualifier2 = "gX";
		subject.ReferenceIdentification2 = "D";
		subject.EquipmentInitial = equipmentInitial;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("j", true)]
	public void Validation_RequiredEquipmentNumber(string equipmentNumber, bool isValidExpected)
	{
		var subject = new CD1_CargoDetail();
		subject.EquipmentInitial = "Y";
		subject.BillOfLadingWaybillNumber = "U";
		subject.TypeOfServiceCode = "iC";
		subject.LocationIdentifier = "M";
		subject.Quantity = 9;
		subject.PackagingCode = "ict";
		subject.DispositionCode = "GG";
		subject.StandardCarrierAlphaCode = "xV";
		subject.ReferenceIdentificationQualifier = "88";
		subject.ReferenceIdentification = "P";
		subject.ReferenceIdentificationQualifier2 = "gX";
		subject.ReferenceIdentification2 = "D";
		subject.EquipmentNumber = equipmentNumber;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("U", true)]
	public void Validation_RequiredBillOfLadingWaybillNumber(string billOfLadingWaybillNumber, bool isValidExpected)
	{
		var subject = new CD1_CargoDetail();
		subject.EquipmentInitial = "Y";
		subject.EquipmentNumber = "j";
		subject.TypeOfServiceCode = "iC";
		subject.LocationIdentifier = "M";
		subject.Quantity = 9;
		subject.PackagingCode = "ict";
		subject.DispositionCode = "GG";
		subject.StandardCarrierAlphaCode = "xV";
		subject.ReferenceIdentificationQualifier = "88";
		subject.ReferenceIdentification = "P";
		subject.ReferenceIdentificationQualifier2 = "gX";
		subject.ReferenceIdentification2 = "D";
		subject.BillOfLadingWaybillNumber = billOfLadingWaybillNumber;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("iC", true)]
	public void Validation_RequiredTypeOfServiceCode(string typeOfServiceCode, bool isValidExpected)
	{
		var subject = new CD1_CargoDetail();
		subject.EquipmentInitial = "Y";
		subject.EquipmentNumber = "j";
		subject.BillOfLadingWaybillNumber = "U";
		subject.LocationIdentifier = "M";
		subject.Quantity = 9;
		subject.PackagingCode = "ict";
		subject.DispositionCode = "GG";
		subject.StandardCarrierAlphaCode = "xV";
		subject.ReferenceIdentificationQualifier = "88";
		subject.ReferenceIdentification = "P";
		subject.ReferenceIdentificationQualifier2 = "gX";
		subject.ReferenceIdentification2 = "D";
		subject.TypeOfServiceCode = typeOfServiceCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("M", true)]
	public void Validation_RequiredLocationIdentifier(string locationIdentifier, bool isValidExpected)
	{
		var subject = new CD1_CargoDetail();
		subject.EquipmentInitial = "Y";
		subject.EquipmentNumber = "j";
		subject.BillOfLadingWaybillNumber = "U";
		subject.TypeOfServiceCode = "iC";
		subject.Quantity = 9;
		subject.PackagingCode = "ict";
		subject.DispositionCode = "GG";
		subject.StandardCarrierAlphaCode = "xV";
		subject.ReferenceIdentificationQualifier = "88";
		subject.ReferenceIdentification = "P";
		subject.ReferenceIdentificationQualifier2 = "gX";
		subject.ReferenceIdentification2 = "D";
		subject.LocationIdentifier = locationIdentifier;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData(0, false)]
	[InlineData(9, true)]
	public void Validation_RequiredQuantity(decimal quantity, bool isValidExpected)
	{
		var subject = new CD1_CargoDetail();
		subject.EquipmentInitial = "Y";
		subject.EquipmentNumber = "j";
		subject.BillOfLadingWaybillNumber = "U";
		subject.TypeOfServiceCode = "iC";
		subject.LocationIdentifier = "M";
		subject.PackagingCode = "ict";
		subject.DispositionCode = "GG";
		subject.StandardCarrierAlphaCode = "xV";
		subject.ReferenceIdentificationQualifier = "88";
		subject.ReferenceIdentification = "P";
		subject.ReferenceIdentificationQualifier2 = "gX";
		subject.ReferenceIdentification2 = "D";
		if (quantity > 0)
			subject.Quantity = quantity;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("ict", true)]
	public void Validation_RequiredPackagingCode(string packagingCode, bool isValidExpected)
	{
		var subject = new CD1_CargoDetail();
		subject.EquipmentInitial = "Y";
		subject.EquipmentNumber = "j";
		subject.BillOfLadingWaybillNumber = "U";
		subject.TypeOfServiceCode = "iC";
		subject.LocationIdentifier = "M";
		subject.Quantity = 9;
		subject.DispositionCode = "GG";
		subject.StandardCarrierAlphaCode = "xV";
		subject.ReferenceIdentificationQualifier = "88";
		subject.ReferenceIdentification = "P";
		subject.ReferenceIdentificationQualifier2 = "gX";
		subject.ReferenceIdentification2 = "D";
		subject.PackagingCode = packagingCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("GG", true)]
	public void Validation_RequiredDispositionCode(string dispositionCode, bool isValidExpected)
	{
		var subject = new CD1_CargoDetail();
		subject.EquipmentInitial = "Y";
		subject.EquipmentNumber = "j";
		subject.BillOfLadingWaybillNumber = "U";
		subject.TypeOfServiceCode = "iC";
		subject.LocationIdentifier = "M";
		subject.Quantity = 9;
		subject.PackagingCode = "ict";
		subject.StandardCarrierAlphaCode = "xV";
		subject.ReferenceIdentificationQualifier = "88";
		subject.ReferenceIdentification = "P";
		subject.ReferenceIdentificationQualifier2 = "gX";
		subject.ReferenceIdentification2 = "D";
		subject.DispositionCode = dispositionCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("xV", true)]
	public void Validation_RequiredStandardCarrierAlphaCode(string standardCarrierAlphaCode, bool isValidExpected)
	{
		var subject = new CD1_CargoDetail();
		subject.EquipmentInitial = "Y";
		subject.EquipmentNumber = "j";
		subject.BillOfLadingWaybillNumber = "U";
		subject.TypeOfServiceCode = "iC";
		subject.LocationIdentifier = "M";
		subject.Quantity = 9;
		subject.PackagingCode = "ict";
		subject.DispositionCode = "GG";
		subject.ReferenceIdentificationQualifier = "88";
		subject.ReferenceIdentification = "P";
		subject.ReferenceIdentificationQualifier2 = "gX";
		subject.ReferenceIdentification2 = "D";
		subject.StandardCarrierAlphaCode = standardCarrierAlphaCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("88", true)]
	public void Validation_RequiredReferenceIdentificationQualifier(string referenceIdentificationQualifier, bool isValidExpected)
	{
		var subject = new CD1_CargoDetail();
		subject.EquipmentInitial = "Y";
		subject.EquipmentNumber = "j";
		subject.BillOfLadingWaybillNumber = "U";
		subject.TypeOfServiceCode = "iC";
		subject.LocationIdentifier = "M";
		subject.Quantity = 9;
		subject.PackagingCode = "ict";
		subject.DispositionCode = "GG";
		subject.StandardCarrierAlphaCode = "xV";
		subject.ReferenceIdentification = "P";
		subject.ReferenceIdentificationQualifier2 = "gX";
		subject.ReferenceIdentification2 = "D";
		subject.ReferenceIdentificationQualifier = referenceIdentificationQualifier;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("P", true)]
	public void Validation_RequiredReferenceIdentification(string referenceIdentification, bool isValidExpected)
	{
		var subject = new CD1_CargoDetail();
		subject.EquipmentInitial = "Y";
		subject.EquipmentNumber = "j";
		subject.BillOfLadingWaybillNumber = "U";
		subject.TypeOfServiceCode = "iC";
		subject.LocationIdentifier = "M";
		subject.Quantity = 9;
		subject.PackagingCode = "ict";
		subject.DispositionCode = "GG";
		subject.StandardCarrierAlphaCode = "xV";
		subject.ReferenceIdentificationQualifier = "88";
		subject.ReferenceIdentificationQualifier2 = "gX";
		subject.ReferenceIdentification2 = "D";
		subject.ReferenceIdentification = referenceIdentification;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("gX", true)]
	public void Validation_RequiredReferenceIdentificationQualifier2(string referenceIdentificationQualifier2, bool isValidExpected)
	{
		var subject = new CD1_CargoDetail();
		subject.EquipmentInitial = "Y";
		subject.EquipmentNumber = "j";
		subject.BillOfLadingWaybillNumber = "U";
		subject.TypeOfServiceCode = "iC";
		subject.LocationIdentifier = "M";
		subject.Quantity = 9;
		subject.PackagingCode = "ict";
		subject.DispositionCode = "GG";
		subject.StandardCarrierAlphaCode = "xV";
		subject.ReferenceIdentificationQualifier = "88";
		subject.ReferenceIdentification = "P";
		subject.ReferenceIdentification2 = "D";
		subject.ReferenceIdentificationQualifier2 = referenceIdentificationQualifier2;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("D", true)]
	public void Validation_RequiredReferenceIdentification2(string referenceIdentification2, bool isValidExpected)
	{
		var subject = new CD1_CargoDetail();
		subject.EquipmentInitial = "Y";
		subject.EquipmentNumber = "j";
		subject.BillOfLadingWaybillNumber = "U";
		subject.TypeOfServiceCode = "iC";
		subject.LocationIdentifier = "M";
		subject.Quantity = 9;
		subject.PackagingCode = "ict";
		subject.DispositionCode = "GG";
		subject.StandardCarrierAlphaCode = "xV";
		subject.ReferenceIdentificationQualifier = "88";
		subject.ReferenceIdentification = "P";
		subject.ReferenceIdentificationQualifier2 = "gX";
		subject.ReferenceIdentification2 = referenceIdentification2;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
