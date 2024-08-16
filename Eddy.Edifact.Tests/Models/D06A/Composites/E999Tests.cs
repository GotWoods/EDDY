using Eddy.Core.Validation;
using Eddy.Edifact.Mapping;
using Eddy.Edifact.Models.D06A;
using Eddy.Edifact.Models.D06A.Composites;

namespace Eddy.Edifact.Tests.Models.D06A.Composites;

public class E999Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string line = "c:m:Y08h:8sBI:1:4:s:R";

		var expected = new E999_ConnectionDetails()
		{
			LocationIdentifier = "c",
			PartyName = "m",
			Time = "Y08h",
			Time2 = "8sBI",
			LocationName = "1",
			LocationFunctionCodeQualifier = "4",
			CountryIdentifier = "s",
			SequencePositionIdentifier = "R",
		};

		var actual = Map.MapComposite<E999_ConnectionDetails>(line, MapOptionsForTesting.EdifactDefaultEndsWithSingleQuote);
		Assert.Equivalent(expected, actual);
	}

}
