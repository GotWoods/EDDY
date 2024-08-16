using Eddy.Core.Validation;
using Eddy.Edifact.Mapping;
using Eddy.Edifact.Models.D96A;
using Eddy.Edifact.Models.D96A.Composites;

namespace Eddy.Edifact.Tests.Models.D96A;

public class MKSTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string line = "MKS+K++J";

		var expected = new MKS_MarketSalesChannelInformation()
		{
			SectorSubjectIdentificationQualifier = "K",
			SalesChannelIdentification = null,
			ActionRequestNotificationCoded = "J",
		};

		var actual = Map.MapObject<MKS_MarketSalesChannelInformation>(line, MapOptionsForTesting.EdifactDefaultEndsWithSingleQuote);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("K", true)]
	public void Validation_RequiredSectorSubjectIdentificationQualifier(string sectorSubjectIdentificationQualifier, bool isValidExpected)
	{
		var subject = new MKS_MarketSalesChannelInformation();
		//Required fields
		subject.SalesChannelIdentification = new C332_SalesChannelIdentification();
		//Test Parameters
		subject.SectorSubjectIdentificationQualifier = sectorSubjectIdentificationQualifier;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("A", true)]
	public void Validation_RequiredSalesChannelIdentification(string salesChannelIdentification, bool isValidExpected)
	{
		var subject = new MKS_MarketSalesChannelInformation();
		//Required fields
		subject.SectorSubjectIdentificationQualifier = "K";
		//Test Parameters
		if (salesChannelIdentification != "") 
			subject.SalesChannelIdentification = new C332_SalesChannelIdentification();
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
