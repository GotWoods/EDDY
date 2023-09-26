using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3040;

namespace Eddy.x12.Tests.Models.v3040;

public class RTTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "RT*wB*hUEO4N*Yc*HI*o*6*A7*Xn*A*6*yR*T";

		var expected = new RT_RateDestination()
		{
			RateValueQualifier = "wB",
			StandardPointLocationCode = "hUEO4N",
			DealerCode = "Yc",
			VehicleServiceCode = "HI",
			DistanceQualifier = "o",
			TariffDistance = 6,
			NationalMotorFreightTransportationAssociationLocationName = "A7",
			StateOrProvinceCode = "Xn",
			Name = "A",
			AddressInformation = "6",
			IdentificationCode = "yR",
			IdentificationCodeQualifier = "T",
		};

		var actual = Map.MapObject<RT_RateDestination>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("wB", true)]
	public void Validation_RequiredRateValueQualifier(string rateValueQualifier, bool isValidExpected)
	{
		var subject = new RT_RateDestination();
		//Required fields
		//Test Parameters
		subject.RateValueQualifier = rateValueQualifier;
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.DistanceQualifier) || !string.IsNullOrEmpty(subject.DistanceQualifier) || subject.TariffDistance > 0)
		{
			subject.DistanceQualifier = "o";
			subject.TariffDistance = 6;
		}
		if(!string.IsNullOrEmpty(subject.IdentificationCode) || !string.IsNullOrEmpty(subject.IdentificationCode) || !string.IsNullOrEmpty(subject.IdentificationCodeQualifier))
		{
			subject.IdentificationCode = "yR";
			subject.IdentificationCodeQualifier = "T";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", 0, true)]
	[InlineData("o", 6, true)]
	[InlineData("o", 0, false)]
	[InlineData("", 6, false)]
	public void Validation_AllAreRequiredDistanceQualifier(string distanceQualifier, int tariffDistance, bool isValidExpected)
	{
		var subject = new RT_RateDestination();
		//Required fields
		subject.RateValueQualifier = "wB";
		//Test Parameters
		subject.DistanceQualifier = distanceQualifier;
		if (tariffDistance > 0) 
			subject.TariffDistance = tariffDistance;
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.IdentificationCode) || !string.IsNullOrEmpty(subject.IdentificationCode) || !string.IsNullOrEmpty(subject.IdentificationCodeQualifier))
		{
			subject.IdentificationCode = "yR";
			subject.IdentificationCodeQualifier = "T";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("yR", "T", true)]
	[InlineData("yR", "", false)]
	[InlineData("", "T", false)]
	public void Validation_AllAreRequiredIdentificationCode(string identificationCode, string identificationCodeQualifier, bool isValidExpected)
	{
		var subject = new RT_RateDestination();
		//Required fields
		subject.RateValueQualifier = "wB";
		//Test Parameters
		subject.IdentificationCode = identificationCode;
		subject.IdentificationCodeQualifier = identificationCodeQualifier;
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.DistanceQualifier) || !string.IsNullOrEmpty(subject.DistanceQualifier) || subject.TariffDistance > 0)
		{
			subject.DistanceQualifier = "o";
			subject.TariffDistance = 6;
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

}
