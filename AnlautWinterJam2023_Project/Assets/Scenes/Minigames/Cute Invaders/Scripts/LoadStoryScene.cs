using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace CuteInvaders
{
    public class LoadStoryScene : MonoBehaviour
    {
        [SerializeField] private Fade _fade;

        private IEnumerator _changeStorySceneCor;

        private void Start()
        {
            _fade.Transparent();
        }

        public void ChangeStoryScene(int index)
        {
            _changeStorySceneCor = ChangeStorySceneI(index);
            StartCoroutine(_changeStorySceneCor);
        }

        private IEnumerator ChangeStorySceneI(int index)
        {
            _fade.gameObject.SetActive(true);
            _fade.Dark();

            yield return new WaitForSecondsRealtime(_fade.AnimatorGet.GetCurrentAnimatorClipInfo(0).Length + 1);

            Time.timeScale = 1f;
            SceneManager.LoadScene("Chapter" + index);
        }
    }
}