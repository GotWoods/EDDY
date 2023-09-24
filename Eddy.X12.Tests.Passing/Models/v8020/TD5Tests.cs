using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v8020;

namespace Eddy.x12.Tests.Models.v8020;

public class TD5Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "TD5*0*Z*79*L*J*qh*k*S*rK*B8*3*bk*o0*LB*Qs";

		var expected = new TD5_CarrierDetailsRoutingSequenceTransitTime()
		{
			RoutingSequenceCode = "0",
			IdentificationCodeQualifier = "Z",
			IdentificationCode = "79",
			TransportationMethodTypeCode = "L",
			Routing = "J",
			ShipmentOrderStatusCode = "qh",
			LocationQualifier = "k",
			LocationIdentifier = "S",
			TransitDirectionCode = "rK",
			TransitTimeDirectionQualifier = "B8",
			TransitTime = 3,
			ServiceLevelCode = "bk",
			ServiceLevelCode2 = "o0",
			ServiceLevelCode3 = "LB",
			CountryCode = "Qs",
		};

		var actual = Map.MapObject<TD5_CarrierDetailsRoutingSequenceTransitTime>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("Z", "79", true)]
	[InlineData("Z", "", false)]
	[InlineData("", "79", true)]
	public void Validation_ARequiresBIdentificationCodeQualifier(string identificationCodeQualifier, string identificationCode, bool isValidExpected)
	{
		var subject = new TD5_CarrierDetailsRoutingSequenceTransitTime();
		subject.IdentificationCodeQualifier = identificationCodeQualifier;
		subject.IdentificationCode = identificationCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("k", "S", true)]
	[InlineData("k", "", false)]
	[InlineData("", "S", true)]
	public void Validation_ARequiresBLocationQualifier(string locationQualifier, string locationIdentifier, bool isValidExpected)
	{
		var subject = new TD5_CarrierDetailsRoutingSequenceTransitTime();
		subject.LocationQualifier = locationQualifier;
		subject.LocationIdentifier = locationIdentifier;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
	}

	[Theory]
	[InlineData("", 0, true)]
	[InlineData("B8", 3, true)]
	[InlineData("B8", 0, false)]
	[InlineData("", 3, true)]
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
	[InlineData("o0", "bk", true)]
	[InlineData("o0", "", false)]
	[InlineData("", "bk", true)]
	public void Validation_ARequiresBServiceLevelCode2(string serviceLevelCode2, string serviceLevelCode, bool isValidExpected)
	{
		var subject = new TD5_CarrierDetailsRoutingSequenceTransitTime();
		subject.ServiceLevelCode2 = serviceLevelCode2;
		subject.ServiceLevelCode = serviceLevelCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("LB", "o0", true)]
	[InlineData("LB", "", false)]
	[InlineData("", "o0", true)]
	public void Validation_ARequiresBServiceLevelCode3(string serviceLevelCode3, string serviceLevelCode2, bool isValidExpected)
	{
		var subject = new TD5_CarrierDetailsRoutingSequenceTransitTime();
		subject.ServiceLevelCode3 = serviceLevelCode3;
		subject.ServiceLevelCode2 = serviceLevelCode2;
		if (serviceLevelCode2 != "")
			subject.ServiceLevelCode = "bk";
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("Qs", "bk", true)]
	[InlineData("Qs", "", false)]
	[InlineData("", "bk", true)]
	public void Validation_ARequiresBCountryCode(string countryCode, string serviceLevelCode, bool isValidExpected)
	{
		var subject = new TD5_CarrierDetailsRoutingSequenceTransitTime();
		subject.CountryCode = countryCode;
		subject.ServiceLevelCode = serviceLevelCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
	}

}
