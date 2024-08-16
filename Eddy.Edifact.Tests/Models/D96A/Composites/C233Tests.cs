using Eddy.Core.Validation;
using Eddy.Edifact.Mapping;
using Eddy.Edifact.Models.D96A;
using Eddy.Edifact.Models.D96A.Composites;

namespace Eddy.Edifact.Tests.Models.D96A.Composites;

public class C233Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		var line = "J:Y:h:e:a:z";

		var expected = new C233_Service()
		{
			ServiceRequirementCoded = "J",
			CodeListQualifier = "Y",
			CodeListResponsibleAgencyCoded = "h",
			ServiceRequirementCoded2 = "e",
			CodeListQualifier2 = "a",
			CodeListResponsibleAgencyCoded2 = "z",
		};

		var actual = Map.MapComposite<C233_Service>(line, MapOptionsForTesting.EdifactDefaultEndsWithSingleQuote);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("J", true)]
	public void Validation_RequiredServiceRequirementCoded(string serviceRequirementCoded, bool isValidExpected)
	{
		var subject = new C233_Service();
		//Required fields
		//Test Parameters
		subject.ServiceRequirementCoded = serviceRequirementCoded;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
