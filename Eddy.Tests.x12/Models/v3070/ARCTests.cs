using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3070;

namespace Eddy.x12.Tests.Models.v3070;

public class ARCTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "ARC*5*6C*OZ";

		var expected = new ARC_AnimalResultsCounts()
		{
			Count = 5,
			TestTypeCode = "6C",
			ObservationTypeCode = "OZ",
		};

		var actual = Map.MapObject<ARC_AnimalResultsCounts>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData(0, false)]
	[InlineData(5, true)]
	public void Validation_RequiredCount(int count, bool isValidExpected)
	{
		var subject = new ARC_AnimalResultsCounts();
		//Required fields
		//Test Parameters
		if (count > 0) 
			subject.Count = count;
		//At Least one
		subject.TestTypeCode = "6C";
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", "", false)]
	[InlineData("6C", "", true)]
	[InlineData("", "OZ", true)]
	public void Validation_AtLeastOneTestTypeCode(string testTypeCode, string observationTypeCode, bool isValidExpected)
	{
		var subject = new ARC_AnimalResultsCounts();
		//Required fields
		subject.Count = 5;
		//Test Parameters
		subject.TestTypeCode = testTypeCode;
		subject.ObservationTypeCode = observationTypeCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.AtLeastOneIsRequired);
	}

	[Theory]
	[InlineData("6C", "OZ", false)]
	[InlineData("6C", "", true)]
	[InlineData("", "OZ", true)]
	public void Validation_OnlyOneOfTestTypeCode(string testTypeCode, string observationTypeCode, bool isValidExpected)
	{
		var subject = new ARC_AnimalResultsCounts();
		//Required fields
		subject.Count = 5;
		//Test Parameters
		subject.TestTypeCode = testTypeCode;
		subject.ObservationTypeCode = observationTypeCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.OnlyOneOf);
	}

}
