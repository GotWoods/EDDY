using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3010;

namespace Eddy.x12.Tests.Models.v3010;

public class F03Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "F03*6*dr*d*W5*r*q*UE*2*nK*a*bc*Z*z*03MqN";

		var expected = new F03_DetailSupportingEvidenceForClaim()
		{
			Quantity = 6,
			UnitOfMeasurementCode = "dr",
			LadingDescription = "d",
			NatureOfClaimCode = "W5",
			Amount = "r",
			Amount2 = "q",
			ReferenceNumberQualifier = "UE",
			ReferenceNumber = "2",
			ReferenceNumberQualifier2 = "nK",
			ReferenceNumber2 = "a",
			NatureOfClaimCode2 = "bc",
			FreeFormDescription = "Z",
			LadingDescription2 = "z",
			PackagingCode = "03MqN",
		};

		var actual = Map.MapObject<F03_DetailSupportingEvidenceForClaim>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData(0, false)]
	[InlineData(6, true)]
	public void Validation_RequiredQuantity(decimal quantity, bool isValidExpected)
	{
		var subject = new F03_DetailSupportingEvidenceForClaim();
		subject.UnitOfMeasurementCode = "dr";
		subject.LadingDescription = "d";
		subject.NatureOfClaimCode = "W5";
		subject.Amount = "r";
		subject.Amount2 = "q";
		subject.NatureOfClaimCode2 = "bc";
		subject.LadingDescription2 = "z";
		if (quantity > 0)
			subject.Quantity = quantity;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("dr", true)]
	public void Validation_RequiredUnitOfMeasurementCode(string unitOfMeasurementCode, bool isValidExpected)
	{
		var subject = new F03_DetailSupportingEvidenceForClaim();
		subject.Quantity = 6;
		subject.LadingDescription = "d";
		subject.NatureOfClaimCode = "W5";
		subject.Amount = "r";
		subject.Amount2 = "q";
		subject.NatureOfClaimCode2 = "bc";
		subject.LadingDescription2 = "z";
		subject.UnitOfMeasurementCode = unitOfMeasurementCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("d", true)]
	public void Validation_RequiredLadingDescription(string ladingDescription, bool isValidExpected)
	{
		var subject = new F03_DetailSupportingEvidenceForClaim();
		subject.Quantity = 6;
		subject.UnitOfMeasurementCode = "dr";
		subject.NatureOfClaimCode = "W5";
		subject.Amount = "r";
		subject.Amount2 = "q";
		subject.NatureOfClaimCode2 = "bc";
		subject.LadingDescription2 = "z";
		subject.LadingDescription = ladingDescription;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("W5", true)]
	public void Validation_RequiredNatureOfClaimCode(string natureOfClaimCode, bool isValidExpected)
	{
		var subject = new F03_DetailSupportingEvidenceForClaim();
		subject.Quantity = 6;
		subject.UnitOfMeasurementCode = "dr";
		subject.LadingDescription = "d";
		subject.Amount = "r";
		subject.Amount2 = "q";
		subject.NatureOfClaimCode2 = "bc";
		subject.LadingDescription2 = "z";
		subject.NatureOfClaimCode = natureOfClaimCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("r", true)]
	public void Validation_RequiredAmount(string amount, bool isValidExpected)
	{
		var subject = new F03_DetailSupportingEvidenceForClaim();
		subject.Quantity = 6;
		subject.UnitOfMeasurementCode = "dr";
		subject.LadingDescription = "d";
		subject.NatureOfClaimCode = "W5";
		subject.Amount2 = "q";
		subject.NatureOfClaimCode2 = "bc";
		subject.LadingDescription2 = "z";
		subject.Amount = amount;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("q", true)]
	public void Validation_RequiredAmount2(string amount2, bool isValidExpected)
	{
		var subject = new F03_DetailSupportingEvidenceForClaim();
		subject.Quantity = 6;
		subject.UnitOfMeasurementCode = "dr";
		subject.LadingDescription = "d";
		subject.NatureOfClaimCode = "W5";
		subject.Amount = "r";
		subject.NatureOfClaimCode2 = "bc";
		subject.LadingDescription2 = "z";
		subject.Amount2 = amount2;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("bc", true)]
	public void Validation_RequiredNatureOfClaimCode2(string natureOfClaimCode2, bool isValidExpected)
	{
		var subject = new F03_DetailSupportingEvidenceForClaim();
		subject.Quantity = 6;
		subject.UnitOfMeasurementCode = "dr";
		subject.LadingDescription = "d";
		subject.NatureOfClaimCode = "W5";
		subject.Amount = "r";
		subject.Amount2 = "q";
		subject.LadingDescription2 = "z";
		subject.NatureOfClaimCode2 = natureOfClaimCode2;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("z", true)]
	public void Validation_RequiredLadingDescription2(string ladingDescription2, bool isValidExpected)
	{
		var subject = new F03_DetailSupportingEvidenceForClaim();
		subject.Quantity = 6;
		subject.UnitOfMeasurementCode = "dr";
		subject.LadingDescription = "d";
		subject.NatureOfClaimCode = "W5";
		subject.Amount = "r";
		subject.Amount2 = "q";
		subject.NatureOfClaimCode2 = "bc";
		subject.LadingDescription2 = ladingDescription2;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
