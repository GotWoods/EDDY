using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v4010;

namespace Eddy.x12.Tests.Models.v4010;

public class MIITests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "MII*J*P*R*J*f*P*e*4*rJ*k*u6*5*8**1";

		var expected = new MII_MortgageInsuranceInformation()
		{
			MortgageInsuranceApplicationType = "J",
			MortgageInsurancePremiumTypeCode = "P",
			YesNoConditionOrResponseCode = "R",
			MortgageInsuranceCertificateTypeCode = "J",
			MortgageInsuranceCoverageTypeCode = "f",
			MortgageInsuranceDurationCode = "P",
			MortgageInsuranceRenewalOptionCode = "e",
			MonetaryAmount = 4,
			ReferenceIdentificationQualifier = "rJ",
			ReferenceIdentification = "k",
			ProductServiceIDQualifier = "u6",
			ProductServiceID = "5",
			Percent = 8,
			CompositeUnitOfMeasure = null,
			Quantity = 1,
		};

		var actual = Map.MapObject<MII_MortgageInsuranceInformation>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("J", true)]
	public void Validation_RequiredMortgageInsuranceApplicationType(string mortgageInsuranceApplicationType, bool isValidExpected)
	{
		var subject = new MII_MortgageInsuranceInformation();
		//Required fields
		//Test Parameters
		subject.MortgageInsuranceApplicationType = mortgageInsuranceApplicationType;
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.ReferenceIdentificationQualifier) || !string.IsNullOrEmpty(subject.ReferenceIdentificationQualifier) || !string.IsNullOrEmpty(subject.ReferenceIdentification))
		{
			subject.ReferenceIdentificationQualifier = "rJ";
			subject.ReferenceIdentification = "k";
		}
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier) || !string.IsNullOrEmpty(subject.ProductServiceID))
		{
			subject.ProductServiceIDQualifier = "u6";
			subject.ProductServiceID = "5";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("rJ", "k", true)]
	[InlineData("rJ", "", false)]
	[InlineData("", "k", false)]
	public void Validation_AllAreRequiredReferenceIdentificationQualifier(string referenceIdentificationQualifier, string referenceIdentification, bool isValidExpected)
	{
		var subject = new MII_MortgageInsuranceInformation();
		//Required fields
		subject.MortgageInsuranceApplicationType = "J";
		//Test Parameters
		subject.ReferenceIdentificationQualifier = referenceIdentificationQualifier;
		subject.ReferenceIdentification = referenceIdentification;
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier) || !string.IsNullOrEmpty(subject.ProductServiceID))
		{
			subject.ProductServiceIDQualifier = "u6";
			subject.ProductServiceID = "5";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("u6", "5", true)]
	[InlineData("u6", "", false)]
	[InlineData("", "5", false)]
	public void Validation_AllAreRequiredProductServiceIDQualifier(string productServiceIDQualifier, string productServiceID, bool isValidExpected)
	{
		var subject = new MII_MortgageInsuranceInformation();
		//Required fields
		subject.MortgageInsuranceApplicationType = "J";
		//Test Parameters
		subject.ProductServiceIDQualifier = productServiceIDQualifier;
		subject.ProductServiceID = productServiceID;
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.ReferenceIdentificationQualifier) || !string.IsNullOrEmpty(subject.ReferenceIdentificationQualifier) || !string.IsNullOrEmpty(subject.ReferenceIdentification))
		{
			subject.ReferenceIdentificationQualifier = "rJ";
			subject.ReferenceIdentification = "k";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

}
