using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v4010;

namespace Eddy.x12.Tests.Models.v4010;

public class RTTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "RT*vD*j4HIGU*wA*pD*U*7*2j*RF*N*j*SU*C";

		var expected = new RT_RateDestination()
		{
			RateValueQualifier = "vD",
			StandardPointLocationCode = "j4HIGU",
			DealerCode = "wA",
			VehicleServiceCode = "pD",
			DistanceQualifier = "U",
			TariffDistance = 7,
			NationalMotorFreightTransportationAssociationLocationName = "2j",
			StateOrProvinceCode = "RF",
			Name = "N",
			AddressInformation = "j",
			IdentificationCode = "SU",
			IdentificationCodeQualifier = "C",
		};

		var actual = Map.MapObject<RT_RateDestination>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("vD", true)]
	public void Validation_RequiredRateValueQualifier(string rateValueQualifier, bool isValidExpected)
	{
		var subject = new RT_RateDestination();
		//Required fields
		//Test Parameters
		subject.RateValueQualifier = rateValueQualifier;
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.DistanceQualifier) || !string.IsNullOrEmpty(subject.DistanceQualifier) || subject.TariffDistance > 0)
		{
			subject.DistanceQualifier = "U";
			subject.TariffDistance = 7;
		}
		if(!string.IsNullOrEmpty(subject.IdentificationCode) || !string.IsNullOrEmpty(subject.IdentificationCode) || !string.IsNullOrEmpty(subject.IdentificationCodeQualifier))
		{
			subject.IdentificationCode = "SU";
			subject.IdentificationCodeQualifier = "C";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", 0, true)]
	[InlineData("U", 7, true)]
	[InlineData("U", 0, false)]
	[InlineData("", 7, false)]
	public void Validation_AllAreRequiredDistanceQualifier(string distanceQualifier, int tariffDistance, bool isValidExpected)
	{
		var subject = new RT_RateDestination();
		//Required fields
		subject.RateValueQualifier = "vD";
		//Test Parameters
		subject.DistanceQualifier = distanceQualifier;
		if (tariffDistance > 0) 
			subject.TariffDistance = tariffDistance;
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.IdentificationCode) || !string.IsNullOrEmpty(subject.IdentificationCode) || !string.IsNullOrEmpty(subject.IdentificationCodeQualifier))
		{
			subject.IdentificationCode = "SU";
			subject.IdentificationCodeQualifier = "C";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("SU", "C", true)]
	[InlineData("SU", "", false)]
	[InlineData("", "C", false)]
	public void Validation_AllAreRequiredIdentificationCode(string identificationCode, string identificationCodeQualifier, bool isValidExpected)
	{
		var subject = new RT_RateDestination();
		//Required fields
		subject.RateValueQualifier = "vD";
		//Test Parameters
		subject.IdentificationCode = identificationCode;
		subject.IdentificationCodeQualifier = identificationCodeQualifier;
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.DistanceQualifier) || !string.IsNullOrEmpty(subject.DistanceQualifier) || subject.TariffDistance > 0)
		{
			subject.DistanceQualifier = "U";
			subject.TariffDistance = 7;
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

}
