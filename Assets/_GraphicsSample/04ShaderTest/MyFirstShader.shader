Shader "Custom/MyFirstShader"
{
    Properties
    {
        [MainColor] _BaseColor("Base Color", Color) = (1, 1, 1, 1)
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
            };

            //버택스 셰이더 함수 프로그래밍의 결과로 리턴값이다
            //프래그먼트 셰이더 입력값의 매개변수로 넘겨준다
            struct Varyings
            {
                // The positions in this struct must have the SV_POSITION semantic.
                float4 positionHCS  : SV_POSITION;
            };

            //버택스 프로그래밍 함수
            Varyings vert(Attributes IN)
            {
                //버택스 프로그래밍 결과의 리턴값 선언
                Varyings OUT;

                // The TransformObjectToHClip function transforms vertex positions
                // from object space to homogenous clip space.
                OUT.positionHCS = TransformObjectToHClip(IN.positionOS.xyz);

                // Returning the output.
                return OUT;
            }

            half4 frag() : SV_Target
            {
                // Defining the color variable and returning it.
                half4 customColor = half4(0.5, 0, 0, 1);
                return customColor;
            }
            ENDHLSL
        }
    }
}
