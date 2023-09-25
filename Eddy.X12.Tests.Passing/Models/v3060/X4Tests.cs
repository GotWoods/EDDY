using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3060;

namespace Eddy.x12.Tests.Models.v3060;

public class X4Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "X4*f*3*G7*J*JjNbO6*HkUy*Cy*s*iA*5b*S*z*i*N*DJ*A*J3*98";

		var expected = new X4_CustomsReleaseInformation()
		{
			BillOfLadingWaybillNumber = "f",
			Quantity = 3,
			CustomsEntryTypeCode = "G7",
			CustomsEntryNumber = "J",
			Date = "JjNbO6",
			Time = "HkUy",
			DispositionCode = "Cy",
			BillOfLadingWaybillNumber2 = "s",
			StandardCarrierAlphaCode = "iA",
			StandardCarrierAlphaCode2 = "5b",
			EquipmentInitial = "S",
			EquipmentNumber = "z",
			LocationIdentifier = "i",
			LocationIdentifier2 = "N",
			ReferenceIdentificationQualifier = "DJ",
			ReferenceIdentification = "A",
			TimeCode = "J3",
			Century = 98,
		};

		var actual = Map.MapObject<X4_CustomsReleaseInformation>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("G7", "J", true)]
	[InlineData("G7", "", false)]
	[InlineData("", "J", false)]
	public void Validation_AllAreRequiredCustomsEntryTypeCode(string customsEntryTypeCode, string customsEntryNumber, bool isValidExpected)
	{
		var subject = new X4_CustomsReleaseInformation();
		//Required fields
		subject.Date = "JjNbO6";
		subject.DispositionCode = "Cy";
		subject.StandardCarrierAlphaCode = "iA";
		//Test Parameters
		subject.CustomsEntryTypeCode = customsEntryTypeCode;
		subject.CustomsEntryNumber = customsEntryNumber;
		//At Least one
		subject.ReferenceIdentificationQualifier = "DJ";
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.BillOfLadingWaybillNumber2) || !string.IsNullOrEmpty(subject.BillOfLadingWaybillNumber2) || !string.IsNullOrEmpty(subject.StandardCarrierAlphaCode2))
		{
			subject.BillOfLadingWaybillNumber2 = "s";
			subject.StandardCarrierAlphaCode2 = "5b";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("JjNbO6", true)]
	public void Validation_RequiredDate(string date, bool isValidExpected)
	{
		var subject = new X4_CustomsReleaseInformation();
		//Required fields
		subject.DispositionCode = "Cy";
		subject.StandardCarrierAlphaCode = "iA";
		//Test Parameters
		subject.Date = date;
		//At Least one
		subject.ReferenceIdentificationQualifier = "DJ";
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.CustomsEntryTypeCode) || !string.IsNullOrEmpty(subject.CustomsEntryTypeCode) || !string.IsNullOrEmpty(subject.CustomsEntryNumber))
		{
			subject.CustomsEntryTypeCode = "G7";
			subject.CustomsEntryNumber = "J";
		}
		if(!string.IsNullOrEmpty(subject.BillOfLadingWaybillNumber2) || !string.IsNullOrEmpty(subject.BillOfLadingWaybillNumber2) || !string.IsNullOrEmpty(subject.StandardCarrierAlphaCode2))
		{
			subject.BillOfLadingWaybillNumber2 = "s";
			subject.StandardCarrierAlphaCode2 = "5b";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("Cy", true)]
	public void Validation_RequiredDispositionCode(string dispositionCode, bool isValidExpected)
	{
		var subject = new X4_CustomsReleaseInformation();
		//Required fields
		subject.Date = "JjNbO6";
		subject.StandardCarrierAlphaCode = "iA";
		//Test Parameters
		subject.DispositionCode = dispositionCode;
		//At Least one
		subject.ReferenceIdentificationQualifier = "DJ";
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.CustomsEntryTypeCode) || !string.IsNullOrEmpty(subject.CustomsEntryTypeCode) || !string.IsNullOrEmpty(subject.CustomsEntryNumber))
		{
			subject.CustomsEntryTypeCode = "G7";
			subject.CustomsEntryNumber = "J";
		}
		if(!string.IsNullOrEmpty(subject.BillOfLadingWaybillNumber2) || !string.IsNullOrEmpty(subject.BillOfLadingWaybillNumber2) || !string.IsNullOrEmpty(subject.StandardCarrierAlphaCode2))
		{
			subject.BillOfLadingWaybillNumber2 = "s";
			subject.StandardCarrierAlphaCode2 = "5b";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("s", "5b", true)]
	[InlineData("s", "", false)]
	[InlineData("", "5b", false)]
	public void Validation_AllAreRequiredBillOfLadingWaybillNumber2(string billOfLadingWaybillNumber2, string standardCarrierAlphaCode2, bool isValidExpected)
	{
		var subject = new X4_CustomsReleaseInformation();
		//Required fields
		subject.Date = "JjNbO6";
		subject.DispositionCode = "Cy";
		subject.StandardCarrierAlphaCode = "iA";
		//Test Parameters
		subject.BillOfLadingWaybillNumber2 = billOfLadingWaybillNumber2;
		subject.StandardCarrierAlphaCode2 = standardCarrierAlphaCode2;
		//At Least one
		subject.ReferenceIdentificationQualifier = "DJ";
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.CustomsEntryTypeCode) || !string.IsNullOrEmpty(subject.CustomsEntryTypeCode) || !string.IsNullOrEmpty(subject.CustomsEntryNumber))
		{
			subject.CustomsEntryTypeCode = "G7";
			subject.CustomsEntryNumber = "J";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("iA", true)]
	public void Validation_RequiredStandardCarrierAlphaCode(string standardCarrierAlphaCode, bool isValidExpected)
	{
		var subject = new X4_CustomsReleaseInformation();
		//Required fields
		subject.Date = "JjNbO6";
		subject.DispositionCode = "Cy";
		//Test Parameters
		subject.StandardCarrierAlphaCode = standardCarrierAlphaCode;
		//At Least one
		subject.ReferenceIdentificationQualifier = "DJ";
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.CustomsEntryTypeCode) || !string.IsNullOrEmpty(subject.CustomsEntryTypeCode) || !string.IsNullOrEmpty(subject.CustomsEntryNumber))
		{
			subject.CustomsEntryTypeCode = "G7";
			subject.CustomsEntryNumber = "J";
		}
		if(!string.IsNullOrEmpty(subject.BillOfLadingWaybillNumber2) || !string.IsNullOrEmpty(subject.BillOfLadingWaybillNumber2) || !string.IsNullOrEmpty(subject.StandardCarrierAlphaCode2))
		{
			subject.BillOfLadingWaybillNumber2 = "s";
			subject.StandardCarrierAlphaCode2 = "5b";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", "", false)]
	[InlineData("DJ", "A", true)]
	[InlineData("DJ", "", true)]
	[InlineData("", "A", true)]
	public void Validation_AtLeastOneReferenceIdentificationQualifier(string referenceIdentificationQualifier, string referenceIdentification, bool isValidExpected)
	{
		var subject = new X4_CustomsReleaseInformation();
		//Required fields
		subject.Date = "JjNbO6";
		subject.DispositionCode = "Cy";
		subject.StandardCarrierAlphaCode = "iA";
		//Test Parameters
		subject.ReferenceIdentificationQualifier = referenceIdentificationQualifier;
		subject.ReferenceIdentification = referenceIdentification;
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.CustomsEntryTypeCode) || !string.IsNullOrEmpty(subject.CustomsEntryTypeCode) || !string.IsNullOrEmpty(subject.CustomsEntryNumber))
		{
			subject.CustomsEntryTypeCode = "G7";
			subject.CustomsEntryNumber = "J";
		}
		if(!string.IsNullOrEmpty(subject.BillOfLadingWaybillNumber2) || !string.IsNullOrEmpty(subject.BillOfLadingWaybillNumber2) || !string.IsNullOrEmpty(subject.StandardCarrierAlphaCode2))
		{
			subject.BillOfLadingWaybillNumber2 = "s";
			subject.StandardCarrierAlphaCode2 = "5b";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.AtLeastOneIsRequired);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("J3", "HkUy", true)]
	[InlineData("J3", "", false)]
	[InlineData("", "HkUy", true)]
	public void Validation_ARequiresBTimeCode(string timeCode, string time, bool isValidExpected)
	{
		var subject = new X4_CustomsReleaseInformation();
		//Required fields
		subject.Date = "JjNbO6";
		subject.DispositionCode = "Cy";
		subject.StandardCarrierAlphaCode = "iA";
		//Test Parameters
		subject.TimeCode = timeCode;
		subject.Time = time;
		//At Least one
		subject.ReferenceIdentificationQualifier = "DJ";
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.CustomsEntryTypeCode) || !string.IsNullOrEmpty(subject.CustomsEntryTypeCode) || !string.IsNullOrEmpty(subject.CustomsEntryNumber))
		{
			subject.CustomsEntryTypeCode = "G7";
			subject.CustomsEntryNumber = "J";
		}
		if(!string.IsNullOrEmpty(subject.BillOfLadingWaybillNumber2) || !string.IsNullOrEmpty(subject.BillOfLadingWaybillNumber2) || !string.IsNullOrEmpty(subject.StandardCarrierAlphaCode2))
		{
			subject.BillOfLadingWaybillNumber2 = "s";
			subject.StandardCarrierAlphaCode2 = "5b";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
	}

}
