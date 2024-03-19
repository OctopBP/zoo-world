namespace ZooWorld.Core
{
    public interface IRnd
    {
        int RandomRange(int from, int to);
        float RandomRange(float from, float to);
        bool RandomBool();
    }
}