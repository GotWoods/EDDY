using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v4030;

namespace Eddy.x12.Tests.Models.v4030;

public class F09Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "F09*1*5C*HD*5*t*h*L*qr*r*6L*0*1";

		var expected = new F09_DetailSupportingEvidenceForClaim()
		{
			Quantity = 1,
			UnitOrBasisForMeasurementCode = "5C",
			NatureOfClaimCode = "HD",
			Amount = "5",
			Amount2 = "t",
			Description = "h",
			LadingDescription = "L",
			ReferenceIdentificationQualifier = "qr",
			ReferenceIdentification = "r",
			ReferenceIdentificationQualifier2 = "6L",
			ReferenceIdentification2 = "0",
			LadingLineItemNumber = 1,
		};

		var actual = Map.MapObject<F09_DetailSupportingEvidenceForClaim>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData(0, false)]
	[InlineData(1, true)]
	public void Validation_RequiredQuantity(decimal quantity, bool isValidExpected)
	{
		var subject = new F09_DetailSupportingEvidenceForClaim();
		//Required fields
		subject.UnitOrBasisForMeasurementCode = "5C";
		subject.NatureOfClaimCode = "HD";
		subject.Amount = "5";
		subject.Amount2 = "t";
		//Test Parameters
		if (quantity > 0) 
			subject.Quantity = quantity;
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.ReferenceIdentificationQualifier) || !string.IsNullOrEmpty(subject.ReferenceIdentificationQualifier) || !string.IsNullOrEmpty(subject.ReferenceIdentification))
		{
			subject.ReferenceIdentificationQualifier = "qr";
			subject.ReferenceIdentification = "r";
		}
		if(!string.IsNullOrEmpty(subject.ReferenceIdentificationQualifier2) || !string.IsNullOrEmpty(subject.ReferenceIdentificationQualifier2) || !string.IsNullOrEmpty(subject.ReferenceIdentification2))
		{
			subject.ReferenceIdentificationQualifier2 = "6L";
			subject.ReferenceIdentification2 = "0";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("5C", true)]
	public void Validation_RequiredUnitOrBasisForMeasurementCode(string unitOrBasisForMeasurementCode, bool isValidExpected)
	{
		var subject = new F09_DetailSupportingEvidenceForClaim();
		//Required fields
		subject.Quantity = 1;
		subject.NatureOfClaimCode = "HD";
		subject.Amount = "5";
		subject.Amount2 = "t";
		//Test Parameters
		subject.UnitOrBasisForMeasurementCode = unitOrBasisForMeasurementCode;
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.ReferenceIdentificationQualifier) || !string.IsNullOrEmpty(subject.ReferenceIdentificationQualifier) || !string.IsNullOrEmpty(subject.ReferenceIdentification))
		{
			subject.ReferenceIdentificationQualifier = "qr";
			subject.ReferenceIdentification = "r";
		}
		if(!string.IsNullOrEmpty(subject.ReferenceIdentificationQualifier2) || !string.IsNullOrEmpty(subject.ReferenceIdentificationQualifier2) || !string.IsNullOrEmpty(subject.ReferenceIdentification2))
		{
			subject.ReferenceIdentificationQualifier2 = "6L";
			subject.ReferenceIdentification2 = "0";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("HD", true)]
	public void Validation_RequiredNatureOfClaimCode(string natureOfClaimCode, bool isValidExpected)
	{
		var subject = new F09_DetailSupportingEvidenceForClaim();
		//Required fields
		subject.Quantity = 1;
		subject.UnitOrBasisForMeasurementCode = "5C";
		subject.Amount = "5";
		subject.Amount2 = "t";
		//Test Parameters
		subject.NatureOfClaimCode = natureOfClaimCode;
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.ReferenceIdentificationQualifier) || !string.IsNullOrEmpty(subject.ReferenceIdentificationQualifier) || !string.IsNullOrEmpty(subject.ReferenceIdentification))
		{
			subject.ReferenceIdentificationQualifier = "qr";
			subject.ReferenceIdentification = "r";
		}
		if(!string.IsNullOrEmpty(subject.ReferenceIdentificationQualifier2) || !string.IsNullOrEmpty(subject.ReferenceIdentificationQualifier2) || !string.IsNullOrEmpty(subject.ReferenceIdentification2))
		{
			subject.ReferenceIdentificationQualifier2 = "6L";
			subject.ReferenceIdentification2 = "0";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("5", true)]
	public void Validation_RequiredAmount(string amount, bool isValidExpected)
	{
		var subject = new F09_DetailSupportingEvidenceForClaim();
		//Required fields
		subject.Quantity = 1;
		subject.UnitOrBasisForMeasurementCode = "5C";
		subject.NatureOfClaimCode = "HD";
		subject.Amount2 = "t";
		//Test Parameters
		subject.Amount = amount;
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.ReferenceIdentificationQualifier) || !string.IsNullOrEmpty(subject.ReferenceIdentificationQualifier) || !string.IsNullOrEmpty(subject.ReferenceIdentification))
		{
			subject.ReferenceIdentificationQualifier = "qr";
			subject.ReferenceIdentification = "r";
		}
		if(!string.IsNullOrEmpty(subject.ReferenceIdentificationQualifier2) || !string.IsNullOrEmpty(subject.ReferenceIdentificationQualifier2) || !string.IsNullOrEmpty(subject.ReferenceIdentification2))
		{
			subject.ReferenceIdentificationQualifier2 = "6L";
			subject.ReferenceIdentification2 = "0";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("t", true)]
	public void Validation_RequiredAmount2(string amount2, bool isValidExpected)
	{
		var subject = new F09_DetailSupportingEvidenceForClaim();
		//Required fields
		subject.Quantity = 1;
		subject.UnitOrBasisForMeasurementCode = "5C";
		subject.NatureOfClaimCode = "HD";
		subject.Amount = "5";
		//Test Parameters
		subject.Amount2 = amount2;
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.ReferenceIdentificationQualifier) || !string.IsNullOrEmpty(subject.ReferenceIdentificationQualifier) || !string.IsNullOrEmpty(subject.ReferenceIdentification))
		{
			subject.ReferenceIdentificationQualifier = "qr";
			subject.ReferenceIdentification = "r";
		}
		if(!string.IsNullOrEmpty(subject.ReferenceIdentificationQualifier2) || !string.IsNullOrEmpty(subject.ReferenceIdentificationQualifier2) || !string.IsNullOrEmpty(subject.ReferenceIdentification2))
		{
			subject.ReferenceIdentificationQualifier2 = "6L";
			subject.ReferenceIdentification2 = "0";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("qr", "r", true)]
	[InlineData("qr", "", false)]
	[InlineData("", "r", false)]
	public void Validation_AllAreRequiredReferenceIdentificationQualifier(string referenceIdentificationQualifier, string referenceIdentification, bool isValidExpected)
	{
		var subject = new F09_DetailSupportingEvidenceForClaim();
		//Required fields
		subject.Quantity = 1;
		subject.UnitOrBasisForMeasurementCode = "5C";
		subject.NatureOfClaimCode = "HD";
		subject.Amount = "5";
		subject.Amount2 = "t";
		//Test Parameters
		subject.ReferenceIdentificationQualifier = referenceIdentificationQualifier;
		subject.ReferenceIdentification = referenceIdentification;
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.ReferenceIdentificationQualifier2) || !string.IsNullOrEmpty(subject.ReferenceIdentificationQualifier2) || !string.IsNullOrEmpty(subject.ReferenceIdentification2))
		{
			subject.ReferenceIdentificationQualifier2 = "6L";
			subject.ReferenceIdentification2 = "0";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("6L", "0", true)]
	[InlineData("6L", "", false)]
	[InlineData("", "0", false)]
	public void Validation_AllAreRequiredReferenceIdentificationQualifier2(string referenceIdentificationQualifier2, string referenceIdentification2, bool isValidExpected)
	{
		var subject = new F09_DetailSupportingEvidenceForClaim();
		//Required fields
		subject.Quantity = 1;
		subject.UnitOrBasisForMeasurementCode = "5C";
		subject.NatureOfClaimCode = "HD";
		subject.Amount = "5";
		subject.Amount2 = "t";
		//Test Parameters
		subject.ReferenceIdentificationQualifier2 = referenceIdentificationQualifier2;
		subject.ReferenceIdentification2 = referenceIdentification2;
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.ReferenceIdentificationQualifier) || !string.IsNullOrEmpty(subject.ReferenceIdentificationQualifier) || !string.IsNullOrEmpty(subject.ReferenceIdentification))
		{
			subject.ReferenceIdentificationQualifier = "qr";
			subject.ReferenceIdentification = "r";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

}
