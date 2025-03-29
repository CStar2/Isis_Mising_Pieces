using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class MusicIndi : MonoBehaviour
{
    
    
        // Arreglo que almacena los efectos de sonido (SFX)
        [Header("Sound Effects")]
        public AudioSource[] sfx;

        // Arreglo que almacena las pistas de música de fondo (BGM)
        [Header("Background Music")]
        public AudioSource[] bgm;

        // Variables ocultas en el inspector, posiblemente usadas para la interfaz de usuario
        [HideInInspector]
        public int toolbar;
        [HideInInspector]
        public string currentTab;

        // Instancia única de MusicIndi para acceder desde otros scripts (Singleton)
        public static MusicIndi instance;

        // Método que se ejecuta al iniciar el script
        void Start()
        {
            instance = this; // Asigna esta instancia a la variable estática
            DontDestroyOnLoad(this.gameObject); // Evita que se destruya al cambiar de escena
        }

        // Método Update (vacío en este caso, pero se ejecuta en cada frame)
        void Update()
        {
        }

        // Método para reproducir un efecto de sonido específico
        public void PlaySFX(int soundToPlay)
        {
            if (soundToPlay < sfx.Length) // Verifica si el índice es válido
            {
                sfx[soundToPlay].Play(); // Reproduce el sonido correspondiente
            }
        }

        // Método para reproducir una música de fondo específica
        public void PlayBGM(int musicToPlay)
        {
            if (!bgm[musicToPlay].isPlaying) // Verifica que la música no esté ya en reproducción
            {
                StopMusic(); // Detiene cualquier música en reproducción

                if (musicToPlay < bgm.Length) // Verifica si el índice es válido
                {
                    bgm[musicToPlay].Play(); // Reproduce la música seleccionada
                }
            }
        }

        // Método para detener toda la música de fondo en reproducción
        public void StopMusic()
        {
            for (int i = 0; i < bgm.Length; i++) // Recorre el arreglo de música
            {
                bgm[i].Stop(); // Detiene cada pista de música en la lista
            }
        }
    
}

