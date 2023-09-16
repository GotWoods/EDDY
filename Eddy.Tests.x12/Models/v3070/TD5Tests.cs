using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3070;

namespace Eddy.x12.Tests.Models.v3070;

public class TD5Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "TD5*e*t*Sp*a*O*xQ*m*5*zY*XA*5*2z*po*oN*7T";

		var expected = new TD5_CarrierDetailsRoutingSequenceTransitTime()
		{
			RoutingSequenceCode = "e",
			IdentificationCodeQualifier = "t",
			IdentificationCode = "Sp",
			TransportationMethodTypeCode = "a",
			Routing = "O",
			ShipmentOrderStatusCode = "xQ",
			LocationQualifier = "m",
			LocationIdentifier = "5",
			TransitDirectionCode = "zY",
			TransitTimeDirectionQualifier = "XA",
			TransitTime = 5,
			ServiceLevelCode = "2z",
			ServiceLevelCode2 = "po",
			ServiceLevelCode3 = "oN",
			CountryCode = "7T",
		};

		var actual = Map.MapObject<TD5_CarrierDetailsRoutingSequenceTransitTime>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("t", "Sp", true)]
	[InlineData("t", "", false)]
	[InlineData("", "Sp", true)]
	public void Validation_ARequiresBIdentificationCodeQualifier(string identificationCodeQualifier, string identificationCode, bool isValidExpected)
	{
		var subject = new TD5_CarrierDetailsRoutingSequenceTransitTime();
		subject.IdentificationCodeQualifier = identificationCodeQualifier;
		subject.IdentificationCode = identificationCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("m", "5", true)]
	[InlineData("m", "", false)]
	[InlineData("", "5", true)]
	public void Validation_ARequiresBRouting(string locationQualifier, string locationIdentifier, bool isValidExpected)
	{
		var subject = new TD5_CarrierDetailsRoutingSequenceTransitTime();
		subject.LocationQualifier = locationQualifier;
		subject.LocationIdentifier = locationIdentifier;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
	}

	[Theory]
	[InlineData("", 0, true)]
	[InlineData("XA", 5, true)]
	[InlineData("XA", 0, false)]
	[InlineData("", 5, true)]
	public void Validation_ARequiresBTransitTimeDirectionQualifier(string transitTimeDirectionQualifier, decimal transitTime, bool isValidExpected)
	{
		var subject = new TD5_CarrierDetailsRoutingSequenceTransitTime();
		subject.TransitTimeDirectionQualifier = transitTimeDirectionQualifier;
		if (transitTime > 0)
			subject.TransitTime = transitTime;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("po", "2z", true)]
	[InlineData("po", "", false)]
	[InlineData("", "2z", true)]
	public void Validation_ARequiresBServiceLevelCode2(string serviceLevelCode2, string serviceLevelCode, bool isValidExpected)
	{
		var subject = new TD5_CarrierDetailsRoutingSequenceTransitTime();
		subject.ServiceLevelCode2 = serviceLevelCode2;
		subject.ServiceLevelCode = serviceLevelCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("oN", "po", true)]
	[InlineData("oN", "", false)]
	[InlineData("", "po", true)]
	public void Validation_ARequiresBServiceLevelCode3(string serviceLevelCode3, string serviceLevelCode2, bool isValidExpected)
	{
		var subject = new TD5_CarrierDetailsRoutingSequenceTransitTime();
		subject.ServiceLevelCode3 = serviceLevelCode3;
		subject.ServiceLevelCode2 = serviceLevelCode2;
		if (serviceLevelCode2 != "")
			subject.ServiceLevelCode = "2z";
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("7T", "2z", true)]
	[InlineData("7T", "", false)]
	[InlineData("", "2z", true)]
	public void Validation_ARequiresBCountryCode(string countryCode, string serviceLevelCode, bool isValidExpected)
	{
		var subject = new TD5_CarrierDetailsRoutingSequenceTransitTime();
		subject.CountryCode = countryCode;
		subject.ServiceLevelCode = serviceLevelCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
	}

}
