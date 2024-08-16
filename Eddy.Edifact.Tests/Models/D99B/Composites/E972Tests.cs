using Eddy.Core.Validation;
using Eddy.Edifact.Mapping;
using Eddy.Edifact.Models.D99B;
using Eddy.Edifact.Models.D99B.Composites;

namespace Eddy.Edifact.Tests.Models.D99B.Composites;

public class E972Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string line = "H:0:f:2:Z:U:O:6:W:k:Q:q";

		var expected = new E972_MessageProcessingDetails()
		{
			BusinessFunctionCode = "H",
			MessageFunctionCode = "0",
			CodeListResponsibleAgencyCode = "f",
			MessageFunctionCode2 = "2",
			MessageFunctionCode3 = "Z",
			MessageFunctionCode4 = "U",
			MessageFunctionCode5 = "O",
			MessageFunctionCode6 = "6",
			MessageFunctionCode7 = "W",
			MessageFunctionCode8 = "k",
			MessageFunctionCode9 = "Q",
			MessageFunctionCode10 = "q",
		};

		var actual = Map.MapComposite<E972_MessageProcessingDetails>(line, MapOptionsForTesting.EdifactDefaultEndsWithSingleQuote);
		Assert.Equivalent(expected, actual);
	}

}
