using UnityEngine;

namespace TowerInformation
{
    public struct TowerResourceRequirement
    {
        public int Brick;
        public int Gold;
        public int Diamond;
    }
    
    public enum TowerToBuild
    {
        Sniper = 0,
        Canon = 1
    }
}
