using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwipeControl : MonoBehaviour
{
   

   public float speed;
   [Header("Spirit")]
   public Transform playerModelRoot;
   public float posX;
   public float startPosX;
   public float swipeSec;
   public float swipeValue;
   
   private float _mousePosx;
   private bool _inputControl;

   [Header("Camera")]
   [HideInInspector] public bool finishCam;
   
   private void Update()
   {
      PlayerMovement();
   }

   private void PlayerMovement()
   {
      Vector3 direc = transform.forward * (Time.deltaTime * speed);
      transform.Translate(direc);
      if (_inputControl)
      {
         return;
      }
      if (Input.GetMouseButtonDown(0))
      {
         _mousePosx = GameManager.Cam.ScreenToViewportPoint(Input.mousePosition).x;
      }

      if (Input.GetMouseButton(0))
      {
         float newMousePosX = GameManager.Cam.ScreenToViewportPoint(Input.mousePosition).x;
         float distanceX = newMousePosX - _mousePosx;
         if (distanceX < -swipeValue)
         {
            StartCoroutine(PlayerSwipe(-1));
         }
         else if (distanceX > swipeValue)
         {
            StartCoroutine(PlayerSwipe(1));

         }
      }

   }

   IEnumerator PlayerSwipe(float target)
   {
      _inputControl = true;
      float timer = 0f;
      while (true)
      {
         timer += Time.deltaTime;
         Vector3 modelPos = playerModelRoot.localPosition;
         modelPos.x = Mathf.Lerp(modelPos.x, target * posX, timer);
         playerModelRoot.localPosition = modelPos;
         if (timer>=1f)
         {
            break;
         }
         yield return new WaitForEndOfFrame();
      }

      yield return new WaitForSeconds(swipeSec);
      
      timer = 0f;
      
      while (true)
      {
         timer += Time.deltaTime;
         Vector3 modelPos = playerModelRoot.localPosition;
         modelPos.x = Mathf.Lerp(modelPos.x, startPosX, timer);
         playerModelRoot.localPosition = modelPos;
         if (timer>=1f)
         {
            _inputControl = false;
            break;
         }
         yield return new WaitForEndOfFrame();
      }
   }



}
