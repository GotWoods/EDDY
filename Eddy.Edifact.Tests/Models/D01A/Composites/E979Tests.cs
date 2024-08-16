using Eddy.Core.Validation;
using Eddy.Edifact.Mapping;
using Eddy.Edifact.Models.D01A;
using Eddy.Edifact.Models.D01A.Composites;

namespace Eddy.Edifact.Tests.Models.D01A.Composites;

public class E979Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string line = "u:e:V:f:ZVEqYMdbV:B:w";

		var expected = new E979_ReservationControlInformation()
		{
			PartyName = "u",
			ReservationIdentifier = "e",
			ReservationIdentifierCodeQualifier = "V",
			DateValue = "f",
			MillisecondTimeValue = "ZVEqYMdbV",
			ReferenceIdentifier = "B",
			AdjustmentReasonDescriptionCode = "w",
		};

		var actual = Map.MapComposite<E979_ReservationControlInformation>(line, MapOptionsForTesting.EdifactDefaultEndsWithSingleQuote);
		Assert.Equivalent(expected, actual);
	}

}
