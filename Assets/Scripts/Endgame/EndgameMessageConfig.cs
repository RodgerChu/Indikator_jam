using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game.Configs
{
    [CreateAssetMenu(fileName = "EndgameMessageConfig", menuName = "SO/EndgameMessageConfig", order = 2)]
    public class EndgameMessageConfig : ScriptableObject
    {
        public string OnWinMessage = "������. \n � �������������� ��� ���� ����!";
        public string OnLoseMessage = "���������. \n � ���, ���� ��������� ��� ����� �������!";
    }
}
