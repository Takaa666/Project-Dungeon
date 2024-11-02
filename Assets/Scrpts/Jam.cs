using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Jam : MonoBehaviour
{
    public int hour = 8;   // Jam mulai
    public int minute = 0; // Menit mulai
    public int second = 0; // Detik mulai

    public float timeSpeed = 1f; // Kecepatan waktu (1f untuk waktu asli, angka lebih tinggi untuk lebih cepat)
    public Text clockText;       // UI teks untuk jam

    private float elapsedTime = 0f;

    void Update()
    {
        // Tambahkan waktu sesuai kecepatan
        elapsedTime += Time.deltaTime * timeSpeed;

        // Setiap satu detik berlalu
        if (elapsedTime >= 1f)
        {
            elapsedTime = 0f;
            second++;

            if (second >= 60)
            {
                second = 0;
                minute++;

                if (minute >= 60)
                {
                    minute = 0;
                    hour++;

                    if (hour >= 24)
                    {
                        hour = 0; // Reset ke tengah malam
                    }
                }
            }
        }

        // Tampilkan waktu
        clockText.text = string.Format("{0:D2}:{1:D2}:{2:D2}", hour, minute, second);
    }
}
