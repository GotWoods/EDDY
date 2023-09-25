using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3010;

namespace Eddy.x12.Tests.Models.v3010;

public class X4Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "X4*X*1*rn*T*CPvafH*686a*Rq*I*4U*O4*g*7";

		var expected = new X4_CustomsReleaseInformation()
		{
			BillOfLadingWaybillNumber = "X",
			Quantity = 1,
			EntryTypeCode = "rn",
			EntryNumber = "T",
			ReleaseIssueDate = "CPvafH",
			Time = "686a",
			DispositionCode = "Rq",
			BillOfLadingWaybillNumber2 = "I",
			StandardCarrierAlphaCode = "4U",
			StandardCarrierAlphaCode2 = "O4",
			EquipmentInitial = "g",
			EquipmentNumber = "7",
		};

		var actual = Map.MapObject<X4_CustomsReleaseInformation>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("X", true)]
	public void Validation_RequiredBillOfLadingWaybillNumber(string billOfLadingWaybillNumber, bool isValidExpected)
	{
		var subject = new X4_CustomsReleaseInformation();
		//Required fields
		subject.Quantity = 1;
		subject.ReleaseIssueDate = "CPvafH";
		subject.Time = "686a";
		subject.DispositionCode = "Rq";
		subject.StandardCarrierAlphaCode = "4U";
		//Test Parameters
		subject.BillOfLadingWaybillNumber = billOfLadingWaybillNumber;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData(0, false)]
	[InlineData(1, true)]
	public void Validation_RequiredQuantity(decimal quantity, bool isValidExpected)
	{
		var subject = new X4_CustomsReleaseInformation();
		//Required fields
		subject.BillOfLadingWaybillNumber = "X";
		subject.ReleaseIssueDate = "CPvafH";
		subject.Time = "686a";
		subject.DispositionCode = "Rq";
		subject.StandardCarrierAlphaCode = "4U";
		//Test Parameters
		if (quantity > 0) 
			subject.Quantity = quantity;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("CPvafH", true)]
	public void Validation_RequiredReleaseIssueDate(string releaseIssueDate, bool isValidExpected)
	{
		var subject = new X4_CustomsReleaseInformation();
		//Required fields
		subject.BillOfLadingWaybillNumber = "X";
		subject.Quantity = 1;
		subject.Time = "686a";
		subject.DispositionCode = "Rq";
		subject.StandardCarrierAlphaCode = "4U";
		//Test Parameters
		subject.ReleaseIssueDate = releaseIssueDate;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("686a", true)]
	public void Validation_RequiredTime(string time, bool isValidExpected)
	{
		var subject = new X4_CustomsReleaseInformation();
		//Required fields
		subject.BillOfLadingWaybillNumber = "X";
		subject.Quantity = 1;
		subject.ReleaseIssueDate = "CPvafH";
		subject.DispositionCode = "Rq";
		subject.StandardCarrierAlphaCode = "4U";
		//Test Parameters
		subject.Time = time;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("Rq", true)]
	public void Validation_RequiredDispositionCode(string dispositionCode, bool isValidExpected)
	{
		var subject = new X4_CustomsReleaseInformation();
		//Required fields
		subject.BillOfLadingWaybillNumber = "X";
		subject.Quantity = 1;
		subject.ReleaseIssueDate = "CPvafH";
		subject.Time = "686a";
		subject.StandardCarrierAlphaCode = "4U";
		//Test Parameters
		subject.DispositionCode = dispositionCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("4U", true)]
	public void Validation_RequiredStandardCarrierAlphaCode(string standardCarrierAlphaCode, bool isValidExpected)
	{
		var subject = new X4_CustomsReleaseInformation();
		//Required fields
		subject.BillOfLadingWaybillNumber = "X";
		subject.Quantity = 1;
		subject.ReleaseIssueDate = "CPvafH";
		subject.Time = "686a";
		subject.DispositionCode = "Rq";
		//Test Parameters
		subject.StandardCarrierAlphaCode = standardCarrierAlphaCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
