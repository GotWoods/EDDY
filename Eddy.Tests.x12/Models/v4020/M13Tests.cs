using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v4020;

namespace Eddy.x12.Tests.Models.v4020;

public class M13Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "M13*Lq*x*N*B*9*c4*Q*D*qP*KM";

		var expected = new M13_ManifestAmendmentDetails()
		{
			StandardCarrierAlphaCode = "Lq",
			LocationIdentifier = "x",
			AmendmentTypeCode = "N",
			BillOfLadingWaybillNumber = "B",
			Quantity = 9,
			AmendmentCode = "c4",
			ActionCode = "Q",
			BillOfLadingWaybillNumber2 = "D",
			StandardCarrierAlphaCode2 = "qP",
			StandardCarrierAlphaCode3 = "KM",
		};

		var actual = Map.MapObject<M13_ManifestAmendmentDetails>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("Lq", true)]
	public void Validation_RequiredStandardCarrierAlphaCode(string standardCarrierAlphaCode, bool isValidExpected)
	{
		var subject = new M13_ManifestAmendmentDetails();
		subject.LocationIdentifier = "x";
		subject.BillOfLadingWaybillNumber = "B";
		subject.StandardCarrierAlphaCode2 = "qP";
		subject.StandardCarrierAlphaCode = standardCarrierAlphaCode;
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.BillOfLadingWaybillNumber2) || !string.IsNullOrEmpty(subject.BillOfLadingWaybillNumber2) || !string.IsNullOrEmpty(subject.StandardCarrierAlphaCode3))
		{
			subject.BillOfLadingWaybillNumber2 = "D";
			subject.StandardCarrierAlphaCode3 = "KM";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("x", true)]
	public void Validation_RequiredLocationIdentifier(string locationIdentifier, bool isValidExpected)
	{
		var subject = new M13_ManifestAmendmentDetails();
		subject.StandardCarrierAlphaCode = "Lq";
		subject.BillOfLadingWaybillNumber = "B";
		subject.StandardCarrierAlphaCode2 = "qP";
		subject.LocationIdentifier = locationIdentifier;
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.BillOfLadingWaybillNumber2) || !string.IsNullOrEmpty(subject.BillOfLadingWaybillNumber2) || !string.IsNullOrEmpty(subject.StandardCarrierAlphaCode3))
		{
			subject.BillOfLadingWaybillNumber2 = "D";
			subject.StandardCarrierAlphaCode3 = "KM";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("B", true)]
	public void Validation_RequiredBillOfLadingWaybillNumber(string billOfLadingWaybillNumber, bool isValidExpected)
	{
		var subject = new M13_ManifestAmendmentDetails();
		subject.StandardCarrierAlphaCode = "Lq";
		subject.LocationIdentifier = "x";
		subject.StandardCarrierAlphaCode2 = "qP";
		subject.BillOfLadingWaybillNumber = billOfLadingWaybillNumber;
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.BillOfLadingWaybillNumber2) || !string.IsNullOrEmpty(subject.BillOfLadingWaybillNumber2) || !string.IsNullOrEmpty(subject.StandardCarrierAlphaCode3))
		{
			subject.BillOfLadingWaybillNumber2 = "D";
			subject.StandardCarrierAlphaCode3 = "KM";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("D", "KM", true)]
	[InlineData("D", "", false)]
	[InlineData("", "KM", false)]
	public void Validation_AllAreRequiredBillOfLadingWaybillNumber2(string billOfLadingWaybillNumber2, string standardCarrierAlphaCode3, bool isValidExpected)
	{
		var subject = new M13_ManifestAmendmentDetails();
		subject.StandardCarrierAlphaCode = "Lq";
		subject.LocationIdentifier = "x";
		subject.BillOfLadingWaybillNumber = "B";
		subject.StandardCarrierAlphaCode2 = "qP";
		subject.BillOfLadingWaybillNumber2 = billOfLadingWaybillNumber2;
		subject.StandardCarrierAlphaCode3 = standardCarrierAlphaCode3;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("qP", true)]
	public void Validation_RequiredStandardCarrierAlphaCode2(string standardCarrierAlphaCode2, bool isValidExpected)
	{
		var subject = new M13_ManifestAmendmentDetails();
		subject.StandardCarrierAlphaCode = "Lq";
		subject.LocationIdentifier = "x";
		subject.BillOfLadingWaybillNumber = "B";
		subject.StandardCarrierAlphaCode2 = standardCarrierAlphaCode2;
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.BillOfLadingWaybillNumber2) || !string.IsNullOrEmpty(subject.BillOfLadingWaybillNumber2) || !string.IsNullOrEmpty(subject.StandardCarrierAlphaCode3))
		{
			subject.BillOfLadingWaybillNumber2 = "D";
			subject.StandardCarrierAlphaCode3 = "KM";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
