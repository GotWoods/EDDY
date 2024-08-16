using Eddy.Core.Validation;
using Eddy.Edifact.Mapping;
using Eddy.Edifact.Models.D96A;
using Eddy.Edifact.Models.D96A.Composites;

namespace Eddy.Edifact.Tests.Models.D96A.Composites;

public class C222Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		var line = "X:u:V:k:d";

		var expected = new C222_TransportIdentification()
		{
			IdOfMeansOfTransportIdentification = "X",
			CodeListQualifier = "u",
			CodeListResponsibleAgencyCoded = "V",
			IdOfTheMeansOfTransport = "k",
			NationalityOfMeansOfTransportCoded = "d",
		};

		var actual = Map.MapComposite<C222_TransportIdentification>(line, MapOptionsForTesting.EdifactDefaultEndsWithSingleQuote);
		Assert.Equivalent(expected, actual);
	}

}
