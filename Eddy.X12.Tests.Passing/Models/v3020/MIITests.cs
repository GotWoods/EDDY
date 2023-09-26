using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3020;

namespace Eddy.x12.Tests.Models.v3020;

public class MIITests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "MII*M*s*J*V*u*1*P*1*Ag*0*a5*2*9*Ms*9";

		var expected = new MII_MortgageInsuranceInformation()
		{
			MortgageInsuranceApplicationType = "M",
			MortgageInsurancePremiumSourceCode = "s",
			YesNoConditionOrResponseCode = "J",
			MortgageInsuranceCertificateTypeCode = "V",
			MortgageInsuranceCoverageTypeCode = "u",
			MortgageInsuranceDurationCode = "1",
			MortgageInsuranceRenewalOptionCode = "P",
			MonetaryAmount = 1,
			ReferenceNumberQualifier = "Ag",
			ReferenceNumber = "0",
			ProductServiceIDQualifier = "a5",
			ProductServiceID = "2",
			Percent = 9,
			UnitOfMeasurementCode = "Ms",
			Quantity = 9,
		};

		var actual = Map.MapObject<MII_MortgageInsuranceInformation>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("M", true)]
	public void Validation_RequiredMortgageInsuranceApplicationType(string mortgageInsuranceApplicationType, bool isValidExpected)
	{
		var subject = new MII_MortgageInsuranceInformation();
		//Required fields
		//Test Parameters
		subject.MortgageInsuranceApplicationType = mortgageInsuranceApplicationType;
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.ReferenceNumberQualifier) || !string.IsNullOrEmpty(subject.ReferenceNumberQualifier) || !string.IsNullOrEmpty(subject.ReferenceNumber))
		{
			subject.ReferenceNumberQualifier = "Ag";
			subject.ReferenceNumber = "0";
		}
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier) || !string.IsNullOrEmpty(subject.ProductServiceID))
		{
			subject.ProductServiceIDQualifier = "a5";
			subject.ProductServiceID = "2";
		}
		if(!string.IsNullOrEmpty(subject.UnitOfMeasurementCode) || !string.IsNullOrEmpty(subject.UnitOfMeasurementCode) || subject.Quantity > 0)
		{
			subject.UnitOfMeasurementCode = "Ms";
			subject.Quantity = 9;
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("Ag", "0", true)]
	[InlineData("Ag", "", false)]
	[InlineData("", "0", false)]
	public void Validation_AllAreRequiredReferenceNumberQualifier(string referenceNumberQualifier, string referenceNumber, bool isValidExpected)
	{
		var subject = new MII_MortgageInsuranceInformation();
		//Required fields
		subject.MortgageInsuranceApplicationType = "M";
		//Test Parameters
		subject.ReferenceNumberQualifier = referenceNumberQualifier;
		subject.ReferenceNumber = referenceNumber;
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier) || !string.IsNullOrEmpty(subject.ProductServiceID))
		{
			subject.ProductServiceIDQualifier = "a5";
			subject.ProductServiceID = "2";
		}
		if(!string.IsNullOrEmpty(subject.UnitOfMeasurementCode) || !string.IsNullOrEmpty(subject.UnitOfMeasurementCode) || subject.Quantity > 0)
		{
			subject.UnitOfMeasurementCode = "Ms";
			subject.Quantity = 9;
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("a5", "2", true)]
	[InlineData("a5", "", false)]
	[InlineData("", "2", false)]
	public void Validation_AllAreRequiredProductServiceIDQualifier(string productServiceIDQualifier, string productServiceID, bool isValidExpected)
	{
		var subject = new MII_MortgageInsuranceInformation();
		//Required fields
		subject.MortgageInsuranceApplicationType = "M";
		//Test Parameters
		subject.ProductServiceIDQualifier = productServiceIDQualifier;
		subject.ProductServiceID = productServiceID;
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.ReferenceNumberQualifier) || !string.IsNullOrEmpty(subject.ReferenceNumberQualifier) || !string.IsNullOrEmpty(subject.ReferenceNumber))
		{
			subject.ReferenceNumberQualifier = "Ag";
			subject.ReferenceNumber = "0";
		}
		if(!string.IsNullOrEmpty(subject.UnitOfMeasurementCode) || !string.IsNullOrEmpty(subject.UnitOfMeasurementCode) || subject.Quantity > 0)
		{
			subject.UnitOfMeasurementCode = "Ms";
			subject.Quantity = 9;
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

	[Theory]
	[InlineData("", 0, true)]
	[InlineData("Ms", 9, true)]
	[InlineData("Ms", 0, false)]
	[InlineData("", 9, false)]
	public void Validation_AllAreRequiredUnitOfMeasurementCode(string unitOfMeasurementCode, decimal quantity, bool isValidExpected)
	{
		var subject = new MII_MortgageInsuranceInformation();
		//Required fields
		subject.MortgageInsuranceApplicationType = "M";
		//Test Parameters
		subject.UnitOfMeasurementCode = unitOfMeasurementCode;
		if (quantity > 0) 
			subject.Quantity = quantity;
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.ReferenceNumberQualifier) || !string.IsNullOrEmpty(subject.ReferenceNumberQualifier) || !string.IsNullOrEmpty(subject.ReferenceNumber))
		{
			subject.ReferenceNumberQualifier = "Ag";
			subject.ReferenceNumber = "0";
		}
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier) || !string.IsNullOrEmpty(subject.ProductServiceID))
		{
			subject.ProductServiceIDQualifier = "a5";
			subject.ProductServiceID = "2";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

}
