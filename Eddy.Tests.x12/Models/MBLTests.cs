using Eddy.Core.Validation;
using Eddy.x12.Mapping;
using Eddy.x12.Models;

namespace Eddy.Tests.x12.Models;

public class MBLTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "MBL*Wv*q*S*1*Sk*3*SG*G";

		var expected = new MBL_BillOfLading()
		{
			StandardCarrierAlphaCode = "Wv",
			BillOfLadingWaybillNumber = "q",
			ActionCode = "S",
			YesNoConditionOrResponseCode = "1",
			TypeOfServiceCode = "Sk",
			LadingQuantity = 3,
			StandardCarrierAlphaCode2 = "SG",
			BillOfLadingWaybillNumber2 = "G",
		};

		var actual = Map.MapObject<MBL_BillOfLading>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("Wv", true)]
	public void Validation_RequiredStandardCarrierAlphaCode(string standardCarrierAlphaCode, bool isValidExpected)
	{
		var subject = new MBL_BillOfLading();
		subject.BillOfLadingWaybillNumber = "q";
		subject.StandardCarrierAlphaCode = standardCarrierAlphaCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("q", true)]
	public void Validation_RequiredBillOfLadingWaybillNumber(string billOfLadingWaybillNumber, bool isValidExpected)
	{
		var subject = new MBL_BillOfLading();
		subject.StandardCarrierAlphaCode = "Wv";
		subject.BillOfLadingWaybillNumber = billOfLadingWaybillNumber;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
