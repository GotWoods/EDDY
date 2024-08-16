using Eddy.Core.Validation;
using Eddy.Edifact.Mapping;
using Eddy.Edifact.Models.D98A;
using Eddy.Edifact.Models.D98A.Composites;

namespace Eddy.Edifact.Tests.Models.D98A;

public class CEDTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string line = "CED+j++9";

		var expected = new CED_ComputerEnvironmentDetails()
		{
			ComputerEnvironmentDetailsQualifier = "j",
			ComputerEnvironmentIdentification = null,
			FileGeneratingCommand = "9",
		};

		var actual = Map.MapObject<CED_ComputerEnvironmentDetails>(line, MapOptionsForTesting.EdifactDefaultEndsWithSingleQuote);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("j", true)]
	public void Validation_RequiredComputerEnvironmentDetailsQualifier(string computerEnvironmentDetailsQualifier, bool isValidExpected)
	{
		var subject = new CED_ComputerEnvironmentDetails();
		//Required fields
		subject.ComputerEnvironmentIdentification = new C079_ComputerEnvironmentIdentification();
		//Test Parameters
		subject.ComputerEnvironmentDetailsQualifier = computerEnvironmentDetailsQualifier;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("A", true)]
	public void Validation_RequiredComputerEnvironmentIdentification(string computerEnvironmentIdentification, bool isValidExpected)
	{
		var subject = new CED_ComputerEnvironmentDetails();
		//Required fields
		subject.ComputerEnvironmentDetailsQualifier = "j";
		//Test Parameters
		if (computerEnvironmentIdentification != "") 
			subject.ComputerEnvironmentIdentification = new C079_ComputerEnvironmentIdentification();
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
