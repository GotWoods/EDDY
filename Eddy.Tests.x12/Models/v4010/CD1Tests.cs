using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v4010;

namespace Eddy.x12.Tests.Models.v4010;

public class CD1Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "CD1*w*m*c4PS*9*n2*0*n*Kkijn6dC*0*5*HAO*xE*LQ*tG*w*qv*7*i*wv*3*A*bs*1*r9s*mq6t2B81*Z*3m*yS*q*9X*U";

		var expected = new CD1_CargoDetail()
		{
			EquipmentInitial = "w",
			EquipmentNumber = "m",
			EquipmentType = "c4PS",
			BillOfLadingWaybillNumber = "9",
			TypeOfServiceCode = "n2",
			HazardousMaterialCodeQualifier = "0",
			HazardousMaterialClassCode = "n",
			Date = "Kkijn6dC",
			LocationIdentifier = "0",
			Quantity = 5,
			PackagingCode = "HAO",
			DispositionCode = "xE",
			DispositionCode2 = "LQ",
			DispositionCode3 = "tG",
			RateClassCode = "w",
			RateValueQualifier = "qv",
			Rate = 7,
			RateClassCode2 = "i",
			RateValueQualifier2 = "wv",
			Rate2 = 3,
			RateClassCode3 = "A",
			RateValueQualifier3 = "bs",
			Rate3 = 1,
			DateTimeQualifier = "r9s",
			Date2 = "mq6t2B81",
			ShipmentStatusCode = "Z",
			StandardCarrierAlphaCode = "3m",
			ReferenceIdentificationQualifier = "yS",
			ReferenceIdentification = "q",
			ReferenceIdentificationQualifier2 = "9X",
			ReferenceIdentification2 = "U",
		};

		var actual = Map.MapObject<CD1_CargoDetail>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("w", true)]
	public void Validation_RequiredEquipmentInitial(string equipmentInitial, bool isValidExpected)
	{
		var subject = new CD1_CargoDetail();
		subject.EquipmentNumber = "m";
		subject.BillOfLadingWaybillNumber = "9";
		subject.TypeOfServiceCode = "n2";
		subject.LocationIdentifier = "0";
		subject.Quantity = 5;
		subject.PackagingCode = "HAO";
		subject.DispositionCode = "xE";
		subject.StandardCarrierAlphaCode = "3m";
		subject.ReferenceIdentificationQualifier = "yS";
		subject.ReferenceIdentification = "q";
		subject.ReferenceIdentificationQualifier2 = "9X";
		subject.ReferenceIdentification2 = "U";
		subject.EquipmentInitial = equipmentInitial;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("m", true)]
	public void Validation_RequiredEquipmentNumber(string equipmentNumber, bool isValidExpected)
	{
		var subject = new CD1_CargoDetail();
		subject.EquipmentInitial = "w";
		subject.BillOfLadingWaybillNumber = "9";
		subject.TypeOfServiceCode = "n2";
		subject.LocationIdentifier = "0";
		subject.Quantity = 5;
		subject.PackagingCode = "HAO";
		subject.DispositionCode = "xE";
		subject.StandardCarrierAlphaCode = "3m";
		subject.ReferenceIdentificationQualifier = "yS";
		subject.ReferenceIdentification = "q";
		subject.ReferenceIdentificationQualifier2 = "9X";
		subject.ReferenceIdentification2 = "U";
		subject.EquipmentNumber = equipmentNumber;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("9", true)]
	public void Validation_RequiredBillOfLadingWaybillNumber(string billOfLadingWaybillNumber, bool isValidExpected)
	{
		var subject = new CD1_CargoDetail();
		subject.EquipmentInitial = "w";
		subject.EquipmentNumber = "m";
		subject.TypeOfServiceCode = "n2";
		subject.LocationIdentifier = "0";
		subject.Quantity = 5;
		subject.PackagingCode = "HAO";
		subject.DispositionCode = "xE";
		subject.StandardCarrierAlphaCode = "3m";
		subject.ReferenceIdentificationQualifier = "yS";
		subject.ReferenceIdentification = "q";
		subject.ReferenceIdentificationQualifier2 = "9X";
		subject.ReferenceIdentification2 = "U";
		subject.BillOfLadingWaybillNumber = billOfLadingWaybillNumber;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("n2", true)]
	public void Validation_RequiredTypeOfServiceCode(string typeOfServiceCode, bool isValidExpected)
	{
		var subject = new CD1_CargoDetail();
		subject.EquipmentInitial = "w";
		subject.EquipmentNumber = "m";
		subject.BillOfLadingWaybillNumber = "9";
		subject.LocationIdentifier = "0";
		subject.Quantity = 5;
		subject.PackagingCode = "HAO";
		subject.DispositionCode = "xE";
		subject.StandardCarrierAlphaCode = "3m";
		subject.ReferenceIdentificationQualifier = "yS";
		subject.ReferenceIdentification = "q";
		subject.ReferenceIdentificationQualifier2 = "9X";
		subject.ReferenceIdentification2 = "U";
		subject.TypeOfServiceCode = typeOfServiceCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("0", true)]
	public void Validation_RequiredLocationIdentifier(string locationIdentifier, bool isValidExpected)
	{
		var subject = new CD1_CargoDetail();
		subject.EquipmentInitial = "w";
		subject.EquipmentNumber = "m";
		subject.BillOfLadingWaybillNumber = "9";
		subject.TypeOfServiceCode = "n2";
		subject.Quantity = 5;
		subject.PackagingCode = "HAO";
		subject.DispositionCode = "xE";
		subject.StandardCarrierAlphaCode = "3m";
		subject.ReferenceIdentificationQualifier = "yS";
		subject.ReferenceIdentification = "q";
		subject.ReferenceIdentificationQualifier2 = "9X";
		subject.ReferenceIdentification2 = "U";
		subject.LocationIdentifier = locationIdentifier;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData(0, false)]
	[InlineData(5, true)]
	public void Validation_RequiredQuantity(decimal quantity, bool isValidExpected)
	{
		var subject = new CD1_CargoDetail();
		subject.EquipmentInitial = "w";
		subject.EquipmentNumber = "m";
		subject.BillOfLadingWaybillNumber = "9";
		subject.TypeOfServiceCode = "n2";
		subject.LocationIdentifier = "0";
		subject.PackagingCode = "HAO";
		subject.DispositionCode = "xE";
		subject.StandardCarrierAlphaCode = "3m";
		subject.ReferenceIdentificationQualifier = "yS";
		subject.ReferenceIdentification = "q";
		subject.ReferenceIdentificationQualifier2 = "9X";
		subject.ReferenceIdentification2 = "U";
		if (quantity > 0)
			subject.Quantity = quantity;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("HAO", true)]
	public void Validation_RequiredPackagingCode(string packagingCode, bool isValidExpected)
	{
		var subject = new CD1_CargoDetail();
		subject.EquipmentInitial = "w";
		subject.EquipmentNumber = "m";
		subject.BillOfLadingWaybillNumber = "9";
		subject.TypeOfServiceCode = "n2";
		subject.LocationIdentifier = "0";
		subject.Quantity = 5;
		subject.DispositionCode = "xE";
		subject.StandardCarrierAlphaCode = "3m";
		subject.ReferenceIdentificationQualifier = "yS";
		subject.ReferenceIdentification = "q";
		subject.ReferenceIdentificationQualifier2 = "9X";
		subject.ReferenceIdentification2 = "U";
		subject.PackagingCode = packagingCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("xE", true)]
	public void Validation_RequiredDispositionCode(string dispositionCode, bool isValidExpected)
	{
		var subject = new CD1_CargoDetail();
		subject.EquipmentInitial = "w";
		subject.EquipmentNumber = "m";
		subject.BillOfLadingWaybillNumber = "9";
		subject.TypeOfServiceCode = "n2";
		subject.LocationIdentifier = "0";
		subject.Quantity = 5;
		subject.PackagingCode = "HAO";
		subject.StandardCarrierAlphaCode = "3m";
		subject.ReferenceIdentificationQualifier = "yS";
		subject.ReferenceIdentification = "q";
		subject.ReferenceIdentificationQualifier2 = "9X";
		subject.ReferenceIdentification2 = "U";
		subject.DispositionCode = dispositionCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("3m", true)]
	public void Validation_RequiredStandardCarrierAlphaCode(string standardCarrierAlphaCode, bool isValidExpected)
	{
		var subject = new CD1_CargoDetail();
		subject.EquipmentInitial = "w";
		subject.EquipmentNumber = "m";
		subject.BillOfLadingWaybillNumber = "9";
		subject.TypeOfServiceCode = "n2";
		subject.LocationIdentifier = "0";
		subject.Quantity = 5;
		subject.PackagingCode = "HAO";
		subject.DispositionCode = "xE";
		subject.ReferenceIdentificationQualifier = "yS";
		subject.ReferenceIdentification = "q";
		subject.ReferenceIdentificationQualifier2 = "9X";
		subject.ReferenceIdentification2 = "U";
		subject.StandardCarrierAlphaCode = standardCarrierAlphaCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("yS", true)]
	public void Validation_RequiredReferenceIdentificationQualifier(string referenceIdentificationQualifier, bool isValidExpected)
	{
		var subject = new CD1_CargoDetail();
		subject.EquipmentInitial = "w";
		subject.EquipmentNumber = "m";
		subject.BillOfLadingWaybillNumber = "9";
		subject.TypeOfServiceCode = "n2";
		subject.LocationIdentifier = "0";
		subject.Quantity = 5;
		subject.PackagingCode = "HAO";
		subject.DispositionCode = "xE";
		subject.StandardCarrierAlphaCode = "3m";
		subject.ReferenceIdentification = "q";
		subject.ReferenceIdentificationQualifier2 = "9X";
		subject.ReferenceIdentification2 = "U";
		subject.ReferenceIdentificationQualifier = referenceIdentificationQualifier;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("q", true)]
	public void Validation_RequiredReferenceIdentification(string referenceIdentification, bool isValidExpected)
	{
		var subject = new CD1_CargoDetail();
		subject.EquipmentInitial = "w";
		subject.EquipmentNumber = "m";
		subject.BillOfLadingWaybillNumber = "9";
		subject.TypeOfServiceCode = "n2";
		subject.LocationIdentifier = "0";
		subject.Quantity = 5;
		subject.PackagingCode = "HAO";
		subject.DispositionCode = "xE";
		subject.StandardCarrierAlphaCode = "3m";
		subject.ReferenceIdentificationQualifier = "yS";
		subject.ReferenceIdentificationQualifier2 = "9X";
		subject.ReferenceIdentification2 = "U";
		subject.ReferenceIdentification = referenceIdentification;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("9X", true)]
	public void Validation_RequiredReferenceIdentificationQualifier2(string referenceIdentificationQualifier2, bool isValidExpected)
	{
		var subject = new CD1_CargoDetail();
		subject.EquipmentInitial = "w";
		subject.EquipmentNumber = "m";
		subject.BillOfLadingWaybillNumber = "9";
		subject.TypeOfServiceCode = "n2";
		subject.LocationIdentifier = "0";
		subject.Quantity = 5;
		subject.PackagingCode = "HAO";
		subject.DispositionCode = "xE";
		subject.StandardCarrierAlphaCode = "3m";
		subject.ReferenceIdentificationQualifier = "yS";
		subject.ReferenceIdentification = "q";
		subject.ReferenceIdentification2 = "U";
		subject.ReferenceIdentificationQualifier2 = referenceIdentificationQualifier2;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("U", true)]
	public void Validation_RequiredReferenceIdentification2(string referenceIdentification2, bool isValidExpected)
	{
		var subject = new CD1_CargoDetail();
		subject.EquipmentInitial = "w";
		subject.EquipmentNumber = "m";
		subject.BillOfLadingWaybillNumber = "9";
		subject.TypeOfServiceCode = "n2";
		subject.LocationIdentifier = "0";
		subject.Quantity = 5;
		subject.PackagingCode = "HAO";
		subject.DispositionCode = "xE";
		subject.StandardCarrierAlphaCode = "3m";
		subject.ReferenceIdentificationQualifier = "yS";
		subject.ReferenceIdentification = "q";
		subject.ReferenceIdentificationQualifier2 = "9X";
		subject.ReferenceIdentification2 = referenceIdentification2;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
