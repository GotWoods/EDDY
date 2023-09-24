using Eddy.Core.Validation;
using Eddy.x12.Mapping;
using Eddy.x12.Models;

namespace Eddy.Tests.x12.Models;

public class X02Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "X02*V1*xh*4*Fz*4";

		var expected = new X02_AutomatedManifestBillsEligibleOverdueArchiveDetails()
		{
			StandardCarrierAlphaCode = "V1",
			StandardCarrierAlphaCode2 = "xh",
			BillOfLadingWaybillNumber = "4",
			StandardCarrierAlphaCode3 = "Fz",
			BillOfLadingWaybillNumber2 = "4",
		};

		var actual = Map.MapObject<X02_AutomatedManifestBillsEligibleOverdueArchiveDetails>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("V1", true)]
	public void Validation_RequiredStandardCarrierAlphaCode(string standardCarrierAlphaCode, bool isValidExpected)
	{
		var subject = new X02_AutomatedManifestBillsEligibleOverdueArchiveDetails();
		subject.StandardCarrierAlphaCode2 = "xh";
		subject.BillOfLadingWaybillNumber = "4";
		subject.StandardCarrierAlphaCode = standardCarrierAlphaCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("xh", true)]
	public void Validation_RequiredStandardCarrierAlphaCode2(string standardCarrierAlphaCode2, bool isValidExpected)
	{
		var subject = new X02_AutomatedManifestBillsEligibleOverdueArchiveDetails();
		subject.StandardCarrierAlphaCode = "V1";
		subject.BillOfLadingWaybillNumber = "4";
		subject.StandardCarrierAlphaCode2 = standardCarrierAlphaCode2;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("4", true)]
	public void Validation_RequiredBillOfLadingWaybillNumber(string billOfLadingWaybillNumber, bool isValidExpected)
	{
		var subject = new X02_AutomatedManifestBillsEligibleOverdueArchiveDetails();
		subject.StandardCarrierAlphaCode = "V1";
		subject.StandardCarrierAlphaCode2 = "xh";
		subject.BillOfLadingWaybillNumber = billOfLadingWaybillNumber;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("","", true)]
	[InlineData("Fz", "4", true)]
	[InlineData("", "4", false)]
	[InlineData("Fz", "", false)]
	public void Validation_AllAreRequiredStandardCarrierAlphaCode3(string standardCarrierAlphaCode3, string billOfLadingWaybillNumber2, bool isValidExpected)
	{
		var subject = new X02_AutomatedManifestBillsEligibleOverdueArchiveDetails();
		subject.StandardCarrierAlphaCode = "V1";
		subject.StandardCarrierAlphaCode2 = "xh";
		subject.BillOfLadingWaybillNumber = "4";
		subject.StandardCarrierAlphaCode3 = standardCarrierAlphaCode3;
		subject.BillOfLadingWaybillNumber2 = billOfLadingWaybillNumber2;

		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

}
