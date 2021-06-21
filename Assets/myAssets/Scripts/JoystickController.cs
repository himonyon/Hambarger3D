using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JoystickController : MonoBehaviour
{
    const float MAX_RADIUS = 70;

    [SerializeField] PlayerController _player;

    Vector3 _startPos; //ジョイスティックの初期ワールド座標
    Vector3 _mousePos; //マウスの座標
    Vector3 _diff; //スタート位置からのベクトル座標
    float _radius = 0; //スタート位置からマウス座標までの半径

    bool _isDrag = false;

    // Start is called before the first frame update
    void Start()
    {
        _startPos = transform.position;
    }

    // Update is called once per frame
    void Update()
    {

        //ジョイスティックの方向を所得してプレイヤーの向きに代入する
        if (Input.GetMouseButton(0))
        {
            _mousePos = Input.mousePosition;
            _diff = _mousePos - _startPos;
            _radius = Mathf.Pow((Mathf.Pow(_diff.x, 2) + Mathf.Pow(_diff.y, 2)), 1.0f / 2.0f);

            if(_radius < MAX_RADIUS)
            {
                _isDrag = true;
            }

            if (_isDrag)
            {
                SetMove();
                SetStickPosition();
            }
        }

        if (Input.GetMouseButtonUp(0))
        {
            _isDrag = false;
            transform.position = _startPos;
            _player.Move(false);
        }
    }


    private void SetStickPosition()
    {
        if(_radius < MAX_RADIUS)
        {
            transform.position = _mousePos;
        }
        else
        {
            //三角比で半径を出す
            float x = _diff.x * MAX_RADIUS / _radius;
            float y = _diff.y * MAX_RADIUS / _radius;
            transform.localPosition = new Vector3(x, y, 0);
        }
    }

    private void SetMove()
    {
        _player.LookForward(_diff.x, _diff.y);

        if (_radius > 20)
        {
            _player.Move(true);
        }
        else
        {
            _player.Move(false);
        }
    }
}
