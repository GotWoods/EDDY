using Eddy.Core.Validation;
using Eddy.Edifact.Mapping;
using Eddy.Edifact.Models.D97A;
using Eddy.Edifact.Models.D97A.Composites;

namespace Eddy.Edifact.Tests.Models.D97A;

public class AAITests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string line = "AAI+";

		var expected = new AAI_AccommodationAllocationInformation()
		{
			AccommodationAllocationInformation = null,
		};

		var actual = Map.MapObject<AAI_AccommodationAllocationInformation>(line, MapOptionsForTesting.EdifactDefaultEndsWithSingleQuote);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("A", true)]
	public void Validation_RequiredAccommodationAllocationInformation(string accommodationAllocationInformation, bool isValidExpected)
	{
		var subject = new AAI_AccommodationAllocationInformation();
		//Required fields
		//Test Parameters
		if (accommodationAllocationInformation != "") 
			subject.AccommodationAllocationInformation = new E997_AccommodationAllocationInformation();
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
