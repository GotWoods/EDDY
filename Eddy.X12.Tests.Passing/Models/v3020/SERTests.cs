using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3020;

namespace Eddy.x12.Tests.Models.v3020;

public class SERTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "SER*As*n*4*5*7*3*m";

		var expected = new SER_ServiceCharges()
		{
			ProductServiceIDQualifier = "As",
			ProductServiceID = "n",
			MonetaryAmount = 4,
			MonetaryAmount2 = 5,
			UnitPrice = 7,
			Quantity = 3,
			Description = "m",
		};

		var actual = Map.MapObject<SER_ServiceCharges>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("As", true)]
	public void Validation_RequiredProductServiceIDQualifier(string productServiceIDQualifier, bool isValidExpected)
	{
		var subject = new SER_ServiceCharges();
		subject.ProductServiceID = "n";
		subject.ProductServiceIDQualifier = productServiceIDQualifier;
			subject.MonetaryAmount = 4;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("n", true)]
	public void Validation_RequiredProductServiceID(string productServiceID, bool isValidExpected)
	{
		var subject = new SER_ServiceCharges();
		subject.ProductServiceIDQualifier = "As";
		subject.ProductServiceID = productServiceID;
			subject.MonetaryAmount = 4;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData(0, 0, false)]
	[InlineData(4, 5, true)]
	[InlineData(4, 0, true)]
	[InlineData(0, 5, true)]
	public void Validation_AtLeastOneMonetaryAmount(decimal monetaryAmount, decimal monetaryAmount2, bool isValidExpected)
	{
		var subject = new SER_ServiceCharges();
		subject.ProductServiceIDQualifier = "As";
		subject.ProductServiceID = "n";
		if (monetaryAmount > 0)
			subject.MonetaryAmount = monetaryAmount;
		if (monetaryAmount2 > 0)
			subject.MonetaryAmount2 = monetaryAmount2;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.AtLeastOneIsRequired);
	}

}
