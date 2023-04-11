using Eddy.Core.Validation;
using Eddy.x12.Mapping;
using Eddy.x12.Models;

namespace Eddy.Tests.x12.Models;

public class B13Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "B13*q*px";

		var expected = new B13_BeginningSegmentForAppointmentSchedule()
		{
			ReferenceIdentification = "q",
			StandardCarrierAlphaCode = "px",
		};

		var actual = Map.MapObject<B13_BeginningSegmentForAppointmentSchedule>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("q", true)]
	public void Validation_RequiredReferenceIdentification(string referenceIdentification, bool isValidExpected)
	{
		var subject = new B13_BeginningSegmentForAppointmentSchedule();
		subject.ReferenceIdentification = referenceIdentification;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
