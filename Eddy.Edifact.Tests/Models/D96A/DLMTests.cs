using Eddy.Core.Validation;
using Eddy.Edifact.Mapping;
using Eddy.Edifact.Models.D96A;
using Eddy.Edifact.Models.D96A.Composites;

namespace Eddy.Edifact.Tests.Models.D96A;

public class DLMTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string line = "DLM+L+++v";

		var expected = new DLM_DeliveryLimitations()
		{
			BackOrderCoded = "L",
			Instruction = null,
			SpecialServicesIdentification = null,
			ProductServiceSubstitutionCoded = "v",
		};

		var actual = Map.MapObject<DLM_DeliveryLimitations>(line, MapOptionsForTesting.EdifactDefaultEndsWithSingleQuote);
		Assert.Equivalent(expected, actual);
	}

}
