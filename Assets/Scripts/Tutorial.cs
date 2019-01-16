using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace BirdGame
{
    public class Tutorial : MonoBehaviour
    {

        public GameObject tutorialText;
        public Image flashImage;
        private Color subtractColor = new Color(0, 0, 0, 1);

        public void FlashImage()
        {
            Invoke("SetImageInternal", .1f);
        }
        public void SetImageInternal()
        {
            flashImage.color = Color.white;
        }

        // Update is called once per frame
        void Update()
        {
            if (Input.GetKeyDown(KeyCode.G))
            {
                tutorialText.SetActive(!tutorialText.activeSelf);
            }
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                Application.Quit();
            }
            if (flashImage.color.a > 0)
            {
                flashImage.color = flashImage.color - subtractColor * Time.deltaTime;
            }
        }
    }
}
