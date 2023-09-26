using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v4020;

namespace Eddy.x12.Tests.Models.v4020;

public class X02Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "X02*KJ*8k*y*2s*l";

		var expected = new X02_AutomatedManifestBillsEligibleOverdueArchiveDetails()
		{
			StandardCarrierAlphaCode = "KJ",
			StandardCarrierAlphaCode2 = "8k",
			BillOfLadingWaybillNumber = "y",
			StandardCarrierAlphaCode3 = "2s",
			BillOfLadingWaybillNumber2 = "l",
		};

		var actual = Map.MapObject<X02_AutomatedManifestBillsEligibleOverdueArchiveDetails>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("KJ", true)]
	public void Validation_RequiredStandardCarrierAlphaCode(string standardCarrierAlphaCode, bool isValidExpected)
	{
		var subject = new X02_AutomatedManifestBillsEligibleOverdueArchiveDetails();
		//Required fields
		subject.StandardCarrierAlphaCode2 = "8k";
		subject.BillOfLadingWaybillNumber = "y";
		//Test Parameters
		subject.StandardCarrierAlphaCode = standardCarrierAlphaCode;
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.StandardCarrierAlphaCode3) || !string.IsNullOrEmpty(subject.StandardCarrierAlphaCode3) || !string.IsNullOrEmpty(subject.BillOfLadingWaybillNumber2))
		{
			subject.StandardCarrierAlphaCode3 = "2s";
			subject.BillOfLadingWaybillNumber2 = "l";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("8k", true)]
	public void Validation_RequiredStandardCarrierAlphaCode2(string standardCarrierAlphaCode2, bool isValidExpected)
	{
		var subject = new X02_AutomatedManifestBillsEligibleOverdueArchiveDetails();
		//Required fields
		subject.StandardCarrierAlphaCode = "KJ";
		subject.BillOfLadingWaybillNumber = "y";
		//Test Parameters
		subject.StandardCarrierAlphaCode2 = standardCarrierAlphaCode2;
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.StandardCarrierAlphaCode3) || !string.IsNullOrEmpty(subject.StandardCarrierAlphaCode3) || !string.IsNullOrEmpty(subject.BillOfLadingWaybillNumber2))
		{
			subject.StandardCarrierAlphaCode3 = "2s";
			subject.BillOfLadingWaybillNumber2 = "l";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("y", true)]
	public void Validation_RequiredBillOfLadingWaybillNumber(string billOfLadingWaybillNumber, bool isValidExpected)
	{
		var subject = new X02_AutomatedManifestBillsEligibleOverdueArchiveDetails();
		//Required fields
		subject.StandardCarrierAlphaCode = "KJ";
		subject.StandardCarrierAlphaCode2 = "8k";
		//Test Parameters
		subject.BillOfLadingWaybillNumber = billOfLadingWaybillNumber;
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.StandardCarrierAlphaCode3) || !string.IsNullOrEmpty(subject.StandardCarrierAlphaCode3) || !string.IsNullOrEmpty(subject.BillOfLadingWaybillNumber2))
		{
			subject.StandardCarrierAlphaCode3 = "2s";
			subject.BillOfLadingWaybillNumber2 = "l";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("2s", "l", true)]
	[InlineData("2s", "", false)]
	[InlineData("", "l", false)]
	public void Validation_AllAreRequiredStandardCarrierAlphaCode3(string standardCarrierAlphaCode3, string billOfLadingWaybillNumber2, bool isValidExpected)
	{
		var subject = new X02_AutomatedManifestBillsEligibleOverdueArchiveDetails();
		//Required fields
		subject.StandardCarrierAlphaCode = "KJ";
		subject.StandardCarrierAlphaCode2 = "8k";
		subject.BillOfLadingWaybillNumber = "y";
		//Test Parameters
		subject.StandardCarrierAlphaCode3 = standardCarrierAlphaCode3;
		subject.BillOfLadingWaybillNumber2 = billOfLadingWaybillNumber2;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

}
