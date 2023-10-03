using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.v7010;
using Eddy.x12.Models.v7010.Composites;

namespace Eddy.x12.Tests.Models.v7010.Composites;

public class C057Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		var x12Line = "mt*E";

		var expected = new C057_CommunicationNumberComponent()
		{
			CommunicationNumberQualifier = "mt",
			CommunicationNumber = "E",
		};

		var actual = Map.MapObject<C057_CommunicationNumberComponent>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("mt", "E", true)]
	[InlineData("mt", "", false)]
	[InlineData("", "E", false)]
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
