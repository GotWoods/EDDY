using Eddy.Core.Validation;
using Eddy.Edifact.Mapping;
using Eddy.Edifact.Models.D00B;
using Eddy.Edifact.Models.D00B.Composites;

namespace Eddy.Edifact.Tests.Models.D00B.Composites;

public class C222Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		var line = "d:a:N:q:2";

		var expected = new C222_TransportIdentification()
		{
			TransportMeansIdentificationNameIdentifier = "d",
			CodeListIdentificationCode = "a",
			CodeListResponsibleAgencyCode = "N",
			TransportMeansIdentificationName = "q",
			TransportMeansNationalityCode = "2",
		};

		var actual = Map.MapComposite<C222_TransportIdentification>(line, MapOptionsForTesting.EdifactDefaultEndsWithSingleQuote);
		Assert.Equivalent(expected, actual);
	}

}
