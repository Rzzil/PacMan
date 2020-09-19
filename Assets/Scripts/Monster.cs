using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Monster : MonoBehaviour
{
    private Animator animator;

    void Awake()
    {
        animator = GetComponent<Animator>();
    }

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(ChangeState());
    }

    // Update is called once per frame
    void Update()
    {

    }
    private IEnumerator ChangeState()
    {
        int i = 1;
        while (true)
        {
            animator.SetInteger("state", i);
            i++;
            if (i >= 7)
                i = 0;
            yield return new WaitForSeconds(3);
        }
    }
}
