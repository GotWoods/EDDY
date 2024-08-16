using Eddy.Core.Validation;
using Eddy.Edifact.Mapping;
using Eddy.Edifact.Models.D99B;
using Eddy.Edifact.Models.D99B.Composites;

namespace Eddy.Edifact.Tests.Models.D99B.Composites;

public class C233Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		var line = "x:w:c:G:B:T";

		var expected = new C233_Service()
		{
			ServiceRequirementCode = "x",
			CodeListIdentificationCode = "w",
			CodeListResponsibleAgencyCode = "c",
			ServiceRequirementCode2 = "G",
			CodeListIdentificationCode2 = "B",
			CodeListResponsibleAgencyCode2 = "T",
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
