using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v5050;

namespace Eddy.x12.Tests.Models.v5050;

public class M21Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "M21*xL*U*Mh*p*Z*g*MO*U*wJ*N*rr*mW*2*kJ*M";

		var expected = new M21_SupplementaryInBondInformation()
		{
			CustomsEntryTypeCode = "xL",
			LocationIdentifier = "U",
			StandardCarrierAlphaCode = "Mh",
			BillOfLadingWaybillNumber = "p",
			MasterInBondTypeCode = "Z",
			InBondControlNumber = "g",
			StandardCarrierAlphaCode2 = "MO",
			BillOfLadingWaybillNumber2 = "U",
			StandardCarrierAlphaCode3 = "wJ",
			BillOfLadingWaybillNumber3 = "N",
			StandardCarrierAlphaCode4 = "rr",
			StandardCarrierAlphaCode5 = "mW",
			Quantity = 2,
			ReferenceIdentificationQualifier = "kJ",
			ReferenceIdentification = "M",
		};

		var actual = Map.MapObject<M21_SupplementaryInBondInformation>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("xL", true)]
	public void Validation_RequiredCustomsEntryTypeCode(string customsEntryTypeCode, bool isValidExpected)
	{
		var subject = new M21_SupplementaryInBondInformation();
		//Required fields
		subject.LocationIdentifier = "U";
		subject.StandardCarrierAlphaCode = "Mh";
		subject.BillOfLadingWaybillNumber = "p";
		subject.MasterInBondTypeCode = "Z";
		subject.InBondControlNumber = "g";
		//Test Parameters
		subject.CustomsEntryTypeCode = customsEntryTypeCode;
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.StandardCarrierAlphaCode2) || !string.IsNullOrEmpty(subject.StandardCarrierAlphaCode2) || !string.IsNullOrEmpty(subject.BillOfLadingWaybillNumber2))
		{
			subject.StandardCarrierAlphaCode2 = "MO";
			subject.BillOfLadingWaybillNumber2 = "U";
		}
		if(!string.IsNullOrEmpty(subject.StandardCarrierAlphaCode3) || !string.IsNullOrEmpty(subject.StandardCarrierAlphaCode3) || !string.IsNullOrEmpty(subject.BillOfLadingWaybillNumber3))
		{
			subject.StandardCarrierAlphaCode3 = "wJ";
			subject.BillOfLadingWaybillNumber3 = "N";
		}
		if(!string.IsNullOrEmpty(subject.ReferenceIdentificationQualifier) || !string.IsNullOrEmpty(subject.ReferenceIdentificationQualifier) || !string.IsNullOrEmpty(subject.ReferenceIdentification))
		{
			subject.ReferenceIdentificationQualifier = "kJ";
			subject.ReferenceIdentification = "M";
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
		subject.CustomsEntryTypeCode = "xL";
		subject.StandardCarrierAlphaCode = "Mh";
		subject.BillOfLadingWaybillNumber = "p";
		subject.MasterInBondTypeCode = "Z";
		subject.InBondControlNumber = "g";
		//Test Parameters
		subject.LocationIdentifier = locationIdentifier;
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.StandardCarrierAlphaCode2) || !string.IsNullOrEmpty(subject.StandardCarrierAlphaCode2) || !string.IsNullOrEmpty(subject.BillOfLadingWaybillNumber2))
		{
			subject.StandardCarrierAlphaCode2 = "MO";
			subject.BillOfLadingWaybillNumber2 = "U";
		}
		if(!string.IsNullOrEmpty(subject.StandardCarrierAlphaCode3) || !string.IsNullOrEmpty(subject.StandardCarrierAlphaCode3) || !string.IsNullOrEmpty(subject.BillOfLadingWaybillNumber3))
		{
			subject.StandardCarrierAlphaCode3 = "wJ";
			subject.BillOfLadingWaybillNumber3 = "N";
		}
		if(!string.IsNullOrEmpty(subject.ReferenceIdentificationQualifier) || !string.IsNullOrEmpty(subject.ReferenceIdentificationQualifier) || !string.IsNullOrEmpty(subject.ReferenceIdentification))
		{
			subject.ReferenceIdentificationQualifier = "kJ";
			subject.ReferenceIdentification = "M";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("Mh", true)]
	public void Validation_RequiredStandardCarrierAlphaCode(string standardCarrierAlphaCode, bool isValidExpected)
	{
		var subject = new M21_SupplementaryInBondInformation();
		//Required fields
		subject.CustomsEntryTypeCode = "xL";
		subject.LocationIdentifier = "U";
		subject.BillOfLadingWaybillNumber = "p";
		subject.MasterInBondTypeCode = "Z";
		subject.InBondControlNumber = "g";
		//Test Parameters
		subject.StandardCarrierAlphaCode = standardCarrierAlphaCode;
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.StandardCarrierAlphaCode2) || !string.IsNullOrEmpty(subject.StandardCarrierAlphaCode2) || !string.IsNullOrEmpty(subject.BillOfLadingWaybillNumber2))
		{
			subject.StandardCarrierAlphaCode2 = "MO";
			subject.BillOfLadingWaybillNumber2 = "U";
		}
		if(!string.IsNullOrEmpty(subject.StandardCarrierAlphaCode3) || !string.IsNullOrEmpty(subject.StandardCarrierAlphaCode3) || !string.IsNullOrEmpty(subject.BillOfLadingWaybillNumber3))
		{
			subject.StandardCarrierAlphaCode3 = "wJ";
			subject.BillOfLadingWaybillNumber3 = "N";
		}
		if(!string.IsNullOrEmpty(subject.ReferenceIdentificationQualifier) || !string.IsNullOrEmpty(subject.ReferenceIdentificationQualifier) || !string.IsNullOrEmpty(subject.ReferenceIdentification))
		{
			subject.ReferenceIdentificationQualifier = "kJ";
			subject.ReferenceIdentification = "M";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("p", true)]
	public void Validation_RequiredBillOfLadingWaybillNumber(string billOfLadingWaybillNumber, bool isValidExpected)
	{
		var subject = new M21_SupplementaryInBondInformation();
		//Required fields
		subject.CustomsEntryTypeCode = "xL";
		subject.LocationIdentifier = "U";
		subject.StandardCarrierAlphaCode = "Mh";
		subject.MasterInBondTypeCode = "Z";
		subject.InBondControlNumber = "g";
		//Test Parameters
		subject.BillOfLadingWaybillNumber = billOfLadingWaybillNumber;
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.StandardCarrierAlphaCode2) || !string.IsNullOrEmpty(subject.StandardCarrierAlphaCode2) || !string.IsNullOrEmpty(subject.BillOfLadingWaybillNumber2))
		{
			subject.StandardCarrierAlphaCode2 = "MO";
			subject.BillOfLadingWaybillNumber2 = "U";
		}
		if(!string.IsNullOrEmpty(subject.StandardCarrierAlphaCode3) || !string.IsNullOrEmpty(subject.StandardCarrierAlphaCode3) || !string.IsNullOrEmpty(subject.BillOfLadingWaybillNumber3))
		{
			subject.StandardCarrierAlphaCode3 = "wJ";
			subject.BillOfLadingWaybillNumber3 = "N";
		}
		if(!string.IsNullOrEmpty(subject.ReferenceIdentificationQualifier) || !string.IsNullOrEmpty(subject.ReferenceIdentificationQualifier) || !string.IsNullOrEmpty(subject.ReferenceIdentification))
		{
			subject.ReferenceIdentificationQualifier = "kJ";
			subject.ReferenceIdentification = "M";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("Z", true)]
	public void Validation_RequiredMasterInBondTypeCode(string masterInBondTypeCode, bool isValidExpected)
	{
		var subject = new M21_SupplementaryInBondInformation();
		//Required fields
		subject.CustomsEntryTypeCode = "xL";
		subject.LocationIdentifier = "U";
		subject.StandardCarrierAlphaCode = "Mh";
		subject.BillOfLadingWaybillNumber = "p";
		subject.InBondControlNumber = "g";
		//Test Parameters
		subject.MasterInBondTypeCode = masterInBondTypeCode;
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.StandardCarrierAlphaCode2) || !string.IsNullOrEmpty(subject.StandardCarrierAlphaCode2) || !string.IsNullOrEmpty(subject.BillOfLadingWaybillNumber2))
		{
			subject.StandardCarrierAlphaCode2 = "MO";
			subject.BillOfLadingWaybillNumber2 = "U";
		}
		if(!string.IsNullOrEmpty(subject.StandardCarrierAlphaCode3) || !string.IsNullOrEmpty(subject.StandardCarrierAlphaCode3) || !string.IsNullOrEmpty(subject.BillOfLadingWaybillNumber3))
		{
			subject.StandardCarrierAlphaCode3 = "wJ";
			subject.BillOfLadingWaybillNumber3 = "N";
		}
		if(!string.IsNullOrEmpty(subject.ReferenceIdentificationQualifier) || !string.IsNullOrEmpty(subject.ReferenceIdentificationQualifier) || !string.IsNullOrEmpty(subject.ReferenceIdentification))
		{
			subject.ReferenceIdentificationQualifier = "kJ";
			subject.ReferenceIdentification = "M";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("g", true)]
	public void Validation_RequiredInBondControlNumber(string inBondControlNumber, bool isValidExpected)
	{
		var subject = new M21_SupplementaryInBondInformation();
		//Required fields
		subject.CustomsEntryTypeCode = "xL";
		subject.LocationIdentifier = "U";
		subject.StandardCarrierAlphaCode = "Mh";
		subject.BillOfLadingWaybillNumber = "p";
		subject.MasterInBondTypeCode = "Z";
		//Test Parameters
		subject.InBondControlNumber = inBondControlNumber;
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.StandardCarrierAlphaCode2) || !string.IsNullOrEmpty(subject.StandardCarrierAlphaCode2) || !string.IsNullOrEmpty(subject.BillOfLadingWaybillNumber2))
		{
			subject.StandardCarrierAlphaCode2 = "MO";
			subject.BillOfLadingWaybillNumber2 = "U";
		}
		if(!string.IsNullOrEmpty(subject.StandardCarrierAlphaCode3) || !string.IsNullOrEmpty(subject.StandardCarrierAlphaCode3) || !string.IsNullOrEmpty(subject.BillOfLadingWaybillNumber3))
		{
			subject.StandardCarrierAlphaCode3 = "wJ";
			subject.BillOfLadingWaybillNumber3 = "N";
		}
		if(!string.IsNullOrEmpty(subject.ReferenceIdentificationQualifier) || !string.IsNullOrEmpty(subject.ReferenceIdentificationQualifier) || !string.IsNullOrEmpty(subject.ReferenceIdentification))
		{
			subject.ReferenceIdentificationQualifier = "kJ";
			subject.ReferenceIdentification = "M";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("MO", "U", true)]
	[InlineData("MO", "", false)]
	[InlineData("", "U", false)]
	public void Validation_AllAreRequiredStandardCarrierAlphaCode2(string standardCarrierAlphaCode2, string billOfLadingWaybillNumber2, bool isValidExpected)
	{
		var subject = new M21_SupplementaryInBondInformation();
		//Required fields
		subject.CustomsEntryTypeCode = "xL";
		subject.LocationIdentifier = "U";
		subject.StandardCarrierAlphaCode = "Mh";
		subject.BillOfLadingWaybillNumber = "p";
		subject.MasterInBondTypeCode = "Z";
		subject.InBondControlNumber = "g";
		//Test Parameters
		subject.StandardCarrierAlphaCode2 = standardCarrierAlphaCode2;
		subject.BillOfLadingWaybillNumber2 = billOfLadingWaybillNumber2;
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.StandardCarrierAlphaCode3) || !string.IsNullOrEmpty(subject.StandardCarrierAlphaCode3) || !string.IsNullOrEmpty(subject.BillOfLadingWaybillNumber3))
		{
			subject.StandardCarrierAlphaCode3 = "wJ";
			subject.BillOfLadingWaybillNumber3 = "N";
		}
		if(!string.IsNullOrEmpty(subject.ReferenceIdentificationQualifier) || !string.IsNullOrEmpty(subject.ReferenceIdentificationQualifier) || !string.IsNullOrEmpty(subject.ReferenceIdentification))
		{
			subject.ReferenceIdentificationQualifier = "kJ";
			subject.ReferenceIdentification = "M";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("wJ", "N", true)]
	[InlineData("wJ", "", false)]
	[InlineData("", "N", false)]
	public void Validation_AllAreRequiredStandardCarrierAlphaCode3(string standardCarrierAlphaCode3, string billOfLadingWaybillNumber3, bool isValidExpected)
	{
		var subject = new M21_SupplementaryInBondInformation();
		//Required fields
		subject.CustomsEntryTypeCode = "xL";
		subject.LocationIdentifier = "U";
		subject.StandardCarrierAlphaCode = "Mh";
		subject.BillOfLadingWaybillNumber = "p";
		subject.MasterInBondTypeCode = "Z";
		subject.InBondControlNumber = "g";
		//Test Parameters
		subject.StandardCarrierAlphaCode3 = standardCarrierAlphaCode3;
		subject.BillOfLadingWaybillNumber3 = billOfLadingWaybillNumber3;
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.StandardCarrierAlphaCode2) || !string.IsNullOrEmpty(subject.StandardCarrierAlphaCode2) || !string.IsNullOrEmpty(subject.BillOfLadingWaybillNumber2))
		{
			subject.StandardCarrierAlphaCode2 = "MO";
			subject.BillOfLadingWaybillNumber2 = "U";
		}
		if(!string.IsNullOrEmpty(subject.ReferenceIdentificationQualifier) || !string.IsNullOrEmpty(subject.ReferenceIdentificationQualifier) || !string.IsNullOrEmpty(subject.ReferenceIdentification))
		{
			subject.ReferenceIdentificationQualifier = "kJ";
			subject.ReferenceIdentification = "M";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("kJ", "M", true)]
	[InlineData("kJ", "", false)]
	[InlineData("", "M", false)]
	public void Validation_AllAreRequiredReferenceIdentificationQualifier(string referenceIdentificationQualifier, string referenceIdentification, bool isValidExpected)
	{
		var subject = new M21_SupplementaryInBondInformation();
		//Required fields
		subject.CustomsEntryTypeCode = "xL";
		subject.LocationIdentifier = "U";
		subject.StandardCarrierAlphaCode = "Mh";
		subject.BillOfLadingWaybillNumber = "p";
		subject.MasterInBondTypeCode = "Z";
		subject.InBondControlNumber = "g";
		//Test Parameters
		subject.ReferenceIdentificationQualifier = referenceIdentificationQualifier;
		subject.ReferenceIdentification = referenceIdentification;
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.StandardCarrierAlphaCode2) || !string.IsNullOrEmpty(subject.StandardCarrierAlphaCode2) || !string.IsNullOrEmpty(subject.BillOfLadingWaybillNumber2))
		{
			subject.StandardCarrierAlphaCode2 = "MO";
			subject.BillOfLadingWaybillNumber2 = "U";
		}
		if(!string.IsNullOrEmpty(subject.StandardCarrierAlphaCode3) || !string.IsNullOrEmpty(subject.StandardCarrierAlphaCode3) || !string.IsNullOrEmpty(subject.BillOfLadingWaybillNumber3))
		{
			subject.StandardCarrierAlphaCode3 = "wJ";
			subject.BillOfLadingWaybillNumber3 = "N";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

}
