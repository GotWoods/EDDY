using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v8010;

namespace Eddy.x12.Tests.Models.v8010;

public class COITests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "COI*33a*79*mT";

		var expected = new COI_ContainerInformation()
		{
			PackagingCode = "33a",
			ContainerMaterialColor = "79",
			ClosureType = "mT",
		};

		var actual = Map.MapObject<COI_ContainerInformation>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

}
