using UnityEngine;
using System.Collections;
using System.Collections.Generic;

namespace ColorDash
{
    public class ColorDashGame : MonoBehaviour
    {
        public GameObject player;
        public Renderer PlayerRenderer;
        public Material[] ColorMaterials;
        public GameObject[] colorCubes;
        public float colorChangeInterval = 10f;
        public float cubeSpawnInterval = 2f;
        public int minCubesToSpawn = 5;
        public int maxCubesToSpawn = 10;

        private Color playerColor;
        private int collectedCubes = 0;
        private float nextColorChangeTime;
        private float nextCubeSpawnTime;

        void Start()
        {
            PlayerRenderer.material = ColorMaterials[Random.Range(0, ColorMaterials.Length)];
            nextColorChangeTime = Time.time + colorChangeInterval;
            nextCubeSpawnTime = Time.time + cubeSpawnInterval;
        }

        void Update()
        {
            // Check if it's time to change the player's color
            if (Time.time >= nextColorChangeTime)
            {
                //player.GetComponent<Renderer>().material.color = playerColor;
                PlayerRenderer.material = ColorMaterials[Random.Range(0, ColorMaterials.Length)];
                nextColorChangeTime = Time.time + colorChangeInterval;
            }

            // Check if it's time to spawn new color cubes
            if (Time.time >= nextCubeSpawnTime)
            {
                int numCubesToSpawn = Random.Range(minCubesToSpawn, maxCubesToSpawn + 1);
                for (int i = 0; i < numCubesToSpawn; i++)
                {
                    SpawnColorCube();
                }
                nextCubeSpawnTime = Time.time + cubeSpawnInterval;
            }
        }

        void SpawnColorCube()
        {
            // Randomly choose a color for the cube
            //Color cubeColor = GetRandomColor();

            // Randomly choose a position within the closed environment
            Vector3 spawnPosition = new Vector3(Random.Range(-40f, 41f), 0.5f, Random.Range(-40f, 41f));

            // Instantiate the color cube at the chosen position
            GameObject newCube = Instantiate(colorCubes[Random.Range(0, colorCubes.Length)], spawnPosition, Quaternion.identity);
            //newCube.GetComponent<Renderer>().material.color = cubeColor;
        }

        Color GetPlayerColor()
        {
            return PlayerRenderer.material.color;
            //return new Color(Random.value, Random.value, Random.value);
        }

        void OnTriggerEnter(Collider other)
        {
            if (other.CompareTag("Collectable"))
            {
                playerColor = GetPlayerColor();
                Color cubeColor = other.GetComponent<Renderer>().material.color;
                if (cubeColor == playerColor)
                {
                    collectedCubes++;
                    Vector3 TempScale = player.transform.localScale;
                    //TempScale.y += 0.1f;
                    TempScale.x += 0.1f;
                    TempScale.z += 0.1f;
                    player.transform.localScale = TempScale;
                    Destroy(other.gameObject);
                }
                else {
                    Vector3 TempScale = player.transform.localScale;
                    //TempScale.y += 0.1f;
                    TempScale.x -= 0.1f;
                    TempScale.z -= 0.1f;
                    player.transform.localScale = TempScale;
                    Destroy(other.gameObject);
                }
            }
        }
    }

}