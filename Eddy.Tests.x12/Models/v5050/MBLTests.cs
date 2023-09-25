using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v5050;

namespace Eddy.x12.Tests.Models.v5050;

public class MBLTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "MBL*ZR*h*C*5*Sy*4*mc*c";

		var expected = new MBL_BillOfLading()
		{
			StandardCarrierAlphaCode = "ZR",
			BillOfLadingWaybillNumber = "h",
			ActionCode = "C",
			YesNoConditionOrResponseCode = "5",
			TypeOfServiceCode = "Sy",
			LadingQuantity = 4,
			StandardCarrierAlphaCode2 = "mc",
			BillOfLadingWaybillNumber2 = "c",
		};

		var actual = Map.MapObject<MBL_BillOfLading>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("ZR", true)]
	public void Validation_RequiredStandardCarrierAlphaCode(string standardCarrierAlphaCode, bool isValidExpected)
	{
		var subject = new MBL_BillOfLading();
		//Required fields
		subject.BillOfLadingWaybillNumber = "h";
		//Test Parameters
		subject.StandardCarrierAlphaCode = standardCarrierAlphaCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("h", true)]
	public void Validation_RequiredBillOfLadingWaybillNumber(string billOfLadingWaybillNumber, bool isValidExpected)
	{
		var subject = new MBL_BillOfLading();
		//Required fields
		subject.StandardCarrierAlphaCode = "ZR";
		//Test Parameters
		subject.BillOfLadingWaybillNumber = billOfLadingWaybillNumber;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
