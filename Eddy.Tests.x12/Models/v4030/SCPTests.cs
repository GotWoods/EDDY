using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v4030;

namespace Eddy.x12.Tests.Models.v4030;

public class SCPTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "SCP*t8*q*L*Koy";

		var expected = new SCP_BeginningSegmentForACartageWorkAssignmentResponse()
		{
			StandardCarrierAlphaCode = "t8",
			ReferenceIdentification = "q",
			ReservationActionCode = "L",
			ShipmentOrWorkAssignmentDeclineReasonCode = "Koy",
		};

		var actual = Map.MapObject<SCP_BeginningSegmentForACartageWorkAssignmentResponse>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("t8", true)]
	public void Validation_RequiredStandardCarrierAlphaCode(string standardCarrierAlphaCode, bool isValidExpected)
	{
		var subject = new SCP_BeginningSegmentForACartageWorkAssignmentResponse();
		//Required fields
		subject.ReferenceIdentification = "q";
		subject.ReservationActionCode = "L";
		//Test Parameters
		subject.StandardCarrierAlphaCode = standardCarrierAlphaCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("q", true)]
	public void Validation_RequiredReferenceIdentification(string referenceIdentification, bool isValidExpected)
	{
		var subject = new SCP_BeginningSegmentForACartageWorkAssignmentResponse();
		//Required fields
		subject.StandardCarrierAlphaCode = "t8";
		subject.ReservationActionCode = "L";
		//Test Parameters
		subject.ReferenceIdentification = referenceIdentification;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("L", true)]
	public void Validation_RequiredReservationActionCode(string reservationActionCode, bool isValidExpected)
	{
		var subject = new SCP_BeginningSegmentForACartageWorkAssignmentResponse();
		//Required fields
		subject.StandardCarrierAlphaCode = "t8";
		subject.ReferenceIdentification = "q";
		//Test Parameters
		subject.ReservationActionCode = reservationActionCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
