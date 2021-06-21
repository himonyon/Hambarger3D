using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    Animator _anim;
    [SerializeField] float _speed = 2.0f; 

    // Start is called before the first frame update
    void Start()
    {
        _anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
       
    }


    public void Move(bool isMove)
    {
        if (isMove)
        {
            _anim.SetBool("Run", true);
            transform.position += transform.forward * Time.deltaTime * _speed;
        }
        else
        {
            _anim.SetBool("Run", false);
        }
    }

    public void LookForward(float rotate_x, float rotate_z)
    {
        Vector3 direction = new Vector3(rotate_x, 0, rotate_z);
        transform.rotation = Quaternion.LookRotation(direction);
    }

    public int CheckObj()
    {
        RaycastHit hit;
        if (Physics.Raycast(transform.position + new Vector3(0, 0.5f, 0), transform.forward, out hit, 1.5f))
        {
            if (hit.collider.gameObject.CompareTag("teppan"))
            {
                return (int)MACHINE.TEPPAN;
            }else if (hit.collider.gameObject.CompareTag("setter"))
            {
                return (int)MACHINE.SETTER;
            }
            else if (hit.collider.gameObject.CompareTag("refrigerator"))
            {
                return (int)MACHINE.REFRIGERATOR;
            }
        }

        return (int)MACHINE.MAX;

    }
}
