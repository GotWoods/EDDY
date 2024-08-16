using Eddy.Core.Validation;
using Eddy.Edifact.Mapping;
using Eddy.Edifact.Models.D05B;
using Eddy.Edifact.Models.D05B.Composites;

namespace Eddy.Edifact.Tests.Models.D05B.Composites;

public class C222Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		var line = "i:4:K:5:Q";

		var expected = new C222_TransportIdentification()
		{
			TransportMeansIdentificationNameIdentifier = "i",
			CodeListIdentificationCode = "4",
			CodeListResponsibleAgencyCode = "K",
			TransportMeansIdentificationName = "5",
			TransportMeansNationalityCode = "Q",
		};

		var actual = Map.MapComposite<C222_TransportIdentification>(line, MapOptionsForTesting.EdifactDefaultEndsWithSingleQuote);
		Assert.Equivalent(expected, actual);
	}

}
