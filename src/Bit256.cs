using System.Runtime.CompilerServices;

namespace ECS
{
    /// <summary>
    /// Represents a 256-bit value using four 64-bit unsigned integers.
    /// Provides efficient bitwise operations and bit manipulation for large bitsets.
    /// </summary>
    public struct Bit256
    {
        /// <summary>
        /// Gets a new <see cref="Bit256"/> instance with all bits cleared (zero).
        /// </summary>
        public static Bit256 Zero => new Bit256();

        private ulong _part0;
        private ulong _part1;
        private ulong _part2;
        private ulong _part3;

        /// <summary>
        /// Initializes a new <see cref="Bit256"/> with all bits set to zero.
        /// </summary>
        public Bit256()
        {
            _part0 = 0;
            _part1 = 0;
            _part2 = 0;
            _part3 = 0;
        }

        /// <summary>
        /// Initializes a new <see cref="Bit256"/> with the specified values for each 64-bit part.
        /// </summary>
        /// <param name="part3">The most significant 64 bits.</param>
        /// <param name="part2">The next 64 bits.</param>
        /// <param name="part1">The next 64 bits.</param>
        /// <param name="part0">The least significant 64 bits.</param>
        public Bit256(ulong part3, ulong part2, ulong part1, ulong part0)
        {
            _part0 = part0;
            _part1 = part1;
            _part2 = part2;
            _part3 = part3;
        }

        /// <summary>
        /// Performs a bitwise NOT operation on the specified <see cref="Bit256"/> value.
        /// </summary>
        /// <param name="a">The value to negate.</param>
        /// <returns>A new <see cref="Bit256"/> with all bits inverted.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Bit256 operator ~(in Bit256 a)
        {
            return new Bit256(
                ~a._part3,
                ~a._part2,
                ~a._part1,
                ~a._part0
            );
        }

        /// <summary>
        /// Determines whether two <see cref="Bit256"/> values are equal.
        /// </summary>
        /// <param name="left">The first value to compare.</param>
        /// <param name="right">The second value to compare.</param>
        /// <returns>True if all bits are equal; otherwise, false.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool operator ==(Bit256 left, Bit256 right)
        {
            return left._part0 == right._part0
                && left._part1 == right._part1
                && left._part2 == right._part2
                && left._part3 == right._part3;
        }

        /// <summary>
        /// Determines whether two <see cref="Bit256"/> values are not equal.
        /// </summary>
        /// <param name="left">The first value to compare.</param>
        /// <param name="right">The second value to compare.</param>
        /// <returns>True if any bit differs; otherwise, false.</returns>
        public static bool operator !=(Bit256 left, Bit256 right)
        {
            return !(left == right);
        }

        /// <summary>
        /// Determines whether this instance and a specified object, which must also be a <see cref="Bit256"/>, have the same value.
        /// </summary>
        /// <param name="obj">The object to compare with the current instance.</param>
        /// <returns>True if the specified object is a <see cref="Bit256"/> and all bits are equal; otherwise, false.</returns>
        public override bool Equals(object? obj)
        {
            return obj is Bit256 other && this == other;
        }

        /// <summary>
        /// Returns a hash code for this instance.
        /// </summary>
        /// <returns>A hash code for the current <see cref="Bit256"/>.</returns>
        public override int GetHashCode()
        {
            return HashCode.Combine(_part0, _part1, _part2, _part3);
        }

        /// <summary>
        /// Performs a bitwise AND operation between two <see cref="Bit256"/> values.
        /// </summary>
        /// <param name="a">The first value.</param>
        /// <param name="b">The second value.</param>
        /// <returns>A new <see cref="Bit256"/> representing the bitwise AND of the two values.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Bit256 operator &(in Bit256 a, in Bit256 b)
        {
            return new Bit256(
                a._part3 & b._part3,
                a._part2 & b._part2,
                a._part1 & b._part1,
                a._part0 & b._part0
            );
        }

        /// <summary>
        /// Performs a bitwise OR operation between two <see cref="Bit256"/> values.
        /// </summary>
        /// <param name="a">The first value.</param>
        /// <param name="b">The second value.</param>
        /// <returns>A new <see cref="Bit256"/> representing the bitwise OR of the two values.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Bit256 operator |(in Bit256 a, in Bit256 b)
        {
            return new Bit256(
                a._part3 | b._part3,
                a._part2 | b._part2,
                a._part1 | b._part1,
                a._part0 | b._part0
            );
        }

        /// <summary>
        /// Performs a bitwise XOR operation between two <see cref="Bit256"/> values.
        /// </summary>
        /// <param name="a">The first value.</param>
        /// <param name="b">The second value.</param>
        /// <returns>A new <see cref="Bit256"/> representing the bitwise XOR of the two values.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Bit256 operator ^(in Bit256 a, in Bit256 b)
        {
            return new Bit256(
                a._part3 ^ b._part3,
                a._part2 ^ b._part2,
                a._part1 ^ b._part1,
                a._part0 ^ b._part0
            );
        }

        /// <summary>
        /// Determines whether all bits set in the specified <paramref name="other"/> are also set in this instance.
        /// </summary>
        /// <param name="other">The <see cref="Bit256"/> to test for containment.</param>
        /// <returns>True if all bits in <paramref name="other"/> are set in this instance; otherwise, false.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public bool Contains(in Bit256 other)
        {
            return (_part3 & other._part3) == other._part3
                && (_part2 & other._part2) == other._part2
                && (_part1 & other._part1) == other._part1
                && (_part0 & other._part0) == other._part0;
        }

        /// <summary>
        /// Gets or sets the value of the bit at the specified index.
        /// </summary>
        /// <param name="bit">The zero-based bit index (0-255).</param>
        /// <returns>True if the bit is set; otherwise, false.</returns>
        /// <exception cref="ArgumentOutOfRangeException">Thrown if <paramref name="bit"/> is not in the range 0-255.</exception>
        public bool this[byte bit]
        {
            get
            {
                int part = bit / 64;
                int offset = bit % 64;
                ulong mask = 1UL << offset;

                return part switch
                {
                    0 => (_part0 & mask) != 0,
                    1 => (_part1 & mask) != 0,
                    2 => (_part2 & mask) != 0,
                    3 => (_part3 & mask) != 0,
                    _ => false
                };
            }
            set
            {
                int part = bit / 64;
                int offset = bit % 64;
                ulong mask = 1UL << offset;

                switch (part)
                {
                    case 0:
                        if (value)
                            _part0 |= mask;
                        else
                            _part0 &= ~mask;
                        break;
                    case 1:
                        if (value)
                            _part1 |= mask;
                        else
                            _part1 &= ~mask;
                        break;
                    case 2:
                        if (value)
                            _part2 |= mask;
                        else
                            _part2 &= ~mask;
                        break;
                    case 3:
                        if (value)
                            _part3 |= mask;
                        else
                            _part3 &= ~mask;
                        break;
                }
            }
        }

        /// <summary>
        /// Clears all bits in this instance, setting them to zero.
        /// </summary>
        public void Clear()
        {
            _part0 = 0;
            _part1 = 0;
            _part2 = 0;
            _part3 = 0;
        }
    }
}
