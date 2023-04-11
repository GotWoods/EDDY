using Eddy.Core.Validation;
using Eddy.x12.Mapping;
using Eddy.x12.Models;

namespace Eddy.Tests.x12.Models;

public class AXLTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "AXL*3G*E*Y*6*6*7*9*j";

		var expected = new AXL_VehicleAxleMeasurements()
		{
			ProductServiceIDQualifier = "3G",
			ProductServiceID = "E",
			MeasurementUnitQualifier = "Y",
			Length = 6,
			Width = 6,
			WeightQualifier = "7",
			Weight = 9,
			ReferenceIdentification = "j",
		};

		var actual = Map.MapObject<AXL_VehicleAxleMeasurements>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("3G", true)]
	public void Validation_RequiredProductServiceIDQualifier(string productServiceIDQualifier, bool isValidExpected)
	{
		var subject = new AXL_VehicleAxleMeasurements();
		subject.ProductServiceID = "E";
		subject.ProductServiceIDQualifier = productServiceIDQualifier;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("E", true)]
	public void Validation_RequiredProductServiceID(string productServiceID, bool isValidExpected)
	{
		var subject = new AXL_VehicleAxleMeasurements();
		subject.ProductServiceIDQualifier = "3G";
		subject.ProductServiceID = productServiceID;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData(0, "", true)]
	[InlineData(0, "Y", true)]
	[InlineData(6, "", false)]
	public void Validation_ARequiresBLength(decimal length, string measurementUnitQualifier, bool isValidExpected)
	{
		var subject = new AXL_VehicleAxleMeasurements();
		subject.ProductServiceIDQualifier = "3G";
		subject.ProductServiceID = "E";
		if (length > 0)
		subject.Length = length;
		subject.MeasurementUnitQualifier = measurementUnitQualifier;

		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
	}

	[Theory]
	[InlineData(0, "", true)]
	[InlineData(0, "Y", true)]
	[InlineData(6, "", false)]
	public void Validation_ARequiresBWidth(decimal width, string measurementUnitQualifier, bool isValidExpected)
	{
		var subject = new AXL_VehicleAxleMeasurements();
		subject.ProductServiceIDQualifier = "3G";
		subject.ProductServiceID = "E";
		if (width > 0)
		subject.Width = width;
		subject.MeasurementUnitQualifier = measurementUnitQualifier;

		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
	}

	[Theory]
	[InlineData("",0, true)]
	[InlineData("7", 9, true)]
	[InlineData("", 9, false)]
	[InlineData("7", 0, false)]
	public void Validation_AllAreRequiredWeightQualifier(string weightQualifier, decimal weight, bool isValidExpected)
	{
		var subject = new AXL_VehicleAxleMeasurements();
		subject.ProductServiceIDQualifier = "3G";
		subject.ProductServiceID = "E";
		subject.WeightQualifier = weightQualifier;
		if (weight > 0)
		subject.Weight = weight;

		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

}
