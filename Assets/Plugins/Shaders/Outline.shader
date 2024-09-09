Shader "Custom/OutlineBlink"
{
    Properties
    {
        _MainTex ("Texture", 2D) = "white" {}
        _OutlineColor ("Outline Color", Color) = (0,0,0,1)
        _Outline ("Outline width", Range (.002, 0.03)) = .005
        _BlinkSpeed ("Blink Speed", Range(0.1, 10.0)) = 1.0 // Default blink speed set to 1.0
    }
    SubShader
    {
        Tags {"Queue" = "Overlay"} // Ensures it renders after everything else
        Pass
        {
            Name "BASE"
            Tags {"LightMode" = "ForwardBase"}

            Cull Front // Renders the outline

            // Disable fog for the outline
            Fog { Mode Off }

            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag
            #include "UnityCG.cginc"

            // Inputs for the shader
            struct appdata_t
            {
                float4 vertex : POSITION;
                float3 normal : NORMAL;
            };

            struct v2f
            {
                float4 pos : POSITION;
                float4 color : COLOR;
            };

            // Uniforms for setting parameters in the shader
            uniform float _Outline;
            uniform float4 _OutlineColor;
            uniform float _BlinkSpeed;

            // Unity provides _Time automatically, so we just use it without redefining it

            v2f vert(appdata_t v)
            {
                // Extrude vertex position along the normal to create an outline
                v2f o;
                o.pos = UnityObjectToClipPos(v.vertex + float4(v.normal * _Outline, 0));
                o.color = _OutlineColor;
                return o;
            }

            half4 frag(v2f i) : COLOR
            {
                // Animate the alpha value to make the outline blink
                float blinkAlpha = (sin(_Time.y * _BlinkSpeed) * 0.5) + 0.5; // Oscillates between 0 and 1
                i.color.a *= blinkAlpha; // Apply the animated alpha value
                return i.color;
            }
            ENDCG
        }
    }
    Fallback "Diffuse"
}

