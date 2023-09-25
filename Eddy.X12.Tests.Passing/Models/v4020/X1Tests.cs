using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v4020;

namespace Eddy.x12.Tests.Models.v4020;

public class X1Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "X1*Q*j*r*tHv7syY0*3*k*by*gNng2aQ*E*1*97*c*y7*1*P*K8";

		var expected = new X1_ExportLicense()
		{
			CodeForLicensingCertificationRegistrationOrAccreditationAgency = "Q",
			ExportLicenseNumber = "j",
			ExportLicenseStatusCode = "r",
			Date = "tHv7syY0",
			ExportLicenseSymbolCode = "3",
			ExportLicenseControlCode = "k",
			CountryCode = "by",
			ScheduleBCode = "gNng2aQ",
			InternationalDomesticCode = "E",
			LadingQuantity = 1,
			LadingValue = 97,
			ExportFilingKeyCode = "c",
			UnitOrBasisForMeasurementCode = "y7",
			UnitPrice = 1,
			USGovernmentLicenseType = "P",
			IdentificationCode = "K8",
		};

		var actual = Map.MapObject<X1_ExportLicense>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

}
