using Eddy.Core.Validation;
using Eddy.Edifact.Mapping;
using Eddy.Edifact.Models.D00B;
using Eddy.Edifact.Models.D00B.Composites;

namespace Eddy.Edifact.Tests.Models.D00B.Composites;

public class C233Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		var line = "x:h:Q:K:i:E";

		var expected = new C233_Service()
		{
			ServiceRequirementCode = "x",
			CodeListIdentificationCode = "h",
			CodeListResponsibleAgencyCode = "Q",
			ServiceRequirementCode2 = "K",
			CodeListIdentificationCode2 = "i",
			CodeListResponsibleAgencyCode2 = "E",
		};

		var actual = Map.MapComposite<C233_Service>(line, MapOptionsForTesting.EdifactDefaultEndsWithSingleQuote);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("x", true)]
	public void Validation_RequiredServiceRequirementCode(string serviceRequirementCode, bool isValidExpected)
	{
		var subject = new C233_Service();
		//Required fields
		//Test Parameters
		subject.ServiceRequirementCode = serviceRequirementCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
