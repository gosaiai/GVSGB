using GVSGB;
using UnityEngine;
using UnityEngine.UI;
using Photon.Pun;

namespace GVSGB
{
    [SerializeField]
    public class MiniGameManager : MonoBehaviourPun
    {

        [SerializeField]
        public Slider Spookmeter;


        void Start()
        {

            Spookmeter.maxValue = 100f;
            Spookmeter.minValue = 0f;

        }

        public void IncreaseSpooks()
        {

            Spookmeter.value += 10;
        }
    }
}
