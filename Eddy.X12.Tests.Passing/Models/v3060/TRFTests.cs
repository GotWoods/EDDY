using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.v3060.Composites;
using Eddy.x12.Models.v3060;

namespace Eddy.x12.Tests.Models.v3060;

public class TRFTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "TRF*tQ**6**7";

		var expected = new TRF_RatingFactors()
		{
			QuantityQualifier = "tQ",
			CompositeUnitOfMeasure = null,
			Quantity = 6,
			CompositeUnitOfMeasure2 = null,
			Quantity2 = 7,
		};

		var actual = Map.MapObject<TRF_RatingFactors>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("tQ", true)]
	public void Validation_RequiredQuantityQualifier(string quantityQualifier, bool isValidExpected)
	{
		var subject = new TRF_RatingFactors();
		//Required fields
		subject.CompositeUnitOfMeasure = new C001_CompositeUnitOfMeasure();
		subject.Quantity = 6;
		subject.CompositeUnitOfMeasure2 = new C001_CompositeUnitOfMeasure();
		subject.Quantity2 = 7;
		//Test Parameters
		subject.QuantityQualifier = quantityQualifier;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("A", true)]
	public void Validation_RequiredCompositeUnitOfMeasure(string compositeUnitOfMeasure, bool isValidExpected)
	{
		var subject = new TRF_RatingFactors();
		//Required fields
		subject.QuantityQualifier = "tQ";
		subject.Quantity = 6;
		subject.CompositeUnitOfMeasure2 = new C001_CompositeUnitOfMeasure();
		subject.Quantity2 = 7;
		//Test Parameters
		if (compositeUnitOfMeasure != "") 
			subject.CompositeUnitOfMeasure = new C001_CompositeUnitOfMeasure();
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData(0, false)]
	[InlineData(6, true)]
	public void Validation_RequiredQuantity(decimal quantity, bool isValidExpected)
	{
		var subject = new TRF_RatingFactors();
		//Required fields
		subject.QuantityQualifier = "tQ";
		subject.CompositeUnitOfMeasure = new C001_CompositeUnitOfMeasure();
		subject.CompositeUnitOfMeasure2 = new C001_CompositeUnitOfMeasure();
		subject.Quantity2 = 7;
		//Test Parameters
		if (quantity > 0) 
			subject.Quantity = quantity;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("A", true)]
	public void Validation_RequiredCompositeUnitOfMeasure2(string compositeUnitOfMeasure2, bool isValidExpected)
	{
		var subject = new TRF_RatingFactors();
		//Required fields
		subject.QuantityQualifier = "tQ";
		subject.CompositeUnitOfMeasure = new C001_CompositeUnitOfMeasure();
		subject.Quantity = 6;
		subject.Quantity2 = 7;
		//Test Parameters
		if (compositeUnitOfMeasure2 != "") 
			subject.CompositeUnitOfMeasure2 = new C001_CompositeUnitOfMeasure();
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData(0, false)]
	[InlineData(7, true)]
	public void Validation_RequiredQuantity2(decimal quantity2, bool isValidExpected)
	{
		var subject = new TRF_RatingFactors();
		//Required fields
		subject.QuantityQualifier = "tQ";
		subject.CompositeUnitOfMeasure = new C001_CompositeUnitOfMeasure();
		subject.Quantity = 6;
		subject.CompositeUnitOfMeasure2 = new C001_CompositeUnitOfMeasure();
		//Test Parameters
		if (quantity2 > 0) 
			subject.Quantity2 = quantity2;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
