using EdiParser.Validation;
using EdiParser.x12.Mapping;
using EdiParser.x12.Models;

namespace EdiParser.Tests.x12.Models;

public class COITests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "COI*AyK*Gh*8b";

		var expected = new COI_ContainerInformation()
		{
			PackagingCode = "AyK",
			ContainerMaterialColor = "Gh",
			ClosureType = "8b",
		};

		var actual = Map.MapObject<COI_ContainerInformation>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

}
