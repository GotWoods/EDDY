using Eddy.Core.Validation;
using Eddy.x12.Mapping;
using Eddy.x12.Models;

namespace Eddy.Tests.x12.Models;

public class TIDTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "TID*Jz*h*t*x*3*g*F*T*Q";

		var expected = new TID_TaskIdentification()
		{
			TaskIDQualifier = "Jz",
			TaskIdentifier = "h",
			RelationshipTaskIdentifier = "t",
			Description = "x",
			WorkStatusCode = "3",
			ActionCode = "g",
			ReferenceIdentification = "F",
			ReferenceIdentification2 = "T",
			ReportingStructureIdentifier = "Q",
		};

		var actual = Map.MapObject<TID_TaskIdentification>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("Jz", true)]
	public void Validation_RequiredTaskIDQualifier(string taskIDQualifier, bool isValidExpected)
	{
		var subject = new TID_TaskIdentification();
		subject.TaskIDQualifier = taskIDQualifier;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
