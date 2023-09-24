using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3030;

namespace Eddy.x12.Tests.Models.v3030;

public class SERTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "SER*pv*C*3*8*3*5*9*RwA*7*7H*J";

		var expected = new SER_ServiceCharges()
		{
			ProductServiceIDQualifier = "pv",
			ProductServiceID = "C",
			MonetaryAmount = 3,
			MonetaryAmount2 = 8,
			UnitPrice = 3,
			Quantity = 5,
			Description = "9",
			PriceIdentifierCode = "RwA",
			PaymentMethodCode = "7",
			ReferenceNumberQualifier = "7H",
			ReferenceNumber = "J",
		};

		var actual = Map.MapObject<SER_ServiceCharges>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("pv", true)]
	public void Validation_RequiredProductServiceIDQualifier(string productServiceIDQualifier, bool isValidExpected)
	{
		var subject = new SER_ServiceCharges();
		subject.ProductServiceID = "C";
		subject.ProductServiceIDQualifier = productServiceIDQualifier;
			subject.MonetaryAmount = 3;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("C", true)]
	public void Validation_RequiredProductServiceID(string productServiceID, bool isValidExpected)
	{
		var subject = new SER_ServiceCharges();
		subject.ProductServiceIDQualifier = "pv";
		subject.ProductServiceID = productServiceID;
			subject.MonetaryAmount = 3;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData(0, 0, false)]
	[InlineData(3, 8, true)]
	[InlineData(3, 0, true)]
	[InlineData(0, 8, true)]
	public void Validation_AtLeastOneMonetaryAmount(decimal monetaryAmount, decimal monetaryAmount2, bool isValidExpected)
	{
		var subject = new SER_ServiceCharges();
		subject.ProductServiceIDQualifier = "pv";
		subject.ProductServiceID = "C";
		if (monetaryAmount > 0)
			subject.MonetaryAmount = monetaryAmount;
		if (monetaryAmount2 > 0)
			subject.MonetaryAmount2 = monetaryAmount2;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.AtLeastOneIsRequired);
	}

}
