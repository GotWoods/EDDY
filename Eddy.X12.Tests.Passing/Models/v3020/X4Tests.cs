using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3020;

namespace Eddy.x12.Tests.Models.v3020;

public class X4Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "X4*8*7*nv*k*Kudqzp*VS0j*ks*G*jH*vx*5*N*1";

		var expected = new X4_CustomsReleaseInformation()
		{
			BillOfLadingWaybillNumber = "8",
			Quantity = 7,
			EntryTypeCode = "nv",
			EntryNumber = "k",
			ReleaseIssueDate = "Kudqzp",
			Time = "VS0j",
			DispositionCode = "ks",
			BillOfLadingWaybillNumber2 = "G",
			StandardCarrierAlphaCode = "jH",
			StandardCarrierAlphaCode2 = "vx",
			EquipmentInitial = "5",
			EquipmentNumber = "N",
			LocationIdentifier = "1",
		};

		var actual = Map.MapObject<X4_CustomsReleaseInformation>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("8", true)]
	public void Validation_RequiredBillOfLadingWaybillNumber(string billOfLadingWaybillNumber, bool isValidExpected)
	{
		var subject = new X4_CustomsReleaseInformation();
		//Required fields
		subject.Quantity = 7;
		subject.ReleaseIssueDate = "Kudqzp";
		subject.Time = "VS0j";
		subject.DispositionCode = "ks";
		subject.StandardCarrierAlphaCode = "jH";
		//Test Parameters
		subject.BillOfLadingWaybillNumber = billOfLadingWaybillNumber;
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.BillOfLadingWaybillNumber2) || !string.IsNullOrEmpty(subject.BillOfLadingWaybillNumber2) || !string.IsNullOrEmpty(subject.StandardCarrierAlphaCode2))
		{
			subject.BillOfLadingWaybillNumber2 = "G";
			subject.StandardCarrierAlphaCode2 = "vx";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData(0, false)]
	[InlineData(7, true)]
	public void Validation_RequiredQuantity(decimal quantity, bool isValidExpected)
	{
		var subject = new X4_CustomsReleaseInformation();
		//Required fields
		subject.BillOfLadingWaybillNumber = "8";
		subject.ReleaseIssueDate = "Kudqzp";
		subject.Time = "VS0j";
		subject.DispositionCode = "ks";
		subject.StandardCarrierAlphaCode = "jH";
		//Test Parameters
		if (quantity > 0) 
			subject.Quantity = quantity;
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.BillOfLadingWaybillNumber2) || !string.IsNullOrEmpty(subject.BillOfLadingWaybillNumber2) || !string.IsNullOrEmpty(subject.StandardCarrierAlphaCode2))
		{
			subject.BillOfLadingWaybillNumber2 = "G";
			subject.StandardCarrierAlphaCode2 = "vx";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("Kudqzp", true)]
	public void Validation_RequiredReleaseIssueDate(string releaseIssueDate, bool isValidExpected)
	{
		var subject = new X4_CustomsReleaseInformation();
		//Required fields
		subject.BillOfLadingWaybillNumber = "8";
		subject.Quantity = 7;
		subject.Time = "VS0j";
		subject.DispositionCode = "ks";
		subject.StandardCarrierAlphaCode = "jH";
		//Test Parameters
		subject.ReleaseIssueDate = releaseIssueDate;
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.BillOfLadingWaybillNumber2) || !string.IsNullOrEmpty(subject.BillOfLadingWaybillNumber2) || !string.IsNullOrEmpty(subject.StandardCarrierAlphaCode2))
		{
			subject.BillOfLadingWaybillNumber2 = "G";
			subject.StandardCarrierAlphaCode2 = "vx";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("VS0j", true)]
	public void Validation_RequiredTime(string time, bool isValidExpected)
	{
		var subject = new X4_CustomsReleaseInformation();
		//Required fields
		subject.BillOfLadingWaybillNumber = "8";
		subject.Quantity = 7;
		subject.ReleaseIssueDate = "Kudqzp";
		subject.DispositionCode = "ks";
		subject.StandardCarrierAlphaCode = "jH";
		//Test Parameters
		subject.Time = time;
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.BillOfLadingWaybillNumber2) || !string.IsNullOrEmpty(subject.BillOfLadingWaybillNumber2) || !string.IsNullOrEmpty(subject.StandardCarrierAlphaCode2))
		{
			subject.BillOfLadingWaybillNumber2 = "G";
			subject.StandardCarrierAlphaCode2 = "vx";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("ks", true)]
	public void Validation_RequiredDispositionCode(string dispositionCode, bool isValidExpected)
	{
		var subject = new X4_CustomsReleaseInformation();
		//Required fields
		subject.BillOfLadingWaybillNumber = "8";
		subject.Quantity = 7;
		subject.ReleaseIssueDate = "Kudqzp";
		subject.Time = "VS0j";
		subject.StandardCarrierAlphaCode = "jH";
		//Test Parameters
		subject.DispositionCode = dispositionCode;
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.BillOfLadingWaybillNumber2) || !string.IsNullOrEmpty(subject.BillOfLadingWaybillNumber2) || !string.IsNullOrEmpty(subject.StandardCarrierAlphaCode2))
		{
			subject.BillOfLadingWaybillNumber2 = "G";
			subject.StandardCarrierAlphaCode2 = "vx";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("G", "vx", true)]
	[InlineData("G", "", false)]
	[InlineData("", "vx", false)]
	public void Validation_AllAreRequiredBillOfLadingWaybillNumber2(string billOfLadingWaybillNumber2, string standardCarrierAlphaCode2, bool isValidExpected)
	{
		var subject = new X4_CustomsReleaseInformation();
		//Required fields
		subject.BillOfLadingWaybillNumber = "8";
		subject.Quantity = 7;
		subject.ReleaseIssueDate = "Kudqzp";
		subject.Time = "VS0j";
		subject.DispositionCode = "ks";
		subject.StandardCarrierAlphaCode = "jH";
		//Test Parameters
		subject.BillOfLadingWaybillNumber2 = billOfLadingWaybillNumber2;
		subject.StandardCarrierAlphaCode2 = standardCarrierAlphaCode2;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("jH", true)]
	public void Validation_RequiredStandardCarrierAlphaCode(string standardCarrierAlphaCode, bool isValidExpected)
	{
		var subject = new X4_CustomsReleaseInformation();
		//Required fields
		subject.BillOfLadingWaybillNumber = "8";
		subject.Quantity = 7;
		subject.ReleaseIssueDate = "Kudqzp";
		subject.Time = "VS0j";
		subject.DispositionCode = "ks";
		//Test Parameters
		subject.StandardCarrierAlphaCode = standardCarrierAlphaCode;
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.BillOfLadingWaybillNumber2) || !string.IsNullOrEmpty(subject.BillOfLadingWaybillNumber2) || !string.IsNullOrEmpty(subject.StandardCarrierAlphaCode2))
		{
			subject.BillOfLadingWaybillNumber2 = "G";
			subject.StandardCarrierAlphaCode2 = "vx";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
