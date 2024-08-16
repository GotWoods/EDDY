using Eddy.Core.Validation;
using Eddy.Edifact.Mapping;
using Eddy.Edifact.Models.D96A;
using Eddy.Edifact.Models.D96A.Composites;

namespace Eddy.Edifact.Tests.Models.D96A;

public class IRQTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string line = "IRQ+";

		var expected = new IRQ_InformationRequired()
		{
			InformationRequest = null,
		};

		var actual = Map.MapObject<IRQ_InformationRequired>(line, MapOptionsForTesting.EdifactDefaultEndsWithSingleQuote);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("A", true)]
	public void Validation_RequiredInformationRequest(string informationRequest, bool isValidExpected)
	{
		var subject = new IRQ_InformationRequired();
		//Required fields
		//Test Parameters
		if (informationRequest != "") 
			subject.InformationRequest = new C333_InformationRequest();
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
