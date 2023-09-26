using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3060;

namespace Eddy.x12.Tests.Models.v3060;

public class RLTTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "RLT*db*G*F9*L*e*sD*jB*6**vx*r*YO";

		var expected = new RLT_RealEstateLoanType()
		{
			ReferenceIdentificationQualifier = "db",
			ReferenceIdentification = "G",
			ReferenceIdentificationQualifier2 = "F9",
			ReferenceIdentification2 = "L",
			RealEstateLoanTypeCode = "e",
			LoanPaymentTypeCode = "sD",
			QuantityQualifier = "jB",
			Quantity = 6,
			CompositeUnitOfMeasure = null,
			ReferenceIdentificationQualifier3 = "vx",
			ReferenceIdentification3 = "r",
			ProgramTypeCode = "YO",
		};

		var actual = Map.MapObject<RLT_RealEstateLoanType>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("db", true)]
	public void Validation_RequiredReferenceIdentificationQualifier(string referenceIdentificationQualifier, bool isValidExpected)
	{
		var subject = new RLT_RealEstateLoanType();
		//Required fields
		subject.ReferenceIdentification = "G";
		//Test Parameters
		subject.ReferenceIdentificationQualifier = referenceIdentificationQualifier;
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.ReferenceIdentificationQualifier2) || !string.IsNullOrEmpty(subject.ReferenceIdentificationQualifier2) || !string.IsNullOrEmpty(subject.ReferenceIdentification2))
		{
			subject.ReferenceIdentificationQualifier2 = "F9";
			subject.ReferenceIdentification2 = "L";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("G", true)]
	public void Validation_RequiredReferenceIdentification(string referenceIdentification, bool isValidExpected)
	{
		var subject = new RLT_RealEstateLoanType();
		//Required fields
		subject.ReferenceIdentificationQualifier = "db";
		//Test Parameters
		subject.ReferenceIdentification = referenceIdentification;
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.ReferenceIdentificationQualifier2) || !string.IsNullOrEmpty(subject.ReferenceIdentificationQualifier2) || !string.IsNullOrEmpty(subject.ReferenceIdentification2))
		{
			subject.ReferenceIdentificationQualifier2 = "F9";
			subject.ReferenceIdentification2 = "L";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("F9", "L", true)]
	[InlineData("F9", "", false)]
	[InlineData("", "L", false)]
	public void Validation_AllAreRequiredReferenceIdentificationQualifier2(string referenceIdentificationQualifier2, string referenceIdentification2, bool isValidExpected)
	{
		var subject = new RLT_RealEstateLoanType();
		//Required fields
		subject.ReferenceIdentificationQualifier = "db";
		subject.ReferenceIdentification = "G";
		//Test Parameters
		subject.ReferenceIdentificationQualifier2 = referenceIdentificationQualifier2;
		subject.ReferenceIdentification2 = referenceIdentification2;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("r", "vx", true)]
	[InlineData("r", "", false)]
	[InlineData("", "vx", true)]
	public void Validation_ARequiresBReferenceIdentification3(string referenceIdentification3, string referenceIdentificationQualifier3, bool isValidExpected)
	{
		var subject = new RLT_RealEstateLoanType();
		//Required fields
		subject.ReferenceIdentificationQualifier = "db";
		subject.ReferenceIdentification = "G";
		//Test Parameters
		subject.ReferenceIdentification3 = referenceIdentification3;
		subject.ReferenceIdentificationQualifier3 = referenceIdentificationQualifier3;
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.ReferenceIdentificationQualifier2) || !string.IsNullOrEmpty(subject.ReferenceIdentificationQualifier2) || !string.IsNullOrEmpty(subject.ReferenceIdentification2))
		{
			subject.ReferenceIdentificationQualifier2 = "F9";
			subject.ReferenceIdentification2 = "L";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
	}

}
