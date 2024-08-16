using Eddy.Core.Validation;
using Eddy.Edifact.Mapping;
using Eddy.Edifact.Models.D06A;
using Eddy.Edifact.Models.D06A.Composites;

namespace Eddy.Edifact.Tests.Models.D06A;

public class EMPTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string line = "EMP+8++++B+6";

		var expected = new EMP_EmploymentDetails()
		{
			EmploymentDetailsCodeQualifier = "8",
			EmploymentCategory = null,
			Occupation = null,
			QualificationClassification = null,
			PersonJobTitle = "B",
			QualificationApplicationAreaCode = "6",
		};

		var actual = Map.MapObject<EMP_EmploymentDetails>(line, MapOptionsForTesting.EdifactDefaultEndsWithSingleQuote);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("8", true)]
	public void Validation_RequiredEmploymentDetailsCodeQualifier(string employmentDetailsCodeQualifier, bool isValidExpected)
	{
		var subject = new EMP_EmploymentDetails();
		//Required fields
		//Test Parameters
		subject.EmploymentDetailsCodeQualifier = employmentDetailsCodeQualifier;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
