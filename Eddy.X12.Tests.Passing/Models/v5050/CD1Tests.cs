using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v5050;

namespace Eddy.x12.Tests.Models.v5050;

public class CD1Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "CD1*E*8*IW1A*v*PJ*T*0*fNzFxeHI*6*2*XXD*3j*ko*Eq*e*Zc*4*V*wM*5*2*z5*6*E3p*ZrAsxaN5*P*Od*4g*u*kA*p";

		var expected = new CD1_CargoDetail()
		{
			EquipmentInitial = "E",
			EquipmentNumber = "8",
			EquipmentType = "IW1A",
			BillOfLadingWaybillNumber = "v",
			TypeOfServiceCode = "PJ",
			HazardousMaterialCodeQualifier = "T",
			HazardousMaterialClassCode = "0",
			Date = "fNzFxeHI",
			LocationIdentifier = "6",
			Quantity = 2,
			PackagingCode = "XXD",
			BillOfLadingDispositionCode = "3j",
			BillOfLadingDispositionCode2 = "ko",
			BillOfLadingDispositionCode3 = "Eq",
			RateClassCode = "e",
			RateValueQualifier = "Zc",
			Rate = 4,
			RateClassCode2 = "V",
			RateValueQualifier2 = "wM",
			Rate2 = 5,
			RateClassCode3 = "2",
			RateValueQualifier3 = "z5",
			Rate3 = 6,
			DateTimeQualifier = "E3p",
			Date2 = "ZrAsxaN5",
			ShipmentStatusCode = "P",
			StandardCarrierAlphaCode = "Od",
			ReferenceIdentificationQualifier = "4g",
			ReferenceIdentification = "u",
			ReferenceIdentificationQualifier2 = "kA",
			ReferenceIdentification2 = "p",
		};

		var actual = Map.MapObject<CD1_CargoDetail>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("E", true)]
	public void Validation_RequiredEquipmentInitial(string equipmentInitial, bool isValidExpected)
	{
		var subject = new CD1_CargoDetail();
		subject.EquipmentNumber = "8";
		subject.BillOfLadingWaybillNumber = "v";
		subject.TypeOfServiceCode = "PJ";
		subject.LocationIdentifier = "6";
		subject.Quantity = 2;
		subject.PackagingCode = "XXD";
		subject.BillOfLadingDispositionCode = "3j";
		subject.StandardCarrierAlphaCode = "Od";
		subject.ReferenceIdentificationQualifier = "4g";
		subject.ReferenceIdentification = "u";
		subject.ReferenceIdentificationQualifier2 = "kA";
		subject.ReferenceIdentification2 = "p";
		subject.EquipmentInitial = equipmentInitial;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("8", true)]
	public void Validation_RequiredEquipmentNumber(string equipmentNumber, bool isValidExpected)
	{
		var subject = new CD1_CargoDetail();
		subject.EquipmentInitial = "E";
		subject.BillOfLadingWaybillNumber = "v";
		subject.TypeOfServiceCode = "PJ";
		subject.LocationIdentifier = "6";
		subject.Quantity = 2;
		subject.PackagingCode = "XXD";
		subject.BillOfLadingDispositionCode = "3j";
		subject.StandardCarrierAlphaCode = "Od";
		subject.ReferenceIdentificationQualifier = "4g";
		subject.ReferenceIdentification = "u";
		subject.ReferenceIdentificationQualifier2 = "kA";
		subject.ReferenceIdentification2 = "p";
		subject.EquipmentNumber = equipmentNumber;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("v", true)]
	public void Validation_RequiredBillOfLadingWaybillNumber(string billOfLadingWaybillNumber, bool isValidExpected)
	{
		var subject = new CD1_CargoDetail();
		subject.EquipmentInitial = "E";
		subject.EquipmentNumber = "8";
		subject.TypeOfServiceCode = "PJ";
		subject.LocationIdentifier = "6";
		subject.Quantity = 2;
		subject.PackagingCode = "XXD";
		subject.BillOfLadingDispositionCode = "3j";
		subject.StandardCarrierAlphaCode = "Od";
		subject.ReferenceIdentificationQualifier = "4g";
		subject.ReferenceIdentification = "u";
		subject.ReferenceIdentificationQualifier2 = "kA";
		subject.ReferenceIdentification2 = "p";
		subject.BillOfLadingWaybillNumber = billOfLadingWaybillNumber;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("PJ", true)]
	public void Validation_RequiredTypeOfServiceCode(string typeOfServiceCode, bool isValidExpected)
	{
		var subject = new CD1_CargoDetail();
		subject.EquipmentInitial = "E";
		subject.EquipmentNumber = "8";
		subject.BillOfLadingWaybillNumber = "v";
		subject.LocationIdentifier = "6";
		subject.Quantity = 2;
		subject.PackagingCode = "XXD";
		subject.BillOfLadingDispositionCode = "3j";
		subject.StandardCarrierAlphaCode = "Od";
		subject.ReferenceIdentificationQualifier = "4g";
		subject.ReferenceIdentification = "u";
		subject.ReferenceIdentificationQualifier2 = "kA";
		subject.ReferenceIdentification2 = "p";
		subject.TypeOfServiceCode = typeOfServiceCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("6", true)]
	public void Validation_RequiredLocationIdentifier(string locationIdentifier, bool isValidExpected)
	{
		var subject = new CD1_CargoDetail();
		subject.EquipmentInitial = "E";
		subject.EquipmentNumber = "8";
		subject.BillOfLadingWaybillNumber = "v";
		subject.TypeOfServiceCode = "PJ";
		subject.Quantity = 2;
		subject.PackagingCode = "XXD";
		subject.BillOfLadingDispositionCode = "3j";
		subject.StandardCarrierAlphaCode = "Od";
		subject.ReferenceIdentificationQualifier = "4g";
		subject.ReferenceIdentification = "u";
		subject.ReferenceIdentificationQualifier2 = "kA";
		subject.ReferenceIdentification2 = "p";
		subject.LocationIdentifier = locationIdentifier;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData(0, false)]
	[InlineData(2, true)]
	public void Validation_RequiredQuantity(decimal quantity, bool isValidExpected)
	{
		var subject = new CD1_CargoDetail();
		subject.EquipmentInitial = "E";
		subject.EquipmentNumber = "8";
		subject.BillOfLadingWaybillNumber = "v";
		subject.TypeOfServiceCode = "PJ";
		subject.LocationIdentifier = "6";
		subject.PackagingCode = "XXD";
		subject.BillOfLadingDispositionCode = "3j";
		subject.StandardCarrierAlphaCode = "Od";
		subject.ReferenceIdentificationQualifier = "4g";
		subject.ReferenceIdentification = "u";
		subject.ReferenceIdentificationQualifier2 = "kA";
		subject.ReferenceIdentification2 = "p";
		if (quantity > 0)
			subject.Quantity = quantity;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("XXD", true)]
	public void Validation_RequiredPackagingCode(string packagingCode, bool isValidExpected)
	{
		var subject = new CD1_CargoDetail();
		subject.EquipmentInitial = "E";
		subject.EquipmentNumber = "8";
		subject.BillOfLadingWaybillNumber = "v";
		subject.TypeOfServiceCode = "PJ";
		subject.LocationIdentifier = "6";
		subject.Quantity = 2;
		subject.BillOfLadingDispositionCode = "3j";
		subject.StandardCarrierAlphaCode = "Od";
		subject.ReferenceIdentificationQualifier = "4g";
		subject.ReferenceIdentification = "u";
		subject.ReferenceIdentificationQualifier2 = "kA";
		subject.ReferenceIdentification2 = "p";
		subject.PackagingCode = packagingCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("3j", true)]
	public void Validation_RequiredBillOfLadingDispositionCode(string billOfLadingDispositionCode, bool isValidExpected)
	{
		var subject = new CD1_CargoDetail();
		subject.EquipmentInitial = "E";
		subject.EquipmentNumber = "8";
		subject.BillOfLadingWaybillNumber = "v";
		subject.TypeOfServiceCode = "PJ";
		subject.LocationIdentifier = "6";
		subject.Quantity = 2;
		subject.PackagingCode = "XXD";
		subject.StandardCarrierAlphaCode = "Od";
		subject.ReferenceIdentificationQualifier = "4g";
		subject.ReferenceIdentification = "u";
		subject.ReferenceIdentificationQualifier2 = "kA";
		subject.ReferenceIdentification2 = "p";
		subject.BillOfLadingDispositionCode = billOfLadingDispositionCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("Od", true)]
	public void Validation_RequiredStandardCarrierAlphaCode(string standardCarrierAlphaCode, bool isValidExpected)
	{
		var subject = new CD1_CargoDetail();
		subject.EquipmentInitial = "E";
		subject.EquipmentNumber = "8";
		subject.BillOfLadingWaybillNumber = "v";
		subject.TypeOfServiceCode = "PJ";
		subject.LocationIdentifier = "6";
		subject.Quantity = 2;
		subject.PackagingCode = "XXD";
		subject.BillOfLadingDispositionCode = "3j";
		subject.ReferenceIdentificationQualifier = "4g";
		subject.ReferenceIdentification = "u";
		subject.ReferenceIdentificationQualifier2 = "kA";
		subject.ReferenceIdentification2 = "p";
		subject.StandardCarrierAlphaCode = standardCarrierAlphaCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("4g", true)]
	public void Validation_RequiredReferenceIdentificationQualifier(string referenceIdentificationQualifier, bool isValidExpected)
	{
		var subject = new CD1_CargoDetail();
		subject.EquipmentInitial = "E";
		subject.EquipmentNumber = "8";
		subject.BillOfLadingWaybillNumber = "v";
		subject.TypeOfServiceCode = "PJ";
		subject.LocationIdentifier = "6";
		subject.Quantity = 2;
		subject.PackagingCode = "XXD";
		subject.BillOfLadingDispositionCode = "3j";
		subject.StandardCarrierAlphaCode = "Od";
		subject.ReferenceIdentification = "u";
		subject.ReferenceIdentificationQualifier2 = "kA";
		subject.ReferenceIdentification2 = "p";
		subject.ReferenceIdentificationQualifier = referenceIdentificationQualifier;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("u", true)]
	public void Validation_RequiredReferenceIdentification(string referenceIdentification, bool isValidExpected)
	{
		var subject = new CD1_CargoDetail();
		subject.EquipmentInitial = "E";
		subject.EquipmentNumber = "8";
		subject.BillOfLadingWaybillNumber = "v";
		subject.TypeOfServiceCode = "PJ";
		subject.LocationIdentifier = "6";
		subject.Quantity = 2;
		subject.PackagingCode = "XXD";
		subject.BillOfLadingDispositionCode = "3j";
		subject.StandardCarrierAlphaCode = "Od";
		subject.ReferenceIdentificationQualifier = "4g";
		subject.ReferenceIdentificationQualifier2 = "kA";
		subject.ReferenceIdentification2 = "p";
		subject.ReferenceIdentification = referenceIdentification;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("kA", true)]
	public void Validation_RequiredReferenceIdentificationQualifier2(string referenceIdentificationQualifier2, bool isValidExpected)
	{
		var subject = new CD1_CargoDetail();
		subject.EquipmentInitial = "E";
		subject.EquipmentNumber = "8";
		subject.BillOfLadingWaybillNumber = "v";
		subject.TypeOfServiceCode = "PJ";
		subject.LocationIdentifier = "6";
		subject.Quantity = 2;
		subject.PackagingCode = "XXD";
		subject.BillOfLadingDispositionCode = "3j";
		subject.StandardCarrierAlphaCode = "Od";
		subject.ReferenceIdentificationQualifier = "4g";
		subject.ReferenceIdentification = "u";
		subject.ReferenceIdentification2 = "p";
		subject.ReferenceIdentificationQualifier2 = referenceIdentificationQualifier2;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("p", true)]
	public void Validation_RequiredReferenceIdentification2(string referenceIdentification2, bool isValidExpected)
	{
		var subject = new CD1_CargoDetail();
		subject.EquipmentInitial = "E";
		subject.EquipmentNumber = "8";
		subject.BillOfLadingWaybillNumber = "v";
		subject.TypeOfServiceCode = "PJ";
		subject.LocationIdentifier = "6";
		subject.Quantity = 2;
		subject.PackagingCode = "XXD";
		subject.BillOfLadingDispositionCode = "3j";
		subject.StandardCarrierAlphaCode = "Od";
		subject.ReferenceIdentificationQualifier = "4g";
		subject.ReferenceIdentification = "u";
		subject.ReferenceIdentificationQualifier2 = "kA";
		subject.ReferenceIdentification2 = referenceIdentification2;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
