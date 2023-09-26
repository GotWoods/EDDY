using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v8020;

namespace Eddy.x12.Tests.Models.v8020;

public class MKSTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "MKS*X*U*G";

		var expected = new MKS_MarksAwarded()
		{
			MarkCodeType = "X",
			AcademicGradeQualifier = "U",
			AcademicGrade = "G",
		};

		var actual = Map.MapObject<MKS_MarksAwarded>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("G", "U", true)]
	[InlineData("G", "", false)]
	[InlineData("", "U", true)]
	public void Validation_ARequiresBAcademicGrade(string academicGrade, string academicGradeQualifier, bool isValidExpected)
	{
		var subject = new MKS_MarksAwarded();
		//Required fields
		//Test Parameters
		subject.AcademicGrade = academicGrade;
		subject.AcademicGradeQualifier = academicGradeQualifier;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
	}

}
