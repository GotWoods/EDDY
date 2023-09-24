using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3020;

namespace Eddy.x12.Tests.Models.v3020;

public class L4Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "L4*1*3*5*z*9";

		var expected = new L4_Measurement()
		{
			Length = 1,
			Width = 3,
			Height = 5,
			MeasurementUnitQualifier = "z",
			Quantity = 9,
		};

		var actual = Map.MapObject<L4_Measurement>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData(0, false)]
	[InlineData(1, true)]
	public void Validation_RequiredLength(decimal length, bool isValidExpected)
	{
		var subject = new L4_Measurement();
		subject.Width = 3;
		subject.Height = 5;
		subject.MeasurementUnitQualifier = "z";
		if (length > 0)
			subject.Length = length;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData(0, false)]
	[InlineData(3, true)]
	public void Validation_RequiredWidth(decimal width, bool isValidExpected)
	{
		var subject = new L4_Measurement();
		subject.Length = 1;
		subject.Height = 5;
		subject.MeasurementUnitQualifier = "z";
		if (width > 0)
			subject.Width = width;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData(0, false)]
	[InlineData(5, true)]
	public void Validation_RequiredHeight(decimal height, bool isValidExpected)
	{
		var subject = new L4_Measurement();
		subject.Length = 1;
		subject.Width = 3;
		subject.MeasurementUnitQualifier = "z";
		if (height > 0)
			subject.Height = height;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("z", true)]
	public void Validation_RequiredMeasurementUnitQualifier(string measurementUnitQualifier, bool isValidExpected)
	{
		var subject = new L4_Measurement();
		subject.Length = 1;
		subject.Width = 3;
		subject.Height = 5;
		subject.MeasurementUnitQualifier = measurementUnitQualifier;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
