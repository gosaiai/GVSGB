using GVSGB;
using UnityEngine;
using UnityEngine.UI;
using Photon.Pun;

namespace GVSGB
{
    [SerializeField]
    public class MiniGameManager : MonoBehaviourPun
    {
        public static MiniGameManager instance;

        [SerializeField]
        public Slider Spookmeter;


        private void Awake()
        {
            if (instance == null)
                instance = this;
            else
            {
                Destroy(gameObject);
            }       
        }


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
