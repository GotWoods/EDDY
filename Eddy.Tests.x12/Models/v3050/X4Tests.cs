using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3050;

namespace Eddy.x12.Tests.Models.v3050;

public class X4Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "X4*Z*9*wD*9*mE4JaJ*IX4f*m4*m*MJ*uD*S*I*8*v*ln*6*xI";

		var expected = new X4_CustomsReleaseInformation()
		{
			BillOfLadingWaybillNumber = "Z",
			Quantity = 9,
			EntryTypeCode = "wD",
			EntryNumber = "9",
			Date = "mE4JaJ",
			Time = "IX4f",
			DispositionCode = "m4",
			BillOfLadingWaybillNumber2 = "m",
			StandardCarrierAlphaCode = "MJ",
			StandardCarrierAlphaCode2 = "uD",
			EquipmentInitial = "S",
			EquipmentNumber = "I",
			LocationIdentifier = "8",
			LocationIdentifier2 = "v",
			ReferenceNumberQualifier = "ln",
			ReferenceNumber = "6",
			TimeCode = "xI",
		};

		var actual = Map.MapObject<X4_CustomsReleaseInformation>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("Z", true)]
	public void Validation_RequiredBillOfLadingWaybillNumber(string billOfLadingWaybillNumber, bool isValidExpected)
	{
		var subject = new X4_CustomsReleaseInformation();
		//Required fields
		subject.Quantity = 9;
		subject.Date = "mE4JaJ";
		subject.DispositionCode = "m4";
		subject.StandardCarrierAlphaCode = "MJ";
		//Test Parameters
		subject.BillOfLadingWaybillNumber = billOfLadingWaybillNumber;
		//At Least one
		subject.ReferenceNumberQualifier = "ln";
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.EntryTypeCode) || !string.IsNullOrEmpty(subject.EntryTypeCode) || !string.IsNullOrEmpty(subject.EntryNumber))
		{
			subject.EntryTypeCode = "wD";
			subject.EntryNumber = "9";
		}
		if(!string.IsNullOrEmpty(subject.BillOfLadingWaybillNumber2) || !string.IsNullOrEmpty(subject.BillOfLadingWaybillNumber2) || !string.IsNullOrEmpty(subject.StandardCarrierAlphaCode2))
		{
			subject.BillOfLadingWaybillNumber2 = "m";
			subject.StandardCarrierAlphaCode2 = "uD";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData(0, false)]
	[InlineData(9, true)]
	public void Validation_RequiredQuantity(decimal quantity, bool isValidExpected)
	{
		var subject = new X4_CustomsReleaseInformation();
		//Required fields
		subject.BillOfLadingWaybillNumber = "Z";
		subject.Date = "mE4JaJ";
		subject.DispositionCode = "m4";
		subject.StandardCarrierAlphaCode = "MJ";
		//Test Parameters
		if (quantity > 0) 
			subject.Quantity = quantity;
		//At Least one
		subject.ReferenceNumberQualifier = "ln";
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.EntryTypeCode) || !string.IsNullOrEmpty(subject.EntryTypeCode) || !string.IsNullOrEmpty(subject.EntryNumber))
		{
			subject.EntryTypeCode = "wD";
			subject.EntryNumber = "9";
		}
		if(!string.IsNullOrEmpty(subject.BillOfLadingWaybillNumber2) || !string.IsNullOrEmpty(subject.BillOfLadingWaybillNumber2) || !string.IsNullOrEmpty(subject.StandardCarrierAlphaCode2))
		{
			subject.BillOfLadingWaybillNumber2 = "m";
			subject.StandardCarrierAlphaCode2 = "uD";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("wD", "9", true)]
	[InlineData("wD", "", false)]
	[InlineData("", "9", false)]
	public void Validation_AllAreRequiredEntryTypeCode(string entryTypeCode, string entryNumber, bool isValidExpected)
	{
		var subject = new X4_CustomsReleaseInformation();
		//Required fields
		subject.BillOfLadingWaybillNumber = "Z";
		subject.Quantity = 9;
		subject.Date = "mE4JaJ";
		subject.DispositionCode = "m4";
		subject.StandardCarrierAlphaCode = "MJ";
		//Test Parameters
		subject.EntryTypeCode = entryTypeCode;
		subject.EntryNumber = entryNumber;
		//At Least one
		subject.ReferenceNumberQualifier = "ln";
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.BillOfLadingWaybillNumber2) || !string.IsNullOrEmpty(subject.BillOfLadingWaybillNumber2) || !string.IsNullOrEmpty(subject.StandardCarrierAlphaCode2))
		{
			subject.BillOfLadingWaybillNumber2 = "m";
			subject.StandardCarrierAlphaCode2 = "uD";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("mE4JaJ", true)]
	public void Validation_RequiredDate(string date, bool isValidExpected)
	{
		var subject = new X4_CustomsReleaseInformation();
		//Required fields
		subject.BillOfLadingWaybillNumber = "Z";
		subject.Quantity = 9;
		subject.DispositionCode = "m4";
		subject.StandardCarrierAlphaCode = "MJ";
		//Test Parameters
		subject.Date = date;
		//At Least one
		subject.ReferenceNumberQualifier = "ln";
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.EntryTypeCode) || !string.IsNullOrEmpty(subject.EntryTypeCode) || !string.IsNullOrEmpty(subject.EntryNumber))
		{
			subject.EntryTypeCode = "wD";
			subject.EntryNumber = "9";
		}
		if(!string.IsNullOrEmpty(subject.BillOfLadingWaybillNumber2) || !string.IsNullOrEmpty(subject.BillOfLadingWaybillNumber2) || !string.IsNullOrEmpty(subject.StandardCarrierAlphaCode2))
		{
			subject.BillOfLadingWaybillNumber2 = "m";
			subject.StandardCarrierAlphaCode2 = "uD";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("m4", true)]
	public void Validation_RequiredDispositionCode(string dispositionCode, bool isValidExpected)
	{
		var subject = new X4_CustomsReleaseInformation();
		//Required fields
		subject.BillOfLadingWaybillNumber = "Z";
		subject.Quantity = 9;
		subject.Date = "mE4JaJ";
		subject.StandardCarrierAlphaCode = "MJ";
		//Test Parameters
		subject.DispositionCode = dispositionCode;
		//At Least one
		subject.ReferenceNumberQualifier = "ln";
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.EntryTypeCode) || !string.IsNullOrEmpty(subject.EntryTypeCode) || !string.IsNullOrEmpty(subject.EntryNumber))
		{
			subject.EntryTypeCode = "wD";
			subject.EntryNumber = "9";
		}
		if(!string.IsNullOrEmpty(subject.BillOfLadingWaybillNumber2) || !string.IsNullOrEmpty(subject.BillOfLadingWaybillNumber2) || !string.IsNullOrEmpty(subject.StandardCarrierAlphaCode2))
		{
			subject.BillOfLadingWaybillNumber2 = "m";
			subject.StandardCarrierAlphaCode2 = "uD";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("m", "uD", true)]
	[InlineData("m", "", false)]
	[InlineData("", "uD", false)]
	public void Validation_AllAreRequiredBillOfLadingWaybillNumber2(string billOfLadingWaybillNumber2, string standardCarrierAlphaCode2, bool isValidExpected)
	{
		var subject = new X4_CustomsReleaseInformation();
		//Required fields
		subject.BillOfLadingWaybillNumber = "Z";
		subject.Quantity = 9;
		subject.Date = "mE4JaJ";
		subject.DispositionCode = "m4";
		subject.StandardCarrierAlphaCode = "MJ";
		//Test Parameters
		subject.BillOfLadingWaybillNumber2 = billOfLadingWaybillNumber2;
		subject.StandardCarrierAlphaCode2 = standardCarrierAlphaCode2;
		//At Least one
		subject.ReferenceNumberQualifier = "ln";
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.EntryTypeCode) || !string.IsNullOrEmpty(subject.EntryTypeCode) || !string.IsNullOrEmpty(subject.EntryNumber))
		{
			subject.EntryTypeCode = "wD";
			subject.EntryNumber = "9";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("MJ", true)]
	public void Validation_RequiredStandardCarrierAlphaCode(string standardCarrierAlphaCode, bool isValidExpected)
	{
		var subject = new X4_CustomsReleaseInformation();
		//Required fields
		subject.BillOfLadingWaybillNumber = "Z";
		subject.Quantity = 9;
		subject.Date = "mE4JaJ";
		subject.DispositionCode = "m4";
		//Test Parameters
		subject.StandardCarrierAlphaCode = standardCarrierAlphaCode;
		//At Least one
		subject.ReferenceNumberQualifier = "ln";
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.EntryTypeCode) || !string.IsNullOrEmpty(subject.EntryTypeCode) || !string.IsNullOrEmpty(subject.EntryNumber))
		{
			subject.EntryTypeCode = "wD";
			subject.EntryNumber = "9";
		}
		if(!string.IsNullOrEmpty(subject.BillOfLadingWaybillNumber2) || !string.IsNullOrEmpty(subject.BillOfLadingWaybillNumber2) || !string.IsNullOrEmpty(subject.StandardCarrierAlphaCode2))
		{
			subject.BillOfLadingWaybillNumber2 = "m";
			subject.StandardCarrierAlphaCode2 = "uD";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", "", false)]
	[InlineData("ln", "6", true)]
	[InlineData("ln", "", true)]
	[InlineData("", "6", true)]
	public void Validation_AtLeastOneReferenceNumberQualifier(string referenceNumberQualifier, string referenceNumber, bool isValidExpected)
	{
		var subject = new X4_CustomsReleaseInformation();
		//Required fields
		subject.BillOfLadingWaybillNumber = "Z";
		subject.Quantity = 9;
		subject.Date = "mE4JaJ";
		subject.DispositionCode = "m4";
		subject.StandardCarrierAlphaCode = "MJ";
		//Test Parameters
		subject.ReferenceNumberQualifier = referenceNumberQualifier;
		subject.ReferenceNumber = referenceNumber;
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.EntryTypeCode) || !string.IsNullOrEmpty(subject.EntryTypeCode) || !string.IsNullOrEmpty(subject.EntryNumber))
		{
			subject.EntryTypeCode = "wD";
			subject.EntryNumber = "9";
		}
		if(!string.IsNullOrEmpty(subject.BillOfLadingWaybillNumber2) || !string.IsNullOrEmpty(subject.BillOfLadingWaybillNumber2) || !string.IsNullOrEmpty(subject.StandardCarrierAlphaCode2))
		{
			subject.BillOfLadingWaybillNumber2 = "m";
			subject.StandardCarrierAlphaCode2 = "uD";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.AtLeastOneIsRequired);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("xI", "IX4f", true)]
	[InlineData("xI", "", false)]
	[InlineData("", "IX4f", true)]
	public void Validation_ARequiresBTimeCode(string timeCode, string time, bool isValidExpected)
	{
		var subject = new X4_CustomsReleaseInformation();
		//Required fields
		subject.BillOfLadingWaybillNumber = "Z";
		subject.Quantity = 9;
		subject.Date = "mE4JaJ";
		subject.DispositionCode = "m4";
		subject.StandardCarrierAlphaCode = "MJ";
		//Test Parameters
		subject.TimeCode = timeCode;
		subject.Time = time;
		//At Least one
		subject.ReferenceNumberQualifier = "ln";
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.EntryTypeCode) || !string.IsNullOrEmpty(subject.EntryTypeCode) || !string.IsNullOrEmpty(subject.EntryNumber))
		{
			subject.EntryTypeCode = "wD";
			subject.EntryNumber = "9";
		}
		if(!string.IsNullOrEmpty(subject.BillOfLadingWaybillNumber2) || !string.IsNullOrEmpty(subject.BillOfLadingWaybillNumber2) || !string.IsNullOrEmpty(subject.StandardCarrierAlphaCode2))
		{
			subject.BillOfLadingWaybillNumber2 = "m";
			subject.StandardCarrierAlphaCode2 = "uD";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
	}

}
