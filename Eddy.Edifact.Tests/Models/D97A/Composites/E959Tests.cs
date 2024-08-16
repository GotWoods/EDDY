using Eddy.Core.Validation;
using Eddy.Edifact.Mapping;
using Eddy.Edifact.Models.D97A;
using Eddy.Edifact.Models.D97A.Composites;

namespace Eddy.Edifact.Tests.Models.D97A.Composites;

public class E959Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string line = "l:n7EN:0J91:w:s";

		var expected = new E959_ServiceDateTimeLocationInformation()
		{
			SpecialServicesCoded = "l",
			Time = "n7EN",
			Time2 = "0J91",
			Date = "w",
			PlaceLocation = "s",
		};

		var actual = Map.MapComposite<E959_ServiceDateTimeLocationInformation>(line, MapOptionsForTesting.EdifactDefaultEndsWithSingleQuote);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("l", true)]
	public void Validation_RequiredSpecialServicesCoded(string specialServicesCoded, bool isValidExpected)
	{
		var subject = new E959_ServiceDateTimeLocationInformation();
		//Required fields
		//Test Parameters
		subject.SpecialServicesCoded = specialServicesCoded;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
