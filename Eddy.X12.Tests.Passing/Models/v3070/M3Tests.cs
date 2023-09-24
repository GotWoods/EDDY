using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3070;

namespace Eddy.x12.Tests.Models.v3070;

public class M3Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "M3*U*L1LV09*iC7N*a2";

		var expected = new M3_Release()
		{
			ReleaseCode = "U",
			Date = "L1LV09",
			Time = "iC7N",
			TimeCode = "a2",
		};

		var actual = Map.MapObject<M3_Release>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("U", true)]
	public void Validation_RequiredReleaseCode(string releaseCode, bool isValidExpected)
	{
		var subject = new M3_Release();
		subject.ReleaseCode = releaseCode;
			subject.Date = "L1LV09";
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", "", false)]
	[InlineData("L1LV09", "iC7N", true)]
	[InlineData("L1LV09", "", true)]
	[InlineData("", "iC7N", true)]
	public void Validation_AtLeastOneDate(string date, string time, bool isValidExpected)
	{
		var subject = new M3_Release();
		subject.ReleaseCode = "U";
		subject.Date = date;
		subject.Time = time;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.AtLeastOneIsRequired);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("a2", "iC7N", true)]
	[InlineData("a2", "", false)]
	[InlineData("", "iC7N", true)]
	public void Validation_ARequiresBTimeCode(string timeCode, string time, bool isValidExpected)
	{
		var subject = new M3_Release();
		subject.ReleaseCode = "U";
		subject.TimeCode = timeCode;
		subject.Time = time;
			subject.Date = "L1LV09";
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
	}

}
