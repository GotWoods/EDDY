using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3010;

namespace Eddy.x12.Tests.Models.v3010;

public class X1Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "X1*d*2yfsmV*k*B6v2V4*A*0*AP*6xI669H*t*2*36*1*Bl*1";

		var expected = new X1_ExportLicense()
		{
			LicensingAgencyCode = "d",
			ExportLicenseNumber = "2yfsmV",
			ExportLicenseStatusCode = "k",
			ExportLicenseExpirationDate = "B6v2V4",
			ExportLicenseSymbolCode = "A",
			ExportLicenseControlCode = "0",
			CountryCode = "AP",
			ScheduleBCode = "6xI669H",
			InternationalDomesticCode = "t",
			LadingQuantity = 2,
			LadingValue = 36,
			ExportFilingKeyCode = "1",
			UnitOfMeasurementCode = "Bl",
			UnitPrice = 1,
		};

		var actual = Map.MapObject<X1_ExportLicense>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

}
