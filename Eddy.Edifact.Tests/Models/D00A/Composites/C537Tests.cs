using Eddy.Core.Validation;
using Eddy.Edifact.Mapping;
using Eddy.Edifact.Models.D00A;
using Eddy.Edifact.Models.D00A.Composites;

namespace Eddy.Edifact.Tests.Models.D00A.Composites;

public class C537Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		var line = "c:6:2";

		var expected = new C537_TransportPriority()
		{
			TransportServicePriorityCode = "c",
			CodeListIdentificationCode = "6",
			CodeListResponsibleAgencyCode = "2",
		};

		var actual = Map.MapComposite<C537_TransportPriority>(line, MapOptionsForTesting.EdifactDefaultEndsWithSingleQuote);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("c", true)]
	public void Validation_RequiredTransportServicePriorityCode(string transportServicePriorityCode, bool isValidExpected)
	{
		var subject = new C537_TransportPriority();
		//Required fields
		//Test Parameters
		subject.TransportServicePriorityCode = transportServicePriorityCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
