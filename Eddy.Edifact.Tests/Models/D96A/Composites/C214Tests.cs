using Eddy.Core.Validation;
using Eddy.Edifact.Mapping;
using Eddy.Edifact.Models.D96A;
using Eddy.Edifact.Models.D96A.Composites;

namespace Eddy.Edifact.Tests.Models.D96A.Composites;

public class C214Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		var line = "P:6:A:c:V";

		var expected = new C214_SpecialServicesIdentification()
		{
			SpecialServicesCoded = "P",
			CodeListQualifier = "6",
			CodeListResponsibleAgencyCoded = "A",
			SpecialService = "c",
			SpecialService2 = "V",
		};

		var actual = Map.MapComposite<C214_SpecialServicesIdentification>(line, MapOptionsForTesting.EdifactDefaultEndsWithSingleQuote);
		Assert.Equivalent(expected, actual);
	}

}
