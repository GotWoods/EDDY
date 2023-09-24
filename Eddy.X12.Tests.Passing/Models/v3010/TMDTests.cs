using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3010;

namespace Eddy.x12.Tests.Models.v3010;

public class TMDTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "TMD*HB*BQ*p*RN*9z*R*WIxB7J*w";

		var expected = new TMD_TestMethod()
		{
			ProductProcessCharacteristicCode = "HB",
			AssociationQualifierCode = "BQ",
			ProductDescriptionCode = "p",
			TestAdministrationMethodCode = "RN",
			TestMediumCode = "9z",
			Description = "R",
			Date = "WIxB7J",
			ReferenceNumber = "w",
		};

		var actual = Map.MapObject<TMD_TestMethod>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

}
