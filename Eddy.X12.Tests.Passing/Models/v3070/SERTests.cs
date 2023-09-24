using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3070;

namespace Eddy.x12.Tests.Models.v3070;

public class SERTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "SER*DO*b*5*6*5*3*z*P8A*G*3H*P";

		var expected = new SER_ServiceCharges()
		{
			ProductServiceIDQualifier = "DO",
			ProductServiceID = "b",
			MonetaryAmount = 5,
			MonetaryAmount2 = 6,
			UnitPrice = 5,
			Quantity = 3,
			Description = "z",
			PriceIdentifierCode = "P8A",
			PaymentMethodCode = "G",
			ReferenceIdentificationQualifier = "3H",
			ReferenceIdentification = "P",
		};

		var actual = Map.MapObject<SER_ServiceCharges>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("DO", true)]
	public void Validation_RequiredProductServiceIDQualifier(string productServiceIDQualifier, bool isValidExpected)
	{
		var subject = new SER_ServiceCharges();
		subject.ProductServiceID = "b";
		subject.ProductServiceIDQualifier = productServiceIDQualifier;
			subject.MonetaryAmount = 5;
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.ReferenceIdentificationQualifier) || !string.IsNullOrEmpty(subject.ReferenceIdentificationQualifier) || !string.IsNullOrEmpty(subject.ReferenceIdentification))
		{
			subject.ReferenceIdentificationQualifier = "3H";
			subject.ReferenceIdentification = "P";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("b", true)]
	public void Validation_RequiredProductServiceID(string productServiceID, bool isValidExpected)
	{
		var subject = new SER_ServiceCharges();
		subject.ProductServiceIDQualifier = "DO";
		subject.ProductServiceID = productServiceID;
			subject.MonetaryAmount = 5;
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.ReferenceIdentificationQualifier) || !string.IsNullOrEmpty(subject.ReferenceIdentificationQualifier) || !string.IsNullOrEmpty(subject.ReferenceIdentification))
		{
			subject.ReferenceIdentificationQualifier = "3H";
			subject.ReferenceIdentification = "P";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData(0, 0, false)]
	[InlineData(5, 6, true)]
	[InlineData(5, 0, true)]
	[InlineData(0, 6, true)]
	public void Validation_AtLeastOneMonetaryAmount(decimal monetaryAmount, decimal monetaryAmount2, bool isValidExpected)
	{
		var subject = new SER_ServiceCharges();
		subject.ProductServiceIDQualifier = "DO";
		subject.ProductServiceID = "b";
		if (monetaryAmount > 0)
			subject.MonetaryAmount = monetaryAmount;
		if (monetaryAmount2 > 0)
			subject.MonetaryAmount2 = monetaryAmount2;
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.ReferenceIdentificationQualifier) || !string.IsNullOrEmpty(subject.ReferenceIdentificationQualifier) || !string.IsNullOrEmpty(subject.ReferenceIdentification))
		{
			subject.ReferenceIdentificationQualifier = "3H";
			subject.ReferenceIdentification = "P";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.AtLeastOneIsRequired);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("3H", "P", true)]
	[InlineData("3H", "", false)]
	[InlineData("", "P", false)]
	public void Validation_AllAreRequiredReferenceIdentificationQualifier(string referenceIdentificationQualifier, string referenceIdentification, bool isValidExpected)
	{
		var subject = new SER_ServiceCharges();
		subject.ProductServiceIDQualifier = "DO";
		subject.ProductServiceID = "b";
		subject.ReferenceIdentificationQualifier = referenceIdentificationQualifier;
		subject.ReferenceIdentification = referenceIdentification;
			subject.MonetaryAmount = 5;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

}
