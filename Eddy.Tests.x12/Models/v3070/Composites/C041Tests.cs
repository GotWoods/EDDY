using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.v3070;
using Eddy.x12.Models.v3070.Composites;

namespace Eddy.x12.Tests.Models.v3070.Composites;

public class C041Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		var x12Line = "vueCkX*73";

		var expected = new C041_CompositeDate()
		{
			Date = "vueCkX",
			Century = 73,
		};

		var actual = Map.MapObject<C041_CompositeDate>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("vueCkX", true)]
	public void Validation_RequiredDate(string date, bool isValidExpected)
	{
		var subject = new C041_CompositeDate();
		//Required fields
		//Test Parameters
		subject.Date = date;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
