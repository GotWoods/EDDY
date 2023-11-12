using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3010;

namespace Eddy.x12.Tests.Models.v3010;

public class L4Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "L4*8*2*8*5*3";

		var expected = new L4_Measurement()
		{
			Length = 8,
			Width = 2,
			Height = 8,
			MeasurementUnitQualifier = "5",
			Quantity = 3,
		};

		var actual = Map.MapObject<L4_Measurement>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData(0, false)]
	[InlineData(8, true)]
	public void Validation_RequiredLength(decimal length, bool isValidExpected)
	{
		var subject = new L4_Measurement();
		subject.Width = 2;
		subject.Height = 8;
		subject.MeasurementUnitQualifier = "5";
		if (length > 0)
			subject.Length = length;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData(0, false)]
	[InlineData(2, true)]
	public void Validation_RequiredWidth(decimal width, bool isValidExpected)
	{
		var subject = new L4_Measurement();
		subject.Length = 8;
		subject.Height = 8;
		subject.MeasurementUnitQualifier = "5";
		if (width > 0)
			subject.Width = width;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData(0, false)]
	[InlineData(8, true)]
	public void Validation_RequiredHeight(decimal height, bool isValidExpected)
	{
		var subject = new L4_Measurement();
		subject.Length = 8;
		subject.Width = 2;
		subject.MeasurementUnitQualifier = "5";
		if (height > 0)
			subject.Height = height;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("5", true)]
	public void Validation_RequiredMeasurementUnitQualifier(string measurementUnitQualifier, bool isValidExpected)
	{
		var subject = new L4_Measurement();
		subject.Length = 8;
		subject.Width = 2;
		subject.Height = 8;
		subject.MeasurementUnitQualifier = measurementUnitQualifier;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
