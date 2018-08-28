using System;
using System.Collections.Generic;
using System.Text;

namespace PutridParrot.Utilities
{
    /// <summary>
    /// This object is used to access/generate file path information
    /// </summary>
    /// TODO: Check if this code is still required or been superceded in later .NET
    public static partial class Path
    {
        /// <summary>
        /// Combines a root path with a relative path to give path combined of the two. Note: If the root path
        /// ends with a seperator token, this is ignored in favour of the relative path, so for example if the
        /// root was c:\hello\world\ but the relative was ..\you then the combined would be
        /// c:\hello\you (notice the missing \). 
        /// </summary>
        /// <example>
        /// string root = @"c:\home\sub\one";
        /// string relative = @"..\\..\\new";
        /// 
        /// string combined = Path.Combine(root, relative);
        /// </example>
        /// <param name="root">The root path, i.e. the path that the relative combines with</param>
        /// <param name="relative">The relative path to combine with the root</param>
        /// <returns>The combination of the two paths</returns>
        public static string Combine(string root, string relative)
        {
            // removes any prefixes seperator from the relative and suffixed seperator from the root
            string normalizedRoot = NormalizePath(root).TrimEnd(System.IO.Path.DirectorySeparatorChar);
            string normalizedRelative = NormalizePath(relative);

            string backToken = "..";

            string[] rootSplit = normalizedRoot.Split(System.IO.Path.DirectorySeparatorChar);
            string[] relativeSplit = normalizedRelative.Split(System.IO.Path.DirectorySeparatorChar);

            Stack<string> stack = new Stack<string>();
            foreach (string rootSeperate in rootSplit)
            {
                stack.Push(rootSeperate);
            }

            foreach (string relativeSeperate in relativeSplit)
            {
                if (relativeSeperate == backToken)
                {
                    if (stack.Count > 0)
                    {
                        stack.Pop();
                    }
                }
                else
                {
                    stack.Push(relativeSeperate);
                }
            }

            // recombine with seperators
            StringBuilder combined = new StringBuilder();
            string[] splitStack = stack.ToArray();
            for (int i = splitStack.Length - 1; i >= 0; i--)
            {
                combined.Append(splitStack[i]);
                if (i > 0)
                {
                    combined.Append(System.IO.Path.DirectorySeparatorChar);
                }
            }
            return combined.ToString();
        }

        private static string NormalizePath(string path)
        {
            return path.Trim().TrimStart(System.IO.Path.DirectorySeparatorChar);
        }
    }
}
