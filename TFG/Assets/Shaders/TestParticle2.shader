// Shader created with Shader Forge v1.38 
// Shader Forge (c) Neat Corporation / Joachim Holmer - http://www.acegikmo.com/shaderforge/
// Note: Manually altering this data may prevent you from opening it in Shader Forge
/*SF_DATA;ver:1.38;sub:START;pass:START;ps:flbk:,iptp:0,cusa:False,bamd:0,cgin:,lico:1,lgpr:1,limd:0,spmd:1,trmd:0,grmd:0,uamb:True,mssp:True,bkdf:False,hqlp:False,rprd:False,enco:False,rmgx:True,imps:True,rpth:0,vtps:0,hqsc:True,nrmq:1,nrsp:0,vomd:0,spxs:False,tesm:0,olmd:1,culm:0,bsrc:3,bdst:7,dpts:2,wrdp:False,dith:0,atcv:False,rfrpo:True,rfrpn:Refraction,coma:15,ufog:True,aust:True,igpj:True,qofs:0,qpre:3,rntp:2,fgom:False,fgoc:False,fgod:False,fgor:False,fgmd:0,fgcr:0.5,fgcg:0.5,fgcb:0.5,fgca:1,fgde:0.01,fgrn:0,fgrf:300,stcl:False,atwp:False,stva:128,stmr:255,stmw:255,stcp:6,stps:0,stfa:0,stfz:0,ofsf:0,ofsu:0,f2p0:False,fnsp:True,fnfb:True,fsmp:False;n:type:ShaderForge.SFN_Final,id:4795,x:33256,y:32682,varname:node_4795,prsc:2|emission-4422-OUT,alpha-798-OUT;n:type:ShaderForge.SFN_Tex2d,id:6074,x:32235,y:32601,ptovrint:False,ptlb:MainTex,ptin:_MainTex,varname:_MainTex,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,tex:9ef27351523e3fb4db2d8009b708d4d9,ntxv:0,isnm:False;n:type:ShaderForge.SFN_Multiply,id:2393,x:32537,y:32730,varname:node_2393,prsc:2|A-6074-RGB,B-2053-RGB,C-797-RGB,D-9248-OUT;n:type:ShaderForge.SFN_VertexColor,id:2053,x:32235,y:32772,varname:node_2053,prsc:2;n:type:ShaderForge.SFN_Color,id:797,x:32235,y:32930,ptovrint:True,ptlb:Color,ptin:_TintColor,varname:_TintColor,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,c1:0.5,c2:0.5,c3:0.5,c4:1;n:type:ShaderForge.SFN_Vector1,id:9248,x:32235,y:33081,varname:node_9248,prsc:2,v1:2;n:type:ShaderForge.SFN_Multiply,id:798,x:32537,y:32935,varname:node_798,prsc:2|A-6074-A,B-2053-A,C-797-A;n:type:ShaderForge.SFN_Multiply,id:1336,x:32783,y:32746,varname:node_1336,prsc:2|A-2393-OUT,B-143-OUT;n:type:ShaderForge.SFN_Tex2d,id:2645,x:32643,y:33110,ptovrint:False,ptlb:node_2645,ptin:_node_2645,varname:node_2645,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,tex:51f775eb9d48e5b4996e227405abb4d3,ntxv:0,isnm:False;n:type:ShaderForge.SFN_Vector1,id:1966,x:32082,y:33348,varname:node_1966,prsc:2,v1:2;n:type:ShaderForge.SFN_Multiply,id:4422,x:33009,y:32979,varname:node_4422,prsc:2|A-2645-RGB,B-1354-OUT;n:type:ShaderForge.SFN_Vector1,id:143,x:32608,y:32856,varname:node_143,prsc:2,v1:0.5;n:type:ShaderForge.SFN_Vector1,id:1354,x:32840,y:33186,varname:node_1354,prsc:2,v1:2;n:type:ShaderForge.SFN_Multiply,id:2753,x:33028,y:32756,varname:node_2753,prsc:2|A-1336-OUT,B-4422-OUT;n:type:ShaderForge.SFN_ComponentMask,id:3361,x:32435,y:33413,varname:node_3361,prsc:2,cc1:0,cc2:-1,cc3:-1,cc4:-1;proporder:797-6074-2645;pass:END;sub:END;*/

Shader "Shader Forge/TestParticle2" {
    Properties {
        _TintColor ("Color", Color) = (0.5,0.5,0.5,1)
        _MainTex ("MainTex", 2D) = "white" {}
        _node_2645 ("node_2645", 2D) = "white" {}
        [HideInInspector]_Cutoff ("Alpha cutoff", Range(0,1)) = 0.5
    }
    SubShader {
        Tags {
            "IgnoreProjector"="True"
            "Queue"="Transparent"
            "RenderType"="Transparent"
        }
        Pass {
            Name "FORWARD"
            Tags {
                "LightMode"="ForwardBase"
            }
            Blend SrcAlpha OneMinusSrcAlpha
            ZWrite Off
            
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag
            #define UNITY_PASS_FORWARDBASE
            #include "UnityCG.cginc"
            #pragma multi_compile_fwdbase
            #pragma multi_compile_fog
            #pragma only_renderers d3d9 d3d11 glcore gles 
            #pragma target 3.0
            uniform sampler2D _MainTex; uniform float4 _MainTex_ST;
            uniform float4 _TintColor;
            uniform sampler2D _node_2645; uniform float4 _node_2645_ST;
            struct VertexInput {
                float4 vertex : POSITION;
                float2 texcoord0 : TEXCOORD0;
                float4 vertexColor : COLOR;
            };
            struct VertexOutput {
                float4 pos : SV_POSITION;
                float2 uv0 : TEXCOORD0;
                float4 vertexColor : COLOR;
                UNITY_FOG_COORDS(1)
            };
            VertexOutput vert (VertexInput v) {
                VertexOutput o = (VertexOutput)0;
                o.uv0 = v.texcoord0;
                o.vertexColor = v.vertexColor;
                o.pos = UnityObjectToClipPos( v.vertex );
                UNITY_TRANSFER_FOG(o,o.pos);
                return o;
            }
            float4 frag(VertexOutput i) : COLOR {
////// Lighting:
////// Emissive:
                float4 _node_2645_var = tex2D(_node_2645,TRANSFORM_TEX(i.uv0, _node_2645));
                float3 node_4422 = (_node_2645_var.rgb*2.0);
                float3 emissive = node_4422;
                float3 finalColor = emissive;
                float4 _MainTex_var = tex2D(_MainTex,TRANSFORM_TEX(i.uv0, _MainTex));
                fixed4 finalRGBA = fixed4(finalColor,(_MainTex_var.a*i.vertexColor.a*_TintColor.a));
                UNITY_APPLY_FOG(i.fogCoord, finalRGBA);
                return finalRGBA;
            }
            ENDCG
        }
    }
    CustomEditor "ShaderForgeMaterialInspector"
}
