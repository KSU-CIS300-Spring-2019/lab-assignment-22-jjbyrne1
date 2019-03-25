using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ksu.Cis300.TrieLibrary
{
    public class TrieWithOneChild : ITrie
    {
        /// <summary>
        /// Keeps track of whether the trie contains an empty string.
        /// </summary>
        private bool _emptyString;

        /// <summary>
        /// Stores the tries only child.
        /// </summary>
        private ITrie _onlyChild;

        /// <summary>
        /// Stores the only childs label.
        /// </summary>
        private char _label;

        /// <summary>
        /// Constructs a trie containing the given string and having the given child at the given label.
        /// If s contains any characters other than lower-case English letters,
        /// throws an ArgumentException.
        /// If childLabel is not a lower-case English letter, throws an ArgumentException.
        /// </summary>
        /// <param name="s">The string to include.</param>
        /// <param name="b">Indicates whether this trie should contain the empty string.</param>
        public TrieWithOneChild(string s, bool b)
        {
            if (s[0] < 'a' || 'z' < s[0] || s == "")
            {
                throw new ArgumentException();
            }
            _emptyString = b;
            _label = s[0];
            _onlyChild = new TrieWithNoChildren().Add(s.Substring(1));
        }

        /// <summary>
        /// Adds the given string to the trie rooted at this node.
        /// </summary>
        /// <param name="s">The string to add.</param>
        public ITrie Add(string s)
        {
            if (s == "")
            {
                _emptyString = true;
            }
            else if (s != "" && _label == s[0])
            {
                _onlyChild = _onlyChild.Add(s.Substring(1));
            }
            else
            {
                return new TrieWithManyChildren(s, _emptyString, _label, _onlyChild);
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
            if (s== "")
            {
                return _emptyString;
            }
            else if (s[0] == _label)
            {
                return _onlyChild.Contains(s.Substring(1));
            }
            else
            {
                return false;
            }
        }
    }
}
