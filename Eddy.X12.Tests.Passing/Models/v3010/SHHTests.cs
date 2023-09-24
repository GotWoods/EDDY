using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3010;

namespace Eddy.x12.Tests.Models.v3010;

public class SHHTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "SHH*7v*fkN*yDyaRn*X4hV";

		var expected = new SHH_GeneralSchedule()
		{
			SchedulingShippingCode = "7v",
			DateTimeQualifier = "fkN",
			Date = "yDyaRn",
			Time = "X4hV",
		};

		var actual = Map.MapObject<SHH_GeneralSchedule>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("7v", true)]
	public void Validation_RequiredSchedulingShippingCode(string schedulingShippingCode, bool isValidExpected)
	{
		var subject = new SHH_GeneralSchedule();
		subject.SchedulingShippingCode = schedulingShippingCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
