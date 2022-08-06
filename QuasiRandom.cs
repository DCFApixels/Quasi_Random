using System;
using UnityEngine;

namespace DCFApixels
{
    public abstract class QuasiRandomBase
    {
        protected float _seed = 0f;
        protected int _iteration = 0;

        [Serializable]
        public struct State
        {
            internal float _seed;
            internal int _iteration;
        }

        public State GetState() => new State() { _seed = _seed, _iteration = _iteration, };
        public void SetState(State state)
        {
            _seed = state._seed;
            _iteration = state._iteration;
        }

        protected QuasiRandomBase()
        {
            _seed = DateTime.Now.Ticks / long.MaxValue;
        }
        protected QuasiRandomBase(int seed)
        {
            _seed = Mathf.Abs(seed / int.MaxValue);
        }
        protected QuasiRandomBase(float seed)
        {
            _seed = Mathf.Abs(seed / float.MaxValue);
        }
        protected QuasiRandomBase(State state)
        {
            _seed = state._seed;
            _iteration = state._iteration;
        }
    }

    public class Quasi1DRandom : QuasiRandomBase
    {
        public static readonly Quasi1DRandom global = new Quasi1DRandom();

        private static float _g = 1.6180339887498948482f;
        private static float _a1 = 1f / _g;

        public Quasi1DRandom() : base() { }
        public Quasi1DRandom(int seed) : base(seed) { }
        public Quasi1DRandom(float seed) : base(seed) { }
        public Quasi1DRandom(State state) : base(state) { }

        public float Next()
        {
            _iteration++;
            return MathValue(_seed, _iteration);
        }

        private float MathValue(float seed, long n)
        {
            float result = (seed + _a1 * n);
            result -= Mathf.Floor(result);
            if (result < 0f) result += 1f;
            return result;
        }
    }

    public class Quasi2DRandom : QuasiRandomBase
    {
        public static readonly Quasi2DRandom global = new Quasi2DRandom();

        private static float _g = 1.32471795724474602596f;
        private static float _a1 = 1f / _g;
        private static float _a2 = 1f / (_g * _g);

        public Quasi2DRandom() : base() { }
        public Quasi2DRandom(int seed) : base(seed) { }
        public Quasi2DRandom(float seed) : base(seed) { }
        public Quasi2DRandom(State state) : base(state) { }

        public Vector2 NextVector()
        {
            _iteration++;
            return MathValue(_seed, _iteration);
        }

        private Vector2 MathValue(float seed, long n)
        {
            Vector2 result = new Vector2(
                seed + _a1 * n,
                seed + _a2 * n
                );
            result.x = result.x - Mathf.Floor(result.x);
            result.y = result.y - Mathf.Floor(result.y);
            return result;
        }
    }

    public class Quasi3DRandom : QuasiRandomBase
    {
        public static readonly Quasi3DRandom global = new Quasi3DRandom();

        private static float _g = 1.22074408460575947536f;
        private static float _a1 = 1f / _g;
        private static float _a2 = 1f / (_g * _g);
        private static float _a3 = 1f / (_g * _g * _g);

        public Quasi3DRandom() : base() { }
        public Quasi3DRandom(int seed) : base(seed) { }
        public Quasi3DRandom(float seed) : base(seed) { }
        public Quasi3DRandom(State state) : base(state) { }

        public Vector3 NextVector()
        {
            _iteration++;
            return MathValue(_seed, _iteration);
        }

        private Vector3 MathValue(float seed, long n)
        {
            Vector3 result = new Vector3(
                seed + _a1 * n,
                seed + _a2 * n,
                seed + _a3 * n
                );
            result.x = result.x - Mathf.Floor(result.x);
            result.y = result.y - Mathf.Floor(result.y);
            result.z = result.z - Mathf.Floor(result.z);
            return result;
        }
    }
}