using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v5030;

namespace Eddy.x12.Tests.Models.v5030;

public class X4Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "X4*i*4*pD*8*EFH44BSt*1E96*rZ*u*V0*xA*o*y*O*c*Eq*L*Iw*0*y";

		var expected = new X4_CustomsReleaseInformation()
		{
			BillOfLadingWaybillNumber = "i",
			Quantity = 4,
			CustomsEntryTypeCode = "pD",
			CustomsEntryNumber = "8",
			Date = "EFH44BSt",
			Time = "1E96",
			BillOfLadingDispositionCode = "rZ",
			BillOfLadingWaybillNumber2 = "u",
			StandardCarrierAlphaCode = "V0",
			StandardCarrierAlphaCode2 = "xA",
			EquipmentInitial = "o",
			EquipmentNumber = "y",
			LocationIdentifier = "O",
			LocationIdentifier2 = "c",
			ReferenceIdentificationQualifier = "Eq",
			ReferenceIdentification = "L",
			TimeCode = "Iw",
			LocationIdentifier3 = "0",
			LocationIdentifier4 = "y",
		};

		var actual = Map.MapObject<X4_CustomsReleaseInformation>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("pD", "8", true)]
	[InlineData("pD", "", false)]
	[InlineData("", "8", false)]
	public void Validation_AllAreRequiredCustomsEntryTypeCode(string customsEntryTypeCode, string customsEntryNumber, bool isValidExpected)
	{
		var subject = new X4_CustomsReleaseInformation();
		//Required fields
		subject.Date = "EFH44BSt";
		subject.BillOfLadingDispositionCode = "rZ";
		subject.StandardCarrierAlphaCode = "V0";
		//Test Parameters
		subject.CustomsEntryTypeCode = customsEntryTypeCode;
		subject.CustomsEntryNumber = customsEntryNumber;
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.BillOfLadingWaybillNumber2) || !string.IsNullOrEmpty(subject.BillOfLadingWaybillNumber2) || !string.IsNullOrEmpty(subject.StandardCarrierAlphaCode2))
		{
			subject.BillOfLadingWaybillNumber2 = "u";
			subject.StandardCarrierAlphaCode2 = "xA";
		}
		if(!string.IsNullOrEmpty(subject.ReferenceIdentificationQualifier) || !string.IsNullOrEmpty(subject.ReferenceIdentificationQualifier) || !string.IsNullOrEmpty(subject.ReferenceIdentification))
		{
			subject.ReferenceIdentificationQualifier = "Eq";
			subject.ReferenceIdentification = "L";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("EFH44BSt", true)]
	public void Validation_RequiredDate(string date, bool isValidExpected)
	{
		var subject = new X4_CustomsReleaseInformation();
		//Required fields
		subject.BillOfLadingDispositionCode = "rZ";
		subject.StandardCarrierAlphaCode = "V0";
		//Test Parameters
		subject.Date = date;
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.CustomsEntryTypeCode) || !string.IsNullOrEmpty(subject.CustomsEntryTypeCode) || !string.IsNullOrEmpty(subject.CustomsEntryNumber))
		{
			subject.CustomsEntryTypeCode = "pD";
			subject.CustomsEntryNumber = "8";
		}
		if(!string.IsNullOrEmpty(subject.BillOfLadingWaybillNumber2) || !string.IsNullOrEmpty(subject.BillOfLadingWaybillNumber2) || !string.IsNullOrEmpty(subject.StandardCarrierAlphaCode2))
		{
			subject.BillOfLadingWaybillNumber2 = "u";
			subject.StandardCarrierAlphaCode2 = "xA";
		}
		if(!string.IsNullOrEmpty(subject.ReferenceIdentificationQualifier) || !string.IsNullOrEmpty(subject.ReferenceIdentificationQualifier) || !string.IsNullOrEmpty(subject.ReferenceIdentification))
		{
			subject.ReferenceIdentificationQualifier = "Eq";
			subject.ReferenceIdentification = "L";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("rZ", true)]
	public void Validation_RequiredBillOfLadingDispositionCode(string billOfLadingDispositionCode, bool isValidExpected)
	{
		var subject = new X4_CustomsReleaseInformation();
		//Required fields
		subject.Date = "EFH44BSt";
		subject.StandardCarrierAlphaCode = "V0";
		//Test Parameters
		subject.BillOfLadingDispositionCode = billOfLadingDispositionCode;
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.CustomsEntryTypeCode) || !string.IsNullOrEmpty(subject.CustomsEntryTypeCode) || !string.IsNullOrEmpty(subject.CustomsEntryNumber))
		{
			subject.CustomsEntryTypeCode = "pD";
			subject.CustomsEntryNumber = "8";
		}
		if(!string.IsNullOrEmpty(subject.BillOfLadingWaybillNumber2) || !string.IsNullOrEmpty(subject.BillOfLadingWaybillNumber2) || !string.IsNullOrEmpty(subject.StandardCarrierAlphaCode2))
		{
			subject.BillOfLadingWaybillNumber2 = "u";
			subject.StandardCarrierAlphaCode2 = "xA";
		}
		if(!string.IsNullOrEmpty(subject.ReferenceIdentificationQualifier) || !string.IsNullOrEmpty(subject.ReferenceIdentificationQualifier) || !string.IsNullOrEmpty(subject.ReferenceIdentification))
		{
			subject.ReferenceIdentificationQualifier = "Eq";
			subject.ReferenceIdentification = "L";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("u", "xA", true)]
	[InlineData("u", "", false)]
	[InlineData("", "xA", false)]
	public void Validation_AllAreRequiredBillOfLadingWaybillNumber2(string billOfLadingWaybillNumber2, string standardCarrierAlphaCode2, bool isValidExpected)
	{
		var subject = new X4_CustomsReleaseInformation();
		//Required fields
		subject.Date = "EFH44BSt";
		subject.BillOfLadingDispositionCode = "rZ";
		subject.StandardCarrierAlphaCode = "V0";
		//Test Parameters
		subject.BillOfLadingWaybillNumber2 = billOfLadingWaybillNumber2;
		subject.StandardCarrierAlphaCode2 = standardCarrierAlphaCode2;
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.CustomsEntryTypeCode) || !string.IsNullOrEmpty(subject.CustomsEntryTypeCode) || !string.IsNullOrEmpty(subject.CustomsEntryNumber))
		{
			subject.CustomsEntryTypeCode = "pD";
			subject.CustomsEntryNumber = "8";
		}
		if(!string.IsNullOrEmpty(subject.ReferenceIdentificationQualifier) || !string.IsNullOrEmpty(subject.ReferenceIdentificationQualifier) || !string.IsNullOrEmpty(subject.ReferenceIdentification))
		{
			subject.ReferenceIdentificationQualifier = "Eq";
			subject.ReferenceIdentification = "L";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("V0", true)]
	public void Validation_RequiredStandardCarrierAlphaCode(string standardCarrierAlphaCode, bool isValidExpected)
	{
		var subject = new X4_CustomsReleaseInformation();
		//Required fields
		subject.Date = "EFH44BSt";
		subject.BillOfLadingDispositionCode = "rZ";
		//Test Parameters
		subject.StandardCarrierAlphaCode = standardCarrierAlphaCode;
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.CustomsEntryTypeCode) || !string.IsNullOrEmpty(subject.CustomsEntryTypeCode) || !string.IsNullOrEmpty(subject.CustomsEntryNumber))
		{
			subject.CustomsEntryTypeCode = "pD";
			subject.CustomsEntryNumber = "8";
		}
		if(!string.IsNullOrEmpty(subject.BillOfLadingWaybillNumber2) || !string.IsNullOrEmpty(subject.BillOfLadingWaybillNumber2) || !string.IsNullOrEmpty(subject.StandardCarrierAlphaCode2))
		{
			subject.BillOfLadingWaybillNumber2 = "u";
			subject.StandardCarrierAlphaCode2 = "xA";
		}
		if(!string.IsNullOrEmpty(subject.ReferenceIdentificationQualifier) || !string.IsNullOrEmpty(subject.ReferenceIdentificationQualifier) || !string.IsNullOrEmpty(subject.ReferenceIdentification))
		{
			subject.ReferenceIdentificationQualifier = "Eq";
			subject.ReferenceIdentification = "L";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("Eq", "L", true)]
	[InlineData("Eq", "", false)]
	[InlineData("", "L", false)]
	public void Validation_AllAreRequiredReferenceIdentificationQualifier(string referenceIdentificationQualifier, string referenceIdentification, bool isValidExpected)
	{
		var subject = new X4_CustomsReleaseInformation();
		//Required fields
		subject.Date = "EFH44BSt";
		subject.BillOfLadingDispositionCode = "rZ";
		subject.StandardCarrierAlphaCode = "V0";
		//Test Parameters
		subject.ReferenceIdentificationQualifier = referenceIdentificationQualifier;
		subject.ReferenceIdentification = referenceIdentification;
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.CustomsEntryTypeCode) || !string.IsNullOrEmpty(subject.CustomsEntryTypeCode) || !string.IsNullOrEmpty(subject.CustomsEntryNumber))
		{
			subject.CustomsEntryTypeCode = "pD";
			subject.CustomsEntryNumber = "8";
		}
		if(!string.IsNullOrEmpty(subject.BillOfLadingWaybillNumber2) || !string.IsNullOrEmpty(subject.BillOfLadingWaybillNumber2) || !string.IsNullOrEmpty(subject.StandardCarrierAlphaCode2))
		{
			subject.BillOfLadingWaybillNumber2 = "u";
			subject.StandardCarrierAlphaCode2 = "xA";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("Iw", "1E96", true)]
	[InlineData("Iw", "", false)]
	[InlineData("", "1E96", true)]
	public void Validation_ARequiresBTimeCode(string timeCode, string time, bool isValidExpected)
	{
		var subject = new X4_CustomsReleaseInformation();
		//Required fields
		subject.Date = "EFH44BSt";
		subject.BillOfLadingDispositionCode = "rZ";
		subject.StandardCarrierAlphaCode = "V0";
		//Test Parameters
		subject.TimeCode = timeCode;
		subject.Time = time;
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.CustomsEntryTypeCode) || !string.IsNullOrEmpty(subject.CustomsEntryTypeCode) || !string.IsNullOrEmpty(subject.CustomsEntryNumber))
		{
			subject.CustomsEntryTypeCode = "pD";
			subject.CustomsEntryNumber = "8";
		}
		if(!string.IsNullOrEmpty(subject.BillOfLadingWaybillNumber2) || !string.IsNullOrEmpty(subject.BillOfLadingWaybillNumber2) || !string.IsNullOrEmpty(subject.StandardCarrierAlphaCode2))
		{
			subject.BillOfLadingWaybillNumber2 = "u";
			subject.StandardCarrierAlphaCode2 = "xA";
		}
		if(!string.IsNullOrEmpty(subject.ReferenceIdentificationQualifier) || !string.IsNullOrEmpty(subject.ReferenceIdentificationQualifier) || !string.IsNullOrEmpty(subject.ReferenceIdentification))
		{
			subject.ReferenceIdentificationQualifier = "Eq";
			subject.ReferenceIdentification = "L";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("0", "pD", true)]
	[InlineData("0", "", false)]
	[InlineData("", "pD", true)]
	public void Validation_ARequiresBLocationIdentifier3(string locationIdentifier3, string customsEntryTypeCode, bool isValidExpected)
	{
		var subject = new X4_CustomsReleaseInformation();
		//Required fields
		subject.Date = "EFH44BSt";
		subject.BillOfLadingDispositionCode = "rZ";
		subject.StandardCarrierAlphaCode = "V0";
		//Test Parameters
		subject.LocationIdentifier3 = locationIdentifier3;
		subject.CustomsEntryTypeCode = customsEntryTypeCode;
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.CustomsEntryTypeCode) || !string.IsNullOrEmpty(subject.CustomsEntryTypeCode) || !string.IsNullOrEmpty(subject.CustomsEntryNumber))
		{
			subject.CustomsEntryTypeCode = "pD";
			subject.CustomsEntryNumber = "8";
		}
		if(!string.IsNullOrEmpty(subject.BillOfLadingWaybillNumber2) || !string.IsNullOrEmpty(subject.BillOfLadingWaybillNumber2) || !string.IsNullOrEmpty(subject.StandardCarrierAlphaCode2))
		{
			subject.BillOfLadingWaybillNumber2 = "u";
			subject.StandardCarrierAlphaCode2 = "xA";
		}
		if(!string.IsNullOrEmpty(subject.ReferenceIdentificationQualifier) || !string.IsNullOrEmpty(subject.ReferenceIdentificationQualifier) || !string.IsNullOrEmpty(subject.ReferenceIdentification))
		{
			subject.ReferenceIdentificationQualifier = "Eq";
			subject.ReferenceIdentification = "L";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("y", "pD", true)]
	[InlineData("y", "", false)]
	[InlineData("", "pD", true)]
	public void Validation_ARequiresBLocationIdentifier4(string locationIdentifier4, string customsEntryTypeCode, bool isValidExpected)
	{
		var subject = new X4_CustomsReleaseInformation();
		//Required fields
		subject.Date = "EFH44BSt";
		subject.BillOfLadingDispositionCode = "rZ";
		subject.StandardCarrierAlphaCode = "V0";
		//Test Parameters
		subject.LocationIdentifier4 = locationIdentifier4;
		subject.CustomsEntryTypeCode = customsEntryTypeCode;
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.CustomsEntryTypeCode) || !string.IsNullOrEmpty(subject.CustomsEntryTypeCode) || !string.IsNullOrEmpty(subject.CustomsEntryNumber))
		{
			subject.CustomsEntryTypeCode = "pD";
			subject.CustomsEntryNumber = "8";
		}
		if(!string.IsNullOrEmpty(subject.BillOfLadingWaybillNumber2) || !string.IsNullOrEmpty(subject.BillOfLadingWaybillNumber2) || !string.IsNullOrEmpty(subject.StandardCarrierAlphaCode2))
		{
			subject.BillOfLadingWaybillNumber2 = "u";
			subject.StandardCarrierAlphaCode2 = "xA";
		}
		if(!string.IsNullOrEmpty(subject.ReferenceIdentificationQualifier) || !string.IsNullOrEmpty(subject.ReferenceIdentificationQualifier) || !string.IsNullOrEmpty(subject.ReferenceIdentification))
		{
			subject.ReferenceIdentificationQualifier = "Eq";
			subject.ReferenceIdentification = "L";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
	}

}
