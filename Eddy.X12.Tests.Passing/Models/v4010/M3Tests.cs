using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v4010;

namespace Eddy.x12.Tests.Models.v4010;

public class M3Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "M3*R*4WVlUqJ8*IjK4*wa";

		var expected = new M3_Release()
		{
			ReleaseCode = "R",
			Date = "4WVlUqJ8",
			Time = "IjK4",
			TimeCode = "wa",
		};

		var actual = Map.MapObject<M3_Release>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("R", true)]
	public void Validation_RequiredReleaseCode(string releaseCode, bool isValidExpected)
	{
		var subject = new M3_Release();
		subject.ReleaseCode = releaseCode;
			subject.Date = "4WVlUqJ8";
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", "", false)]
	[InlineData("4WVlUqJ8", "IjK4", true)]
	[InlineData("4WVlUqJ8", "", true)]
	[InlineData("", "IjK4", true)]
	public void Validation_AtLeastOneDate(string date, string time, bool isValidExpected)
	{
		var subject = new M3_Release();
		subject.ReleaseCode = "R";
		subject.Date = date;
		subject.Time = time;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.AtLeastOneIsRequired);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("wa", "IjK4", true)]
	[InlineData("wa", "", false)]
	[InlineData("", "IjK4", true)]
	public void Validation_ARequiresBTimeCode(string timeCode, string time, bool isValidExpected)
	{
		var subject = new M3_Release();
		subject.ReleaseCode = "R";
		subject.TimeCode = timeCode;
		subject.Time = time;
			subject.Date = "4WVlUqJ8";
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
	}

}
