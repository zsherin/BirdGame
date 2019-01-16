using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

namespace BirdGame
{
    public class BirdController : MonoBehaviour
    {

        public Animator myAnimator;
        public CinemachineDollyCart cart;

        public enum BirdState
        {
            Landing,
            TakingOff,
            Flying,
            Idle
        }
        public BirdState myState = BirdState.Idle;

        float idleTimer = 0;

        // Use this for initialization
        void Start()
        {
            cart.m_Speed = 0;
            myState = BirdState.Idle;
        }

        public void OnTriggerEnter(Collider other)
        {
            if (myState == BirdState.Flying)
            {
                myAnimator.SetTrigger("Land");
                myState = BirdState.Landing;
            }
        }

        public void OnTriggerExit(Collider other)
        {
            if (myState == BirdState.TakingOff)
            {
                myState = BirdState.Flying;
            }
        }
        // Update is called once per frame
        void Update()
        {

            if (myState == BirdState.Landing && (cart.m_Position > .99f || cart.m_Position < .01f))
            {
                myState = BirdState.Idle;
                cart.m_Speed = 0;
                cart.m_Position = 0;
                idleTimer = 0;
            }
            if (myState == BirdState.Idle && idleTimer > 10)
            {
                idleTimer = 0;
                myState = BirdState.TakingOff;
                myAnimator.SetTrigger("Fly");
                cart.m_Speed = .1f;
            }
            idleTimer += Time.deltaTime;
        }
    }
}