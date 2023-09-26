using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v4030;

namespace Eddy.x12.Tests.Models.v4030;

public class TIDTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "TID*09*P*f*L*d*O*N*r*w";

		var expected = new TID_TaskIdentification()
		{
			TaskIDQualifier = "09",
			TaskIdentifier = "P",
			RelationshipTaskIdentifier = "f",
			Description = "L",
			WorkStatusCode = "d",
			ActionCode = "O",
			ReferenceIdentification = "N",
			ReferenceIdentification2 = "r",
			Level = "w",
		};

		var actual = Map.MapObject<TID_TaskIdentification>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("09", true)]
	public void Validation_RequiredTaskIDQualifier(string taskIDQualifier, bool isValidExpected)
	{
		var subject = new TID_TaskIdentification();
		//Required fields
		//Test Parameters
		subject.TaskIDQualifier = taskIDQualifier;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
