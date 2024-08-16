using Eddy.Core.Validation;
using Eddy.Edifact.Mapping;
using Eddy.Edifact.Models.D99B;
using Eddy.Edifact.Models.D99B.Composites;

namespace Eddy.Edifact.Tests.Models.D99B.Composites;

public class E999Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string line = "0:g:pIlq:zfiD:N:y:5:1";

		var expected = new E999_ConnectionDetails()
		{
			LocationNameCode = "0",
			PartyName = "g",
			Time = "pIlq",
			Time2 = "zfiD",
			LocationName = "N",
			LocationFunctionCodeQualifier = "y",
			CountryNameCode = "5",
			SequenceNumber = "1",
		};

		var actual = Map.MapComposite<E999_ConnectionDetails>(line, MapOptionsForTesting.EdifactDefaultEndsWithSingleQuote);
		Assert.Equivalent(expected, actual);
	}

}
