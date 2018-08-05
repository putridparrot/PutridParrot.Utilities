using System;
using System.Collections.Generic;
using System.Text;

namespace PutridParrot.Utilities
{
    /// <summary>
    /// AutoDisposer simple acts as a collection which will call Dispose
    /// on the items within it when it's disposed of and then clear itself
    /// down.
    /// </summary>
    /// <example>
    /// using(AutoDisposer a = new AutoDisposer())
    /// {
    ///    Brush b = new SolidBrush(...);
    ///    a.Add(b);
    /// }
    /// </example>
    public class AutoDisposer : List<IDisposable>, IDisposable
    {
        /// <summary>
        /// Instantiates and instance of the AutoDisposer
        /// </summary>
        public AutoDisposer()
        {
        }

        #region IDisposable Members
        /// <summary>
        /// Disposes of all items within the collection before
        /// clearing itself
        /// </summary>
        public void Dispose()
        {
            foreach (IDisposable disposable in this)
            {
                disposable.Dispose();
            }
            Clear();
        }

        #endregion
    }

}
