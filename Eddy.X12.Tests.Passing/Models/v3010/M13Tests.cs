using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3010;

namespace Eddy.x12.Tests.Models.v3010;

public class M13Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "M13*yf*G*u*H*4*Qx*X*X*8M*ub";

		var expected = new M13_ManifestAmendmentDetails()
		{
			StandardCarrierAlphaCode = "yf",
			LocationIdentifier = "G",
			AmendmentTypeCode = "u",
			BillOfLadingWaybillNumber = "H",
			Quantity = 4,
			AmendmentCode = "Qx",
			ActionCode = "X",
			BillOfLadingWaybillNumber2 = "X",
			StandardCarrierAlphaCode2 = "8M",
			StandardCarrierAlphaCode3 = "ub",
		};

		var actual = Map.MapObject<M13_ManifestAmendmentDetails>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("yf", true)]
	public void Validation_RequiredStandardCarrierAlphaCode(string standardCarrierAlphaCode, bool isValidExpected)
	{
		var subject = new M13_ManifestAmendmentDetails();
		subject.LocationIdentifier = "G";
		subject.BillOfLadingWaybillNumber = "H";
		subject.StandardCarrierAlphaCode2 = "8M";
		subject.StandardCarrierAlphaCode = standardCarrierAlphaCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("G", true)]
	public void Validation_RequiredLocationIdentifier(string locationIdentifier, bool isValidExpected)
	{
		var subject = new M13_ManifestAmendmentDetails();
		subject.StandardCarrierAlphaCode = "yf";
		subject.BillOfLadingWaybillNumber = "H";
		subject.StandardCarrierAlphaCode2 = "8M";
		subject.LocationIdentifier = locationIdentifier;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("H", true)]
	public void Validation_RequiredBillOfLadingWaybillNumber(string billOfLadingWaybillNumber, bool isValidExpected)
	{
		var subject = new M13_ManifestAmendmentDetails();
		subject.StandardCarrierAlphaCode = "yf";
		subject.LocationIdentifier = "G";
		subject.StandardCarrierAlphaCode2 = "8M";
		subject.BillOfLadingWaybillNumber = billOfLadingWaybillNumber;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("8M", true)]
	public void Validation_RequiredStandardCarrierAlphaCode2(string standardCarrierAlphaCode2, bool isValidExpected)
	{
		var subject = new M13_ManifestAmendmentDetails();
		subject.StandardCarrierAlphaCode = "yf";
		subject.LocationIdentifier = "G";
		subject.BillOfLadingWaybillNumber = "H";
		subject.StandardCarrierAlphaCode2 = standardCarrierAlphaCode2;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
