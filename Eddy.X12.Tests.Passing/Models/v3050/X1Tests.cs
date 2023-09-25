using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3050;

namespace Eddy.x12.Tests.Models.v3050;

public class X1Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "X1*9*T6W6SS*V*ZKwNE6*h*4*W5*3jpf10U*9*3*78*N*8A*4*x";

		var expected = new X1_ExportLicense()
		{
			LicensingAgencyCode = "9",
			ExportLicenseNumber = "T6W6SS",
			ExportLicenseStatusCode = "V",
			Date = "ZKwNE6",
			ExportLicenseSymbolCode = "h",
			ExportLicenseControlCode = "4",
			CountryCode = "W5",
			ScheduleBCode = "3jpf10U",
			InternationalDomesticCode = "9",
			LadingQuantity = 3,
			LadingValue = 78,
			ExportFilingKeyCode = "N",
			UnitOrBasisForMeasurementCode = "8A",
			UnitPrice = 4,
			USGovernmentLicenseType = "x",
		};

		var actual = Map.MapObject<X1_ExportLicense>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

}
