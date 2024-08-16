using Eddy.Core.Validation;
using Eddy.Edifact.Mapping;
using Eddy.Edifact.Models.D97A;
using Eddy.Edifact.Models.D97A.Composites;

namespace Eddy.Edifact.Tests.Models.D97A.Composites;

public class E979Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string line = "i:h:1:9:DXYVhrkEO:S";

		var expected = new E979_ReservationControlIdentification()
		{
			PartyName = "i",
			ReservationControlNumber = "h",
			ReservationControlNumberQualifier = "1",
			Date = "9",
			MillisecondTime = "DXYVhrkEO",
			ReferenceNumber = "S",
		};

		var actual = Map.MapComposite<E979_ReservationControlIdentification>(line, MapOptionsForTesting.EdifactDefaultEndsWithSingleQuote);
		Assert.Equivalent(expected, actual);
	}

}
