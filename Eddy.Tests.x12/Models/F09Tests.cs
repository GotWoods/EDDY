using Eddy.Core.Validation;
using Eddy.x12.Mapping;
using Eddy.x12.Models;

namespace Eddy.Tests.x12.Models;

public class F09Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "F09*3*jT*Wt*C*C*l*b*go*w*8S*Q*4";

		var expected = new F09_DetailSupportingEvidenceForClaim()
		{
			Quantity = 3,
			UnitOrBasisForMeasurementCode = "jT",
			NatureOfClaimCode = "Wt",
			Amount = "C",
			Amount2 = "C",
			Description = "l",
			LadingDescription = "b",
			ReferenceIdentificationQualifier = "go",
			ReferenceIdentification = "w",
			ReferenceIdentificationQualifier2 = "8S",
			ReferenceIdentification2 = "Q",
			LadingLineItemNumber = 4,
		};

		var actual = Map.MapObject<F09_DetailSupportingEvidenceForClaim>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData(0, false)]
	[InlineData(3, true)]
	public void Validation_RequiredQuantity(decimal quantity, bool isValidExpected)
	{
		var subject = new F09_DetailSupportingEvidenceForClaim();
		subject.UnitOrBasisForMeasurementCode = "jT";
		subject.NatureOfClaimCode = "Wt";
		subject.Amount = "C";
		subject.Amount2 = "C";
		if (quantity > 0)
		subject.Quantity = quantity;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("jT", true)]
	public void Validation_RequiredUnitOrBasisForMeasurementCode(string unitOrBasisForMeasurementCode, bool isValidExpected)
	{
		var subject = new F09_DetailSupportingEvidenceForClaim();
		subject.Quantity = 3;
		subject.NatureOfClaimCode = "Wt";
		subject.Amount = "C";
		subject.Amount2 = "C";
		subject.UnitOrBasisForMeasurementCode = unitOrBasisForMeasurementCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("Wt", true)]
	public void Validation_RequiredNatureOfClaimCode(string natureOfClaimCode, bool isValidExpected)
	{
		var subject = new F09_DetailSupportingEvidenceForClaim();
		subject.Quantity = 3;
		subject.UnitOrBasisForMeasurementCode = "jT";
		subject.Amount = "C";
		subject.Amount2 = "C";
		subject.NatureOfClaimCode = natureOfClaimCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("C", true)]
	public void Validation_RequiredAmount(string amount, bool isValidExpected)
	{
		var subject = new F09_DetailSupportingEvidenceForClaim();
		subject.Quantity = 3;
		subject.UnitOrBasisForMeasurementCode = "jT";
		subject.NatureOfClaimCode = "Wt";
		subject.Amount2 = "C";
		subject.Amount = amount;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("C", true)]
	public void Validation_RequiredAmount2(string amount2, bool isValidExpected)
	{
		var subject = new F09_DetailSupportingEvidenceForClaim();
		subject.Quantity = 3;
		subject.UnitOrBasisForMeasurementCode = "jT";
		subject.NatureOfClaimCode = "Wt";
		subject.Amount = "C";
		subject.Amount2 = amount2;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("","", true)]
	[InlineData("go", "w", true)]
	[InlineData("", "w", false)]
	[InlineData("go", "", false)]
	public void Validation_AllAreRequiredReferenceIdentificationQualifier(string referenceIdentificationQualifier, string referenceIdentification, bool isValidExpected)
	{
		var subject = new F09_DetailSupportingEvidenceForClaim();
		subject.Quantity = 3;
		subject.UnitOrBasisForMeasurementCode = "jT";
		subject.NatureOfClaimCode = "Wt";
		subject.Amount = "C";
		subject.Amount2 = "C";
		subject.ReferenceIdentificationQualifier = referenceIdentificationQualifier;
		subject.ReferenceIdentification = referenceIdentification;

		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

	[Theory]
	[InlineData("","", true)]
	[InlineData("8S", "Q", true)]
	[InlineData("", "Q", false)]
	[InlineData("8S", "", false)]
	public void Validation_AllAreRequiredReferenceIdentificationQualifier2(string referenceIdentificationQualifier2, string referenceIdentification2, bool isValidExpected)
	{
		var subject = new F09_DetailSupportingEvidenceForClaim();
		subject.Quantity = 3;
		subject.UnitOrBasisForMeasurementCode = "jT";
		subject.NatureOfClaimCode = "Wt";
		subject.Amount = "C";
		subject.Amount2 = "C";
		subject.ReferenceIdentificationQualifier2 = referenceIdentificationQualifier2;
		subject.ReferenceIdentification2 = referenceIdentification2;

		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

}
