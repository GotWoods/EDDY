using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3030;

namespace Eddy.x12.Tests.Models.v3030;

public class TRFTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "TRF*VE*DH*2*CF*1";

		var expected = new TRF_RatingFactors()
		{
			QuantityQualifier = "VE",
			UnitOrBasisForMeasurementCode = "DH",
			Quantity = 2,
			UnitOrBasisForMeasurementCode2 = "CF",
			Quantity2 = 1,
		};

		var actual = Map.MapObject<TRF_RatingFactors>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("VE", true)]
	public void Validation_RequiredQuantityQualifier(string quantityQualifier, bool isValidExpected)
	{
		var subject = new TRF_RatingFactors();
		//Required fields
		subject.UnitOrBasisForMeasurementCode = "DH";
		subject.Quantity = 2;
		subject.UnitOrBasisForMeasurementCode2 = "CF";
		subject.Quantity2 = 1;
		//Test Parameters
		subject.QuantityQualifier = quantityQualifier;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("DH", true)]
	public void Validation_RequiredUnitOrBasisForMeasurementCode(string unitOrBasisForMeasurementCode, bool isValidExpected)
	{
		var subject = new TRF_RatingFactors();
		//Required fields
		subject.QuantityQualifier = "VE";
		subject.Quantity = 2;
		subject.UnitOrBasisForMeasurementCode2 = "CF";
		subject.Quantity2 = 1;
		//Test Parameters
		subject.UnitOrBasisForMeasurementCode = unitOrBasisForMeasurementCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData(0, false)]
	[InlineData(2, true)]
	public void Validation_RequiredQuantity(decimal quantity, bool isValidExpected)
	{
		var subject = new TRF_RatingFactors();
		//Required fields
		subject.QuantityQualifier = "VE";
		subject.UnitOrBasisForMeasurementCode = "DH";
		subject.UnitOrBasisForMeasurementCode2 = "CF";
		subject.Quantity2 = 1;
		//Test Parameters
		if (quantity > 0) 
			subject.Quantity = quantity;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("CF", true)]
	public void Validation_RequiredUnitOrBasisForMeasurementCode2(string unitOrBasisForMeasurementCode2, bool isValidExpected)
	{
		var subject = new TRF_RatingFactors();
		//Required fields
		subject.QuantityQualifier = "VE";
		subject.UnitOrBasisForMeasurementCode = "DH";
		subject.Quantity = 2;
		subject.Quantity2 = 1;
		//Test Parameters
		subject.UnitOrBasisForMeasurementCode2 = unitOrBasisForMeasurementCode2;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData(0, false)]
	[InlineData(1, true)]
	public void Validation_RequiredQuantity2(decimal quantity2, bool isValidExpected)
	{
		var subject = new TRF_RatingFactors();
		//Required fields
		subject.QuantityQualifier = "VE";
		subject.UnitOrBasisForMeasurementCode = "DH";
		subject.Quantity = 2;
		subject.UnitOrBasisForMeasurementCode2 = "CF";
		//Test Parameters
		if (quantity2 > 0) 
			subject.Quantity2 = quantity2;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
