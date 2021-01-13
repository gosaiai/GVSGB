using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GVSGB
{
    public class DrawPentagram : Singleton<DrawPentagram>
    {
        #region private fields
        LineRenderer drawingLine;
        MingameBase miniGame;
        PentagramPoint[] ConnectedToPoints;
        #endregion
        #region public fields
        public PentagramPoint[] AllPoints;
        public PentagramPoint[] PointsToConnect;
        public GameObject ImageBeingDrawn;
        public PentagramPoint startPoint;
        public PentagramPoint endPoint;
        public Dictionary<PentagramPoint, PentagramPoint> ConnectionPattern;
       

        #endregion
        #region properties
        public bool MouseHeldDown
        {
            get => mouseHeldDown;


            set
            {
                if (value == false)
                {
                    //delete existing line
                }

                mouseHeldDown = value;
            }


        }

        bool mouseHeldDown;
        #endregion

        #region game logic methods

        void RandomlyConnectPoints()
        {
            int randomConnectNumber = UnityEngine.Random.Range(0, 3);
            for (int i = 0; i < randomConnectNumber; i++)
            {
                int val = (Random.Range(0, 6));
                if (ConnectionPattern.ContainsKey(AllPoints[val]) && AllPoints[val].ConnectedTo_Next == false)
                {
                    PentagramPoint.ConnectPoints(ImageBeingDrawn, AllPoints[val], ConnectionPattern[AllPoints[val]], transform);

                    AllPoints[val].ConnectedTo_Next = true;

                }

            }
        }
        bool Is_Allconnected()
        {
            bool ret = true;
            foreach (PentagramPoint p in AllPoints)
            {
                ret &= p.ConnectedTo_Next;
            }
            return ret;
        }
        void SetUp()
        {
           
            ConnectionPattern = new Dictionary<PentagramPoint, PentagramPoint>();
            drawingLine = Instantiate(ImageBeingDrawn, transform).GetComponent<LineRenderer>();

            for (int i = 0, j = 2; i < 6; i++, j++)
            {
                if (j == 6)
                {
                    j = 0;
                }

                AllPoints[i].gameObject.SetActive(true);
                ConnectionPattern.Add(AllPoints[i], AllPoints[j]);

                RandomlyConnectPoints();
            }
        }
        #endregion

        public void startGame()
        {
            if (miniGame.MyState != MiniGameState.INPROGRESS)
            {
                miniGame.MyState = MiniGameState.INPROGRESS;
                SetUp();
            }
        }
        #region unity methods
        private void Start()
        {
           
            miniGame = new MingameBase();
            miniGame.MyState=MiniGameState.NOTSTARTED;

        }
        void Update()
        {
           
            if (miniGame.MyState == MiniGameState.INPROGRESS)
            {
                if (Input.GetMouseButtonUp(0))
                {
                    MouseHeldDown = false;
                    drawingLine.SetPosition(0, Vector3.zero);
                    drawingLine.SetPosition(1, Vector3.zero);
                    drawingLine.enabled = false;
                }
                if (mouseHeldDown == true && Input.GetMouseButton(0))
                {
                    drawingLine.enabled = true;
                    drawingLine.SetPosition(0, startPoint.transform.position);
                    Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                    mousePos.z = 0;
                    drawingLine.SetPosition(1, mousePos);
                }
                if (!mouseHeldDown)
                {
                    if (startPoint != endPoint && startPoint != null && endPoint != null)
                    {
                        if (startPoint.ConnectedTo_Next == false)
                        {

                            if (ConnectionPattern[startPoint] == endPoint)
                            {
                                PentagramPoint.ConnectPoints(ImageBeingDrawn, startPoint, endPoint, transform);
                                startPoint.ConnectedTo_Next = true;
                                if (Is_Allconnected())
                                {
                                    miniGame.MyState = MiniGameState.FINISHED;
                                    Debug.Log("horha");
                                }
                            }
                        }
                        startPoint = null;
                        endPoint = null;
                    }
                }
            }

        }
        #endregion
    }
}