using Eddy.Core.Validation;
using Eddy.Edifact.Mapping;
using Eddy.Edifact.Models.D99B;
using Eddy.Edifact.Models.D99B.Composites;

namespace Eddy.Edifact.Tests.Models.D99B;

public class CEDTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string line = "CED+k++q";

		var expected = new CED_ComputerEnvironmentDetails()
		{
			ComputerEnvironmentDetailsCodeQualifier = "k",
			ComputerEnvironmentIdentification = null,
			FileGeneratingCommand = "q",
		};

		var actual = Map.MapObject<CED_ComputerEnvironmentDetails>(line, MapOptionsForTesting.EdifactDefaultEndsWithSingleQuote);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("k", true)]
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
		subject.ComputerEnvironmentDetailsCodeQualifier = "k";
		//Test Parameters
		if (computerEnvironmentIdentification != "") 
			subject.ComputerEnvironmentIdentification = new C079_ComputerEnvironmentIdentification();
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
