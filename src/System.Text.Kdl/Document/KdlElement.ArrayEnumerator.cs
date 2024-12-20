using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;

namespace System.Text.Kdl
{
    public partial struct KdlElement
    {
        /// <summary>
        ///   An enumerable and enumerator for the contents of a KDL array.
        /// </summary>
        [DebuggerDisplay("{Current,nq}")]
        public struct ArrayEnumerator : IEnumerable<KdlElement>, IEnumerator<KdlElement>
        {
            private readonly KdlElement _target;
            private int _curIdx;
            private readonly int _endIdxOrVersion;

            internal ArrayEnumerator(KdlElement target)
            {
                _target = target;
                _curIdx = -1;

                Debug.Assert(target.TokenType == KdlTokenType.StartArray);

                _endIdxOrVersion = target._parent.GetEndIndex(_target._idx, includeEndElement: false);
            }

            /// <inheritdoc />
            public KdlElement Current
            {
                get
                {
                    if (_curIdx < 0)
                    {
                        return default;
                    }

                    return new KdlElement(_target._parent, _curIdx);
                }
            }

            /// <summary>
            ///   Returns an enumerator that iterates through a collection.
            /// </summary>
            /// <returns>
            ///   An <see cref="ArrayEnumerator"/> value that can be used to iterate
            ///   through the array.
            /// </returns>
            public ArrayEnumerator GetEnumerator()
            {
                ArrayEnumerator ator = this;
                ator._curIdx = -1;
                return ator;
            }

            /// <inheritdoc />
            IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();

            /// <inheritdoc />
            IEnumerator<KdlElement> IEnumerable<KdlElement>.GetEnumerator() => GetEnumerator();

            /// <inheritdoc />
            public void Dispose()
            {
                _curIdx = _endIdxOrVersion;
            }

            /// <inheritdoc />
            public void Reset()
            {
                _curIdx = -1;
            }

            /// <inheritdoc />
            object IEnumerator.Current => Current;

            /// <inheritdoc />
            public bool MoveNext()
            {
                if (_curIdx >= _endIdxOrVersion)
                {
                    return false;
                }

                if (_curIdx < 0)
                {
                    _curIdx = _target._idx + KdlDocument.DbRow.Size;
                }
                else
                {
                    _curIdx = _target._parent.GetEndIndex(_curIdx, includeEndElement: true);
                }

                return _curIdx < _endIdxOrVersion;
            }
        }
    }
}
