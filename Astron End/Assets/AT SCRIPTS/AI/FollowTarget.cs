using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;


namespace AstroEnd.Core.AI
{
    [RequireComponent(typeof(NavMeshAgent))]
    public class FollowTarget : MonoBehaviour
    {
        public AreaConstraint areaConstraint;
        NavMeshAgent navMesh;
        public GameObject targetToMoveTo;
        Vector3 startingPoint;

        public enum State
        {
            Idle,
            FollowingTarget,
            MoveToBase
        }
        public State state;

        void Reset()
        {
            navMesh = navMesh ?? GetComponent<NavMeshAgent>();
        }
        void Awake()
        {
            state = State.FollowingTarget;
            navMesh = navMesh ?? GetComponent<NavMeshAgent>();
            startingPoint = transform.position;
        }

        void Start()
        {
            StartCoroutine(FSM());
        }

        IEnumerator FSM()
        {
            while (true)
            {
                Debug.Log(state.ToString());
                yield return StartCoroutine(state.ToString());
            }

        }

        IEnumerator Idle()
        {
            yield return null;
            if (AuthorizedToMoveFurther() && AuthorizedToFollow())
                state = State.FollowingTarget;
        }

        IEnumerator FollowingTarget()
        {
            yield return null;
            if (AuthorizedToMoveFurther())
            {
                MoveTo(targetToMoveTo);
                yield return new WaitForSeconds(.5f);
            }
            else
            {
                state = State.MoveToBase;
            }


        }

        IEnumerator MoveToBase()
        {
            yield return null;
            if (Vector3.Distance(startingPoint, transform.position) <= 2)
                state = State.Idle;

            MoveTo(startingPoint);

        }
        void MoveTo(GameObject destination)
        {
            navMesh.destination = destination.transform.position;
        }
        void MoveTo(Vector3 destination)
        {
            navMesh.destination = destination;
        }

        bool AuthorizedToMoveFurther()
        {
            bool result;
            if (areaConstraint == null || Vector3.Distance(transform.position, areaConstraint.transform.position) <= areaConstraint.areaOffset)
            {
                result = true;
            }
            else
            {
                result = false;
            }
            return result;
        }

        bool AuthorizedToFollow()
        {
            bool result;
            if (areaConstraint == null || Vector3.Distance(transform.position,targetToMoveTo.transform.position) <= areaConstraint.areaOffset)
            {
                result = true;
            }
            else
            {
                result = false;
            }
            return result;
        }
    }

}