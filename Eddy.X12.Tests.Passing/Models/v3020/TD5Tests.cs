using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3020;

namespace Eddy.x12.Tests.Models.v3020;

public class TD5Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "TD5*m*J*ws*y*a*XJ*i*5*54*9e*7";

		var expected = new TD5_CarrierDetailsRoutingSequenceTransitTime()
		{
			RoutingSequenceCode = "m",
			IdentificationCodeQualifier = "J",
			IdentificationCode = "ws",
			TransportationMethodTypeCode = "y",
			Routing = "a",
			ShipmentOrderStatusCode = "XJ",
			LocationQualifier = "i",
			LocationIdentifier = "5",
			TransitDirectionCode = "54",
			TransitTimeDirectionQualifier = "9e",
			TransitTime = 7,
		};

		var actual = Map.MapObject<TD5_CarrierDetailsRoutingSequenceTransitTime>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("J", "ws", true)]
	[InlineData("J", "", false)]
	[InlineData("", "ws", true)]
	public void Validation_ARequiresBIdentificationCodeQualifier(string identificationCodeQualifier, string identificationCode, bool isValidExpected)
	{
		var subject = new TD5_CarrierDetailsRoutingSequenceTransitTime();
		subject.IdentificationCodeQualifier = identificationCodeQualifier;
		subject.IdentificationCode = identificationCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("i", "5", true)]
	[InlineData("i", "", false)]
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
	[InlineData("9e", 7, true)]
	[InlineData("9e", 0, false)]
	[InlineData("", 7, true)]
	public void Validation_ARequiresBTransitTimeDirectionQualifier(string transitTimeDirectionQualifier, decimal transitTime, bool isValidExpected)
	{
		var subject = new TD5_CarrierDetailsRoutingSequenceTransitTime();
		subject.TransitTimeDirectionQualifier = transitTimeDirectionQualifier;
		if (transitTime > 0)
			subject.TransitTime = transitTime;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
	}

}
