#if UNITY_5_3_OR_NEWER
using System.Runtime.CompilerServices;
using Unity.Mathematics;

namespace DCFApixels
{
    using IN = MethodImplAttribute;

    public partial struct QuasiRandom
    {
        #region Vectors
        public partial struct Bool2
        {
            [IN(LINE)] public static explicit operator float2(Bool2 a) => new float2(a.X ? 1 : 0, a.Y ? 1 : 0);
            [IN(LINE)] public static explicit operator float3(Bool2 a) => new float3(a.X ? 1 : 0, a.Y ? 1 : 0, 0);
            [IN(LINE)] public static explicit operator float4(Bool2 a) => new float4(a.X ? 1 : 0, a.Y ? 1 : 0, 0, 0);
            [IN(LINE)] public static explicit operator double2(Bool2 a) => new double2(a.X ? 1 : 0, a.Y ? 1 : 0);
            [IN(LINE)] public static explicit operator double3(Bool2 a) => new double3(a.X ? 1 : 0, a.Y ? 1 : 0, 0);
            [IN(LINE)] public static explicit operator double4(Bool2 a) => new double4(a.X ? 1 : 0, a.Y ? 1 : 0, 0, 0);
            [IN(LINE)] public static explicit operator int2(Bool2 a) => new int2(a.X ? 1 : 0, a.Y ? 1 : 0);
            [IN(LINE)] public static explicit operator int3(Bool2 a) => new int3(a.X ? 1 : 0, a.Y ? 1 : 0, 0);
            [IN(LINE)] public static explicit operator int4(Bool2 a) => new int4(a.X ? 1 : 0, a.Y ? 1 : 0, 0, 0);
            [IN(LINE)] public static explicit operator uint2(Bool2 a) => new uint2(a.X ? 1U : 0, a.Y ? 1U : 0);
            [IN(LINE)] public static explicit operator uint3(Bool2 a) => new uint3(a.X ? 1U : 0, a.Y ? 1U : 0, 0);
            [IN(LINE)] public static explicit operator uint4(Bool2 a) => new uint4(a.X ? 1U : 0, a.Y ? 1U : 0, 0, 0);
        }
        public partial struct Bool3
        {
            [IN(LINE)] public static explicit operator float3(Bool3 a) => new float3(a.X ? 1 : 0, a.Y ? 1 : 0, a.Z ? 1 : 0);
            [IN(LINE)] public static explicit operator float4(Bool3 a) => new float4(a.X ? 1 : 0, a.Y ? 1 : 0, a.Z ? 1 : 0, 0);
            [IN(LINE)] public static explicit operator double3(Bool3 a) => new double3(a.X ? 1 : 0, a.Y ? 1 : 0, a.Z ? 1 : 0);
            [IN(LINE)] public static explicit operator double4(Bool3 a) => new double4(a.X ? 1 : 0, a.Y ? 1 : 0, a.Z ? 1 : 0, 0);
            [IN(LINE)] public static explicit operator int3(Bool3 a) => new int3(a.X ? 1 : 0, a.Y ? 1 : 0, a.Z ? 1 : 0);
            [IN(LINE)] public static explicit operator int4(Bool3 a) => new int4(a.X ? 1 : 0, a.Y ? 1 : 0, a.Z ? 1 : 0, 0);
            [IN(LINE)] public static explicit operator uint3(Bool3 a) => new uint3(a.X ? 1U : 0, a.Y ? 1U : 0, a.Z ? 1U : 0);
            [IN(LINE)] public static explicit operator uint4(Bool3 a) => new uint4(a.X ? 1U : 0, a.Y ? 1U : 0, a.Z ? 1U : 0, 0);
        }
        public partial struct Bool4
        {
            [IN(LINE)] public static explicit operator float4(Bool4 a) => new float4(a.X ? 1 : 0, a.Y ? 1 : 0, a.Z ? 1 : 0, a.W ? 1 : 0);
            [IN(LINE)] public static explicit operator double4(Bool4 a) => new double4(a.X ? 1 : 0, a.Y ? 1 : 0, a.Z ? 1 : 0, a.W ? 1 : 0);
            [IN(LINE)] public static explicit operator int4(Bool4 a) => new int4(a.X ? 1 : 0, a.Y ? 1 : 0, a.Z ? 1 : 0, a.W ? 1 : 0);
            [IN(LINE)] public static explicit operator uint4(Bool4 a) => new uint4(a.X ? 1U : 0, a.Y ? 1U : 0, a.Z ? 1U : 0, a.W ? 1U : 0);
        }

