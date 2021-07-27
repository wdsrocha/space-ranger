using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class Menu : MonoBehaviour
{

    [SerializeField] private float delay = 3f;
    private float time;
    private Rigidbody2D rig;

    private void Start()
    {
        time = delay;
        rig = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        if (Input.anyKey && time == delay) {
            time -= Time.deltaTime;
            SoundManager.Instance.PlaySound(SoundManager.Sound.UiSelect);
        } else if (time != delay) {
            time -= Time.deltaTime;
            rig.velocity = Vector2.down * (2 * (delay - time));
        }

        if (time <= 0) {
            SceneManager.LoadScene("Level");
        }
    }
}
