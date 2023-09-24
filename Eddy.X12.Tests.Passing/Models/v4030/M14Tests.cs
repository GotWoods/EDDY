using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v4030;

namespace Eddy.x12.Tests.Models.v4030;

public class M14Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "M14*Z*P*d*EI*45pL5NUU*f*li*fF*2*O*2";

		var expected = new M14_GeneralOrderStatusInformation()
		{
			BillOfLadingWaybillNumber = "Z",
			BillOfLadingStatusCode = "P",
			CustomsEntryNumber = "d",
			CustomsEntryTypeCode = "EI",
			Date = "45pL5NUU",
			BillOfLadingWaybillNumber2 = "f",
			StandardCarrierAlphaCode = "li",
			StandardCarrierAlphaCode2 = "fF",
			Quantity = 2,
			ReferenceIdentification = "O",
			LocationIdentifier = "2",
		};

		var actual = Map.MapObject<M14_GeneralOrderStatusInformation>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("Z", true)]
	public void Validation_RequiredBillOfLadingWaybillNumber(string billOfLadingWaybillNumber, bool isValidExpected)
	{
		var subject = new M14_GeneralOrderStatusInformation();
		subject.BillOfLadingStatusCode = "P";
		subject.StandardCarrierAlphaCode = "li";
		subject.Quantity = 2;
		subject.BillOfLadingWaybillNumber = billOfLadingWaybillNumber;
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.BillOfLadingWaybillNumber2) || !string.IsNullOrEmpty(subject.BillOfLadingWaybillNumber2) || !string.IsNullOrEmpty(subject.StandardCarrierAlphaCode2))
		{
			subject.BillOfLadingWaybillNumber2 = "f";
			subject.StandardCarrierAlphaCode2 = "fF";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("P", true)]
	public void Validation_RequiredBillOfLadingStatusCode(string billOfLadingStatusCode, bool isValidExpected)
	{
		var subject = new M14_GeneralOrderStatusInformation();
		subject.BillOfLadingWaybillNumber = "Z";
		subject.StandardCarrierAlphaCode = "li";
		subject.Quantity = 2;
		subject.BillOfLadingStatusCode = billOfLadingStatusCode;
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.BillOfLadingWaybillNumber2) || !string.IsNullOrEmpty(subject.BillOfLadingWaybillNumber2) || !string.IsNullOrEmpty(subject.StandardCarrierAlphaCode2))
		{
			subject.BillOfLadingWaybillNumber2 = "f";
			subject.StandardCarrierAlphaCode2 = "fF";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("f", "fF", true)]
	[InlineData("f", "", false)]
	[InlineData("", "fF", false)]
	public void Validation_AllAreRequiredBillOfLadingWaybillNumber2(string billOfLadingWaybillNumber2, string standardCarrierAlphaCode2, bool isValidExpected)
	{
		var subject = new M14_GeneralOrderStatusInformation();
		subject.BillOfLadingWaybillNumber = "Z";
		subject.BillOfLadingStatusCode = "P";
		subject.StandardCarrierAlphaCode = "li";
		subject.Quantity = 2;
		subject.BillOfLadingWaybillNumber2 = billOfLadingWaybillNumber2;
		subject.StandardCarrierAlphaCode2 = standardCarrierAlphaCode2;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("li", true)]
	public void Validation_RequiredStandardCarrierAlphaCode(string standardCarrierAlphaCode, bool isValidExpected)
	{
		var subject = new M14_GeneralOrderStatusInformation();
		subject.BillOfLadingWaybillNumber = "Z";
		subject.BillOfLadingStatusCode = "P";
		subject.Quantity = 2;
		subject.StandardCarrierAlphaCode = standardCarrierAlphaCode;
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.BillOfLadingWaybillNumber2) || !string.IsNullOrEmpty(subject.BillOfLadingWaybillNumber2) || !string.IsNullOrEmpty(subject.StandardCarrierAlphaCode2))
		{
			subject.BillOfLadingWaybillNumber2 = "f";
			subject.StandardCarrierAlphaCode2 = "fF";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData(0, false)]
	[InlineData(2, true)]
	public void Validation_RequiredQuantity(decimal quantity, bool isValidExpected)
	{
		var subject = new M14_GeneralOrderStatusInformation();
		subject.BillOfLadingWaybillNumber = "Z";
		subject.BillOfLadingStatusCode = "P";
		subject.StandardCarrierAlphaCode = "li";
		if (quantity > 0)
			subject.Quantity = quantity;
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.BillOfLadingWaybillNumber2) || !string.IsNullOrEmpty(subject.BillOfLadingWaybillNumber2) || !string.IsNullOrEmpty(subject.StandardCarrierAlphaCode2))
		{
			subject.BillOfLadingWaybillNumber2 = "f";
			subject.StandardCarrierAlphaCode2 = "fF";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