        public partial struct Float2
        {
            [IN(LINE)] public static implicit operator float2(Float2 a) => new float2(a.X, a.Y);
            [IN(LINE)] public static implicit operator float3(Float2 a) => new float3(a.X, a.Y, 0);
            [IN(LINE)] public static implicit operator float4(Float2 a) => new float4(a.X, a.Y, 0, 0);
            [IN(LINE)] public static implicit operator double2(Float2 a) => new double2(a.X, a.Y);
            [IN(LINE)] public static implicit operator double3(Float2 a) => new double3(a.X, a.Y, 0);
            [IN(LINE)] public static implicit operator double4(Float2 a) => new double4(a.X, a.Y, 0, 0);
            [IN(LINE)] public static explicit operator int2(Float2 a) => new int2((int)a.X, (int)a.Y);
            [IN(LINE)] public static explicit operator int3(Float2 a) => new int3((int)a.X, (int)a.Y, 0);
            [IN(LINE)] public static explicit operator int4(Float2 a) => new int4((int)a.X, (int)a.Y, 0, 0);
            [IN(LINE)] public static explicit operator uint2(Float2 a) => new uint2((uint)a.X, (uint)a.Y);
            [IN(LINE)] public static explicit operator uint3(Float2 a) => new uint3((uint)a.X, (uint)a.Y, 0);
            [IN(LINE)] public static explicit operator uint4(Float2 a) => new uint4((uint)a.X, (uint)a.Y, 0, 0);
        }
        public partial struct Float3
        {
            [IN(LINE)] public static implicit operator float3(Float3 a) => new float3(a.X, a.Y, a.Z);
            [IN(LINE)] public static implicit operator float4(Float3 a) => new float4(a.X, a.Y, a.Z, 0);
            [IN(LINE)] public static implicit operator double3(Float3 a) => new double3(a.X, a.Y, a.Z);
            [IN(LINE)] public static implicit operator double4(Float3 a) => new double4(a.X, a.Y, a.Z, 0);
            [IN(LINE)] public static explicit operator int3(Float3 a) => new int3((int)a.X, (int)a.Y, (int)a.Z);
            [IN(LINE)] public static explicit operator int4(Float3 a) => new int4((int)a.X, (int)a.Y, (int)a.Z, 0);
            [IN(LINE)] public static explicit operator uint3(Float3 a) => new uint3((uint)a.X, (uint)a.Y, (uint)a.Z);
            [IN(LINE)] public static explicit operator uint4(Float3 a) => new uint4((uint)a.X, (uint)a.Y, (uint)a.Z, 0);
        }
        public partial struct Float4
        {
            [IN(LINE)] public static implicit operator float4(Float4 a) => new float4(a.X, a.Y, a.Z, a.W);
            [IN(LINE)] public static implicit operator double4(Float4 a) => new double4(a.X, a.Y, a.Z, a.W);
            [IN(LINE)] public static explicit operator int4(Float4 a) => new int4((int)a.X, (int)a.Y, (int)a.Z, (int)a.W);
            [IN(LINE)] public static explicit operator uint4(Float4 a) => new uint4((uint)a.X, (uint)a.Y, (uint)a.Z, (uint)a.W);
        }

