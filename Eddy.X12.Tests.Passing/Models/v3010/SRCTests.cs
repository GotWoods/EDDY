using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3010;

namespace Eddy.x12.Tests.Models.v3010;

public class SRCTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "SRC*4X*b*V*n*d*h*b*W*4*R*k*E*d*h*3*c*b*3*z";

		var expected = new SRC_ScaleRateColumnID()
		{
			RateValueQualifier = "4X",
			Scale = "b",
			Scale2 = "V",
			Scale3 = "n",
			Scale4 = "d",
			Scale5 = "h",
			Scale6 = "b",
			Scale7 = "W",
			Scale8 = "4",
			Scale9 = "R",
			Scale10 = "k",
			Scale11 = "E",
			Scale12 = "d",
			Scale13 = "h",
			Scale14 = "3",
			Scale15 = "c",
			Scale16 = "b",
			Scale17 = "3",
			Scale18 = "z",
		};

		var actual = Map.MapObject<SRC_ScaleRateColumnID>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("4X", true)]
	public void Validation_RequiredRateValueQualifier(string rateValueQualifier, bool isValidExpected)
	{
		var subject = new SRC_ScaleRateColumnID();
		subject.Scale = "b";
		subject.RateValueQualifier = rateValueQualifier;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("b", true)]
	public void Validation_RequiredScale(string scale, bool isValidExpected)
	{
		var subject = new SRC_ScaleRateColumnID();
		subject.RateValueQualifier = "4X";
		subject.Scale = scale;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
