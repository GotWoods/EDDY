using Eddy.Core.Validation;
using Eddy.Edifact.Mapping;
using Eddy.Edifact.Models.D00B;
using Eddy.Edifact.Models.D00B.Composites;

namespace Eddy.Edifact.Tests.Models.D00B.Composites;

public class E979Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string line = "H:E:N:l:581RN3ybV:3";

		var expected = new E979_ReservationControlIdentification()
		{
			PartyName = "H",
			ReservationIdentifier = "E",
			ReservationIdentifierCodeQualifier = "N",
			DateValue = "l",
			MillisecondTimeValue = "581RN3ybV",
			ReferenceIdentifier = "3",
		};

		var actual = Map.MapComposite<E979_ReservationControlIdentification>(line, MapOptionsForTesting.EdifactDefaultEndsWithSingleQuote);
		Assert.Equivalent(expected, actual);
	}

}
