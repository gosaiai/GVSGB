using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace GVSGB
{
    public class PentagramPoint : MonoBehaviour
    {

        #region private fields
        bool IS_allConnectionDone;

        #endregion

        #region public fields
        public bool ConnectedTo_Next=false;
       

        #endregion
        #region game logic methods

        public static void ConnectPoints(GameObject line, PentagramPoint A, PentagramPoint B, Transform parent)
        {
            //Strech(_sprite, A.transform.position, B.transform.position,parent,false);
            DrawLine(line, A.transform.position, B.transform.position, parent);
        }
        public static void DrawLine(GameObject obj, Vector3 _initialPosition, Vector3 _finalPosition, Transform parent)
        {
            LineRenderer temp = Instantiate(obj, parent).GetComponent<LineRenderer>();

            temp.SetPosition(0, _initialPosition);
            temp.SetPosition(1, _finalPosition);

        }

        //public static  void Strech(GameObject obj, Vector3 _initialPosition, Vector3 _finalPosition,Transform parent, bool _mirrorZ)
        //{
        // GameObject _sprite=   Instantiate(obj,parent);
        //    Vector3 centerPos = (_initialPosition + _finalPosition) / 2f;
        //    _sprite.transform.position = centerPos;
        //    Vector3 direction = _finalPosition - _initialPosition;
        //    direction = Vector3.Normalize(direction);
        //    _sprite.transform.right = direction;
        //    if (_mirrorZ) _sprite.transform.right *= -1f;
        //    Vector3 scale = new Vector3(1, 1, 1);
        //    scale.x = Vector3.Distance(_initialPosition, _finalPosition);
        //    float  factor= _sprite.GetComponent<Sprite>().
        //    _sprite.transform.localScale = scale;
        //}
        #endregion



        #region unity methods

        void Start()
        {

        }

        void Update()
        {

        }

        void OnMouseDown()
        {
            if (DrawPentagram.Instance.MouseHeldDown == false)
            {
                DrawPentagram.Instance.startPoint = this;
                DrawPentagram.Instance.MouseHeldDown = true;
            }

        }
        void OnMouseOver()
        {
            if (DrawPentagram.Instance.MouseHeldDown == true && Input.GetMouseButtonUp(0))
            {
                DrawPentagram.Instance.endPoint = this;
                DrawPentagram.Instance.MouseHeldDown = false;

            }
        }
        #endregion
    }
}