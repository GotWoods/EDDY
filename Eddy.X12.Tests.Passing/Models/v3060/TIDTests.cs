using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3060;

namespace Eddy.x12.Tests.Models.v3060;

public class TIDTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "TID*w5*c*0*v*L*C*G*u*n";

		var expected = new TID_TaskIdentification()
		{
			TaskIDQualifier = "w5",
			TaskIdentifier = "c",
			RelationshipTaskIdentifier = "0",
			Description = "v",
			WorkStatusCode = "L",
			ActionCode = "C",
			ReferenceIdentification = "G",
			ReferenceIdentification2 = "u",
			Level = "n",
		};

		var actual = Map.MapObject<TID_TaskIdentification>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("w5", true)]
	public void Validation_RequiredTaskIDQualifier(string taskIDQualifier, bool isValidExpected)
	{
		var subject = new TID_TaskIdentification();
		//Required fields
		//Test Parameters
		subject.TaskIDQualifier = taskIDQualifier;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
