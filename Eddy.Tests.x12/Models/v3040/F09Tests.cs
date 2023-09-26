using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3040;

namespace Eddy.x12.Tests.Models.v3040;

public class F09Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "F09*8*i0*Kh*n*V*H*7*vU*c*Bp*u*2";

		var expected = new F09_DetailSupportingEvidenceForClaim()
		{
			Quantity = 8,
			UnitOrBasisForMeasurementCode = "i0",
			NatureOfClaimCode = "Kh",
			Amount = "n",
			Amount2 = "V",
			Description = "H",
			LadingDescription = "7",
			ReferenceNumberQualifier = "vU",
			ReferenceNumber = "c",
			ReferenceNumberQualifier2 = "Bp",
			ReferenceNumber2 = "u",
			LadingLineItemNumber = 2,
		};

		var actual = Map.MapObject<F09_DetailSupportingEvidenceForClaim>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData(0, false)]
	[InlineData(8, true)]
	public void Validation_RequiredQuantity(decimal quantity, bool isValidExpected)
	{
		var subject = new F09_DetailSupportingEvidenceForClaim();
		//Required fields
		subject.UnitOrBasisForMeasurementCode = "i0";
		subject.NatureOfClaimCode = "Kh";
		subject.Amount = "n";
		subject.Amount2 = "V";
		//Test Parameters
		if (quantity > 0) 
			subject.Quantity = quantity;
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.ReferenceNumberQualifier) || !string.IsNullOrEmpty(subject.ReferenceNumberQualifier) || !string.IsNullOrEmpty(subject.ReferenceNumber))
		{
			subject.ReferenceNumberQualifier = "vU";
			subject.ReferenceNumber = "c";
		}
		if(!string.IsNullOrEmpty(subject.ReferenceNumberQualifier2) || !string.IsNullOrEmpty(subject.ReferenceNumberQualifier2) || !string.IsNullOrEmpty(subject.ReferenceNumber2))
		{
			subject.ReferenceNumberQualifier2 = "Bp";
			subject.ReferenceNumber2 = "u";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("i0", true)]
	public void Validation_RequiredUnitOrBasisForMeasurementCode(string unitOrBasisForMeasurementCode, bool isValidExpected)
	{
		var subject = new F09_DetailSupportingEvidenceForClaim();
		//Required fields
		subject.Quantity = 8;
		subject.NatureOfClaimCode = "Kh";
		subject.Amount = "n";
		subject.Amount2 = "V";
		//Test Parameters
		subject.UnitOrBasisForMeasurementCode = unitOrBasisForMeasurementCode;
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.ReferenceNumberQualifier) || !string.IsNullOrEmpty(subject.ReferenceNumberQualifier) || !string.IsNullOrEmpty(subject.ReferenceNumber))
		{
			subject.ReferenceNumberQualifier = "vU";
			subject.ReferenceNumber = "c";
		}
		if(!string.IsNullOrEmpty(subject.ReferenceNumberQualifier2) || !string.IsNullOrEmpty(subject.ReferenceNumberQualifier2) || !string.IsNullOrEmpty(subject.ReferenceNumber2))
		{
			subject.ReferenceNumberQualifier2 = "Bp";
			subject.ReferenceNumber2 = "u";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("Kh", true)]
	public void Validation_RequiredNatureOfClaimCode(string natureOfClaimCode, bool isValidExpected)
	{
		var subject = new F09_DetailSupportingEvidenceForClaim();
		//Required fields
		subject.Quantity = 8;
		subject.UnitOrBasisForMeasurementCode = "i0";
		subject.Amount = "n";
		subject.Amount2 = "V";
		//Test Parameters
		subject.NatureOfClaimCode = natureOfClaimCode;
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.ReferenceNumberQualifier) || !string.IsNullOrEmpty(subject.ReferenceNumberQualifier) || !string.IsNullOrEmpty(subject.ReferenceNumber))
		{
			subject.ReferenceNumberQualifier = "vU";
			subject.ReferenceNumber = "c";
		}
		if(!string.IsNullOrEmpty(subject.ReferenceNumberQualifier2) || !string.IsNullOrEmpty(subject.ReferenceNumberQualifier2) || !string.IsNullOrEmpty(subject.ReferenceNumber2))
		{
			subject.ReferenceNumberQualifier2 = "Bp";
			subject.ReferenceNumber2 = "u";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("n", true)]
	public void Validation_RequiredAmount(string amount, bool isValidExpected)
	{
		var subject = new F09_DetailSupportingEvidenceForClaim();
		//Required fields
		subject.Quantity = 8;
		subject.UnitOrBasisForMeasurementCode = "i0";
		subject.NatureOfClaimCode = "Kh";
		subject.Amount2 = "V";
		//Test Parameters
		subject.Amount = amount;
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.ReferenceNumberQualifier) || !string.IsNullOrEmpty(subject.ReferenceNumberQualifier) || !string.IsNullOrEmpty(subject.ReferenceNumber))
		{
			subject.ReferenceNumberQualifier = "vU";
			subject.ReferenceNumber = "c";
		}
		if(!string.IsNullOrEmpty(subject.ReferenceNumberQualifier2) || !string.IsNullOrEmpty(subject.ReferenceNumberQualifier2) || !string.IsNullOrEmpty(subject.ReferenceNumber2))
		{
			subject.ReferenceNumberQualifier2 = "Bp";
			subject.ReferenceNumber2 = "u";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("V", true)]
	public void Validation_RequiredAmount2(string amount2, bool isValidExpected)
	{
		var subject = new F09_DetailSupportingEvidenceForClaim();
		//Required fields
		subject.Quantity = 8;
		subject.UnitOrBasisForMeasurementCode = "i0";
		subject.NatureOfClaimCode = "Kh";
		subject.Amount = "n";
		//Test Parameters
		subject.Amount2 = amount2;
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.ReferenceNumberQualifier) || !string.IsNullOrEmpty(subject.ReferenceNumberQualifier) || !string.IsNullOrEmpty(subject.ReferenceNumber))
		{
			subject.ReferenceNumberQualifier = "vU";
			subject.ReferenceNumber = "c";
		}
		if(!string.IsNullOrEmpty(subject.ReferenceNumberQualifier2) || !string.IsNullOrEmpty(subject.ReferenceNumberQualifier2) || !string.IsNullOrEmpty(subject.ReferenceNumber2))
		{
			subject.ReferenceNumberQualifier2 = "Bp";
			subject.ReferenceNumber2 = "u";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("vU", "c", true)]
	[InlineData("vU", "", false)]
	[InlineData("", "c", false)]
	public void Validation_AllAreRequiredReferenceNumberQualifier(string referenceNumberQualifier, string referenceNumber, bool isValidExpected)
	{
		var subject = new F09_DetailSupportingEvidenceForClaim();
		//Required fields
		subject.Quantity = 8;
		subject.UnitOrBasisForMeasurementCode = "i0";
		subject.NatureOfClaimCode = "Kh";
		subject.Amount = "n";
		subject.Amount2 = "V";
		//Test Parameters
		subject.ReferenceNumberQualifier = referenceNumberQualifier;
		subject.ReferenceNumber = referenceNumber;
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.ReferenceNumberQualifier2) || !string.IsNullOrEmpty(subject.ReferenceNumberQualifier2) || !string.IsNullOrEmpty(subject.ReferenceNumber2))
		{
			subject.ReferenceNumberQualifier2 = "Bp";
			subject.ReferenceNumber2 = "u";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("Bp", "u", true)]
	[InlineData("Bp", "", false)]
	[InlineData("", "u", false)]
	public void Validation_AllAreRequiredReferenceNumberQualifier2(string referenceNumberQualifier2, string referenceNumber2, bool isValidExpected)
	{
		var subject = new F09_DetailSupportingEvidenceForClaim();
		//Required fields
		subject.Quantity = 8;
		subject.UnitOrBasisForMeasurementCode = "i0";
		subject.NatureOfClaimCode = "Kh";
		subject.Amount = "n";
		subject.Amount2 = "V";
		//Test Parameters
		subject.ReferenceNumberQualifier2 = referenceNumberQualifier2;
		subject.ReferenceNumber2 = referenceNumber2;
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.ReferenceNumberQualifier) || !string.IsNullOrEmpty(subject.ReferenceNumberQualifier) || !string.IsNullOrEmpty(subject.ReferenceNumber))
		{
			subject.ReferenceNumberQualifier = "vU";
			subject.ReferenceNumber = "c";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

}
