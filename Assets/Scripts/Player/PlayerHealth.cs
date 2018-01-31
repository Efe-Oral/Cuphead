﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Created by Timo Heijne
public class PlayerHealth : MonoBehaviour {

	[SerializeField]
	private int health = 3;
	
	private SpriteRenderer _sr;
	
	public delegate void Died();
	public Died HasDied;

	private float _lastDamage;
	
	[SerializeField]
	private float _maxCooldown = 5;
	
	/*
	 * private GameObject heart1;
	 * private GameObject heart2;
	 * private GameObject heart3;
	 */
	
	// Use this for initialization
	void Start () {
		_sr = GetComponent<SpriteRenderer>();
	}

	public void TakeDamage() {
		if (Time.time - _lastDamage < _maxCooldown) return;

		_lastDamage = Time.time;
		health -= 1;
		StartCoroutine(Blink());
		
		if (health <= 0) {
			if (HasDied != null) {
				HasDied();
			}
		}
	}
	
	private IEnumerator Blink()
	{
		Color c = _sr.color;
		_sr.color = new Color(0.8f, c.g, c.b, c.a);
		yield return new WaitForSeconds(0.05f);
		_sr.color = c;
	}

	private void OnParticleCollision(GameObject other) { // This is for the paper & key attack 'n shit
		throw new System.NotImplementedException();
	}
}