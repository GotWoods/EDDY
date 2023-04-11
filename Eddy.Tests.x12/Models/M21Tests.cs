using Eddy.Core.Validation;
using Eddy.x12.Mapping;
using Eddy.x12.Models;

namespace Eddy.Tests.x12.Models;

public class M21Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "M21*1x*L*V2*X*b*b*so*7*AA*Q*uR*0k*1*NP*m";

		var expected = new M21_SupplementaryInBondInformation()
		{
			CustomsEntryTypeCode = "1x",
			LocationIdentifier = "L",
			StandardCarrierAlphaCode = "V2",
			BillOfLadingWaybillNumber = "X",
			MasterInBondTypeCode = "b",
			InBondControlNumber = "b",
			StandardCarrierAlphaCode2 = "so",
			BillOfLadingWaybillNumber2 = "7",
			StandardCarrierAlphaCode3 = "AA",
			BillOfLadingWaybillNumber3 = "Q",
			StandardCarrierAlphaCode4 = "uR",
			StandardCarrierAlphaCode5 = "0k",
			Quantity = 1,
			ReferenceIdentificationQualifier = "NP",
			ReferenceIdentification = "m",
		};

		var actual = Map.MapObject<M21_SupplementaryInBondInformation>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("1x", true)]
	public void Validation_RequiredCustomsEntryTypeCode(string customsEntryTypeCode, bool isValidExpected)
	{
		var subject = new M21_SupplementaryInBondInformation();
		subject.LocationIdentifier = "L";
		subject.StandardCarrierAlphaCode = "V2";
		subject.BillOfLadingWaybillNumber = "X";
		subject.MasterInBondTypeCode = "b";
		subject.InBondControlNumber = "b";
		subject.CustomsEntryTypeCode = customsEntryTypeCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("L", true)]
	public void Validation_RequiredLocationIdentifier(string locationIdentifier, bool isValidExpected)
	{
		var subject = new M21_SupplementaryInBondInformation();
		subject.CustomsEntryTypeCode = "1x";
		subject.StandardCarrierAlphaCode = "V2";
		subject.BillOfLadingWaybillNumber = "X";
		subject.MasterInBondTypeCode = "b";
		subject.InBondControlNumber = "b";
		subject.LocationIdentifier = locationIdentifier;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("V2", true)]
	public void Validation_RequiredStandardCarrierAlphaCode(string standardCarrierAlphaCode, bool isValidExpected)
	{
		var subject = new M21_SupplementaryInBondInformation();
		subject.CustomsEntryTypeCode = "1x";
		subject.LocationIdentifier = "L";
		subject.BillOfLadingWaybillNumber = "X";
		subject.MasterInBondTypeCode = "b";
		subject.InBondControlNumber = "b";
		subject.StandardCarrierAlphaCode = standardCarrierAlphaCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("X", true)]
	public void Validation_RequiredBillOfLadingWaybillNumber(string billOfLadingWaybillNumber, bool isValidExpected)
	{
		var subject = new M21_SupplementaryInBondInformation();
		subject.CustomsEntryTypeCode = "1x";
		subject.LocationIdentifier = "L";
		subject.StandardCarrierAlphaCode = "V2";
		subject.MasterInBondTypeCode = "b";
		subject.InBondControlNumber = "b";
		subject.BillOfLadingWaybillNumber = billOfLadingWaybillNumber;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("b", true)]
	public void Validation_RequiredMasterInBondTypeCode(string masterInBondTypeCode, bool isValidExpected)
	{
		var subject = new M21_SupplementaryInBondInformation();
		subject.CustomsEntryTypeCode = "1x";
		subject.LocationIdentifier = "L";
		subject.StandardCarrierAlphaCode = "V2";
		subject.BillOfLadingWaybillNumber = "X";
		subject.InBondControlNumber = "b";
		subject.MasterInBondTypeCode = masterInBondTypeCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("b", true)]
	public void Validation_RequiredInBondControlNumber(string inBondControlNumber, bool isValidExpected)
	{
		var subject = new M21_SupplementaryInBondInformation();
		subject.CustomsEntryTypeCode = "1x";
		subject.LocationIdentifier = "L";
		subject.StandardCarrierAlphaCode = "V2";
		subject.BillOfLadingWaybillNumber = "X";
		subject.MasterInBondTypeCode = "b";
		subject.InBondControlNumber = inBondControlNumber;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("","", true)]
	[InlineData("so", "7", true)]
	[InlineData("", "7", false)]
	[InlineData("so", "", false)]
	public void Validation_AllAreRequiredStandardCarrierAlphaCode2(string standardCarrierAlphaCode2, string billOfLadingWaybillNumber2, bool isValidExpected)
	{
		var subject = new M21_SupplementaryInBondInformation();
		subject.CustomsEntryTypeCode = "1x";
		subject.LocationIdentifier = "L";
		subject.StandardCarrierAlphaCode = "V2";
		subject.BillOfLadingWaybillNumber = "X";
		subject.MasterInBondTypeCode = "b";
		subject.InBondControlNumber = "b";
		subject.StandardCarrierAlphaCode2 = standardCarrierAlphaCode2;
		subject.BillOfLadingWaybillNumber2 = billOfLadingWaybillNumber2;

		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

	[Theory]
	[InlineData("","", true)]
	[InlineData("AA", "Q", true)]
	[InlineData("", "Q", false)]
	[InlineData("AA", "", false)]
	public void Validation_AllAreRequiredStandardCarrierAlphaCode3(string standardCarrierAlphaCode3, string billOfLadingWaybillNumber3, bool isValidExpected)
	{
		var subject = new M21_SupplementaryInBondInformation();
		subject.CustomsEntryTypeCode = "1x";
		subject.LocationIdentifier = "L";
		subject.StandardCarrierAlphaCode = "V2";
		subject.BillOfLadingWaybillNumber = "X";
		subject.MasterInBondTypeCode = "b";
		subject.InBondControlNumber = "b";
		subject.StandardCarrierAlphaCode3 = standardCarrierAlphaCode3;
		subject.BillOfLadingWaybillNumber3 = billOfLadingWaybillNumber3;

		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

	[Theory]
	[InlineData("","", true)]
	[InlineData("NP", "m", true)]
	[InlineData("", "m", false)]
	[InlineData("NP", "", false)]
	public void Validation_AllAreRequiredReferenceIdentificationQualifier(string referenceIdentificationQualifier, string referenceIdentification, bool isValidExpected)
	{
		var subject = new M21_SupplementaryInBondInformation();
		subject.CustomsEntryTypeCode = "1x";
		subject.LocationIdentifier = "L";
		subject.StandardCarrierAlphaCode = "V2";
		subject.BillOfLadingWaybillNumber = "X";
		subject.MasterInBondTypeCode = "b";
		subject.InBondControlNumber = "b";
		subject.ReferenceIdentificationQualifier = referenceIdentificationQualifier;
		subject.ReferenceIdentification = referenceIdentification;

		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

}
