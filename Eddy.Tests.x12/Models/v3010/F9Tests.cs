using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3010;

namespace Eddy.x12.Tests.Models.v3010;

public class F9Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "F9*0*5K*12*Kp*v*1Y*8I*3x93Ja*MB0m";

		var expected = new F9_OriginStation()
		{
			FreightStationAccountingCode = "0",
			OriginStation = "5K",
			StateOrProvinceCode = "12",
			CountryCode = "Kp",
			BilledAtStationCode = "v",
			CityName = "1Y",
			StateOrProvinceCode2 = "8I",
			StandardPointLocationCode = "3x93Ja",
			PostalCode = "MB0m",
		};

		var actual = Map.MapObject<F9_OriginStation>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("5K", true)]
	public void Validation_RequiredOriginStation(string originStation, bool isValidExpected)
	{
		var subject = new F9_OriginStation();
		subject.StateOrProvinceCode = "12";
		subject.OriginStation = originStation;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("12", true)]
	public void Validation_RequiredStateOrProvinceCode(string stateOrProvinceCode, bool isValidExpected)
	{
		var subject = new F9_OriginStation();
		subject.OriginStation = "5K";
		subject.StateOrProvinceCode = stateOrProvinceCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
