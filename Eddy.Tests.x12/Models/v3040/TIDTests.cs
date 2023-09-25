using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3040;

namespace Eddy.x12.Tests.Models.v3040;

public class TIDTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "TID*xl*o*y*W*j*w*g*a*I";

		var expected = new TID_TaskIdentification()
		{
			TaskIDQualifier = "xl",
			TaskIdentifier = "o",
			RelationshipTaskIdentifier = "y",
			Description = "W",
			WorkStatusCode = "j",
			ActionCode = "w",
			ReferenceNumber = "g",
			ReferenceNumber2 = "a",
			Level = "I",
		};

		var actual = Map.MapObject<TID_TaskIdentification>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("xl", true)]
	public void Validation_RequiredTaskIDQualifier(string taskIDQualifier, bool isValidExpected)
	{
		var subject = new TID_TaskIdentification();
		//Required fields
		//Test Parameters
		subject.TaskIDQualifier = taskIDQualifier;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
