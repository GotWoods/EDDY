using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v4030;

namespace Eddy.x12.Tests.Models.v4030;

public class AXLTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "AXL*l9*W*L*5*4*C*3*T";

		var expected = new AXL_VehicleAxleMeasurements()
		{
			ProductServiceIDQualifier = "l9",
			ProductServiceID = "W",
			MeasurementUnitQualifier = "L",
			Length = 5,
			Width = 4,
			WeightQualifier = "C",
			Weight = 3,
			ReferenceIdentification = "T",
		};

		var actual = Map.MapObject<AXL_VehicleAxleMeasurements>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("l9", true)]
	public void Validation_RequiredProductServiceIDQualifier(string productServiceIDQualifier, bool isValidExpected)
	{
		var subject = new AXL_VehicleAxleMeasurements();
		//Required fields
		subject.ProductServiceID = "W";
		//Test Parameters
		subject.ProductServiceIDQualifier = productServiceIDQualifier;
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.WeightQualifier) || !string.IsNullOrEmpty(subject.WeightQualifier) || subject.Weight > 0)
		{
			subject.WeightQualifier = "C";
			subject.Weight = 3;
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("W", true)]
	public void Validation_RequiredProductServiceID(string productServiceID, bool isValidExpected)
	{
		var subject = new AXL_VehicleAxleMeasurements();
		//Required fields
		subject.ProductServiceIDQualifier = "l9";
		//Test Parameters
		subject.ProductServiceID = productServiceID;
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.WeightQualifier) || !string.IsNullOrEmpty(subject.WeightQualifier) || subject.Weight > 0)
		{
			subject.WeightQualifier = "C";
			subject.Weight = 3;
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData(0, "", true)]
	[InlineData(5, "L", true)]
	[InlineData(5, "", false)]
	[InlineData(0, "L", true)]
	public void Validation_ARequiresBLength(decimal length, string measurementUnitQualifier, bool isValidExpected)
	{
		var subject = new AXL_VehicleAxleMeasurements();
		//Required fields
		subject.ProductServiceIDQualifier = "l9";
		subject.ProductServiceID = "W";
		//Test Parameters
		if (length > 0) 
			subject.Length = length;
		subject.MeasurementUnitQualifier = measurementUnitQualifier;
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.WeightQualifier) || !string.IsNullOrEmpty(subject.WeightQualifier) || subject.Weight > 0)
		{
			subject.WeightQualifier = "C";
			subject.Weight = 3;
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
	}

	[Theory]
	[InlineData(0, "", true)]
	[InlineData(4, "L", true)]
	[InlineData(4, "", false)]
	[InlineData(0, "L", true)]
	public void Validation_ARequiresBWidth(decimal width, string measurementUnitQualifier, bool isValidExpected)
	{
		var subject = new AXL_VehicleAxleMeasurements();
		//Required fields
		subject.ProductServiceIDQualifier = "l9";
		subject.ProductServiceID = "W";
		//Test Parameters
		if (width > 0) 
			subject.Width = width;
		subject.MeasurementUnitQualifier = measurementUnitQualifier;
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.WeightQualifier) || !string.IsNullOrEmpty(subject.WeightQualifier) || subject.Weight > 0)
		{
			subject.WeightQualifier = "C";
			subject.Weight = 3;
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
	}

	[Theory]
	[InlineData("", 0, true)]
	[InlineData("C", 3, true)]
	[InlineData("C", 0, false)]
	[InlineData("", 3, false)]
	public void Validation_AllAreRequiredWeightQualifier(string weightQualifier, decimal weight, bool isValidExpected)
	{
		var subject = new AXL_VehicleAxleMeasurements();
		//Required fields
		subject.ProductServiceIDQualifier = "l9";
		subject.ProductServiceID = "W";
		//Test Parameters
		subject.WeightQualifier = weightQualifier;
		if (weight > 0) 
			subject.Weight = weight;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

}
