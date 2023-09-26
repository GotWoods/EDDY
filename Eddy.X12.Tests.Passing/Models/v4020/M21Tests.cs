using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v4020;

namespace Eddy.x12.Tests.Models.v4020;

public class M21Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "M21*OX*a*OY*l*H*Q*lV*T*oI*g*xN*ot*4";

		var expected = new M21_SupplementaryInBondInformation()
		{
			CustomsEntryTypeCode = "OX",
			LocationIdentifier = "a",
			StandardCarrierAlphaCode = "OY",
			BillOfLadingWaybillNumber = "l",
			MasterInBondTypeCode = "H",
			InBondControlNumber = "Q",
			StandardCarrierAlphaCode2 = "lV",
			BillOfLadingWaybillNumber2 = "T",
			StandardCarrierAlphaCode3 = "oI",
			BillOfLadingWaybillNumber3 = "g",
			StandardCarrierAlphaCode4 = "xN",
			StandardCarrierAlphaCode5 = "ot",
			Quantity = 4,
		};

		var actual = Map.MapObject<M21_SupplementaryInBondInformation>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("OX", true)]
	public void Validation_RequiredCustomsEntryTypeCode(string customsEntryTypeCode, bool isValidExpected)
	{
		var subject = new M21_SupplementaryInBondInformation();
		//Required fields
		subject.LocationIdentifier = "a";
		subject.StandardCarrierAlphaCode = "OY";
		subject.BillOfLadingWaybillNumber = "l";
		//Test Parameters
		subject.CustomsEntryTypeCode = customsEntryTypeCode;
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.StandardCarrierAlphaCode2) || !string.IsNullOrEmpty(subject.StandardCarrierAlphaCode2) || !string.IsNullOrEmpty(subject.BillOfLadingWaybillNumber2))
		{
			subject.StandardCarrierAlphaCode2 = "lV";
			subject.BillOfLadingWaybillNumber2 = "T";
		}
		if(!string.IsNullOrEmpty(subject.StandardCarrierAlphaCode3) || !string.IsNullOrEmpty(subject.StandardCarrierAlphaCode3) || !string.IsNullOrEmpty(subject.BillOfLadingWaybillNumber3))
		{
			subject.StandardCarrierAlphaCode3 = "oI";
			subject.BillOfLadingWaybillNumber3 = "g";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("a", true)]
	public void Validation_RequiredLocationIdentifier(string locationIdentifier, bool isValidExpected)
	{
		var subject = new M21_SupplementaryInBondInformation();
		//Required fields
		subject.CustomsEntryTypeCode = "OX";
		subject.StandardCarrierAlphaCode = "OY";
		subject.BillOfLadingWaybillNumber = "l";
		//Test Parameters
		subject.LocationIdentifier = locationIdentifier;
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.StandardCarrierAlphaCode2) || !string.IsNullOrEmpty(subject.StandardCarrierAlphaCode2) || !string.IsNullOrEmpty(subject.BillOfLadingWaybillNumber2))
		{
			subject.StandardCarrierAlphaCode2 = "lV";
			subject.BillOfLadingWaybillNumber2 = "T";
		}
		if(!string.IsNullOrEmpty(subject.StandardCarrierAlphaCode3) || !string.IsNullOrEmpty(subject.StandardCarrierAlphaCode3) || !string.IsNullOrEmpty(subject.BillOfLadingWaybillNumber3))
		{
			subject.StandardCarrierAlphaCode3 = "oI";
			subject.BillOfLadingWaybillNumber3 = "g";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("OY", true)]
	public void Validation_RequiredStandardCarrierAlphaCode(string standardCarrierAlphaCode, bool isValidExpected)
	{
		var subject = new M21_SupplementaryInBondInformation();
		//Required fields
		subject.CustomsEntryTypeCode = "OX";
		subject.LocationIdentifier = "a";
		subject.BillOfLadingWaybillNumber = "l";
		//Test Parameters
		subject.StandardCarrierAlphaCode = standardCarrierAlphaCode;
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.StandardCarrierAlphaCode2) || !string.IsNullOrEmpty(subject.StandardCarrierAlphaCode2) || !string.IsNullOrEmpty(subject.BillOfLadingWaybillNumber2))
		{
			subject.StandardCarrierAlphaCode2 = "lV";
			subject.BillOfLadingWaybillNumber2 = "T";
		}
		if(!string.IsNullOrEmpty(subject.StandardCarrierAlphaCode3) || !string.IsNullOrEmpty(subject.StandardCarrierAlphaCode3) || !string.IsNullOrEmpty(subject.BillOfLadingWaybillNumber3))
		{
			subject.StandardCarrierAlphaCode3 = "oI";
			subject.BillOfLadingWaybillNumber3 = "g";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("l", true)]
	public void Validation_RequiredBillOfLadingWaybillNumber(string billOfLadingWaybillNumber, bool isValidExpected)
	{
		var subject = new M21_SupplementaryInBondInformation();
		//Required fields
		subject.CustomsEntryTypeCode = "OX";
		subject.LocationIdentifier = "a";
		subject.StandardCarrierAlphaCode = "OY";
		//Test Parameters
		subject.BillOfLadingWaybillNumber = billOfLadingWaybillNumber;
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.StandardCarrierAlphaCode2) || !string.IsNullOrEmpty(subject.StandardCarrierAlphaCode2) || !string.IsNullOrEmpty(subject.BillOfLadingWaybillNumber2))
		{
			subject.StandardCarrierAlphaCode2 = "lV";
			subject.BillOfLadingWaybillNumber2 = "T";
		}
		if(!string.IsNullOrEmpty(subject.StandardCarrierAlphaCode3) || !string.IsNullOrEmpty(subject.StandardCarrierAlphaCode3) || !string.IsNullOrEmpty(subject.BillOfLadingWaybillNumber3))
		{
			subject.StandardCarrierAlphaCode3 = "oI";
			subject.BillOfLadingWaybillNumber3 = "g";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("lV", "T", true)]
	[InlineData("lV", "", false)]
	[InlineData("", "T", false)]
	public void Validation_AllAreRequiredStandardCarrierAlphaCode2(string standardCarrierAlphaCode2, string billOfLadingWaybillNumber2, bool isValidExpected)
	{
		var subject = new M21_SupplementaryInBondInformation();
		//Required fields
		subject.CustomsEntryTypeCode = "OX";
		subject.LocationIdentifier = "a";
		subject.StandardCarrierAlphaCode = "OY";
		subject.BillOfLadingWaybillNumber = "l";
		//Test Parameters
		subject.StandardCarrierAlphaCode2 = standardCarrierAlphaCode2;
		subject.BillOfLadingWaybillNumber2 = billOfLadingWaybillNumber2;
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.StandardCarrierAlphaCode3) || !string.IsNullOrEmpty(subject.StandardCarrierAlphaCode3) || !string.IsNullOrEmpty(subject.BillOfLadingWaybillNumber3))
		{
			subject.StandardCarrierAlphaCode3 = "oI";
			subject.BillOfLadingWaybillNumber3 = "g";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("oI", "g", true)]
	[InlineData("oI", "", false)]
	[InlineData("", "g", false)]
	public void Validation_AllAreRequiredStandardCarrierAlphaCode3(string standardCarrierAlphaCode3, string billOfLadingWaybillNumber3, bool isValidExpected)
	{
		var subject = new M21_SupplementaryInBondInformation();
		//Required fields
		subject.CustomsEntryTypeCode = "OX";
		subject.LocationIdentifier = "a";
		subject.StandardCarrierAlphaCode = "OY";
		subject.BillOfLadingWaybillNumber = "l";
		//Test Parameters
		subject.StandardCarrierAlphaCode3 = standardCarrierAlphaCode3;
		subject.BillOfLadingWaybillNumber3 = billOfLadingWaybillNumber3;
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.StandardCarrierAlphaCode2) || !string.IsNullOrEmpty(subject.StandardCarrierAlphaCode2) || !string.IsNullOrEmpty(subject.BillOfLadingWaybillNumber2))
		{
			subject.StandardCarrierAlphaCode2 = "lV";
			subject.BillOfLadingWaybillNumber2 = "T";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

}
