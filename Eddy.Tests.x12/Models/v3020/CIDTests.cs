using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3020;

namespace Eddy.x12.Tests.Models.v3020;

public class CIDTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "CID*n*vM*2I*G*a";

		var expected = new CID_CharacteristicClassID()
		{
			MeasurementQualifier = "n",
			ProductProcessCharacteristicCode = "vM",
			AgencyQualifierCode = "2I",
			ProductDescriptionCode = "G",
			Description = "a",
		};

		var actual = Map.MapObject<CID_CharacteristicClassID>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("2I", "G", true)]
	[InlineData("2I", "", false)]
	[InlineData("", "G", false)]
	public void Validation_AllAreRequiredAgencyQualifierCode(string agencyQualifierCode, string productDescriptionCode, bool isValidExpected)
	{
		var subject = new CID_CharacteristicClassID();
		subject.AgencyQualifierCode = agencyQualifierCode;
		subject.ProductDescriptionCode = productDescriptionCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

}
