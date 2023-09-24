using Eddy.Core.Validation;
using Eddy.x12.Mapping;
using Eddy.x12.Models;

namespace Eddy.Tests.x12.Models;

public class ISBTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "ISB*z";

		var expected = new ISB_GradeOfServiceRequestSegment()
		{
			GradeOfServiceCode = "z",
		};

		var actual = Map.MapObject<ISB_GradeOfServiceRequestSegment>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("z", true)]
	public void Validation_RequiredGradeOfServiceCode(string gradeOfServiceCode, bool isValidExpected)
	{
		var subject = new ISB_GradeOfServiceRequestSegment();
		subject.GradeOfServiceCode = gradeOfServiceCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
