using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3060;

namespace Eddy.x12.Tests.Models.v3060;

public class M21Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "M21*24*M*Lx*P*L*3*Bu*W*kk*J*Op*fD*7";

		var expected = new M21_SupplementaryInBondInformation()
		{
			CustomsEntryTypeCode = "24",
			LocationIdentifier = "M",
			StandardCarrierAlphaCode = "Lx",
			BillOfLadingWaybillNumber = "P",
			MasterInBondTypeCode = "L",
			InBondControlNumber = "3",
			StandardCarrierAlphaCode2 = "Bu",
			BillOfLadingWaybillNumber2 = "W",
			StandardCarrierAlphaCode3 = "kk",
			BillOfLadingWaybillNumber3 = "J",
			StandardCarrierAlphaCode4 = "Op",
			StandardCarrierAlphaCode5 = "fD",
			Quantity = 7,
		};

		var actual = Map.MapObject<M21_SupplementaryInBondInformation>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("24", true)]
	public void Validation_RequiredCustomsEntryTypeCode(string customsEntryTypeCode, bool isValidExpected)
	{
		var subject = new M21_SupplementaryInBondInformation();
		//Required fields
		subject.LocationIdentifier = "M";
		subject.StandardCarrierAlphaCode = "Lx";
		subject.BillOfLadingWaybillNumber = "P";
		//Test Parameters
		subject.CustomsEntryTypeCode = customsEntryTypeCode;
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.StandardCarrierAlphaCode2) || !string.IsNullOrEmpty(subject.StandardCarrierAlphaCode2) || !string.IsNullOrEmpty(subject.BillOfLadingWaybillNumber2))
		{
			subject.StandardCarrierAlphaCode2 = "Bu";
			subject.BillOfLadingWaybillNumber2 = "W";
		}
		if(!string.IsNullOrEmpty(subject.StandardCarrierAlphaCode3) || !string.IsNullOrEmpty(subject.StandardCarrierAlphaCode3) || !string.IsNullOrEmpty(subject.BillOfLadingWaybillNumber3))
		{
			subject.StandardCarrierAlphaCode3 = "kk";
			subject.BillOfLadingWaybillNumber3 = "J";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("M", true)]
	public void Validation_RequiredLocationIdentifier(string locationIdentifier, bool isValidExpected)
	{
		var subject = new M21_SupplementaryInBondInformation();
		//Required fields
		subject.CustomsEntryTypeCode = "24";
		subject.StandardCarrierAlphaCode = "Lx";
		subject.BillOfLadingWaybillNumber = "P";
		//Test Parameters
		subject.LocationIdentifier = locationIdentifier;
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.StandardCarrierAlphaCode2) || !string.IsNullOrEmpty(subject.StandardCarrierAlphaCode2) || !string.IsNullOrEmpty(subject.BillOfLadingWaybillNumber2))
		{
			subject.StandardCarrierAlphaCode2 = "Bu";
			subject.BillOfLadingWaybillNumber2 = "W";
		}
		if(!string.IsNullOrEmpty(subject.StandardCarrierAlphaCode3) || !string.IsNullOrEmpty(subject.StandardCarrierAlphaCode3) || !string.IsNullOrEmpty(subject.BillOfLadingWaybillNumber3))
		{
			subject.StandardCarrierAlphaCode3 = "kk";
			subject.BillOfLadingWaybillNumber3 = "J";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("Lx", true)]
	public void Validation_RequiredStandardCarrierAlphaCode(string standardCarrierAlphaCode, bool isValidExpected)
	{
		var subject = new M21_SupplementaryInBondInformation();
		//Required fields
		subject.CustomsEntryTypeCode = "24";
		subject.LocationIdentifier = "M";
		subject.BillOfLadingWaybillNumber = "P";
		//Test Parameters
		subject.StandardCarrierAlphaCode = standardCarrierAlphaCode;
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.StandardCarrierAlphaCode2) || !string.IsNullOrEmpty(subject.StandardCarrierAlphaCode2) || !string.IsNullOrEmpty(subject.BillOfLadingWaybillNumber2))
		{
			subject.StandardCarrierAlphaCode2 = "Bu";
			subject.BillOfLadingWaybillNumber2 = "W";
		}
		if(!string.IsNullOrEmpty(subject.StandardCarrierAlphaCode3) || !string.IsNullOrEmpty(subject.StandardCarrierAlphaCode3) || !string.IsNullOrEmpty(subject.BillOfLadingWaybillNumber3))
		{
			subject.StandardCarrierAlphaCode3 = "kk";
			subject.BillOfLadingWaybillNumber3 = "J";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("P", true)]
	public void Validation_RequiredBillOfLadingWaybillNumber(string billOfLadingWaybillNumber, bool isValidExpected)
	{
		var subject = new M21_SupplementaryInBondInformation();
		//Required fields
		subject.CustomsEntryTypeCode = "24";
		subject.LocationIdentifier = "M";
		subject.StandardCarrierAlphaCode = "Lx";
		//Test Parameters
		subject.BillOfLadingWaybillNumber = billOfLadingWaybillNumber;
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.StandardCarrierAlphaCode2) || !string.IsNullOrEmpty(subject.StandardCarrierAlphaCode2) || !string.IsNullOrEmpty(subject.BillOfLadingWaybillNumber2))
		{
			subject.StandardCarrierAlphaCode2 = "Bu";
			subject.BillOfLadingWaybillNumber2 = "W";
		}
		if(!string.IsNullOrEmpty(subject.StandardCarrierAlphaCode3) || !string.IsNullOrEmpty(subject.StandardCarrierAlphaCode3) || !string.IsNullOrEmpty(subject.BillOfLadingWaybillNumber3))
		{
			subject.StandardCarrierAlphaCode3 = "kk";
			subject.BillOfLadingWaybillNumber3 = "J";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("Bu", "W", true)]
	[InlineData("Bu", "", false)]
	[InlineData("", "W", false)]
	public void Validation_AllAreRequiredStandardCarrierAlphaCode2(string standardCarrierAlphaCode2, string billOfLadingWaybillNumber2, bool isValidExpected)
	{
		var subject = new M21_SupplementaryInBondInformation();
		//Required fields
		subject.CustomsEntryTypeCode = "24";
		subject.LocationIdentifier = "M";
		subject.StandardCarrierAlphaCode = "Lx";
		subject.BillOfLadingWaybillNumber = "P";
		//Test Parameters
		subject.StandardCarrierAlphaCode2 = standardCarrierAlphaCode2;
		subject.BillOfLadingWaybillNumber2 = billOfLadingWaybillNumber2;
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.StandardCarrierAlphaCode3) || !string.IsNullOrEmpty(subject.StandardCarrierAlphaCode3) || !string.IsNullOrEmpty(subject.BillOfLadingWaybillNumber3))
		{
			subject.StandardCarrierAlphaCode3 = "kk";
			subject.BillOfLadingWaybillNumber3 = "J";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("kk", "J", true)]
	[InlineData("kk", "", false)]
	[InlineData("", "J", false)]
	public void Validation_AllAreRequiredStandardCarrierAlphaCode3(string standardCarrierAlphaCode3, string billOfLadingWaybillNumber3, bool isValidExpected)
	{
		var subject = new M21_SupplementaryInBondInformation();
		//Required fields
		subject.CustomsEntryTypeCode = "24";
		subject.LocationIdentifier = "M";
		subject.StandardCarrierAlphaCode = "Lx";
		subject.BillOfLadingWaybillNumber = "P";
		//Test Parameters
		subject.StandardCarrierAlphaCode3 = standardCarrierAlphaCode3;
		subject.BillOfLadingWaybillNumber3 = billOfLadingWaybillNumber3;
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.StandardCarrierAlphaCode2) || !string.IsNullOrEmpty(subject.StandardCarrierAlphaCode2) || !string.IsNullOrEmpty(subject.BillOfLadingWaybillNumber2))
		{
			subject.StandardCarrierAlphaCode2 = "Bu";
			subject.BillOfLadingWaybillNumber2 = "W";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

}
