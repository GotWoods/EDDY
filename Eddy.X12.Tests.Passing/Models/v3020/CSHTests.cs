using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3020;

namespace Eddy.x12.Tests.Models.v3020;

public class CSHTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "CSH*j*4*0z*n*wkDZxW*I5*4P*R";

		var expected = new CSH_HeaderSaleCondition()
		{
			SalesRequirementCode = "j",
			DoNotExceedActionCode = "4",
			DoNotExceedAmount = "0z",
			AccountNumber = "n",
			RequiredInvoiceDate = "wkDZxW",
			AgencyQualifierCode = "I5",
			SpecialServicesCode = "4P",
			ProductServiceSubstitutionCode = "R",
		};

		var actual = Map.MapObject<CSH_HeaderSaleCondition>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("4", "0z", true)]
	[InlineData("4", "", false)]
	[InlineData("", "0z", true)]
	public void Validation_ARequiresBDoNotExceedActionCode(string doNotExceedActionCode, string doNotExceedAmount, bool isValidExpected)
	{
		var subject = new CSH_HeaderSaleCondition();
		subject.DoNotExceedActionCode = doNotExceedActionCode;
		subject.DoNotExceedAmount = doNotExceedAmount;
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.AgencyQualifierCode) || !string.IsNullOrEmpty(subject.AgencyQualifierCode) || !string.IsNullOrEmpty(subject.SpecialServicesCode))
		{
			subject.AgencyQualifierCode = "I5";
			subject.SpecialServicesCode = "4P";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("I5", "4P", true)]
	[InlineData("I5", "", false)]
	[InlineData("", "4P", false)]
	public void Validation_AllAreRequiredAgencyQualifierCode(string agencyQualifierCode, string specialServicesCode, bool isValidExpected)
	{
		var subject = new CSH_HeaderSaleCondition();
		subject.AgencyQualifierCode = agencyQualifierCode;
		subject.SpecialServicesCode = specialServicesCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

}