        public partial struct Double2
        {
            [IN(LINE)] public static explicit operator float2(Double2 a) => new float2((float)a.X, (float)a.Y);
            [IN(LINE)] public static explicit operator float3(Double2 a) => new float3((float)a.X, (float)a.Y, 0);
            [IN(LINE)] public static explicit operator float4(Double2 a) => new float4((float)a.X, (float)a.Y, 0, 0);
            [IN(LINE)] public static implicit operator double2(Double2 a) => new double2(a.X, a.Y);
            [IN(LINE)] public static implicit operator double3(Double2 a) => new double3(a.X, a.Y, 0);
            [IN(LINE)] public static implicit operator double4(Double2 a) => new double4(a.X, a.Y, 0, 0);
            [IN(LINE)] public static explicit operator int2(Double2 a) => new int2((int)a.X, (int)a.Y);
            [IN(LINE)] public static explicit operator int3(Double2 a) => new int3((int)a.X, (int)a.Y, 0);
            [IN(LINE)] public static explicit operator int4(Double2 a) => new int4((int)a.X, (int)a.Y, 0, 0);
            [IN(LINE)] public static explicit operator uint2(Double2 a) => new uint2((uint)a.X, (uint)a.Y);
            [IN(LINE)] public static explicit operator uint3(Double2 a) => new uint3((uint)a.X, (uint)a.Y, 0);
            [IN(LINE)] public static explicit operator uint4(Double2 a) => new uint4((uint)a.X, (uint)a.Y, 0, 0);
        }
        public partial struct Double3
        {
            [IN(LINE)] public static explicit operator float3(Double3 a) => new float3((float)a.X, (float)a.Y, (float)a.Z);
            [IN(LINE)] public static explicit operator float4(Double3 a) => new float4((float)a.X, (float)a.Y, (float)a.Z, 0);
            [IN(LINE)] public static implicit operator double3(Double3 a) => new double3(a.X, a.Y, a.Z);
            [IN(LINE)] public static implicit operator double4(Double3 a) => new double4(a.X, a.Y, a.Z, 0);
            [IN(LINE)] public static explicit operator int3(Double3 a) => new int3((int)a.X, (int)a.Y, (int)a.Z);
            [IN(LINE)] public static explicit operator int4(Double3 a) => new int4((int)a.X, (int)a.Y, (int)a.Z, 0);
            [IN(LINE)] public static explicit operator uint3(Double3 a) => new uint3((uint)a.X, (uint)a.Y, (uint)a.Z);
            [IN(LINE)] public static explicit operator uint4(Double3 a) => new uint4((uint)a.X, (uint)a.Y, (uint)a.Z, 0);
        }
        public partial struct Double4
        {
            [IN(LINE)] public static explicit operator float4(Double4 a) => new float4((float)a.X, (float)a.Y, (float)a.Z, (float)a.W);
            [IN(LINE)] public static implicit operator double4(Double4 a) => new double4(a.X, a.Y, a.Z, a.W);
            [IN(LINE)] public static explicit operator int4(Double4 a) => new int4((int)a.X, (int)a.Y, (int)a.Z, (int)a.W);
            [IN(LINE)] public static explicit operator uint4(Double4 a) => new uint4((uint)a.X, (uint)a.Y, (uint)a.Z, (uint)a.W);
        }

