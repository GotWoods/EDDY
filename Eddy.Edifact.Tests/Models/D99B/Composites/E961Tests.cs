using Eddy.Core.Validation;
using Eddy.Edifact.Mapping;
using Eddy.Edifact.Models.D99B;
using Eddy.Edifact.Models.D99B.Composites;

namespace Eddy.Edifact.Tests.Models.D99B.Composites;

public class E961Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string line = "x:V:T:l:j:W:H:3:0:X";

		var expected = new E961_TransportDetails()
		{
			TransportMeansDescriptionCode = "x",
			NumberOfStops = "V",
			LegDuration = "T",
			Percentage = "l",
			DaysOfOperation = "j",
			DateTimePeriodValue = "W",
			ComplexingTransportIndicator = "H",
			LocationNameCode = "3",
			LocationNameCode2 = "0",
			LocationNameCode3 = "X",
		};

		var actual = Map.MapComposite<E961_TransportDetails>(line, MapOptionsForTesting.EdifactDefaultEndsWithSingleQuote);
		Assert.Equivalent(expected, actual);
	}

}
