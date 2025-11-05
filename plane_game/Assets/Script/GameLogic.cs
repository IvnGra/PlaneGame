using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameLogic : MonoBehaviour
{
    public int Score1;
    public int Score2;
    public AudioSource WaypointAudio;
    public TMP_Text ScoreText;
       void Start()
    {
        ScoreText.GetComponent<TMP_Text>();
        ScoreText.text = "" + Score1;
        ScoreText.text = "" + Score2;
    }

    // Update is called once per frame
    void Update()
    {

    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "waypoint1")
        {
            Destroy(other.gameObject, 0.1f);
            Score1++;
            ScoreText.text = "" + Score1;
            WaypointAudio.Play();

            if(Score1 == 5)
            {
                Application.LoadLevel("Level2");
            }
        }
    }
}
