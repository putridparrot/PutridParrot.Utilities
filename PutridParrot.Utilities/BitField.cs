using System;

namespace PutridParrot.Utilities
{
    using BITFIELDTYPE = Int64;

    /// <summary>
    /// A compact and simple low level implementation of bit flags. The BitArray
    /// exists for an array of bit values, but seems overkill for some situations.
    /// </summary>
    public class BitFields
    {
        private const int BITSPERBYTE = 8;

        private BITFIELDTYPE _state;

        /// <summary>
        /// Instantiates a default BitFlag with all bits set to zero.
        /// </summary>
        public BitFields()
        {
        }
        /// <summary>
        /// Instantiates a BitFlag class with the bit flags set to the provided
        /// state.
        /// </summary>
        /// <param name="state">The initial state of the bit flags</param>
        public BitFields(BITFIELDTYPE state)
            : this()
        {
            this._state = state;
        }

        /// <summary>
        /// Gets/sets the state of the bit flags within the BitFlag object.
        /// </summary>
        public BITFIELDTYPE State
        {
            get => _state;
            set => _state = value;
        }
        /// <summary>
        /// Gets the number of bits stored/available within the object.
        /// </summary>
        public int Count => sizeof(BITFIELDTYPE) * BITSPERBYTE;

        /// <summary>
        /// Gets/sets the bit at the specified index.
        /// </summary>
        /// <param name="index">The index to get/set the bit at.</param>
        /// <returns>A boolean representing whether the flag at the given index is true or false.</returns>
        /// <exception cref="IndexOutOfRangeException"/>
        public bool this[int index]
        {
            get
            {
                if (index < 0 || index >= Count)
                    throw new IndexOutOfRangeException("The supplied index of " + index + " is out of range");

                var mask = 1 << index;
                return (mask & State) != 0;

            }
            set
            {
                if (index < 0 || index >= Count)
                    throw new IndexOutOfRangeException("The supplied index of " + index + " is out of range");

                State ^= 1 << index;
            }
        }
        /// <summary>
        /// Bitwise AND of the state within the instance of the object.
        /// </summary>
        /// <param name="value">The value to AND with.</param>
        /// <returns>The value of the state AND'd with the value.</returns>
        public BITFIELDTYPE And(BitFields value) =>
            And(State, value);

        /// <summary>
        /// Bitwise OR of the state within the instance of the object.
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public BITFIELDTYPE Or(BitFields value)
        {
            return Or(State, value);
        }
        /// <summary>
        /// Bitwise XOR of the state within the instance of the object.
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public BITFIELDTYPE Xor(BitFields value)
        {
            return Xor(State, value);
        }
        /// <summary>
        /// Bitwise NOT of the state within the instance of the object. i.e. bits are inverted, 1's
        /// become 0 and 0's become 1.
        /// </summary>
        /// <returns></returns>
        public BITFIELDTYPE Not()
        {
            return Not(State);
        }
        /// <summary>
        /// Bitwise AND of two BitFlag objects.
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns></returns>
        public static BITFIELDTYPE And(BitFields a, BitFields b)
        {
            return a.State & b.State;
        }
        /// <summary>
        /// Bitwise OR of two BitFlag objects.
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns></returns>
        public static BITFIELDTYPE Or(BitFields a, BitFields b)
        {
            return a.State | b.State;
        }
        /// <summary>
        /// Bitwise XOR of two BitFlag objects.
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns></returns>
        public static BITFIELDTYPE Xor(BitFields a, BitFields b)
        {
            return a.State ^ b.State;
        }
        /// <summary>
        /// Bitwise NOT of a BitFlag object.
        /// </summary>
        /// <param name="a"></param>
        /// <returns></returns>
        public static BITFIELDTYPE Not(BitFields a)
        {
            return ~a.State;
        }
        /// <summary>
        /// Bitwise AND of two BitFlag objects.
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns></returns>
        public static BITFIELDTYPE operator &(BitFields a, BitFields b)
        {
            return And(a.State, b.State);
        }
        /// <summary>
        /// Bitwise OR of two BitFlag objects.
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns></returns>
        public static BITFIELDTYPE operator |(BitFields a, BitFields b)
        {
            return Or(a.State, b.State);
        }
        /// <summary>
        /// Bitwise XOR of two BitFlag objects.
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns></returns>
        public static BITFIELDTYPE operator ^(BitFields a, BitFields b)
        {
            return Xor(a.State, b.State);
        }
        /// <summary>
        /// Bitwise NOT of two BitFlag objects.
        /// </summary>
        /// <param name="a"></param>
        /// <returns></returns>
        public static BITFIELDTYPE operator ~(BitFields a)
        {
            return Not(a.State);
        }
        /// <summary>
        /// Left bit shift of the BitFlag by a number of bits.
        /// </summary>
        /// <param name="bits"></param>
        /// <param name="amount"></param>
        /// <returns></returns>
        public static BITFIELDTYPE operator <<(BitFields bits, int amount)
        {
            return bits.State << amount;
        }
        /// <summary>
        /// Right bit shift of the BitFlag by a number of bits.
        /// </summary>
        /// <param name="bits"></param>
        /// <param name="amount"></param>
        /// <returns></returns>
        public static BITFIELDTYPE operator >>(BitFields bits, int amount)
        {
            return bits.State >> amount;
        }
        /// <summary>
        /// Implicit operator overload to return a value type representation
        /// of the object, i.e. it's state.
        /// </summary>
        /// <param name="bits"></param>
        /// <returns></returns>
        public static implicit operator BITFIELDTYPE(BitFields bits)
        {
            return bits.State;
        }
        /// <summary>
        /// Creates a BitFlag object from a value type.
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static implicit operator BitFields(BITFIELDTYPE value)
        {
            return new BitFields(value);
        }
    }

}
