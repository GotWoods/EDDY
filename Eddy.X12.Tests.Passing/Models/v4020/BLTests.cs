using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v4020;

namespace Eddy.x12.Tests.Models.v4020;

public class BLTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "BL*3z*i*F*S7RIKp*oK*cH*cR*XIH95t*5O*BM*nl*nq*Tz*c2*0y*04*Ih";

		var expected = new BL_BillingInformation()
		{
			RebillReasonCode = "3z",
			FreightStationAccountingCode = "i",
			FreightStationAccountingCode2 = "F",
			StandardPointLocationCode = "S7RIKp",
			CityName = "oK",
			StateOrProvinceCode = "cH",
			CountryCode = "cR",
			StandardPointLocationCode2 = "XIH95t",
			CityName2 = "5O",
			StateOrProvinceCode2 = "BM",
			CountryCode2 = "nl",
			StandardCarrierAlphaCode = "nq",
			StandardCarrierAlphaCode2 = "Tz",
			StandardCarrierAlphaCode3 = "c2",
			StandardCarrierAlphaCode4 = "0y",
			StandardCarrierAlphaCode5 = "04",
			StandardCarrierAlphaCode6 = "Ih",
		};

		var actual = Map.MapObject<BL_BillingInformation>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("3z", true)]
	public void Validation_RequiredRebillReasonCode(string rebillReasonCode, bool isValidExpected)
	{
		var subject = new BL_BillingInformation();
		//Required fields
		//Test Parameters
		subject.RebillReasonCode = rebillReasonCode;
		//At Least one
		subject.StandardPointLocationCode = "S7RIKp";
		subject.StandardPointLocationCode2 = "XIH95t";
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", "", false)]
	[InlineData("S7RIKp", "oK", true)]
	[InlineData("S7RIKp", "", true)]
	[InlineData("", "oK", true)]
	public void Validation_AtLeastOneStandardPointLocationCode(string standardPointLocationCode, string cityName, bool isValidExpected)
	{
		var subject = new BL_BillingInformation();
		//Required fields
		subject.RebillReasonCode = "3z";
		//Test Parameters
		subject.StandardPointLocationCode = standardPointLocationCode;
		subject.CityName = cityName;
		//At Least one
		subject.StandardPointLocationCode2 = "XIH95t";
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.AtLeastOneIsRequired);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("cH", "oK", true)]
	[InlineData("cH", "", false)]
	[InlineData("", "oK", true)]
	public void Validation_ARequiresBStateOrProvinceCode(string stateOrProvinceCode, string cityName, bool isValidExpected)
	{
		var subject = new BL_BillingInformation();
		//Required fields
		subject.RebillReasonCode = "3z";
		//Test Parameters
		subject.StateOrProvinceCode = stateOrProvinceCode;
		subject.CityName = cityName;
		//At Least one
		subject.StandardPointLocationCode = "S7RIKp";
		subject.StandardPointLocationCode2 = "XIH95t";
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
	}

	[Theory]
	[InlineData("", "", false)]
	[InlineData("XIH95t", "5O", true)]
	[InlineData("XIH95t", "", true)]
	[InlineData("", "5O", true)]
	public void Validation_AtLeastOneStandardPointLocationCode2(string standardPointLocationCode2, string cityName2, bool isValidExpected)
	{
		var subject = new BL_BillingInformation();
		//Required fields
		subject.RebillReasonCode = "3z";
		//Test Parameters
		subject.StandardPointLocationCode2 = standardPointLocationCode2;
		subject.CityName2 = cityName2;
		//At Least one
		subject.StandardPointLocationCode = "S7RIKp";
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.AtLeastOneIsRequired);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("BM", "5O", true)]
	[InlineData("BM", "", false)]
	[InlineData("", "5O", true)]
	public void Validation_ARequiresBStateOrProvinceCode2(string stateOrProvinceCode2, string cityName2, bool isValidExpected)
	{
		var subject = new BL_BillingInformation();
		//Required fields
		subject.RebillReasonCode = "3z";
		//Test Parameters
		subject.StateOrProvinceCode2 = stateOrProvinceCode2;
		subject.CityName2 = cityName2;
		//At Least one
		subject.StandardPointLocationCode = "S7RIKp";
		subject.StandardPointLocationCode2 = "XIH95t";
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
	}

}
