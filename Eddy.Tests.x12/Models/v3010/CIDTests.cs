using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.v3010;

namespace Eddy.x12.Tests.Models.v3010;

public class CIDTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "CID*G*9I*Kq*t*h";

		var expected = new CID_CharacteristicClassID()
		{
			MeasurementQualifier = "G",
			ProductProcessCharacteristicCode = "9I",
			AssociationQualifierCode = "Kq",
			ProductDescriptionCode = "t",
			Description = "h",
		};

		var actual = Map.MapObject<CID_CharacteristicClassID>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

}
