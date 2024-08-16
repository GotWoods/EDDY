using Eddy.Core.Validation;
using Eddy.Edifact.Mapping;
using Eddy.Edifact.Models.D99B;
using Eddy.Edifact.Models.D99B.Composites;

namespace Eddy.Edifact.Tests.Models.D99B.Composites;

public class C537Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		var line = "m:K:2";

		var expected = new C537_TransportPriority()
		{
			TransportPriorityCoded = "m",
			CodeListIdentificationCode = "K",
			CodeListResponsibleAgencyCode = "2",
		};

		var actual = Map.MapComposite<C537_TransportPriority>(line, MapOptionsForTesting.EdifactDefaultEndsWithSingleQuote);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("m", true)]
	public void Validation_RequiredTransportPriorityCoded(string transportPriorityCoded, bool isValidExpected)
	{
		var subject = new C537_TransportPriority();
		//Required fields
		//Test Parameters
		subject.TransportPriorityCoded = transportPriorityCoded;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
