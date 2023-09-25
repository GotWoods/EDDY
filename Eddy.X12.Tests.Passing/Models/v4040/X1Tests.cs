using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v4040;

namespace Eddy.x12.Tests.Models.v4040;

public class X1Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "X1*Y*QZrUQ7*9*VDSzan3F*7*e*n3*pX3qdAX*c*3*27*E*V1*5*u*l9*e";

		var expected = new X1_ExportLicense()
		{
			CodeForLicensingCertificationRegistrationOrAccreditationAgency = "Y",
			ExportLicenseNumber = "QZrUQ7",
			ExportLicenseStatusCode = "9",
			Date = "VDSzan3F",
			ExportLicenseSymbolCode = "7",
			ExportLicenseControlCode = "e",
			CountryCode = "n3",
			ScheduleBCode = "pX3qdAX",
			InternationalDomesticCode = "c",
			LadingQuantity = 3,
			LadingValue = 27,
			ExportFilingKeyCode = "E",
			UnitOrBasisForMeasurementCode = "V1",
			UnitPrice = 5,
			USGovernmentLicenseType = "u",
			IdentificationCode = "l9",
			LocationIdentifier = "e",
		};

		var actual = Map.MapObject<X1_ExportLicense>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

}
