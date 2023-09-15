using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3040;

namespace Eddy.x12.Tests.Models.v3040;

public class M3Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "M3*V*NotokS*yAeW*aw";

		var expected = new M3_Release()
		{
			ReleaseCode = "V",
			Date = "NotokS",
			Time = "yAeW",
			TimeCode = "aw",
		};

		var actual = Map.MapObject<M3_Release>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("V", true)]
	public void Validation_RequiredReleaseCode(string releaseCode, bool isValidExpected)
	{
		var subject = new M3_Release();
		subject.ReleaseCode = releaseCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("aw", "yAeW", true)]
	[InlineData("aw", "", false)]
	[InlineData("", "yAeW", true)]
	public void Validation_ARequiresBTimeCode(string timeCode, string time, bool isValidExpected)
	{
		var subject = new M3_Release();
		subject.ReleaseCode = "V";
		subject.TimeCode = timeCode;
		subject.Time = time;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
	}

}
