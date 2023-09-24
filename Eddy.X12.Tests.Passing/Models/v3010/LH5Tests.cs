using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3010;

namespace Eddy.x12.Tests.Models.v3010;

public class LH5Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "LH5*h6bCbk2*B*zJ4ikOr*j";

		var expected = new LH5_HazardousMaterialShipmentContacts()
		{
			CommunicationNumber = "h6bCbk2",
			Name = "B",
			CommunicationNumber2 = "zJ4ikOr",
			Name2 = "j",
		};

		var actual = Map.MapObject<LH5_HazardousMaterialShipmentContacts>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("h6bCbk2", true)]
	public void Validation_RequiredCommunicationNumber(string communicationNumber, bool isValidExpected)
	{
		var subject = new LH5_HazardousMaterialShipmentContacts();
		subject.CommunicationNumber = communicationNumber;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
