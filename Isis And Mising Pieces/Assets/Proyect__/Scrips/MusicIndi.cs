using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class MusicIndi : MonoBehaviour
{
    
    
        // Arreglo que almacena los efectos de sonido (SFX)
        [Header("Sound Effects")]
        public AudioSource[] sfx;

        // Arreglo que almacena las pistas de m�sica de fondo (BGM)
        [Header("Background Music")]
        public AudioSource[] bgm;

        // Variables ocultas en el inspector, posiblemente usadas para la interfaz de usuario
        [HideInInspector]
        public int toolbar;
        [HideInInspector]
        public string currentTab;

        // Instancia �nica de MusicIndi para acceder desde otros scripts (Singleton)
        public static MusicIndi instance;

        // M�todo que se ejecuta al iniciar el script
        void Start()
        {
            instance = this; // Asigna esta instancia a la variable est�tica
            DontDestroyOnLoad(this.gameObject); // Evita que se destruya al cambiar de escena
        }

        // M�todo Update (vac�o en este caso, pero se ejecuta en cada frame)
        void Update()
        {
        }

        // M�todo para reproducir un efecto de sonido espec�fico
        public void PlaySFX(int soundToPlay)
        {
            if (soundToPlay < sfx.Length) // Verifica si el �ndice es v�lido
            {
                sfx[soundToPlay].Play(); // Reproduce el sonido correspondiente
            }
        }

        // M�todo para reproducir una m�sica de fondo espec�fica
        public void PlayBGM(int musicToPlay)
        {
            if (!bgm[musicToPlay].isPlaying) // Verifica que la m�sica no est� ya en reproducci�n
            {
                StopMusic(); // Detiene cualquier m�sica en reproducci�n

                if (musicToPlay < bgm.Length) // Verifica si el �ndice es v�lido
                {
                    bgm[musicToPlay].Play(); // Reproduce la m�sica seleccionada
                }
            }
        }

        // M�todo para detener toda la m�sica de fondo en reproducci�n
        public void StopMusic()
        {
            for (int i = 0; i < bgm.Length; i++) // Recorre el arreglo de m�sica
            {
                bgm[i].Stop(); // Detiene cada pista de m�sica en la lista
            }
        }
    
}

