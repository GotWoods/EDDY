using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3050;

namespace Eddy.x12.Tests.Models.v3050;

public class MIITests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "MII*Y*9*y*W*a*6*U*8*Nr*3*tC*m*6*2P*8";

		var expected = new MII_MortgageInsuranceInformation()
		{
			MortgageInsuranceApplicationType = "Y",
			MortgageInsurancePremiumSourceCode = "9",
			YesNoConditionOrResponseCode = "y",
			MortgageInsuranceCertificateTypeCode = "W",
			MortgageInsuranceCoverageTypeCode = "a",
			MortgageInsuranceDurationCode = "6",
			MortgageInsuranceRenewalOptionCode = "U",
			MonetaryAmount = 8,
			ReferenceNumberQualifier = "Nr",
			ReferenceNumber = "3",
			ProductServiceIDQualifier = "tC",
			ProductServiceID = "m",
			Percent = 6,
			UnitOrBasisForMeasurementCode = "2P",
			Quantity = 8,
		};

		var actual = Map.MapObject<MII_MortgageInsuranceInformation>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("Y", true)]
	public void Validation_RequiredMortgageInsuranceApplicationType(string mortgageInsuranceApplicationType, bool isValidExpected)
	{
		var subject = new MII_MortgageInsuranceInformation();
		//Required fields
		//Test Parameters
		subject.MortgageInsuranceApplicationType = mortgageInsuranceApplicationType;
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.ReferenceNumberQualifier) || !string.IsNullOrEmpty(subject.ReferenceNumberQualifier) || !string.IsNullOrEmpty(subject.ReferenceNumber))
		{
			subject.ReferenceNumberQualifier = "Nr";
			subject.ReferenceNumber = "3";
		}
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier) || !string.IsNullOrEmpty(subject.ProductServiceID))
		{
			subject.ProductServiceIDQualifier = "tC";
			subject.ProductServiceID = "m";
		}
		if(!string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode) || !string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode) || subject.Quantity > 0)
		{
			subject.UnitOrBasisForMeasurementCode = "2P";
			subject.Quantity = 8;
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("Nr", "3", true)]
	[InlineData("Nr", "", false)]
	[InlineData("", "3", false)]
	public void Validation_AllAreRequiredReferenceNumberQualifier(string referenceNumberQualifier, string referenceNumber, bool isValidExpected)
	{
		var subject = new MII_MortgageInsuranceInformation();
		//Required fields
		subject.MortgageInsuranceApplicationType = "Y";
		//Test Parameters
		subject.ReferenceNumberQualifier = referenceNumberQualifier;
		subject.ReferenceNumber = referenceNumber;
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier) || !string.IsNullOrEmpty(subject.ProductServiceID))
		{
			subject.ProductServiceIDQualifier = "tC";
			subject.ProductServiceID = "m";
		}
		if(!string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode) || !string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode) || subject.Quantity > 0)
		{
			subject.UnitOrBasisForMeasurementCode = "2P";
			subject.Quantity = 8;
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("tC", "m", true)]
	[InlineData("tC", "", false)]
	[InlineData("", "m", false)]
	public void Validation_AllAreRequiredProductServiceIDQualifier(string productServiceIDQualifier, string productServiceID, bool isValidExpected)
	{
		var subject = new MII_MortgageInsuranceInformation();
		//Required fields
		subject.MortgageInsuranceApplicationType = "Y";
		//Test Parameters
		subject.ProductServiceIDQualifier = productServiceIDQualifier;
		subject.ProductServiceID = productServiceID;
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.ReferenceNumberQualifier) || !string.IsNullOrEmpty(subject.ReferenceNumberQualifier) || !string.IsNullOrEmpty(subject.ReferenceNumber))
		{
			subject.ReferenceNumberQualifier = "Nr";
			subject.ReferenceNumber = "3";
		}
		if(!string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode) || !string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode) || subject.Quantity > 0)
		{
			subject.UnitOrBasisForMeasurementCode = "2P";
			subject.Quantity = 8;
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

	[Theory]
	[InlineData("", 0, true)]
	[InlineData("2P", 8, true)]
	[InlineData("2P", 0, false)]
	[InlineData("", 8, false)]
	public void Validation_AllAreRequiredUnitOrBasisForMeasurementCode(string unitOrBasisForMeasurementCode, decimal quantity, bool isValidExpected)
	{
		var subject = new MII_MortgageInsuranceInformation();
		//Required fields
		subject.MortgageInsuranceApplicationType = "Y";
		//Test Parameters
		subject.UnitOrBasisForMeasurementCode = unitOrBasisForMeasurementCode;
		if (quantity > 0) 
			subject.Quantity = quantity;
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.ReferenceNumberQualifier) || !string.IsNullOrEmpty(subject.ReferenceNumberQualifier) || !string.IsNullOrEmpty(subject.ReferenceNumber))
		{
			subject.ReferenceNumberQualifier = "Nr";
			subject.ReferenceNumber = "3";
		}
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier) || !string.IsNullOrEmpty(subject.ProductServiceID))
		{
			subject.ProductServiceIDQualifier = "tC";
			subject.ProductServiceID = "m";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

}
