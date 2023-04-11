using Eddy.Core.Validation;
using Eddy.x12.Mapping;
using Eddy.x12.Models;

namespace Eddy.Tests.x12.Models;

public class M13Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "M13*RX*2*a*n*2*DT*K*t*7h*Wc*O*BA";

		var expected = new M13_ManifestAmendmentDetails()
		{
			StandardCarrierAlphaCode = "RX",
			LocationIdentifier = "2",
			AmendmentTypeCode = "a",
			BillOfLadingWaybillNumber = "n",
			Quantity = 2,
			AmendmentCode = "DT",
			ActionCode = "K",
			BillOfLadingWaybillNumber2 = "t",
			StandardCarrierAlphaCode2 = "7h",
			StandardCarrierAlphaCode3 = "Wc",
			IdentificationCodeQualifier = "O",
			IdentificationCode = "BA",
		};

		var actual = Map.MapObject<M13_ManifestAmendmentDetails>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("RX", true)]
	public void Validation_RequiredStandardCarrierAlphaCode(string standardCarrierAlphaCode, bool isValidExpected)
	{
		var subject = new M13_ManifestAmendmentDetails();
		subject.LocationIdentifier = "2";
		subject.BillOfLadingWaybillNumber = "n";
		subject.StandardCarrierAlphaCode = standardCarrierAlphaCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("2", true)]
	public void Validation_RequiredLocationIdentifier(string locationIdentifier, bool isValidExpected)
	{
		var subject = new M13_ManifestAmendmentDetails();
		subject.StandardCarrierAlphaCode = "RX";
		subject.BillOfLadingWaybillNumber = "n";
		subject.LocationIdentifier = locationIdentifier;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("n", true)]
	public void Validation_RequiredBillOfLadingWaybillNumber(string billOfLadingWaybillNumber, bool isValidExpected)
	{
		var subject = new M13_ManifestAmendmentDetails();
		subject.StandardCarrierAlphaCode = "RX";
		subject.LocationIdentifier = "2";
		subject.BillOfLadingWaybillNumber = billOfLadingWaybillNumber;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("","", true)]
	[InlineData("t", "Wc", true)]
	[InlineData("", "Wc", false)]
	[InlineData("t", "", false)]
	public void Validation_AllAreRequiredBillOfLadingWaybillNumber2(string billOfLadingWaybillNumber2, string standardCarrierAlphaCode3, bool isValidExpected)
	{
		var subject = new M13_ManifestAmendmentDetails();
		subject.StandardCarrierAlphaCode = "RX";
		subject.LocationIdentifier = "2";
		subject.BillOfLadingWaybillNumber = "n";
		subject.BillOfLadingWaybillNumber2 = billOfLadingWaybillNumber2;
		subject.StandardCarrierAlphaCode3 = standardCarrierAlphaCode3;

		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

	[Theory]
	[InlineData("","", true)]
	[InlineData("O", "BA", true)]
	[InlineData("", "BA", false)]
	[InlineData("O", "", false)]
	public void Validation_AllAreRequiredIdentificationCodeQualifier(string identificationCodeQualifier, string identificationCode, bool isValidExpected)
	{
		var subject = new M13_ManifestAmendmentDetails();
		subject.StandardCarrierAlphaCode = "RX";
		subject.LocationIdentifier = "2";
		subject.BillOfLadingWaybillNumber = "n";
		subject.IdentificationCodeQualifier = identificationCodeQualifier;
		subject.IdentificationCode = identificationCode;

		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

}
