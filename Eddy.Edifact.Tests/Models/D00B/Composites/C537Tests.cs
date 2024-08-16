using Eddy.Core.Validation;
using Eddy.Edifact.Mapping;
using Eddy.Edifact.Models.D00B;
using Eddy.Edifact.Models.D00B.Composites;

namespace Eddy.Edifact.Tests.Models.D00B.Composites;

public class C537Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		var line = "e:U:p";

		var expected = new C537_TransportPriority()
		{
			TransportServicePriorityCode = "e",
			CodeListIdentificationCode = "U",
			CodeListResponsibleAgencyCode = "p",
		};

		var actual = Map.MapComposite<C537_TransportPriority>(line, MapOptionsForTesting.EdifactDefaultEndsWithSingleQuote);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("e", true)]
	public void Validation_RequiredTransportServicePriorityCode(string transportServicePriorityCode, bool isValidExpected)
	{
		var subject = new C537_TransportPriority();
		//Required fields
		//Test Parameters
		subject.TransportServicePriorityCode = transportServicePriorityCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
