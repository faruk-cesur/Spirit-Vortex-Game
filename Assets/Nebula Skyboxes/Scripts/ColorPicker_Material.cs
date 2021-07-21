using UnityEngine;
using System;


public class ColorPicker_Material:MonoBehaviour{
    // Unluck Software © 2013
    // http://www.chemicalbliss.com
    //
    // Material Color Picker v1.0
    // Picks color from a GUI texture and applies it to a Shared Material
    
    public Material targetSharedMaterial;
    public Texture2D colorPickerTexture; 
    public int guiTextureX = 0;
    public int guiTextureY = 0;
    public int guiTextureWidth = 256;
    public int guiTextureHeight = 256;
    
    public void OnGUI() {
    	GUIStyle labelStyle = GUI.skin.label;
        if (GUI.RepeatButton(new Rect((float)guiTextureX, (float)guiTextureY, (float)guiTextureWidth, (float)guiTextureHeight), colorPickerTexture,labelStyle)) { 
            Vector2 mousePos = Event.current.mousePosition;
            int textureXpos = (int)(mousePos.x - guiTextureX+8);
            int textureYpos =  (int)(mousePos.y - guiTextureY+8);
            Color color = colorPickerTexture.GetPixel(textureXpos,colorPickerTexture.height-textureYpos);
            targetSharedMaterial.SetColor("_Tint", color);
        }
    }
}