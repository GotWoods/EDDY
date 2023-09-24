using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3020;

namespace Eddy.x12.Tests.Models.v3020;

public class LH5Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "LH5*pLUALDs*y*27ydr1u*s";

		var expected = new LH5_HazardousMaterialShipmentContacts()
		{
			CommunicationNumber = "pLUALDs",
			Name = "y",
			CommunicationNumber2 = "27ydr1u",
			Name2 = "s",
		};

		var actual = Map.MapObject<LH5_HazardousMaterialShipmentContacts>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("pLUALDs", true)]
	public void Validation_RequiredCommunicationNumber(string communicationNumber, bool isValidExpected)
	{
		var subject = new LH5_HazardousMaterialShipmentContacts();
		subject.CommunicationNumber = communicationNumber;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
