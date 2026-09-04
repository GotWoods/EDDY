using System.Collections.Generic;
using System.Text;

namespace Eddy.Core.Validation
{
    public class ValidationResult
    {
        public ValidationResult()
        {
        }

        public bool IsValid => Errors.Count == 0;
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
                sb.AppendFormat(error.ErrorCode.Message, error.Data);
                sb.AppendLine();
            }
            return sb.ToString();
        }
    }
}
