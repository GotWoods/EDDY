using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v4030;

namespace Eddy.x12.Tests.Models.v4030;

public class MIITests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "MII*K*h*I*B*i*g*W*5*pd*6*Nt*W*6**2";

		var expected = new MII_MortgageInsuranceInformation()
		{
			MortgageInsuranceApplicationType = "K",
			MortgageInsurancePremiumTypeCode = "h",
			YesNoConditionOrResponseCode = "I",
			MortgageInsuranceCertificateTypeCode = "B",
			MortgageInsuranceCoverageTypeCode = "i",
			MortgageInsuranceDurationCode = "g",
			MortgageInsuranceRenewalOptionCode = "W",
			MonetaryAmount = 5,
			ReferenceIdentificationQualifier = "pd",
			ReferenceIdentification = "6",
			ProductServiceIDQualifier = "Nt",
			ProductServiceID = "W",
			Percent = 6,
			CompositeUnitOfMeasure = null,
			Quantity = 2,
		};

		var actual = Map.MapObject<MII_MortgageInsuranceInformation>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("K", true)]
	public void Validation_RequiredMortgageInsuranceApplicationType(string mortgageInsuranceApplicationType, bool isValidExpected)
	{
		var subject = new MII_MortgageInsuranceInformation();
		//Required fields
		//Test Parameters
		subject.MortgageInsuranceApplicationType = mortgageInsuranceApplicationType;
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.ReferenceIdentificationQualifier) || !string.IsNullOrEmpty(subject.ReferenceIdentificationQualifier) || !string.IsNullOrEmpty(subject.ReferenceIdentification))
		{
			subject.ReferenceIdentificationQualifier = "pd";
			subject.ReferenceIdentification = "6";
		}
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier) || !string.IsNullOrEmpty(subject.ProductServiceID))
		{
			subject.ProductServiceIDQualifier = "Nt";
			subject.ProductServiceID = "W";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("pd", "6", true)]
	[InlineData("pd", "", false)]
	[InlineData("", "6", false)]
	public void Validation_AllAreRequiredReferenceIdentificationQualifier(string referenceIdentificationQualifier, string referenceIdentification, bool isValidExpected)
	{
		var subject = new MII_MortgageInsuranceInformation();
		//Required fields
		subject.MortgageInsuranceApplicationType = "K";
		//Test Parameters
		subject.ReferenceIdentificationQualifier = referenceIdentificationQualifier;
		subject.ReferenceIdentification = referenceIdentification;
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier) || !string.IsNullOrEmpty(subject.ProductServiceID))
		{
			subject.ProductServiceIDQualifier = "Nt";
			subject.ProductServiceID = "W";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("Nt", "W", true)]
	[InlineData("Nt", "", false)]
	[InlineData("", "W", false)]
	public void Validation_AllAreRequiredProductServiceIDQualifier(string productServiceIDQualifier, string productServiceID, bool isValidExpected)
	{
		var subject = new MII_MortgageInsuranceInformation();
		//Required fields
		subject.MortgageInsuranceApplicationType = "K";
		//Test Parameters
		subject.ProductServiceIDQualifier = productServiceIDQualifier;
		subject.ProductServiceID = productServiceID;
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.ReferenceIdentificationQualifier) || !string.IsNullOrEmpty(subject.ReferenceIdentificationQualifier) || !string.IsNullOrEmpty(subject.ReferenceIdentification))
		{
			subject.ReferenceIdentificationQualifier = "pd";
			subject.ReferenceIdentification = "6";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

}
