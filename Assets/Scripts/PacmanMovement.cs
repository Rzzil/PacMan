using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PacmanMovement : MonoBehaviour
{
    private Animator animator;

    [SerializeField]
    private List<int> MoveList;

    void Awake()
    {
        animator = GetComponent<Animator>();
    }

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(Movement());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void Move(int state)
    {
        animator.SetInteger("state", state);
        transform.Translate(Vector2.right * 0.55f);
    }

    private IEnumerator Movement()
    {
        int i = 0;
        while (true)
        {
            Move(MoveList[i]);
            i++;
            if (i >= MoveList.Count)
                i = 0;
            yield return new WaitForSeconds(0.4f);
        }
    }
}
