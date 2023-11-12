using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v4030;

namespace Eddy.x12.Tests.Models.v4030;

public class RLTTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "RLT*8e*a*WM*Q*d*Xl*h9*3**Wz*B*H4";

		var expected = new RLT_RealEstateLoanType()
		{
			ReferenceIdentificationQualifier = "8e",
			ReferenceIdentification = "a",
			ReferenceIdentificationQualifier2 = "WM",
			ReferenceIdentification2 = "Q",
			RealEstateLoanTypeCode = "d",
			LoanPaymentTypeCode = "Xl",
			QuantityQualifier = "h9",
			Quantity = 3,
			CompositeUnitOfMeasure = null,
			ReferenceIdentificationQualifier3 = "Wz",
			ReferenceIdentification3 = "B",
			ProgramTypeCode = "H4",
		};

		var actual = Map.MapObject<RLT_RealEstateLoanType>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("8e", true)]
	public void Validation_RequiredReferenceIdentificationQualifier(string referenceIdentificationQualifier, bool isValidExpected)
	{
		var subject = new RLT_RealEstateLoanType();
		//Required fields
		subject.ReferenceIdentification = "a";
		//Test Parameters
		subject.ReferenceIdentificationQualifier = referenceIdentificationQualifier;
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.ReferenceIdentificationQualifier2) || !string.IsNullOrEmpty(subject.ReferenceIdentificationQualifier2) || !string.IsNullOrEmpty(subject.ReferenceIdentification2))
		{
			subject.ReferenceIdentificationQualifier2 = "WM";
			subject.ReferenceIdentification2 = "Q";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("a", true)]
	public void Validation_RequiredReferenceIdentification(string referenceIdentification, bool isValidExpected)
	{
		var subject = new RLT_RealEstateLoanType();
		//Required fields
		subject.ReferenceIdentificationQualifier = "8e";
		//Test Parameters
		subject.ReferenceIdentification = referenceIdentification;
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.ReferenceIdentificationQualifier2) || !string.IsNullOrEmpty(subject.ReferenceIdentificationQualifier2) || !string.IsNullOrEmpty(subject.ReferenceIdentification2))
		{
			subject.ReferenceIdentificationQualifier2 = "WM";
			subject.ReferenceIdentification2 = "Q";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("WM", "Q", true)]
	[InlineData("WM", "", false)]
	[InlineData("", "Q", false)]
	public void Validation_AllAreRequiredReferenceIdentificationQualifier2(string referenceIdentificationQualifier2, string referenceIdentification2, bool isValidExpected)
	{
		var subject = new RLT_RealEstateLoanType();
		//Required fields
		subject.ReferenceIdentificationQualifier = "8e";
		subject.ReferenceIdentification = "a";
		//Test Parameters
		subject.ReferenceIdentificationQualifier2 = referenceIdentificationQualifier2;
		subject.ReferenceIdentification2 = referenceIdentification2;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("B", "Wz", true)]
	[InlineData("B", "", false)]
	[InlineData("", "Wz", true)]
	public void Validation_ARequiresBReferenceIdentification3(string referenceIdentification3, string referenceIdentificationQualifier3, bool isValidExpected)
	{
		var subject = new RLT_RealEstateLoanType();
		//Required fields
		subject.ReferenceIdentificationQualifier = "8e";
		subject.ReferenceIdentification = "a";
		//Test Parameters
		subject.ReferenceIdentification3 = referenceIdentification3;
		subject.ReferenceIdentificationQualifier3 = referenceIdentificationQualifier3;
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.ReferenceIdentificationQualifier2) || !string.IsNullOrEmpty(subject.ReferenceIdentificationQualifier2) || !string.IsNullOrEmpty(subject.ReferenceIdentification2))
		{
			subject.ReferenceIdentificationQualifier2 = "WM";
			subject.ReferenceIdentification2 = "Q";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
	}

}
