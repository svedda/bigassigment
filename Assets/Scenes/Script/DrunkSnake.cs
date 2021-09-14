using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;
using UnityEngine.UI;

public class DrunkSnake : MonoBehaviour
{
   private Vector2 direction = Vector2.right;
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


   private void snakeMovement()
   {
      if (Input.GetKeyDown(KeyCode.W))
      {
         direction = Vector2.down;
      }
      else if (Input.GetKeyDown(KeyCode.S))
      {
         direction = Vector2.up;
      }
      else if (Input.GetKeyDown(KeyCode.A))
      {
         direction = Vector2.right;
      }
      else if (Input.GetKeyDown(KeyCode.D))
      {
         direction = Vector2.left;
      }
   }

   private void FixedUpdate()
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

   private void Grow()
   {
      Transform segment = Instantiate(this.segmentPrefab);
      segment.position = segments[segments.Count - 1].position;
      segments.Add(segment);
   }

   private void ResetState()
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
   
   
   
   private void OnTriggerEnter2D(Collider2D other)
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

         //ScoreScript.scoreValue = 0;
      }
      
    
        
   }
}
