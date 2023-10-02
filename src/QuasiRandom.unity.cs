#if UNITY_5_3_OR_NEWER
using UnityEngine;

namespace DCFApixels
{
    public partial struct QuasiRandom 
    {
        public Vector2 NextUnityVector2()
        {
            return new Vector2(
                GetX2_F(++_state), 
                GetY2_F(_state));
        }
        public Vector3 NextUnityVector3()
        {
            return new Vector3(
                GetX3_F(++_state), 
                GetY3_F(_state), 
                GetZ3_F(_state));
        }
        public Vector4 NextUnityVector4()
        {
            return new Vector4(
                GetX4_F(++_state), 
                GetY4_F(_state), 
                GetZ4_F(_state), 
                GetW4_F(_state));
        }

        public Vector2Int NextUnityVector2Int()
        {
            return new Vector2Int(
                (int)GetX2_Q32(++_state), 
                (int)GetY2_Q32(_state));
        }
        public Vector3Int NextUnityVector3Int()
        {
            return new Vector3Int(
                (int)GetX3_Q32(++_state), 
                (int)GetY3_Q32(_state), 
                (int)GetZ3_Q32(_state));
        }

        public Vector2Int NextUnityVector2Int(int max)
        {
            return new Vector2Int(
                Compresse32(GetX2_Q32(++_state), max),
                Compresse32(GetY2_Q32(_state), max));
        }
        public Vector3Int NextUnityVector3Int(int max)
        {
            return new Vector3Int(
                Compresse32(GetX3_Q32(++_state), max),
                Compresse32(GetY3_Q32(_state), max),
                Compresse32(GetZ3_Q32(_state), max));
        }

        public Vector2Int NextUnityVector2Int(int min, int max)
        {
            ulong range = (ulong)(max - min);
            return new Vector2Int(
                Compresse32(GetX2_Q32(++_state), min, range),
                Compresse32(GetY2_Q32(_state), min, range));
        }
        public Vector3Int NextUnityVector3Int(int min, int max)
        {
            ulong range = (ulong)(max - min);
            return new Vector3Int(
                Compresse32(GetX3_Q32(++_state), min, range),
                Compresse32(GetY3_Q32(_state), min, range),
                Compresse32(GetZ3_Q32(_state), min, range));
        }
    }
}
#endif