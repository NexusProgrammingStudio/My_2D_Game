using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    Animator m_Animator;
    // Start is called before the first frame update
    void Start()
    {
        m_Animator = gameObject.GetComponent<Animator>();       
    }

    // Update is called once per frame
    void Update()
    {
        float speed=Input.GetAxisRaw("Horizontal");
        float jump = Input.GetAxisRaw("Vertical");
        m_Animator.SetFloat("Speed",Mathf.Abs(speed));
        Vector3 scale = transform.localScale;
        Vector3 pos = transform.localPosition;
        if(Input.GetKey(KeyCode.LeftArrow))
        {
            scale.x = -1f * Mathf.Abs(scale.x);
            pos.x = -0.1f + pos.x;
            // pos.y = 0.1f - pos.y;
            pos.z = 0;
        }
        else if(Input.GetKey(KeyCode.RightArrow))
        {
            scale.x = 1f * Mathf.Abs(scale.x);
            pos.x = 0.1f + pos.x;
            // pos.y = 0.1f + pos.y; 
            pos.z = 0;
              
        }
        if(Input.GetKey(KeyCode.UpArrow))
        {
            m_Animator.SetTrigger("Jump_trigger");

            m_Animator.ResetTrigger("Crouch_Trigger");
        }
        else if(Input.GetKey(KeyCode.DownArrow))
        {
            m_Animator.SetTrigger("Crouch_Trigger");

            m_Animator.ResetTrigger("Jump_trigger");
        }
        transform.localScale = scale;
        transform.localPosition = pos;
    }
}
