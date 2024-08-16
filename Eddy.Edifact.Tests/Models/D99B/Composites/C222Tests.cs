using Eddy.Core.Validation;
using Eddy.Edifact.Mapping;
using Eddy.Edifact.Models.D99B;
using Eddy.Edifact.Models.D99B.Composites;

namespace Eddy.Edifact.Tests.Models.D99B.Composites;

public class C222Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		var line = "C:e:m:H:A";

		var expected = new C222_TransportIdentification()
		{
			TransportMeansIdentificationNameIdentifier = "C",
			CodeListIdentificationCode = "e",
			CodeListResponsibleAgencyCode = "m",
			TransportMeansIdentificationName = "H",
			NationalityOfMeansOfTransportCoded = "A",
		};

		var actual = Map.MapComposite<C222_TransportIdentification>(line, MapOptionsForTesting.EdifactDefaultEndsWithSingleQuote);
		Assert.Equivalent(expected, actual);
	}

}
