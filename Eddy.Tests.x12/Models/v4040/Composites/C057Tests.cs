using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.v4040;
using Eddy.x12.Models.v4040.Composites;

namespace Eddy.x12.Tests.Models.v4040.Composites;

public class C057Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		var x12Line = "jP*c";

		var expected = new C057_CommunicationNumberComponent()
		{
			CommunicationNumberQualifier = "jP",
			CommunicationNumber = "c",
		};

		var actual = Map.MapObject<C057_CommunicationNumberComponent>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("jP", "c", true)]
	[InlineData("jP", "", false)]
	[InlineData("", "c", false)]
	public void Validation_AllAreRequiredCommunicationNumberQualifier(string communicationNumberQualifier, string communicationNumber, bool isValidExpected)
	{
		var subject = new C057_CommunicationNumberComponent();
		//Required fields
		//Test Parameters
		subject.CommunicationNumberQualifier = communicationNumberQualifier;
		subject.CommunicationNumber = communicationNumber;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

}
