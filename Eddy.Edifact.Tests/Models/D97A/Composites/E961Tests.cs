using Eddy.Core.Validation;
using Eddy.Edifact.Mapping;
using Eddy.Edifact.Models.D97A;
using Eddy.Edifact.Models.D97A.Composites;

namespace Eddy.Edifact.Tests.Models.D97A.Composites;

public class E961Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string line = "X:U:o:z:V:e:p:U:y:6";

		var expected = new E961_TransportDetails()
		{
			TypeOfMeansOfTransportIdentification = "X",
			NumberOfStops = "U",
			LegDuration = "o",
			Percentage = "z",
			DaysOfOperation = "V",
			DateTimePeriod = "e",
			ComplexingTransportIndicator = "p",
			PlaceLocationIdentification = "U",
			PlaceLocationIdentification2 = "y",
			PlaceLocationIdentification3 = "6",
		};

		var actual = Map.MapComposite<E961_TransportDetails>(line, MapOptionsForTesting.EdifactDefaultEndsWithSingleQuote);
		Assert.Equivalent(expected, actual);
	}

}
