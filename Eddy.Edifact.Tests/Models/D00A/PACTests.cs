using Eddy.Core.Validation;
using Eddy.Edifact.Mapping;
using Eddy.Edifact.Models.D00A;
using Eddy.Edifact.Models.D00A.Composites;

namespace Eddy.Edifact.Tests.Models.D00A;

public class PACTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string line = "PAC+2++++";

		var expected = new PAC_Package()
		{
			PackageQuantity = "2",
			PackagingDetails = null,
			PackageType = null,
			PackageTypeIdentification = null,
			ReturnablePackageDetails = null,
		};

		var actual = Map.MapObject<PAC_Package>(line, MapOptionsForTesting.EdifactDefaultEndsWithSingleQuote);
		Assert.Equivalent(expected, actual);
	}

}
