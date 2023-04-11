using Eddy.Core.Validation;
using Eddy.x12.Mapping;
using Eddy.x12.Models;

namespace Eddy.Tests.x12.Models;

public class N8ATests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "N8A*s6*8*6CRf6WYd*5*wx*c3*4c*Y*q*u";

		var expected = new N8A_AdditionalReferenceInformation()
		{
			WaybillCrossReferenceCode = "s6",
			WaybillNumber = 8,
			Date = "6CRf6WYd",
			ReferenceIdentification = "5",
			CityName = "wx",
			StateOrProvinceCode = "c3",
			StandardCarrierAlphaCode = "4c",
			FreightStationAccountingCode = "Y",
			EquipmentInitial = "q",
			EquipmentNumber = "u",
		};

		var actual = Map.MapObject<N8A_AdditionalReferenceInformation>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("","", true)]
	[InlineData("wx", "c3", true)]
	[InlineData("", "c3", false)]
	[InlineData("wx", "", false)]
	public void Validation_AllAreRequiredCityName(string cityName, string stateOrProvinceCode, bool isValidExpected)
	{
		var subject = new N8A_AdditionalReferenceInformation();
		subject.CityName = cityName;
		subject.StateOrProvinceCode = stateOrProvinceCode;

		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

}
