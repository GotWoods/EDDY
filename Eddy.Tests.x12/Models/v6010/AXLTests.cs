using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v6010;

namespace Eddy.x12.Tests.Models.v6010;

public class AXLTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "AXL*er*5*6*4*6*O*4*W";

		var expected = new AXL_VehicleAxleMeasurements()
		{
			ProductServiceIDQualifier = "er",
			ProductServiceID = "5",
			MeasurementUnitQualifier = "6",
			Length = 4,
			Width = 6,
			WeightQualifier = "O",
			Weight = 4,
			ReferenceIdentification = "W",
		};

		var actual = Map.MapObject<AXL_VehicleAxleMeasurements>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("er", true)]
	public void Validation_RequiredProductServiceIDQualifier(string productServiceIDQualifier, bool isValidExpected)
	{
		var subject = new AXL_VehicleAxleMeasurements();
		//Required fields
		subject.ProductServiceID = "5";
		//Test Parameters
		subject.ProductServiceIDQualifier = productServiceIDQualifier;
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.WeightQualifier) || !string.IsNullOrEmpty(subject.WeightQualifier) || subject.Weight > 0)
		{
			subject.WeightQualifier = "O";
			subject.Weight = 4;
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("5", true)]
	public void Validation_RequiredProductServiceID(string productServiceID, bool isValidExpected)
	{
		var subject = new AXL_VehicleAxleMeasurements();
		//Required fields
		subject.ProductServiceIDQualifier = "er";
		//Test Parameters
		subject.ProductServiceID = productServiceID;
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.WeightQualifier) || !string.IsNullOrEmpty(subject.WeightQualifier) || subject.Weight > 0)
		{
			subject.WeightQualifier = "O";
			subject.Weight = 4;
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData(0, "", true)]
	[InlineData(4, "6", true)]
	[InlineData(4, "", false)]
	[InlineData(0, "6", true)]
	public void Validation_ARequiresBLength(decimal length, string measurementUnitQualifier, bool isValidExpected)
	{
		var subject = new AXL_VehicleAxleMeasurements();
		//Required fields
		subject.ProductServiceIDQualifier = "er";
		subject.ProductServiceID = "5";
		//Test Parameters
		if (length > 0) 
			subject.Length = length;
		subject.MeasurementUnitQualifier = measurementUnitQualifier;
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.WeightQualifier) || !string.IsNullOrEmpty(subject.WeightQualifier) || subject.Weight > 0)
		{
			subject.WeightQualifier = "O";
			subject.Weight = 4;
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
	}

	[Theory]
	[InlineData(0, "", true)]
	[InlineData(6, "6", true)]
	[InlineData(6, "", false)]
	[InlineData(0, "6", true)]
	public void Validation_ARequiresBWidth(decimal width, string measurementUnitQualifier, bool isValidExpected)
	{
		var subject = new AXL_VehicleAxleMeasurements();
		//Required fields
		subject.ProductServiceIDQualifier = "er";
		subject.ProductServiceID = "5";
		//Test Parameters
		if (width > 0) 
			subject.Width = width;
		subject.MeasurementUnitQualifier = measurementUnitQualifier;
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.WeightQualifier) || !string.IsNullOrEmpty(subject.WeightQualifier) || subject.Weight > 0)
		{
			subject.WeightQualifier = "O";
			subject.Weight = 4;
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
	}

	[Theory]
	[InlineData("", 0, true)]
	[InlineData("O", 4, true)]
	[InlineData("O", 0, false)]
	[InlineData("", 4, false)]
	public void Validation_AllAreRequiredWeightQualifier(string weightQualifier, decimal weight, bool isValidExpected)
	{
		var subject = new AXL_VehicleAxleMeasurements();
		//Required fields
		subject.ProductServiceIDQualifier = "er";
		subject.ProductServiceID = "5";
		//Test Parameters
		subject.WeightQualifier = weightQualifier;
		if (weight > 0) 
			subject.Weight = weight;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

}
