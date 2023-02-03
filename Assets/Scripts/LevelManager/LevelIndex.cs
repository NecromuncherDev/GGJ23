namespace GGJ.Core
{
    public struct LevelIndex
    {
        public int LayerIndex;
        public int NodeIndex;

        public static LevelIndex Invalid = new LevelIndex { LayerIndex = -1, NodeIndex = -1 };

        public static bool operator ==(LevelIndex a, LevelIndex b)
        {
            return a.LayerIndex == b.LayerIndex && a.NodeIndex == b.NodeIndex;
        }

        public static bool operator !=(LevelIndex a, LevelIndex b)
        {
            return !(a == b);
        }

        public override bool Equals(object obj)
        {
            if (obj is LevelIndex)
            {
                return this == (LevelIndex)obj;
            }
            return false;
        }

        public override int GetHashCode()
        {
            return LayerIndex ^ NodeIndex;
        }

        public override string ToString()
        {
            return string.Format("Layer: {0}, Node: {1}", LayerIndex, NodeIndex);
        }
    }
}