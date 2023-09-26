using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3070;

namespace Eddy.x12.Tests.Models.v3070;

public class RTTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "RT*Mv*MdW5D8*mK*SW*B*3*IL*P6*d*k*Dk*S";

		var expected = new RT_RateDestination()
		{
			RateValueQualifier = "Mv",
			StandardPointLocationCode = "MdW5D8",
			DealerCode = "mK",
			VehicleServiceCode = "SW",
			DistanceQualifier = "B",
			TariffDistance = 3,
			NationalMotorFreightTransportationAssociationLocationName = "IL",
			StateOrProvinceCode = "P6",
			Name = "d",
			AddressInformation = "k",
			IdentificationCode = "Dk",
			IdentificationCodeQualifier = "S",
		};

		var actual = Map.MapObject<RT_RateDestination>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("Mv", true)]
	public void Validation_RequiredRateValueQualifier(string rateValueQualifier, bool isValidExpected)
	{
		var subject = new RT_RateDestination();
		//Required fields
		//Test Parameters
		subject.RateValueQualifier = rateValueQualifier;
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.DistanceQualifier) || !string.IsNullOrEmpty(subject.DistanceQualifier) || subject.TariffDistance > 0)
		{
			subject.DistanceQualifier = "B";
			subject.TariffDistance = 3;
		}
		if(!string.IsNullOrEmpty(subject.IdentificationCode) || !string.IsNullOrEmpty(subject.IdentificationCode) || !string.IsNullOrEmpty(subject.IdentificationCodeQualifier))
		{
			subject.IdentificationCode = "Dk";
			subject.IdentificationCodeQualifier = "S";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", 0, true)]
	[InlineData("B", 3, true)]
	[InlineData("B", 0, false)]
	[InlineData("", 3, false)]
	public void Validation_AllAreRequiredDistanceQualifier(string distanceQualifier, int tariffDistance, bool isValidExpected)
	{
		var subject = new RT_RateDestination();
		//Required fields
		subject.RateValueQualifier = "Mv";
		//Test Parameters
		subject.DistanceQualifier = distanceQualifier;
		if (tariffDistance > 0) 
			subject.TariffDistance = tariffDistance;
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.IdentificationCode) || !string.IsNullOrEmpty(subject.IdentificationCode) || !string.IsNullOrEmpty(subject.IdentificationCodeQualifier))
		{
			subject.IdentificationCode = "Dk";
			subject.IdentificationCodeQualifier = "S";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("Dk", "S", true)]
	[InlineData("Dk", "", false)]
	[InlineData("", "S", false)]
	public void Validation_AllAreRequiredIdentificationCode(string identificationCode, string identificationCodeQualifier, bool isValidExpected)
	{
		var subject = new RT_RateDestination();
		//Required fields
		subject.RateValueQualifier = "Mv";
		//Test Parameters
		subject.IdentificationCode = identificationCode;
		subject.IdentificationCodeQualifier = identificationCodeQualifier;
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.DistanceQualifier) || !string.IsNullOrEmpty(subject.DistanceQualifier) || subject.TariffDistance > 0)
		{
			subject.DistanceQualifier = "B";
			subject.TariffDistance = 3;
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

}
