/* TrieWithNoChildren.cs
 * Author: Jason Byrne
 */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ksu.Cis300.TrieLibrary
{
    public class TrieWithNoChildren : ITrie
    {
        /// <summary>
        /// Indicates whether the trie rooted at this node contains the empty string.
        /// </summary>
        private bool _emptyString = false;

        /// <summary>
        /// Adds the given string to the trie rooted at this node.
        /// </summary>
        /// <param name="s">The string to add.</param>
        /// <returns> The correct ITrie.</returns>
        public ITrie Add(string v)
        {
            if (v == "")
            {
                _emptyString = true;
            }
            else
            {
                return new TrieWithOneChild(v, _emptyString);
            }
            return this;
        }

        /// <summary>
        /// Gets whether the trie rooted at this node contains the given string.
        /// </summary>
        /// <param name="s">The string to look up.</param>
        /// <returns>Whether the trie rooted at this node contains s.</returns>
        public bool Contains(string s)
        {
            if (s == "")
            {
                return _emptyString;
            }
            else
            {
                return false;
            }
        }
    }
}
