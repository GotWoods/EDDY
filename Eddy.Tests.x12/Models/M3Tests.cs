using Eddy.Core.Validation;
using Eddy.x12.Mapping;
using Eddy.x12.Models;

namespace Eddy.Tests.x12.Models;

public class M3Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "M3*B*lIH4FCRm*1Tyx*1G";

		var expected = new M3_Release()
		{
			ReleaseCode = "B",
			Date = "lIH4FCRm",
			Time = "1Tyx",
			TimeCode = "1G",
		};

		var actual = Map.MapObject<M3_Release>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("B", true)]
	public void Validation_RequiredReleaseCode(string releaseCode, bool isValidExpected)
	{
		var subject = new M3_Release();
		subject.ReleaseCode = releaseCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("","", false)]
	[InlineData("lIH4FCRm","1Tyx", true)]
	[InlineData("", "1Tyx", true)]
	[InlineData("lIH4FCRm", "", true)]
	public void Validation_AtLeastOneDate(string date, string time, bool isValidExpected)
	{
		var subject = new M3_Release();
		subject.ReleaseCode = "B";
		subject.Date = date;
		subject.Time = time;

		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.AtLeastOneIsRequired);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("", "1Tyx", true)]
	[InlineData("1G", "", false)]
	public void Validation_ARequiresBTimeCode(string timeCode, string time, bool isValidExpected)
	{
		var subject = new M3_Release();
		subject.ReleaseCode = "B";
		subject.TimeCode = timeCode;
		subject.Time = time;

		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
	}

}
