﻿using UnityEngine;

namespace Code.Enemy{
	// ReSharper disable once InconsistentNaming
	public class EnemyAI : MonoBehaviour{
		public Transform target;

		[SerializeField] EnemyMovement enemyMovement;
		[SerializeField] Vector3 nextStep;
		[SerializeField] float speed = 5;
		[SerializeField] bool isBomb;
		public float health = 5;
		float currentHealth;

		bool _isMoving = true;

		void Start() {
			currentHealth = health;
			var movementInstance = Instantiate(enemyMovement);
			enemyMovement = movementInstance;
			
			var temp = target.position;
			enemyMovement.GenerateRoute(transform.position, 
				new Vector3(temp.x, temp.y, temp.z));
			nextStep = enemyMovement.GetNextVector();
		}

		void Update(){
			if(!isBomb){
				//przeciwnicy odwracaja sie w strone gracza
			}

			if(currentHealth <= 0){
				Destroy(gameObject);
			}
		}

		void FixedUpdate(){
			if(_isMoving){
				MoveEnemy();
			}else{
				if(isBomb){
					Debug.Log("BOOM");
				}
				Destroy(gameObject);
			}
		}

		void MoveEnemy(){
			if(IsInNextStep()){
				if(enemyMovement.IsNextVector()){
					nextStep = enemyMovement.GetNextVector();
				}else{
					_isMoving = false;
				}
			}

			var step = speed * Time.deltaTime;
			//Debug.Log(nextStep);
			transform.position = Vector3.MoveTowards(transform.position, nextStep, step);
		}

		bool IsInNextStep(){
			var distance = Vector3.Distance(transform.position, nextStep);
			return distance < 0.01f;
		}

		public RespawnArea GetRespawnArea(){
			return enemyMovement.GetRespawnArea();
		}
		
		[ContextMenu("Kill")]
		void Kill(){
			currentHealth -= currentHealth;
		}

		public void DamageMeBoi(int damage) {
			currentHealth -= damage;
		}
	}
}