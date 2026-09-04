using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Eddy.Core.Validation
{
    public class ValidationResult
    {
        public ValidationResult()
        {
        }

        /// <summary>True when there are no Error-severity entries. A result with only Warning and/or
        /// Info entries is still valid.</summary>
        public bool IsValid => !Errors.Any(e => e.Severity == ErrorSeverity.Error);

        /// <summary>True when at least one entry has Warning severity.</summary>
        public bool HasWarnings => Errors.Any(e => e.Severity == ErrorSeverity.Warning);

        public int LineNumber { get; set; }

        /// <summary>Identifier of the segment the result belongs to, e.g. "N1", or null for document level results.</summary>
        public string SegmentCode { get; set; }

        /// <summary>Where the offending segment sits in the source text, when the parser tracked it.</summary>
        public SegmentSource Source { get; set; }
        public List<Error> Errors { get; } = new();

        public void Add(Error error)
        {
            if (error != null)
                this.Errors.Add(error);
        }

        public void AddRange(List<Error> errors)
        {
            this.Errors.AddRange(errors);
        }

        public override string ToString()
        {
            var sb = new StringBuilder();
            foreach (var error in Errors)
            {
                if (error.Severity == ErrorSeverity.Warning)
                    sb.Append("warning: ");
                sb.AppendFormat(error.ErrorCode.Message, error.Data);
                sb.AppendLine();
            }
            return sb.ToString();
        }
    }
}
