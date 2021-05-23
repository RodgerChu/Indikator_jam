using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game.Configs
{
    [CreateAssetMenu(fileName = "EndgameMessageConfig", menuName = "SO/EndgameMessageConfig", order = 2)]
    public class EndgameMessageConfig : ScriptableObject
    {
        public string OnWinMessage = "ПОБЕДА. \n У справедливости ещё есть шанс!";
        public string OnLoseMessage = "ПОРАЖЕНИЕ. \n О нет, этот продажный суд снова победил!";
    }
}
