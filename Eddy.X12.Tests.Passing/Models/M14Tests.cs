using Eddy.Core.Validation;
using Eddy.x12.Mapping;
using Eddy.x12.Models;

namespace Eddy.Tests.x12.Models;

public class M14Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "M14*z*E*t*ch*DEoxv0zh*J*Ws*IZ*8*y*6";

		var expected = new M14_GeneralOrderStatusInformation()
		{
			BillOfLadingWaybillNumber = "z",
			BillOfLadingStatusCode = "E",
			CustomsEntryNumber = "t",
			CustomsEntryTypeCode = "ch",
			Date = "DEoxv0zh",
			BillOfLadingWaybillNumber2 = "J",
			StandardCarrierAlphaCode = "Ws",
			StandardCarrierAlphaCode2 = "IZ",
			Quantity = 8,
			ReferenceIdentification = "y",
			LocationIdentifier = "6",
		};

		var actual = Map.MapObject<M14_GeneralOrderStatusInformation>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("z", true)]
	public void Validation_RequiredBillOfLadingWaybillNumber(string billOfLadingWaybillNumber, bool isValidExpected)
	{
		var subject = new M14_GeneralOrderStatusInformation();
		subject.BillOfLadingStatusCode = "E";
		subject.StandardCarrierAlphaCode = "Ws";
		subject.Quantity = 8;
		subject.BillOfLadingWaybillNumber = billOfLadingWaybillNumber;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("E", true)]
	public void Validation_RequiredBillOfLadingStatusCode(string billOfLadingStatusCode, bool isValidExpected)
	{
		var subject = new M14_GeneralOrderStatusInformation();
		subject.BillOfLadingWaybillNumber = "z";
		subject.StandardCarrierAlphaCode = "Ws";
		subject.Quantity = 8;
		subject.BillOfLadingStatusCode = billOfLadingStatusCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("","", true)]
	[InlineData("J", "IZ", true)]
	[InlineData("", "IZ", false)]
	[InlineData("J", "", false)]
	public void Validation_AllAreRequiredBillOfLadingWaybillNumber2(string billOfLadingWaybillNumber2, string standardCarrierAlphaCode2, bool isValidExpected)
	{
		var subject = new M14_GeneralOrderStatusInformation();
		subject.BillOfLadingWaybillNumber = "z";
		subject.BillOfLadingStatusCode = "E";
		subject.StandardCarrierAlphaCode = "Ws";
		subject.Quantity = 8;
		subject.BillOfLadingWaybillNumber2 = billOfLadingWaybillNumber2;
		subject.StandardCarrierAlphaCode2 = standardCarrierAlphaCode2;

		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("Ws", true)]
	public void Validation_RequiredStandardCarrierAlphaCode(string standardCarrierAlphaCode, bool isValidExpected)
	{
		var subject = new M14_GeneralOrderStatusInformation();
		subject.BillOfLadingWaybillNumber = "z";
		subject.BillOfLadingStatusCode = "E";
		subject.Quantity = 8;
		subject.StandardCarrierAlphaCode = standardCarrierAlphaCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData(0, false)]
	[InlineData(8, true)]
	public void Validation_RequiredQuantity(decimal quantity, bool isValidExpected)
	{
		var subject = new M14_GeneralOrderStatusInformation();
		subject.BillOfLadingWaybillNumber = "z";
		subject.BillOfLadingStatusCode = "E";
		subject.StandardCarrierAlphaCode = "Ws";
		if (quantity > 0)
		subject.Quantity = quantity;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
