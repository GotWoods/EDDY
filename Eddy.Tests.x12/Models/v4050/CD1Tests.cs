using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v4050;

namespace Eddy.x12.Tests.Models.v4050;

public class CD1Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "CD1*b*h*NY05*O*87*0*r*ubWrD8l3*o*1*fGg*aB*tq*ag*x*qy*5*6*21*3*V*Xz*8*jBM*OPk8XJrf*u*GH*cd*h*Cy*s";

		var expected = new CD1_CargoDetail()
		{
			EquipmentInitial = "b",
			EquipmentNumber = "h",
			EquipmentType = "NY05",
			BillOfLadingWaybillNumber = "O",
			TypeOfServiceCode = "87",
			HazardousMaterialCodeQualifier = "0",
			HazardousMaterialClassCode = "r",
			Date = "ubWrD8l3",
			LocationIdentifier = "o",
			Quantity = 1,
			PackagingCode = "fGg",
			BillOfLadingDispositionCode = "aB",
			BillOfLadingDispositionCode2 = "tq",
			BillOfLadingDispositionCode3 = "ag",
			RateClassCode = "x",
			RateValueQualifier = "qy",
			Rate = 5,
			RateClassCode2 = "6",
			RateValueQualifier2 = "21",
			Rate2 = 3,
			RateClassCode3 = "V",
			RateValueQualifier3 = "Xz",
			Rate3 = 8,
			DateTimeQualifier = "jBM",
			Date2 = "OPk8XJrf",
			ShipmentStatusCode = "u",
			StandardCarrierAlphaCode = "GH",
			ReferenceIdentificationQualifier = "cd",
			ReferenceIdentification = "h",
			ReferenceIdentificationQualifier2 = "Cy",
			ReferenceIdentification2 = "s",
		};

		var actual = Map.MapObject<CD1_CargoDetail>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("b", true)]
	public void Validation_RequiredEquipmentInitial(string equipmentInitial, bool isValidExpected)
	{
		var subject = new CD1_CargoDetail();
		subject.EquipmentNumber = "h";
		subject.BillOfLadingWaybillNumber = "O";
		subject.TypeOfServiceCode = "87";
		subject.LocationIdentifier = "o";
		subject.Quantity = 1;
		subject.PackagingCode = "fGg";
		subject.BillOfLadingDispositionCode = "aB";
		subject.StandardCarrierAlphaCode = "GH";
		subject.ReferenceIdentificationQualifier = "cd";
		subject.ReferenceIdentification = "h";
		subject.ReferenceIdentificationQualifier2 = "Cy";
		subject.ReferenceIdentification2 = "s";
		subject.EquipmentInitial = equipmentInitial;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("h", true)]
	public void Validation_RequiredEquipmentNumber(string equipmentNumber, bool isValidExpected)
	{
		var subject = new CD1_CargoDetail();
		subject.EquipmentInitial = "b";
		subject.BillOfLadingWaybillNumber = "O";
		subject.TypeOfServiceCode = "87";
		subject.LocationIdentifier = "o";
		subject.Quantity = 1;
		subject.PackagingCode = "fGg";
		subject.BillOfLadingDispositionCode = "aB";
		subject.StandardCarrierAlphaCode = "GH";
		subject.ReferenceIdentificationQualifier = "cd";
		subject.ReferenceIdentification = "h";
		subject.ReferenceIdentificationQualifier2 = "Cy";
		subject.ReferenceIdentification2 = "s";
		subject.EquipmentNumber = equipmentNumber;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("O", true)]
	public void Validation_RequiredBillOfLadingWaybillNumber(string billOfLadingWaybillNumber, bool isValidExpected)
	{
		var subject = new CD1_CargoDetail();
		subject.EquipmentInitial = "b";
		subject.EquipmentNumber = "h";
		subject.TypeOfServiceCode = "87";
		subject.LocationIdentifier = "o";
		subject.Quantity = 1;
		subject.PackagingCode = "fGg";
		subject.BillOfLadingDispositionCode = "aB";
		subject.StandardCarrierAlphaCode = "GH";
		subject.ReferenceIdentificationQualifier = "cd";
		subject.ReferenceIdentification = "h";
		subject.ReferenceIdentificationQualifier2 = "Cy";
		subject.ReferenceIdentification2 = "s";
		subject.BillOfLadingWaybillNumber = billOfLadingWaybillNumber;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("87", true)]
	public void Validation_RequiredTypeOfServiceCode(string typeOfServiceCode, bool isValidExpected)
	{
		var subject = new CD1_CargoDetail();
		subject.EquipmentInitial = "b";
		subject.EquipmentNumber = "h";
		subject.BillOfLadingWaybillNumber = "O";
		subject.LocationIdentifier = "o";
		subject.Quantity = 1;
		subject.PackagingCode = "fGg";
		subject.BillOfLadingDispositionCode = "aB";
		subject.StandardCarrierAlphaCode = "GH";
		subject.ReferenceIdentificationQualifier = "cd";
		subject.ReferenceIdentification = "h";
		subject.ReferenceIdentificationQualifier2 = "Cy";
		subject.ReferenceIdentification2 = "s";
		subject.TypeOfServiceCode = typeOfServiceCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("o", true)]
	public void Validation_RequiredLocationIdentifier(string locationIdentifier, bool isValidExpected)
	{
		var subject = new CD1_CargoDetail();
		subject.EquipmentInitial = "b";
		subject.EquipmentNumber = "h";
		subject.BillOfLadingWaybillNumber = "O";
		subject.TypeOfServiceCode = "87";
		subject.Quantity = 1;
		subject.PackagingCode = "fGg";
		subject.BillOfLadingDispositionCode = "aB";
		subject.StandardCarrierAlphaCode = "GH";
		subject.ReferenceIdentificationQualifier = "cd";
		subject.ReferenceIdentification = "h";
		subject.ReferenceIdentificationQualifier2 = "Cy";
		subject.ReferenceIdentification2 = "s";
		subject.LocationIdentifier = locationIdentifier;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData(0, false)]
	[InlineData(1, true)]
	public void Validation_RequiredQuantity(decimal quantity, bool isValidExpected)
	{
		var subject = new CD1_CargoDetail();
		subject.EquipmentInitial = "b";
		subject.EquipmentNumber = "h";
		subject.BillOfLadingWaybillNumber = "O";
		subject.TypeOfServiceCode = "87";
		subject.LocationIdentifier = "o";
		subject.PackagingCode = "fGg";
		subject.BillOfLadingDispositionCode = "aB";
		subject.StandardCarrierAlphaCode = "GH";
		subject.ReferenceIdentificationQualifier = "cd";
		subject.ReferenceIdentification = "h";
		subject.ReferenceIdentificationQualifier2 = "Cy";
		subject.ReferenceIdentification2 = "s";
		if (quantity > 0)
			subject.Quantity = quantity;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("fGg", true)]
	public void Validation_RequiredPackagingCode(string packagingCode, bool isValidExpected)
	{
		var subject = new CD1_CargoDetail();
		subject.EquipmentInitial = "b";
		subject.EquipmentNumber = "h";
		subject.BillOfLadingWaybillNumber = "O";
		subject.TypeOfServiceCode = "87";
		subject.LocationIdentifier = "o";
		subject.Quantity = 1;
		subject.BillOfLadingDispositionCode = "aB";
		subject.StandardCarrierAlphaCode = "GH";
		subject.ReferenceIdentificationQualifier = "cd";
		subject.ReferenceIdentification = "h";
		subject.ReferenceIdentificationQualifier2 = "Cy";
		subject.ReferenceIdentification2 = "s";
		subject.PackagingCode = packagingCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("aB", true)]
	public void Validation_RequiredBillOfLadingDispositionCode(string billOfLadingDispositionCode, bool isValidExpected)
	{
		var subject = new CD1_CargoDetail();
		subject.EquipmentInitial = "b";
		subject.EquipmentNumber = "h";
		subject.BillOfLadingWaybillNumber = "O";
		subject.TypeOfServiceCode = "87";
		subject.LocationIdentifier = "o";
		subject.Quantity = 1;
		subject.PackagingCode = "fGg";
		subject.StandardCarrierAlphaCode = "GH";
		subject.ReferenceIdentificationQualifier = "cd";
		subject.ReferenceIdentification = "h";
		subject.ReferenceIdentificationQualifier2 = "Cy";
		subject.ReferenceIdentification2 = "s";
		subject.BillOfLadingDispositionCode = billOfLadingDispositionCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("GH", true)]
	public void Validation_RequiredStandardCarrierAlphaCode(string standardCarrierAlphaCode, bool isValidExpected)
	{
		var subject = new CD1_CargoDetail();
		subject.EquipmentInitial = "b";
		subject.EquipmentNumber = "h";
		subject.BillOfLadingWaybillNumber = "O";
		subject.TypeOfServiceCode = "87";
		subject.LocationIdentifier = "o";
		subject.Quantity = 1;
		subject.PackagingCode = "fGg";
		subject.BillOfLadingDispositionCode = "aB";
		subject.ReferenceIdentificationQualifier = "cd";
		subject.ReferenceIdentification = "h";
		subject.ReferenceIdentificationQualifier2 = "Cy";
		subject.ReferenceIdentification2 = "s";
		subject.StandardCarrierAlphaCode = standardCarrierAlphaCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("cd", true)]
	public void Validation_RequiredReferenceIdentificationQualifier(string referenceIdentificationQualifier, bool isValidExpected)
	{
		var subject = new CD1_CargoDetail();
		subject.EquipmentInitial = "b";
		subject.EquipmentNumber = "h";
		subject.BillOfLadingWaybillNumber = "O";
		subject.TypeOfServiceCode = "87";
		subject.LocationIdentifier = "o";
		subject.Quantity = 1;
		subject.PackagingCode = "fGg";
		subject.BillOfLadingDispositionCode = "aB";
		subject.StandardCarrierAlphaCode = "GH";
		subject.ReferenceIdentification = "h";
		subject.ReferenceIdentificationQualifier2 = "Cy";
		subject.ReferenceIdentification2 = "s";
		subject.ReferenceIdentificationQualifier = referenceIdentificationQualifier;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("h", true)]
	public void Validation_RequiredReferenceIdentification(string referenceIdentification, bool isValidExpected)
	{
		var subject = new CD1_CargoDetail();
		subject.EquipmentInitial = "b";
		subject.EquipmentNumber = "h";
		subject.BillOfLadingWaybillNumber = "O";
		subject.TypeOfServiceCode = "87";
		subject.LocationIdentifier = "o";
		subject.Quantity = 1;
		subject.PackagingCode = "fGg";
		subject.BillOfLadingDispositionCode = "aB";
		subject.StandardCarrierAlphaCode = "GH";
		subject.ReferenceIdentificationQualifier = "cd";
		subject.ReferenceIdentificationQualifier2 = "Cy";
		subject.ReferenceIdentification2 = "s";
		subject.ReferenceIdentification = referenceIdentification;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("Cy", true)]
	public void Validation_RequiredReferenceIdentificationQualifier2(string referenceIdentificationQualifier2, bool isValidExpected)
	{
		var subject = new CD1_CargoDetail();
		subject.EquipmentInitial = "b";
		subject.EquipmentNumber = "h";
		subject.BillOfLadingWaybillNumber = "O";
		subject.TypeOfServiceCode = "87";
		subject.LocationIdentifier = "o";
		subject.Quantity = 1;
		subject.PackagingCode = "fGg";
		subject.BillOfLadingDispositionCode = "aB";
		subject.StandardCarrierAlphaCode = "GH";
		subject.ReferenceIdentificationQualifier = "cd";
		subject.ReferenceIdentification = "h";
		subject.ReferenceIdentification2 = "s";
		subject.ReferenceIdentificationQualifier2 = referenceIdentificationQualifier2;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("s", true)]
	public void Validation_RequiredReferenceIdentification2(string referenceIdentification2, bool isValidExpected)
	{
		var subject = new CD1_CargoDetail();
		subject.EquipmentInitial = "b";
		subject.EquipmentNumber = "h";
		subject.BillOfLadingWaybillNumber = "O";
		subject.TypeOfServiceCode = "87";
		subject.LocationIdentifier = "o";
		subject.Quantity = 1;
		subject.PackagingCode = "fGg";
		subject.BillOfLadingDispositionCode = "aB";
		subject.StandardCarrierAlphaCode = "GH";
		subject.ReferenceIdentificationQualifier = "cd";
		subject.ReferenceIdentification = "h";
		subject.ReferenceIdentificationQualifier2 = "Cy";
		subject.ReferenceIdentification2 = referenceIdentification2;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
