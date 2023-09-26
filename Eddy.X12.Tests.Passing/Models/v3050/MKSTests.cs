using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3050;

namespace Eddy.x12.Tests.Models.v3050;

public class MKSTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "MKS*x*T*C";

		var expected = new MKS_MarksAwarded()
		{
			MarkCodeType = "x",
			AcademicGradeQualifier = "T",
			AcademicGrade = "C",
		};

		var actual = Map.MapObject<MKS_MarksAwarded>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("T", "C", true)]
	[InlineData("T", "", false)]
	[InlineData("", "C", false)]
	public void Validation_AllAreRequiredAcademicGradeQualifier(string academicGradeQualifier, string academicGrade, bool isValidExpected)
	{
		var subject = new MKS_MarksAwarded();
		//Required fields
		//Test Parameters
		subject.AcademicGradeQualifier = academicGradeQualifier;
		subject.AcademicGrade = academicGrade;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

}
