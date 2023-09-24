using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v4010;

namespace Eddy.x12.Tests.Models.v4010;

public class V3Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "V3*Oy*T4yxTB4M*HK*1BfOBYR2";

		var expected = new V3_VesselSchedule()
		{
			CurrentPortOfLoading = "Oy",
			Date = "T4yxTB4M",
			NextPortOfDischarge = "HK",
			Date2 = "1BfOBYR2",
		};

		var actual = Map.MapObject<V3_VesselSchedule>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("Oy", true)]
	public void Validation_RequiredCurrentPortOfLoading(string currentPortOfLoading, bool isValidExpected)
	{
		var subject = new V3_VesselSchedule();
		subject.Date = "T4yxTB4M";
		subject.CurrentPortOfLoading = currentPortOfLoading;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("T4yxTB4M", true)]
	public void Validation_RequiredDate(string date, bool isValidExpected)
	{
		var subject = new V3_VesselSchedule();
		subject.CurrentPortOfLoading = "Oy";
		subject.Date = date;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
