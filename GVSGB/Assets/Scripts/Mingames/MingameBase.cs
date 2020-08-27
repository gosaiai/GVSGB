
using System;

namespace GVSGB
{
    [Serializable]
    public class MingameBase
    {
        
        MiniGameState myState;
        public MiniGameState MyState
        {
            get
            {
                return myState;
            }
            set
            {
                myState = value;
                //perform a switch statement here
            }
        }

        public bool IS_Complete()
        {
            return myState == MiniGameState.FINISHED;
        }
        public bool IS_Started()
        {
            return myState == MiniGameState.INPROGRESS;
        }
        public bool IS_Failed()
        {
            return myState == MiniGameState.FAILED;
        }
        public MingameBase()
        {
            myState = MiniGameState.NOTSTARTED;

        }
    }
}