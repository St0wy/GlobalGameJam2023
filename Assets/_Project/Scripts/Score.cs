using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GlobalGameJam
{
    public class Score : MonoBehaviour
    {
        public int PlayerScore { get; private set; }

        public void IncrementScore(int value)
        {
            PlayerScore += value;
        }
    }
}
