using Eddy.Core.Validation;
using Eddy.Edifact.Mapping;
using Eddy.Edifact.Models.D96A;
using Eddy.Edifact.Models.D96A.Composites;

namespace Eddy.Edifact.Tests.Models.D96A.Composites;

public class C537Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		var line = "s:K:x";

		var expected = new C537_TransportPriority()
		{
			TransportPriorityCoded = "s",
			CodeListQualifier = "K",
			CodeListResponsibleAgencyCoded = "x",
		};

		var actual = Map.MapComposite<C537_TransportPriority>(line, MapOptionsForTesting.EdifactDefaultEndsWithSingleQuote);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("s", true)]
	public void Validation_RequiredTransportPriorityCoded(string transportPriorityCoded, bool isValidExpected)
	{
		var subject = new C537_TransportPriority();
		//Required fields
		//Test Parameters
		subject.TransportPriorityCoded = transportPriorityCoded;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
