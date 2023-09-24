using Eddy.Core.Validation;
using Eddy.x12.Mapping;
using Eddy.x12.Models;

namespace Eddy.Tests.x12.Models;

public class V3Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "V3*ct*aBDIaqyr*ih*dV47mlEW";

		var expected = new V3_VesselSchedule()
		{
			CurrentPortOfLoading = "ct",
			Date = "aBDIaqyr",
			NextPortOfDischarge = "ih",
			Date2 = "dV47mlEW",
		};

		var actual = Map.MapObject<V3_VesselSchedule>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("ct", true)]
	public void Validation_RequiredCurrentPortOfLoading(string currentPortOfLoading, bool isValidExpected)
	{
		var subject = new V3_VesselSchedule();
		subject.Date = "aBDIaqyr";
		subject.CurrentPortOfLoading = currentPortOfLoading;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("aBDIaqyr", true)]
	public void Validation_RequiredDate(string date, bool isValidExpected)
	{
		var subject = new V3_VesselSchedule();
		subject.CurrentPortOfLoading = "ct";
		subject.Date = date;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
