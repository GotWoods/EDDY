using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.v4010;
using Eddy.x12.Models.v4010.Composites;

namespace Eddy.x12.Tests.Models.v4010.Composites;

public class C041Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		var x12Line = "7pWKvSg7*41";

		var expected = new C041_CompositeDate()
		{
			Date = "7pWKvSg7",
			Century = 41,
		};

		var actual = Map.MapObject<C041_CompositeDate>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("7pWKvSg7", true)]
	public void Validation_RequiredDate(string date, bool isValidExpected)
	{
		var subject = new C041_CompositeDate();
		//Required fields
		//Test Parameters
		subject.Date = date;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
