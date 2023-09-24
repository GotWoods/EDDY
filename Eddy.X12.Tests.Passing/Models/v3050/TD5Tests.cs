using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3050;

namespace Eddy.x12.Tests.Models.v3050;

public class TD5Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "TD5*U*M*pj*V*X*ix*E*u*CR*U6*7*TG";

		var expected = new TD5_CarrierDetailsRoutingSequenceTransitTime()
		{
			RoutingSequenceCode = "U",
			IdentificationCodeQualifier = "M",
			IdentificationCode = "pj",
			TransportationMethodTypeCode = "V",
			Routing = "X",
			ShipmentOrderStatusCode = "ix",
			LocationQualifier = "E",
			LocationIdentifier = "u",
			TransitDirectionCode = "CR",
			TransitTimeDirectionQualifier = "U6",
			TransitTime = 7,
			ServiceLevelCode = "TG",
		};

		var actual = Map.MapObject<TD5_CarrierDetailsRoutingSequenceTransitTime>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("M", "pj", true)]
	[InlineData("M", "", false)]
	[InlineData("", "pj", true)]
	public void Validation_ARequiresBIdentificationCodeQualifier(string identificationCodeQualifier, string identificationCode, bool isValidExpected)
	{
		var subject = new TD5_CarrierDetailsRoutingSequenceTransitTime();
		subject.IdentificationCodeQualifier = identificationCodeQualifier;
		subject.IdentificationCode = identificationCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("E", "u", true)]
	[InlineData("E", "", false)]
	[InlineData("", "u", true)]
	public void Validation_ARequiresBRouting(string locationQualifier, string locationIdentifier, bool isValidExpected)
	{
		var subject = new TD5_CarrierDetailsRoutingSequenceTransitTime();
		subject.LocationQualifier = locationQualifier;
		subject.LocationIdentifier = locationIdentifier;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
	}

	[Theory]
	[InlineData("", 0, true)]
	[InlineData("U6", 7, true)]
	[InlineData("U6", 0, false)]
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
