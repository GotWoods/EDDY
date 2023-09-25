using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3020;

namespace Eddy.x12.Tests.Models.v3020;

public class X02Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "X02*Nd*jW*1*gN*p";

		var expected = new X02_AutomatedManifestBillsEligibleOverdueArchiveDetails()
		{
			StandardCarrierAlphaCode = "Nd",
			StandardCarrierAlphaCode2 = "jW",
			BillOfLadingWaybillNumber = "1",
			StandardCarrierAlphaCode3 = "gN",
			BillOfLadingWaybillNumber2 = "p",
		};

		var actual = Map.MapObject<X02_AutomatedManifestBillsEligibleOverdueArchiveDetails>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("Nd", true)]
	public void Validation_RequiredStandardCarrierAlphaCode(string standardCarrierAlphaCode, bool isValidExpected)
	{
		var subject = new X02_AutomatedManifestBillsEligibleOverdueArchiveDetails();
		//Required fields
		subject.StandardCarrierAlphaCode2 = "jW";
		subject.BillOfLadingWaybillNumber = "1";
		//Test Parameters
		subject.StandardCarrierAlphaCode = standardCarrierAlphaCode;
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.StandardCarrierAlphaCode3) || !string.IsNullOrEmpty(subject.StandardCarrierAlphaCode3) || !string.IsNullOrEmpty(subject.BillOfLadingWaybillNumber2))
		{
			subject.StandardCarrierAlphaCode3 = "gN";
			subject.BillOfLadingWaybillNumber2 = "p";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("jW", true)]
	public void Validation_RequiredStandardCarrierAlphaCode2(string standardCarrierAlphaCode2, bool isValidExpected)
	{
		var subject = new X02_AutomatedManifestBillsEligibleOverdueArchiveDetails();
		//Required fields
		subject.StandardCarrierAlphaCode = "Nd";
		subject.BillOfLadingWaybillNumber = "1";
		//Test Parameters
		subject.StandardCarrierAlphaCode2 = standardCarrierAlphaCode2;
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.StandardCarrierAlphaCode3) || !string.IsNullOrEmpty(subject.StandardCarrierAlphaCode3) || !string.IsNullOrEmpty(subject.BillOfLadingWaybillNumber2))
		{
			subject.StandardCarrierAlphaCode3 = "gN";
			subject.BillOfLadingWaybillNumber2 = "p";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("1", true)]
	public void Validation_RequiredBillOfLadingWaybillNumber(string billOfLadingWaybillNumber, bool isValidExpected)
	{
		var subject = new X02_AutomatedManifestBillsEligibleOverdueArchiveDetails();
		//Required fields
		subject.StandardCarrierAlphaCode = "Nd";
		subject.StandardCarrierAlphaCode2 = "jW";
		//Test Parameters
		subject.BillOfLadingWaybillNumber = billOfLadingWaybillNumber;
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.StandardCarrierAlphaCode3) || !string.IsNullOrEmpty(subject.StandardCarrierAlphaCode3) || !string.IsNullOrEmpty(subject.BillOfLadingWaybillNumber2))
		{
			subject.StandardCarrierAlphaCode3 = "gN";
			subject.BillOfLadingWaybillNumber2 = "p";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("gN", "p", true)]
	[InlineData("gN", "", false)]
	[InlineData("", "p", false)]
	public void Validation_AllAreRequiredStandardCarrierAlphaCode3(string standardCarrierAlphaCode3, string billOfLadingWaybillNumber2, bool isValidExpected)
	{
		var subject = new X02_AutomatedManifestBillsEligibleOverdueArchiveDetails();
		//Required fields
		subject.StandardCarrierAlphaCode = "Nd";
		subject.StandardCarrierAlphaCode2 = "jW";
		subject.BillOfLadingWaybillNumber = "1";
		//Test Parameters
		subject.StandardCarrierAlphaCode3 = standardCarrierAlphaCode3;
		subject.BillOfLadingWaybillNumber2 = billOfLadingWaybillNumber2;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

}
