using Eddy.Core.Validation;
using Eddy.Edifact.Mapping;
using Eddy.Edifact.Models.D99B;
using Eddy.Edifact.Models.D99B.Composites;

namespace Eddy.Edifact.Tests.Models.D99B;

public class MKSTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string line = "MKS+x++k";

		var expected = new MKS_MarketSalesChannelInformation()
		{
			SectorAreaIdentificationCodeQualifier = "x",
			SalesChannelIdentification = null,
			ActionRequestNotificationDescriptionCode = "k",
		};

		var actual = Map.MapObject<MKS_MarketSalesChannelInformation>(line, MapOptionsForTesting.EdifactDefaultEndsWithSingleQuote);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("x", true)]
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
		subject.SectorAreaIdentificationCodeQualifier = "x";
		//Test Parameters
		if (salesChannelIdentification != "") 
			subject.SalesChannelIdentification = new C332_SalesChannelIdentification();
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
