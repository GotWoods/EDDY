using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3040;

namespace Eddy.x12.Tests.Models.v3040;

public class F03Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "F03*9*g6*T*f6*Y*y*RG*j*Dh*m*fD*K*k*g0OQP";

		var expected = new F03_DetailSupportingEvidenceForClaim()
		{
			Quantity = 9,
			UnitOrBasisForMeasurementCode = "g6",
			LadingDescription = "T",
			NatureOfClaimCode = "f6",
			Amount = "Y",
			Amount2 = "y",
			ReferenceNumberQualifier = "RG",
			ReferenceNumber = "j",
			ReferenceNumberQualifier2 = "Dh",
			ReferenceNumber2 = "m",
			NatureOfClaimCode2 = "fD",
			FreeFormDescription = "K",
			LadingDescription2 = "k",
			PackagingCode = "g0OQP",
		};

		var actual = Map.MapObject<F03_DetailSupportingEvidenceForClaim>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData(0, false)]
	[InlineData(9, true)]
	public void Validation_RequiredQuantity(decimal quantity, bool isValidExpected)
	{
		var subject = new F03_DetailSupportingEvidenceForClaim();
		subject.UnitOrBasisForMeasurementCode = "g6";
		subject.LadingDescription = "T";
		subject.NatureOfClaimCode = "f6";
		subject.Amount = "Y";
		subject.Amount2 = "y";
		subject.NatureOfClaimCode2 = "fD";
		subject.LadingDescription2 = "k";
		if (quantity > 0)
			subject.Quantity = quantity;
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.ReferenceNumberQualifier) || !string.IsNullOrEmpty(subject.ReferenceNumberQualifier) || !string.IsNullOrEmpty(subject.ReferenceNumber))
		{
			subject.ReferenceNumberQualifier = "RG";
			subject.ReferenceNumber = "j";
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.ReferenceNumberQualifier2) || !string.IsNullOrEmpty(subject.ReferenceNumberQualifier2) || !string.IsNullOrEmpty(subject.ReferenceNumber2))
		{
			subject.ReferenceNumberQualifier2 = "Dh";
			subject.ReferenceNumber2 = "m";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("g6", true)]
	public void Validation_RequiredUnitOrBasisForMeasurementCode(string unitOrBasisForMeasurementCode, bool isValidExpected)
	{
		var subject = new F03_DetailSupportingEvidenceForClaim();
		subject.Quantity = 9;
		subject.LadingDescription = "T";
		subject.NatureOfClaimCode = "f6";
		subject.Amount = "Y";
		subject.Amount2 = "y";
		subject.NatureOfClaimCode2 = "fD";
		subject.LadingDescription2 = "k";
		subject.UnitOrBasisForMeasurementCode = unitOrBasisForMeasurementCode;
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.ReferenceNumberQualifier) || !string.IsNullOrEmpty(subject.ReferenceNumberQualifier) || !string.IsNullOrEmpty(subject.ReferenceNumber))
		{
			subject.ReferenceNumberQualifier = "RG";
			subject.ReferenceNumber = "j";
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.ReferenceNumberQualifier2) || !string.IsNullOrEmpty(subject.ReferenceNumberQualifier2) || !string.IsNullOrEmpty(subject.ReferenceNumber2))
		{
			subject.ReferenceNumberQualifier2 = "Dh";
			subject.ReferenceNumber2 = "m";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("T", true)]
	public void Validation_RequiredLadingDescription(string ladingDescription, bool isValidExpected)
	{
		var subject = new F03_DetailSupportingEvidenceForClaim();
		subject.Quantity = 9;
		subject.UnitOrBasisForMeasurementCode = "g6";
		subject.NatureOfClaimCode = "f6";
		subject.Amount = "Y";
		subject.Amount2 = "y";
		subject.NatureOfClaimCode2 = "fD";
		subject.LadingDescription2 = "k";
		subject.LadingDescription = ladingDescription;
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.ReferenceNumberQualifier) || !string.IsNullOrEmpty(subject.ReferenceNumberQualifier) || !string.IsNullOrEmpty(subject.ReferenceNumber))
		{
			subject.ReferenceNumberQualifier = "RG";
			subject.ReferenceNumber = "j";
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.ReferenceNumberQualifier2) || !string.IsNullOrEmpty(subject.ReferenceNumberQualifier2) || !string.IsNullOrEmpty(subject.ReferenceNumber2))
		{
			subject.ReferenceNumberQualifier2 = "Dh";
			subject.ReferenceNumber2 = "m";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("f6", true)]
	public void Validation_RequiredNatureOfClaimCode(string natureOfClaimCode, bool isValidExpected)
	{
		var subject = new F03_DetailSupportingEvidenceForClaim();
		subject.Quantity = 9;
		subject.UnitOrBasisForMeasurementCode = "g6";
		subject.LadingDescription = "T";
		subject.Amount = "Y";
		subject.Amount2 = "y";
		subject.NatureOfClaimCode2 = "fD";
		subject.LadingDescription2 = "k";
		subject.NatureOfClaimCode = natureOfClaimCode;
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.ReferenceNumberQualifier) || !string.IsNullOrEmpty(subject.ReferenceNumberQualifier) || !string.IsNullOrEmpty(subject.ReferenceNumber))
		{
			subject.ReferenceNumberQualifier = "RG";
			subject.ReferenceNumber = "j";
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.ReferenceNumberQualifier2) || !string.IsNullOrEmpty(subject.ReferenceNumberQualifier2) || !string.IsNullOrEmpty(subject.ReferenceNumber2))
		{
			subject.ReferenceNumberQualifier2 = "Dh";
			subject.ReferenceNumber2 = "m";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("Y", true)]
	public void Validation_RequiredAmount(string amount, bool isValidExpected)
	{
		var subject = new F03_DetailSupportingEvidenceForClaim();
		subject.Quantity = 9;
		subject.UnitOrBasisForMeasurementCode = "g6";
		subject.LadingDescription = "T";
		subject.NatureOfClaimCode = "f6";
		subject.Amount2 = "y";
		subject.NatureOfClaimCode2 = "fD";
		subject.LadingDescription2 = "k";
		subject.Amount = amount;
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.ReferenceNumberQualifier) || !string.IsNullOrEmpty(subject.ReferenceNumberQualifier) || !string.IsNullOrEmpty(subject.ReferenceNumber))
		{
			subject.ReferenceNumberQualifier = "RG";
			subject.ReferenceNumber = "j";
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.ReferenceNumberQualifier2) || !string.IsNullOrEmpty(subject.ReferenceNumberQualifier2) || !string.IsNullOrEmpty(subject.ReferenceNumber2))
		{
			subject.ReferenceNumberQualifier2 = "Dh";
			subject.ReferenceNumber2 = "m";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("y", true)]
	public void Validation_RequiredAmount2(string amount2, bool isValidExpected)
	{
		var subject = new F03_DetailSupportingEvidenceForClaim();
		subject.Quantity = 9;
		subject.UnitOrBasisForMeasurementCode = "g6";
		subject.LadingDescription = "T";
		subject.NatureOfClaimCode = "f6";
		subject.Amount = "Y";
		subject.NatureOfClaimCode2 = "fD";
		subject.LadingDescription2 = "k";
		subject.Amount2 = amount2;
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.ReferenceNumberQualifier) || !string.IsNullOrEmpty(subject.ReferenceNumberQualifier) || !string.IsNullOrEmpty(subject.ReferenceNumber))
		{
			subject.ReferenceNumberQualifier = "RG";
			subject.ReferenceNumber = "j";
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.ReferenceNumberQualifier2) || !string.IsNullOrEmpty(subject.ReferenceNumberQualifier2) || !string.IsNullOrEmpty(subject.ReferenceNumber2))
		{
			subject.ReferenceNumberQualifier2 = "Dh";
			subject.ReferenceNumber2 = "m";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("RG", "j", true)]
	[InlineData("RG", "", false)]
	[InlineData("", "j", false)]
	public void Validation_AllAreRequiredReferenceNumberQualifier(string referenceNumberQualifier, string referenceNumber, bool isValidExpected)
	{
		var subject = new F03_DetailSupportingEvidenceForClaim();
		subject.Quantity = 9;
		subject.UnitOrBasisForMeasurementCode = "g6";
		subject.LadingDescription = "T";
		subject.NatureOfClaimCode = "f6";
		subject.Amount = "Y";
		subject.Amount2 = "y";
		subject.NatureOfClaimCode2 = "fD";
		subject.LadingDescription2 = "k";
		subject.ReferenceNumberQualifier = referenceNumberQualifier;
		subject.ReferenceNumber = referenceNumber;
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.ReferenceNumberQualifier2) || !string.IsNullOrEmpty(subject.ReferenceNumberQualifier2) || !string.IsNullOrEmpty(subject.ReferenceNumber2))
		{
			subject.ReferenceNumberQualifier2 = "Dh";
			subject.ReferenceNumber2 = "m";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("Dh", "m", true)]
	[InlineData("Dh", "", false)]
	[InlineData("", "m", false)]
	public void Validation_AllAreRequiredReferenceNumberQualifier2(string referenceNumberQualifier2, string referenceNumber2, bool isValidExpected)
	{
		var subject = new F03_DetailSupportingEvidenceForClaim();
		subject.Quantity = 9;
		subject.UnitOrBasisForMeasurementCode = "g6";
		subject.LadingDescription = "T";
		subject.NatureOfClaimCode = "f6";
		subject.Amount = "Y";
		subject.Amount2 = "y";
		subject.NatureOfClaimCode2 = "fD";
		subject.LadingDescription2 = "k";
		subject.ReferenceNumberQualifier2 = referenceNumberQualifier2;
		subject.ReferenceNumber2 = referenceNumber2;
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.ReferenceNumberQualifier) || !string.IsNullOrEmpty(subject.ReferenceNumberQualifier) || !string.IsNullOrEmpty(subject.ReferenceNumber))
		{
			subject.ReferenceNumberQualifier = "RG";
			subject.ReferenceNumber = "j";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("fD", true)]
	public void Validation_RequiredNatureOfClaimCode2(string natureOfClaimCode2, bool isValidExpected)
	{
		var subject = new F03_DetailSupportingEvidenceForClaim();
		subject.Quantity = 9;
		subject.UnitOrBasisForMeasurementCode = "g6";
		subject.LadingDescription = "T";
		subject.NatureOfClaimCode = "f6";
		subject.Amount = "Y";
		subject.Amount2 = "y";
		subject.LadingDescription2 = "k";
		subject.NatureOfClaimCode2 = natureOfClaimCode2;
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.ReferenceNumberQualifier) || !string.IsNullOrEmpty(subject.ReferenceNumberQualifier) || !string.IsNullOrEmpty(subject.ReferenceNumber))
		{
			subject.ReferenceNumberQualifier = "RG";
			subject.ReferenceNumber = "j";
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.ReferenceNumberQualifier2) || !string.IsNullOrEmpty(subject.ReferenceNumberQualifier2) || !string.IsNullOrEmpty(subject.ReferenceNumber2))
		{
			subject.ReferenceNumberQualifier2 = "Dh";
			subject.ReferenceNumber2 = "m";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("k", true)]
	public void Validation_RequiredLadingDescription2(string ladingDescription2, bool isValidExpected)
	{
		var subject = new F03_DetailSupportingEvidenceForClaim();
		subject.Quantity = 9;
		subject.UnitOrBasisForMeasurementCode = "g6";
		subject.LadingDescription = "T";
		subject.NatureOfClaimCode = "f6";
		subject.Amount = "Y";
		subject.Amount2 = "y";
		subject.NatureOfClaimCode2 = "fD";
		subject.LadingDescription2 = ladingDescription2;
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.ReferenceNumberQualifier) || !string.IsNullOrEmpty(subject.ReferenceNumberQualifier) || !string.IsNullOrEmpty(subject.ReferenceNumber))
		{
			subject.ReferenceNumberQualifier = "RG";
			subject.ReferenceNumber = "j";
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.ReferenceNumberQualifier2) || !string.IsNullOrEmpty(subject.ReferenceNumberQualifier2) || !string.IsNullOrEmpty(subject.ReferenceNumber2))
		{
			subject.ReferenceNumberQualifier2 = "Dh";
			subject.ReferenceNumber2 = "m";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
