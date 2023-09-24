using Eddy.Core.Validation;
using Eddy.x12.Mapping;
using Eddy.x12.Models;

namespace Eddy.Tests.x12.Models;

public class SCPTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "SCP*WE*R*o*Bte";

		var expected = new SCP_BeginningSegmentForACartageWorkAssignmentResponse()
		{
			StandardCarrierAlphaCode = "WE",
			ReferenceIdentification = "R",
			ReservationActionCode = "o",
			ShipmentOrWorkAssignmentDeclineReasonCode = "Bte",
		};

		var actual = Map.MapObject<SCP_BeginningSegmentForACartageWorkAssignmentResponse>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("WE", true)]
	public void Validation_RequiredStandardCarrierAlphaCode(string standardCarrierAlphaCode, bool isValidExpected)
	{
		var subject = new SCP_BeginningSegmentForACartageWorkAssignmentResponse();
		subject.ReferenceIdentification = "R";
		subject.ReservationActionCode = "o";
		subject.StandardCarrierAlphaCode = standardCarrierAlphaCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("R", true)]
	public void Validation_RequiredReferenceIdentification(string referenceIdentification, bool isValidExpected)
	{
		var subject = new SCP_BeginningSegmentForACartageWorkAssignmentResponse();
		subject.StandardCarrierAlphaCode = "WE";
		subject.ReservationActionCode = "o";
		subject.ReferenceIdentification = referenceIdentification;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("o", true)]
	public void Validation_RequiredReservationActionCode(string reservationActionCode, bool isValidExpected)
	{
		var subject = new SCP_BeginningSegmentForACartageWorkAssignmentResponse();
		subject.StandardCarrierAlphaCode = "WE";
		subject.ReferenceIdentification = "R";
		subject.ReservationActionCode = reservationActionCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
