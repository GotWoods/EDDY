using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v5030;

namespace Eddy.x12.Tests.Models.v5030;

public class M21Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "M21*rH*e*lo*M*n*N*1p*S*M4*E*Gh*HW*8*I5*p";

		var expected = new M21_SupplementaryInBondInformation()
		{
			CustomsEntryTypeCode = "rH",
			LocationIdentifier = "e",
			StandardCarrierAlphaCode = "lo",
			BillOfLadingWaybillNumber = "M",
			MasterInBondTypeCode = "n",
			InBondControlNumber = "N",
			StandardCarrierAlphaCode2 = "1p",
			BillOfLadingWaybillNumber2 = "S",
			StandardCarrierAlphaCode3 = "M4",
			BillOfLadingWaybillNumber3 = "E",
			StandardCarrierAlphaCode4 = "Gh",
			StandardCarrierAlphaCode5 = "HW",
			Quantity = 8,
			ReferenceIdentificationQualifier = "I5",
			ReferenceIdentification = "p",
		};

		var actual = Map.MapObject<M21_SupplementaryInBondInformation>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("rH", true)]
	public void Validation_RequiredCustomsEntryTypeCode(string customsEntryTypeCode, bool isValidExpected)
	{
		var subject = new M21_SupplementaryInBondInformation();
		//Required fields
		subject.LocationIdentifier = "e";
		subject.StandardCarrierAlphaCode = "lo";
		subject.BillOfLadingWaybillNumber = "M";
		subject.MasterInBondTypeCode = "n";
		subject.InBondControlNumber = "N";
		//Test Parameters
		subject.CustomsEntryTypeCode = customsEntryTypeCode;
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.StandardCarrierAlphaCode2) || !string.IsNullOrEmpty(subject.StandardCarrierAlphaCode2) || !string.IsNullOrEmpty(subject.BillOfLadingWaybillNumber2))
		{
			subject.StandardCarrierAlphaCode2 = "1p";
			subject.BillOfLadingWaybillNumber2 = "S";
		}
		if(!string.IsNullOrEmpty(subject.StandardCarrierAlphaCode3) || !string.IsNullOrEmpty(subject.StandardCarrierAlphaCode3) || !string.IsNullOrEmpty(subject.BillOfLadingWaybillNumber3))
		{
			subject.StandardCarrierAlphaCode3 = "M4";
			subject.BillOfLadingWaybillNumber3 = "E";
		}
		if(!string.IsNullOrEmpty(subject.ReferenceIdentificationQualifier) || !string.IsNullOrEmpty(subject.ReferenceIdentificationQualifier) || !string.IsNullOrEmpty(subject.ReferenceIdentification))
		{
			subject.ReferenceIdentificationQualifier = "I5";
			subject.ReferenceIdentification = "p";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("e", true)]
	public void Validation_RequiredLocationIdentifier(string locationIdentifier, bool isValidExpected)
	{
		var subject = new M21_SupplementaryInBondInformation();
		//Required fields
		subject.CustomsEntryTypeCode = "rH";
		subject.StandardCarrierAlphaCode = "lo";
		subject.BillOfLadingWaybillNumber = "M";
		subject.MasterInBondTypeCode = "n";
		subject.InBondControlNumber = "N";
		//Test Parameters
		subject.LocationIdentifier = locationIdentifier;
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.StandardCarrierAlphaCode2) || !string.IsNullOrEmpty(subject.StandardCarrierAlphaCode2) || !string.IsNullOrEmpty(subject.BillOfLadingWaybillNumber2))
		{
			subject.StandardCarrierAlphaCode2 = "1p";
			subject.BillOfLadingWaybillNumber2 = "S";
		}
		if(!string.IsNullOrEmpty(subject.StandardCarrierAlphaCode3) || !string.IsNullOrEmpty(subject.StandardCarrierAlphaCode3) || !string.IsNullOrEmpty(subject.BillOfLadingWaybillNumber3))
		{
			subject.StandardCarrierAlphaCode3 = "M4";
			subject.BillOfLadingWaybillNumber3 = "E";
		}
		if(!string.IsNullOrEmpty(subject.ReferenceIdentificationQualifier) || !string.IsNullOrEmpty(subject.ReferenceIdentificationQualifier) || !string.IsNullOrEmpty(subject.ReferenceIdentification))
		{
			subject.ReferenceIdentificationQualifier = "I5";
			subject.ReferenceIdentification = "p";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("lo", true)]
	public void Validation_RequiredStandardCarrierAlphaCode(string standardCarrierAlphaCode, bool isValidExpected)
	{
		var subject = new M21_SupplementaryInBondInformation();
		//Required fields
		subject.CustomsEntryTypeCode = "rH";
		subject.LocationIdentifier = "e";
		subject.BillOfLadingWaybillNumber = "M";
		subject.MasterInBondTypeCode = "n";
		subject.InBondControlNumber = "N";
		//Test Parameters
		subject.StandardCarrierAlphaCode = standardCarrierAlphaCode;
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.StandardCarrierAlphaCode2) || !string.IsNullOrEmpty(subject.StandardCarrierAlphaCode2) || !string.IsNullOrEmpty(subject.BillOfLadingWaybillNumber2))
		{
			subject.StandardCarrierAlphaCode2 = "1p";
			subject.BillOfLadingWaybillNumber2 = "S";
		}
		if(!string.IsNullOrEmpty(subject.StandardCarrierAlphaCode3) || !string.IsNullOrEmpty(subject.StandardCarrierAlphaCode3) || !string.IsNullOrEmpty(subject.BillOfLadingWaybillNumber3))
		{
			subject.StandardCarrierAlphaCode3 = "M4";
			subject.BillOfLadingWaybillNumber3 = "E";
		}
		if(!string.IsNullOrEmpty(subject.ReferenceIdentificationQualifier) || !string.IsNullOrEmpty(subject.ReferenceIdentificationQualifier) || !string.IsNullOrEmpty(subject.ReferenceIdentification))
		{
			subject.ReferenceIdentificationQualifier = "I5";
			subject.ReferenceIdentification = "p";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("M", true)]
	public void Validation_RequiredBillOfLadingWaybillNumber(string billOfLadingWaybillNumber, bool isValidExpected)
	{
		var subject = new M21_SupplementaryInBondInformation();
		//Required fields
		subject.CustomsEntryTypeCode = "rH";
		subject.LocationIdentifier = "e";
		subject.StandardCarrierAlphaCode = "lo";
		subject.MasterInBondTypeCode = "n";
		subject.InBondControlNumber = "N";
		//Test Parameters
		subject.BillOfLadingWaybillNumber = billOfLadingWaybillNumber;
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.StandardCarrierAlphaCode2) || !string.IsNullOrEmpty(subject.StandardCarrierAlphaCode2) || !string.IsNullOrEmpty(subject.BillOfLadingWaybillNumber2))
		{
			subject.StandardCarrierAlphaCode2 = "1p";
			subject.BillOfLadingWaybillNumber2 = "S";
		}
		if(!string.IsNullOrEmpty(subject.StandardCarrierAlphaCode3) || !string.IsNullOrEmpty(subject.StandardCarrierAlphaCode3) || !string.IsNullOrEmpty(subject.BillOfLadingWaybillNumber3))
		{
			subject.StandardCarrierAlphaCode3 = "M4";
			subject.BillOfLadingWaybillNumber3 = "E";
		}
		if(!string.IsNullOrEmpty(subject.ReferenceIdentificationQualifier) || !string.IsNullOrEmpty(subject.ReferenceIdentificationQualifier) || !string.IsNullOrEmpty(subject.ReferenceIdentification))
		{
			subject.ReferenceIdentificationQualifier = "I5";
			subject.ReferenceIdentification = "p";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("n", true)]
	public void Validation_RequiredMasterInBondTypeCode(string masterInBondTypeCode, bool isValidExpected)
	{
		var subject = new M21_SupplementaryInBondInformation();
		//Required fields
		subject.CustomsEntryTypeCode = "rH";
		subject.LocationIdentifier = "e";
		subject.StandardCarrierAlphaCode = "lo";
		subject.BillOfLadingWaybillNumber = "M";
		subject.InBondControlNumber = "N";
		//Test Parameters
		subject.MasterInBondTypeCode = masterInBondTypeCode;
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.StandardCarrierAlphaCode2) || !string.IsNullOrEmpty(subject.StandardCarrierAlphaCode2) || !string.IsNullOrEmpty(subject.BillOfLadingWaybillNumber2))
		{
			subject.StandardCarrierAlphaCode2 = "1p";
			subject.BillOfLadingWaybillNumber2 = "S";
		}
		if(!string.IsNullOrEmpty(subject.StandardCarrierAlphaCode3) || !string.IsNullOrEmpty(subject.StandardCarrierAlphaCode3) || !string.IsNullOrEmpty(subject.BillOfLadingWaybillNumber3))
		{
			subject.StandardCarrierAlphaCode3 = "M4";
			subject.BillOfLadingWaybillNumber3 = "E";
		}
		if(!string.IsNullOrEmpty(subject.ReferenceIdentificationQualifier) || !string.IsNullOrEmpty(subject.ReferenceIdentificationQualifier) || !string.IsNullOrEmpty(subject.ReferenceIdentification))
		{
			subject.ReferenceIdentificationQualifier = "I5";
			subject.ReferenceIdentification = "p";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("N", true)]
	public void Validation_RequiredInBondControlNumber(string inBondControlNumber, bool isValidExpected)
	{
		var subject = new M21_SupplementaryInBondInformation();
		//Required fields
		subject.CustomsEntryTypeCode = "rH";
		subject.LocationIdentifier = "e";
		subject.StandardCarrierAlphaCode = "lo";
		subject.BillOfLadingWaybillNumber = "M";
		subject.MasterInBondTypeCode = "n";
		//Test Parameters
		subject.InBondControlNumber = inBondControlNumber;
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.StandardCarrierAlphaCode2) || !string.IsNullOrEmpty(subject.StandardCarrierAlphaCode2) || !string.IsNullOrEmpty(subject.BillOfLadingWaybillNumber2))
		{
			subject.StandardCarrierAlphaCode2 = "1p";
			subject.BillOfLadingWaybillNumber2 = "S";
		}
		if(!string.IsNullOrEmpty(subject.StandardCarrierAlphaCode3) || !string.IsNullOrEmpty(subject.StandardCarrierAlphaCode3) || !string.IsNullOrEmpty(subject.BillOfLadingWaybillNumber3))
		{
			subject.StandardCarrierAlphaCode3 = "M4";
			subject.BillOfLadingWaybillNumber3 = "E";
		}
		if(!string.IsNullOrEmpty(subject.ReferenceIdentificationQualifier) || !string.IsNullOrEmpty(subject.ReferenceIdentificationQualifier) || !string.IsNullOrEmpty(subject.ReferenceIdentification))
		{
			subject.ReferenceIdentificationQualifier = "I5";
			subject.ReferenceIdentification = "p";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("1p", "S", true)]
	[InlineData("1p", "", false)]
	[InlineData("", "S", false)]
	public void Validation_AllAreRequiredStandardCarrierAlphaCode2(string standardCarrierAlphaCode2, string billOfLadingWaybillNumber2, bool isValidExpected)
	{
		var subject = new M21_SupplementaryInBondInformation();
		//Required fields
		subject.CustomsEntryTypeCode = "rH";
		subject.LocationIdentifier = "e";
		subject.StandardCarrierAlphaCode = "lo";
		subject.BillOfLadingWaybillNumber = "M";
		subject.MasterInBondTypeCode = "n";
		subject.InBondControlNumber = "N";
		//Test Parameters
		subject.StandardCarrierAlphaCode2 = standardCarrierAlphaCode2;
		subject.BillOfLadingWaybillNumber2 = billOfLadingWaybillNumber2;
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.StandardCarrierAlphaCode3) || !string.IsNullOrEmpty(subject.StandardCarrierAlphaCode3) || !string.IsNullOrEmpty(subject.BillOfLadingWaybillNumber3))
		{
			subject.StandardCarrierAlphaCode3 = "M4";
			subject.BillOfLadingWaybillNumber3 = "E";
		}
		if(!string.IsNullOrEmpty(subject.ReferenceIdentificationQualifier) || !string.IsNullOrEmpty(subject.ReferenceIdentificationQualifier) || !string.IsNullOrEmpty(subject.ReferenceIdentification))
		{
			subject.ReferenceIdentificationQualifier = "I5";
			subject.ReferenceIdentification = "p";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("M4", "E", true)]
	[InlineData("M4", "", false)]
	[InlineData("", "E", false)]
	public void Validation_AllAreRequiredStandardCarrierAlphaCode3(string standardCarrierAlphaCode3, string billOfLadingWaybillNumber3, bool isValidExpected)
	{
		var subject = new M21_SupplementaryInBondInformation();
		//Required fields
		subject.CustomsEntryTypeCode = "rH";
		subject.LocationIdentifier = "e";
		subject.StandardCarrierAlphaCode = "lo";
		subject.BillOfLadingWaybillNumber = "M";
		subject.MasterInBondTypeCode = "n";
		subject.InBondControlNumber = "N";
		//Test Parameters
		subject.StandardCarrierAlphaCode3 = standardCarrierAlphaCode3;
		subject.BillOfLadingWaybillNumber3 = billOfLadingWaybillNumber3;
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.StandardCarrierAlphaCode2) || !string.IsNullOrEmpty(subject.StandardCarrierAlphaCode2) || !string.IsNullOrEmpty(subject.BillOfLadingWaybillNumber2))
		{
			subject.StandardCarrierAlphaCode2 = "1p";
			subject.BillOfLadingWaybillNumber2 = "S";
		}
		if(!string.IsNullOrEmpty(subject.ReferenceIdentificationQualifier) || !string.IsNullOrEmpty(subject.ReferenceIdentificationQualifier) || !string.IsNullOrEmpty(subject.ReferenceIdentification))
		{
			subject.ReferenceIdentificationQualifier = "I5";
			subject.ReferenceIdentification = "p";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("I5", "p", true)]
	[InlineData("I5", "", false)]
	[InlineData("", "p", false)]
	public void Validation_AllAreRequiredReferenceIdentificationQualifier(string referenceIdentificationQualifier, string referenceIdentification, bool isValidExpected)
	{
		var subject = new M21_SupplementaryInBondInformation();
		//Required fields
		subject.CustomsEntryTypeCode = "rH";
		subject.LocationIdentifier = "e";
		subject.StandardCarrierAlphaCode = "lo";
		subject.BillOfLadingWaybillNumber = "M";
		subject.MasterInBondTypeCode = "n";
		subject.InBondControlNumber = "N";
		//Test Parameters
		subject.ReferenceIdentificationQualifier = referenceIdentificationQualifier;
		subject.ReferenceIdentification = referenceIdentification;
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.StandardCarrierAlphaCode2) || !string.IsNullOrEmpty(subject.StandardCarrierAlphaCode2) || !string.IsNullOrEmpty(subject.BillOfLadingWaybillNumber2))
		{
			subject.StandardCarrierAlphaCode2 = "1p";
			subject.BillOfLadingWaybillNumber2 = "S";
		}
		if(!string.IsNullOrEmpty(subject.StandardCarrierAlphaCode3) || !string.IsNullOrEmpty(subject.StandardCarrierAlphaCode3) || !string.IsNullOrEmpty(subject.BillOfLadingWaybillNumber3))
		{
			subject.StandardCarrierAlphaCode3 = "M4";
			subject.BillOfLadingWaybillNumber3 = "E";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

}
