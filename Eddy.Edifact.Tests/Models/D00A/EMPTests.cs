using Eddy.Core.Validation;
using Eddy.Edifact.Mapping;
using Eddy.Edifact.Models.D00A;
using Eddy.Edifact.Models.D00A.Composites;

namespace Eddy.Edifact.Tests.Models.D00A;

public class EMPTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string line = "EMP+O++++f+H";

		var expected = new EMP_EmploymentDetails()
		{
			EmploymentDetailsCodeQualifier = "O",
			EmploymentCategory = null,
			Occupation = null,
			QualificationClassification = null,
			JobTitleDescription = "f",
			QualificationApplicationAreaCode = "H",
		};

		var actual = Map.MapObject<EMP_EmploymentDetails>(line, MapOptionsForTesting.EdifactDefaultEndsWithSingleQuote);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("O", true)]
	public void Validation_RequiredEmploymentDetailsCodeQualifier(string employmentDetailsCodeQualifier, bool isValidExpected)
	{
		var subject = new EMP_EmploymentDetails();
		//Required fields
		//Test Parameters
		subject.EmploymentDetailsCodeQualifier = employmentDetailsCodeQualifier;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
