using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3030;

namespace Eddy.x12.Tests.Models.v3030;

public class X1Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "X1*P*jOGU2s*i*MQgaSC*j*U*fY*PK4CXMt*d*5*49*0*2F*2*Z";

		var expected = new X1_ExportLicense()
		{
			LicensingAgencyCode = "P",
			ExportLicenseNumber = "jOGU2s",
			ExportLicenseStatusCode = "i",
			Date = "MQgaSC",
			ExportLicenseSymbolCode = "j",
			ExportLicenseControlCode = "U",
			CountryCode = "fY",
			ScheduleBCode = "PK4CXMt",
			InternationalDomesticCode = "d",
			LadingQuantity = 5,
			LadingValue = 49,
			ExportFilingKeyCode = "0",
			UnitOrBasisForMeasurementCode = "2F",
			UnitPrice = 2,
			USGovernmentLicenseType = "Z",
		};

		var actual = Map.MapObject<X1_ExportLicense>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

}
