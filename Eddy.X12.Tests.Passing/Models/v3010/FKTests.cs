using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3010;

namespace Eddy.x12.Tests.Models.v3010;

public class FKTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "FK*3g*3*30*Tg*E*X*9*8*6*6*5*1*2*2";

		var expected = new FK_Factor()
		{
			StandardCarrierAlphaCode = "3g",
			TransportationMethodTypeCode = "3",
			StateOrProvinceCode = "30",
			CityName = "Tg",
			Rule260JunctionCode = "E",
			PercentageDivision = "X",
			FactorAmount = 9,
			FactorAmount2 = 8,
			FactorAmount3 = 6,
			FactorAmount4 = 6,
			FactorAmount5 = 5,
			FactorAmount6 = 1,
			FactorAmount7 = 2,
			FactorAmount8 = 2,
		};

		var actual = Map.MapObject<FK_Factor>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("3g", true)]
	public void Validation_RequiredStandardCarrierAlphaCode(string standardCarrierAlphaCode, bool isValidExpected)
	{
		var subject = new FK_Factor();
		//Required fields
		subject.TransportationMethodTypeCode = "3";
		//Test Parameters
		subject.StandardCarrierAlphaCode = standardCarrierAlphaCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("3", true)]
	public void Validation_RequiredTransportationMethodTypeCode(string transportationMethodTypeCode, bool isValidExpected)
	{
		var subject = new FK_Factor();
		//Required fields
		subject.StandardCarrierAlphaCode = "3g";
		//Test Parameters
		subject.TransportationMethodTypeCode = transportationMethodTypeCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
