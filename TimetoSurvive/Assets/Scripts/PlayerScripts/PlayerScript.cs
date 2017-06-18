using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System;
using UnityEngine.SceneManagement;

public class PlayerScript : MonoBehaviour {

    public int health;
    public float sisHealth;
    int maxHealth;

    int sisDisplayHealth;
    public float healthTimer;
    float resetHealthTimer;

    public Text sisHP;
    public Slider healthSlider;
    Scene scene;
	// Use this for initialization
	void Start () {
        maxHealth = health;
        resetHealthTimer = healthTimer;
	}

    // Update is called once per frame
    void Update () {
        scene = SceneManager.GetActiveScene();
        if(scene.name != "ForToSky")
        {
            DecreaseHealth();
            sisHealth -= Time.deltaTime;
        }
        sisDisplayHealth = (int)sisHealth;
        sisHP.text = sisDisplayHealth.ToString();
        healthSlider.value = health;

    }

    void DecreaseHealth()
    {
        healthTimer -= Time.deltaTime;
        if (healthTimer <= 0)
        {
            health--;
            healthTimer = resetHealthTimer;
        }
    }

    public void AddHealth(int amount)
    {
        int healthNeeded = maxHealth - health;
        if(healthNeeded < amount)
        {
            sisHealth += amount - healthNeeded;
            health = maxHealth;
        }
        else
        {
            health += amount;
        }
    }
    public void SubHealth(int amount)
    {
        health -= amount;
        if(health<=0)
        {
            Destroy(this.gameObject);
            SceneManager.LoadScene("Lose");
        }
    }

}
