using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v4020;

namespace Eddy.x12.Tests.Models.v4020;

public class MKSTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "MKS*S*B*c";

		var expected = new MKS_MarksAwarded()
		{
			MarkCodeType = "S",
			AcademicGradeQualifier = "B",
			AcademicGrade = "c",
		};

		var actual = Map.MapObject<MKS_MarksAwarded>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("c", "B", true)]
	[InlineData("c", "", false)]
	[InlineData("", "B", true)]
	public void Validation_ARequiresBAcademicGradeQualifier(string academicGrade, string academicGradeQualifier, bool isValidExpected)
	{
		var subject = new MKS_MarksAwarded();
		//Required fields
		//Test Parameters
		subject.AcademicGrade = academicGrade;
		subject.AcademicGradeQualifier = academicGradeQualifier;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
	}

}
