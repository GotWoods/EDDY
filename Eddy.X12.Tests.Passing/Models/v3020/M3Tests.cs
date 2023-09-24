using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3020;

namespace Eddy.x12.Tests.Models.v3020;

public class M3Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "M3*h*xeUgC3*pjXe";

		var expected = new M3_Release()
		{
			ReleaseCode = "h",
			Date = "xeUgC3",
			Time = "pjXe",
		};

		var actual = Map.MapObject<M3_Release>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("h", true)]
	public void Validation_RequiredReleaseCode(string releaseCode, bool isValidExpected)
	{
		var subject = new M3_Release();
		subject.ReleaseCode = releaseCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
