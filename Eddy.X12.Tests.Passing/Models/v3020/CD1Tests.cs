using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3020;

namespace Eddy.x12.Tests.Models.v3020;

public class CD1Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "CD1*K*Q*gFgz*Q*zA*G*XY*4xyWMy*S*3*NWOG7*Fu*4O*xg*F*mI*4*d*UL*2*l*hQ*6*2Sd*0c6EbS*8*jm*zF*V*oZ*q";

		var expected = new CD1_CargoDetail()
		{
			EquipmentInitial = "K",
			EquipmentNumber = "Q",
			EquipmentType = "gFgz",
			BillOfLadingWaybillNumber = "Q",
			TypeOfServiceCode = "zA",
			HazardousMaterialCodeQualifier = "G",
			HazardousMaterialClassCode = "XY",
			Date = "4xyWMy",
			LocationIdentifier = "S",
			Quantity = 3,
			PackagingCode = "NWOG7",
			DispositionCode = "Fu",
			DispositionCode2 = "4O",
			DispositionCode3 = "xg",
			RateClassCode = "F",
			RateValueQualifier = "mI",
			Rate = 4,
			RateClassCode2 = "d",
			RateValueQualifier2 = "UL",
			Rate2 = 2,
			RateClassCode3 = "l",
			RateValueQualifier3 = "hQ",
			Rate3 = 6,
			DateTimeQualifier = "2Sd",
			DeliveryDate = "0c6EbS",
			StatusCode = "8",
			StandardCarrierAlphaCode = "jm",
			ReferenceNumberQualifier = "zF",
			ReferenceNumber = "V",
			ReferenceNumberQualifier2 = "oZ",
			ReferenceNumber2 = "q",
		};

		var actual = Map.MapObject<CD1_CargoDetail>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("K", true)]
	public void Validation_RequiredEquipmentInitial(string equipmentInitial, bool isValidExpected)
	{
		var subject = new CD1_CargoDetail();
		subject.EquipmentNumber = "Q";
		subject.BillOfLadingWaybillNumber = "Q";
		subject.TypeOfServiceCode = "zA";
		subject.LocationIdentifier = "S";
		subject.Quantity = 3;
		subject.PackagingCode = "NWOG7";
		subject.DispositionCode = "Fu";
		subject.StandardCarrierAlphaCode = "jm";
		subject.ReferenceNumberQualifier = "zF";
		subject.ReferenceNumber = "V";
		subject.ReferenceNumberQualifier2 = "oZ";
		subject.ReferenceNumber2 = "q";
		subject.EquipmentInitial = equipmentInitial;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("Q", true)]
	public void Validation_RequiredEquipmentNumber(string equipmentNumber, bool isValidExpected)
	{
		var subject = new CD1_CargoDetail();
		subject.EquipmentInitial = "K";
		subject.BillOfLadingWaybillNumber = "Q";
		subject.TypeOfServiceCode = "zA";
		subject.LocationIdentifier = "S";
		subject.Quantity = 3;
		subject.PackagingCode = "NWOG7";
		subject.DispositionCode = "Fu";
		subject.StandardCarrierAlphaCode = "jm";
		subject.ReferenceNumberQualifier = "zF";
		subject.ReferenceNumber = "V";
		subject.ReferenceNumberQualifier2 = "oZ";
		subject.ReferenceNumber2 = "q";
		subject.EquipmentNumber = equipmentNumber;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("Q", true)]
	public void Validation_RequiredBillOfLadingWaybillNumber(string billOfLadingWaybillNumber, bool isValidExpected)
	{
		var subject = new CD1_CargoDetail();
		subject.EquipmentInitial = "K";
		subject.EquipmentNumber = "Q";
		subject.TypeOfServiceCode = "zA";
		subject.LocationIdentifier = "S";
		subject.Quantity = 3;
		subject.PackagingCode = "NWOG7";
		subject.DispositionCode = "Fu";
		subject.StandardCarrierAlphaCode = "jm";
		subject.ReferenceNumberQualifier = "zF";
		subject.ReferenceNumber = "V";
		subject.ReferenceNumberQualifier2 = "oZ";
		subject.ReferenceNumber2 = "q";
		subject.BillOfLadingWaybillNumber = billOfLadingWaybillNumber;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("zA", true)]
	public void Validation_RequiredTypeOfServiceCode(string typeOfServiceCode, bool isValidExpected)
	{
		var subject = new CD1_CargoDetail();
		subject.EquipmentInitial = "K";
		subject.EquipmentNumber = "Q";
		subject.BillOfLadingWaybillNumber = "Q";
		subject.LocationIdentifier = "S";
		subject.Quantity = 3;
		subject.PackagingCode = "NWOG7";
		subject.DispositionCode = "Fu";
		subject.StandardCarrierAlphaCode = "jm";
		subject.ReferenceNumberQualifier = "zF";
		subject.ReferenceNumber = "V";
		subject.ReferenceNumberQualifier2 = "oZ";
		subject.ReferenceNumber2 = "q";
		subject.TypeOfServiceCode = typeOfServiceCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("S", true)]
	public void Validation_RequiredLocationIdentifier(string locationIdentifier, bool isValidExpected)
	{
		var subject = new CD1_CargoDetail();
		subject.EquipmentInitial = "K";
		subject.EquipmentNumber = "Q";
		subject.BillOfLadingWaybillNumber = "Q";
		subject.TypeOfServiceCode = "zA";
		subject.Quantity = 3;
		subject.PackagingCode = "NWOG7";
		subject.DispositionCode = "Fu";
		subject.StandardCarrierAlphaCode = "jm";
		subject.ReferenceNumberQualifier = "zF";
		subject.ReferenceNumber = "V";
		subject.ReferenceNumberQualifier2 = "oZ";
		subject.ReferenceNumber2 = "q";
		subject.LocationIdentifier = locationIdentifier;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData(0, false)]
	[InlineData(3, true)]
	public void Validation_RequiredQuantity(decimal quantity, bool isValidExpected)
	{
		var subject = new CD1_CargoDetail();
		subject.EquipmentInitial = "K";
		subject.EquipmentNumber = "Q";
		subject.BillOfLadingWaybillNumber = "Q";
		subject.TypeOfServiceCode = "zA";
		subject.LocationIdentifier = "S";
		subject.PackagingCode = "NWOG7";
		subject.DispositionCode = "Fu";
		subject.StandardCarrierAlphaCode = "jm";
		subject.ReferenceNumberQualifier = "zF";
		subject.ReferenceNumber = "V";
		subject.ReferenceNumberQualifier2 = "oZ";
		subject.ReferenceNumber2 = "q";
		if (quantity > 0)
			subject.Quantity = quantity;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("NWOG7", true)]
	public void Validation_RequiredPackagingCode(string packagingCode, bool isValidExpected)
	{
		var subject = new CD1_CargoDetail();
		subject.EquipmentInitial = "K";
		subject.EquipmentNumber = "Q";
		subject.BillOfLadingWaybillNumber = "Q";
		subject.TypeOfServiceCode = "zA";
		subject.LocationIdentifier = "S";
		subject.Quantity = 3;
		subject.DispositionCode = "Fu";
		subject.StandardCarrierAlphaCode = "jm";
		subject.ReferenceNumberQualifier = "zF";
		subject.ReferenceNumber = "V";
		subject.ReferenceNumberQualifier2 = "oZ";
		subject.ReferenceNumber2 = "q";
		subject.PackagingCode = packagingCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("Fu", true)]
	public void Validation_RequiredDispositionCode(string dispositionCode, bool isValidExpected)
	{
		var subject = new CD1_CargoDetail();
		subject.EquipmentInitial = "K";
		subject.EquipmentNumber = "Q";
		subject.BillOfLadingWaybillNumber = "Q";
		subject.TypeOfServiceCode = "zA";
		subject.LocationIdentifier = "S";
		subject.Quantity = 3;
		subject.PackagingCode = "NWOG7";
		subject.StandardCarrierAlphaCode = "jm";
		subject.ReferenceNumberQualifier = "zF";
		subject.ReferenceNumber = "V";
		subject.ReferenceNumberQualifier2 = "oZ";
		subject.ReferenceNumber2 = "q";
		subject.DispositionCode = dispositionCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("jm", true)]
	public void Validation_RequiredStandardCarrierAlphaCode(string standardCarrierAlphaCode, bool isValidExpected)
	{
		var subject = new CD1_CargoDetail();
		subject.EquipmentInitial = "K";
		subject.EquipmentNumber = "Q";
		subject.BillOfLadingWaybillNumber = "Q";
		subject.TypeOfServiceCode = "zA";
		subject.LocationIdentifier = "S";
		subject.Quantity = 3;
		subject.PackagingCode = "NWOG7";
		subject.DispositionCode = "Fu";
		subject.ReferenceNumberQualifier = "zF";
		subject.ReferenceNumber = "V";
		subject.ReferenceNumberQualifier2 = "oZ";
		subject.ReferenceNumber2 = "q";
		subject.StandardCarrierAlphaCode = standardCarrierAlphaCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("zF", true)]
	public void Validation_RequiredReferenceNumberQualifier(string referenceNumberQualifier, bool isValidExpected)
	{
		var subject = new CD1_CargoDetail();
		subject.EquipmentInitial = "K";
		subject.EquipmentNumber = "Q";
		subject.BillOfLadingWaybillNumber = "Q";
		subject.TypeOfServiceCode = "zA";
		subject.LocationIdentifier = "S";
		subject.Quantity = 3;
		subject.PackagingCode = "NWOG7";
		subject.DispositionCode = "Fu";
		subject.StandardCarrierAlphaCode = "jm";
		subject.ReferenceNumber = "V";
		subject.ReferenceNumberQualifier2 = "oZ";
		subject.ReferenceNumber2 = "q";
		subject.ReferenceNumberQualifier = referenceNumberQualifier;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("V", true)]
	public void Validation_RequiredReferenceNumber(string referenceNumber, bool isValidExpected)
	{
		var subject = new CD1_CargoDetail();
		subject.EquipmentInitial = "K";
		subject.EquipmentNumber = "Q";
		subject.BillOfLadingWaybillNumber = "Q";
		subject.TypeOfServiceCode = "zA";
		subject.LocationIdentifier = "S";
		subject.Quantity = 3;
		subject.PackagingCode = "NWOG7";
		subject.DispositionCode = "Fu";
		subject.StandardCarrierAlphaCode = "jm";
		subject.ReferenceNumberQualifier = "zF";
		subject.ReferenceNumberQualifier2 = "oZ";
		subject.ReferenceNumber2 = "q";
		subject.ReferenceNumber = referenceNumber;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("oZ", true)]
	public void Validation_RequiredReferenceNumberQualifier2(string referenceNumberQualifier2, bool isValidExpected)
	{
		var subject = new CD1_CargoDetail();
		subject.EquipmentInitial = "K";
		subject.EquipmentNumber = "Q";
		subject.BillOfLadingWaybillNumber = "Q";
		subject.TypeOfServiceCode = "zA";
		subject.LocationIdentifier = "S";
		subject.Quantity = 3;
		subject.PackagingCode = "NWOG7";
		subject.DispositionCode = "Fu";
		subject.StandardCarrierAlphaCode = "jm";
		subject.ReferenceNumberQualifier = "zF";
		subject.ReferenceNumber = "V";
		subject.ReferenceNumber2 = "q";
		subject.ReferenceNumberQualifier2 = referenceNumberQualifier2;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("q", true)]
	public void Validation_RequiredReferenceNumber2(string referenceNumber2, bool isValidExpected)
	{
		var subject = new CD1_CargoDetail();
		subject.EquipmentInitial = "K";
		subject.EquipmentNumber = "Q";
		subject.BillOfLadingWaybillNumber = "Q";
		subject.TypeOfServiceCode = "zA";
		subject.LocationIdentifier = "S";
		subject.Quantity = 3;
		subject.PackagingCode = "NWOG7";
		subject.DispositionCode = "Fu";
		subject.StandardCarrierAlphaCode = "jm";
		subject.ReferenceNumberQualifier = "zF";
		subject.ReferenceNumber = "V";
		subject.ReferenceNumberQualifier2 = "oZ";
		subject.ReferenceNumber2 = referenceNumber2;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
