using Eddy.Core.Validation;
using Eddy.Edifact.Mapping;
using Eddy.Edifact.Models.D06A;
using Eddy.Edifact.Models.D06A.Composites;

namespace Eddy.Edifact.Tests.Models.D06A;

public class MKSTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string line = "MKS+v++1";

		var expected = new MKS_MarketSalesChannelInformation()
		{
			SectorAreaIdentificationCodeQualifier = "v",
			SalesChannelIdentification = null,
			ActionCode = "1",
		};

		var actual = Map.MapObject<MKS_MarketSalesChannelInformation>(line, MapOptionsForTesting.EdifactDefaultEndsWithSingleQuote);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("v", true)]
	public void Validation_RequiredSectorAreaIdentificationCodeQualifier(string sectorAreaIdentificationCodeQualifier, bool isValidExpected)
	{
		var subject = new MKS_MarketSalesChannelInformation();
		//Required fields
		subject.SalesChannelIdentification = new C332_SalesChannelIdentification();
		//Test Parameters
		subject.SectorAreaIdentificationCodeQualifier = sectorAreaIdentificationCodeQualifier;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("A", true)]
	public void Validation_RequiredSalesChannelIdentification(string salesChannelIdentification, bool isValidExpected)
	{
		var subject = new MKS_MarketSalesChannelInformation();
		//Required fields
		subject.SectorAreaIdentificationCodeQualifier = "v";
		//Test Parameters
		if (salesChannelIdentification != "") 
			subject.SalesChannelIdentification = new C332_SalesChannelIdentification();
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
