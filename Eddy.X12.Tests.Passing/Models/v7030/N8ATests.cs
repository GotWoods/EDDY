using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v7030;

namespace Eddy.x12.Tests.Models.v7030;

public class N8ATests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "N8A*eB*7*2hB46dTO*o*Nr*9l*wC*G*M*V";

		var expected = new N8A_AdditionalReferenceInformation()
		{
			WaybillCrossReferenceCode = "eB",
			WaybillNumber = 7,
			Date = "2hB46dTO",
			ReferenceIdentification = "o",
			CityName = "Nr",
			StateOrProvinceCode = "9l",
			StandardCarrierAlphaCode = "wC",
			FreightStationAccountingCode = "G",
			EquipmentInitial = "M",
			EquipmentNumber = "V",
		};

		var actual = Map.MapObject<N8A_AdditionalReferenceInformation>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("Nr", "9l", true)]
	[InlineData("Nr", "", false)]
	[InlineData("", "9l", false)]
	public void Validation_AllAreRequiredCityName(string cityName, string stateOrProvinceCode, bool isValidExpected)
	{
		var subject = new N8A_AdditionalReferenceInformation();
		//Required fields
		//Test Parameters
		subject.CityName = cityName;
		subject.StateOrProvinceCode = stateOrProvinceCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

}
