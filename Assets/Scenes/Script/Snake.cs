using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;
using UnityEngine.UI;

public class Snake : MonoBehaviour
{
   private Vector2 direction = Vector2.left; //start direction
   private List<Transform> segments = new List<Transform>();
   public Transform segmentPrefab;
   public int startSize = 0;
   private void Start()
   {
      ResetState();
   }

   private void Update()
   {
      snakeMovement();
      
   }
   
   
//----------------------------------------

   private void snakeMovement()  //WASD snakemovement
   {
      if (Input.GetKeyDown(KeyCode.W))
      {
         direction = Vector2.up;
         Debug.Log("hej");
      }
      else if (Input.GetKeyDown(KeyCode.S))
      {
         direction = Vector2.down;
      }
      else if (Input.GetKeyDown(KeyCode.A))
      {
         direction = Vector2.left;
      }
      else if (Input.GetKeyDown(KeyCode.D))
      {
         direction = Vector2.right;
      }
   }
   
   //-------------------------------------------------------------

   private void FixedUpdate() //snake movement
   {

      for (int i = segments.Count - 1; i > 0; i--)
      {
         segments[i].position = segments[i - 1].position;

      }
      var position = this.transform.position;
      position = new Vector3(
         Mathf.Round(position.x) + direction.x,
         Mathf.Round(position.y) + direction.y, 0.0f);
      this.transform.position = position;
   }
   
   //---------------------------------------------------------

   private void Grow() // snake growfunction
   {
      Transform segment = Instantiate(this.segmentPrefab);
      segment.position = segments[segments.Count - 1].position;
      segments.Add(segment);
   }

   //-----------------------------------------------------------
   
   private void ResetState()  //reset function
   {
      for (int i = 1; i < segments.Count; i++)  
      {
         Destroy(segments[i].gameObject);
      }
      
      segments.Clear();
      segments.Add(this.transform);

      for (int i = 1; i < this.startSize; i++)
      {
         segments.Add(Instantiate(this.segmentPrefab));
      }
      
      this.transform.position = Vector3.zero;

   }
   
   //----------------------------------------------------
   
   
   
   private void OnTriggerEnter2D(Collider2D other) //collider functions, add food to counter, reset if collision with wall or itself
   {
      if (other.tag == "Food")
      {
         Grow();
         FindObjectOfType<ScoreScript>().IncreaseScore();
         //ScoreScript.scoreValue ++;
         
      }
      else if (other.tag == "Obstacle")
      {
         ResetState();
         FindObjectOfType<ScoreScript>().ResetScore();
      }
      
    
        
   }
}
