using Eddy.Core.Validation;
using Eddy.Edifact.Mapping;
using Eddy.Edifact.Models.D99B;
using Eddy.Edifact.Models.D99B.Composites;

namespace Eddy.Edifact.Tests.Models.D99B;

public class PSITests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string line = "PSI+5+++V+c+p+6+B+Y+";

		var expected = new PSI_ServiceInformation()
		{
			ObjectIdentifier = "5",
			DateTimePeriod = null,
			Service = null,
			Quantity = "V",
			MonetaryAmountValue = "c",
			IndexValue = "p",
			FacilityTypeDescriptionCode = "6",
			ServiceTypeCode = "B",
			SpecialConditionCode = "Y",
			SupportingEvidence = null,
		};

		var actual = Map.MapObject<PSI_ServiceInformation>(line, MapOptionsForTesting.EdifactDefaultEndsWithSingleQuote);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("5", true)]
	public void Validation_RequiredObjectIdentifier(string objectIdentifier, bool isValidExpected)
	{
		var subject = new PSI_ServiceInformation();
		//Required fields
		//Test Parameters
		subject.ObjectIdentifier = objectIdentifier;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
