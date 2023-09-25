using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v4050;

namespace Eddy.x12.Tests.Models.v4050;

public class X4Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "X4*8*6*i3*8*BvCcpHKc*ho46*FY*m*hF*T6*S*4*p*M*rM*d*61*y*B";

		var expected = new X4_CustomsReleaseInformation()
		{
			BillOfLadingWaybillNumber = "8",
			Quantity = 6,
			CustomsEntryTypeCode = "i3",
			CustomsEntryNumber = "8",
			Date = "BvCcpHKc",
			Time = "ho46",
			BillOfLadingDispositionCode = "FY",
			BillOfLadingWaybillNumber2 = "m",
			StandardCarrierAlphaCode = "hF",
			StandardCarrierAlphaCode2 = "T6",
			EquipmentInitial = "S",
			EquipmentNumber = "4",
			LocationIdentifier = "p",
			LocationIdentifier2 = "M",
			ReferenceIdentificationQualifier = "rM",
			ReferenceIdentification = "d",
			TimeCode = "61",
			LocationIdentifier3 = "y",
			LocationIdentifier4 = "B",
		};

		var actual = Map.MapObject<X4_CustomsReleaseInformation>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("i3", "8", true)]
	[InlineData("i3", "", false)]
	[InlineData("", "8", false)]
	public void Validation_AllAreRequiredCustomsEntryTypeCode(string customsEntryTypeCode, string customsEntryNumber, bool isValidExpected)
	{
		var subject = new X4_CustomsReleaseInformation();
		//Required fields
		subject.Date = "BvCcpHKc";
		subject.BillOfLadingDispositionCode = "FY";
		subject.StandardCarrierAlphaCode = "hF";
		//Test Parameters
		subject.CustomsEntryTypeCode = customsEntryTypeCode;
		subject.CustomsEntryNumber = customsEntryNumber;
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.BillOfLadingWaybillNumber2) || !string.IsNullOrEmpty(subject.BillOfLadingWaybillNumber2) || !string.IsNullOrEmpty(subject.StandardCarrierAlphaCode2))
		{
			subject.BillOfLadingWaybillNumber2 = "m";
			subject.StandardCarrierAlphaCode2 = "T6";
		}
		if(!string.IsNullOrEmpty(subject.ReferenceIdentificationQualifier) || !string.IsNullOrEmpty(subject.ReferenceIdentificationQualifier) || !string.IsNullOrEmpty(subject.ReferenceIdentification))
		{
			subject.ReferenceIdentificationQualifier = "rM";
			subject.ReferenceIdentification = "d";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("BvCcpHKc", true)]
	public void Validation_RequiredDate(string date, bool isValidExpected)
	{
		var subject = new X4_CustomsReleaseInformation();
		//Required fields
		subject.BillOfLadingDispositionCode = "FY";
		subject.StandardCarrierAlphaCode = "hF";
		//Test Parameters
		subject.Date = date;
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.CustomsEntryTypeCode) || !string.IsNullOrEmpty(subject.CustomsEntryTypeCode) || !string.IsNullOrEmpty(subject.CustomsEntryNumber))
		{
			subject.CustomsEntryTypeCode = "i3";
			subject.CustomsEntryNumber = "8";
		}
		if(!string.IsNullOrEmpty(subject.BillOfLadingWaybillNumber2) || !string.IsNullOrEmpty(subject.BillOfLadingWaybillNumber2) || !string.IsNullOrEmpty(subject.StandardCarrierAlphaCode2))
		{
			subject.BillOfLadingWaybillNumber2 = "m";
			subject.StandardCarrierAlphaCode2 = "T6";
		}
		if(!string.IsNullOrEmpty(subject.ReferenceIdentificationQualifier) || !string.IsNullOrEmpty(subject.ReferenceIdentificationQualifier) || !string.IsNullOrEmpty(subject.ReferenceIdentification))
		{
			subject.ReferenceIdentificationQualifier = "rM";
			subject.ReferenceIdentification = "d";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("FY", true)]
	public void Validation_RequiredBillOfLadingDispositionCode(string billOfLadingDispositionCode, bool isValidExpected)
	{
		var subject = new X4_CustomsReleaseInformation();
		//Required fields
		subject.Date = "BvCcpHKc";
		subject.StandardCarrierAlphaCode = "hF";
		//Test Parameters
		subject.BillOfLadingDispositionCode = billOfLadingDispositionCode;
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.CustomsEntryTypeCode) || !string.IsNullOrEmpty(subject.CustomsEntryTypeCode) || !string.IsNullOrEmpty(subject.CustomsEntryNumber))
		{
			subject.CustomsEntryTypeCode = "i3";
			subject.CustomsEntryNumber = "8";
		}
		if(!string.IsNullOrEmpty(subject.BillOfLadingWaybillNumber2) || !string.IsNullOrEmpty(subject.BillOfLadingWaybillNumber2) || !string.IsNullOrEmpty(subject.StandardCarrierAlphaCode2))
		{
			subject.BillOfLadingWaybillNumber2 = "m";
			subject.StandardCarrierAlphaCode2 = "T6";
		}
		if(!string.IsNullOrEmpty(subject.ReferenceIdentificationQualifier) || !string.IsNullOrEmpty(subject.ReferenceIdentificationQualifier) || !string.IsNullOrEmpty(subject.ReferenceIdentification))
		{
			subject.ReferenceIdentificationQualifier = "rM";
			subject.ReferenceIdentification = "d";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("m", "T6", true)]
	[InlineData("m", "", false)]
	[InlineData("", "T6", false)]
	public void Validation_AllAreRequiredBillOfLadingWaybillNumber2(string billOfLadingWaybillNumber2, string standardCarrierAlphaCode2, bool isValidExpected)
	{
		var subject = new X4_CustomsReleaseInformation();
		//Required fields
		subject.Date = "BvCcpHKc";
		subject.BillOfLadingDispositionCode = "FY";
		subject.StandardCarrierAlphaCode = "hF";
		//Test Parameters
		subject.BillOfLadingWaybillNumber2 = billOfLadingWaybillNumber2;
		subject.StandardCarrierAlphaCode2 = standardCarrierAlphaCode2;
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.CustomsEntryTypeCode) || !string.IsNullOrEmpty(subject.CustomsEntryTypeCode) || !string.IsNullOrEmpty(subject.CustomsEntryNumber))
		{
			subject.CustomsEntryTypeCode = "i3";
			subject.CustomsEntryNumber = "8";
		}
		if(!string.IsNullOrEmpty(subject.ReferenceIdentificationQualifier) || !string.IsNullOrEmpty(subject.ReferenceIdentificationQualifier) || !string.IsNullOrEmpty(subject.ReferenceIdentification))
		{
			subject.ReferenceIdentificationQualifier = "rM";
			subject.ReferenceIdentification = "d";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("hF", true)]
	public void Validation_RequiredStandardCarrierAlphaCode(string standardCarrierAlphaCode, bool isValidExpected)
	{
		var subject = new X4_CustomsReleaseInformation();
		//Required fields
		subject.Date = "BvCcpHKc";
		subject.BillOfLadingDispositionCode = "FY";
		//Test Parameters
		subject.StandardCarrierAlphaCode = standardCarrierAlphaCode;
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.CustomsEntryTypeCode) || !string.IsNullOrEmpty(subject.CustomsEntryTypeCode) || !string.IsNullOrEmpty(subject.CustomsEntryNumber))
		{
			subject.CustomsEntryTypeCode = "i3";
			subject.CustomsEntryNumber = "8";
		}
		if(!string.IsNullOrEmpty(subject.BillOfLadingWaybillNumber2) || !string.IsNullOrEmpty(subject.BillOfLadingWaybillNumber2) || !string.IsNullOrEmpty(subject.StandardCarrierAlphaCode2))
		{
			subject.BillOfLadingWaybillNumber2 = "m";
			subject.StandardCarrierAlphaCode2 = "T6";
		}
		if(!string.IsNullOrEmpty(subject.ReferenceIdentificationQualifier) || !string.IsNullOrEmpty(subject.ReferenceIdentificationQualifier) || !string.IsNullOrEmpty(subject.ReferenceIdentification))
		{
			subject.ReferenceIdentificationQualifier = "rM";
			subject.ReferenceIdentification = "d";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("rM", "d", true)]
	[InlineData("rM", "", false)]
	[InlineData("", "d", false)]
	public void Validation_AllAreRequiredReferenceIdentificationQualifier(string referenceIdentificationQualifier, string referenceIdentification, bool isValidExpected)
	{
		var subject = new X4_CustomsReleaseInformation();
		//Required fields
		subject.Date = "BvCcpHKc";
		subject.BillOfLadingDispositionCode = "FY";
		subject.StandardCarrierAlphaCode = "hF";
		//Test Parameters
		subject.ReferenceIdentificationQualifier = referenceIdentificationQualifier;
		subject.ReferenceIdentification = referenceIdentification;
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.CustomsEntryTypeCode) || !string.IsNullOrEmpty(subject.CustomsEntryTypeCode) || !string.IsNullOrEmpty(subject.CustomsEntryNumber))
		{
			subject.CustomsEntryTypeCode = "i3";
			subject.CustomsEntryNumber = "8";
		}
		if(!string.IsNullOrEmpty(subject.BillOfLadingWaybillNumber2) || !string.IsNullOrEmpty(subject.BillOfLadingWaybillNumber2) || !string.IsNullOrEmpty(subject.StandardCarrierAlphaCode2))
		{
			subject.BillOfLadingWaybillNumber2 = "m";
			subject.StandardCarrierAlphaCode2 = "T6";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("61", "ho46", true)]
	[InlineData("61", "", false)]
	[InlineData("", "ho46", true)]
	public void Validation_ARequiresBTimeCode(string timeCode, string time, bool isValidExpected)
	{
		var subject = new X4_CustomsReleaseInformation();
		//Required fields
		subject.Date = "BvCcpHKc";
		subject.BillOfLadingDispositionCode = "FY";
		subject.StandardCarrierAlphaCode = "hF";
		//Test Parameters
		subject.TimeCode = timeCode;
		subject.Time = time;
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.CustomsEntryTypeCode) || !string.IsNullOrEmpty(subject.CustomsEntryTypeCode) || !string.IsNullOrEmpty(subject.CustomsEntryNumber))
		{
			subject.CustomsEntryTypeCode = "i3";
			subject.CustomsEntryNumber = "8";
		}
		if(!string.IsNullOrEmpty(subject.BillOfLadingWaybillNumber2) || !string.IsNullOrEmpty(subject.BillOfLadingWaybillNumber2) || !string.IsNullOrEmpty(subject.StandardCarrierAlphaCode2))
		{
			subject.BillOfLadingWaybillNumber2 = "m";
			subject.StandardCarrierAlphaCode2 = "T6";
		}
		if(!string.IsNullOrEmpty(subject.ReferenceIdentificationQualifier) || !string.IsNullOrEmpty(subject.ReferenceIdentificationQualifier) || !string.IsNullOrEmpty(subject.ReferenceIdentification))
		{
			subject.ReferenceIdentificationQualifier = "rM";
			subject.ReferenceIdentification = "d";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("y", "i3", true)]
	[InlineData("y", "", false)]
	[InlineData("", "i3", true)]
	public void Validation_ARequiresBLocationIdentifier3(string locationIdentifier3, string customsEntryTypeCode, bool isValidExpected)
	{
		var subject = new X4_CustomsReleaseInformation();
		//Required fields
		subject.Date = "BvCcpHKc";
		subject.BillOfLadingDispositionCode = "FY";
		subject.StandardCarrierAlphaCode = "hF";
		//Test Parameters
		subject.LocationIdentifier3 = locationIdentifier3;
		subject.CustomsEntryTypeCode = customsEntryTypeCode;
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.CustomsEntryTypeCode) || !string.IsNullOrEmpty(subject.CustomsEntryTypeCode) || !string.IsNullOrEmpty(subject.CustomsEntryNumber))
		{
			subject.CustomsEntryTypeCode = "i3";
			subject.CustomsEntryNumber = "8";
		}
		if(!string.IsNullOrEmpty(subject.BillOfLadingWaybillNumber2) || !string.IsNullOrEmpty(subject.BillOfLadingWaybillNumber2) || !string.IsNullOrEmpty(subject.StandardCarrierAlphaCode2))
		{
			subject.BillOfLadingWaybillNumber2 = "m";
			subject.StandardCarrierAlphaCode2 = "T6";
		}
		if(!string.IsNullOrEmpty(subject.ReferenceIdentificationQualifier) || !string.IsNullOrEmpty(subject.ReferenceIdentificationQualifier) || !string.IsNullOrEmpty(subject.ReferenceIdentification))
		{
			subject.ReferenceIdentificationQualifier = "rM";
			subject.ReferenceIdentification = "d";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("B", "i3", true)]
	[InlineData("B", "", false)]
	[InlineData("", "i3", true)]
	public void Validation_ARequiresBLocationIdentifier4(string locationIdentifier4, string customsEntryTypeCode, bool isValidExpected)
	{
		var subject = new X4_CustomsReleaseInformation();
		//Required fields
		subject.Date = "BvCcpHKc";
		subject.BillOfLadingDispositionCode = "FY";
		subject.StandardCarrierAlphaCode = "hF";
		//Test Parameters
		subject.LocationIdentifier4 = locationIdentifier4;
		subject.CustomsEntryTypeCode = customsEntryTypeCode;
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.CustomsEntryTypeCode) || !string.IsNullOrEmpty(subject.CustomsEntryTypeCode) || !string.IsNullOrEmpty(subject.CustomsEntryNumber))
		{
			subject.CustomsEntryTypeCode = "i3";
			subject.CustomsEntryNumber = "8";
		}
		if(!string.IsNullOrEmpty(subject.BillOfLadingWaybillNumber2) || !string.IsNullOrEmpty(subject.BillOfLadingWaybillNumber2) || !string.IsNullOrEmpty(subject.StandardCarrierAlphaCode2))
		{
			subject.BillOfLadingWaybillNumber2 = "m";
			subject.StandardCarrierAlphaCode2 = "T6";
		}
		if(!string.IsNullOrEmpty(subject.ReferenceIdentificationQualifier) || !string.IsNullOrEmpty(subject.ReferenceIdentificationQualifier) || !string.IsNullOrEmpty(subject.ReferenceIdentification))
		{
			subject.ReferenceIdentificationQualifier = "rM";
			subject.ReferenceIdentification = "d";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
	}

}
