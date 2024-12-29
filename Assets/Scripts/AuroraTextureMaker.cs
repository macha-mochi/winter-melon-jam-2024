using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AuroraTextureMaker : MonoBehaviour
{
    [SerializeField] Texture2D sourceTexture;
    public Texture2D t;
    [SerializeField] int singleMaxColorHeight = 20;

    [SerializeField] Color[] colors;
    [SerializeField] SpriteRenderer sr;

    int currentColorHeight;
    Color[] pixels;

    Color white = new Color(1, 1, 1, 1);

    // Start is called before the first frame update
    void Start()
    {
        t = new Texture2D(sourceTexture.width, sourceTexture.height); //, TextureFormat.RGB24, true);
        t.filterMode = FilterMode.Point;
        t.alphaIsTransparency = true;
        //Graphics.CopyTexture(sourceTexture, t);

        pixels = sourceTexture.GetPixels();
        currentColorHeight = Random.Range(1, 5);
        makeImage();

        sr.sprite = Sprite.Create(t, new Rect(0, 0, t.width, t.height), new Vector2(0.5f, 0.5f), 16);
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
        while(!finished) //for(int i = 0; i < t.width; i++)
        {
            Debug.Log("whitepixel: " + whitePixel);
            SetPixelsInColumn(whitePixel, currentColorHeight);
            if((int)whitePixel.x >= t.width - 1)
            {
                finished = true;
                break;
            }
            whitePixel = nextWhitePixel(whitePixel);
            currentColorHeight += Random.Range(-1, 2);
            currentColorHeight = Mathf.Clamp(currentColorHeight, 1, singleMaxColorHeight);
        }
        t.SetPixels(pixels, 0);
        t.Apply();
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
                    //Debug.Log(x + " " + y); // + " " + pixels[textureCoordToFlatArray(x, y, t.width)]);
;                   if (0 <= x && x < t.width && 0 <= y && y < t.height && pixels[textureCoordToFlatArray(x, y, t.width)] == white)//t.GetPixel(x, y) == white)
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
            for(; j < Mathf.Min(t.height, i + colorHeight); j++)
            {
                int px = (int)startPos.x;
                if (j == (int)startPos.y || pixels[textureCoordToFlatArray(px, j, t.width)] != white)//t.GetPixel(px, j) != white)
                {
                    int ind = textureCoordToFlatArray((int)startPos.x, j, t.width);
                    //Debug.Log((int)startPos.x + " " + j + " " + t.width);
                    //Debug.Log(ind);
                    pixels[ind] = colors[colorIndex];
                    //t.SetPixel((int)startPos.x, j, colors[colorIndex]);
                }
            }
            i = j - 1;
            colorIndex++;
            colorHeight += Random.Range(-2, 3);
            currentColorHeight = Mathf.Clamp(currentColorHeight, 1, singleMaxColorHeight);
            if (colorIndex == colors.Length)
            {
                break;
            }
        }
    }

    Vector2 leftmostWhitePixel()
    {
        for(int i = 0; i < t.height; i++)
        {
            if(pixels[textureCoordToFlatArray(0, i, t.width)] == white)//t.GetPixel(0, i) == white)
            {
                return new Vector2(0, i);
            }
        }
        return new Vector2(-1, -1);
    }
    int textureCoordToFlatArray(int x, int y, int width)
    {
        //x and y = c and r
        return y * width + x;
    }
}
