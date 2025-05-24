using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetShooter : MonoBehaviour
{
    public static Action OnTargetMissed;
    private Animator animator;
    [SerializeField] Camera cam;
    private void Start()
    {
        animator = GetComponent<Animator>(); 
    }



    void Update()
    {
        if (Timer.GameEnded)
            return;

        if (Input.GetMouseButtonDown(0))
        {


            Ray ray = cam.ViewportPointToRay(new Vector3(0.5f, 0.5f));
            if (Physics.Raycast(ray, out RaycastHit hit))
            {
                Target target = hit.collider.gameObject.GetComponent<Target>();

                if (target != null)
                {
                    target.Hit();
                }
                else
                {
                    OnTargetMissed?.Invoke();
                }
            }
            else
            {
                OnTargetMissed?.Invoke();
            }
            if (Input.GetMouseButtonDown(0))
            {
                {
                    animator.Play("Shoot", -1, 0f); 
                }
            }
        }
    }
}