        public partial struct Int2
        {
            [IN(LINE)] public static implicit operator float2(Int2 a) => new float2(a.X, a.Y);
            [IN(LINE)] public static implicit operator float3(Int2 a) => new float3(a.X, a.Y, 0);
            [IN(LINE)] public static implicit operator float4(Int2 a) => new float4(a.X, a.Y, 0, 0);
            [IN(LINE)] public static implicit operator double2(Int2 a) => new double2(a.X, a.Y);
            [IN(LINE)] public static implicit operator double3(Int2 a) => new double3(a.X, a.Y, 0);
            [IN(LINE)] public static implicit operator double4(Int2 a) => new double4(a.X, a.Y, 0, 0);
            [IN(LINE)] public static implicit operator int2(Int2 a) => new int2(a.X, a.Y);
            [IN(LINE)] public static implicit operator int3(Int2 a) => new int3(a.X, a.Y, 0);
            [IN(LINE)] public static implicit operator int4(Int2 a) => new int4(a.X, a.Y, 0, 0);
            [IN(LINE)] public static explicit operator uint2(Int2 a) => new uint2((uint)a.X, (uint)a.Y);
            [IN(LINE)] public static explicit operator uint3(Int2 a) => new uint3((uint)a.X, (uint)a.Y, 0);
            [IN(LINE)] public static explicit operator uint4(Int2 a) => new uint4((uint)a.X, (uint)a.Y, 0, 0);
        }
        public partial struct Int3
        {
            [IN(LINE)] public static implicit operator float3(Int3 a) => new float3(a.X, a.Y, a.Z);
            [IN(LINE)] public static implicit operator float4(Int3 a) => new float4(a.X, a.Y, a.Z, 0);
            [IN(LINE)] public static implicit operator double3(Int3 a) => new double3(a.X, a.Y, a.Z);
            [IN(LINE)] public static implicit operator double4(Int3 a) => new double4(a.X, a.Y, a.Z, 0);
            [IN(LINE)] public static implicit operator int3(Int3 a) => new int3(a.X, a.Y, a.Z);
            [IN(LINE)] public static implicit operator int4(Int3 a) => new int4(a.X, a.Y, a.Z, 0);
            [IN(LINE)] public static explicit operator uint3(Int3 a) => new uint3((uint)a.X, (uint)a.Y, (uint)a.Z);
            [IN(LINE)] public static explicit operator uint4(Int3 a) => new uint4((uint)a.X, (uint)a.Y, (uint)a.Z, 0);
        }
        public partial struct Int4
        {
            [IN(LINE)] public static implicit operator float4(Int4 a) => new float4(a.X, a.Y, a.Z, a.W);
            [IN(LINE)] public static implicit operator double4(Int4 a) => new double4(a.X, a.Y, a.Z, a.W);
            [IN(LINE)] public static implicit operator int4(Int4 a) => new int4(a.X, a.Y, a.Z, a.W);
            [IN(LINE)] public static explicit operator uint4(Int4 a) => new uint4((uint)a.X, (uint)a.Y, (uint)a.Z, (uint)a.W);
        }

        public partial struct UInt2
        {
            [IN(LINE)] public static implicit operator float2(UInt2 a) => new float2(a.X, a.Y);
            [IN(LINE)] public static implicit operator float3(UInt2 a) => new float3(a.X, a.Y, 0);
            [IN(LINE)] public static implicit operator float4(UInt2 a) => new float4(a.X, a.Y, 0, 0);
            [IN(LINE)] public static implicit operator double2(UInt2 a) => new double2(a.X, a.Y);
            [IN(LINE)] public static implicit operator double3(UInt2 a) => new double3(a.X, a.Y, 0);
            [IN(LINE)] public static implicit operator double4(UInt2 a) => new double4(a.X, a.Y, 0, 0);
            [IN(LINE)] public static explicit operator int2(UInt2 a) => new int2((int)a.X, (int)a.Y);
            [IN(LINE)] public static explicit operator int3(UInt2 a) => new int3((int)a.X, (int)a.Y, 0);
            [IN(LINE)] public static explicit operator int4(UInt2 a) => new int4((int)a.X, (int)a.Y, 0, 0);
            [IN(LINE)] public static implicit operator uint2(UInt2 a) => new uint2(a.X, a.Y);
            [IN(LINE)] public static implicit operator uint3(UInt2 a) => new uint3(a.X, a.Y, 0);
            [IN(LINE)] public static implicit operator uint4(UInt2 a) => new uint4(a.X, a.Y, 0, 0);
        }
        public partial struct UInt3
        {
            [IN(LINE)] public static implicit operator float3(UInt3 a) => new float3(a.X, a.Y, a.Z);
            [IN(LINE)] public static implicit operator float4(UInt3 a) => new float4(a.X, a.Y, a.Z, 0);
            [IN(LINE)] public static implicit operator double3(UInt3 a) => new double3(a.X, a.Y, a.Z);
            [IN(LINE)] public static implicit operator double4(UInt3 a) => new double4(a.X, a.Y, a.Z, 0);
            [IN(LINE)] public static explicit operator int3(UInt3 a) => new int3((int)a.X, (int)a.Y, (int)a.Z);
            [IN(LINE)] public static explicit operator int4(UInt3 a) => new int4((int)a.X, (int)a.Y, (int)a.Z, 0);
            [IN(LINE)] public static implicit operator uint3(UInt3 a) => new uint3(a.X, a.Y, a.Z);
            [IN(LINE)] public static implicit operator uint4(UInt3 a) => new uint4(a.X, a.Y, a.Z, 0);
        }
        public partial struct UInt4
        {
            [IN(LINE)] public static implicit operator float4(UInt4 a) => new float4(a.X, a.Y, a.Z, a.W);
            [IN(LINE)] public static implicit operator double4(UInt4 a) => new double4(a.X, a.Y, a.Z, a.W);
            [IN(LINE)] public static explicit operator int4(UInt4 a) => new int4((int)a.X, (int)a.Y, (int)a.Z, (int)a.W);
            [IN(LINE)] public static implicit operator uint4(UInt4 a) => new uint4(a.X, a.Y, a.Z, a.W);
        }

