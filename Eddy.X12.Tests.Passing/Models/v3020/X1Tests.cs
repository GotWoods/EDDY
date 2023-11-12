using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3020;

namespace Eddy.x12.Tests.Models.v3020;

public class X1Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "X1*A*LTv7ek*Y*Jo6Uh3*z*F*jS*U7yyrm9*p*7*96*B*Tj*4";

		var expected = new X1_ExportLicense()
		{
			LicensingAgencyCode = "A",
			ExportLicenseNumber = "LTv7ek",
			ExportLicenseStatusCode = "Y",
			Date = "Jo6Uh3",
			ExportLicenseSymbolCode = "z",
			ExportLicenseControlCode = "F",
			CountryCode = "jS",
			ScheduleBCode = "U7yyrm9",
			InternationalDomesticCode = "p",
			LadingQuantity = 7,
			LadingValue = 96,
			ExportFilingKeyCode = "B",
			UnitOfMeasurementCode = "Tj",
			UnitPrice = 4,
		};

		var actual = Map.MapObject<X1_ExportLicense>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

}
