using Eddy.Core.Validation;
using Eddy.Edifact.Mapping;
using Eddy.Edifact.Models.D00A;
using Eddy.Edifact.Models.D00A.Composites;

namespace Eddy.Edifact.Tests.Models.D00A.Composites;

public class C222Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		var line = "v:2:C:d:M";

		var expected = new C222_TransportIdentification()
		{
			TransportMeansIdentificationNameIdentifier = "v",
			CodeListIdentificationCode = "2",
			CodeListResponsibleAgencyCode = "C",
			TransportMeansIdentificationName = "d",
			TransportMeansNationalityCode = "M",
		};

		var actual = Map.MapComposite<C222_TransportIdentification>(line, MapOptionsForTesting.EdifactDefaultEndsWithSingleQuote);
		Assert.Equivalent(expected, actual);
	}

}
