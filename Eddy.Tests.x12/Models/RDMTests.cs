using Eddy.Core.Validation;
using Eddy.x12.Mapping;
using Eddy.x12.Models;

namespace Eddy.Tests.x12.Models;

public class RDMTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "RDM*R*T*z**";

		var expected = new RDM_RemittanceDeliveryMethod()
		{
			ReportTransmissionCode = "R",
			Name = "T",
			CommunicationNumber = "z",
			ReferenceIdentifier = "",
			ReferenceIdentifier2 = "",
		};

		var actual = Map.MapObject<RDM_RemittanceDeliveryMethod>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("R", true)]
	public void Validation_RequiredReportTransmissionCode(string reportTransmissionCode, bool isValidExpected)
	{
		var subject = new RDM_RemittanceDeliveryMethod();
		subject.ReportTransmissionCode = reportTransmissionCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
