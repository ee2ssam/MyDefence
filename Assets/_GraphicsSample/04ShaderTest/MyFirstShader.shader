Shader "Custom/MyFirstShader"
{
    /*//인스펙터창에서 입력 받는 값 정의
    Properties
    {
        // _BaseColor : 셰이더 프로그램에서 사용하는 변수 이름과 동일
        // "Base Color" : 인스팩터 창에서 디스플레이 되는 이름
        // Color, Vector, Float, CUBE : 데이터 타입
        // (1, 1, 1, 1) : 초기값(인스펙터창에서 보이는)
        //[MainColor] _BaseColor("Base Color", Color) = (1, 1, 1, 1)
        [MainTexture] _BaseMap("Base Map", 2D) = "white" {}

        //_MyColor ("Some Color", Color) = (1,1,1,1) 
        //_MyVector ("Some Vector", Vector) = (0,0,0,0) 
        //_MyFloat ("My float", Float) = 0.5 
        //_MyTexture ("Texture", 2D) = "white" {} 
        //_MyCubemap ("Cubemap", CUBE) = "" {} 
    }
    SubShader
    {        
        Tags { "RenderType" = "Opaque" "RenderPipeline" = "UniversalPipeline" }    

        Pass
        {
            //HLSL 코드블록, HLSL 언어로 프로그래밍 한다
            HLSLPROGRAM
            //버택스 셰이더 함수 이름(vert) 정의
            #pragma vertex vert            
            //프래그먼트 셰이더 함수 이름(frag) 정의
            #pragma fragment frag
        
            //HLSL 라이브러리 가져오기(매크로, 함수)
            #include "Packages/com.unity.render-pipelines.universal/ShaderLibrary/Core.hlsl"

            //버택스 셰이더에서 매개변수로 입력받아서 사용할 버택스 정보중에서 가져올 데이터 정의
            struct Attributes
            {            
                // 모델 공간의 버텍스 위치 정보
                float4 positionOS   : POSITION;
                // 버텍스의 uv 정보
                float2 uv           : TEXCOORD0;
            };

            // This macro declares _BaseMap as a Texture2D object.
            TEXTURE2D(_BaseMap);
            // This macro declares the sampler for the _BaseMap texture.
            SAMPLER(sampler_BaseMap);

            CBUFFER_START(UnityPerMaterial)                
                //셰이더 프로그램에서 사용하는 변수로 인스펙터창에서 입력 받은 값을 처리한다
                //half4 _BaseColor;
                sampler2D _BaseMap;

                //half4 _MyColor; // low precision type is usually enough for colors
                //float4 _MyVector;
                //float _MyFloat; 
                //sampler2D _MyTexture;
                //samplerCUBE _MyCubemap;
            CBUFFER_END


            //버택스 셰이더 함수 프로그래밍의 결과로 리턴값이다
            //프래그먼트 셰이더 입력값의 매개변수로 넘겨준다
            struct Varyings
            {
                // The positions in this struct must have the SV_POSITION semantic.
                float4 positionHCS  : SV_POSITION;
                float2 uv           : TEXCOORD0;
            };

            //버택스 프로그래밍 함수
            Varyings vert(Attributes IN)
            {
                //버택스 프로그래밍 결과의 리턴값 선언
                Varyings OUT;

                // The TransformObjectToHClip function transforms vertex positions
                // from object space to homogenous clip space.
                OUT.positionHCS = TransformObjectToHClip(IN.positionOS.xyz);
                OUT.uv = TRANSFORM_TEX(IN.uv, _BaseMap);

                // Returning the output.
                return OUT;
            }

            half4 frag(Varyings IN) : SV_Target
            {
                half4 color = SAMPLE_TEXTURE2D(_BaseMap, sampler_BaseMap, IN.uv);
                return color;
            }
            ENDHLSL
        }
    }*/

    /*// The _BaseMap variable is visible in the Material's Inspector, as a field
    // called Base Map.
    Properties
    {
        [MainTexture] _BaseMap("Base Map", 2D) = "white" {}
    }

    SubShader
    {
        Tags { "RenderType" = "Opaque" "RenderPipeline" = "UniversalPipeline" }

        Pass
        {
            HLSLPROGRAM
            #pragma vertex vert
            #pragma fragment frag

            #include "Packages/com.unity.render-pipelines.universal/ShaderLibrary/Core.hlsl"

            struct Attributes
            {
                float4 positionOS   : POSITION;
                // The uv variable contains the UV coordinate on the texture for the
                // given vertex.
                float2 uv           : TEXCOORD0;
            };

            struct Varyings
            {
                float4 positionHCS  : SV_POSITION;
                // The uv variable contains the UV coordinate on the texture for the
                // given vertex.
                float2 uv           : TEXCOORD0;
            };

            // This macro declares _BaseMap as a Texture2D object.
            TEXTURE2D(_BaseMap);
            // This macro declares the sampler for the _BaseMap texture.
            SAMPLER(sampler_BaseMap);

            CBUFFER_START(UnityPerMaterial)
                // The following line declares the _BaseMap_ST variable, so that you
                // can use the _BaseMap variable in the fragment shader. The _ST
                // suffix is necessary for the tiling and offset function to work.
                float4 _BaseMap_ST;
            CBUFFER_END

            Varyings vert(Attributes IN)
            {
                Varyings OUT;
                OUT.positionHCS = TransformObjectToHClip(IN.positionOS.xyz);
                // The TRANSFORM_TEX macro performs the tiling and offset
                // transformation.
                OUT.uv = TRANSFORM_TEX(IN.uv, _BaseMap);
                return OUT;
            }

            half4 frag(Varyings IN) : SV_Target
            {
                // The SAMPLE_TEXTURE2D marco samples the texture with the given
                // sampler.
                half4 color = SAMPLE_TEXTURE2D(_BaseMap, sampler_BaseMap, IN.uv);
                return color;
            }
            ENDHLSL
        }
    }*/

    Properties
    { }

    SubShader
    {
        Tags { "RenderType" = "Opaque" "RenderPipeline" = "UniversalPipeline" }

        Pass
        {
            HLSLPROGRAM
            #pragma vertex vert
            #pragma fragment frag

            #include "Packages/com.unity.render-pipelines.universal/ShaderLibrary/Core.hlsl"

            struct Attributes
            {
                float4 positionOS   : POSITION;
                // Declaring the variable containing the normal vector for each
                // vertex.
                half3 normal        : NORMAL;
            };

            struct Varyings
            {
                float4 positionHCS  : SV_POSITION;
                half3 normal        : TEXCOORD0;
            };

            Varyings vert(Attributes IN)
            {
                Varyings OUT;
                OUT.positionHCS = TransformObjectToHClip(IN.positionOS.xyz);
                // Use the TransformObjectToWorldNormal function to transform the
                // normals from object to world space. This function is from the
                // SpaceTransforms.hlsl file, which is referenced in Core.hlsl.
                OUT.normal = TransformObjectToWorldNormal(IN.normal);
                return OUT;
            }

            half4 frag(Varyings IN) : SV_Target
            {
                half4 color = 0;
                // IN.normal is a 3D vector. Each vector component has the range
                // -1..1. To show all vector elements as color, including the
                // negative values, compress each value into the range 0..1.
                color.rgb = IN.normal * 0.5 + 0.5;
                return color;
            }
            ENDHLSL
        }
    }

}
