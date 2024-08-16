using Eddy.Core.Attributes;
using Eddy.Core.Validation;

namespace Eddy.Edifact.Models.D00A.Composites;

[Segment("S502")]
public class S502_SecurityAlgorithm : EdifactComponent
{
	[Position(1)]
	public string UseOfAlgorithmCoded { get; set; }

	[Position(2)]
	public string CryptographicModeOfOperationCoded { get; set; }

	[Position(3)]
	public string ModeOfOperationCodeListIdentifier { get; set; }

	[Position(4)]
	public string AlgorithmCoded { get; set; }

	[Position(5)]
	public string AlgorithmCodeListIdentifier { get; set; }

	[Position(6)]
	public string PaddingMechanismCoded { get; set; }

	[Position(7)]
	public string PaddingMechanismCodeListIdentifier { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<S502_SecurityAlgorithm>(this);
		validator.Required(x=>x.UseOfAlgorithmCoded);
		validator.Length(x => x.UseOfAlgorithmCoded, 1, 3);
		validator.Length(x => x.CryptographicModeOfOperationCoded, 1, 3);
		validator.Length(x => x.ModeOfOperationCodeListIdentifier, 1, 3);
		validator.Length(x => x.AlgorithmCoded, 1, 3);
		validator.Length(x => x.AlgorithmCodeListIdentifier, 1, 3);
		validator.Length(x => x.PaddingMechanismCoded, 1, 3);
		validator.Length(x => x.PaddingMechanismCodeListIdentifier, 1, 3);
		return validator.Results;
	}
}
