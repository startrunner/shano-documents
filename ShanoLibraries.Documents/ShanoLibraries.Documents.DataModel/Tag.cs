using System;

namespace ShanoLibraries.Documents.DataModel
{
    public class Tag
    {

        public Tag Previous { get; internal set; } = null;
        public Tag Next { get; internal set; } = null;

        object state;
        public object State
        {
            get => state;
            internal set
            {
                if(value.GetType()!=state.GetType())
                {
                    throw new InvalidOperationException("Chaning the type of a tag's state is not allowed.");
                }
                state = value;
            }
        }

        public Tag(object state)
        {
            if (state == null)
            {
                throw new ArgumentNullException(nameof(state));
            }
            this.state = state;
        }

        public bool IsDocumentStart => Objects.Equal(state, DocumentBoundary.DocumentStart);
        public bool IsDocumentEnd => Objects.Equal(state, DocumentBoundary.DocumentEnd);
    }
}
