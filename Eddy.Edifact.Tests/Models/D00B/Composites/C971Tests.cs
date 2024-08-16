using Eddy.Core.Validation;
using Eddy.Edifact.Mapping;
using Eddy.Edifact.Models.D00B;
using Eddy.Edifact.Models.D00B.Composites;

namespace Eddy.Edifact.Tests.Models.D00B.Composites;

public class C971Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string line = "i:2:0:y";

		var expected = new C971_ProvisoType()
		{
			ProvisoTypeDescriptionCode = "i",
			CodeListIdentificationCode = "2",
			CodeListResponsibleAgencyCode = "0",
			ProvisoTypeDescription = "y",
		};

		var actual = Map.MapComposite<C971_ProvisoType>(line, MapOptionsForTesting.EdifactDefaultEndsWithSingleQuote);
		Assert.Equivalent(expected, actual);
	}

}
