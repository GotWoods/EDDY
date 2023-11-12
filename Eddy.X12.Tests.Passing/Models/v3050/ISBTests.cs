using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3050;

namespace Eddy.x12.Tests.Models.v3050;

public class ISBTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "ISB*1";

		var expected = new ISB_GradeOfServiceRequestSegment()
		{
			GradeOfServiceCode = "1",
		};

		var actual = Map.MapObject<ISB_GradeOfServiceRequestSegment>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("1", true)]
	public void Validation_RequiredGradeOfServiceCode(string gradeOfServiceCode, bool isValidExpected)
	{
		var subject = new ISB_GradeOfServiceRequestSegment();
		//Required fields
		//Test Parameters
		subject.GradeOfServiceCode = gradeOfServiceCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
