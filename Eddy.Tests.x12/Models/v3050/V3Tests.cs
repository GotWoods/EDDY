using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3050;

namespace Eddy.x12.Tests.Models.v3050;

public class V3Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "V3*AK*KIaudI*0v*hlZFJH";

		var expected = new V3_VesselSchedule()
		{
			CurrentPortOfLoading = "AK",
			Date = "KIaudI",
			NextPortOfDischarge = "0v",
			Date2 = "hlZFJH",
		};

		var actual = Map.MapObject<V3_VesselSchedule>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("AK", true)]
	public void Validation_RequiredCurrentPortOfLoading(string currentPortOfLoading, bool isValidExpected)
	{
		var subject = new V3_VesselSchedule();
		subject.Date = "KIaudI";
		subject.CurrentPortOfLoading = currentPortOfLoading;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("KIaudI", true)]
	public void Validation_RequiredDate(string date, bool isValidExpected)
	{
		var subject = new V3_VesselSchedule();
		subject.CurrentPortOfLoading = "AK";
		subject.Date = date;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
