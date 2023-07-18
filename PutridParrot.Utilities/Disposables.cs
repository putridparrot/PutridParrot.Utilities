using System;
using System.Collections.Generic;

namespace PutridParrot.Utilities;

/// <summary>
/// Disposables simple acts as a collection which will call Dispose
/// on the items within it when it's disposed of and then clear itself
/// down.
/// </summary>
/// <example>
/// using(Disposables a = new Disposables())
/// {
///    Brush b = new SolidBrush(...);
///    a.Add(b);
/// }
/// </example>
public class Disposables : List<IDisposable>, IDisposable
{
    /// <summary>
    /// Disposes of all items within the collection before
    /// clearing itself
    /// </summary>
    public void Dispose()
    {
        foreach (var disposable in this)
        {
            disposable.Dispose();
        }
        Clear();
    }
}