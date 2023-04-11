using Eddy.Core.Validation;
using Eddy.x12.Mapping;
using Eddy.x12.Models;

namespace Eddy.Tests.x12.Models;

public class RTTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "RT*vq*enuLSG*j6*S1*V*5*Hv*eF*Y*x*aC*G";

		var expected = new RT_RateDestination()
		{
			RateValueQualifier = "vq",
			StandardPointLocationCode = "enuLSG",
			DealerCode = "j6",
			VehicleServiceCode = "S1",
			DistanceQualifier = "V",
			TariffDistance = 5,
			NationalMotorFreightTransportationAssociationLocationName = "Hv",
			StateOrProvinceCode = "eF",
			Name = "Y",
			AddressInformation = "x",
			IdentificationCode = "aC",
			IdentificationCodeQualifier = "G",
		};

		var actual = Map.MapObject<RT_RateDestination>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("vq", true)]
	public void Validation_RequiredRateValueQualifier(string rateValueQualifier, bool isValidExpected)
	{
		var subject = new RT_RateDestination();
		subject.RateValueQualifier = rateValueQualifier;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("",0, true)]
	[InlineData("V", 5, true)]
	[InlineData("", 5, false)]
	[InlineData("V", 0, false)]
	public void Validation_AllAreRequiredDistanceQualifier(string distanceQualifier, int tariffDistance, bool isValidExpected)
	{
		var subject = new RT_RateDestination();
		subject.RateValueQualifier = "vq";
		subject.DistanceQualifier = distanceQualifier;
		if (tariffDistance > 0)
		subject.TariffDistance = tariffDistance;

		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

	[Theory]
	[InlineData("","", true)]
	[InlineData("aC", "G", true)]
	[InlineData("", "G", false)]
	[InlineData("aC", "", false)]
	public void Validation_AllAreRequiredIdentificationCode(string identificationCode, string identificationCodeQualifier, bool isValidExpected)
	{
		var subject = new RT_RateDestination();
		subject.RateValueQualifier = "vq";
		subject.IdentificationCode = identificationCode;
		subject.IdentificationCodeQualifier = identificationCodeQualifier;

		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

}
