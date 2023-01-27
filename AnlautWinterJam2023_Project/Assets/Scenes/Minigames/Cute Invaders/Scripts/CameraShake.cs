using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CuteInvaders
{
    public class CameraShake : MonoBehaviour
    {
        public void Shake(float duration, float magnitude)
        {
            StartCoroutine(ShakeI(duration, magnitude));
        }

        private IEnumerator ShakeI(float duration, float magnitude)
        {
            Vector3 originalPos = transform.position;

            float elapsed = 0.0f;

            while (elapsed < duration && Time.timeScale > 0)
            {
                float x = Random.Range(-1f, 1f) * magnitude;
                float y = Random.Range(-1f, 1f) * magnitude;

                transform.localPosition = new Vector3(x, y, -10f);

                elapsed += Time.deltaTime;

                yield return null;
            }

            transform.localPosition = originalPos;
        }
    }
}