        public partial struct Long2
        {
            [IN(LINE)] public static implicit operator float2(Long2 a) => new float2(a.X, a.Y);
            [IN(LINE)] public static implicit operator float3(Long2 a) => new float3(a.X, a.Y, 0);
            [IN(LINE)] public static implicit operator float4(Long2 a) => new float4(a.X, a.Y, 0, 0);
            [IN(LINE)] public static implicit operator double2(Long2 a) => new double2(a.X, a.Y);
            [IN(LINE)] public static implicit operator double3(Long2 a) => new double3(a.X, a.Y, 0);
            [IN(LINE)] public static implicit operator double4(Long2 a) => new double4(a.X, a.Y, 0, 0);
            [IN(LINE)] public static explicit operator int2(Long2 a) => new int2((int)a.X, (int)a.Y);
            [IN(LINE)] public static explicit operator int3(Long2 a) => new int3((int)a.X, (int)a.Y, 0);
            [IN(LINE)] public static explicit operator int4(Long2 a) => new int4((int)a.X, (int)a.Y, 0, 0);
            [IN(LINE)] public static explicit operator uint2(Long2 a) => new uint2((uint)a.X, (uint)a.Y);
            [IN(LINE)] public static explicit operator uint3(Long2 a) => new uint3((uint)a.X, (uint)a.Y, 0);
            [IN(LINE)] public static explicit operator uint4(Long2 a) => new uint4((uint)a.X, (uint)a.Y, 0, 0);
        }
        public partial struct Long3
        {
            [IN(LINE)] public static implicit operator float3(Long3 a) => new float3(a.X, a.Y, a.Z);
            [IN(LINE)] public static implicit operator float4(Long3 a) => new float4(a.X, a.Y, a.Z, 0);
            [IN(LINE)] public static implicit operator double3(Long3 a) => new float3(a.X, a.Y, a.Z);
            [IN(LINE)] public static implicit operator double4(Long3 a) => new float4(a.X, a.Y, a.Z, 0);
            [IN(LINE)] public static explicit operator int3(Long3 a) => new int3((int)a.X, (int)a.Y, (int)a.Z);
            [IN(LINE)] public static explicit operator int4(Long3 a) => new int4((int)a.X, (int)a.Y, (int)a.Z, 0);
            [IN(LINE)] public static explicit operator uint3(Long3 a) => new uint3((uint)a.X, (uint)a.Y, (uint)a.Z);
            [IN(LINE)] public static explicit operator uint4(Long3 a) => new uint4((uint)a.X, (uint)a.Y, (uint)a.Z, 0);
        }
        public partial struct Long4
        {
            [IN(LINE)] public static implicit operator float4(Long4 a) => new float4(a.X, a.Y, a.Z, a.W);
            [IN(LINE)] public static implicit operator double4(Long4 a) => new double4(a.X, a.Y, a.Z, a.W);
            [IN(LINE)] public static explicit operator int4(Long4 a) => new int4((int)a.X, (int)a.Y, (int)a.Z, (int)a.W);
            [IN(LINE)] public static explicit operator uint4(Long4 a) => new uint4((uint)a.X, (uint)a.Y, (uint)a.Z, (uint)a.W);
        }

