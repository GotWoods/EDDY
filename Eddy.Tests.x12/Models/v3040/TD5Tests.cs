using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3040;

namespace Eddy.x12.Tests.Models.v3040;

public class TD5Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "TD5*r*w*H5*W*y*SD*z*p*r8*e1*6*73";

		var expected = new TD5_CarrierDetailsRoutingSequenceTransitTime()
		{
			RoutingSequenceCode = "r",
			IdentificationCodeQualifier = "w",
			IdentificationCode = "H5",
			TransportationMethodTypeCode = "W",
			Routing = "y",
			ShipmentOrderStatusCode = "SD",
			LocationQualifier = "z",
			LocationIdentifier = "p",
			TransitDirectionCode = "r8",
			TransitTimeDirectionQualifier = "e1",
			TransitTime = 6,
			ServiceLevelCode = "73",
		};

		var actual = Map.MapObject<TD5_CarrierDetailsRoutingSequenceTransitTime>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("w", "H5", true)]
	[InlineData("w", "", false)]
	[InlineData("", "H5", true)]
	public void Validation_ARequiresBIdentificationCodeQualifier(string identificationCodeQualifier, string identificationCode, bool isValidExpected)
	{
		var subject = new TD5_CarrierDetailsRoutingSequenceTransitTime();
		subject.IdentificationCodeQualifier = identificationCodeQualifier;
		subject.IdentificationCode = identificationCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("z", "p", true)]
	[InlineData("z", "", false)]
	[InlineData("", "p", true)]
	public void Validation_ARequiresBRouting(string locationQualifier, string locationIdentifier, bool isValidExpected)
	{
		var subject = new TD5_CarrierDetailsRoutingSequenceTransitTime();
		subject.LocationQualifier = locationQualifier;
		subject.LocationIdentifier = locationIdentifier;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
	}

	[Theory]
	[InlineData("", 0, true)]
	[InlineData("e1", 6, true)]
	[InlineData("e1", 0, false)]
	[InlineData("", 6, true)]
	public void Validation_ARequiresBTransitTimeDirectionQualifier(string transitTimeDirectionQualifier, decimal transitTime, bool isValidExpected)
	{
		var subject = new TD5_CarrierDetailsRoutingSequenceTransitTime();
		subject.TransitTimeDirectionQualifier = transitTimeDirectionQualifier;
		if (transitTime > 0)
			subject.TransitTime = transitTime;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
	}

}
