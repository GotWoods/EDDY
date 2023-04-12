using Eddy.Core.Validation;
using Eddy.x12.Mapping;
using Eddy.x12.Models;

namespace Eddy.Tests.x12.Models;

public class RLTTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "RLT*wF*5*7m*c*N*FP*bY*8**Mj*Z*mI";

		var expected = new RLT_RealEstateLoanType()
		{
			ReferenceIdentificationQualifier = "wF",
			ReferenceIdentification = "5",
			ReferenceIdentificationQualifier2 = "7m",
			ReferenceIdentification2 = "c",
			RealEstateLoanTypeCode = "N",
			LoanPaymentTypeCode = "FP",
			QuantityQualifier = "bY",
			Quantity = 8,
			CompositeUnitOfMeasure = null,
			ReferenceIdentificationQualifier3 = "Mj",
			ReferenceIdentification3 = "Z",
			ProgramTypeCode = "mI",
		};

		var actual = Map.MapObject<RLT_RealEstateLoanType>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("wF", true)]
	public void Validation_RequiredReferenceIdentificationQualifier(string referenceIdentificationQualifier, bool isValidExpected)
	{
		var subject = new RLT_RealEstateLoanType();
		subject.ReferenceIdentification = "5";
		subject.ReferenceIdentificationQualifier = referenceIdentificationQualifier;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("5", true)]
	public void Validation_RequiredReferenceIdentification(string referenceIdentification, bool isValidExpected)
	{
		var subject = new RLT_RealEstateLoanType();
		subject.ReferenceIdentificationQualifier = "wF";
		subject.ReferenceIdentification = referenceIdentification;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("","", true)]
	[InlineData("7m", "c", true)]
	[InlineData("", "c", false)]
	[InlineData("7m", "", false)]
	public void Validation_AllAreRequiredReferenceIdentificationQualifier2(string referenceIdentificationQualifier2, string referenceIdentification2, bool isValidExpected)
	{
		var subject = new RLT_RealEstateLoanType();
		subject.ReferenceIdentificationQualifier = "wF";
		subject.ReferenceIdentification = "5";
		subject.ReferenceIdentificationQualifier2 = referenceIdentificationQualifier2;
		subject.ReferenceIdentification2 = referenceIdentification2;

		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("", "Mj", true)]
	[InlineData("Z", "", false)]
	public void Validation_ARequiresBReferenceIdentification3(string referenceIdentification3, string referenceIdentificationQualifier3, bool isValidExpected)
	{
		var subject = new RLT_RealEstateLoanType();
		subject.ReferenceIdentificationQualifier = "wF";
		subject.ReferenceIdentification = "5";
		subject.ReferenceIdentification3 = referenceIdentification3;
		subject.ReferenceIdentificationQualifier3 = referenceIdentificationQualifier3;

		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
	}

}
