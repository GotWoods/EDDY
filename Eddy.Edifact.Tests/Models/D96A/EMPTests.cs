using Eddy.Core.Validation;
using Eddy.Edifact.Mapping;
using Eddy.Edifact.Models.D96A;
using Eddy.Edifact.Models.D96A.Composites;

namespace Eddy.Edifact.Tests.Models.D96A;

public class EMPTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string line = "EMP+A++++f+k";

		var expected = new EMP_EmploymentDetails()
		{
			EmploymentQualifier = "A",
			EmploymentCategory = null,
			Occupation = null,
			QualificationClassification = null,
			JobTitle = "f",
			QualificationAreaCoded = "k",
		};

		var actual = Map.MapObject<EMP_EmploymentDetails>(line, MapOptionsForTesting.EdifactDefaultEndsWithSingleQuote);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("A", true)]
	public void Validation_RequiredEmploymentQualifier(string employmentQualifier, bool isValidExpected)
	{
		var subject = new EMP_EmploymentDetails();
		//Required fields
		//Test Parameters
		subject.EmploymentQualifier = employmentQualifier;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
