using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3040;

namespace Eddy.x12.Tests.Models.v3040;

public class CD1Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "CD1*r*Z*Gd0S*K*Om*r*ZK*35pfRy*f*7*VQBbO*Kr*HQ*tb*8*hK*8*4*TB*2*l*kl*1*WTO*3l9vvh*0*14*tF*V*v1*q";

		var expected = new CD1_CargoDetail()
		{
			EquipmentInitial = "r",
			EquipmentNumber = "Z",
			EquipmentType = "Gd0S",
			BillOfLadingWaybillNumber = "K",
			TypeOfServiceCode = "Om",
			HazardousMaterialCodeQualifier = "r",
			HazardousMaterialClassCode = "ZK",
			Date = "35pfRy",
			LocationIdentifier = "f",
			Quantity = 7,
			PackagingCode = "VQBbO",
			DispositionCode = "Kr",
			DispositionCode2 = "HQ",
			DispositionCode3 = "tb",
			RateClassCode = "8",
			RateValueQualifier = "hK",
			Rate = 8,
			RateClassCode2 = "4",
			RateValueQualifier2 = "TB",
			Rate2 = 2,
			RateClassCode3 = "l",
			RateValueQualifier3 = "kl",
			Rate3 = 1,
			DateTimeQualifier = "WTO",
			DeliveryDate = "3l9vvh",
			StatusCode = "0",
			StandardCarrierAlphaCode = "14",
			ReferenceNumberQualifier = "tF",
			ReferenceNumber = "V",
			ReferenceNumberQualifier2 = "v1",
			ReferenceNumber2 = "q",
		};

		var actual = Map.MapObject<CD1_CargoDetail>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("r", true)]
	public void Validation_RequiredEquipmentInitial(string equipmentInitial, bool isValidExpected)
	{
		var subject = new CD1_CargoDetail();
		subject.EquipmentNumber = "Z";
		subject.BillOfLadingWaybillNumber = "K";
		subject.TypeOfServiceCode = "Om";
		subject.LocationIdentifier = "f";
		subject.Quantity = 7;
		subject.PackagingCode = "VQBbO";
		subject.DispositionCode = "Kr";
		subject.StandardCarrierAlphaCode = "14";
		subject.ReferenceNumberQualifier = "tF";
		subject.ReferenceNumber = "V";
		subject.ReferenceNumberQualifier2 = "v1";
		subject.ReferenceNumber2 = "q";
		subject.EquipmentInitial = equipmentInitial;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("Z", true)]
	public void Validation_RequiredEquipmentNumber(string equipmentNumber, bool isValidExpected)
	{
		var subject = new CD1_CargoDetail();
		subject.EquipmentInitial = "r";
		subject.BillOfLadingWaybillNumber = "K";
		subject.TypeOfServiceCode = "Om";
		subject.LocationIdentifier = "f";
		subject.Quantity = 7;
		subject.PackagingCode = "VQBbO";
		subject.DispositionCode = "Kr";
		subject.StandardCarrierAlphaCode = "14";
		subject.ReferenceNumberQualifier = "tF";
		subject.ReferenceNumber = "V";
		subject.ReferenceNumberQualifier2 = "v1";
		subject.ReferenceNumber2 = "q";
		subject.EquipmentNumber = equipmentNumber;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("K", true)]
	public void Validation_RequiredBillOfLadingWaybillNumber(string billOfLadingWaybillNumber, bool isValidExpected)
	{
		var subject = new CD1_CargoDetail();
		subject.EquipmentInitial = "r";
		subject.EquipmentNumber = "Z";
		subject.TypeOfServiceCode = "Om";
		subject.LocationIdentifier = "f";
		subject.Quantity = 7;
		subject.PackagingCode = "VQBbO";
		subject.DispositionCode = "Kr";
		subject.StandardCarrierAlphaCode = "14";
		subject.ReferenceNumberQualifier = "tF";
		subject.ReferenceNumber = "V";
		subject.ReferenceNumberQualifier2 = "v1";
		subject.ReferenceNumber2 = "q";
		subject.BillOfLadingWaybillNumber = billOfLadingWaybillNumber;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("Om", true)]
	public void Validation_RequiredTypeOfServiceCode(string typeOfServiceCode, bool isValidExpected)
	{
		var subject = new CD1_CargoDetail();
		subject.EquipmentInitial = "r";
		subject.EquipmentNumber = "Z";
		subject.BillOfLadingWaybillNumber = "K";
		subject.LocationIdentifier = "f";
		subject.Quantity = 7;
		subject.PackagingCode = "VQBbO";
		subject.DispositionCode = "Kr";
		subject.StandardCarrierAlphaCode = "14";
		subject.ReferenceNumberQualifier = "tF";
		subject.ReferenceNumber = "V";
		subject.ReferenceNumberQualifier2 = "v1";
		subject.ReferenceNumber2 = "q";
		subject.TypeOfServiceCode = typeOfServiceCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("f", true)]
	public void Validation_RequiredLocationIdentifier(string locationIdentifier, bool isValidExpected)
	{
		var subject = new CD1_CargoDetail();
		subject.EquipmentInitial = "r";
		subject.EquipmentNumber = "Z";
		subject.BillOfLadingWaybillNumber = "K";
		subject.TypeOfServiceCode = "Om";
		subject.Quantity = 7;
		subject.PackagingCode = "VQBbO";
		subject.DispositionCode = "Kr";
		subject.StandardCarrierAlphaCode = "14";
		subject.ReferenceNumberQualifier = "tF";
		subject.ReferenceNumber = "V";
		subject.ReferenceNumberQualifier2 = "v1";
		subject.ReferenceNumber2 = "q";
		subject.LocationIdentifier = locationIdentifier;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData(0, false)]
	[InlineData(7, true)]
	public void Validation_RequiredQuantity(decimal quantity, bool isValidExpected)
	{
		var subject = new CD1_CargoDetail();
		subject.EquipmentInitial = "r";
		subject.EquipmentNumber = "Z";
		subject.BillOfLadingWaybillNumber = "K";
		subject.TypeOfServiceCode = "Om";
		subject.LocationIdentifier = "f";
		subject.PackagingCode = "VQBbO";
		subject.DispositionCode = "Kr";
		subject.StandardCarrierAlphaCode = "14";
		subject.ReferenceNumberQualifier = "tF";
		subject.ReferenceNumber = "V";
		subject.ReferenceNumberQualifier2 = "v1";
		subject.ReferenceNumber2 = "q";
		if (quantity > 0)
			subject.Quantity = quantity;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("VQBbO", true)]
	public void Validation_RequiredPackagingCode(string packagingCode, bool isValidExpected)
	{
		var subject = new CD1_CargoDetail();
		subject.EquipmentInitial = "r";
		subject.EquipmentNumber = "Z";
		subject.BillOfLadingWaybillNumber = "K";
		subject.TypeOfServiceCode = "Om";
		subject.LocationIdentifier = "f";
		subject.Quantity = 7;
		subject.DispositionCode = "Kr";
		subject.StandardCarrierAlphaCode = "14";
		subject.ReferenceNumberQualifier = "tF";
		subject.ReferenceNumber = "V";
		subject.ReferenceNumberQualifier2 = "v1";
		subject.ReferenceNumber2 = "q";
		subject.PackagingCode = packagingCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("Kr", true)]
	public void Validation_RequiredDispositionCode(string dispositionCode, bool isValidExpected)
	{
		var subject = new CD1_CargoDetail();
		subject.EquipmentInitial = "r";
		subject.EquipmentNumber = "Z";
		subject.BillOfLadingWaybillNumber = "K";
		subject.TypeOfServiceCode = "Om";
		subject.LocationIdentifier = "f";
		subject.Quantity = 7;
		subject.PackagingCode = "VQBbO";
		subject.StandardCarrierAlphaCode = "14";
		subject.ReferenceNumberQualifier = "tF";
		subject.ReferenceNumber = "V";
		subject.ReferenceNumberQualifier2 = "v1";
		subject.ReferenceNumber2 = "q";
		subject.DispositionCode = dispositionCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("14", true)]
	public void Validation_RequiredStandardCarrierAlphaCode(string standardCarrierAlphaCode, bool isValidExpected)
	{
		var subject = new CD1_CargoDetail();
		subject.EquipmentInitial = "r";
		subject.EquipmentNumber = "Z";
		subject.BillOfLadingWaybillNumber = "K";
		subject.TypeOfServiceCode = "Om";
		subject.LocationIdentifier = "f";
		subject.Quantity = 7;
		subject.PackagingCode = "VQBbO";
		subject.DispositionCode = "Kr";
		subject.ReferenceNumberQualifier = "tF";
		subject.ReferenceNumber = "V";
		subject.ReferenceNumberQualifier2 = "v1";
		subject.ReferenceNumber2 = "q";
		subject.StandardCarrierAlphaCode = standardCarrierAlphaCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("tF", true)]
	public void Validation_RequiredReferenceNumberQualifier(string referenceNumberQualifier, bool isValidExpected)
	{
		var subject = new CD1_CargoDetail();
		subject.EquipmentInitial = "r";
		subject.EquipmentNumber = "Z";
		subject.BillOfLadingWaybillNumber = "K";
		subject.TypeOfServiceCode = "Om";
		subject.LocationIdentifier = "f";
		subject.Quantity = 7;
		subject.PackagingCode = "VQBbO";
		subject.DispositionCode = "Kr";
		subject.StandardCarrierAlphaCode = "14";
		subject.ReferenceNumber = "V";
		subject.ReferenceNumberQualifier2 = "v1";
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
		subject.EquipmentInitial = "r";
		subject.EquipmentNumber = "Z";
		subject.BillOfLadingWaybillNumber = "K";
		subject.TypeOfServiceCode = "Om";
		subject.LocationIdentifier = "f";
		subject.Quantity = 7;
		subject.PackagingCode = "VQBbO";
		subject.DispositionCode = "Kr";
		subject.StandardCarrierAlphaCode = "14";
		subject.ReferenceNumberQualifier = "tF";
		subject.ReferenceNumberQualifier2 = "v1";
		subject.ReferenceNumber2 = "q";
		subject.ReferenceNumber = referenceNumber;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("v1", true)]
	public void Validation_RequiredReferenceNumberQualifier2(string referenceNumberQualifier2, bool isValidExpected)
	{
		var subject = new CD1_CargoDetail();
		subject.EquipmentInitial = "r";
		subject.EquipmentNumber = "Z";
		subject.BillOfLadingWaybillNumber = "K";
		subject.TypeOfServiceCode = "Om";
		subject.LocationIdentifier = "f";
		subject.Quantity = 7;
		subject.PackagingCode = "VQBbO";
		subject.DispositionCode = "Kr";
		subject.StandardCarrierAlphaCode = "14";
		subject.ReferenceNumberQualifier = "tF";
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
		subject.EquipmentInitial = "r";
		subject.EquipmentNumber = "Z";
		subject.BillOfLadingWaybillNumber = "K";
		subject.TypeOfServiceCode = "Om";
		subject.LocationIdentifier = "f";
		subject.Quantity = 7;
		subject.PackagingCode = "VQBbO";
		subject.DispositionCode = "Kr";
		subject.StandardCarrierAlphaCode = "14";
		subject.ReferenceNumberQualifier = "tF";
		subject.ReferenceNumber = "V";
		subject.ReferenceNumberQualifier2 = "v1";
		subject.ReferenceNumber2 = referenceNumber2;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
