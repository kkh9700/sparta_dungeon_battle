using System;
using System.Collections.Generic;

namespace SpartaDungeonBattle
{
    class Program
    {
        static void Main(string[] args)
        {

            List<CharacterData> list = GameManager.Instance().GetFileNameList();

            foreach (CharacterData cd in list)
            {
                Console.WriteLine(cd.ToString());
            }

            Character player = null;
            GameManager.Instance().LoadData(1, out player);
        }
    }
}
