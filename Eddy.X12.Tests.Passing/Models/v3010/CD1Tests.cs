using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3010;

namespace Eddy.x12.Tests.Models.v3010;

public class CD1Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "CD1*y*Y*33sg*p*yu*u*tv*AbrtOU*I*6*MPvTe*Eg*vc*dd*5*7d*7*V*AJ*2*y*Vx*3*OrI*d3HlXd*t*9M*4s*b*eQ*k";

		var expected = new CD1_CargoDetail()
		{
			EquipmentInitial = "y",
			EquipmentNumber = "Y",
			EquipmentType = "33sg",
			BillOfLadingWaybillNumber = "p",
			TypeOfServiceCode = "yu",
			HazardousMaterialCodeQualifier = "u",
			HazardousMaterialClassCode = "tv",
			Date = "AbrtOU",
			LocationIdentifier = "I",
			Quantity = 6,
			PackagingCode = "MPvTe",
			DispositionCode = "Eg",
			DispositionCode2 = "vc",
			DispositionCode3 = "dd",
			RateClassCode = "5",
			RateValueQualifier = "7d",
			Rate = 7,
			RateClassCode2 = "V",
			RateValueQualifier2 = "AJ",
			Rate2 = 2,
			RateClassCode3 = "y",
			RateValueQualifier3 = "Vx",
			Rate3 = 3,
			DateTimeQualifier = "OrI",
			DeliveryDate = "d3HlXd",
			StatusCode = "t",
			StandardCarrierAlphaCode = "9M",
			ReferenceNumberQualifier = "4s",
			ReferenceNumber = "b",
			ReferenceNumberQualifier2 = "eQ",
			ReferenceNumber2 = "k",
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
		subject.EquipmentNumber = "Y";
		subject.BillOfLadingWaybillNumber = "p";
		subject.TypeOfServiceCode = "yu";
		subject.LocationIdentifier = "I";
		subject.Quantity = 6;
		subject.PackagingCode = "MPvTe";
		subject.DispositionCode = "Eg";
		subject.StandardCarrierAlphaCode = "9M";
		subject.ReferenceNumberQualifier = "4s";
		subject.ReferenceNumber = "b";
		subject.ReferenceNumberQualifier2 = "eQ";
		subject.ReferenceNumber2 = "k";
		subject.EquipmentInitial = equipmentInitial;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("Y", true)]
	public void Validation_RequiredEquipmentNumber(string equipmentNumber, bool isValidExpected)
	{
		var subject = new CD1_CargoDetail();
		subject.EquipmentInitial = "y";
		subject.BillOfLadingWaybillNumber = "p";
		subject.TypeOfServiceCode = "yu";
		subject.LocationIdentifier = "I";
		subject.Quantity = 6;
		subject.PackagingCode = "MPvTe";
		subject.DispositionCode = "Eg";
		subject.StandardCarrierAlphaCode = "9M";
		subject.ReferenceNumberQualifier = "4s";
		subject.ReferenceNumber = "b";
		subject.ReferenceNumberQualifier2 = "eQ";
		subject.ReferenceNumber2 = "k";
		subject.EquipmentNumber = equipmentNumber;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("p", true)]
	public void Validation_RequiredBillOfLadingWaybillNumber(string billOfLadingWaybillNumber, bool isValidExpected)
	{
		var subject = new CD1_CargoDetail();
		subject.EquipmentInitial = "y";
		subject.EquipmentNumber = "Y";
		subject.TypeOfServiceCode = "yu";
		subject.LocationIdentifier = "I";
		subject.Quantity = 6;
		subject.PackagingCode = "MPvTe";
		subject.DispositionCode = "Eg";
		subject.StandardCarrierAlphaCode = "9M";
		subject.ReferenceNumberQualifier = "4s";
		subject.ReferenceNumber = "b";
		subject.ReferenceNumberQualifier2 = "eQ";
		subject.ReferenceNumber2 = "k";
		subject.BillOfLadingWaybillNumber = billOfLadingWaybillNumber;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("yu", true)]
	public void Validation_RequiredTypeOfServiceCode(string typeOfServiceCode, bool isValidExpected)
	{
		var subject = new CD1_CargoDetail();
		subject.EquipmentInitial = "y";
		subject.EquipmentNumber = "Y";
		subject.BillOfLadingWaybillNumber = "p";
		subject.LocationIdentifier = "I";
		subject.Quantity = 6;
		subject.PackagingCode = "MPvTe";
		subject.DispositionCode = "Eg";
		subject.StandardCarrierAlphaCode = "9M";
		subject.ReferenceNumberQualifier = "4s";
		subject.ReferenceNumber = "b";
		subject.ReferenceNumberQualifier2 = "eQ";
		subject.ReferenceNumber2 = "k";
		subject.TypeOfServiceCode = typeOfServiceCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("I", true)]
	public void Validation_RequiredLocationIdentifier(string locationIdentifier, bool isValidExpected)
	{
		var subject = new CD1_CargoDetail();
		subject.EquipmentInitial = "y";
		subject.EquipmentNumber = "Y";
		subject.BillOfLadingWaybillNumber = "p";
		subject.TypeOfServiceCode = "yu";
		subject.Quantity = 6;
		subject.PackagingCode = "MPvTe";
		subject.DispositionCode = "Eg";
		subject.StandardCarrierAlphaCode = "9M";
		subject.ReferenceNumberQualifier = "4s";
		subject.ReferenceNumber = "b";
		subject.ReferenceNumberQualifier2 = "eQ";
		subject.ReferenceNumber2 = "k";
		subject.LocationIdentifier = locationIdentifier;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData(0, false)]
	[InlineData(6, true)]
	public void Validation_RequiredQuantity(decimal quantity, bool isValidExpected)
	{
		var subject = new CD1_CargoDetail();
		subject.EquipmentInitial = "y";
		subject.EquipmentNumber = "Y";
		subject.BillOfLadingWaybillNumber = "p";
		subject.TypeOfServiceCode = "yu";
		subject.LocationIdentifier = "I";
		subject.PackagingCode = "MPvTe";
		subject.DispositionCode = "Eg";
		subject.StandardCarrierAlphaCode = "9M";
		subject.ReferenceNumberQualifier = "4s";
		subject.ReferenceNumber = "b";
		subject.ReferenceNumberQualifier2 = "eQ";
		subject.ReferenceNumber2 = "k";
		if (quantity > 0)
			subject.Quantity = quantity;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("MPvTe", true)]
	public void Validation_RequiredPackagingCode(string packagingCode, bool isValidExpected)
	{
		var subject = new CD1_CargoDetail();
		subject.EquipmentInitial = "y";
		subject.EquipmentNumber = "Y";
		subject.BillOfLadingWaybillNumber = "p";
		subject.TypeOfServiceCode = "yu";
		subject.LocationIdentifier = "I";
		subject.Quantity = 6;
		subject.DispositionCode = "Eg";
		subject.StandardCarrierAlphaCode = "9M";
		subject.ReferenceNumberQualifier = "4s";
		subject.ReferenceNumber = "b";
		subject.ReferenceNumberQualifier2 = "eQ";
		subject.ReferenceNumber2 = "k";
		subject.PackagingCode = packagingCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("Eg", true)]
	public void Validation_RequiredDispositionCode(string dispositionCode, bool isValidExpected)
	{
		var subject = new CD1_CargoDetail();
		subject.EquipmentInitial = "y";
		subject.EquipmentNumber = "Y";
		subject.BillOfLadingWaybillNumber = "p";
		subject.TypeOfServiceCode = "yu";
		subject.LocationIdentifier = "I";
		subject.Quantity = 6;
		subject.PackagingCode = "MPvTe";
		subject.StandardCarrierAlphaCode = "9M";
		subject.ReferenceNumberQualifier = "4s";
		subject.ReferenceNumber = "b";
		subject.ReferenceNumberQualifier2 = "eQ";
		subject.ReferenceNumber2 = "k";
		subject.DispositionCode = dispositionCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("9M", true)]
	public void Validation_RequiredStandardCarrierAlphaCode(string standardCarrierAlphaCode, bool isValidExpected)
	{
		var subject = new CD1_CargoDetail();
		subject.EquipmentInitial = "y";
		subject.EquipmentNumber = "Y";
		subject.BillOfLadingWaybillNumber = "p";
		subject.TypeOfServiceCode = "yu";
		subject.LocationIdentifier = "I";
		subject.Quantity = 6;
		subject.PackagingCode = "MPvTe";
		subject.DispositionCode = "Eg";
		subject.ReferenceNumberQualifier = "4s";
		subject.ReferenceNumber = "b";
		subject.ReferenceNumberQualifier2 = "eQ";
		subject.ReferenceNumber2 = "k";
		subject.StandardCarrierAlphaCode = standardCarrierAlphaCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("4s", true)]
	public void Validation_RequiredReferenceNumberQualifier(string referenceNumberQualifier, bool isValidExpected)
	{
		var subject = new CD1_CargoDetail();
		subject.EquipmentInitial = "y";
		subject.EquipmentNumber = "Y";
		subject.BillOfLadingWaybillNumber = "p";
		subject.TypeOfServiceCode = "yu";
		subject.LocationIdentifier = "I";
		subject.Quantity = 6;
		subject.PackagingCode = "MPvTe";
		subject.DispositionCode = "Eg";
		subject.StandardCarrierAlphaCode = "9M";
		subject.ReferenceNumber = "b";
		subject.ReferenceNumberQualifier2 = "eQ";
		subject.ReferenceNumber2 = "k";
		subject.ReferenceNumberQualifier = referenceNumberQualifier;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("b", true)]
	public void Validation_RequiredReferenceNumber(string referenceNumber, bool isValidExpected)
	{
		var subject = new CD1_CargoDetail();
		subject.EquipmentInitial = "y";
		subject.EquipmentNumber = "Y";
		subject.BillOfLadingWaybillNumber = "p";
		subject.TypeOfServiceCode = "yu";
		subject.LocationIdentifier = "I";
		subject.Quantity = 6;
		subject.PackagingCode = "MPvTe";
		subject.DispositionCode = "Eg";
		subject.StandardCarrierAlphaCode = "9M";
		subject.ReferenceNumberQualifier = "4s";
		subject.ReferenceNumberQualifier2 = "eQ";
		subject.ReferenceNumber2 = "k";
		subject.ReferenceNumber = referenceNumber;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("eQ", true)]
	public void Validation_RequiredReferenceNumberQualifier2(string referenceNumberQualifier2, bool isValidExpected)
	{
		var subject = new CD1_CargoDetail();
		subject.EquipmentInitial = "y";
		subject.EquipmentNumber = "Y";
		subject.BillOfLadingWaybillNumber = "p";
		subject.TypeOfServiceCode = "yu";
		subject.LocationIdentifier = "I";
		subject.Quantity = 6;
		subject.PackagingCode = "MPvTe";
		subject.DispositionCode = "Eg";
		subject.StandardCarrierAlphaCode = "9M";
		subject.ReferenceNumberQualifier = "4s";
		subject.ReferenceNumber = "b";
		subject.ReferenceNumber2 = "k";
		subject.ReferenceNumberQualifier2 = referenceNumberQualifier2;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("k", true)]
	public void Validation_RequiredReferenceNumber2(string referenceNumber2, bool isValidExpected)
	{
		var subject = new CD1_CargoDetail();
		subject.EquipmentInitial = "y";
		subject.EquipmentNumber = "Y";
		subject.BillOfLadingWaybillNumber = "p";
		subject.TypeOfServiceCode = "yu";
		subject.LocationIdentifier = "I";
		subject.Quantity = 6;
		subject.PackagingCode = "MPvTe";
		subject.DispositionCode = "Eg";
		subject.StandardCarrierAlphaCode = "9M";
		subject.ReferenceNumberQualifier = "4s";
		subject.ReferenceNumber = "b";
		subject.ReferenceNumberQualifier2 = "eQ";
		subject.ReferenceNumber2 = referenceNumber2;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
