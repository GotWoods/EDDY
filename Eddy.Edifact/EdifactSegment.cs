using Eddy.Core;
using Eddy.Core.Validation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Eddy.Edifact
{
    public abstract class EdifactSegment : ISourceTracked
    {
        public abstract ValidationResult Validate();

        /// <summary>Where this segment came from in the original text. Set by the parser; null for
        /// segments constructed directly by callers (e.g. when building a document to write out).</summary>
        public SegmentSource Source { get; set; }
    }

    public abstract class EdifactComponent : EdifactSegment
    {

    }
}
