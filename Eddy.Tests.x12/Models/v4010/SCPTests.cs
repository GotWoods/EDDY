using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v4010;

namespace Eddy.x12.Tests.Models.v4010;

public class SCPTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "SCP*l4*h*g*NGm";

		var expected = new SCP_BeginningSegmentForACartageWorkAssignmentResponse()
		{
			StandardCarrierAlphaCode = "l4",
			ReferenceIdentification = "h",
			ReservationActionCode = "g",
			ShipmentOrWorkAssignmentDeclineReasonCode = "NGm",
		};

		var actual = Map.MapObject<SCP_BeginningSegmentForACartageWorkAssignmentResponse>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("l4", true)]
	public void Validation_RequiredStandardCarrierAlphaCode(string standardCarrierAlphaCode, bool isValidExpected)
	{
		var subject = new SCP_BeginningSegmentForACartageWorkAssignmentResponse();
		//Required fields
		subject.ReferenceIdentification = "h";
		subject.ReservationActionCode = "g";
		//Test Parameters
		subject.StandardCarrierAlphaCode = standardCarrierAlphaCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("h", true)]
	public void Validation_RequiredReferenceIdentification(string referenceIdentification, bool isValidExpected)
	{
		var subject = new SCP_BeginningSegmentForACartageWorkAssignmentResponse();
		//Required fields
		subject.StandardCarrierAlphaCode = "l4";
		subject.ReservationActionCode = "g";
		//Test Parameters
		subject.ReferenceIdentification = referenceIdentification;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("g", true)]
	public void Validation_RequiredReservationActionCode(string reservationActionCode, bool isValidExpected)
	{
		var subject = new SCP_BeginningSegmentForACartageWorkAssignmentResponse();
		//Required fields
		subject.StandardCarrierAlphaCode = "l4";
		subject.ReferenceIdentification = "h";
		//Test Parameters
		subject.ReservationActionCode = reservationActionCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
