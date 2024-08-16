using Eddy.Core.Validation;
using Eddy.Edifact.Mapping;
using Eddy.Edifact.Models.D00A;
using Eddy.Edifact.Models.D00A.Composites;

namespace Eddy.Edifact.Tests.Models.D00A;

public class QUATests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string line = "QUA+Y+";

		var expected = new QUA_Qualification()
		{
			QualificationTypeCodeQualifier = "Y",
			QualificationClassification = null,
		};

		var actual = Map.MapObject<QUA_Qualification>(line, MapOptionsForTesting.EdifactDefaultEndsWithSingleQuote);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("Y", true)]
	public void Validation_RequiredQualificationTypeCodeQualifier(string qualificationTypeCodeQualifier, bool isValidExpected)
	{
		var subject = new QUA_Qualification();
		//Required fields
		//Test Parameters
		subject.QualificationTypeCodeQualifier = qualificationTypeCodeQualifier;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