        public partial struct ULong2
        {
            [IN(LINE)] public static implicit operator float2(ULong2 a) => new float2(a.X, a.Y);
            [IN(LINE)] public static implicit operator float3(ULong2 a) => new float3(a.X, a.Y, 0);
            [IN(LINE)] public static implicit operator float4(ULong2 a) => new float4(a.X, a.Y, 0, 0);
            [IN(LINE)] public static implicit operator double2(ULong2 a) => new double2(a.X, a.Y);
            [IN(LINE)] public static implicit operator double3(ULong2 a) => new double3(a.X, a.Y, 0);
            [IN(LINE)] public static implicit operator double4(ULong2 a) => new double4(a.X, a.Y, 0, 0);
            [IN(LINE)] public static explicit operator int2(ULong2 a) => new int2((int)a.X, (int)a.Y);
            [IN(LINE)] public static explicit operator int3(ULong2 a) => new int3((int)a.X, (int)a.Y, 0);
            [IN(LINE)] public static explicit operator int4(ULong2 a) => new int4((int)a.X, (int)a.Y, 0, 0);
            [IN(LINE)] public static explicit operator uint2(ULong2 a) => new uint2((uint)a.X, (uint)a.Y);
            [IN(LINE)] public static explicit operator uint3(ULong2 a) => new uint3((uint)a.X, (uint)a.Y, 0);
            [IN(LINE)] public static explicit operator uint4(ULong2 a) => new uint4((uint)a.X, (uint)a.Y, 0, 0);
        }
        public partial struct ULong3
        {
            [IN(LINE)] public static implicit operator float3(ULong3 a) => new float3(a.X, a.Y, a.Z);
            [IN(LINE)] public static implicit operator float4(ULong3 a) => new float4(a.X, a.Y, a.Z, 0);
            [IN(LINE)] public static implicit operator double3(ULong3 a) => new double3(a.X, a.Y, a.Z);
            [IN(LINE)] public static implicit operator double4(ULong3 a) => new double4(a.X, a.Y, a.Z, 0);
            [IN(LINE)] public static explicit operator int3(ULong3 a) => new int3((int)a.X, (int)a.Y, (int)a.Z);
            [IN(LINE)] public static explicit operator int4(ULong3 a) => new int4((int)a.X, (int)a.Y, (int)a.Z, 0);
            [IN(LINE)] public static explicit operator uint3(ULong3 a) => new uint3((uint)a.X, (uint)a.Y, (uint)a.Z);
            [IN(LINE)] public static explicit operator uint4(ULong3 a) => new uint4((uint)a.X, (uint)a.Y, (uint)a.Z, 0);
        }
        public partial struct ULong4
        {
            [IN(LINE)] public static implicit operator float4(ULong4 a) => new float4(a.X, a.Y, a.Z, a.W);
            [IN(LINE)] public static implicit operator double4(ULong4 a) => new double4(a.X, a.Y, a.Z, a.W);
            [IN(LINE)] public static explicit operator int4(ULong4 a) => new int4((int)a.X, (int)a.Y, (int)a.Z, (int)a.W);
            [IN(LINE)] public static explicit operator uint4(ULong4 a) => new uint4((uint)a.X, (uint)a.Y, (uint)a.Z, (uint)a.W);
        }
        #endregion
    }
}
#endif