using Eddy.Core.Validation;
using Eddy.x12.Mapping;
using Eddy.x12.Models;

namespace Eddy.Tests.x12.Models;

public class X4Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "X4*3*4*Uu*v*EfR8iors*bUle*jk*P*5y*IL*1*z*Z*6*Pn*Z*P0*z*t*r";

		var expected = new X4_CustomsReleaseInformation()
		{
			BillOfLadingWaybillNumber = "3",
			Quantity = 4,
			CustomsEntryTypeCode = "Uu",
			CustomsEntryNumber = "v",
			Date = "EfR8iors",
			Time = "bUle",
			BillOfLadingDispositionCode = "jk",
			BillOfLadingWaybillNumber2 = "P",
			StandardCarrierAlphaCode = "5y",
			StandardCarrierAlphaCode2 = "IL",
			EquipmentInitial = "1",
			EquipmentNumber = "z",
			LocationIdentifier = "Z",
			LocationIdentifier2 = "6",
			ReferenceIdentificationQualifier = "Pn",
			ReferenceIdentification = "Z",
			TimeCode = "P0",
			LocationIdentifier3 = "z",
			LocationIdentifier4 = "t",
			YesNoConditionOrResponseCode = "r",
		};

		var actual = Map.MapObject<X4_CustomsReleaseInformation>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("","", true)]
	[InlineData("Uu", "v", true)]
	[InlineData("", "v", false)]
	[InlineData("Uu", "", false)]
	public void Validation_AllAreRequiredCustomsEntryTypeCode(string customsEntryTypeCode, string customsEntryNumber, bool isValidExpected)
	{
		var subject = new X4_CustomsReleaseInformation();
		subject.Date = "EfR8iors";
		subject.BillOfLadingDispositionCode = "jk";
		subject.StandardCarrierAlphaCode = "5y";
		subject.CustomsEntryTypeCode = customsEntryTypeCode;
		subject.CustomsEntryNumber = customsEntryNumber;

		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("EfR8iors", true)]
	public void Validation_RequiredDate(string date, bool isValidExpected)
	{
		var subject = new X4_CustomsReleaseInformation();
		subject.BillOfLadingDispositionCode = "jk";
		subject.StandardCarrierAlphaCode = "5y";
		subject.Date = date;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("jk", true)]
	public void Validation_RequiredBillOfLadingDispositionCode(string billOfLadingDispositionCode, bool isValidExpected)
	{
		var subject = new X4_CustomsReleaseInformation();
		subject.Date = "EfR8iors";
		subject.StandardCarrierAlphaCode = "5y";
		subject.BillOfLadingDispositionCode = billOfLadingDispositionCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("","", true)]
	[InlineData("P", "IL", true)]
	[InlineData("", "IL", false)]
	[InlineData("P", "", false)]
	public void Validation_AllAreRequiredBillOfLadingWaybillNumber2(string billOfLadingWaybillNumber2, string standardCarrierAlphaCode2, bool isValidExpected)
	{
		var subject = new X4_CustomsReleaseInformation();
		subject.Date = "EfR8iors";
		subject.BillOfLadingDispositionCode = "jk";
		subject.StandardCarrierAlphaCode = "5y";
		subject.BillOfLadingWaybillNumber2 = billOfLadingWaybillNumber2;
		subject.StandardCarrierAlphaCode2 = standardCarrierAlphaCode2;

		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("5y", true)]
	public void Validation_RequiredStandardCarrierAlphaCode(string standardCarrierAlphaCode, bool isValidExpected)
	{
		var subject = new X4_CustomsReleaseInformation();
		subject.Date = "EfR8iors";
		subject.BillOfLadingDispositionCode = "jk";
		subject.StandardCarrierAlphaCode = standardCarrierAlphaCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("","", true)]
	[InlineData("Pn", "Z", true)]
	[InlineData("", "Z", false)]
	[InlineData("Pn", "", false)]
	public void Validation_AllAreRequiredReferenceIdentificationQualifier(string referenceIdentificationQualifier, string referenceIdentification, bool isValidExpected)
	{
		var subject = new X4_CustomsReleaseInformation();
		subject.Date = "EfR8iors";
		subject.BillOfLadingDispositionCode = "jk";
		subject.StandardCarrierAlphaCode = "5y";
		subject.ReferenceIdentificationQualifier = referenceIdentificationQualifier;
		subject.ReferenceIdentification = referenceIdentification;

		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("", "bUle", true)]
	[InlineData("P0", "", false)]
	public void Validation_ARequiresBTimeCode(string timeCode, string time, bool isValidExpected)
	{
		var subject = new X4_CustomsReleaseInformation();
		subject.Date = "EfR8iors";
		subject.BillOfLadingDispositionCode = "jk";
		subject.StandardCarrierAlphaCode = "5y";
		subject.TimeCode = timeCode;
		subject.Time = time;

		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("", "Uu", true)]
	[InlineData("z", "", false)]
	public void Validation_ARequiresBLocationIdentifier3(string locationIdentifier3, string customsEntryTypeCode, bool isValidExpected)
	{
		var subject = new X4_CustomsReleaseInformation();
		subject.Date = "EfR8iors";
		subject.BillOfLadingDispositionCode = "jk";
		subject.StandardCarrierAlphaCode = "5y";
		subject.LocationIdentifier3 = locationIdentifier3;
		subject.CustomsEntryTypeCode = customsEntryTypeCode;

		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("", "Uu", true)]
	[InlineData("t", "", false)]
	public void Validation_ARequiresBLocationIdentifier4(string locationIdentifier4, string customsEntryTypeCode, bool isValidExpected)
	{
		var subject = new X4_CustomsReleaseInformation();
		subject.Date = "EfR8iors";
		subject.BillOfLadingDispositionCode = "jk";
		subject.StandardCarrierAlphaCode = "5y";
		subject.LocationIdentifier4 = locationIdentifier4;
		subject.CustomsEntryTypeCode = customsEntryTypeCode;

		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
	}

}
