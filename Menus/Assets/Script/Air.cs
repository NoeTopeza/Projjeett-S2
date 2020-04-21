using System;
using UnityEngine;

namespace Script
{
    public class Air : MonoBehaviour
    {
        public GameObject cursor;

        private void OnTriggerEnter(Collider coll)
        {
            GameObject gameObj = coll.gameObject;
            
            if (gameObj == cursor)
            {
                MeshRenderer render = GetComponent<MeshRenderer>();
                render.enabled = true;
            }
        }

        private void OnTriggerExit(Collider other)
        {
            MeshRenderer render = GetComponent<MeshRenderer>();
            render.enabled = false;
        }
        

        // Update is called once per frame
        void Update()
        {
        
        }
    }
}
