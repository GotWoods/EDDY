using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v4020;

namespace Eddy.x12.Tests.Models.v4020;

public class X4Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "X4*G*8*zU*i*z8MJlTqw*xmuR*UR*6*BM*rq*4*R*u*o*wE*o*WU*h*3";

		var expected = new X4_CustomsReleaseInformation()
		{
			BillOfLadingWaybillNumber = "G",
			Quantity = 8,
			CustomsEntryTypeCode = "zU",
			CustomsEntryNumber = "i",
			Date = "z8MJlTqw",
			Time = "xmuR",
			DispositionCode = "UR",
			BillOfLadingWaybillNumber2 = "6",
			StandardCarrierAlphaCode = "BM",
			StandardCarrierAlphaCode2 = "rq",
			EquipmentInitial = "4",
			EquipmentNumber = "R",
			LocationIdentifier = "u",
			LocationIdentifier2 = "o",
			ReferenceIdentificationQualifier = "wE",
			ReferenceIdentification = "o",
			TimeCode = "WU",
			LocationIdentifier3 = "h",
			LocationIdentifier4 = "3",
		};

		var actual = Map.MapObject<X4_CustomsReleaseInformation>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("zU", "i", true)]
	[InlineData("zU", "", false)]
	[InlineData("", "i", false)]
	public void Validation_AllAreRequiredCustomsEntryTypeCode(string customsEntryTypeCode, string customsEntryNumber, bool isValidExpected)
	{
		var subject = new X4_CustomsReleaseInformation();
		//Required fields
		subject.Date = "z8MJlTqw";
		subject.DispositionCode = "UR";
		subject.StandardCarrierAlphaCode = "BM";
		//Test Parameters
		subject.CustomsEntryTypeCode = customsEntryTypeCode;
		subject.CustomsEntryNumber = customsEntryNumber;
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.BillOfLadingWaybillNumber2) || !string.IsNullOrEmpty(subject.BillOfLadingWaybillNumber2) || !string.IsNullOrEmpty(subject.StandardCarrierAlphaCode2))
		{
			subject.BillOfLadingWaybillNumber2 = "6";
			subject.StandardCarrierAlphaCode2 = "rq";
		}
		if(!string.IsNullOrEmpty(subject.ReferenceIdentificationQualifier) || !string.IsNullOrEmpty(subject.ReferenceIdentificationQualifier) || !string.IsNullOrEmpty(subject.ReferenceIdentification))
		{
			subject.ReferenceIdentificationQualifier = "wE";
			subject.ReferenceIdentification = "o";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("z8MJlTqw", true)]
	public void Validation_RequiredDate(string date, bool isValidExpected)
	{
		var subject = new X4_CustomsReleaseInformation();
		//Required fields
		subject.DispositionCode = "UR";
		subject.StandardCarrierAlphaCode = "BM";
		//Test Parameters
		subject.Date = date;
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.CustomsEntryTypeCode) || !string.IsNullOrEmpty(subject.CustomsEntryTypeCode) || !string.IsNullOrEmpty(subject.CustomsEntryNumber))
		{
			subject.CustomsEntryTypeCode = "zU";
			subject.CustomsEntryNumber = "i";
		}
		if(!string.IsNullOrEmpty(subject.BillOfLadingWaybillNumber2) || !string.IsNullOrEmpty(subject.BillOfLadingWaybillNumber2) || !string.IsNullOrEmpty(subject.StandardCarrierAlphaCode2))
		{
			subject.BillOfLadingWaybillNumber2 = "6";
			subject.StandardCarrierAlphaCode2 = "rq";
		}
		if(!string.IsNullOrEmpty(subject.ReferenceIdentificationQualifier) || !string.IsNullOrEmpty(subject.ReferenceIdentificationQualifier) || !string.IsNullOrEmpty(subject.ReferenceIdentification))
		{
			subject.ReferenceIdentificationQualifier = "wE";
			subject.ReferenceIdentification = "o";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("UR", true)]
	public void Validation_RequiredDispositionCode(string dispositionCode, bool isValidExpected)
	{
		var subject = new X4_CustomsReleaseInformation();
		//Required fields
		subject.Date = "z8MJlTqw";
		subject.StandardCarrierAlphaCode = "BM";
		//Test Parameters
		subject.DispositionCode = dispositionCode;
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.CustomsEntryTypeCode) || !string.IsNullOrEmpty(subject.CustomsEntryTypeCode) || !string.IsNullOrEmpty(subject.CustomsEntryNumber))
		{
			subject.CustomsEntryTypeCode = "zU";
			subject.CustomsEntryNumber = "i";
		}
		if(!string.IsNullOrEmpty(subject.BillOfLadingWaybillNumber2) || !string.IsNullOrEmpty(subject.BillOfLadingWaybillNumber2) || !string.IsNullOrEmpty(subject.StandardCarrierAlphaCode2))
		{
			subject.BillOfLadingWaybillNumber2 = "6";
			subject.StandardCarrierAlphaCode2 = "rq";
		}
		if(!string.IsNullOrEmpty(subject.ReferenceIdentificationQualifier) || !string.IsNullOrEmpty(subject.ReferenceIdentificationQualifier) || !string.IsNullOrEmpty(subject.ReferenceIdentification))
		{
			subject.ReferenceIdentificationQualifier = "wE";
			subject.ReferenceIdentification = "o";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("6", "rq", true)]
	[InlineData("6", "", false)]
	[InlineData("", "rq", false)]
	public void Validation_AllAreRequiredBillOfLadingWaybillNumber2(string billOfLadingWaybillNumber2, string standardCarrierAlphaCode2, bool isValidExpected)
	{
		var subject = new X4_CustomsReleaseInformation();
		//Required fields
		subject.Date = "z8MJlTqw";
		subject.DispositionCode = "UR";
		subject.StandardCarrierAlphaCode = "BM";
		//Test Parameters
		subject.BillOfLadingWaybillNumber2 = billOfLadingWaybillNumber2;
		subject.StandardCarrierAlphaCode2 = standardCarrierAlphaCode2;
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.CustomsEntryTypeCode) || !string.IsNullOrEmpty(subject.CustomsEntryTypeCode) || !string.IsNullOrEmpty(subject.CustomsEntryNumber))
		{
			subject.CustomsEntryTypeCode = "zU";
			subject.CustomsEntryNumber = "i";
		}
		if(!string.IsNullOrEmpty(subject.ReferenceIdentificationQualifier) || !string.IsNullOrEmpty(subject.ReferenceIdentificationQualifier) || !string.IsNullOrEmpty(subject.ReferenceIdentification))
		{
			subject.ReferenceIdentificationQualifier = "wE";
			subject.ReferenceIdentification = "o";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("BM", true)]
	public void Validation_RequiredStandardCarrierAlphaCode(string standardCarrierAlphaCode, bool isValidExpected)
	{
		var subject = new X4_CustomsReleaseInformation();
		//Required fields
		subject.Date = "z8MJlTqw";
		subject.DispositionCode = "UR";
		//Test Parameters
		subject.StandardCarrierAlphaCode = standardCarrierAlphaCode;
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.CustomsEntryTypeCode) || !string.IsNullOrEmpty(subject.CustomsEntryTypeCode) || !string.IsNullOrEmpty(subject.CustomsEntryNumber))
		{
			subject.CustomsEntryTypeCode = "zU";
			subject.CustomsEntryNumber = "i";
		}
		if(!string.IsNullOrEmpty(subject.BillOfLadingWaybillNumber2) || !string.IsNullOrEmpty(subject.BillOfLadingWaybillNumber2) || !string.IsNullOrEmpty(subject.StandardCarrierAlphaCode2))
		{
			subject.BillOfLadingWaybillNumber2 = "6";
			subject.StandardCarrierAlphaCode2 = "rq";
		}
		if(!string.IsNullOrEmpty(subject.ReferenceIdentificationQualifier) || !string.IsNullOrEmpty(subject.ReferenceIdentificationQualifier) || !string.IsNullOrEmpty(subject.ReferenceIdentification))
		{
			subject.ReferenceIdentificationQualifier = "wE";
			subject.ReferenceIdentification = "o";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("wE", "o", true)]
	[InlineData("wE", "", false)]
	[InlineData("", "o", false)]
	public void Validation_AllAreRequiredReferenceIdentificationQualifier(string referenceIdentificationQualifier, string referenceIdentification, bool isValidExpected)
	{
		var subject = new X4_CustomsReleaseInformation();
		//Required fields
		subject.Date = "z8MJlTqw";
		subject.DispositionCode = "UR";
		subject.StandardCarrierAlphaCode = "BM";
		//Test Parameters
		subject.ReferenceIdentificationQualifier = referenceIdentificationQualifier;
		subject.ReferenceIdentification = referenceIdentification;
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.CustomsEntryTypeCode) || !string.IsNullOrEmpty(subject.CustomsEntryTypeCode) || !string.IsNullOrEmpty(subject.CustomsEntryNumber))
		{
			subject.CustomsEntryTypeCode = "zU";
			subject.CustomsEntryNumber = "i";
		}
		if(!string.IsNullOrEmpty(subject.BillOfLadingWaybillNumber2) || !string.IsNullOrEmpty(subject.BillOfLadingWaybillNumber2) || !string.IsNullOrEmpty(subject.StandardCarrierAlphaCode2))
		{
			subject.BillOfLadingWaybillNumber2 = "6";
			subject.StandardCarrierAlphaCode2 = "rq";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("WU", "xmuR", true)]
	[InlineData("WU", "", false)]
	[InlineData("", "xmuR", true)]
	public void Validation_ARequiresBTimeCode(string timeCode, string time, bool isValidExpected)
	{
		var subject = new X4_CustomsReleaseInformation();
		//Required fields
		subject.Date = "z8MJlTqw";
		subject.DispositionCode = "UR";
		subject.StandardCarrierAlphaCode = "BM";
		//Test Parameters
		subject.TimeCode = timeCode;
		subject.Time = time;
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.CustomsEntryTypeCode) || !string.IsNullOrEmpty(subject.CustomsEntryTypeCode) || !string.IsNullOrEmpty(subject.CustomsEntryNumber))
		{
			subject.CustomsEntryTypeCode = "zU";
			subject.CustomsEntryNumber = "i";
		}
		if(!string.IsNullOrEmpty(subject.BillOfLadingWaybillNumber2) || !string.IsNullOrEmpty(subject.BillOfLadingWaybillNumber2) || !string.IsNullOrEmpty(subject.StandardCarrierAlphaCode2))
		{
			subject.BillOfLadingWaybillNumber2 = "6";
			subject.StandardCarrierAlphaCode2 = "rq";
		}
		if(!string.IsNullOrEmpty(subject.ReferenceIdentificationQualifier) || !string.IsNullOrEmpty(subject.ReferenceIdentificationQualifier) || !string.IsNullOrEmpty(subject.ReferenceIdentification))
		{
			subject.ReferenceIdentificationQualifier = "wE";
			subject.ReferenceIdentification = "o";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("h", "zU", true)]
	[InlineData("h", "", false)]
	[InlineData("", "zU", true)]
	public void Validation_ARequiresBLocationIdentifier3(string locationIdentifier3, string customsEntryTypeCode, bool isValidExpected)
	{
		var subject = new X4_CustomsReleaseInformation();
		//Required fields
		subject.Date = "z8MJlTqw";
		subject.DispositionCode = "UR";
		subject.StandardCarrierAlphaCode = "BM";
		//Test Parameters
		subject.LocationIdentifier3 = locationIdentifier3;
		subject.CustomsEntryTypeCode = customsEntryTypeCode;
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.CustomsEntryTypeCode) || !string.IsNullOrEmpty(subject.CustomsEntryTypeCode) || !string.IsNullOrEmpty(subject.CustomsEntryNumber))
		{
			subject.CustomsEntryTypeCode = "zU";
			subject.CustomsEntryNumber = "i";
		}
		if(!string.IsNullOrEmpty(subject.BillOfLadingWaybillNumber2) || !string.IsNullOrEmpty(subject.BillOfLadingWaybillNumber2) || !string.IsNullOrEmpty(subject.StandardCarrierAlphaCode2))
		{
			subject.BillOfLadingWaybillNumber2 = "6";
			subject.StandardCarrierAlphaCode2 = "rq";
		}
		if(!string.IsNullOrEmpty(subject.ReferenceIdentificationQualifier) || !string.IsNullOrEmpty(subject.ReferenceIdentificationQualifier) || !string.IsNullOrEmpty(subject.ReferenceIdentification))
		{
			subject.ReferenceIdentificationQualifier = "wE";
			subject.ReferenceIdentification = "o";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("3", "zU", true)]
	[InlineData("3", "", false)]
	[InlineData("", "zU", true)]
	public void Validation_ARequiresBLocationIdentifier4(string locationIdentifier4, string customsEntryTypeCode, bool isValidExpected)
	{
		var subject = new X4_CustomsReleaseInformation();
		//Required fields
		subject.Date = "z8MJlTqw";
		subject.DispositionCode = "UR";
		subject.StandardCarrierAlphaCode = "BM";
		//Test Parameters
		subject.LocationIdentifier4 = locationIdentifier4;
		subject.CustomsEntryTypeCode = customsEntryTypeCode;
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.CustomsEntryTypeCode) || !string.IsNullOrEmpty(subject.CustomsEntryTypeCode) || !string.IsNullOrEmpty(subject.CustomsEntryNumber))
		{
			subject.CustomsEntryTypeCode = "zU";
			subject.CustomsEntryNumber = "i";
		}
		if(!string.IsNullOrEmpty(subject.BillOfLadingWaybillNumber2) || !string.IsNullOrEmpty(subject.BillOfLadingWaybillNumber2) || !string.IsNullOrEmpty(subject.StandardCarrierAlphaCode2))
		{
			subject.BillOfLadingWaybillNumber2 = "6";
			subject.StandardCarrierAlphaCode2 = "rq";
		}
		if(!string.IsNullOrEmpty(subject.ReferenceIdentificationQualifier) || !string.IsNullOrEmpty(subject.ReferenceIdentificationQualifier) || !string.IsNullOrEmpty(subject.ReferenceIdentification))
		{
			subject.ReferenceIdentificationQualifier = "wE";
			subject.ReferenceIdentification = "o";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
	}

}
