using UnityEngine;

public class MinifyLong : MonoBehaviour
{
    public static string Minify(float value)
    {
        if (value >= Mathf.Pow(10, 17))
            return (value / Mathf.Pow(10, 15)).ToString("#,0") + " Q";
        if (value >= Mathf.Pow(10, 15))
            return (value / Mathf.Pow(10, 15)).ToString("0.#") + " Q";

        if (value >= Mathf.Pow(10, 14))
            return (value / Mathf.Pow(10, 12)).ToString("#,0") + " T";
        if (value >= Mathf.Pow(10, 12))
            return (value / Mathf.Pow(10, 12)).ToString("0.#") + " T";

        if (value >= Mathf.Pow(10, 11))
            return (value / Mathf.Pow(10, 9)).ToString("#,0") + " B";
        if (value >= Mathf.Pow(10, 9))
            return (value / Mathf.Pow(10, 9)).ToString("0.#") + " B";

        if (value >= Mathf.Pow(10, 8))
            return (value / Mathf.Pow(10, 6)).ToString("#,0") + " M";
        if (value >= Mathf.Pow(10, 6))
            return (value / Mathf.Pow(10, 6)).ToString("0.#") + " M";

        if (value >= Mathf.Pow(10, 5))
            return (value / Mathf.Pow(10, 3)).ToString("#,0") + " K";
        if (value >= Mathf.Pow(10, 4))
            return (value / Mathf.Pow(10, 3)).ToString("0.#") + " K";

        return value.ToString("#,0");
    }
}
