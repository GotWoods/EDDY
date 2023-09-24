using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v4030;

namespace Eddy.x12.Tests.Models.v4030;

public class X1Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "X1*D*pPbQ58*q*svInB820*a*y*av*BO97e8b*v*4*28*D*2K*5*t*8h*4";

		var expected = new X1_ExportLicense()
		{
			CodeForLicensingCertificationRegistrationOrAccreditationAgency = "D",
			ExportLicenseNumber = "pPbQ58",
			ExportLicenseStatusCode = "q",
			Date = "svInB820",
			ExportLicenseSymbolCode = "a",
			ExportLicenseControlCode = "y",
			CountryCode = "av",
			ScheduleBCode = "BO97e8b",
			InternationalDomesticCode = "v",
			LadingQuantity = 4,
			LadingValue = 28,
			ExportFilingKeyCode = "D",
			UnitOrBasisForMeasurementCode = "2K",
			UnitPrice = 5,
			USGovernmentLicenseType = "t",
			IdentificationCode = "8h",
			LocationIdentifier = "4",
		};

		var actual = Map.MapObject<X1_ExportLicense>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

}
