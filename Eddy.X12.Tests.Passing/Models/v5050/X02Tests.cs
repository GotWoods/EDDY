using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v5050;

namespace Eddy.x12.Tests.Models.v5050;

public class X02Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "X02*U2*mC*y*OT*L";

		var expected = new X02_AutomatedManifestBillsEligibleOverdueArchiveDetails()
		{
			StandardCarrierAlphaCode = "U2",
			StandardCarrierAlphaCode2 = "mC",
			BillOfLadingWaybillNumber = "y",
			StandardCarrierAlphaCode3 = "OT",
			BillOfLadingWaybillNumber2 = "L",
		};

		var actual = Map.MapObject<X02_AutomatedManifestBillsEligibleOverdueArchiveDetails>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("U2", true)]
	public void Validation_RequiredStandardCarrierAlphaCode(string standardCarrierAlphaCode, bool isValidExpected)
	{
		var subject = new X02_AutomatedManifestBillsEligibleOverdueArchiveDetails();
		//Required fields
		subject.StandardCarrierAlphaCode2 = "mC";
		subject.BillOfLadingWaybillNumber = "y";
		//Test Parameters
		subject.StandardCarrierAlphaCode = standardCarrierAlphaCode;
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.StandardCarrierAlphaCode3) || !string.IsNullOrEmpty(subject.StandardCarrierAlphaCode3) || !string.IsNullOrEmpty(subject.BillOfLadingWaybillNumber2))
		{
			subject.StandardCarrierAlphaCode3 = "OT";
			subject.BillOfLadingWaybillNumber2 = "L";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("mC", true)]
	public void Validation_RequiredStandardCarrierAlphaCode2(string standardCarrierAlphaCode2, bool isValidExpected)
	{
		var subject = new X02_AutomatedManifestBillsEligibleOverdueArchiveDetails();
		//Required fields
		subject.StandardCarrierAlphaCode = "U2";
		subject.BillOfLadingWaybillNumber = "y";
		//Test Parameters
		subject.StandardCarrierAlphaCode2 = standardCarrierAlphaCode2;
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.StandardCarrierAlphaCode3) || !string.IsNullOrEmpty(subject.StandardCarrierAlphaCode3) || !string.IsNullOrEmpty(subject.BillOfLadingWaybillNumber2))
		{
			subject.StandardCarrierAlphaCode3 = "OT";
			subject.BillOfLadingWaybillNumber2 = "L";
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
		subject.StandardCarrierAlphaCode = "U2";
		subject.StandardCarrierAlphaCode2 = "mC";
		//Test Parameters
		subject.BillOfLadingWaybillNumber = billOfLadingWaybillNumber;
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.StandardCarrierAlphaCode3) || !string.IsNullOrEmpty(subject.StandardCarrierAlphaCode3) || !string.IsNullOrEmpty(subject.BillOfLadingWaybillNumber2))
		{
			subject.StandardCarrierAlphaCode3 = "OT";
			subject.BillOfLadingWaybillNumber2 = "L";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("OT", "L", true)]
	[InlineData("OT", "", false)]
	[InlineData("", "L", false)]
	public void Validation_AllAreRequiredStandardCarrierAlphaCode3(string standardCarrierAlphaCode3, string billOfLadingWaybillNumber2, bool isValidExpected)
	{
		var subject = new X02_AutomatedManifestBillsEligibleOverdueArchiveDetails();
		//Required fields
		subject.StandardCarrierAlphaCode = "U2";
		subject.StandardCarrierAlphaCode2 = "mC";
		subject.BillOfLadingWaybillNumber = "y";
		//Test Parameters
		subject.StandardCarrierAlphaCode3 = standardCarrierAlphaCode3;
		subject.BillOfLadingWaybillNumber2 = billOfLadingWaybillNumber2;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

}
