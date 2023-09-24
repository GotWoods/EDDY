using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3010;

namespace Eddy.x12.Tests.Models.v3010;

public class V3Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "V3*zu*UibX9l*0K*1tpgcN";

		var expected = new V3_VesselSchedule()
		{
			CurrentPortOfLoading = "zu",
			SailingDate = "UibX9l",
			NextPortOfDischarge = "0K",
			ETADate = "1tpgcN",
		};

		var actual = Map.MapObject<V3_VesselSchedule>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("zu", true)]
	public void Validation_RequiredCurrentPortOfLoading(string currentPortOfLoading, bool isValidExpected)
	{
		var subject = new V3_VesselSchedule();
		subject.SailingDate = "UibX9l";
		subject.CurrentPortOfLoading = currentPortOfLoading;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("UibX9l", true)]
	public void Validation_RequiredSailingDate(string sailingDate, bool isValidExpected)
	{
		var subject = new V3_VesselSchedule();
		subject.CurrentPortOfLoading = "zu";
		subject.SailingDate = sailingDate;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
