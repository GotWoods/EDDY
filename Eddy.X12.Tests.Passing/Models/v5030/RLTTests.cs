using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v5030;

namespace Eddy.x12.Tests.Models.v5030;

public class RLTTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "RLT*Vq*r*Gk*f*y*pB*pK*6**0k*1*T9";

		var expected = new RLT_RealEstateLoanType()
		{
			ReferenceIdentificationQualifier = "Vq",
			ReferenceIdentification = "r",
			ReferenceIdentificationQualifier2 = "Gk",
			ReferenceIdentification2 = "f",
			RealEstateLoanTypeCode = "y",
			LoanPaymentTypeCode = "pB",
			QuantityQualifier = "pK",
			Quantity = 6,
			CompositeUnitOfMeasure = null,
			ReferenceIdentificationQualifier3 = "0k",
			ReferenceIdentification3 = "1",
			ProgramTypeCode = "T9",
		};

		var actual = Map.MapObject<RLT_RealEstateLoanType>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("Vq", true)]
	public void Validation_RequiredReferenceIdentificationQualifier(string referenceIdentificationQualifier, bool isValidExpected)
	{
		var subject = new RLT_RealEstateLoanType();
		//Required fields
		subject.ReferenceIdentification = "r";
		//Test Parameters
		subject.ReferenceIdentificationQualifier = referenceIdentificationQualifier;
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.ReferenceIdentificationQualifier2) || !string.IsNullOrEmpty(subject.ReferenceIdentificationQualifier2) || !string.IsNullOrEmpty(subject.ReferenceIdentification2))
		{
			subject.ReferenceIdentificationQualifier2 = "Gk";
			subject.ReferenceIdentification2 = "f";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("r", true)]
	public void Validation_RequiredReferenceIdentification(string referenceIdentification, bool isValidExpected)
	{
		var subject = new RLT_RealEstateLoanType();
		//Required fields
		subject.ReferenceIdentificationQualifier = "Vq";
		//Test Parameters
		subject.ReferenceIdentification = referenceIdentification;
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.ReferenceIdentificationQualifier2) || !string.IsNullOrEmpty(subject.ReferenceIdentificationQualifier2) || !string.IsNullOrEmpty(subject.ReferenceIdentification2))
		{
			subject.ReferenceIdentificationQualifier2 = "Gk";
			subject.ReferenceIdentification2 = "f";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("Gk", "f", true)]
	[InlineData("Gk", "", false)]
	[InlineData("", "f", false)]
	public void Validation_AllAreRequiredReferenceIdentificationQualifier2(string referenceIdentificationQualifier2, string referenceIdentification2, bool isValidExpected)
	{
		var subject = new RLT_RealEstateLoanType();
		//Required fields
		subject.ReferenceIdentificationQualifier = "Vq";
		subject.ReferenceIdentification = "r";
		//Test Parameters
		subject.ReferenceIdentificationQualifier2 = referenceIdentificationQualifier2;
		subject.ReferenceIdentification2 = referenceIdentification2;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("1", "0k", true)]
	[InlineData("1", "", false)]
	[InlineData("", "0k", true)]
	public void Validation_ARequiresBReferenceIdentification3(string referenceIdentification3, string referenceIdentificationQualifier3, bool isValidExpected)
	{
		var subject = new RLT_RealEstateLoanType();
		//Required fields
		subject.ReferenceIdentificationQualifier = "Vq";
		subject.ReferenceIdentification = "r";
		//Test Parameters
		subject.ReferenceIdentification3 = referenceIdentification3;
		subject.ReferenceIdentificationQualifier3 = referenceIdentificationQualifier3;
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.ReferenceIdentificationQualifier2) || !string.IsNullOrEmpty(subject.ReferenceIdentificationQualifier2) || !string.IsNullOrEmpty(subject.ReferenceIdentification2))
		{
			subject.ReferenceIdentificationQualifier2 = "Gk";
			subject.ReferenceIdentification2 = "f";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
	}

}
