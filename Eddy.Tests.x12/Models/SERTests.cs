using Eddy.Core.Validation;
using Eddy.x12.Mapping;
using Eddy.x12.Models;

namespace Eddy.Tests.x12.Models;

public class SERTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "SER*pD*a*4*9*1*2*s*6Rr*R*X4*M";

		var expected = new SER_ServiceCharges()
		{
			ProductServiceIDQualifier = "pD",
			ProductServiceID = "a",
			MonetaryAmount = 4,
			MonetaryAmount2 = 9,
			UnitPrice = 1,
			Quantity = 2,
			Description = "s",
			PriceIdentifierCode = "6Rr",
			PaymentMethodTypeCode = "R",
			ReferenceIdentificationQualifier = "X4",
			ReferenceIdentification = "M",
		};

		var actual = Map.MapObject<SER_ServiceCharges>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("pD", true)]
	public void Validation_RequiredProductServiceIDQualifier(string productServiceIDQualifier, bool isValidExpected)
	{
		var subject = new SER_ServiceCharges();
		subject.ProductServiceID = "a";
		subject.ProductServiceIDQualifier = productServiceIDQualifier;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("a", true)]
	public void Validation_RequiredProductServiceID(string productServiceID, bool isValidExpected)
	{
		var subject = new SER_ServiceCharges();
		subject.ProductServiceIDQualifier = "pD";
		subject.ProductServiceID = productServiceID;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData(0,0, false)]
	[InlineData(4,9, true)]
	[InlineData(0, 9, true)]
	[InlineData(4, 0, true)]
	public void Validation_AtLeastOneMonetaryAmount(decimal monetaryAmount, decimal monetaryAmount2, bool isValidExpected)
	{
		var subject = new SER_ServiceCharges();
		subject.ProductServiceIDQualifier = "pD";
		subject.ProductServiceID = "a";
		if (monetaryAmount > 0)
		subject.MonetaryAmount = monetaryAmount;
		if (monetaryAmount2 > 0)
		subject.MonetaryAmount2 = monetaryAmount2;

		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.AtLeastOneIsRequired);
	}

	[Theory]
	[InlineData("","", true)]
	[InlineData("X4", "M", true)]
	[InlineData("", "M", false)]
	[InlineData("X4", "", false)]
	public void Validation_AllAreRequiredReferenceIdentificationQualifier(string referenceIdentificationQualifier, string referenceIdentification, bool isValidExpected)
	{
		var subject = new SER_ServiceCharges();
		subject.ProductServiceIDQualifier = "pD";
		subject.ProductServiceID = "a";
		subject.ReferenceIdentificationQualifier = referenceIdentificationQualifier;
		subject.ReferenceIdentification = referenceIdentification;

		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

}
