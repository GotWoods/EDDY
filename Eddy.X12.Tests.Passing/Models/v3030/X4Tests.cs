using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3030;

namespace Eddy.x12.Tests.Models.v3030;

public class X4Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "X4*e*5*o2*G*BdKSnV*jjDz*DT*j*Hb*G4*Y*t*0*w*NI*e";

		var expected = new X4_CustomsReleaseInformation()
		{
			BillOfLadingWaybillNumber = "e",
			Quantity = 5,
			EntryTypeCode = "o2",
			EntryNumber = "G",
			ReleaseIssueDate = "BdKSnV",
			Time = "jjDz",
			DispositionCode = "DT",
			BillOfLadingWaybillNumber2 = "j",
			StandardCarrierAlphaCode = "Hb",
			StandardCarrierAlphaCode2 = "G4",
			EquipmentInitial = "Y",
			EquipmentNumber = "t",
			LocationIdentifier = "0",
			LocationIdentifier2 = "w",
			ReferenceNumberQualifier = "NI",
			ReferenceNumber = "e",
		};

		var actual = Map.MapObject<X4_CustomsReleaseInformation>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("e", true)]
	public void Validation_RequiredBillOfLadingWaybillNumber(string billOfLadingWaybillNumber, bool isValidExpected)
	{
		var subject = new X4_CustomsReleaseInformation();
		//Required fields
		subject.Quantity = 5;
		subject.ReleaseIssueDate = "BdKSnV";
		subject.Time = "jjDz";
		subject.DispositionCode = "DT";
		subject.StandardCarrierAlphaCode = "Hb";
		//Test Parameters
		subject.BillOfLadingWaybillNumber = billOfLadingWaybillNumber;
		//At Least one
		subject.ReferenceNumberQualifier = "NI";
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.BillOfLadingWaybillNumber2) || !string.IsNullOrEmpty(subject.BillOfLadingWaybillNumber2) || !string.IsNullOrEmpty(subject.StandardCarrierAlphaCode2))
		{
			subject.BillOfLadingWaybillNumber2 = "j";
			subject.StandardCarrierAlphaCode2 = "G4";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData(0, false)]
	[InlineData(5, true)]
	public void Validation_RequiredQuantity(decimal quantity, bool isValidExpected)
	{
		var subject = new X4_CustomsReleaseInformation();
		//Required fields
		subject.BillOfLadingWaybillNumber = "e";
		subject.ReleaseIssueDate = "BdKSnV";
		subject.Time = "jjDz";
		subject.DispositionCode = "DT";
		subject.StandardCarrierAlphaCode = "Hb";
		//Test Parameters
		if (quantity > 0) 
			subject.Quantity = quantity;
		//At Least one
		subject.ReferenceNumberQualifier = "NI";
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.BillOfLadingWaybillNumber2) || !string.IsNullOrEmpty(subject.BillOfLadingWaybillNumber2) || !string.IsNullOrEmpty(subject.StandardCarrierAlphaCode2))
		{
			subject.BillOfLadingWaybillNumber2 = "j";
			subject.StandardCarrierAlphaCode2 = "G4";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("BdKSnV", true)]
	public void Validation_RequiredReleaseIssueDate(string releaseIssueDate, bool isValidExpected)
	{
		var subject = new X4_CustomsReleaseInformation();
		//Required fields
		subject.BillOfLadingWaybillNumber = "e";
		subject.Quantity = 5;
		subject.Time = "jjDz";
		subject.DispositionCode = "DT";
		subject.StandardCarrierAlphaCode = "Hb";
		//Test Parameters
		subject.ReleaseIssueDate = releaseIssueDate;
		//At Least one
		subject.ReferenceNumberQualifier = "NI";
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.BillOfLadingWaybillNumber2) || !string.IsNullOrEmpty(subject.BillOfLadingWaybillNumber2) || !string.IsNullOrEmpty(subject.StandardCarrierAlphaCode2))
		{
			subject.BillOfLadingWaybillNumber2 = "j";
			subject.StandardCarrierAlphaCode2 = "G4";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("jjDz", true)]
	public void Validation_RequiredTime(string time, bool isValidExpected)
	{
		var subject = new X4_CustomsReleaseInformation();
		//Required fields
		subject.BillOfLadingWaybillNumber = "e";
		subject.Quantity = 5;
		subject.ReleaseIssueDate = "BdKSnV";
		subject.DispositionCode = "DT";
		subject.StandardCarrierAlphaCode = "Hb";
		//Test Parameters
		subject.Time = time;
		//At Least one
		subject.ReferenceNumberQualifier = "NI";
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.BillOfLadingWaybillNumber2) || !string.IsNullOrEmpty(subject.BillOfLadingWaybillNumber2) || !string.IsNullOrEmpty(subject.StandardCarrierAlphaCode2))
		{
			subject.BillOfLadingWaybillNumber2 = "j";
			subject.StandardCarrierAlphaCode2 = "G4";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("DT", true)]
	public void Validation_RequiredDispositionCode(string dispositionCode, bool isValidExpected)
	{
		var subject = new X4_CustomsReleaseInformation();
		//Required fields
		subject.BillOfLadingWaybillNumber = "e";
		subject.Quantity = 5;
		subject.ReleaseIssueDate = "BdKSnV";
		subject.Time = "jjDz";
		subject.StandardCarrierAlphaCode = "Hb";
		//Test Parameters
		subject.DispositionCode = dispositionCode;
		//At Least one
		subject.ReferenceNumberQualifier = "NI";
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.BillOfLadingWaybillNumber2) || !string.IsNullOrEmpty(subject.BillOfLadingWaybillNumber2) || !string.IsNullOrEmpty(subject.StandardCarrierAlphaCode2))
		{
			subject.BillOfLadingWaybillNumber2 = "j";
			subject.StandardCarrierAlphaCode2 = "G4";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("j", "G4", true)]
	[InlineData("j", "", false)]
	[InlineData("", "G4", false)]
	public void Validation_AllAreRequiredBillOfLadingWaybillNumber2(string billOfLadingWaybillNumber2, string standardCarrierAlphaCode2, bool isValidExpected)
	{
		var subject = new X4_CustomsReleaseInformation();
		//Required fields
		subject.BillOfLadingWaybillNumber = "e";
		subject.Quantity = 5;
		subject.ReleaseIssueDate = "BdKSnV";
		subject.Time = "jjDz";
		subject.DispositionCode = "DT";
		subject.StandardCarrierAlphaCode = "Hb";
		//Test Parameters
		subject.BillOfLadingWaybillNumber2 = billOfLadingWaybillNumber2;
		subject.StandardCarrierAlphaCode2 = standardCarrierAlphaCode2;
		//At Least one
		subject.ReferenceNumberQualifier = "NI";
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("Hb", true)]
	public void Validation_RequiredStandardCarrierAlphaCode(string standardCarrierAlphaCode, bool isValidExpected)
	{
		var subject = new X4_CustomsReleaseInformation();
		//Required fields
		subject.BillOfLadingWaybillNumber = "e";
		subject.Quantity = 5;
		subject.ReleaseIssueDate = "BdKSnV";
		subject.Time = "jjDz";
		subject.DispositionCode = "DT";
		//Test Parameters
		subject.StandardCarrierAlphaCode = standardCarrierAlphaCode;
		//At Least one
		subject.ReferenceNumberQualifier = "NI";
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.BillOfLadingWaybillNumber2) || !string.IsNullOrEmpty(subject.BillOfLadingWaybillNumber2) || !string.IsNullOrEmpty(subject.StandardCarrierAlphaCode2))
		{
			subject.BillOfLadingWaybillNumber2 = "j";
			subject.StandardCarrierAlphaCode2 = "G4";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", "", false)]
	[InlineData("NI", "e", true)]
	[InlineData("NI", "", true)]
	[InlineData("", "e", true)]
	public void Validation_AtLeastOneReferenceNumberQualifier(string referenceNumberQualifier, string referenceNumber, bool isValidExpected)
	{
		var subject = new X4_CustomsReleaseInformation();
		//Required fields
		subject.BillOfLadingWaybillNumber = "e";
		subject.Quantity = 5;
		subject.ReleaseIssueDate = "BdKSnV";
		subject.Time = "jjDz";
		subject.DispositionCode = "DT";
		subject.StandardCarrierAlphaCode = "Hb";
		//Test Parameters
		subject.ReferenceNumberQualifier = referenceNumberQualifier;
		subject.ReferenceNumber = referenceNumber;
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.BillOfLadingWaybillNumber2) || !string.IsNullOrEmpty(subject.BillOfLadingWaybillNumber2) || !string.IsNullOrEmpty(subject.StandardCarrierAlphaCode2))
		{
			subject.BillOfLadingWaybillNumber2 = "j";
			subject.StandardCarrierAlphaCode2 = "G4";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.AtLeastOneIsRequired);
	}

}
