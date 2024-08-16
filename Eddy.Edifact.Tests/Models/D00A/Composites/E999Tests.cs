using Eddy.Core.Validation;
using Eddy.Edifact.Mapping;
using Eddy.Edifact.Models.D00A;
using Eddy.Edifact.Models.D00A.Composites;

namespace Eddy.Edifact.Tests.Models.D00A.Composites;

public class E999Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string line = "y:5:LYl5:7ciG:l:q:v:4";

		var expected = new E999_ConnectionDetails()
		{
			LocationNameCode = "y",
			PartyName = "5",
			TimeValue = "LYl5",
			TimeValue2 = "7ciG",
			LocationName = "l",
			LocationFunctionCodeQualifier = "q",
			CountryNameCode = "v",
			SequencePositionIdentifier = "4",
		};

		var actual = Map.MapComposite<E999_ConnectionDetails>(line, MapOptionsForTesting.EdifactDefaultEndsWithSingleQuote);
		Assert.Equivalent(expected, actual);
	}

}
