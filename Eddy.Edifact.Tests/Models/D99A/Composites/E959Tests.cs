using Eddy.Core.Validation;
using Eddy.Edifact.Mapping;
using Eddy.Edifact.Models.D99A;
using Eddy.Edifact.Models.D99A.Composites;

namespace Eddy.Edifact.Tests.Models.D99A.Composites;

public class E959Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string line = "t:AC6P:1pgf:w:6:A:T:u:m:J:j:p";

		var expected = new E959_ServiceDateTimeLocationInformation()
		{
			SpecialServicesCoded = "t",
			Time = "AC6P",
			Time2 = "1pgf",
			Date = "w",
			PlaceLocation = "6",
			PlaceLocationIdentification = "A",
			PlaceLocationQualifier = "T",
			CharacteristicIdentification = "u",
			RelatedPlaceLocationOneIdentification = "m",
			CountryCoded = "J",
			SpecialService = "j",
			Characteristic = "p",
		};

		var actual = Map.MapComposite<E959_ServiceDateTimeLocationInformation>(line, MapOptionsForTesting.EdifactDefaultEndsWithSingleQuote);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("t", true)]
	public void Validation_RequiredSpecialServicesCoded(string specialServicesCoded, bool isValidExpected)
	{
		var subject = new E959_ServiceDateTimeLocationInformation();
		//Required fields
		//Test Parameters
		subject.SpecialServicesCoded = specialServicesCoded;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
