using Eddy.Core.Validation;
using Eddy.Edifact.Mapping;
using Eddy.Edifact.Models.D99A;
using Eddy.Edifact.Models.D99A.Composites;

namespace Eddy.Edifact.Tests.Models.D99A.Composites;

public class E999Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string line = "z:o:5Mfk:LE4H:o:m:r:y";

		var expected = new E999_ConnectionDetails()
		{
			PlaceLocationIdentification = "z",
			PartyName = "o",
			Time = "5Mfk",
			Time2 = "LE4H",
			PlaceLocation = "o",
			PlaceLocationQualifier = "m",
			CountryCoded = "r",
			SequenceNumber = "y",
		};

		var actual = Map.MapComposite<E999_ConnectionDetails>(line, MapOptionsForTesting.EdifactDefaultEndsWithSingleQuote);
		Assert.Equivalent(expected, actual);
	}

}
