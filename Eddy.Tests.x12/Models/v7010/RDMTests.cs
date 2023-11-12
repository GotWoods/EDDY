using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v7010;

namespace Eddy.x12.Tests.Models.v7010;

public class RDMTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "RDM*c*j*E**";

		var expected = new RDM_RemittanceDeliveryMethod()
		{
			ReportTransmissionCode = "c",
			Name = "j",
			CommunicationNumber = "E",
			ReferenceIdentifier = null,
			ReferenceIdentifier2 = null,
		};

		var actual = Map.MapObject<RDM_RemittanceDeliveryMethod>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("c", true)]
	public void Validation_RequiredReportTransmissionCode(string reportTransmissionCode, bool isValidExpected)
	{
		var subject = new RDM_RemittanceDeliveryMethod();
		//Required fields
		//Test Parameters
		subject.ReportTransmissionCode = reportTransmissionCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
