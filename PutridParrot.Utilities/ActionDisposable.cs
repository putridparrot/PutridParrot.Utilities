using System;

namespace PutridParrot.Utilities
{
    /// <summary>
    /// For situations where you don't want to create a class just
    /// to implement IDisposable but instead want one or more actions
    /// to invoke.
    ///
    /// For example, if you need to call a method to save data to persisted
    /// store and it's class doesn't support such functionality
    /// </summary>
    public class ActionDisposable : IDisposable
    {
        private readonly Action _action;

        public ActionDisposable(Action action)
        {
            _action = action;
        }

        public void Dispose()
        {
            _action?.Invoke();
        }
    }
}