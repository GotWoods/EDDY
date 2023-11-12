using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3050;

namespace Eddy.x12.Tests.Models.v3050;

public class RLTTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "RLT*Ff*3*LW*o*e*Af*rU*3**G0*L*cT";

		var expected = new RLT_RealEstateLoanType()
		{
			ReferenceNumberQualifier = "Ff",
			ReferenceNumber = "3",
			ReferenceNumberQualifier2 = "LW",
			ReferenceNumber2 = "o",
			RealEstateLoanTypeCode = "e",
			LoanPaymentTypeCode = "Af",
			QuantityQualifier = "rU",
			Quantity = 3,
			CompositeUnitOfMeasure = null,
			ReferenceNumberQualifier3 = "G0",
			ReferenceNumber3 = "L",
			ProgramTypeCode = "cT",
		};

		var actual = Map.MapObject<RLT_RealEstateLoanType>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("Ff", true)]
	public void Validation_RequiredReferenceNumberQualifier(string referenceNumberQualifier, bool isValidExpected)
	{
		var subject = new RLT_RealEstateLoanType();
		//Required fields
		subject.ReferenceNumber = "3";
		//Test Parameters
		subject.ReferenceNumberQualifier = referenceNumberQualifier;
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.ReferenceNumberQualifier2) || !string.IsNullOrEmpty(subject.ReferenceNumberQualifier2) || !string.IsNullOrEmpty(subject.ReferenceNumber2))
		{
			subject.ReferenceNumberQualifier2 = "LW";
			subject.ReferenceNumber2 = "o";
		}
		if(!string.IsNullOrEmpty(subject.ReferenceNumberQualifier3) || !string.IsNullOrEmpty(subject.ReferenceNumberQualifier3) || !string.IsNullOrEmpty(subject.ReferenceNumber3))
		{
			subject.ReferenceNumberQualifier3 = "G0";
			subject.ReferenceNumber3 = "L";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("3", true)]
	public void Validation_RequiredReferenceNumber(string referenceNumber, bool isValidExpected)
	{
		var subject = new RLT_RealEstateLoanType();
		//Required fields
		subject.ReferenceNumberQualifier = "Ff";
		//Test Parameters
		subject.ReferenceNumber = referenceNumber;
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.ReferenceNumberQualifier2) || !string.IsNullOrEmpty(subject.ReferenceNumberQualifier2) || !string.IsNullOrEmpty(subject.ReferenceNumber2))
		{
			subject.ReferenceNumberQualifier2 = "LW";
			subject.ReferenceNumber2 = "o";
		}
		if(!string.IsNullOrEmpty(subject.ReferenceNumberQualifier3) || !string.IsNullOrEmpty(subject.ReferenceNumberQualifier3) || !string.IsNullOrEmpty(subject.ReferenceNumber3))
		{
			subject.ReferenceNumberQualifier3 = "G0";
			subject.ReferenceNumber3 = "L";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("LW", "o", true)]
	[InlineData("LW", "", false)]
	[InlineData("", "o", false)]
	public void Validation_AllAreRequiredReferenceNumberQualifier2(string referenceNumberQualifier2, string referenceNumber2, bool isValidExpected)
	{
		var subject = new RLT_RealEstateLoanType();
		//Required fields
		subject.ReferenceNumberQualifier = "Ff";
		subject.ReferenceNumber = "3";
		//Test Parameters
		subject.ReferenceNumberQualifier2 = referenceNumberQualifier2;
		subject.ReferenceNumber2 = referenceNumber2;
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.ReferenceNumberQualifier3) || !string.IsNullOrEmpty(subject.ReferenceNumberQualifier3) || !string.IsNullOrEmpty(subject.ReferenceNumber3))
		{
			subject.ReferenceNumberQualifier3 = "G0";
			subject.ReferenceNumber3 = "L";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("G0", "L", true)]
	[InlineData("G0", "", false)]
	[InlineData("", "L", false)]
	public void Validation_AllAreRequiredReferenceNumberQualifier3(string referenceNumberQualifier3, string referenceNumber3, bool isValidExpected)
	{
		var subject = new RLT_RealEstateLoanType();
		//Required fields
		subject.ReferenceNumberQualifier = "Ff";
		subject.ReferenceNumber = "3";
		//Test Parameters
		subject.ReferenceNumberQualifier3 = referenceNumberQualifier3;
		subject.ReferenceNumber3 = referenceNumber3;
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.ReferenceNumberQualifier2) || !string.IsNullOrEmpty(subject.ReferenceNumberQualifier2) || !string.IsNullOrEmpty(subject.ReferenceNumber2))
		{
			subject.ReferenceNumberQualifier2 = "LW";
			subject.ReferenceNumber2 = "o";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

}
