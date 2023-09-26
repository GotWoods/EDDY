using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3060;

namespace Eddy.x12.Tests.Models.v3060;

public class F09Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "F09*5*W9*GX*K*n*A*f*eb*P*Vu*B*3";

		var expected = new F09_DetailSupportingEvidenceForClaim()
		{
			Quantity = 5,
			UnitOrBasisForMeasurementCode = "W9",
			NatureOfClaimCode = "GX",
			Amount = "K",
			Amount2 = "n",
			Description = "A",
			LadingDescription = "f",
			ReferenceIdentificationQualifier = "eb",
			ReferenceIdentification = "P",
			ReferenceIdentificationQualifier2 = "Vu",
			ReferenceIdentification2 = "B",
			LadingLineItemNumber = 3,
		};

		var actual = Map.MapObject<F09_DetailSupportingEvidenceForClaim>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData(0, false)]
	[InlineData(5, true)]
	public void Validation_RequiredQuantity(decimal quantity, bool isValidExpected)
	{
		var subject = new F09_DetailSupportingEvidenceForClaim();
		//Required fields
		subject.UnitOrBasisForMeasurementCode = "W9";
		subject.NatureOfClaimCode = "GX";
		subject.Amount = "K";
		subject.Amount2 = "n";
		//Test Parameters
		if (quantity > 0) 
			subject.Quantity = quantity;
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.ReferenceIdentificationQualifier) || !string.IsNullOrEmpty(subject.ReferenceIdentificationQualifier) || !string.IsNullOrEmpty(subject.ReferenceIdentification))
		{
			subject.ReferenceIdentificationQualifier = "eb";
			subject.ReferenceIdentification = "P";
		}
		if(!string.IsNullOrEmpty(subject.ReferenceIdentificationQualifier2) || !string.IsNullOrEmpty(subject.ReferenceIdentificationQualifier2) || !string.IsNullOrEmpty(subject.ReferenceIdentification2))
		{
			subject.ReferenceIdentificationQualifier2 = "Vu";
			subject.ReferenceIdentification2 = "B";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("W9", true)]
	public void Validation_RequiredUnitOrBasisForMeasurementCode(string unitOrBasisForMeasurementCode, bool isValidExpected)
	{
		var subject = new F09_DetailSupportingEvidenceForClaim();
		//Required fields
		subject.Quantity = 5;
		subject.NatureOfClaimCode = "GX";
		subject.Amount = "K";
		subject.Amount2 = "n";
		//Test Parameters
		subject.UnitOrBasisForMeasurementCode = unitOrBasisForMeasurementCode;
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.ReferenceIdentificationQualifier) || !string.IsNullOrEmpty(subject.ReferenceIdentificationQualifier) || !string.IsNullOrEmpty(subject.ReferenceIdentification))
		{
			subject.ReferenceIdentificationQualifier = "eb";
			subject.ReferenceIdentification = "P";
		}
		if(!string.IsNullOrEmpty(subject.ReferenceIdentificationQualifier2) || !string.IsNullOrEmpty(subject.ReferenceIdentificationQualifier2) || !string.IsNullOrEmpty(subject.ReferenceIdentification2))
		{
			subject.ReferenceIdentificationQualifier2 = "Vu";
			subject.ReferenceIdentification2 = "B";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("GX", true)]
	public void Validation_RequiredNatureOfClaimCode(string natureOfClaimCode, bool isValidExpected)
	{
		var subject = new F09_DetailSupportingEvidenceForClaim();
		//Required fields
		subject.Quantity = 5;
		subject.UnitOrBasisForMeasurementCode = "W9";
		subject.Amount = "K";
		subject.Amount2 = "n";
		//Test Parameters
		subject.NatureOfClaimCode = natureOfClaimCode;
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.ReferenceIdentificationQualifier) || !string.IsNullOrEmpty(subject.ReferenceIdentificationQualifier) || !string.IsNullOrEmpty(subject.ReferenceIdentification))
		{
			subject.ReferenceIdentificationQualifier = "eb";
			subject.ReferenceIdentification = "P";
		}
		if(!string.IsNullOrEmpty(subject.ReferenceIdentificationQualifier2) || !string.IsNullOrEmpty(subject.ReferenceIdentificationQualifier2) || !string.IsNullOrEmpty(subject.ReferenceIdentification2))
		{
			subject.ReferenceIdentificationQualifier2 = "Vu";
			subject.ReferenceIdentification2 = "B";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("K", true)]
	public void Validation_RequiredAmount(string amount, bool isValidExpected)
	{
		var subject = new F09_DetailSupportingEvidenceForClaim();
		//Required fields
		subject.Quantity = 5;
		subject.UnitOrBasisForMeasurementCode = "W9";
		subject.NatureOfClaimCode = "GX";
		subject.Amount2 = "n";
		//Test Parameters
		subject.Amount = amount;
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.ReferenceIdentificationQualifier) || !string.IsNullOrEmpty(subject.ReferenceIdentificationQualifier) || !string.IsNullOrEmpty(subject.ReferenceIdentification))
		{
			subject.ReferenceIdentificationQualifier = "eb";
			subject.ReferenceIdentification = "P";
		}
		if(!string.IsNullOrEmpty(subject.ReferenceIdentificationQualifier2) || !string.IsNullOrEmpty(subject.ReferenceIdentificationQualifier2) || !string.IsNullOrEmpty(subject.ReferenceIdentification2))
		{
			subject.ReferenceIdentificationQualifier2 = "Vu";
			subject.ReferenceIdentification2 = "B";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("n", true)]
	public void Validation_RequiredAmount2(string amount2, bool isValidExpected)
	{
		var subject = new F09_DetailSupportingEvidenceForClaim();
		//Required fields
		subject.Quantity = 5;
		subject.UnitOrBasisForMeasurementCode = "W9";
		subject.NatureOfClaimCode = "GX";
		subject.Amount = "K";
		//Test Parameters
		subject.Amount2 = amount2;
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.ReferenceIdentificationQualifier) || !string.IsNullOrEmpty(subject.ReferenceIdentificationQualifier) || !string.IsNullOrEmpty(subject.ReferenceIdentification))
		{
			subject.ReferenceIdentificationQualifier = "eb";
			subject.ReferenceIdentification = "P";
		}
		if(!string.IsNullOrEmpty(subject.ReferenceIdentificationQualifier2) || !string.IsNullOrEmpty(subject.ReferenceIdentificationQualifier2) || !string.IsNullOrEmpty(subject.ReferenceIdentification2))
		{
			subject.ReferenceIdentificationQualifier2 = "Vu";
			subject.ReferenceIdentification2 = "B";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("eb", "P", true)]
	[InlineData("eb", "", false)]
	[InlineData("", "P", false)]
	public void Validation_AllAreRequiredReferenceIdentificationQualifier(string referenceIdentificationQualifier, string referenceIdentification, bool isValidExpected)
	{
		var subject = new F09_DetailSupportingEvidenceForClaim();
		//Required fields
		subject.Quantity = 5;
		subject.UnitOrBasisForMeasurementCode = "W9";
		subject.NatureOfClaimCode = "GX";
		subject.Amount = "K";
		subject.Amount2 = "n";
		//Test Parameters
		subject.ReferenceIdentificationQualifier = referenceIdentificationQualifier;
		subject.ReferenceIdentification = referenceIdentification;
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.ReferenceIdentificationQualifier2) || !string.IsNullOrEmpty(subject.ReferenceIdentificationQualifier2) || !string.IsNullOrEmpty(subject.ReferenceIdentification2))
		{
			subject.ReferenceIdentificationQualifier2 = "Vu";
			subject.ReferenceIdentification2 = "B";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("Vu", "B", true)]
	[InlineData("Vu", "", false)]
	[InlineData("", "B", false)]
	public void Validation_AllAreRequiredReferenceIdentificationQualifier2(string referenceIdentificationQualifier2, string referenceIdentification2, bool isValidExpected)
	{
		var subject = new F09_DetailSupportingEvidenceForClaim();
		//Required fields
		subject.Quantity = 5;
		subject.UnitOrBasisForMeasurementCode = "W9";
		subject.NatureOfClaimCode = "GX";
		subject.Amount = "K";
		subject.Amount2 = "n";
		//Test Parameters
		subject.ReferenceIdentificationQualifier2 = referenceIdentificationQualifier2;
		subject.ReferenceIdentification2 = referenceIdentification2;
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.ReferenceIdentificationQualifier) || !string.IsNullOrEmpty(subject.ReferenceIdentificationQualifier) || !string.IsNullOrEmpty(subject.ReferenceIdentification))
		{
			subject.ReferenceIdentificationQualifier = "eb";
			subject.ReferenceIdentification = "P";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

}
