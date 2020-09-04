using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TextFollow : MonoBehaviour
{
    
        
        public GameObject player;

        public Transform TextTransform;

        public Vector3 offset;

        // Start is called before the first frame update
        void Start()
        {
            TextTransform = this.GetComponent<Transform>();
        }


        // Update is called once per frame
        void Update()
        {
            TextTransform.position = player.transform.position + offset;
        }
    

}
