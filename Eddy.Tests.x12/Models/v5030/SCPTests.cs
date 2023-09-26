using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v5030;

namespace Eddy.x12.Tests.Models.v5030;

public class SCPTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "SCP*M8*I*E*UwU";

		var expected = new SCP_BeginningSegmentForACartageWorkAssignmentResponse()
		{
			StandardCarrierAlphaCode = "M8",
			ReferenceIdentification = "I",
			ReservationActionCode = "E",
			ShipmentOrWorkAssignmentDeclineReasonCode = "UwU",
		};

		var actual = Map.MapObject<SCP_BeginningSegmentForACartageWorkAssignmentResponse>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("M8", true)]
	public void Validation_RequiredStandardCarrierAlphaCode(string standardCarrierAlphaCode, bool isValidExpected)
	{
		var subject = new SCP_BeginningSegmentForACartageWorkAssignmentResponse();
		//Required fields
		subject.ReferenceIdentification = "I";
		subject.ReservationActionCode = "E";
		//Test Parameters
		subject.StandardCarrierAlphaCode = standardCarrierAlphaCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("I", true)]
	public void Validation_RequiredReferenceIdentification(string referenceIdentification, bool isValidExpected)
	{
		var subject = new SCP_BeginningSegmentForACartageWorkAssignmentResponse();
		//Required fields
		subject.StandardCarrierAlphaCode = "M8";
		subject.ReservationActionCode = "E";
		//Test Parameters
		subject.ReferenceIdentification = referenceIdentification;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("E", true)]
	public void Validation_RequiredReservationActionCode(string reservationActionCode, bool isValidExpected)
	{
		var subject = new SCP_BeginningSegmentForACartageWorkAssignmentResponse();
		//Required fields
		subject.StandardCarrierAlphaCode = "M8";
		subject.ReferenceIdentification = "I";
		//Test Parameters
		subject.ReservationActionCode = reservationActionCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
