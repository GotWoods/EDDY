using Eddy.Core.Validation;
using Eddy.x12.Mapping;
using Eddy.x12.Models;

namespace Eddy.Tests.x12.Models;

public class M11Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "M11*B*J*4*l*7*6*1*I*rU*W*6*Xf*br*lO*Sx*X*Jj*nv*HC*g*r*w*GTb*p*0*T3*WxvenQJq*D";

		var expected = new M11_ManifestBillOfLadingDetails()
		{
			BillOfLadingWaybillNumber = "B",
			LocationIdentifier = "J",
			Quantity = 4,
			ManifestUnitCode = "l",
			Weight = 7,
			WeightUnitCode = "6",
			Volume = 1,
			VolumeUnitQualifier = "I",
			BillOfLadingTypeCode = "rU",
			PlaceOfReceiptByPreCarrier = "W",
			BillOfLadingWaybillNumber2 = "6",
			StandardCarrierAlphaCode = "Xf",
			StandardCarrierAlphaCode2 = "br",
			StandardCarrierAlphaCode3 = "lO",
			StandardCarrierAlphaCode4 = "Sx",
			ShippersExportDeclarationRequirements = "X",
			ExportExceptionCode = "Jj",
			StandardCarrierAlphaCode5 = "nv",
			StandardCarrierAlphaCode6 = "HC",
			LocationIdentifier2 = "g",
			LocationIdentifier3 = "r",
			TransportationMethodTypeCode = "w",
			PaymentMethodCode = "GTb",
			IndustryCode = "p",
			LocationQualifier = "0",
			ServiceLevelCode = "T3",
			Date = "WxvenQJq",
			YesNoConditionOrResponseCode = "D",
		};

		var actual = Map.MapObject<M11_ManifestBillOfLadingDetails>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("B", true)]
	public void Validation_RequiredBillOfLadingWaybillNumber(string billOfLadingWaybillNumber, bool isValidExpected)
	{
		var subject = new M11_ManifestBillOfLadingDetails();
		subject.LocationIdentifier = "J";
		subject.StandardCarrierAlphaCode = "Xf";
		subject.LocationQualifier = "0";
		subject.BillOfLadingWaybillNumber = billOfLadingWaybillNumber;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("J", true)]
	public void Validation_RequiredLocationIdentifier(string locationIdentifier, bool isValidExpected)
	{
		var subject = new M11_ManifestBillOfLadingDetails();
		subject.BillOfLadingWaybillNumber = "B";
		subject.StandardCarrierAlphaCode = "Xf";
		subject.LocationQualifier = "0";
		subject.LocationIdentifier = locationIdentifier;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData(0,"", true)]
	[InlineData(4, "l", true)]
	[InlineData(0, "l", false)]
	[InlineData(4, "", false)]
	public void Validation_AllAreRequiredQuantity(decimal quantity, string manifestUnitCode, bool isValidExpected)
	{
		var subject = new M11_ManifestBillOfLadingDetails();
		subject.BillOfLadingWaybillNumber = "B";
		subject.LocationIdentifier = "J";
		subject.StandardCarrierAlphaCode = "Xf";
		subject.LocationQualifier = "0";
		if (quantity > 0)
		subject.Quantity = quantity;
		subject.ManifestUnitCode = manifestUnitCode;

		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

	[Theory]
	[InlineData(0,"", true)]
	[InlineData(7, "6", true)]
	[InlineData(0, "6", false)]
	[InlineData(7, "", false)]
	public void Validation_AllAreRequiredWeight(decimal weight, string weightUnitCode, bool isValidExpected)
	{
		var subject = new M11_ManifestBillOfLadingDetails();
		subject.BillOfLadingWaybillNumber = "B";
		subject.LocationIdentifier = "J";
		subject.StandardCarrierAlphaCode = "Xf";
		subject.LocationQualifier = "0";
		if (weight > 0)
		subject.Weight = weight;
		subject.WeightUnitCode = weightUnitCode;

		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

	[Theory]
	[InlineData(0,"", true)]
	[InlineData(1, "I", true)]
	[InlineData(0, "I", false)]
	[InlineData(1, "", false)]
	public void Validation_AllAreRequiredVolume(decimal volume, string volumeUnitQualifier, bool isValidExpected)
	{
		var subject = new M11_ManifestBillOfLadingDetails();
		subject.BillOfLadingWaybillNumber = "B";
		subject.LocationIdentifier = "J";
		subject.StandardCarrierAlphaCode = "Xf";
		subject.LocationQualifier = "0";
		if (volume > 0)
		subject.Volume = volume;
		subject.VolumeUnitQualifier = volumeUnitQualifier;

		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

	[Theory]
	[InlineData("","", true)]
	[InlineData("6", "br", true)]
	[InlineData("", "br", false)]
	[InlineData("6", "", false)]
	public void Validation_AllAreRequiredBillOfLadingWaybillNumber2(string billOfLadingWaybillNumber2, string standardCarrierAlphaCode2, bool isValidExpected)
	{
		var subject = new M11_ManifestBillOfLadingDetails();
		subject.BillOfLadingWaybillNumber = "B";
		subject.LocationIdentifier = "J";
		subject.StandardCarrierAlphaCode = "Xf";
		subject.LocationQualifier = "0";
		subject.BillOfLadingWaybillNumber2 = billOfLadingWaybillNumber2;
		subject.StandardCarrierAlphaCode2 = standardCarrierAlphaCode2;

		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("Xf", true)]
	public void Validation_RequiredStandardCarrierAlphaCode(string standardCarrierAlphaCode, bool isValidExpected)
	{
		var subject = new M11_ManifestBillOfLadingDetails();
		subject.BillOfLadingWaybillNumber = "B";
		subject.LocationIdentifier = "J";
		subject.LocationQualifier = "0";
		subject.StandardCarrierAlphaCode = standardCarrierAlphaCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("", "lO", true)]
	[InlineData("Sx", "", false)]
	public void Validation_ARequiresBStandardCarrierAlphaCode4(string standardCarrierAlphaCode4, string standardCarrierAlphaCode3, bool isValidExpected)
	{
		var subject = new M11_ManifestBillOfLadingDetails();
		subject.BillOfLadingWaybillNumber = "B";
		subject.LocationIdentifier = "J";
		subject.StandardCarrierAlphaCode = "Xf";
		subject.LocationQualifier = "0";
		subject.StandardCarrierAlphaCode4 = standardCarrierAlphaCode4;
		subject.StandardCarrierAlphaCode3 = standardCarrierAlphaCode3;

		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("", "Sx", true)]
	[InlineData("nv", "", false)]
	public void Validation_ARequiresBStandardCarrierAlphaCode5(string standardCarrierAlphaCode5, string standardCarrierAlphaCode4, bool isValidExpected)
	{
		var subject = new M11_ManifestBillOfLadingDetails();
		subject.BillOfLadingWaybillNumber = "B";
		subject.LocationIdentifier = "J";
		subject.StandardCarrierAlphaCode = "Xf";
		subject.LocationQualifier = "0";
		subject.StandardCarrierAlphaCode5 = standardCarrierAlphaCode5;
		subject.StandardCarrierAlphaCode4 = standardCarrierAlphaCode4;

		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("", "nv", true)]
	[InlineData("HC", "", false)]
	public void Validation_ARequiresBStandardCarrierAlphaCode6(string standardCarrierAlphaCode6, string standardCarrierAlphaCode5, bool isValidExpected)
	{
		var subject = new M11_ManifestBillOfLadingDetails();
		subject.BillOfLadingWaybillNumber = "B";
		subject.LocationIdentifier = "J";
		subject.StandardCarrierAlphaCode = "Xf";
		subject.LocationQualifier = "0";
		subject.StandardCarrierAlphaCode6 = standardCarrierAlphaCode6;
		subject.StandardCarrierAlphaCode5 = standardCarrierAlphaCode5;

		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("0", true)]
	public void Validation_RequiredLocationQualifier(string locationQualifier, bool isValidExpected)
	{
		var subject = new M11_ManifestBillOfLadingDetails();
		subject.BillOfLadingWaybillNumber = "B";
		subject.LocationIdentifier = "J";
		subject.StandardCarrierAlphaCode = "Xf";
		subject.LocationQualifier = locationQualifier;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
