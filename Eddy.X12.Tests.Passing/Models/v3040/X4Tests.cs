using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3040;

namespace Eddy.x12.Tests.Models.v3040;

public class X4Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "X4*8*7*li*p*wLuMzK*JCkf*PT*M*s3*4B*G*3*s*v*wh*o*vy";

		var expected = new X4_CustomsReleaseInformation()
		{
			BillOfLadingWaybillNumber = "8",
			Quantity = 7,
			EntryTypeCode = "li",
			EntryNumber = "p",
			ReleaseIssueDate = "wLuMzK",
			Time = "JCkf",
			DispositionCode = "PT",
			BillOfLadingWaybillNumber2 = "M",
			StandardCarrierAlphaCode = "s3",
			StandardCarrierAlphaCode2 = "4B",
			EquipmentInitial = "G",
			EquipmentNumber = "3",
			LocationIdentifier = "s",
			LocationIdentifier2 = "v",
			ReferenceNumberQualifier = "wh",
			ReferenceNumber = "o",
			TimeCode = "vy",
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
		subject.ReleaseIssueDate = "wLuMzK";
		subject.DispositionCode = "PT";
		subject.StandardCarrierAlphaCode = "s3";
		//Test Parameters
		subject.BillOfLadingWaybillNumber = billOfLadingWaybillNumber;
		//At Least one
		subject.ReferenceNumberQualifier = "wh";
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.BillOfLadingWaybillNumber2) || !string.IsNullOrEmpty(subject.BillOfLadingWaybillNumber2) || !string.IsNullOrEmpty(subject.StandardCarrierAlphaCode2))
		{
			subject.BillOfLadingWaybillNumber2 = "M";
			subject.StandardCarrierAlphaCode2 = "4B";
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
		subject.ReleaseIssueDate = "wLuMzK";
		subject.DispositionCode = "PT";
		subject.StandardCarrierAlphaCode = "s3";
		//Test Parameters
		if (quantity > 0) 
			subject.Quantity = quantity;
		//At Least one
		subject.ReferenceNumberQualifier = "wh";
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.BillOfLadingWaybillNumber2) || !string.IsNullOrEmpty(subject.BillOfLadingWaybillNumber2) || !string.IsNullOrEmpty(subject.StandardCarrierAlphaCode2))
		{
			subject.BillOfLadingWaybillNumber2 = "M";
			subject.StandardCarrierAlphaCode2 = "4B";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("wLuMzK", true)]
	public void Validation_RequiredReleaseIssueDate(string releaseIssueDate, bool isValidExpected)
	{
		var subject = new X4_CustomsReleaseInformation();
		//Required fields
		subject.BillOfLadingWaybillNumber = "8";
		subject.Quantity = 7;
		subject.DispositionCode = "PT";
		subject.StandardCarrierAlphaCode = "s3";
		//Test Parameters
		subject.ReleaseIssueDate = releaseIssueDate;
		//At Least one
		subject.ReferenceNumberQualifier = "wh";
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.BillOfLadingWaybillNumber2) || !string.IsNullOrEmpty(subject.BillOfLadingWaybillNumber2) || !string.IsNullOrEmpty(subject.StandardCarrierAlphaCode2))
		{
			subject.BillOfLadingWaybillNumber2 = "M";
			subject.StandardCarrierAlphaCode2 = "4B";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("PT", true)]
	public void Validation_RequiredDispositionCode(string dispositionCode, bool isValidExpected)
	{
		var subject = new X4_CustomsReleaseInformation();
		//Required fields
		subject.BillOfLadingWaybillNumber = "8";
		subject.Quantity = 7;
		subject.ReleaseIssueDate = "wLuMzK";
		subject.StandardCarrierAlphaCode = "s3";
		//Test Parameters
		subject.DispositionCode = dispositionCode;
		//At Least one
		subject.ReferenceNumberQualifier = "wh";
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.BillOfLadingWaybillNumber2) || !string.IsNullOrEmpty(subject.BillOfLadingWaybillNumber2) || !string.IsNullOrEmpty(subject.StandardCarrierAlphaCode2))
		{
			subject.BillOfLadingWaybillNumber2 = "M";
			subject.StandardCarrierAlphaCode2 = "4B";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("M", "4B", true)]
	[InlineData("M", "", false)]
	[InlineData("", "4B", false)]
	public void Validation_AllAreRequiredBillOfLadingWaybillNumber2(string billOfLadingWaybillNumber2, string standardCarrierAlphaCode2, bool isValidExpected)
	{
		var subject = new X4_CustomsReleaseInformation();
		//Required fields
		subject.BillOfLadingWaybillNumber = "8";
		subject.Quantity = 7;
		subject.ReleaseIssueDate = "wLuMzK";
		subject.DispositionCode = "PT";
		subject.StandardCarrierAlphaCode = "s3";
		//Test Parameters
		subject.BillOfLadingWaybillNumber2 = billOfLadingWaybillNumber2;
		subject.StandardCarrierAlphaCode2 = standardCarrierAlphaCode2;
		//At Least one
		subject.ReferenceNumberQualifier = "wh";
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("s3", true)]
	public void Validation_RequiredStandardCarrierAlphaCode(string standardCarrierAlphaCode, bool isValidExpected)
	{
		var subject = new X4_CustomsReleaseInformation();
		//Required fields
		subject.BillOfLadingWaybillNumber = "8";
		subject.Quantity = 7;
		subject.ReleaseIssueDate = "wLuMzK";
		subject.DispositionCode = "PT";
		//Test Parameters
		subject.StandardCarrierAlphaCode = standardCarrierAlphaCode;
		//At Least one
		subject.ReferenceNumberQualifier = "wh";
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.BillOfLadingWaybillNumber2) || !string.IsNullOrEmpty(subject.BillOfLadingWaybillNumber2) || !string.IsNullOrEmpty(subject.StandardCarrierAlphaCode2))
		{
			subject.BillOfLadingWaybillNumber2 = "M";
			subject.StandardCarrierAlphaCode2 = "4B";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", "", false)]
	[InlineData("wh", "o", true)]
	[InlineData("wh", "", true)]
	[InlineData("", "o", true)]
	public void Validation_AtLeastOneReferenceNumberQualifier(string referenceNumberQualifier, string referenceNumber, bool isValidExpected)
	{
		var subject = new X4_CustomsReleaseInformation();
		//Required fields
		subject.BillOfLadingWaybillNumber = "8";
		subject.Quantity = 7;
		subject.ReleaseIssueDate = "wLuMzK";
		subject.DispositionCode = "PT";
		subject.StandardCarrierAlphaCode = "s3";
		//Test Parameters
		subject.ReferenceNumberQualifier = referenceNumberQualifier;
		subject.ReferenceNumber = referenceNumber;
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.BillOfLadingWaybillNumber2) || !string.IsNullOrEmpty(subject.BillOfLadingWaybillNumber2) || !string.IsNullOrEmpty(subject.StandardCarrierAlphaCode2))
		{
			subject.BillOfLadingWaybillNumber2 = "M";
			subject.StandardCarrierAlphaCode2 = "4B";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.AtLeastOneIsRequired);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("vy", "JCkf", true)]
	[InlineData("vy", "", false)]
	[InlineData("", "JCkf", true)]
	public void Validation_ARequiresBTimeCode(string timeCode, string time, bool isValidExpected)
	{
		var subject = new X4_CustomsReleaseInformation();
		//Required fields
		subject.BillOfLadingWaybillNumber = "8";
		subject.Quantity = 7;
		subject.ReleaseIssueDate = "wLuMzK";
		subject.DispositionCode = "PT";
		subject.StandardCarrierAlphaCode = "s3";
		//Test Parameters
		subject.TimeCode = timeCode;
		subject.Time = time;
		//At Least one
		subject.ReferenceNumberQualifier = "wh";
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.BillOfLadingWaybillNumber2) || !string.IsNullOrEmpty(subject.BillOfLadingWaybillNumber2) || !string.IsNullOrEmpty(subject.StandardCarrierAlphaCode2))
		{
			subject.BillOfLadingWaybillNumber2 = "M";
			subject.StandardCarrierAlphaCode2 = "4B";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
	}

}
