using Eddy.Core.Validation;
using Eddy.Edifact.Mapping;
using Eddy.Edifact.Models.D99B;
using Eddy.Edifact.Models.D99B.Composites;

namespace Eddy.Edifact.Tests.Models.D99B.Composites;

public class E979Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string line = "v:b:S:e:DuuEfb2UQ:w";

		var expected = new E979_ReservationControlIdentification()
		{
			PartyName = "v",
			ReservationControlNumber = "b",
			ReservationControlNumberQualifier = "S",
			DateValue = "e",
			MillisecondTime = "DuuEfb2UQ",
			ReferenceIdentifier = "w",
		};

		var actual = Map.MapComposite<E979_ReservationControlIdentification>(line, MapOptionsForTesting.EdifactDefaultEndsWithSingleQuote);
		Assert.Equivalent(expected, actual);
	}

}
