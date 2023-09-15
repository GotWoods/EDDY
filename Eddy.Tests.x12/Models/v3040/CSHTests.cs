using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3040;

namespace Eddy.x12.Tests.Models.v3040;

public class CSHTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "CSH*n*g*e5*y*Kq4HFh*G9*NW*d*3";

		var expected = new CSH_HeaderSaleCondition()
		{
			SalesRequirementCode = "n",
			DoNotExceedActionCode = "g",
			DoNotExceedAmount = "e5",
			AccountNumber = "y",
			RequiredInvoiceDate = "Kq4HFh",
			AgencyQualifierCode = "G9",
			SpecialServicesCode = "NW",
			ProductServiceSubstitutionCode = "d",
			Percent = 3,
		};

		var actual = Map.MapObject<CSH_HeaderSaleCondition>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("g", "e5", true)]
	[InlineData("g", "", false)]
	[InlineData("", "e5", true)]
	public void Validation_ARequiresBDoNotExceedActionCode(string doNotExceedActionCode, string doNotExceedAmount, bool isValidExpected)
	{
		var subject = new CSH_HeaderSaleCondition();
		subject.DoNotExceedActionCode = doNotExceedActionCode;
		subject.DoNotExceedAmount = doNotExceedAmount;
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.AgencyQualifierCode) || !string.IsNullOrEmpty(subject.AgencyQualifierCode) || !string.IsNullOrEmpty(subject.SpecialServicesCode))
		{
			subject.AgencyQualifierCode = "G9";
			subject.SpecialServicesCode = "NW";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("G9", "NW", true)]
	[InlineData("G9", "", false)]
	[InlineData("", "NW", false)]
	public void Validation_AllAreRequiredAgencyQualifierCode(string agencyQualifierCode, string specialServicesCode, bool isValidExpected)
	{
		var subject = new CSH_HeaderSaleCondition();
		subject.AgencyQualifierCode = agencyQualifierCode;
		subject.SpecialServicesCode = specialServicesCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

}
