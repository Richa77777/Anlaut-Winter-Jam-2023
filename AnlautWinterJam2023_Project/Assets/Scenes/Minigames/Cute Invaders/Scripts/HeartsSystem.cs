using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CuteInvaders
{
    public class HeartsSystem : MonoBehaviour
    {
        [SerializeField] private GameObject[] _hearts = new GameObject[3];

        private LoseWin _loseWin;

        private void Start()
        {
            _loseWin = FindObjectOfType<LoseWin>();
        }
        public void CheckHearts(int heartsValue)
        {
            switch (heartsValue)
            {
                case 3:
                    for (int i = 0; i < 3; i++)
                    {
                        _hearts[i].SetActive(true);
                    }
                    break;

                case 2:
                    _hearts[0].SetActive(false);
                    break;

                case 1:
                    _hearts[0].SetActive(false);
                    _hearts[1].SetActive(false);
                    break;

                case 0:
                    for (int i = 0; i < 3; i++)
                    {
                        _hearts[i].SetActive(false);
                    }

                    _loseWin.Lose();
                    break;



            }
        }
    }
}