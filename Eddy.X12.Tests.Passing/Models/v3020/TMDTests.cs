using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3020;

namespace Eddy.x12.Tests.Models.v3020;

public class TMDTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "TMD*qa*bZ*M*9S*gp*v*FygE34*W";

		var expected = new TMD_TestMethod()
		{
			ProductProcessCharacteristicCode = "qa",
			AgencyQualifierCode = "bZ",
			ProductDescriptionCode = "M",
			TestAdministrationMethodCode = "9S",
			TestMediumCode = "gp",
			Description = "v",
			Date = "FygE34",
			ReferenceNumber = "W",
		};

		var actual = Map.MapObject<TMD_TestMethod>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("bZ", "M", true)]
	[InlineData("bZ", "", false)]
	[InlineData("", "M", false)]
	public void Validation_AllAreRequiredAgencyQualifierCode(string agencyQualifierCode, string productDescriptionCode, bool isValidExpected)
	{
		var subject = new TMD_TestMethod();
		subject.AgencyQualifierCode = agencyQualifierCode;
		subject.ProductDescriptionCode = productDescriptionCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

}
