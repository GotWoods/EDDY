using Eddy.Core.Validation;
using Eddy.Edifact.Mapping;
using Eddy.Edifact.Models.D96A;
using Eddy.Edifact.Models.D96A.Composites;

namespace Eddy.Edifact.Tests.Models.D96A;

public class TSRTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string line = "TSR++++";

		var expected = new TSR_TransportServiceRequirements()
		{
			ContractAndCarriageCondition = null,
			Service = null,
			TransportPriority = null,
			NatureOfCargo = null,
		};

		var actual = Map.MapObject<TSR_TransportServiceRequirements>(line, MapOptionsForTesting.EdifactDefaultEndsWithSingleQuote);
		Assert.Equivalent(expected, actual);
	}

}
