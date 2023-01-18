using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace CuteInvaders
{
    public class LoadStoryScene : MonoBehaviour
    {
        [SerializeField] private Fade _fade;

        private void Start()
        {
            _fade.Transparent();
        }

        public void ChangeStoryScene(int index)
        {
            StartCoroutine(ChangeStorySceneI(index));
        }

        private IEnumerator ChangeStorySceneI(int index)
        {
            _fade.gameObject.SetActive(true);
            _fade.Dark();
            
            yield return new WaitForSeconds(1.5f);

            SceneManager.LoadScene("Chapter" + index);
        }
    }
}