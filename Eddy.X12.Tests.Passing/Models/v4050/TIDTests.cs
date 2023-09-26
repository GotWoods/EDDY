using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v4050;

namespace Eddy.x12.Tests.Models.v4050;

public class TIDTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "TID*44*i*k*N*G*P*E*9*0";

		var expected = new TID_TaskIdentification()
		{
			TaskIDQualifier = "44",
			TaskIdentifier = "i",
			RelationshipTaskIdentifier = "k",
			Description = "N",
			WorkStatusCode = "G",
			ActionCode = "P",
			ReferenceIdentification = "E",
			ReferenceIdentification2 = "9",
			ReportingStructureIdentifier = "0",
		};

		var actual = Map.MapObject<TID_TaskIdentification>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("44", true)]
	public void Validation_RequiredTaskIDQualifier(string taskIDQualifier, bool isValidExpected)
	{
		var subject = new TID_TaskIdentification();
		//Required fields
		//Test Parameters
		subject.TaskIDQualifier = taskIDQualifier;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
