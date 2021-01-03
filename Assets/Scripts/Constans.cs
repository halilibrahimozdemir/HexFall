using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Constants : MonoBehaviour
{
    //Dereceden radyana çevirme oraný
    public static float DEG2RAD = 0.0174532925f;

    //Altýgen objelerin birbiri üzerine tam oturmasý için gerekli deðiþkenler.
    public static float XCOLLOFFSET = 0.7489f;
    public static float YROWOFFSET = 0.8656f;

    //Altýgen boyutlarý
    public static float WIDTH = 1.0f;
    public static float HEIGHT = 1f;

    //Orjin noktasý
    public static Vector3 ORIGIN_POINT = new Vector3(0, 0, 0);

    //Varsayýlan bomba geri sayým baþlangýcý
    public static int BOMB_COUNTER = 10;

    //Bekleme süreleri
    public static float WAIT_TIME = 0.02f;
    public static float HALF_SECOND = 0.5f;
    public static float HEX_INSTANTIATE_TIME = 0.02f;
    public static float HEX_ROTATION_WAIT_TIME = 0.6f;
}