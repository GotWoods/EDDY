using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v4010;

namespace Eddy.x12.Tests.Models.v4010;

public class X4Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "X4*I*7*u8*I*WBRuvg3h*JOep*BJ*8*yS*Jk*b*e*Q*z*39*i*fl";

		var expected = new X4_CustomsReleaseInformation()
		{
			BillOfLadingWaybillNumber = "I",
			Quantity = 7,
			CustomsEntryTypeCode = "u8",
			CustomsEntryNumber = "I",
			Date = "WBRuvg3h",
			Time = "JOep",
			DispositionCode = "BJ",
			BillOfLadingWaybillNumber2 = "8",
			StandardCarrierAlphaCode = "yS",
			StandardCarrierAlphaCode2 = "Jk",
			EquipmentInitial = "b",
			EquipmentNumber = "e",
			LocationIdentifier = "Q",
			LocationIdentifier2 = "z",
			ReferenceIdentificationQualifier = "39",
			ReferenceIdentification = "i",
			TimeCode = "fl",
		};

		var actual = Map.MapObject<X4_CustomsReleaseInformation>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("u8", "I", true)]
	[InlineData("u8", "", false)]
	[InlineData("", "I", false)]
	public void Validation_AllAreRequiredCustomsEntryTypeCode(string customsEntryTypeCode, string customsEntryNumber, bool isValidExpected)
	{
		var subject = new X4_CustomsReleaseInformation();
		//Required fields
		subject.Date = "WBRuvg3h";
		subject.DispositionCode = "BJ";
		subject.StandardCarrierAlphaCode = "yS";
		//Test Parameters
		subject.CustomsEntryTypeCode = customsEntryTypeCode;
		subject.CustomsEntryNumber = customsEntryNumber;
		//At Least one
		subject.ReferenceIdentificationQualifier = "39";
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.BillOfLadingWaybillNumber2) || !string.IsNullOrEmpty(subject.BillOfLadingWaybillNumber2) || !string.IsNullOrEmpty(subject.StandardCarrierAlphaCode2))
		{
			subject.BillOfLadingWaybillNumber2 = "8";
			subject.StandardCarrierAlphaCode2 = "Jk";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("WBRuvg3h", true)]
	public void Validation_RequiredDate(string date, bool isValidExpected)
	{
		var subject = new X4_CustomsReleaseInformation();
		//Required fields
		subject.DispositionCode = "BJ";
		subject.StandardCarrierAlphaCode = "yS";
		//Test Parameters
		subject.Date = date;
		//At Least one
		subject.ReferenceIdentificationQualifier = "39";
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.CustomsEntryTypeCode) || !string.IsNullOrEmpty(subject.CustomsEntryTypeCode) || !string.IsNullOrEmpty(subject.CustomsEntryNumber))
		{
			subject.CustomsEntryTypeCode = "u8";
			subject.CustomsEntryNumber = "I";
		}
		if(!string.IsNullOrEmpty(subject.BillOfLadingWaybillNumber2) || !string.IsNullOrEmpty(subject.BillOfLadingWaybillNumber2) || !string.IsNullOrEmpty(subject.StandardCarrierAlphaCode2))
		{
			subject.BillOfLadingWaybillNumber2 = "8";
			subject.StandardCarrierAlphaCode2 = "Jk";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("BJ", true)]
	public void Validation_RequiredDispositionCode(string dispositionCode, bool isValidExpected)
	{
		var subject = new X4_CustomsReleaseInformation();
		//Required fields
		subject.Date = "WBRuvg3h";
		subject.StandardCarrierAlphaCode = "yS";
		//Test Parameters
		subject.DispositionCode = dispositionCode;
		//At Least one
		subject.ReferenceIdentificationQualifier = "39";
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.CustomsEntryTypeCode) || !string.IsNullOrEmpty(subject.CustomsEntryTypeCode) || !string.IsNullOrEmpty(subject.CustomsEntryNumber))
		{
			subject.CustomsEntryTypeCode = "u8";
			subject.CustomsEntryNumber = "I";
		}
		if(!string.IsNullOrEmpty(subject.BillOfLadingWaybillNumber2) || !string.IsNullOrEmpty(subject.BillOfLadingWaybillNumber2) || !string.IsNullOrEmpty(subject.StandardCarrierAlphaCode2))
		{
			subject.BillOfLadingWaybillNumber2 = "8";
			subject.StandardCarrierAlphaCode2 = "Jk";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("8", "Jk", true)]
	[InlineData("8", "", false)]
	[InlineData("", "Jk", false)]
	public void Validation_AllAreRequiredBillOfLadingWaybillNumber2(string billOfLadingWaybillNumber2, string standardCarrierAlphaCode2, bool isValidExpected)
	{
		var subject = new X4_CustomsReleaseInformation();
		//Required fields
		subject.Date = "WBRuvg3h";
		subject.DispositionCode = "BJ";
		subject.StandardCarrierAlphaCode = "yS";
		//Test Parameters
		subject.BillOfLadingWaybillNumber2 = billOfLadingWaybillNumber2;
		subject.StandardCarrierAlphaCode2 = standardCarrierAlphaCode2;
		//At Least one
		subject.ReferenceIdentificationQualifier = "39";
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.CustomsEntryTypeCode) || !string.IsNullOrEmpty(subject.CustomsEntryTypeCode) || !string.IsNullOrEmpty(subject.CustomsEntryNumber))
		{
			subject.CustomsEntryTypeCode = "u8";
			subject.CustomsEntryNumber = "I";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("yS", true)]
	public void Validation_RequiredStandardCarrierAlphaCode(string standardCarrierAlphaCode, bool isValidExpected)
	{
		var subject = new X4_CustomsReleaseInformation();
		//Required fields
		subject.Date = "WBRuvg3h";
		subject.DispositionCode = "BJ";
		//Test Parameters
		subject.StandardCarrierAlphaCode = standardCarrierAlphaCode;
		//At Least one
		subject.ReferenceIdentificationQualifier = "39";
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.CustomsEntryTypeCode) || !string.IsNullOrEmpty(subject.CustomsEntryTypeCode) || !string.IsNullOrEmpty(subject.CustomsEntryNumber))
		{
			subject.CustomsEntryTypeCode = "u8";
			subject.CustomsEntryNumber = "I";
		}
		if(!string.IsNullOrEmpty(subject.BillOfLadingWaybillNumber2) || !string.IsNullOrEmpty(subject.BillOfLadingWaybillNumber2) || !string.IsNullOrEmpty(subject.StandardCarrierAlphaCode2))
		{
			subject.BillOfLadingWaybillNumber2 = "8";
			subject.StandardCarrierAlphaCode2 = "Jk";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", "", false)]
	[InlineData("39", "i", true)]
	[InlineData("39", "", true)]
	[InlineData("", "i", true)]
	public void Validation_AtLeastOneReferenceIdentificationQualifier(string referenceIdentificationQualifier, string referenceIdentification, bool isValidExpected)
	{
		var subject = new X4_CustomsReleaseInformation();
		//Required fields
		subject.Date = "WBRuvg3h";
		subject.DispositionCode = "BJ";
		subject.StandardCarrierAlphaCode = "yS";
		//Test Parameters
		subject.ReferenceIdentificationQualifier = referenceIdentificationQualifier;
		subject.ReferenceIdentification = referenceIdentification;
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.CustomsEntryTypeCode) || !string.IsNullOrEmpty(subject.CustomsEntryTypeCode) || !string.IsNullOrEmpty(subject.CustomsEntryNumber))
		{
			subject.CustomsEntryTypeCode = "u8";
			subject.CustomsEntryNumber = "I";
		}
		if(!string.IsNullOrEmpty(subject.BillOfLadingWaybillNumber2) || !string.IsNullOrEmpty(subject.BillOfLadingWaybillNumber2) || !string.IsNullOrEmpty(subject.StandardCarrierAlphaCode2))
		{
			subject.BillOfLadingWaybillNumber2 = "8";
			subject.StandardCarrierAlphaCode2 = "Jk";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.AtLeastOneIsRequired);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("fl", "JOep", true)]
	[InlineData("fl", "", false)]
	[InlineData("", "JOep", true)]
	public void Validation_ARequiresBTimeCode(string timeCode, string time, bool isValidExpected)
	{
		var subject = new X4_CustomsReleaseInformation();
		//Required fields
		subject.Date = "WBRuvg3h";
		subject.DispositionCode = "BJ";
		subject.StandardCarrierAlphaCode = "yS";
		//Test Parameters
		subject.TimeCode = timeCode;
		subject.Time = time;
		//At Least one
		subject.ReferenceIdentificationQualifier = "39";
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.CustomsEntryTypeCode) || !string.IsNullOrEmpty(subject.CustomsEntryTypeCode) || !string.IsNullOrEmpty(subject.CustomsEntryNumber))
		{
			subject.CustomsEntryTypeCode = "u8";
			subject.CustomsEntryNumber = "I";
		}
		if(!string.IsNullOrEmpty(subject.BillOfLadingWaybillNumber2) || !string.IsNullOrEmpty(subject.BillOfLadingWaybillNumber2) || !string.IsNullOrEmpty(subject.StandardCarrierAlphaCode2))
		{
			subject.BillOfLadingWaybillNumber2 = "8";
			subject.StandardCarrierAlphaCode2 = "Jk";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
	}

}
