using Eddy.Core.Validation;
using Eddy.Edifact.Mapping;
using Eddy.Edifact.Models.D96B;
using Eddy.Edifact.Models.D96B.Composites;

namespace Eddy.Edifact.Tests.Models.D96B;

public class QUATests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string line = "QUA+1+";

		var expected = new QUA_Qualification()
		{
			QualificationQualifier = "1",
			QualificationClassification = null,
		};

		var actual = Map.MapObject<QUA_Qualification>(line, MapOptionsForTesting.EdifactDefaultEndsWithSingleQuote);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("1", true)]
	public void Validation_RequiredQualificationQualifier(string qualificationQualifier, bool isValidExpected)
	{
		var subject = new QUA_Qualification();
		//Required fields
		//Test Parameters
		subject.QualificationQualifier = qualificationQualifier;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
