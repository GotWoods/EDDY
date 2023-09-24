using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v6030;

namespace Eddy.x12.Tests.Models.v6030;

public class F9Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "F9*E*gA*AY*3C*5*8h*Gz*Hx1fWJ*fNx*KnQuqc*VEN*Xv";

		var expected = new F9_OriginStation()
		{
			FreightStationAccountingCode = "E",
			CityName = "gA",
			StateOrProvinceCode = "AY",
			CountryCode = "3C",
			FreightStationAccountingCode2 = "5",
			CityName2 = "8h",
			StateOrProvinceCode2 = "Gz",
			StandardPointLocationCode = "Hx1fWJ",
			PostalCode = "fNx",
			StandardPointLocationCode2 = "KnQuqc",
			PostalCode2 = "VEN",
			CountryCode2 = "Xv",
		};

		var actual = Map.MapObject<F9_OriginStation>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("gA", true)]
	public void Validation_RequiredCityName(string cityName, bool isValidExpected)
	{
		var subject = new F9_OriginStation();
		subject.StateOrProvinceCode = "AY";
		subject.CityName = cityName;
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.CityName2) || !string.IsNullOrEmpty(subject.CityName2) || !string.IsNullOrEmpty(subject.StateOrProvinceCode2))
		{
			subject.CityName2 = "8h";
			subject.StateOrProvinceCode2 = "Gz";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("AY", true)]
	public void Validation_RequiredStateOrProvinceCode(string stateOrProvinceCode, bool isValidExpected)
	{
		var subject = new F9_OriginStation();
		subject.CityName = "gA";
		subject.StateOrProvinceCode = stateOrProvinceCode;
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.CityName2) || !string.IsNullOrEmpty(subject.CityName2) || !string.IsNullOrEmpty(subject.StateOrProvinceCode2))
		{
			subject.CityName2 = "8h";
			subject.StateOrProvinceCode2 = "Gz";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("8h", "Gz", true)]
	[InlineData("8h", "", false)]
	[InlineData("", "Gz", false)]
	public void Validation_AllAreRequiredCityName2(string cityName2, string stateOrProvinceCode2, bool isValidExpected)
	{
		var subject = new F9_OriginStation();
		subject.CityName = "gA";
		subject.StateOrProvinceCode = "AY";
		subject.CityName2 = cityName2;
		subject.StateOrProvinceCode2 = stateOrProvinceCode2;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

}
