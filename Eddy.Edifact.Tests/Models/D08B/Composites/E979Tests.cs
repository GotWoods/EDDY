using Eddy.Core.Validation;
using Eddy.Edifact.Mapping;
using Eddy.Edifact.Models.D08B;
using Eddy.Edifact.Models.D08B.Composites;

namespace Eddy.Edifact.Tests.Models.D08B.Composites;

public class E979Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string line = "X:N:m:b:CnnycmZaf:k:M";

		var expected = new E979_ReservationControlInformation()
		{
			PartyName = "X",
			ReservationIdentifier = "N",
			ReservationIdentifierCodeQualifier = "m",
			Date = "b",
			MillisecondTime = "CnnycmZaf",
			ReferenceIdentifier = "k",
			AdjustmentReasonDescriptionCode = "M",
		};

		var actual = Map.MapComposite<E979_ReservationControlInformation>(line, MapOptionsForTesting.EdifactDefaultEndsWithSingleQuote);
		Assert.Equivalent(expected, actual);
	}

}
