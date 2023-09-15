using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3020;

namespace Eddy.x12.Tests.Models.v3020;

public class M13Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "M13*uO*x*9*k*1*NO*8*T*xw*Tk";

		var expected = new M13_ManifestAmendmentDetails()
		{
			StandardCarrierAlphaCode = "uO",
			LocationIdentifier = "x",
			AmendmentTypeCode = "9",
			BillOfLadingWaybillNumber = "k",
			Quantity = 1,
			AmendmentCode = "NO",
			ActionCode = "8",
			BillOfLadingWaybillNumber2 = "T",
			StandardCarrierAlphaCode2 = "xw",
			StandardCarrierAlphaCode3 = "Tk",
		};

		var actual = Map.MapObject<M13_ManifestAmendmentDetails>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("uO", true)]
	public void Validation_RequiredStandardCarrierAlphaCode(string standardCarrierAlphaCode, bool isValidExpected)
	{
		var subject = new M13_ManifestAmendmentDetails();
		subject.LocationIdentifier = "x";
		subject.BillOfLadingWaybillNumber = "k";
		subject.StandardCarrierAlphaCode2 = "xw";
		subject.StandardCarrierAlphaCode = standardCarrierAlphaCode;
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.BillOfLadingWaybillNumber2) || !string.IsNullOrEmpty(subject.BillOfLadingWaybillNumber2) || !string.IsNullOrEmpty(subject.StandardCarrierAlphaCode3))
		{
			subject.BillOfLadingWaybillNumber2 = "T";
			subject.StandardCarrierAlphaCode3 = "Tk";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("x", true)]
	public void Validation_RequiredLocationIdentifier(string locationIdentifier, bool isValidExpected)
	{
		var subject = new M13_ManifestAmendmentDetails();
		subject.StandardCarrierAlphaCode = "uO";
		subject.BillOfLadingWaybillNumber = "k";
		subject.StandardCarrierAlphaCode2 = "xw";
		subject.LocationIdentifier = locationIdentifier;
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.BillOfLadingWaybillNumber2) || !string.IsNullOrEmpty(subject.BillOfLadingWaybillNumber2) || !string.IsNullOrEmpty(subject.StandardCarrierAlphaCode3))
		{
			subject.BillOfLadingWaybillNumber2 = "T";
			subject.StandardCarrierAlphaCode3 = "Tk";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("k", true)]
	public void Validation_RequiredBillOfLadingWaybillNumber(string billOfLadingWaybillNumber, bool isValidExpected)
	{
		var subject = new M13_ManifestAmendmentDetails();
		subject.StandardCarrierAlphaCode = "uO";
		subject.LocationIdentifier = "x";
		subject.StandardCarrierAlphaCode2 = "xw";
		subject.BillOfLadingWaybillNumber = billOfLadingWaybillNumber;
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.BillOfLadingWaybillNumber2) || !string.IsNullOrEmpty(subject.BillOfLadingWaybillNumber2) || !string.IsNullOrEmpty(subject.StandardCarrierAlphaCode3))
		{
			subject.BillOfLadingWaybillNumber2 = "T";
			subject.StandardCarrierAlphaCode3 = "Tk";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("T", "Tk", true)]
	[InlineData("T", "", false)]
	[InlineData("", "Tk", false)]
	public void Validation_AllAreRequiredBillOfLadingWaybillNumber2(string billOfLadingWaybillNumber2, string standardCarrierAlphaCode3, bool isValidExpected)
	{
		var subject = new M13_ManifestAmendmentDetails();
		subject.StandardCarrierAlphaCode = "uO";
		subject.LocationIdentifier = "x";
		subject.BillOfLadingWaybillNumber = "k";
		subject.StandardCarrierAlphaCode2 = "xw";
		subject.BillOfLadingWaybillNumber2 = billOfLadingWaybillNumber2;
		subject.StandardCarrierAlphaCode3 = standardCarrierAlphaCode3;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("xw", true)]
	public void Validation_RequiredStandardCarrierAlphaCode2(string standardCarrierAlphaCode2, bool isValidExpected)
	{
		var subject = new M13_ManifestAmendmentDetails();
		subject.StandardCarrierAlphaCode = "uO";
		subject.LocationIdentifier = "x";
		subject.BillOfLadingWaybillNumber = "k";
		subject.StandardCarrierAlphaCode2 = standardCarrierAlphaCode2;
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.BillOfLadingWaybillNumber2) || !string.IsNullOrEmpty(subject.BillOfLadingWaybillNumber2) || !string.IsNullOrEmpty(subject.StandardCarrierAlphaCode3))
		{
			subject.BillOfLadingWaybillNumber2 = "T";
			subject.StandardCarrierAlphaCode3 = "Tk";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
