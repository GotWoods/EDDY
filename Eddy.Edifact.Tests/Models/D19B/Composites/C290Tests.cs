using Eddy.Core.Validation;
using Eddy.Edifact.Mapping;
using Eddy.Edifact.Models.D19B;
using Eddy.Edifact.Models.D19B.Composites;

namespace Eddy.Edifact.Tests.Models.D19B.Composites;

public class C290Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string line = "n:Q:e:c:O";

		var expected = new C290_TransportService()
		{
			TransportServiceIdentificationCode = "n",
			CodeListIdentificationCode = "Q",
			CodeListResponsibleAgencyCode = "e",
			TransportServiceName = "c",
			TransportServiceDescription = "O",
		};

		var actual = Map.MapComposite<C290_TransportService>(line, MapOptionsForTesting.EdifactDefaultEndsWithSingleQuote);
		Assert.Equivalent(expected, actual);
	}

}
