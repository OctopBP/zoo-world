namespace ZooWorld.Core
{
    public class Random : IRnd
    {
        private readonly System.Random _rnd = new System.Random(0);

        public int RandomRange(int from, int to) => _rnd.Next(from, to);
        public float RandomRange(float from, float to) => (float) (from + _rnd.NextDouble() * (to - from));
        public bool RandomBool() =>_rnd.NextDouble() > 0.5f;
    }
}