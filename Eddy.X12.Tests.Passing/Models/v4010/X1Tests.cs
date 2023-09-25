using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v4010;

namespace Eddy.x12.Tests.Models.v4010;

public class X1Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "X1*W*HdvNXx*U*h6eDccGU*g*K*rQ*VuivwnD*Q*4*76*P*JC*1*2*KS";

		var expected = new X1_ExportLicense()
		{
			LicensingAgencyCode = "W",
			ExportLicenseNumber = "HdvNXx",
			ExportLicenseStatusCode = "U",
			Date = "h6eDccGU",
			ExportLicenseSymbolCode = "g",
			ExportLicenseControlCode = "K",
			CountryCode = "rQ",
			ScheduleBCode = "VuivwnD",
			InternationalDomesticCode = "Q",
			LadingQuantity = 4,
			LadingValue = 76,
			ExportFilingKeyCode = "P",
			UnitOrBasisForMeasurementCode = "JC",
			UnitPrice = 1,
			USGovernmentLicenseType = "2",
			IdentificationCode = "KS",
		};

		var actual = Map.MapObject<X1_ExportLicense>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

}
