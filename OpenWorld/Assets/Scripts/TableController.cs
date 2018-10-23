//-----------------------------------------------------------------------
// <copyright file="HelloARController.cs" company="Google">
//
// Copyright 2017 Google Inc. All Rights Reserved.
//
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
//
// http://www.apache.org/licenses/LICENSE-2.0
//
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// See the License for the specific language governing permissions and
// limitations under the License.
//
// </copyright>
//-----------------------------------------------------------------------

namespace GoogleARCore.Examples.HelloAR
{
    using System.Collections.Generic;
    using GoogleARCore;
    using GoogleARCore.Examples.Common;
    using UnityEngine;
    using UnityEngine.EventSystems;
    using UnityEngine.SceneManagement;

#if UNITY_EDITOR
    // Set up touch input propagation while using Instant Preview in the editor.
    using Input = InstantPreviewInput;
#endif

    /// <summary>
    /// Controls the HelloAR example.
    /// </summary>
    public class TableController : MonoBehaviour
    {
        /// <summary>
        /// The first-person camera being used to render the passthrough camera image (i.e. AR background).
        /// </summary>
        public Camera FirstPersonCamera;

        /// <summary>
        /// A model to place when a raycast from a user touch hits a plane.
        /// </summary>
        public GameObject FencePrefab;

        public GameObject LoadingScreen;

        /// <summary>
        /// The rotation in degrees need to apply to model when the Andy model is placed.
        /// </summary>
        private const float k_ModelRotation = 180.0f;

        /// <summary>
        /// True if the app is in the process of quitting due to an ARCore connection error, otherwise false.
        /// </summary>
        private bool m_IsQuitting = false;
        private int curr = 0, tries = 0;

        public Material red;
        public Material blue;
        public Material yellow;
        public Material green;

        private string[] pattern = new string[4] { "R1", "R2", "R3", "R4" };
        private List<Material> mats = new List<Material>();
        private int[] index = new int[4] { -1, -1, -1, -1 };
        private int[] correct = new int[4] { 0, 0, 0, 0 };

        private GameObject[] obj = new GameObject[4];

		public Sprite planetSprite;

        public void Start()
        {
            LoadingScreen.SetActive(false);
            mats.Add(blue);
            mats.Add(yellow);
            mats.Add(red);
            mats.Add(green);
        }

        /// <summary>
        /// The Unity Update() method.
        /// </summary>
        public void Update()
        {
            //_UpdateApplicationLifecycle();

            Ray ray;
            RaycastHit hit;
            if (Input.touchCount > 0 && (Input.GetTouch(0)).phase == TouchPhase.Began)
            {
                ray = Camera.main.ScreenPointToRay(Input.GetTouch(0).position);
                if (Physics.Raycast(ray, out hit, Mathf.Infinity))
                {
                    if (hit.collider.tag == "R1")
                    {
                        index[0]++;
                        index[0] = index[0] % 4;
                        hit.collider.gameObject.GetComponent<MeshRenderer>().material = mats[index[0]];
                        if (index[0] == 0)
                        {
                            correct[0] = 1;
                        }
                        else
                        {
                            correct[0] = 0;
                        }
                    }
                    else if (hit.collider.tag == "R2")
                    {
                        index[1]++;
                        index[1] = index[0] % 4;
                        hit.collider.gameObject.GetComponent<MeshRenderer>().material = mats[index[1]];
                        if (index[1] == 1)
                        {
                            correct[1] = 1;
                        }
                        else
                        {
                            correct[1] = 0;
                        }
                    }
                    else if (hit.collider.tag == "R3")
                    {
                        index[2]++;
                        index[2] = index[2] % 4;
                        hit.collider.gameObject.GetComponent<MeshRenderer>().material = mats[index[2]];
                        if (index[2] == 2)
                        {
                            correct[2] = 1;
                        }
                        else
                        {
                            correct[2] = 0;
                        }
                    }
                    else if (hit.collider.tag == "R4")
                    {
                        index[3]++;
                        index[3] = index[3] % 4;
                        hit.collider.gameObject.GetComponent<MeshRenderer>().material = mats[index[3]];
                        if (index[3] == 3)
                        {
                            correct[3] = 1;
                        }
                        else
                        {
                            correct[3] = 0;
                        }
                    }
					if (checkCorrect ()) {
						LoadingScreen.SetActive (true);

						// Persistent Update
						PersistentDataController PDC = GameObject.FindGameObjectWithTag("persistentDataController").GetComponent<PersistentDataController>();
						PDC.addCollectible(3, "Milk", planetSprite);
						PDC.relayMessage = "You got the milk";
						PDC.sceneChange = 1;

						SceneManager.LoadScene ("PeacefulForest", LoadSceneMode.Single);
					}   
                }
            }
        }

        private bool checkCorrect()
        {
            for (int i = 0; i < 4; i++)
            {
                 if (correct[i] == 0)
                {
                     return false;
                }

            }
            return true;
        }
        /// <summary>
        /// Check and update the application lifecycle.
        /// </summary>
        private void _UpdateApplicationLifecycle()
        {
            // Exit the app when the 'back' button is pressed.
            if (Input.GetKey(KeyCode.Escape))
            {
                Application.Quit();
            }

            // Only allow the screen to sleep when not tracking.
            if (Session.Status != SessionStatus.Tracking)
            {
                const int lostTrackingSleepTimeout = 15;
                Screen.sleepTimeout = lostTrackingSleepTimeout;
            }
            else
            {
                Screen.sleepTimeout = SleepTimeout.NeverSleep;
            }

            if (m_IsQuitting)
            {
                return;
            }

            // Quit if ARCore was unable to connect and give Unity some time for the toast to appear.
            if (Session.Status == SessionStatus.ErrorPermissionNotGranted)
            {
                _ShowAndroidToastMessage("Camera permission is needed to run this application.");
                m_IsQuitting = true;
                Invoke("_DoQuit", 0.5f);
            }
            else if (Session.Status.IsError())
            {
                _ShowAndroidToastMessage("ARCore encountered a problem connecting.  Please start the app again.");
                m_IsQuitting = true;
                Invoke("_DoQuit", 0.5f);
            }
        }

        /// <summary>
        /// Actually quit the application.
        /// </summary>
        private void _DoQuit()
        {
            Application.Quit();
        }

        /// <summary>
        /// Show an Android toast message.
        /// </summary>
        /// <param name="message">Message string to show in the toast.</param>
        private void _ShowAndroidToastMessage(string message)
        {
            AndroidJavaClass unityPlayer = new AndroidJavaClass("com.unity3d.player.UnityPlayer");
            AndroidJavaObject unityActivity = unityPlayer.GetStatic<AndroidJavaObject>("currentActivity");

            if (unityActivity != null)
            {
                AndroidJavaClass toastClass = new AndroidJavaClass("android.widget.Toast");
                unityActivity.Call("runOnUiThread", new AndroidJavaRunnable(() =>
                {
                    AndroidJavaObject toastObject = toastClass.CallStatic<AndroidJavaObject>("makeText", unityActivity,
                        message, 0);
                    toastObject.Call("show");
                }));
            }
        }
    }
}
