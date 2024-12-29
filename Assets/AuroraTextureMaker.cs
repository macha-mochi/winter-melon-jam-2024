using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AuroraTextureMaker : MonoBehaviour
{
    [SerializeField] Texture2D sourceTexture;
    [SerializeField] Texture2D t;

    [SerializeField] Color[] colors;
    [SerializeField] SpriteRenderer sr;

    bool[] increaseInHeight;
    int currentColorHeight;

    Color white = new Color(1, 1, 1, 1);

    // Start is called before the first frame update
    void Start()
    {
        //t = new Texture2D(sourceTexture.width, sourceTexture.height);
        //Graphics.CopyTexture(sourceTexture, t);

        increaseInHeight = new bool[t.width];
        bool increase = Random.Range(0, 2) == 0;
        for(int i = 0; i < t.width; i++)
        {
            int randLength = Random.Range(5, 40);
            int j = i;
            for(; j < Mathf.Min(t.width, i + randLength); j++)
            {
                increaseInHeight[j] = increase;
            }
            increase = !increase;
            i = j - 1;
        }

        currentColorHeight = Random.Range(1, 31);
        makeImage();

        sr.sprite = Sprite.Create(t, new Rect(0, 0, t.width, t.height), new Vector2(0, 0), 16);
    }
    void makeImage()
    {
        //plan: start at column 0, then search neighbors to find next white pixel
        //visited ones are just no longer white LMAO so its fine
        //replace that pixel with color[0], then go up currentColorHeight pixels with color[0]
        //change currentColorHeight by a random amount, go up with color[1] and so on
        //if you ever reach another white pixel, skip it and keep going
        //after doing one white pixel: if ur supposed to increase height, add a random number to colorHeight, else decrease

        Vector2 whitePixel = leftmostWhitePixel();

        bool finished = false;
        while (!finished)
        {
            SetPixelsInColumn(whitePixel, currentColorHeight);
            t.Apply();
            whitePixel = nextWhitePixel(whitePixel);
            Debug.Log(increaseInHeight.Length);
            Debug.Log((int)whitePixel.x);
            if (increaseInHeight[(int)whitePixel.x]) currentColorHeight += Random.Range(3, 8);
            else currentColorHeight = Mathf.Min(1, currentColorHeight - Random.Range(3, 8));
            finished = true;
        }
    }

    Vector2 nextWhitePixel(Vector2 pos)
    {
        for(int i = -1; i <= 1; i++)
        {
            for(int j = -1; j <= 1; j++)
            {
                if (!(i == 0 && j == 0))
                {
                    int x = (int)pos.x + i;
                    int y = (int)pos.y + j;
                    if(0 <= x && x < t.width && 0 <= y && y < t.height && t.GetPixel(x, y) == white)
                    {
                        Debug.Log("found");
                        return new Vector2(x, y);
                    }
                }
            }
        }
        return new Vector2(-1, -1);
    }

    void SetPixelsInColumn(Vector2 startPos, int colorHeight)
    {
        int colorIndex = 0;
        for(int i = (int)startPos.y; i < t.height; i++)
        {
            int j = i;
            for(; j < Mathf.Min(t.height, j + colorHeight); j++)
            {
                int px = (int)startPos.x;
                if(j == (int)startPos.y || t.GetPixel(px, j) != white) t.SetPixel((int)startPos.x, j, colors[colorIndex]);
            }
            i = j - 1;
            colorIndex++;
            colorHeight += Random.Range(-2, 2);
            Mathf.Clamp(colorHeight, 1, t.height / 10);
            if (colorIndex == colors.Length) break;
        }
    }

    Vector2 leftmostWhitePixel()
    {
        for(int i = 0; i < t.height; i++)
        {
            if(t.GetPixel(0, i) == white)
            {
                return new Vector2(0, i);
            }
        }
        return new Vector2(-1, -1);
    }
}
