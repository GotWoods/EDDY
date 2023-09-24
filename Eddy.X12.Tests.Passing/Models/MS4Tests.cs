using Eddy.Core.Validation;
using Eddy.x12.Mapping;
using Eddy.x12.Models;

namespace Eddy.Tests.x12.Models;

public class MS4Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "MS4*S*8*1*3";

		var expected = new MS4_ShipmentOrPackageDimensions()
		{
			MeasurementUnitQualifier = "S",
			Length = 8,
			Height = 1,
			Width = 3,
		};

		var actual = Map.MapObject<MS4_ShipmentOrPackageDimensions>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("S", true)]
	public void Validation_RequiredMeasurementUnitQualifier(string measurementUnitQualifier, bool isValidExpected)
	{
		var subject = new MS4_ShipmentOrPackageDimensions();
		subject.Length = 8;
		subject.Height = 1;
		subject.Width = 3;
		subject.MeasurementUnitQualifier = measurementUnitQualifier;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData(0, false)]
	[InlineData(8, true)]
	public void Validation_RequiredLength(decimal length, bool isValidExpected)
	{
		var subject = new MS4_ShipmentOrPackageDimensions();
		subject.MeasurementUnitQualifier = "S";
		subject.Height = 1;
		subject.Width = 3;
		if (length > 0)
		subject.Length = length;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData(0, false)]
	[InlineData(1, true)]
	public void Validation_RequiredHeight(decimal height, bool isValidExpected)
	{
		var subject = new MS4_ShipmentOrPackageDimensions();
		subject.MeasurementUnitQualifier = "S";
		subject.Length = 8;
		subject.Width = 3;
		if (height > 0)
		subject.Height = height;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData(0, false)]
	[InlineData(3, true)]
	public void Validation_RequiredWidth(decimal width, bool isValidExpected)
	{
		var subject = new MS4_ShipmentOrPackageDimensions();
		subject.MeasurementUnitQualifier = "S";
		subject.Length = 8;
		subject.Height = 1;
		if (width > 0)
		subject.Width = width;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
