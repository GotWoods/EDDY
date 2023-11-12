using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v4020;

namespace Eddy.x12.Tests.Models.v4020;

public class RDMTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "RDM*2*W*K**";

		var expected = new RDM_RemittanceDeliveryMethod()
		{
			ReportTransmissionCode = "2",
			Name = "W",
			CommunicationNumber = "K",
			ReferenceIdentifier = null,
			ReferenceIdentifier2 = null,
		};

		var actual = Map.MapObject<RDM_RemittanceDeliveryMethod>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("2", true)]
	public void Validation_RequiredReportTransmissionCode(string reportTransmissionCode, bool isValidExpected)
	{
		var subject = new RDM_RemittanceDeliveryMethod();
		//Required fields
		//Test Parameters
		subject.ReportTransmissionCode = reportTransmissionCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
