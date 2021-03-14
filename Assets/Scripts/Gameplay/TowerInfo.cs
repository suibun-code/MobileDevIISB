using UnityEngine;


namespace TowerInformation
{
    public struct TowerResourceRequirement
    {
        public int ID;
        public int Brick;
        public int Gold;
        public int Diamond;
    }
    
    public enum TowerToBuild
    {
        Sniper = 0,
        Canon = 1
    }



    // all the tower info will be stored in here
    public class TowerInfo : MonoBehaviour
    {

        public TowerResourceRequirement Sniper = new TowerResourceRequirement();
        public TowerResourceRequirement Canon = new TowerResourceRequirement();



        void Start()
        {
            Sniper.ID = 0;
            Sniper.Brick = 9;
            Sniper.Gold = 9;
            Sniper.Diamond = 9;

        }


    }

}
