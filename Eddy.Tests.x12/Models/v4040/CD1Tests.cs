using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v4040;

namespace Eddy.x12.Tests.Models.v4040;

public class CD1Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "CD1*T*j*hTDo*m*Q3*q*q*D8wjPC78*Y*3*sou*FQ*Sr*yu*2*cI*6*v*5a*6*x*iK*1*5x1*q62f6JWk*c*hl*Pg*P*i9*b";

		var expected = new CD1_CargoDetail()
		{
			EquipmentInitial = "T",
			EquipmentNumber = "j",
			EquipmentType = "hTDo",
			BillOfLadingWaybillNumber = "m",
			TypeOfServiceCode = "Q3",
			HazardousMaterialCodeQualifier = "q",
			HazardousMaterialClassCode = "q",
			Date = "D8wjPC78",
			LocationIdentifier = "Y",
			Quantity = 3,
			PackagingCode = "sou",
			DispositionCode = "FQ",
			DispositionCode2 = "Sr",
			DispositionCode3 = "yu",
			RateClassCode = "2",
			RateValueQualifier = "cI",
			Rate = 6,
			RateClassCode2 = "v",
			RateValueQualifier2 = "5a",
			Rate2 = 6,
			RateClassCode3 = "x",
			RateValueQualifier3 = "iK",
			Rate3 = 1,
			DateTimeQualifier = "5x1",
			Date2 = "q62f6JWk",
			ShipmentStatusCode = "c",
			StandardCarrierAlphaCode = "hl",
			ReferenceIdentificationQualifier = "Pg",
			ReferenceIdentification = "P",
			ReferenceIdentificationQualifier2 = "i9",
			ReferenceIdentification2 = "b",
		};

		var actual = Map.MapObject<CD1_CargoDetail>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("T", true)]
	public void Validation_RequiredEquipmentInitial(string equipmentInitial, bool isValidExpected)
	{
		var subject = new CD1_CargoDetail();
		subject.EquipmentNumber = "j";
		subject.BillOfLadingWaybillNumber = "m";
		subject.TypeOfServiceCode = "Q3";
		subject.LocationIdentifier = "Y";
		subject.Quantity = 3;
		subject.PackagingCode = "sou";
		subject.DispositionCode = "FQ";
		subject.StandardCarrierAlphaCode = "hl";
		subject.ReferenceIdentificationQualifier = "Pg";
		subject.ReferenceIdentification = "P";
		subject.ReferenceIdentificationQualifier2 = "i9";
		subject.ReferenceIdentification2 = "b";
		subject.EquipmentInitial = equipmentInitial;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("j", true)]
	public void Validation_RequiredEquipmentNumber(string equipmentNumber, bool isValidExpected)
	{
		var subject = new CD1_CargoDetail();
		subject.EquipmentInitial = "T";
		subject.BillOfLadingWaybillNumber = "m";
		subject.TypeOfServiceCode = "Q3";
		subject.LocationIdentifier = "Y";
		subject.Quantity = 3;
		subject.PackagingCode = "sou";
		subject.DispositionCode = "FQ";
		subject.StandardCarrierAlphaCode = "hl";
		subject.ReferenceIdentificationQualifier = "Pg";
		subject.ReferenceIdentification = "P";
		subject.ReferenceIdentificationQualifier2 = "i9";
		subject.ReferenceIdentification2 = "b";
		subject.EquipmentNumber = equipmentNumber;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("m", true)]
	public void Validation_RequiredBillOfLadingWaybillNumber(string billOfLadingWaybillNumber, bool isValidExpected)
	{
		var subject = new CD1_CargoDetail();
		subject.EquipmentInitial = "T";
		subject.EquipmentNumber = "j";
		subject.TypeOfServiceCode = "Q3";
		subject.LocationIdentifier = "Y";
		subject.Quantity = 3;
		subject.PackagingCode = "sou";
		subject.DispositionCode = "FQ";
		subject.StandardCarrierAlphaCode = "hl";
		subject.ReferenceIdentificationQualifier = "Pg";
		subject.ReferenceIdentification = "P";
		subject.ReferenceIdentificationQualifier2 = "i9";
		subject.ReferenceIdentification2 = "b";
		subject.BillOfLadingWaybillNumber = billOfLadingWaybillNumber;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("Q3", true)]
	public void Validation_RequiredTypeOfServiceCode(string typeOfServiceCode, bool isValidExpected)
	{
		var subject = new CD1_CargoDetail();
		subject.EquipmentInitial = "T";
		subject.EquipmentNumber = "j";
		subject.BillOfLadingWaybillNumber = "m";
		subject.LocationIdentifier = "Y";
		subject.Quantity = 3;
		subject.PackagingCode = "sou";
		subject.DispositionCode = "FQ";
		subject.StandardCarrierAlphaCode = "hl";
		subject.ReferenceIdentificationQualifier = "Pg";
		subject.ReferenceIdentification = "P";
		subject.ReferenceIdentificationQualifier2 = "i9";
		subject.ReferenceIdentification2 = "b";
		subject.TypeOfServiceCode = typeOfServiceCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("Y", true)]
	public void Validation_RequiredLocationIdentifier(string locationIdentifier, bool isValidExpected)
	{
		var subject = new CD1_CargoDetail();
		subject.EquipmentInitial = "T";
		subject.EquipmentNumber = "j";
		subject.BillOfLadingWaybillNumber = "m";
		subject.TypeOfServiceCode = "Q3";
		subject.Quantity = 3;
		subject.PackagingCode = "sou";
		subject.DispositionCode = "FQ";
		subject.StandardCarrierAlphaCode = "hl";
		subject.ReferenceIdentificationQualifier = "Pg";
		subject.ReferenceIdentification = "P";
		subject.ReferenceIdentificationQualifier2 = "i9";
		subject.ReferenceIdentification2 = "b";
		subject.LocationIdentifier = locationIdentifier;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData(0, false)]
	[InlineData(3, true)]
	public void Validation_RequiredQuantity(decimal quantity, bool isValidExpected)
	{
		var subject = new CD1_CargoDetail();
		subject.EquipmentInitial = "T";
		subject.EquipmentNumber = "j";
		subject.BillOfLadingWaybillNumber = "m";
		subject.TypeOfServiceCode = "Q3";
		subject.LocationIdentifier = "Y";
		subject.PackagingCode = "sou";
		subject.DispositionCode = "FQ";
		subject.StandardCarrierAlphaCode = "hl";
		subject.ReferenceIdentificationQualifier = "Pg";
		subject.ReferenceIdentification = "P";
		subject.ReferenceIdentificationQualifier2 = "i9";
		subject.ReferenceIdentification2 = "b";
		if (quantity > 0)
			subject.Quantity = quantity;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("sou", true)]
	public void Validation_RequiredPackagingCode(string packagingCode, bool isValidExpected)
	{
		var subject = new CD1_CargoDetail();
		subject.EquipmentInitial = "T";
		subject.EquipmentNumber = "j";
		subject.BillOfLadingWaybillNumber = "m";
		subject.TypeOfServiceCode = "Q3";
		subject.LocationIdentifier = "Y";
		subject.Quantity = 3;
		subject.DispositionCode = "FQ";
		subject.StandardCarrierAlphaCode = "hl";
		subject.ReferenceIdentificationQualifier = "Pg";
		subject.ReferenceIdentification = "P";
		subject.ReferenceIdentificationQualifier2 = "i9";
		subject.ReferenceIdentification2 = "b";
		subject.PackagingCode = packagingCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("FQ", true)]
	public void Validation_RequiredDispositionCode(string dispositionCode, bool isValidExpected)
	{
		var subject = new CD1_CargoDetail();
		subject.EquipmentInitial = "T";
		subject.EquipmentNumber = "j";
		subject.BillOfLadingWaybillNumber = "m";
		subject.TypeOfServiceCode = "Q3";
		subject.LocationIdentifier = "Y";
		subject.Quantity = 3;
		subject.PackagingCode = "sou";
		subject.StandardCarrierAlphaCode = "hl";
		subject.ReferenceIdentificationQualifier = "Pg";
		subject.ReferenceIdentification = "P";
		subject.ReferenceIdentificationQualifier2 = "i9";
		subject.ReferenceIdentification2 = "b";
		subject.DispositionCode = dispositionCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("hl", true)]
	public void Validation_RequiredStandardCarrierAlphaCode(string standardCarrierAlphaCode, bool isValidExpected)
	{
		var subject = new CD1_CargoDetail();
		subject.EquipmentInitial = "T";
		subject.EquipmentNumber = "j";
		subject.BillOfLadingWaybillNumber = "m";
		subject.TypeOfServiceCode = "Q3";
		subject.LocationIdentifier = "Y";
		subject.Quantity = 3;
		subject.PackagingCode = "sou";
		subject.DispositionCode = "FQ";
		subject.ReferenceIdentificationQualifier = "Pg";
		subject.ReferenceIdentification = "P";
		subject.ReferenceIdentificationQualifier2 = "i9";
		subject.ReferenceIdentification2 = "b";
		subject.StandardCarrierAlphaCode = standardCarrierAlphaCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("Pg", true)]
	public void Validation_RequiredReferenceIdentificationQualifier(string referenceIdentificationQualifier, bool isValidExpected)
	{
		var subject = new CD1_CargoDetail();
		subject.EquipmentInitial = "T";
		subject.EquipmentNumber = "j";
		subject.BillOfLadingWaybillNumber = "m";
		subject.TypeOfServiceCode = "Q3";
		subject.LocationIdentifier = "Y";
		subject.Quantity = 3;
		subject.PackagingCode = "sou";
		subject.DispositionCode = "FQ";
		subject.StandardCarrierAlphaCode = "hl";
		subject.ReferenceIdentification = "P";
		subject.ReferenceIdentificationQualifier2 = "i9";
		subject.ReferenceIdentification2 = "b";
		subject.ReferenceIdentificationQualifier = referenceIdentificationQualifier;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("P", true)]
	public void Validation_RequiredReferenceIdentification(string referenceIdentification, bool isValidExpected)
	{
		var subject = new CD1_CargoDetail();
		subject.EquipmentInitial = "T";
		subject.EquipmentNumber = "j";
		subject.BillOfLadingWaybillNumber = "m";
		subject.TypeOfServiceCode = "Q3";
		subject.LocationIdentifier = "Y";
		subject.Quantity = 3;
		subject.PackagingCode = "sou";
		subject.DispositionCode = "FQ";
		subject.StandardCarrierAlphaCode = "hl";
		subject.ReferenceIdentificationQualifier = "Pg";
		subject.ReferenceIdentificationQualifier2 = "i9";
		subject.ReferenceIdentification2 = "b";
		subject.ReferenceIdentification = referenceIdentification;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("i9", true)]
	public void Validation_RequiredReferenceIdentificationQualifier2(string referenceIdentificationQualifier2, bool isValidExpected)
	{
		var subject = new CD1_CargoDetail();
		subject.EquipmentInitial = "T";
		subject.EquipmentNumber = "j";
		subject.BillOfLadingWaybillNumber = "m";
		subject.TypeOfServiceCode = "Q3";
		subject.LocationIdentifier = "Y";
		subject.Quantity = 3;
		subject.PackagingCode = "sou";
		subject.DispositionCode = "FQ";
		subject.StandardCarrierAlphaCode = "hl";
		subject.ReferenceIdentificationQualifier = "Pg";
		subject.ReferenceIdentification = "P";
		subject.ReferenceIdentification2 = "b";
		subject.ReferenceIdentificationQualifier2 = referenceIdentificationQualifier2;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("b", true)]
	public void Validation_RequiredReferenceIdentification2(string referenceIdentification2, bool isValidExpected)
	{
		var subject = new CD1_CargoDetail();
		subject.EquipmentInitial = "T";
		subject.EquipmentNumber = "j";
		subject.BillOfLadingWaybillNumber = "m";
		subject.TypeOfServiceCode = "Q3";
		subject.LocationIdentifier = "Y";
		subject.Quantity = 3;
		subject.PackagingCode = "sou";
		subject.DispositionCode = "FQ";
		subject.StandardCarrierAlphaCode = "hl";
		subject.ReferenceIdentificationQualifier = "Pg";
		subject.ReferenceIdentification = "P";
		subject.ReferenceIdentificationQualifier2 = "i9";
		subject.ReferenceIdentification2 = referenceIdentification2;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
