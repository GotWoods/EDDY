using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3020;

namespace Eddy.x12.Tests.Models.v3020;

public class TRFTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "TRF*q5*K2*1*ez*8";

		var expected = new TRF_RatingFactors()
		{
			QuantityQualifier = "q5",
			UnitOfMeasurementCode = "K2",
			Quantity = 1,
			UnitOfMeasurementCode2 = "ez",
			Quantity2 = 8,
		};

		var actual = Map.MapObject<TRF_RatingFactors>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("q5", true)]
	public void Validation_RequiredQuantityQualifier(string quantityQualifier, bool isValidExpected)
	{
		var subject = new TRF_RatingFactors();
		//Required fields
		subject.UnitOfMeasurementCode = "K2";
		subject.Quantity = 1;
		subject.UnitOfMeasurementCode2 = "ez";
		subject.Quantity2 = 8;
		//Test Parameters
		subject.QuantityQualifier = quantityQualifier;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("K2", true)]
	public void Validation_RequiredUnitOfMeasurementCode(string unitOfMeasurementCode, bool isValidExpected)
	{
		var subject = new TRF_RatingFactors();
		//Required fields
		subject.QuantityQualifier = "q5";
		subject.Quantity = 1;
		subject.UnitOfMeasurementCode2 = "ez";
		subject.Quantity2 = 8;
		//Test Parameters
		subject.UnitOfMeasurementCode = unitOfMeasurementCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData(0, false)]
	[InlineData(1, true)]
	public void Validation_RequiredQuantity(decimal quantity, bool isValidExpected)
	{
		var subject = new TRF_RatingFactors();
		//Required fields
		subject.QuantityQualifier = "q5";
		subject.UnitOfMeasurementCode = "K2";
		subject.UnitOfMeasurementCode2 = "ez";
		subject.Quantity2 = 8;
		//Test Parameters
		if (quantity > 0) 
			subject.Quantity = quantity;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("ez", true)]
	public void Validation_RequiredUnitOfMeasurementCode2(string unitOfMeasurementCode2, bool isValidExpected)
	{
		var subject = new TRF_RatingFactors();
		//Required fields
		subject.QuantityQualifier = "q5";
		subject.UnitOfMeasurementCode = "K2";
		subject.Quantity = 1;
		subject.Quantity2 = 8;
		//Test Parameters
		subject.UnitOfMeasurementCode2 = unitOfMeasurementCode2;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData(0, false)]
	[InlineData(8, true)]
	public void Validation_RequiredQuantity2(decimal quantity2, bool isValidExpected)
	{
		var subject = new TRF_RatingFactors();
		//Required fields
		subject.QuantityQualifier = "q5";
		subject.UnitOfMeasurementCode = "K2";
		subject.Quantity = 1;
		subject.UnitOfMeasurementCode2 = "ez";
		//Test Parameters
		if (quantity2 > 0) 
			subject.Quantity2 = quantity2;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
