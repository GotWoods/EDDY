using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3010;

namespace Eddy.x12.Tests.Models.v3010;

public class M14Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "M14*6*B*w*qA*zJTVZ3*J*6z*TX";

		var expected = new M14_GeneralOrderStatusInformation()
		{
			BillOfLadingWaybillNumber = "6",
			BillOfLadingStatusCode = "B",
			EntryNumber = "w",
			EntryTypeCode = "qA",
			ReleaseIssueDate = "zJTVZ3",
			BillOfLadingWaybillNumber2 = "J",
			StandardCarrierAlphaCode = "6z",
			StandardCarrierAlphaCode2 = "TX",
		};

		var actual = Map.MapObject<M14_GeneralOrderStatusInformation>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("6", true)]
	public void Validation_RequiredBillOfLadingWaybillNumber(string billOfLadingWaybillNumber, bool isValidExpected)
	{
		var subject = new M14_GeneralOrderStatusInformation();
		subject.BillOfLadingStatusCode = "B";
		subject.StandardCarrierAlphaCode = "6z";
		subject.BillOfLadingWaybillNumber = billOfLadingWaybillNumber;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("B", true)]
	public void Validation_RequiredBillOfLadingStatusCode(string billOfLadingStatusCode, bool isValidExpected)
	{
		var subject = new M14_GeneralOrderStatusInformation();
		subject.BillOfLadingWaybillNumber = "6";
		subject.StandardCarrierAlphaCode = "6z";
		subject.BillOfLadingStatusCode = billOfLadingStatusCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("6z", true)]
	public void Validation_RequiredStandardCarrierAlphaCode(string standardCarrierAlphaCode, bool isValidExpected)
	{
		var subject = new M14_GeneralOrderStatusInformation();
		subject.BillOfLadingWaybillNumber = "6";
		subject.BillOfLadingStatusCode = "B";
		subject.StandardCarrierAlphaCode = standardCarrierAlphaCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
