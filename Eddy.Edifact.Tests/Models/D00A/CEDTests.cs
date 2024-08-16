using Eddy.Core.Validation;
using Eddy.Edifact.Mapping;
using Eddy.Edifact.Models.D00A;
using Eddy.Edifact.Models.D00A.Composites;

namespace Eddy.Edifact.Tests.Models.D00A;

public class CEDTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string line = "CED+K++a";

		var expected = new CED_ComputerEnvironmentDetails()
		{
			ComputerEnvironmentDetailsCodeQualifier = "K",
			ComputerEnvironmentIdentification = null,
			FileGenerationCommandName = "a",
		};

		var actual = Map.MapObject<CED_ComputerEnvironmentDetails>(line, MapOptionsForTesting.EdifactDefaultEndsWithSingleQuote);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("K", true)]
	public void Validation_RequiredComputerEnvironmentDetailsCodeQualifier(string computerEnvironmentDetailsCodeQualifier, bool isValidExpected)
	{
		var subject = new CED_ComputerEnvironmentDetails();
		//Required fields
		subject.ComputerEnvironmentIdentification = new C079_ComputerEnvironmentIdentification();
		//Test Parameters
		subject.ComputerEnvironmentDetailsCodeQualifier = computerEnvironmentDetailsCodeQualifier;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("A", true)]
	public void Validation_RequiredComputerEnvironmentIdentification(string computerEnvironmentIdentification, bool isValidExpected)
	{
		var subject = new CED_ComputerEnvironmentDetails();
		//Required fields
		subject.ComputerEnvironmentDetailsCodeQualifier = "K";
		//Test Parameters
		if (computerEnvironmentIdentification != "") 
			subject.ComputerEnvironmentIdentification = new C079_ComputerEnvironmentIdentification();
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
