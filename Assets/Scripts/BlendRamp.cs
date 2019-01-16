using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.PostProcessing;

namespace BirdGame
{
    public class BlendRamp : MonoBehaviour
    {

        private PostProcessVolume myVolume;
        private bool rampUp = false;
        public float speed = 5.0f;

        private void Awake()
        {
            myVolume = GetComponent<PostProcessVolume>();
        }

        public void RampUp()
        {
            rampUp = true;
        }

        public void RampDown()
        {
            rampUp = false;
        }

        // Update is called once per frame
        void Update()
        {
            if (myVolume.weight < 1.0f && rampUp)
            {
                myVolume.weight += Time.deltaTime * speed;
            }

            else if (myVolume.weight > 0.0f && !rampUp)
            {
                myVolume.weight -= Time.deltaTime * speed;
            }
        }
    }
}
