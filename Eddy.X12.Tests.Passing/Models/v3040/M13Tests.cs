using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3040;

namespace Eddy.x12.Tests.Models.v3040;

public class M13Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "M13*eV*s*f*R*3*wh*L*2*Ew*P4";

		var expected = new M13_ManifestAmendmentDetails()
		{
			StandardCarrierAlphaCode = "eV",
			LocationIdentifier = "s",
			AmendmentTypeCode = "f",
			BillOfLadingWaybillNumber = "R",
			Quantity = 3,
			AmendmentCode = "wh",
			ActionCode = "L",
			BillOfLadingWaybillNumber2 = "2",
			StandardCarrierAlphaCode2 = "Ew",
			StandardCarrierAlphaCode3 = "P4",
		};

		var actual = Map.MapObject<M13_ManifestAmendmentDetails>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("eV", true)]
	public void Validation_RequiredStandardCarrierAlphaCode(string standardCarrierAlphaCode, bool isValidExpected)
	{
		var subject = new M13_ManifestAmendmentDetails();
		subject.LocationIdentifier = "s";
		subject.BillOfLadingWaybillNumber = "R";
		subject.StandardCarrierAlphaCode2 = "Ew";
		subject.StandardCarrierAlphaCode = standardCarrierAlphaCode;
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.BillOfLadingWaybillNumber2) || !string.IsNullOrEmpty(subject.BillOfLadingWaybillNumber2) || !string.IsNullOrEmpty(subject.StandardCarrierAlphaCode3))
		{
			subject.BillOfLadingWaybillNumber2 = "2";
			subject.StandardCarrierAlphaCode3 = "P4";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("s", true)]
	public void Validation_RequiredLocationIdentifier(string locationIdentifier, bool isValidExpected)
	{
		var subject = new M13_ManifestAmendmentDetails();
		subject.StandardCarrierAlphaCode = "eV";
		subject.BillOfLadingWaybillNumber = "R";
		subject.StandardCarrierAlphaCode2 = "Ew";
		subject.LocationIdentifier = locationIdentifier;
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.BillOfLadingWaybillNumber2) || !string.IsNullOrEmpty(subject.BillOfLadingWaybillNumber2) || !string.IsNullOrEmpty(subject.StandardCarrierAlphaCode3))
		{
			subject.BillOfLadingWaybillNumber2 = "2";
			subject.StandardCarrierAlphaCode3 = "P4";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("R", true)]
	public void Validation_RequiredBillOfLadingWaybillNumber(string billOfLadingWaybillNumber, bool isValidExpected)
	{
		var subject = new M13_ManifestAmendmentDetails();
		subject.StandardCarrierAlphaCode = "eV";
		subject.LocationIdentifier = "s";
		subject.StandardCarrierAlphaCode2 = "Ew";
		subject.BillOfLadingWaybillNumber = billOfLadingWaybillNumber;
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.BillOfLadingWaybillNumber2) || !string.IsNullOrEmpty(subject.BillOfLadingWaybillNumber2) || !string.IsNullOrEmpty(subject.StandardCarrierAlphaCode3))
		{
			subject.BillOfLadingWaybillNumber2 = "2";
			subject.StandardCarrierAlphaCode3 = "P4";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("2", "P4", true)]
	[InlineData("2", "", false)]
	[InlineData("", "P4", false)]
	public void Validation_AllAreRequiredBillOfLadingWaybillNumber2(string billOfLadingWaybillNumber2, string standardCarrierAlphaCode3, bool isValidExpected)
	{
		var subject = new M13_ManifestAmendmentDetails();
		subject.StandardCarrierAlphaCode = "eV";
		subject.LocationIdentifier = "s";
		subject.BillOfLadingWaybillNumber = "R";
		subject.StandardCarrierAlphaCode2 = "Ew";
		subject.BillOfLadingWaybillNumber2 = billOfLadingWaybillNumber2;
		subject.StandardCarrierAlphaCode3 = standardCarrierAlphaCode3;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("Ew", true)]
	public void Validation_RequiredStandardCarrierAlphaCode2(string standardCarrierAlphaCode2, bool isValidExpected)
	{
		var subject = new M13_ManifestAmendmentDetails();
		subject.StandardCarrierAlphaCode = "eV";
		subject.LocationIdentifier = "s";
		subject.BillOfLadingWaybillNumber = "R";
		subject.StandardCarrierAlphaCode2 = standardCarrierAlphaCode2;
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.BillOfLadingWaybillNumber2) || !string.IsNullOrEmpty(subject.BillOfLadingWaybillNumber2) || !string.IsNullOrEmpty(subject.StandardCarrierAlphaCode3))
		{
			subject.BillOfLadingWaybillNumber2 = "2";
			subject.StandardCarrierAlphaCode3 = "P4";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
