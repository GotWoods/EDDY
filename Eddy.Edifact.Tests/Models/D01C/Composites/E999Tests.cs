using Eddy.Core.Validation;
using Eddy.Edifact.Mapping;
using Eddy.Edifact.Models.D01C;
using Eddy.Edifact.Models.D01C.Composites;

namespace Eddy.Edifact.Tests.Models.D01C.Composites;

public class E999Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string line = "0:1:Lk9Y:lyq8:a:p:d:g";

		var expected = new E999_ConnectionDetails()
		{
			LocationNameCode = "0",
			PartyName = "1",
			Time = "Lk9Y",
			Time2 = "lyq8",
			LocationName = "a",
			LocationFunctionCodeQualifier = "p",
			CountryNameCode = "d",
			SequencePositionIdentifier = "g",
		};

		var actual = Map.MapComposite<E999_ConnectionDetails>(line, MapOptionsForTesting.EdifactDefaultEndsWithSingleQuote);
		Assert.Equivalent(expected, actual);
	}

}
