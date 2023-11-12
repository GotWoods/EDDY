using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3050;

namespace Eddy.x12.Tests.Models.v3050;

public class RTTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "RT*Y9*NWqAnf*wG*WK*X*1*no*sy*W*3*iK*V";

		var expected = new RT_RateDestination()
		{
			RateValueQualifier = "Y9",
			StandardPointLocationCode = "NWqAnf",
			DealerCode = "wG",
			VehicleServiceCode = "WK",
			DistanceQualifier = "X",
			TariffDistance = 1,
			NationalMotorFreightTransportationAssociationLocationName = "no",
			StateOrProvinceCode = "sy",
			Name = "W",
			AddressInformation = "3",
			IdentificationCode = "iK",
			IdentificationCodeQualifier = "V",
		};

		var actual = Map.MapObject<RT_RateDestination>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("Y9", true)]
	public void Validation_RequiredRateValueQualifier(string rateValueQualifier, bool isValidExpected)
	{
		var subject = new RT_RateDestination();
		//Required fields
		//Test Parameters
		subject.RateValueQualifier = rateValueQualifier;
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.DistanceQualifier) || !string.IsNullOrEmpty(subject.DistanceQualifier) || subject.TariffDistance > 0)
		{
			subject.DistanceQualifier = "X";
			subject.TariffDistance = 1;
		}
		if(!string.IsNullOrEmpty(subject.IdentificationCode) || !string.IsNullOrEmpty(subject.IdentificationCode) || !string.IsNullOrEmpty(subject.IdentificationCodeQualifier))
		{
			subject.IdentificationCode = "iK";
			subject.IdentificationCodeQualifier = "V";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", 0, true)]
	[InlineData("X", 1, true)]
	[InlineData("X", 0, false)]
	[InlineData("", 1, false)]
	public void Validation_AllAreRequiredDistanceQualifier(string distanceQualifier, int tariffDistance, bool isValidExpected)
	{
		var subject = new RT_RateDestination();
		//Required fields
		subject.RateValueQualifier = "Y9";
		//Test Parameters
		subject.DistanceQualifier = distanceQualifier;
		if (tariffDistance > 0) 
			subject.TariffDistance = tariffDistance;
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.IdentificationCode) || !string.IsNullOrEmpty(subject.IdentificationCode) || !string.IsNullOrEmpty(subject.IdentificationCodeQualifier))
		{
			subject.IdentificationCode = "iK";
			subject.IdentificationCodeQualifier = "V";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("iK", "V", true)]
	[InlineData("iK", "", false)]
	[InlineData("", "V", false)]
	public void Validation_AllAreRequiredIdentificationCode(string identificationCode, string identificationCodeQualifier, bool isValidExpected)
	{
		var subject = new RT_RateDestination();
		//Required fields
		subject.RateValueQualifier = "Y9";
		//Test Parameters
		subject.IdentificationCode = identificationCode;
		subject.IdentificationCodeQualifier = identificationCodeQualifier;
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.DistanceQualifier) || !string.IsNullOrEmpty(subject.DistanceQualifier) || subject.TariffDistance > 0)
		{
			subject.DistanceQualifier = "X";
			subject.TariffDistance = 1;
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

}
