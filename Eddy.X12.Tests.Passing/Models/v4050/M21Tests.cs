using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v4050;

namespace Eddy.x12.Tests.Models.v4050;

public class M21Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "M21*aq*U*OO*A*3*L*vB*k*qL*d*5A*kG*8*kb*H";

		var expected = new M21_SupplementaryInBondInformation()
		{
			CustomsEntryTypeCode = "aq",
			LocationIdentifier = "U",
			StandardCarrierAlphaCode = "OO",
			BillOfLadingWaybillNumber = "A",
			MasterInBondTypeCode = "3",
			InBondControlNumber = "L",
			StandardCarrierAlphaCode2 = "vB",
			BillOfLadingWaybillNumber2 = "k",
			StandardCarrierAlphaCode3 = "qL",
			BillOfLadingWaybillNumber3 = "d",
			StandardCarrierAlphaCode4 = "5A",
			StandardCarrierAlphaCode5 = "kG",
			Quantity = 8,
			ReferenceIdentificationQualifier = "kb",
			ReferenceIdentification = "H",
		};

		var actual = Map.MapObject<M21_SupplementaryInBondInformation>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("aq", true)]
	public void Validation_RequiredCustomsEntryTypeCode(string customsEntryTypeCode, bool isValidExpected)
	{
		var subject = new M21_SupplementaryInBondInformation();
		//Required fields
		subject.LocationIdentifier = "U";
		subject.StandardCarrierAlphaCode = "OO";
		subject.BillOfLadingWaybillNumber = "A";
		//Test Parameters
		subject.CustomsEntryTypeCode = customsEntryTypeCode;
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.StandardCarrierAlphaCode2) || !string.IsNullOrEmpty(subject.StandardCarrierAlphaCode2) || !string.IsNullOrEmpty(subject.BillOfLadingWaybillNumber2))
		{
			subject.StandardCarrierAlphaCode2 = "vB";
			subject.BillOfLadingWaybillNumber2 = "k";
		}
		if(!string.IsNullOrEmpty(subject.StandardCarrierAlphaCode3) || !string.IsNullOrEmpty(subject.StandardCarrierAlphaCode3) || !string.IsNullOrEmpty(subject.BillOfLadingWaybillNumber3))
		{
			subject.StandardCarrierAlphaCode3 = "qL";
			subject.BillOfLadingWaybillNumber3 = "d";
		}
		if(!string.IsNullOrEmpty(subject.ReferenceIdentificationQualifier) || !string.IsNullOrEmpty(subject.ReferenceIdentificationQualifier) || !string.IsNullOrEmpty(subject.ReferenceIdentification))
		{
			subject.ReferenceIdentificationQualifier = "kb";
			subject.ReferenceIdentification = "H";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("U", true)]
	public void Validation_RequiredLocationIdentifier(string locationIdentifier, bool isValidExpected)
	{
		var subject = new M21_SupplementaryInBondInformation();
		//Required fields
		subject.CustomsEntryTypeCode = "aq";
		subject.StandardCarrierAlphaCode = "OO";
		subject.BillOfLadingWaybillNumber = "A";
		//Test Parameters
		subject.LocationIdentifier = locationIdentifier;
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.StandardCarrierAlphaCode2) || !string.IsNullOrEmpty(subject.StandardCarrierAlphaCode2) || !string.IsNullOrEmpty(subject.BillOfLadingWaybillNumber2))
		{
			subject.StandardCarrierAlphaCode2 = "vB";
			subject.BillOfLadingWaybillNumber2 = "k";
		}
		if(!string.IsNullOrEmpty(subject.StandardCarrierAlphaCode3) || !string.IsNullOrEmpty(subject.StandardCarrierAlphaCode3) || !string.IsNullOrEmpty(subject.BillOfLadingWaybillNumber3))
		{
			subject.StandardCarrierAlphaCode3 = "qL";
			subject.BillOfLadingWaybillNumber3 = "d";
		}
		if(!string.IsNullOrEmpty(subject.ReferenceIdentificationQualifier) || !string.IsNullOrEmpty(subject.ReferenceIdentificationQualifier) || !string.IsNullOrEmpty(subject.ReferenceIdentification))
		{
			subject.ReferenceIdentificationQualifier = "kb";
			subject.ReferenceIdentification = "H";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("OO", true)]
	public void Validation_RequiredStandardCarrierAlphaCode(string standardCarrierAlphaCode, bool isValidExpected)
	{
		var subject = new M21_SupplementaryInBondInformation();
		//Required fields
		subject.CustomsEntryTypeCode = "aq";
		subject.LocationIdentifier = "U";
		subject.BillOfLadingWaybillNumber = "A";
		//Test Parameters
		subject.StandardCarrierAlphaCode = standardCarrierAlphaCode;
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.StandardCarrierAlphaCode2) || !string.IsNullOrEmpty(subject.StandardCarrierAlphaCode2) || !string.IsNullOrEmpty(subject.BillOfLadingWaybillNumber2))
		{
			subject.StandardCarrierAlphaCode2 = "vB";
			subject.BillOfLadingWaybillNumber2 = "k";
		}
		if(!string.IsNullOrEmpty(subject.StandardCarrierAlphaCode3) || !string.IsNullOrEmpty(subject.StandardCarrierAlphaCode3) || !string.IsNullOrEmpty(subject.BillOfLadingWaybillNumber3))
		{
			subject.StandardCarrierAlphaCode3 = "qL";
			subject.BillOfLadingWaybillNumber3 = "d";
		}
		if(!string.IsNullOrEmpty(subject.ReferenceIdentificationQualifier) || !string.IsNullOrEmpty(subject.ReferenceIdentificationQualifier) || !string.IsNullOrEmpty(subject.ReferenceIdentification))
		{
			subject.ReferenceIdentificationQualifier = "kb";
			subject.ReferenceIdentification = "H";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("A", true)]
	public void Validation_RequiredBillOfLadingWaybillNumber(string billOfLadingWaybillNumber, bool isValidExpected)
	{
		var subject = new M21_SupplementaryInBondInformation();
		//Required fields
		subject.CustomsEntryTypeCode = "aq";
		subject.LocationIdentifier = "U";
		subject.StandardCarrierAlphaCode = "OO";
		//Test Parameters
		subject.BillOfLadingWaybillNumber = billOfLadingWaybillNumber;
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.StandardCarrierAlphaCode2) || !string.IsNullOrEmpty(subject.StandardCarrierAlphaCode2) || !string.IsNullOrEmpty(subject.BillOfLadingWaybillNumber2))
		{
			subject.StandardCarrierAlphaCode2 = "vB";
			subject.BillOfLadingWaybillNumber2 = "k";
		}
		if(!string.IsNullOrEmpty(subject.StandardCarrierAlphaCode3) || !string.IsNullOrEmpty(subject.StandardCarrierAlphaCode3) || !string.IsNullOrEmpty(subject.BillOfLadingWaybillNumber3))
		{
			subject.StandardCarrierAlphaCode3 = "qL";
			subject.BillOfLadingWaybillNumber3 = "d";
		}
		if(!string.IsNullOrEmpty(subject.ReferenceIdentificationQualifier) || !string.IsNullOrEmpty(subject.ReferenceIdentificationQualifier) || !string.IsNullOrEmpty(subject.ReferenceIdentification))
		{
			subject.ReferenceIdentificationQualifier = "kb";
			subject.ReferenceIdentification = "H";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("vB", "k", true)]
	[InlineData("vB", "", false)]
	[InlineData("", "k", false)]
	public void Validation_AllAreRequiredStandardCarrierAlphaCode2(string standardCarrierAlphaCode2, string billOfLadingWaybillNumber2, bool isValidExpected)
	{
		var subject = new M21_SupplementaryInBondInformation();
		//Required fields
		subject.CustomsEntryTypeCode = "aq";
		subject.LocationIdentifier = "U";
		subject.StandardCarrierAlphaCode = "OO";
		subject.BillOfLadingWaybillNumber = "A";
		//Test Parameters
		subject.StandardCarrierAlphaCode2 = standardCarrierAlphaCode2;
		subject.BillOfLadingWaybillNumber2 = billOfLadingWaybillNumber2;
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.StandardCarrierAlphaCode3) || !string.IsNullOrEmpty(subject.StandardCarrierAlphaCode3) || !string.IsNullOrEmpty(subject.BillOfLadingWaybillNumber3))
		{
			subject.StandardCarrierAlphaCode3 = "qL";
			subject.BillOfLadingWaybillNumber3 = "d";
		}
		if(!string.IsNullOrEmpty(subject.ReferenceIdentificationQualifier) || !string.IsNullOrEmpty(subject.ReferenceIdentificationQualifier) || !string.IsNullOrEmpty(subject.ReferenceIdentification))
		{
			subject.ReferenceIdentificationQualifier = "kb";
			subject.ReferenceIdentification = "H";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("qL", "d", true)]
	[InlineData("qL", "", false)]
	[InlineData("", "d", false)]
	public void Validation_AllAreRequiredStandardCarrierAlphaCode3(string standardCarrierAlphaCode3, string billOfLadingWaybillNumber3, bool isValidExpected)
	{
		var subject = new M21_SupplementaryInBondInformation();
		//Required fields
		subject.CustomsEntryTypeCode = "aq";
		subject.LocationIdentifier = "U";
		subject.StandardCarrierAlphaCode = "OO";
		subject.BillOfLadingWaybillNumber = "A";
		//Test Parameters
		subject.StandardCarrierAlphaCode3 = standardCarrierAlphaCode3;
		subject.BillOfLadingWaybillNumber3 = billOfLadingWaybillNumber3;
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.StandardCarrierAlphaCode2) || !string.IsNullOrEmpty(subject.StandardCarrierAlphaCode2) || !string.IsNullOrEmpty(subject.BillOfLadingWaybillNumber2))
		{
			subject.StandardCarrierAlphaCode2 = "vB";
			subject.BillOfLadingWaybillNumber2 = "k";
		}
		if(!string.IsNullOrEmpty(subject.ReferenceIdentificationQualifier) || !string.IsNullOrEmpty(subject.ReferenceIdentificationQualifier) || !string.IsNullOrEmpty(subject.ReferenceIdentification))
		{
			subject.ReferenceIdentificationQualifier = "kb";
			subject.ReferenceIdentification = "H";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("kb", "H", true)]
	[InlineData("kb", "", false)]
	[InlineData("", "H", false)]
	public void Validation_AllAreRequiredReferenceIdentificationQualifier(string referenceIdentificationQualifier, string referenceIdentification, bool isValidExpected)
	{
		var subject = new M21_SupplementaryInBondInformation();
		//Required fields
		subject.CustomsEntryTypeCode = "aq";
		subject.LocationIdentifier = "U";
		subject.StandardCarrierAlphaCode = "OO";
		subject.BillOfLadingWaybillNumber = "A";
		//Test Parameters
		subject.ReferenceIdentificationQualifier = referenceIdentificationQualifier;
		subject.ReferenceIdentification = referenceIdentification;
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.StandardCarrierAlphaCode2) || !string.IsNullOrEmpty(subject.StandardCarrierAlphaCode2) || !string.IsNullOrEmpty(subject.BillOfLadingWaybillNumber2))
		{
			subject.StandardCarrierAlphaCode2 = "vB";
			subject.BillOfLadingWaybillNumber2 = "k";
		}
		if(!string.IsNullOrEmpty(subject.StandardCarrierAlphaCode3) || !string.IsNullOrEmpty(subject.StandardCarrierAlphaCode3) || !string.IsNullOrEmpty(subject.BillOfLadingWaybillNumber3))
		{
			subject.StandardCarrierAlphaCode3 = "qL";
			subject.BillOfLadingWaybillNumber3 = "d";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

}
