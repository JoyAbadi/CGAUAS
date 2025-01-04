using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FreeLook : MonoBehaviour
   {
       private float rotationSpeed = 5f; // Kecepatan rotasi
       private bool isRotating = false;

       void Update()
       {
           // Cek apakah tombol kanan mouse ditekan
           if (Input.GetMouseButton(1)) // 1 adalah tombol kanan mouse
           {
               isRotating = true;
               RotateCube();
           }
           else
           {
               isRotating = false;
           }
       }

       void RotateCube()
       {
           // Ambil pergerakan mouse
           float mouseX = Input.GetAxis("Mouse X") * rotationSpeed;
           float mouseY = Input.GetAxis("Mouse Y") * rotationSpeed;

           // Rotasi kubus berdasarkan pergerakan mouse
           transform.Rotate(Vector3.up, -mouseX, Space.World);
           transform.Rotate(Vector3.right, mouseY, Space.World);
       }
   }
