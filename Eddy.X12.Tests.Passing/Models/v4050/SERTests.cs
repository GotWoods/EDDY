using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v4050;

namespace Eddy.x12.Tests.Models.v4050;

public class SERTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "SER*Ch*b*2*1*4*4*2*mF8*y*zE*X";

		var expected = new SER_ServiceCharges()
		{
			ProductServiceIDQualifier = "Ch",
			ProductServiceID = "b",
			MonetaryAmount = 2,
			MonetaryAmount2 = 1,
			UnitPrice = 4,
			Quantity = 4,
			Description = "2",
			PriceIdentifierCode = "mF8",
			PaymentMethodTypeCode = "y",
			ReferenceIdentificationQualifier = "zE",
			ReferenceIdentification = "X",
		};

		var actual = Map.MapObject<SER_ServiceCharges>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("Ch", true)]
	public void Validation_RequiredProductServiceIDQualifier(string productServiceIDQualifier, bool isValidExpected)
	{
		var subject = new SER_ServiceCharges();
		subject.ProductServiceID = "b";
		subject.ProductServiceIDQualifier = productServiceIDQualifier;
			subject.MonetaryAmount = 2;
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.ReferenceIdentificationQualifier) || !string.IsNullOrEmpty(subject.ReferenceIdentificationQualifier) || !string.IsNullOrEmpty(subject.ReferenceIdentification))
		{
			subject.ReferenceIdentificationQualifier = "zE";
			subject.ReferenceIdentification = "X";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("b", true)]
	public void Validation_RequiredProductServiceID(string productServiceID, bool isValidExpected)
	{
		var subject = new SER_ServiceCharges();
		subject.ProductServiceIDQualifier = "Ch";
		subject.ProductServiceID = productServiceID;
			subject.MonetaryAmount = 2;
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.ReferenceIdentificationQualifier) || !string.IsNullOrEmpty(subject.ReferenceIdentificationQualifier) || !string.IsNullOrEmpty(subject.ReferenceIdentification))
		{
			subject.ReferenceIdentificationQualifier = "zE";
			subject.ReferenceIdentification = "X";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData(0, 0, false)]
	[InlineData(2, 1, true)]
	[InlineData(2, 0, true)]
	[InlineData(0, 1, true)]
	public void Validation_AtLeastOneMonetaryAmount(decimal monetaryAmount, decimal monetaryAmount2, bool isValidExpected)
	{
		var subject = new SER_ServiceCharges();
		subject.ProductServiceIDQualifier = "Ch";
		subject.ProductServiceID = "b";
		if (monetaryAmount > 0)
			subject.MonetaryAmount = monetaryAmount;
		if (monetaryAmount2 > 0)
			subject.MonetaryAmount2 = monetaryAmount2;
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.ReferenceIdentificationQualifier) || !string.IsNullOrEmpty(subject.ReferenceIdentificationQualifier) || !string.IsNullOrEmpty(subject.ReferenceIdentification))
		{
			subject.ReferenceIdentificationQualifier = "zE";
			subject.ReferenceIdentification = "X";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.AtLeastOneIsRequired);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("zE", "X", true)]
	[InlineData("zE", "", false)]
	[InlineData("", "X", false)]
	public void Validation_AllAreRequiredReferenceIdentificationQualifier(string referenceIdentificationQualifier, string referenceIdentification, bool isValidExpected)
	{
		var subject = new SER_ServiceCharges();
		subject.ProductServiceIDQualifier = "Ch";
		subject.ProductServiceID = "b";
		subject.ReferenceIdentificationQualifier = referenceIdentificationQualifier;
		subject.ReferenceIdentification = referenceIdentification;
			subject.MonetaryAmount = 2;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

}
