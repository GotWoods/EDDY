using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v5030;

namespace Eddy.x12.Tests.Models.v5030;

public class M14Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "M14*s*d*j*FN*vNtOdObE*z*qw*6T*1*l*J";

		var expected = new M14_GeneralOrderStatusInformation()
		{
			BillOfLadingWaybillNumber = "s",
			BillOfLadingStatusCode = "d",
			CustomsEntryNumber = "j",
			CustomsEntryTypeCode = "FN",
			Date = "vNtOdObE",
			BillOfLadingWaybillNumber2 = "z",
			StandardCarrierAlphaCode = "qw",
			StandardCarrierAlphaCode2 = "6T",
			Quantity = 1,
			ReferenceIdentification = "l",
			LocationIdentifier = "J",
		};

		var actual = Map.MapObject<M14_GeneralOrderStatusInformation>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("s", true)]
	public void Validation_RequiredBillOfLadingWaybillNumber(string billOfLadingWaybillNumber, bool isValidExpected)
	{
		var subject = new M14_GeneralOrderStatusInformation();
		subject.BillOfLadingStatusCode = "d";
		subject.StandardCarrierAlphaCode = "qw";
		subject.Quantity = 1;
		subject.BillOfLadingWaybillNumber = billOfLadingWaybillNumber;
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.BillOfLadingWaybillNumber2) || !string.IsNullOrEmpty(subject.BillOfLadingWaybillNumber2) || !string.IsNullOrEmpty(subject.StandardCarrierAlphaCode2))
		{
			subject.BillOfLadingWaybillNumber2 = "z";
			subject.StandardCarrierAlphaCode2 = "6T";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("d", true)]
	public void Validation_RequiredBillOfLadingStatusCode(string billOfLadingStatusCode, bool isValidExpected)
	{
		var subject = new M14_GeneralOrderStatusInformation();
		subject.BillOfLadingWaybillNumber = "s";
		subject.StandardCarrierAlphaCode = "qw";
		subject.Quantity = 1;
		subject.BillOfLadingStatusCode = billOfLadingStatusCode;
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.BillOfLadingWaybillNumber2) || !string.IsNullOrEmpty(subject.BillOfLadingWaybillNumber2) || !string.IsNullOrEmpty(subject.StandardCarrierAlphaCode2))
		{
			subject.BillOfLadingWaybillNumber2 = "z";
			subject.StandardCarrierAlphaCode2 = "6T";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("z", "6T", true)]
	[InlineData("z", "", false)]
	[InlineData("", "6T", false)]
	public void Validation_AllAreRequiredBillOfLadingWaybillNumber2(string billOfLadingWaybillNumber2, string standardCarrierAlphaCode2, bool isValidExpected)
	{
		var subject = new M14_GeneralOrderStatusInformation();
		subject.BillOfLadingWaybillNumber = "s";
		subject.BillOfLadingStatusCode = "d";
		subject.StandardCarrierAlphaCode = "qw";
		subject.Quantity = 1;
		subject.BillOfLadingWaybillNumber2 = billOfLadingWaybillNumber2;
		subject.StandardCarrierAlphaCode2 = standardCarrierAlphaCode2;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("qw", true)]
	public void Validation_RequiredStandardCarrierAlphaCode(string standardCarrierAlphaCode, bool isValidExpected)
	{
		var subject = new M14_GeneralOrderStatusInformation();
		subject.BillOfLadingWaybillNumber = "s";
		subject.BillOfLadingStatusCode = "d";
		subject.Quantity = 1;
		subject.StandardCarrierAlphaCode = standardCarrierAlphaCode;
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.BillOfLadingWaybillNumber2) || !string.IsNullOrEmpty(subject.BillOfLadingWaybillNumber2) || !string.IsNullOrEmpty(subject.StandardCarrierAlphaCode2))
		{
			subject.BillOfLadingWaybillNumber2 = "z";
			subject.StandardCarrierAlphaCode2 = "6T";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData(0, false)]
	[InlineData(1, true)]
	public void Validation_RequiredQuantity(decimal quantity, bool isValidExpected)
	{
		var subject = new M14_GeneralOrderStatusInformation();
		subject.BillOfLadingWaybillNumber = "s";
		subject.BillOfLadingStatusCode = "d";
		subject.StandardCarrierAlphaCode = "qw";
		if (quantity > 0)
			subject.Quantity = quantity;
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.BillOfLadingWaybillNumber2) || !string.IsNullOrEmpty(subject.BillOfLadingWaybillNumber2) || !string.IsNullOrEmpty(subject.StandardCarrierAlphaCode2))
		{
			subject.BillOfLadingWaybillNumber2 = "z";
			subject.StandardCarrierAlphaCode2 = "6T";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
