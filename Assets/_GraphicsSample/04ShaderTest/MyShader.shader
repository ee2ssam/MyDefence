Shader "Custom/MyShader"
{
    Properties
    {
        _MainTex ("Texture", 2D) = "white" {}
    }
    SubShader
    {
        Tags { "RenderType"="Opaque" }
        LOD 100

        Pass
        {
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag
            // make fog work
            #pragma multi_compile_fog

            #include "UnityCG.cginc"

            struct appdata
            {
                float4 vertex : POSITION;
                float2 uv : TEXCOORD0;
            };

            struct v2f
            {
                float2 uv : TEXCOORD0;
                UNITY_FOG_COORDS(1)
                float4 vertex : SV_POSITION;
            };

            sampler2D _MainTex;
            float4 _MainTex_ST;

            v2f vert (appdata v)
            {
                v2f o;
                o.vertex = UnityObjectToClipPos(v.vertex);
                o.uv = TRANSFORM_TEX(v.uv, _MainTex);
                UNITY_TRANSFER_FOG(o,o.vertex);
                return o;
            }

            fixed4 frag (v2f i) : SV_Target
            {
                // sample the texture
                fixed4 col = tex2D(_MainTex, i.uv);
                // apply fog
                UNITY_APPLY_FOG(i.fogCoord, col);
                return col;
            }
            ENDCG
        }
    }
}


/*
Lighting 종류
1) Ambient : 주변광, 환경광등에 나오는 빛이 오브젝트에 반사되어 나온 반사광
2) Diffuse : 오브젝트 자신의 고유 색, 광원에 반사될때 출력되는 가장 주된 색
3) Specular : 정 반사광, 특정 방향으로만 반사되는 빛, 하이라이트 표현
4) Emissive : 메시 표면에서 자체적으로 방출되는 색


Shader 프로그램
: 화면에 출력할 픽셀의 위치와 색상을 계산하는 함수를 작성하는 것

언어
ShaderLab : 유니티에서 사용하는 셰이더 스크립트 언어
셰이더 언어 CG / HLSL / GLSL
CG : C for Graphics, MS와 엔비디아에서 만든 셰이딩 언어
GLSL : OpenGL에서 사용하는 셰이딩 언어 (OpenGL Shading Language)
HLSL : 가장 유명하고 보편적으로 사용하는 언어, Unity 6에서 사용, High Level Shading Language

ShaderLab 으로 작성할수 있는 셰이더 프로그램
: 고정 함수 셰이더 - x
: 표면 셰이더 - surface shader
: 버텍스/프래그먼트 셰이더 : 6.0 

Shader "Custom/MyShader"    //셰이더 경로 및 셰이더 이름 정의
{
    //인스펙터창에서 입력 받는 값 정의
    Properties
    {
        
    }
    //고사양
    SubShader
    {
        Pass
        {

        }
        Pass
        {

        }
    }
    //중사양
    SubShader
    {
        Pass
        {

        }
        Pass
        {

        }
    }
    //저사양
    SubShader
    {
        Pass
        {

        }
        Pass
        {

        }
    }
    Fallback "Diffuse"
}
*/