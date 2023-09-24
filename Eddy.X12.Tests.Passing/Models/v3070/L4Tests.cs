using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3070;

namespace Eddy.x12.Tests.Models.v3070;

public class L4Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "L4*1*1*7*T*6*P";

		var expected = new L4_Measurement()
		{
			Length = 1,
			Width = 1,
			Height = 7,
			MeasurementUnitQualifier = "T",
			Quantity = 6,
			IndustryCode = "P",
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
		subject.Width = 1;
		subject.Height = 7;
		subject.MeasurementUnitQualifier = "T";
		if (length > 0)
			subject.Length = length;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData(0, false)]
	[InlineData(1, true)]
	public void Validation_RequiredWidth(decimal width, bool isValidExpected)
	{
		var subject = new L4_Measurement();
		subject.Length = 1;
		subject.Height = 7;
		subject.MeasurementUnitQualifier = "T";
		if (width > 0)
			subject.Width = width;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData(0, false)]
	[InlineData(7, true)]
	public void Validation_RequiredHeight(decimal height, bool isValidExpected)
	{
		var subject = new L4_Measurement();
		subject.Length = 1;
		subject.Width = 1;
		subject.MeasurementUnitQualifier = "T";
		if (height > 0)
			subject.Height = height;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("T", true)]
	public void Validation_RequiredMeasurementUnitQualifier(string measurementUnitQualifier, bool isValidExpected)
	{
		var subject = new L4_Measurement();
		subject.Length = 1;
		subject.Width = 1;
		subject.Height = 7;
		subject.MeasurementUnitQualifier = measurementUnitQualifier;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
