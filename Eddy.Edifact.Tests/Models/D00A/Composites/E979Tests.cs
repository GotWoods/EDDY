using Eddy.Core.Validation;
using Eddy.Edifact.Mapping;
using Eddy.Edifact.Models.D00A;
using Eddy.Edifact.Models.D00A.Composites;

namespace Eddy.Edifact.Tests.Models.D00A.Composites;

public class E979Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string line = "a:Z:d:G:r1ARz6O5f:k";

		var expected = new E979_ReservationControlIdentification()
		{
			PartyName = "a",
			ReservationIdentifier = "Z",
			ReservationIdentifierCodeQualifier = "d",
			DateValue = "G",
			MillisecondTimeValue = "r1ARz6O5f",
			ReferenceIdentifier = "k",
		};

		var actual = Map.MapComposite<E979_ReservationControlIdentification>(line, MapOptionsForTesting.EdifactDefaultEndsWithSingleQuote);
		Assert.Equivalent(expected, actual);
	}

}
