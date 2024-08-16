using Eddy.Core.Validation;
using Eddy.Edifact.Mapping;
using Eddy.Edifact.Models.D99B;
using Eddy.Edifact.Models.D99B.Composites;

namespace Eddy.Edifact.Tests.Models.D99B;

public class ADITests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string line = "ADI+++6++7++3+K++I+F";

		var expected = new ADI_HealthCareClaimAdjudicationInformation()
		{
			ObjectIdentification = null,
			Service = null,
			ActionRequestNotificationDescriptionCode = "6",
			MonetaryAmount = null,
			Quantity = "7",
			AdjustmentInformation = null,
			PolicyLimitationIdentifier = "3",
			ProductGroupNameCode = "K",
			DateTimePeriod = null,
			DiagnosisCategoryCode = "I",
			Percentage = "F",
		};

		var actual = Map.MapObject<ADI_HealthCareClaimAdjudicationInformation>(line, MapOptionsForTesting.EdifactDefaultEndsWithSingleQuote);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("A", true)]
	public void Validation_RequiredObjectIdentification(string objectIdentification, bool isValidExpected)
	{
		var subject = new ADI_HealthCareClaimAdjudicationInformation();
		//Required fields
		//Test Parameters
		if (objectIdentification != "") 
			subject.ObjectIdentification = new E206_ObjectIdentification();
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
