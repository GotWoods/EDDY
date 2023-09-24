using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3060;

namespace Eddy.x12.Tests.Models.v3060;

public class M14Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "M14*z*e*u*Fk*nnB4It*d*dr*d2*7*Q*C";

		var expected = new M14_GeneralOrderStatusInformation()
		{
			BillOfLadingWaybillNumber = "z",
			BillOfLadingStatusCode = "e",
			CustomsEntryNumber = "u",
			CustomsEntryTypeCode = "Fk",
			Date = "nnB4It",
			BillOfLadingWaybillNumber2 = "d",
			StandardCarrierAlphaCode = "dr",
			StandardCarrierAlphaCode2 = "d2",
			Quantity = 7,
			ReferenceIdentification = "Q",
			LocationIdentifier = "C",
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
		subject.BillOfLadingStatusCode = "e";
		subject.StandardCarrierAlphaCode = "dr";
		subject.Quantity = 7;
		subject.BillOfLadingWaybillNumber = billOfLadingWaybillNumber;
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.BillOfLadingWaybillNumber2) || !string.IsNullOrEmpty(subject.BillOfLadingWaybillNumber2) || !string.IsNullOrEmpty(subject.StandardCarrierAlphaCode2))
		{
			subject.BillOfLadingWaybillNumber2 = "d";
			subject.StandardCarrierAlphaCode2 = "d2";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("e", true)]
	public void Validation_RequiredBillOfLadingStatusCode(string billOfLadingStatusCode, bool isValidExpected)
	{
		var subject = new M14_GeneralOrderStatusInformation();
		subject.BillOfLadingWaybillNumber = "z";
		subject.StandardCarrierAlphaCode = "dr";
		subject.Quantity = 7;
		subject.BillOfLadingStatusCode = billOfLadingStatusCode;
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.BillOfLadingWaybillNumber2) || !string.IsNullOrEmpty(subject.BillOfLadingWaybillNumber2) || !string.IsNullOrEmpty(subject.StandardCarrierAlphaCode2))
		{
			subject.BillOfLadingWaybillNumber2 = "d";
			subject.StandardCarrierAlphaCode2 = "d2";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("d", "d2", true)]
	[InlineData("d", "", false)]
	[InlineData("", "d2", false)]
	public void Validation_AllAreRequiredBillOfLadingWaybillNumber2(string billOfLadingWaybillNumber2, string standardCarrierAlphaCode2, bool isValidExpected)
	{
		var subject = new M14_GeneralOrderStatusInformation();
		subject.BillOfLadingWaybillNumber = "z";
		subject.BillOfLadingStatusCode = "e";
		subject.StandardCarrierAlphaCode = "dr";
		subject.Quantity = 7;
		subject.BillOfLadingWaybillNumber2 = billOfLadingWaybillNumber2;
		subject.StandardCarrierAlphaCode2 = standardCarrierAlphaCode2;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("dr", true)]
	public void Validation_RequiredStandardCarrierAlphaCode(string standardCarrierAlphaCode, bool isValidExpected)
	{
		var subject = new M14_GeneralOrderStatusInformation();
		subject.BillOfLadingWaybillNumber = "z";
		subject.BillOfLadingStatusCode = "e";
		subject.Quantity = 7;
		subject.StandardCarrierAlphaCode = standardCarrierAlphaCode;
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.BillOfLadingWaybillNumber2) || !string.IsNullOrEmpty(subject.BillOfLadingWaybillNumber2) || !string.IsNullOrEmpty(subject.StandardCarrierAlphaCode2))
		{
			subject.BillOfLadingWaybillNumber2 = "d";
			subject.StandardCarrierAlphaCode2 = "d2";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData(0, false)]
	[InlineData(7, true)]
	public void Validation_RequiredQuantity(decimal quantity, bool isValidExpected)
	{
		var subject = new M14_GeneralOrderStatusInformation();
		subject.BillOfLadingWaybillNumber = "z";
		subject.BillOfLadingStatusCode = "e";
		subject.StandardCarrierAlphaCode = "dr";
		if (quantity > 0)
			subject.Quantity = quantity;
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.BillOfLadingWaybillNumber2) || !string.IsNullOrEmpty(subject.BillOfLadingWaybillNumber2) || !string.IsNullOrEmpty(subject.StandardCarrierAlphaCode2))
		{
			subject.BillOfLadingWaybillNumber2 = "d";
			subject.StandardCarrierAlphaCode2 = "d2";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
