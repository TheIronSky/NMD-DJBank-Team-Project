using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Detect : MonoBehaviour {
    
	public Text scoreText;
    private int score;
	private int HiScore;
	public Text HiScoreText;
	
	 float currCountdownValue;
	public Text timeText;
    private float time;
	
	public LB_Leaderboard _scoreManager;
	
	public KeyCode k = KeyCode.K;
	
	//public Transform shot;
	//public Transform target;
    //public float speed;
	public GameObject Shot;
    public Transform shotSpawn;
	
	private static bool gameOver;
	
	
    void Start ()
    {
		score = 0;
		StartCoroutine(StartCountdown());
        UpdateScore ();
	}
	
	
	 void Update()
    {
	 var x = Input.GetAxis("Horizontal") * Time.deltaTime * 150.0f;
     var z = Input.GetAxis("Vertical") * Time.deltaTime * 3.0f;
		if (Input.GetKeyUp(k)){
				Fire();
					
        transform.Rotate(0, 0, 0);
        transform.Translate(0, 0, z);
			
	}
	}
	
	void GameOver()
    {
		if (gameOver == true) {
				Debug.Log("End");
				//if (score > ScoreKeeper.instance.highestScore){
				PlayerPrefs.SetInt("score", score);
				SceneManager.LoadScene("ShowLeaderboard");
		 }
		 	}
	//}
	
	void Fire()
    {
        
        var shot = (GameObject)Instantiate(
            Shot,
            shotSpawn.position,
            shotSpawn.rotation);
        
        shot.GetComponent<Rigidbody>().velocity = shot.transform.forward * -120;
        Destroy(shot, 2.0f);        
    }
	
		void OnTriggerStay(Collider other){
	 if(other.gameObject.tag == "Enemy"){
			if (Input.GetKeyUp(k)){
				Fire();
					
			}
	}
}
         public void AddScore(int gain)
    {
        score += gain;
        UpdateScore ();
    }
	void UpdateScore()
    {
		print("Score: " + score);
		scoreText.GetComponent<Text>().text = "" + score;
        
    }



 public IEnumerator StartCountdown(float countdownValue = 10)
 {
     currCountdownValue = countdownValue;
     while (currCountdownValue > -1)
     {
		// time == currCountdownValue;
         Debug.Log("Countdown: " + currCountdownValue);
		 timeText.GetComponent<Text>().text = "" + currCountdownValue;
         yield return new WaitForSeconds(1.0f);
         currCountdownValue--;
     }
	 if (currCountdownValue < 1)
     {
 		 gameOver = true;
		 GameOver();
	 }
 }
	
void UpdateTime()
    {
		//print("Score: " + score);
		//timeText.GetComponent<Text>().text = "" + time;
        //timeText.text = ": " + time;
    }	

}