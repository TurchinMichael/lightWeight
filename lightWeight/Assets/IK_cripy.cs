using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IK_cripy : MonoBehaviour
{
    Transform targetPos;
    float lookIkWeigt,
                eyesWeight,
                clampWeight,
                bodyWeight,
                headWeight;
    Animator animator;
    bool creepy;

    // Use this for initialization
    void Start()
    {
        animator = GetComponent<Animator>();
        targetPos = Camera.main.transform;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Z))
        {
            if (!creepy)
            {
                Debug.Log("sdf");
                creepy = true;
                lookIkWeigt = 1f;
                eyesWeight = 1f;
                clampWeight = 1f;
                bodyWeight = 1f;
                headWeight = 1f;
                Debug.Log(headWeight);
            }
            else
            {
                creepy = false;
                lookIkWeigt = 0f;
                eyesWeight = 0f;
                clampWeight = 0f;
                bodyWeight = 0f;
                headWeight = 0f;
            }
        }

        if (Input.GetKeyDown(KeyCode.X) && creepy)
        {
            foreach (Rigidbody rig in GetComponentsInChildren<Rigidbody>())
            {
                rig.AddForce(0, 0, 0, ForceMode.Force);
            }
            animator.enabled = !animator.enabled;
            transform.position = new Vector3(1.8f, 1f, -1f);
        }
    }
    void OnAnimatorIK()
    {
        animator.SetLookAtWeight(lookIkWeigt, bodyWeight, headWeight, eyesWeight, clampWeight);
        animator.SetLookAtPosition(targetPos.position);
    }
}
