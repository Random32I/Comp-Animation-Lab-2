using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PathController : MonoBehaviour
{
    [SerializeField]
    public PathManager pathManager;

    public Animator animator;
    bool isWalking;

    List<Waypoint> thePath;
    Waypoint target;

    public float MoveSpeed;
    public float RotateSpeed;

    // Start is called before the first frame update
    void Start()
    {
        thePath = pathManager.GetPath();
        if (thePath != null && thePath.Count > 0)
        {
            target = thePath[0];
        }
    }

    void rotateTowrdsTarget()
    {
        float stepSize = RotateSpeed * Time.deltaTime;

        Vector3 targetDir = target.pos - transform.position;
        Vector3 newDir = Vector3.RotateTowards(transform.forward, targetDir, stepSize, 0.0f);
        transform.rotation = Quaternion.LookRotation(newDir);
    }
    void MoveForward()
    {
        float stepSize = Time.deltaTime * MoveSpeed;
        float distanceToTarget = Vector3.Distance(transform.position, target.pos);
        if (distanceToTarget < stepSize)
        {
            return;
        }
        Vector3 moveDir = Vector3.forward;
        transform.Translate(moveDir * stepSize);
    }


    // Update is called once per frame
    void Update()
    {
        if (Input.anyKeyDown)
        {
            isWalking = !isWalking;
            animator.SetBool("isWalking", isWalking);
        }
        if (isWalking)
        {
            rotateTowrdsTarget();
            MoveForward();
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        target = pathManager.GetNextTarget();
    }
}
