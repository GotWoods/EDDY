using Eddy.Core.Validation;
using Eddy.x12.Mapping;
using Eddy.x12.Models;

namespace Eddy.Tests.x12.Models;

public class X1Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "X1*8*EQL1g8*g*IrEPoU81*d*v*vN*hdh1d5n*s*2*99*g*XH*4*y*Sn*1";

		var expected = new X1_ExportLicense()
		{
			CodeForLicensingCertificationRegistrationOrAccreditationAgency = "8",
			ExportLicenseNumber = "EQL1g8",
			ExportLicenseStatusCode = "g",
			Date = "IrEPoU81",
			ExportLicenseSymbolCode = "d",
			ExportLicenseControlCode = "v",
			CountryCode = "vN",
			ScheduleBCode = "hdh1d5n",
			InternationalDomesticCode = "s",
			LadingQuantity = 2,
			LadingValue = 99,
			ExportFilingKeyCode = "g",
			UnitOrBasisForMeasurementCode = "XH",
			UnitPrice = 4,
			USGovernmentLicenseType = "y",
			IdentificationCode = "Sn",
			LocationIdentifier = "1",
		};

		var actual = Map.MapObject<X1_ExportLicense>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

}
