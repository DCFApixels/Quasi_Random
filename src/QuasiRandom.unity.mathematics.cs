#if UNITY_5_3_OR_NEWER
using Unity.Mathematics;

namespace DCFApixels
{
    public partial struct QuasiRandom 
    {
        #region bool
        public bool2 NextBool2()
        {
            return new bool2(
                (GetX2_Q32(++_state) & UINT_HIBIT) > 0,
                (GetY2_Q32(_state) & UINT_HIBIT) > 0);
        }
        public bool3 NextBool3()
        {
            return new bool3(
                (GetX3_Q32(++_state) & UINT_HIBIT) > 0,
                (GetY3_Q32(_state) & UINT_HIBIT) > 0,
                (GetZ3_Q32(_state) & UINT_HIBIT) > 0);
        }
        public bool4 NextBool4()
        {
            return new bool4(
                (GetX4_Q32(++_state) & UINT_HIBIT) > 0,
                (GetY4_Q32(_state) & UINT_HIBIT) > 0,
                (GetZ4_Q32(_state) & UINT_HIBIT) > 0,
                (GetW4_Q32(_state) & UINT_HIBIT) > 0);
        }
        #endregion

        #region float
        public float2 NextFloat2()
        {
            return new float2(GetX2_F(++_state), GetY2_F(_state));
        }
        public float3 NextFloat3()
        {
            return new float3(GetX3_F(++_state), GetY3_F(_state), GetZ3_F(_state));
        }
        public float4 NextFloat4()
        {
            return new float4(GetX4_F(++_state), GetY4_F(_state), GetZ4_F(_state), GetW4_F(_state));
        }
        #endregion

        #region double
        public double2 NextDouble2()
        {
            return new double2(GetX2_D(++_state), GetY2_D(_state));
        }
        public double3 NextDouble3()
        {
            return new double3(GetX3_D(++_state), GetY3_D(_state), GetZ3_D(_state));
        }
        public double4 NextDouble4()
        {
            return new double4(GetX4_D(++_state), GetY4_D(_state), GetZ4_D(_state), GetW4_D(_state));
        }
        #endregion

        #region int
        public int2 NextInt2()
        {
            return new int2(
                (int)GetX2_Q32(++_state),
                (int)GetY2_Q32(_state));
        }
        public int3 NextInt3()
        {
            return new int3(
                (int)GetX3_Q32(++_state),
                (int)GetY3_Q32(_state),
                (int)GetZ3_Q32(_state));
        }
        public int4 NextInt4()
        {
            return new int4(
                (int)GetX4_Q32(++_state),
                (int)GetY4_Q32(_state),
                (int)GetZ4_Q32(_state),
                (int)GetW4_Q32(_state));
        }

        public int2 NextInt2(int max)
        {
            return new int2(
                Compresse32(GetX2_Q32(++_state), max),
                Compresse32(GetY2_Q32(_state), max));
        }
        public int3 NextInt3(int max)
        {
            return new int3(
                Compresse32(GetX3_Q32(++_state), max),
                Compresse32(GetY3_Q32(_state), max),
                Compresse32(GetZ3_Q32(_state), max));
        }
        public int4 NextInt4(int max)
        {
            return new int4(
                Compresse32(GetX4_Q32(++_state), max),
                Compresse32(GetY4_Q32(_state), max),
                Compresse32(GetZ4_Q32(_state), max),
                Compresse32(GetW4_Q32(_state), max));
        }

        public int2 NextInt2(int min, int max)
        {
            ulong range = (ulong)(max - min);
            return new int2(
                Compresse32(GetX2_Q32(++_state), min, range),
                Compresse32(GetY2_Q32(_state), min, range));
        }
        public int3 NextInt3(int min, int max)
        {
            ulong range = (ulong)(max - min);
            return new int3(
                Compresse32(GetX3_Q32(++_state), min, range),
                Compresse32(GetY3_Q32(_state), min, range),
                Compresse32(GetZ3_Q32(_state), min, range));
        }
        public int4 NextInt4(int min, int max)
        {
            ulong range = (ulong)(max - min);
            return new int4(
                Compresse32(GetX4_Q32(++_state), min, range),
                Compresse32(GetY4_Q32(_state), min, range),
                Compresse32(GetZ4_Q32(_state), min, range),
                Compresse32(GetW4_Q32(_state), min, range));
        }
        #endregion

        #region uint
        public uint2 NextUInt2()
        {
            return new uint2(
                GetX2_Q32(++_state),
                GetY2_Q32(_state));
        }
        public uint3 NextUInt3()
        {
            return new uint3(
                GetX3_Q32(++_state),
                GetY3_Q32(_state),
                GetZ3_Q32(_state));
        }
        public uint4 NextUInt4()
        {
            return new uint4(
                GetX4_Q32(++_state),
                GetY4_Q32(_state),
                GetZ4_Q32(_state),
                GetW4_Q32(_state));
        }

        public uint2 NextUInt2(int max)
        {
            return new uint2(
                CompresseU32(GetX2_Q32(++_state), max),
                CompresseU32(GetY2_Q32(_state), max));
        }
        public uint3 NextUInt3(int max)
        {
            return new uint3(
                CompresseU32(GetX3_Q32(++_state), max),
                CompresseU32(GetY3_Q32(_state), max),
                CompresseU32(GetZ3_Q32(_state), max));
        }
        public uint4 NextUInt4(int max)
        {
            return new uint4(
                CompresseU32(GetX4_Q32(++_state), max),
                CompresseU32(GetY4_Q32(_state), max),
                CompresseU32(GetZ4_Q32(_state), max),
                CompresseU32(GetW4_Q32(_state), max));
        }

        public uint2 NextUInt2(int min, int max)
        {
            ulong range = (ulong)(max - min);
            return new uint2(
                CompresseU32(GetX2_Q32(++_state), min, range),
                CompresseU32(GetY2_Q32(_state), min, range));
        }
        public uint3 NextUInt3(int min, int max)
        {
            ulong range = (ulong)(max - min);
            return new uint3(
                CompresseU32(GetX3_Q32(++_state), min, range),
                CompresseU32(GetY3_Q32(_state), min, range),
                CompresseU32(GetZ3_Q32(_state), min, range));
        }
        public uint4 NextUInt4(int min, int max)
        {
            ulong range = (ulong)(max - min);
            return new uint4(
                CompresseU32(GetX4_Q32(++_state), min, range),
                CompresseU32(GetY4_Q32(_state), min, range),
                CompresseU32(GetZ4_Q32(_state), min, range),
                CompresseU32(GetW4_Q32(_state), min, range));
        }
        #endregion
    }
}
#endif