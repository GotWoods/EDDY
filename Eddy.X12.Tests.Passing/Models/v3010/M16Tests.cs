using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3010;

namespace Eddy.x12.Tests.Models.v3010;

public class M16Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "M16*y*5*RPamZx*b*O5*oz";

		var expected = new M16_EligibleBillsOfLading()
		{
			BillOfLadingWaybillNumber = "y",
			Quantity = 5,
			ReleaseIssueDate = "RPamZx",
			BillOfLadingWaybillNumber2 = "b",
			StandardCarrierAlphaCode = "O5",
			StandardCarrierAlphaCode2 = "oz",
		};

		var actual = Map.MapObject<M16_EligibleBillsOfLading>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("y", true)]
	public void Validation_RequiredBillOfLadingWaybillNumber(string billOfLadingWaybillNumber, bool isValidExpected)
	{
		var subject = new M16_EligibleBillsOfLading();
		subject.Quantity = 5;
		subject.StandardCarrierAlphaCode = "O5";
		subject.BillOfLadingWaybillNumber = billOfLadingWaybillNumber;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData(0, false)]
	[InlineData(5, true)]
	public void Validation_RequiredQuantity(decimal quantity, bool isValidExpected)
	{
		var subject = new M16_EligibleBillsOfLading();
		subject.BillOfLadingWaybillNumber = "y";
		subject.StandardCarrierAlphaCode = "O5";
		if (quantity > 0)
			subject.Quantity = quantity;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("O5", true)]
	public void Validation_RequiredStandardCarrierAlphaCode(string standardCarrierAlphaCode, bool isValidExpected)
	{
		var subject = new M16_EligibleBillsOfLading();
		subject.BillOfLadingWaybillNumber = "y";
		subject.Quantity = 5;
		subject.StandardCarrierAlphaCode = standardCarrierAlphaCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
