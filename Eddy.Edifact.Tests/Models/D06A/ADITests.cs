using Eddy.Core.Validation;
using Eddy.Edifact.Mapping;
using Eddy.Edifact.Models.D06A;
using Eddy.Edifact.Models.D06A.Composites;

namespace Eddy.Edifact.Tests.Models.D06A;

public class ADITests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string line = "ADI+++m++f++9+D++9+q";

		var expected = new ADI_HealthCareClaimAdjudicationInformation()
		{
			ObjectIdentification = null,
			Service = null,
			ActionCode = "m",
			MonetaryAmount = null,
			Quantity = "f",
			AdjustmentInformation = null,
			PolicyLimitationIdentifier = "9",
			ProductGroupNameCode = "D",
			DateTimePeriod = null,
			DiagnosisCategoryCode = "9",
			Percentage = "q",
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
