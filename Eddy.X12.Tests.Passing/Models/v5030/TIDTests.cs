using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v5030;

namespace Eddy.x12.Tests.Models.v5030;

public class TIDTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "TID*3P*6*P*y*3*p*h*Z*M";

		var expected = new TID_TaskIdentification()
		{
			TaskIDQualifier = "3P",
			TaskIdentifier = "6",
			RelationshipTaskIdentifier = "P",
			Description = "y",
			WorkStatusCode = "3",
			ActionCode = "p",
			ReferenceIdentification = "h",
			ReferenceIdentification2 = "Z",
			ReportingStructureIdentifier = "M",
		};

		var actual = Map.MapObject<TID_TaskIdentification>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("3P", true)]
	public void Validation_RequiredTaskIDQualifier(string taskIDQualifier, bool isValidExpected)
	{
		var subject = new TID_TaskIdentification();
		//Required fields
		//Test Parameters
		subject.TaskIDQualifier = taskIDQualifier;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
