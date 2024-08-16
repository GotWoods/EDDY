using Eddy.Core.Validation;
using Eddy.Edifact.Mapping;
using Eddy.Edifact.Models.D00A;
using Eddy.Edifact.Models.D00A.Composites;

namespace Eddy.Edifact.Tests.Models.D00A.Composites;

public class C971Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string line = "h:g:N:t";

		var expected = new C971_ProvisoType()
		{
			ProvisoTypeDescriptionCode = "h",
			CodeListIdentificationCode = "g",
			CodeListResponsibleAgencyCode = "N",
			ProvisoTypeDescription = "t",
		};

		var actual = Map.MapComposite<C971_ProvisoType>(line, MapOptionsForTesting.EdifactDefaultEndsWithSingleQuote);
		Assert.Equivalent(expected, actual);
	}

}
