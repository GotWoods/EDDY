using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v4030;

namespace Eddy.x12.Tests.Models.v4030;

public class BLTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "BL*nC*O*R*IIypCt*Bc*Se*gJ*JMbiSr*Ky*HQ*Q1*Y9*xk*5d*Uc*S0*7x";

		var expected = new BL_BillingInformation()
		{
			RebillReasonCode = "nC",
			FreightStationAccountingCode = "O",
			FreightStationAccountingCode2 = "R",
			StandardPointLocationCode = "IIypCt",
			CityName = "Bc",
			StateOrProvinceCode = "Se",
			CountryCode = "gJ",
			StandardPointLocationCode2 = "JMbiSr",
			CityName2 = "Ky",
			StateOrProvinceCode2 = "HQ",
			CountryCode2 = "Q1",
			StandardCarrierAlphaCode = "Y9",
			StandardCarrierAlphaCode2 = "xk",
			StandardCarrierAlphaCode3 = "5d",
			StandardCarrierAlphaCode4 = "Uc",
			StandardCarrierAlphaCode5 = "S0",
			StandardCarrierAlphaCode6 = "7x",
		};

		var actual = Map.MapObject<BL_BillingInformation>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("nC", true)]
	public void Validation_RequiredRebillReasonCode(string rebillReasonCode, bool isValidExpected)
	{
		var subject = new BL_BillingInformation();
		//Required fields
		//Test Parameters
		subject.RebillReasonCode = rebillReasonCode;
		//At Least one
		subject.FreightStationAccountingCode = "O";
		subject.FreightStationAccountingCode2 = "R";
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", "", false)]
	[InlineData("O", "Bc", true)]
	[InlineData("O", "", true)]
	[InlineData("", "Bc", true)]
	public void Validation_AtLeastOneFreightStationAccountingCode(string freightStationAccountingCode, string cityName, bool isValidExpected)
	{
		var subject = new BL_BillingInformation();
		//Required fields
		subject.RebillReasonCode = "nC";
		//Test Parameters
		subject.FreightStationAccountingCode = freightStationAccountingCode;
		subject.CityName = cityName;
		//At Least one
		subject.FreightStationAccountingCode2 = "R";
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.AtLeastOneIsRequired);
	}

	[Theory]
	[InlineData("", "", false)]
	[InlineData("R", "Ky", true)]
	[InlineData("R", "", true)]
	[InlineData("", "Ky", true)]
	public void Validation_AtLeastOneFreightStationAccountingCode2(string freightStationAccountingCode2, string cityName2, bool isValidExpected)
	{
		var subject = new BL_BillingInformation();
		//Required fields
		subject.RebillReasonCode = "nC";
		//Test Parameters
		subject.FreightStationAccountingCode2 = freightStationAccountingCode2;
		subject.CityName2 = cityName2;
		//At Least one
		subject.FreightStationAccountingCode = "O";
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.AtLeastOneIsRequired);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("Se", "Bc", true)]
	[InlineData("Se", "", false)]
	[InlineData("", "Bc", true)]
	public void Validation_ARequiresBStateOrProvinceCode(string stateOrProvinceCode, string cityName, bool isValidExpected)
	{
		var subject = new BL_BillingInformation();
		//Required fields
		subject.RebillReasonCode = "nC";
		//Test Parameters
		subject.StateOrProvinceCode = stateOrProvinceCode;
		subject.CityName = cityName;
		//At Least one
		subject.FreightStationAccountingCode = "O";
		subject.FreightStationAccountingCode2 = "R";
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("HQ", "Ky", true)]
	[InlineData("HQ", "", false)]
	[InlineData("", "Ky", true)]
	public void Validation_ARequiresBStateOrProvinceCode2(string stateOrProvinceCode2, string cityName2, bool isValidExpected)
	{
		var subject = new BL_BillingInformation();
		//Required fields
		subject.RebillReasonCode = "nC";
		//Test Parameters
		subject.StateOrProvinceCode2 = stateOrProvinceCode2;
		subject.CityName2 = cityName2;
		//At Least one
		subject.FreightStationAccountingCode = "O";
		subject.FreightStationAccountingCode2 = "R";
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
	}

}
