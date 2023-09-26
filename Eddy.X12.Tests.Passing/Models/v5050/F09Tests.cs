using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v5050;

namespace Eddy.x12.Tests.Models.v5050;

public class F09Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "F09*6*6u*yn*R*V*i*Q*QD*g*7R*X*7";

		var expected = new F09_DetailSupportingEvidenceForClaim()
		{
			Quantity = 6,
			UnitOrBasisForMeasurementCode = "6u",
			NatureOfClaimCode = "yn",
			Amount = "R",
			Amount2 = "V",
			Description = "i",
			LadingDescription = "Q",
			ReferenceIdentificationQualifier = "QD",
			ReferenceIdentification = "g",
			ReferenceIdentificationQualifier2 = "7R",
			ReferenceIdentification2 = "X",
			LadingLineItemNumber = 7,
		};

		var actual = Map.MapObject<F09_DetailSupportingEvidenceForClaim>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData(0, false)]
	[InlineData(6, true)]
	public void Validation_RequiredQuantity(decimal quantity, bool isValidExpected)
	{
		var subject = new F09_DetailSupportingEvidenceForClaim();
		//Required fields
		subject.UnitOrBasisForMeasurementCode = "6u";
		subject.NatureOfClaimCode = "yn";
		subject.Amount = "R";
		subject.Amount2 = "V";
		//Test Parameters
		if (quantity > 0) 
			subject.Quantity = quantity;
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.ReferenceIdentificationQualifier) || !string.IsNullOrEmpty(subject.ReferenceIdentificationQualifier) || !string.IsNullOrEmpty(subject.ReferenceIdentification))
		{
			subject.ReferenceIdentificationQualifier = "QD";
			subject.ReferenceIdentification = "g";
		}
		if(!string.IsNullOrEmpty(subject.ReferenceIdentificationQualifier2) || !string.IsNullOrEmpty(subject.ReferenceIdentificationQualifier2) || !string.IsNullOrEmpty(subject.ReferenceIdentification2))
		{
			subject.ReferenceIdentificationQualifier2 = "7R";
			subject.ReferenceIdentification2 = "X";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("6u", true)]
	public void Validation_RequiredUnitOrBasisForMeasurementCode(string unitOrBasisForMeasurementCode, bool isValidExpected)
	{
		var subject = new F09_DetailSupportingEvidenceForClaim();
		//Required fields
		subject.Quantity = 6;
		subject.NatureOfClaimCode = "yn";
		subject.Amount = "R";
		subject.Amount2 = "V";
		//Test Parameters
		subject.UnitOrBasisForMeasurementCode = unitOrBasisForMeasurementCode;
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.ReferenceIdentificationQualifier) || !string.IsNullOrEmpty(subject.ReferenceIdentificationQualifier) || !string.IsNullOrEmpty(subject.ReferenceIdentification))
		{
			subject.ReferenceIdentificationQualifier = "QD";
			subject.ReferenceIdentification = "g";
		}
		if(!string.IsNullOrEmpty(subject.ReferenceIdentificationQualifier2) || !string.IsNullOrEmpty(subject.ReferenceIdentificationQualifier2) || !string.IsNullOrEmpty(subject.ReferenceIdentification2))
		{
			subject.ReferenceIdentificationQualifier2 = "7R";
			subject.ReferenceIdentification2 = "X";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("yn", true)]
	public void Validation_RequiredNatureOfClaimCode(string natureOfClaimCode, bool isValidExpected)
	{
		var subject = new F09_DetailSupportingEvidenceForClaim();
		//Required fields
		subject.Quantity = 6;
		subject.UnitOrBasisForMeasurementCode = "6u";
		subject.Amount = "R";
		subject.Amount2 = "V";
		//Test Parameters
		subject.NatureOfClaimCode = natureOfClaimCode;
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.ReferenceIdentificationQualifier) || !string.IsNullOrEmpty(subject.ReferenceIdentificationQualifier) || !string.IsNullOrEmpty(subject.ReferenceIdentification))
		{
			subject.ReferenceIdentificationQualifier = "QD";
			subject.ReferenceIdentification = "g";
		}
		if(!string.IsNullOrEmpty(subject.ReferenceIdentificationQualifier2) || !string.IsNullOrEmpty(subject.ReferenceIdentificationQualifier2) || !string.IsNullOrEmpty(subject.ReferenceIdentification2))
		{
			subject.ReferenceIdentificationQualifier2 = "7R";
			subject.ReferenceIdentification2 = "X";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("R", true)]
	public void Validation_RequiredAmount(string amount, bool isValidExpected)
	{
		var subject = new F09_DetailSupportingEvidenceForClaim();
		//Required fields
		subject.Quantity = 6;
		subject.UnitOrBasisForMeasurementCode = "6u";
		subject.NatureOfClaimCode = "yn";
		subject.Amount2 = "V";
		//Test Parameters
		subject.Amount = amount;
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.ReferenceIdentificationQualifier) || !string.IsNullOrEmpty(subject.ReferenceIdentificationQualifier) || !string.IsNullOrEmpty(subject.ReferenceIdentification))
		{
			subject.ReferenceIdentificationQualifier = "QD";
			subject.ReferenceIdentification = "g";
		}
		if(!string.IsNullOrEmpty(subject.ReferenceIdentificationQualifier2) || !string.IsNullOrEmpty(subject.ReferenceIdentificationQualifier2) || !string.IsNullOrEmpty(subject.ReferenceIdentification2))
		{
			subject.ReferenceIdentificationQualifier2 = "7R";
			subject.ReferenceIdentification2 = "X";
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
		subject.Quantity = 6;
		subject.UnitOrBasisForMeasurementCode = "6u";
		subject.NatureOfClaimCode = "yn";
		subject.Amount = "R";
		//Test Parameters
		subject.Amount2 = amount2;
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.ReferenceIdentificationQualifier) || !string.IsNullOrEmpty(subject.ReferenceIdentificationQualifier) || !string.IsNullOrEmpty(subject.ReferenceIdentification))
		{
			subject.ReferenceIdentificationQualifier = "QD";
			subject.ReferenceIdentification = "g";
		}
		if(!string.IsNullOrEmpty(subject.ReferenceIdentificationQualifier2) || !string.IsNullOrEmpty(subject.ReferenceIdentificationQualifier2) || !string.IsNullOrEmpty(subject.ReferenceIdentification2))
		{
			subject.ReferenceIdentificationQualifier2 = "7R";
			subject.ReferenceIdentification2 = "X";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("QD", "g", true)]
	[InlineData("QD", "", false)]
	[InlineData("", "g", false)]
	public void Validation_AllAreRequiredReferenceIdentificationQualifier(string referenceIdentificationQualifier, string referenceIdentification, bool isValidExpected)
	{
		var subject = new F09_DetailSupportingEvidenceForClaim();
		//Required fields
		subject.Quantity = 6;
		subject.UnitOrBasisForMeasurementCode = "6u";
		subject.NatureOfClaimCode = "yn";
		subject.Amount = "R";
		subject.Amount2 = "V";
		//Test Parameters
		subject.ReferenceIdentificationQualifier = referenceIdentificationQualifier;
		subject.ReferenceIdentification = referenceIdentification;
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.ReferenceIdentificationQualifier2) || !string.IsNullOrEmpty(subject.ReferenceIdentificationQualifier2) || !string.IsNullOrEmpty(subject.ReferenceIdentification2))
		{
			subject.ReferenceIdentificationQualifier2 = "7R";
			subject.ReferenceIdentification2 = "X";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("7R", "X", true)]
	[InlineData("7R", "", false)]
	[InlineData("", "X", false)]
	public void Validation_AllAreRequiredReferenceIdentificationQualifier2(string referenceIdentificationQualifier2, string referenceIdentification2, bool isValidExpected)
	{
		var subject = new F09_DetailSupportingEvidenceForClaim();
		//Required fields
		subject.Quantity = 6;
		subject.UnitOrBasisForMeasurementCode = "6u";
		subject.NatureOfClaimCode = "yn";
		subject.Amount = "R";
		subject.Amount2 = "V";
		//Test Parameters
		subject.ReferenceIdentificationQualifier2 = referenceIdentificationQualifier2;
		subject.ReferenceIdentification2 = referenceIdentification2;
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.ReferenceIdentificationQualifier) || !string.IsNullOrEmpty(subject.ReferenceIdentificationQualifier) || !string.IsNullOrEmpty(subject.ReferenceIdentification))
		{
			subject.ReferenceIdentificationQualifier = "QD";
			subject.ReferenceIdentification = "g";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

}
