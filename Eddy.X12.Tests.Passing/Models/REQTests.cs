using Eddy.Core.Validation;
using Eddy.x12.Mapping;
using Eddy.x12.Models;

namespace Eddy.Tests.x12.Models;

public class REQTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "REQ*J*R";

		var expected = new REQ_RequestInformation()
		{
			InquiryResponseCode = "J",
			InquirySelectionCode = "R",
		};

		var actual = Map.MapObject<REQ_RequestInformation>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

}
