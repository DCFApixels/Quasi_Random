using System;
using System.Numerics;
using System.Runtime.CompilerServices;
using q32 = System.UInt32;
using q64 = System.UInt64;

namespace DCFApixels
{
    /// <summary>Quasi Random. Use new additive recursive R-sequence.</summary>
    [Serializable]
    public partial struct QuasiRandom :
        IEquatable<QuasiRandom>,
        IFormattable
    {
        #region Consts
        private const uint UINT_HIBIT = 0x8000_0000;

        private const q32 Q32_MAX = q32.MaxValue;
        private const q64 Q64_MAX = q64.MaxValue;

        private const decimal G1 = 1.6180339887498948482045868383m;
        private const q32 X1_Q32 = (q32)(1m / G1 * Q32_MAX) + 1;
        private const q64 X1_Q64 = (q64)(1m / G1 * Q64_MAX) + 1;

        private const decimal G2 = 1.3247179572447460259609088563m;
        private const q32 X2_Q32 = (q32)(1m / G2 * Q32_MAX) + 1;
        private const q32 Y2_Q32 = (q32)(1m / (G2 * G2) * Q32_MAX) + 1;
        private const q64 X2_Q64 = (q64)(1m / G2 * Q64_MAX) + 1;
        private const q64 Y2_Q64 = (q64)(1m / (G2 * G2) * Q64_MAX) + 1;

        private const decimal G3 = 1.2207440846057594753616853503m;
        private const q32 X3_Q32 = (q32)(1m / G3 * Q32_MAX) + 1;
        private const q32 Y3_Q32 = (q32)(1m / (G3 * G3) * Q32_MAX) + 1;
        private const q32 Z3_Q32 = (q32)(1m / (G3 * G3 * G3) * Q32_MAX) + 1;
        private const q64 X3_Q64 = (q64)(1m / G3 * Q64_MAX) + 1;
        private const q64 Y3_Q64 = (q64)(1m / (G3 * G3) * Q64_MAX) + 1;
        private const q64 Z3_Q64 = (q64)(1m / (G3 * G3 * G3) * Q64_MAX) + 1;

        private const decimal G4 = 1.1673039782614186842560459007m;
        private const q32 X4_Q32 = (q32)(1m / G4 * Q32_MAX) + 1;
        private const q32 Y4_Q32 = (q32)(1m / (G4 * G4) * Q32_MAX) + 1;
        private const q32 Z4_Q32 = (q32)(1m / (G4 * G4 * G4) * Q32_MAX) + 1;
        private const q32 W4_Q32 = (q32)(1m / (G4 * G4 * G4 * G4) * Q32_MAX) + 1;
        private const q64 X4_Q64 = (q64)(1m / G4 * Q64_MAX) + 1;
        private const q64 Y4_Q64 = (q64)(1m / (G4 * G4) * Q64_MAX) + 1;
        private const q64 Z4_Q64 = (q64)(1m / (G4 * G4 * G4) * Q64_MAX) + 1;
        private const q64 W4_Q64 = (q64)(1m / (G4 * G4 * G4 * G4) * Q64_MAX) + 1;
        #endregion

        #region Math
        /*----------------------------------------------------------------------------------------------------------------*/

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private readonly uint GetX1_Q32(uint state) => X1_Q32 * state;
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private readonly ulong GetX1_Q64(uint state) => X1_Q64 * state;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private readonly float GetX1_F(uint state) => Q32ToFloat(GetX1_Q32(state));
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private readonly double GetX1_D(uint state) => Q64ToDouble(GetX1_Q64(state));

        /*----------------------------------------------------------------------------------------------------------------*/

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private readonly uint GetX2_Q32(uint state) => X2_Q32 * state;
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private readonly uint GetY2_Q32(uint state) => Y2_Q32 * state;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private readonly ulong GetX2_Q64(uint state) => X2_Q64 * state;
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private readonly ulong GetY2_Q64(uint state) => Y2_Q64 * state;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private readonly float GetX2_F(uint state) => Q32ToFloat(GetX2_Q32(state));
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private readonly float GetY2_F(uint state) => Q32ToFloat(GetY2_Q32(state));

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private readonly double GetX2_D(uint state) => Q64ToDouble(GetX2_Q64(state));
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private readonly double GetY2_D(uint state) => Q64ToDouble(GetY2_Q64(state));

        /*----------------------------------------------------------------------------------------------------------------*/

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private readonly uint GetX3_Q32(uint state) => X3_Q32 * state;
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private readonly uint GetY3_Q32(uint state) => Y3_Q32 * state;
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private readonly uint GetZ3_Q32(uint state) => Z3_Q32 * state;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private readonly ulong GetX3_Q64(uint state) => X3_Q64 * state;
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private readonly ulong GetY3_Q64(uint state) => Y3_Q64 * state;
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private readonly ulong GetZ3_Q64(uint state) => Z3_Q64 * state;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private readonly float GetX3_F(uint state) => Q32ToFloat(GetX3_Q32(state));
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private readonly float GetY3_F(uint state) => Q32ToFloat(GetY3_Q32(state));
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private readonly float GetZ3_F(uint state) => Q32ToFloat(GetZ3_Q32(state));

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private readonly double GetX3_D(uint state) => Q64ToDouble(GetX3_Q64(state));
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private readonly double GetY3_D(uint state) => Q64ToDouble(GetY3_Q64(state));
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private readonly double GetZ3_D(uint state) => Q64ToDouble(GetZ3_Q64(state));

        /*----------------------------------------------------------------------------------------------------------------*/

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private readonly uint GetX4_Q32(uint state) => X4_Q32 * state;
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private readonly uint GetY4_Q32(uint state) => Y4_Q32 * state;
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private readonly uint GetZ4_Q32(uint state) => Z4_Q32 * state;
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private readonly uint GetW4_Q32(uint state) => W4_Q32 * state;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private readonly ulong GetX4_Q64(uint state) => X4_Q64 * state;
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private readonly ulong GetY4_Q64(uint state) => Y4_Q64 * state;
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private readonly ulong GetZ4_Q64(uint state) => Z4_Q64 * state;
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private readonly ulong GetW4_Q64(uint state) => W4_Q64 * state;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private readonly float GetX4_F(uint state) => Q32ToFloat(GetX4_Q32(state));
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private readonly float GetY4_F(uint state) => Q32ToFloat(GetY4_Q32(state));
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private readonly float GetZ4_F(uint state) => Q32ToFloat(GetZ4_Q32(state));
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private readonly float GetW4_F(uint state) => Q32ToFloat(GetW4_Q32(state));

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private readonly double GetX4_D(uint state) => Q64ToDouble(GetX4_Q64(state));
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private readonly double GetY4_D(uint state) => Q64ToDouble(GetY4_Q64(state));
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private readonly double GetZ4_D(uint state) => Q64ToDouble(GetZ4_Q64(state));
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private readonly double GetW4_D(uint state) => Q64ToDouble(GetW4_Q64(state));

        /*----------------------------------------------------------------------------------------------------------------*/

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static unsafe float AsFloat(uint value) => *(float*)&value;
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static unsafe double AsDouble(ulong value) => *(double*)&value;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static float Q32ToFloat(uint value) => AsFloat((value >> 9) | 0x3F80_0000) - 1f;
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static double Q64ToDouble(ulong value) => AsDouble((value >> 12) | 0x7FF0_0000_0000_0000) - 1d;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static uint CompresseU32(uint value, int range) => (uint)((value * (ulong)range) >> 32);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static int Compresse32(uint value, int range) => (int)((value * (ulong)range) >> 32);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static uint CompresseU32(uint value, ulong range) => (uint)((value * range) >> 32);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static int Compresse32(uint value, ulong range) => (int)((value * range) >> 32);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static uint CompresseU32(uint value, int min, ulong range) => (uint)((value * range) >> 32 + min);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static int Compresse32(uint value, int min, ulong range) => (int)((value * range) >> 32) + min;

        /*----------------------------------------------------------------------------------------------------------------*/
        #endregion

        private uint _state;

        #region Constructors
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public QuasiRandom(int seed)
        {
            _state = (uint)seed;
        }
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public QuasiRandom(uint seed)
        {
            _state = seed;
        }
        public static QuasiRandom AutoSeed()
        {
            uint seed = (uint)DateTime.Now.Ticks;
            seed ^= seed << 13;
            seed ^= seed >> 17;
            seed ^= seed << 5;
            return new QuasiRandom(seed);
        }
        #endregion


        #region bool
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public bool NextBool() => (GetX1_Q32(++_state) & UINT_HIBIT) > 0;

        public void NextBool2(out bool x, out bool y)
        {
            x = (GetX2_Q32(++_state) & UINT_HIBIT) > 0;
            y = (GetY2_Q32(_state) & UINT_HIBIT) > 0;
        }
        public void NextBool3(out bool x, out bool y, out bool z)
        {
            x = (GetX3_Q32(++_state) & UINT_HIBIT) > 0;
            y = (GetY3_Q32(_state) & UINT_HIBIT) > 0;
            z = (GetZ3_Q32(_state) & UINT_HIBIT) > 0;
        }
        public void NextBool4(out bool x, out bool y, out bool z, out bool w)
        {
            x = (GetX4_Q32(++_state) & UINT_HIBIT) > 0;
            y = (GetY4_Q32(_state) & UINT_HIBIT) > 0;
            z = (GetZ4_Q32(_state) & UINT_HIBIT) > 0;
            w = (GetW4_Q32(_state) & UINT_HIBIT) > 0;
        }
        #endregion

        #region Int
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public int NextInt()
        {
            return (int)GetX1_Q32(++_state);
        }
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public int NextInt(int max)
        {
            return Compresse32(GetX1_Q32(++_state), max);
        }
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public int NextInt(int min, int max)
        {
            return Compresse32(GetX1_Q32(++_state), min, (ulong)(max - min));
        }

        public void NextInt2(out int x, out int y)
        {
            x = (int)GetX2_Q32(++_state);
            y = (int)GetY2_Q32(_state);
        }
        public void NextInt2(int max, out int x, out int y)
        {
            x = Compresse32(GetX2_Q32(++_state), max);
            y = Compresse32(GetY2_Q32(_state), max);
        }
        public void NextInt2(int min, int max, out int x, out int y)
        {
            ulong range = (ulong)(max - min);
            x = Compresse32(GetX2_Q32(++_state), min, range);
            y = Compresse32(GetY2_Q32(_state), min, range);
        }

        public void NextInt3(out int x, out int y, out int z)
        {
            x = (int)GetX3_Q32(++_state);
            y = (int)GetY3_Q32(_state);
            z = (int)GetZ3_Q32(_state);
        }
        public void NextInt3(int max, out int x, out int y, out int z)
        {
            x = Compresse32(GetX3_Q32(++_state), max);
            y = Compresse32(GetY3_Q32(_state), max);
            z = Compresse32(GetZ3_Q32(_state), max);
        }
        public void NextInt3(int min, int max, out int x, out int y, out int z)
        {
            ulong range = (ulong)(max - min);
            x = Compresse32(GetX3_Q32(++_state), min, range);
            y = Compresse32(GetY3_Q32(_state), min, range);
            z = Compresse32(GetZ3_Q32(_state), min, range);
        }

        public void NextInt4(out int x, out int y, out int z, out int w)
        {
            x = (int)GetX4_Q32(++_state);
            y = (int)GetY4_Q32(_state);
            z = (int)GetZ4_Q32(_state);
            w = (int)GetW4_Q32(_state);
        }
        public void NextInt4(int max, out int x, out int y, out int z, out int w)
        {
            x = Compresse32(GetX4_Q32(++_state), max);
            y = Compresse32(GetY4_Q32(_state), max);
            z = Compresse32(GetZ4_Q32(_state), max);
            w = Compresse32(GetW4_Q32(_state), max);
        }
        public void NextInt4(int min, int max, out int x, out int y, out int z, out int w)
        {
            ulong range = (ulong)(max - min);
            x = Compresse32(GetX4_Q32(++_state), min, range);
            y = Compresse32(GetY4_Q32(_state), min, range);
            z = Compresse32(GetZ4_Q32(_state), min, range);
            w = Compresse32(GetW4_Q32(_state), min, range);
        }
        #endregion

        #region UInt
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public uint NextUInt()
        {
            return GetX1_Q32(++_state);
        }
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public uint NextUInt(int max)
        {
            return CompresseU32(GetX1_Q32(++_state), max);
        }
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public uint NextUInt(int min, int max)
        {
            return CompresseU32(GetX1_Q32(++_state), min, (ulong)(max - min));
        }

        public void NextUInt2(out uint x, out uint y)
        {
            x = GetX2_Q32(++_state);
            y = GetY2_Q32(_state);
        }
        public void NextUInt2(int max, out uint x, out uint y)
        {
            x = CompresseU32(GetX2_Q32(++_state), max);
            y = CompresseU32(GetY2_Q32(_state), max);
        }
        public void NextUInt2(int min, int max, out uint x, out uint y)
        {
            ulong range = (ulong)(max - min);
            x = CompresseU32(GetX2_Q32(++_state), min, range);
            y = CompresseU32(GetY2_Q32(_state), min, range);
        }

        public void NextUInt3(out uint x, out uint y, out uint z)
        {
            x = GetX3_Q32(++_state);
            y = GetY3_Q32(_state);
            z = GetZ3_Q32(_state);
        }
        public void NextUInt3(int max, out uint x, out uint y, out uint z)
        {
            x = CompresseU32(GetX3_Q32(++_state), max);
            y = CompresseU32(GetY3_Q32(_state), max);
            z = CompresseU32(GetZ3_Q32(_state), max);
        }
        public void NextUInt3(int min, int max, out uint x, out uint y, out uint z)
        {
            ulong range = (ulong)(max - min);
            x = CompresseU32(GetX3_Q32(++_state), min, range);
            y = CompresseU32(GetY3_Q32(_state), min, range);
            z = CompresseU32(GetZ3_Q32(_state), min, range);
        }

        public void NextUInt4(out uint x, out uint y, out uint z, out uint w)
        {
            x = GetX4_Q32(++_state);
            y = GetY4_Q32(_state);
            z = GetZ4_Q32(_state);
            w = GetW4_Q32(_state);
        }
        public void NextUInt4(int max, out uint x, out uint y, out uint z, out uint w)
        {
            x = CompresseU32(GetX4_Q32(++_state), max);
            y = CompresseU32(GetY4_Q32(_state), max);
            z = CompresseU32(GetZ4_Q32(_state), max);
            w = CompresseU32(GetW4_Q32(_state), max);
        }
        public void NextUInt4(int min, int max, out uint x, out uint y, out uint z, out uint w)
        {
            ulong range = (ulong)(max - min);
            x = CompresseU32(GetX4_Q32(++_state), min, range);
            y = CompresseU32(GetY4_Q32(_state), min, range);
            z = CompresseU32(GetZ4_Q32(_state), min, range);
            w = CompresseU32(GetW4_Q32(_state), min, range);
        }
        #endregion

        #region Long
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public long NextLong()
        {
            return (long)GetX1_Q64(++_state);
        }

        public void NextLong2(out long x, out long y)
        {
            x = (long)GetX2_Q64(++_state);
            y = (long)GetY2_Q64(_state);
        }

        public void NextLong3(out long x, out long y, out long z)
        {
            x = (long)GetX3_Q64(++_state);
            y = (long)GetY3_Q64(_state);
            z = (long)GetZ3_Q64(_state);
        }

        public void NextLong4(out long x, out long y, out long z, out long w)
        {
            x = (long)GetX4_Q64(++_state);
            y = (long)GetY4_Q64(_state);
            z = (long)GetZ4_Q64(_state);
            w = (long)GetW4_Q64(_state);
        }
        #endregion

        #region ULong
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public ulong NextULong()
        {
            return GetX1_Q64(++_state);
        }

        public void NextULong2(out ulong x, out ulong y)
        {
            x = GetX2_Q64(++_state);
            y = GetY2_Q64(_state);
        }

        public void NextULong3(out ulong x, out ulong y, out ulong z)
        {
            x = GetX3_Q64(++_state);
            y = GetY3_Q64(_state);
            z = GetZ3_Q64(_state);
        }

        public void NextULong4(out ulong x, out ulong y, out ulong z, out ulong w)
        {
            x = GetX4_Q64(++_state);
            y = GetY4_Q64(_state);
            z = GetZ4_Q64(_state);
            w = GetW4_Q64(_state);
        }
        #endregion

        #region Float
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public float NextFloat()
        {
            return GetX1_F(++_state);
        }

        public void NextFloat2(out float x, out float y)
        {
            x = GetX2_F(++_state);
            y = GetY2_F(_state);
        }
        public void NextFloat3(out float x, out float y, out float z)
        {
            x = GetX3_F(++_state);
            y = GetY3_F(_state);
            z = GetZ3_F(_state);
        }
        public void NextFloat4(out float x, out float y, out float z, out float w)
        {
            x = GetX4_F(++_state);
            y = GetY4_F(_state);
            z = GetZ4_F(_state);
            w = GetW4_F(_state);
        }

        public Vector2 NextVector2()
        {
            return new Vector2(GetX2_F(++_state), GetY2_F(_state));
        }
        public Vector3 NextVector3()
        {
            return new Vector3(GetX3_F(++_state), GetY3_F(_state), GetZ3_F(_state));
        }
        public Vector4 NextVector4()
        {
            return new Vector4(GetX4_F(++_state), GetY4_F(_state), GetZ4_F(_state), GetW4_F(_state));
        }
        #endregion

        #region Double
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public double NextDouble()
        {
            return GetX1_D(++_state);
        }

        public void NextDouble2(out double x, out double y)
        {
            x = GetX2_D(++_state);
            y = GetY2_D(_state);
        }
        public void NextDouble3(out double x, out double y, out double z)
        {
            x = GetX3_D(++_state);
            y = GetY3_D(_state);
            z = GetZ3_D(_state);
        }
        public void NextDouble4(out double x, out double y, out double z, out double w)
        {
            x = GetX4_D(++_state);
            y = GetY4_D(_state);
            z = GetZ4_D(_state);
            w = GetW4_D(_state);
        }
        #endregion


        #region State
        public uint GetState() => _state;
        public uint SetState(int state) => _state = (uint)state;
        public uint SetState(uint state) => _state = state;
        #endregion

        #region Other
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public override bool Equals(object o) => o is QuasiRandom target && Equals(target);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public bool Equals(QuasiRandom a) => a._state == _state;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public override int GetHashCode() => (int)_state;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public override string ToString() => $"{nameof(QuasiRandom)}({_state})";
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public string ToString(string format, IFormatProvider formatProvider)
        {
            return $"{nameof(QuasiRandom)}({_state.ToString(format, formatProvider)})";
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool operator ==(QuasiRandom a, QuasiRandom b) => a._state == b._state;
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool operator !=(QuasiRandom a, QuasiRandom b) => a._state != b._state;
        #endregion
    }
}