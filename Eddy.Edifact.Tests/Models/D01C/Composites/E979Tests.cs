using Eddy.Core.Validation;
using Eddy.Edifact.Mapping;
using Eddy.Edifact.Models.D01C;
using Eddy.Edifact.Models.D01C.Composites;

namespace Eddy.Edifact.Tests.Models.D01C.Composites;

public class E979Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string line = "x:K:y:V:PXpYWuwOn:S:m";

		var expected = new E979_ReservationControlInformation()
		{
			PartyName = "x",
			ReservationIdentifier = "K",
			ReservationIdentifierCodeQualifier = "y",
			Date = "V",
			MillisecondTime = "PXpYWuwOn",
			ReferenceIdentifier = "S",
			AdjustmentReasonDescriptionCode = "m",
		};

		var actual = Map.MapComposite<E979_ReservationControlInformation>(line, MapOptionsForTesting.EdifactDefaultEndsWithSingleQuote);
		Assert.Equivalent(expected, actual);
	}

}
