using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3070;

namespace Eddy.x12.Tests.Models.v3070;

public class MS4Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "MS4*f*9*4*7";

		var expected = new MS4_ShipmentOrPackageDimensions()
		{
			MeasurementUnitQualifier = "f",
			Length = 9,
			Height = 4,
			Width = 7,
		};

		var actual = Map.MapObject<MS4_ShipmentOrPackageDimensions>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("f", true)]
	public void Validation_RequiredMeasurementUnitQualifier(string measurementUnitQualifier, bool isValidExpected)
	{
		var subject = new MS4_ShipmentOrPackageDimensions();
		//Required fields
		subject.Length = 9;
		subject.Height = 4;
		subject.Width = 7;
		//Test Parameters
		subject.MeasurementUnitQualifier = measurementUnitQualifier;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData(0, false)]
	[InlineData(9, true)]
	public void Validation_RequiredLength(decimal length, bool isValidExpected)
	{
		var subject = new MS4_ShipmentOrPackageDimensions();
		//Required fields
		subject.MeasurementUnitQualifier = "f";
		subject.Height = 4;
		subject.Width = 7;
		//Test Parameters
		if (length > 0) 
			subject.Length = length;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData(0, false)]
	[InlineData(4, true)]
	public void Validation_RequiredHeight(decimal height, bool isValidExpected)
	{
		var subject = new MS4_ShipmentOrPackageDimensions();
		//Required fields
		subject.MeasurementUnitQualifier = "f";
		subject.Length = 9;
		subject.Width = 7;
		//Test Parameters
		if (height > 0) 
			subject.Height = height;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData(0, false)]
	[InlineData(7, true)]
	public void Validation_RequiredWidth(decimal width, bool isValidExpected)
	{
		var subject = new MS4_ShipmentOrPackageDimensions();
		//Required fields
		subject.MeasurementUnitQualifier = "f";
		subject.Length = 9;
		subject.Height = 4;
		//Test Parameters
		if (width > 0) 
			subject.Width = width;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
