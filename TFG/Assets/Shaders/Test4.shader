// Shader created with Shader Forge v1.38 
// Shader Forge (c) Neat Corporation / Joachim Holmer - http://www.acegikmo.com/shaderforge/
// Note: Manually altering this data may prevent you from opening it in Shader Forge
/*SF_DATA;ver:1.38;sub:START;pass:START;ps:flbk:,iptp:0,cusa:False,bamd:0,cgin:,lico:1,lgpr:1,limd:3,spmd:1,trmd:0,grmd:0,uamb:True,mssp:True,bkdf:True,hqlp:False,rprd:True,enco:False,rmgx:True,imps:True,rpth:0,vtps:0,hqsc:True,nrmq:1,nrsp:0,vomd:0,spxs:False,tesm:0,olmd:1,culm:0,bsrc:0,bdst:1,dpts:2,wrdp:True,dith:0,atcv:False,rfrpo:True,rfrpn:Refraction,coma:15,ufog:True,aust:True,igpj:False,qofs:0,qpre:1,rntp:1,fgom:False,fgoc:False,fgod:False,fgor:False,fgmd:0,fgcr:0.5,fgcg:0.5,fgcb:0.5,fgca:1,fgde:0.01,fgrn:0,fgrf:300,stcl:False,atwp:False,stva:128,stmr:255,stmw:255,stcp:6,stps:0,stfa:0,stfz:0,ofsf:0,ofsu:0,f2p0:False,fnsp:False,fnfb:False,fsmp:False;n:type:ShaderForge.SFN_Final,id:2865,x:32719,y:32712,varname:node_2865,prsc:2|emission-8879-OUT;n:type:ShaderForge.SFN_Tex2d,id:3274,x:31847,y:32748,ptovrint:False,ptlb:MainTex,ptin:_MainTex,varname:_MainTex_copy,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:True,tagnsco:False,tagnrm:False,ntxv:0,isnm:False;n:type:ShaderForge.SFN_Multiply,id:1993,x:32124,y:32876,cmnt:RGB,varname:node_1993,prsc:2|A-3274-RGB,B-5203-RGB,C-5822-RGB;n:type:ShaderForge.SFN_Color,id:5203,x:31847,y:32980,ptovrint:False,ptlb:Color,ptin:_Color,varname:_Color_copy,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,c1:1,c2:1,c3:1,c4:1;n:type:ShaderForge.SFN_VertexColor,id:5822,x:31863,y:33137,varname:node_5822,prsc:2;n:type:ShaderForge.SFN_Multiply,id:4442,x:32356,y:32876,cmnt:Premultiply Alpha,varname:node_4442,prsc:2|A-1993-OUT,B-8611-OUT;n:type:ShaderForge.SFN_Multiply,id:8611,x:32154,y:33043,cmnt:A,varname:node_8611,prsc:2|A-3274-A,B-5203-A,C-5822-A,D-9918-OUT;n:type:ShaderForge.SFN_Slider,id:1090,x:30882,y:33567,ptovrint:False,ptlb:Displacement,ptin:_Displacement,varname:node_3129,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,min:0,cur:1,max:1;n:type:ShaderForge.SFN_RemapRange,id:6549,x:31398,y:33567,varname:node_6549,prsc:2,frmn:0,frmx:1,tomn:-1,tomx:1|IN-9089-OUT;n:type:ShaderForge.SFN_OneMinus,id:9089,x:31208,y:33555,varname:node_9089,prsc:2|IN-1090-OUT;n:type:ShaderForge.SFN_UVTile,id:3686,x:31292,y:33832,varname:node_3686,prsc:2|UVIN-1759-UVOUT,WDT-9943-OUT,HGT-9943-OUT,TILE-9943-OUT;n:type:ShaderForge.SFN_TexCoord,id:1759,x:31093,y:33794,varname:node_1759,prsc:2,uv:0,uaff:False;n:type:ShaderForge.SFN_Tex2d,id:7648,x:31468,y:33832,ptovrint:False,ptlb:node_7414,ptin:_node_7414,varname:node_7414,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,tex:2831029d8313be24c973a0d12c5f17a2,ntxv:0,isnm:False|UVIN-3686-UVOUT;n:type:ShaderForge.SFN_Add,id:5701,x:31616,y:33596,varname:node_5701,prsc:2|A-6549-OUT,B-7648-RGB;n:type:ShaderForge.SFN_Vector1,id:9943,x:31093,y:33971,varname:node_9943,prsc:2,v1:5;n:type:ShaderForge.SFN_Clamp01,id:9918,x:31797,y:33575,varname:node_9918,prsc:2|IN-5701-OUT;n:type:ShaderForge.SFN_Tex2d,id:7076,x:31566,y:33047,varname:node_1203,prsc:2,tex:1cdba0f9246d05445bfe55b99e8339ab,ntxv:0,isnm:False|TEX-6447-TEX;n:type:ShaderForge.SFN_Tex2dAsset,id:6447,x:31370,y:33259,ptovrint:False,ptlb:node_7526,ptin:_node_7526,varname:node_7526,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,tex:1cdba0f9246d05445bfe55b99e8339ab,ntxv:0,isnm:False;n:type:ShaderForge.SFN_Append,id:5770,x:31355,y:33024,varname:node_5770,prsc:2|A-1654-OUT,B-6713-OUT;n:type:ShaderForge.SFN_Vector1,id:6713,x:31114,y:33243,varname:node_6713,prsc:2,v1:0;n:type:ShaderForge.SFN_RemapRange,id:2765,x:30826,y:32929,varname:node_2765,prsc:2,frmn:0,frmx:1,tomn:-4,tomx:4|IN-9918-OUT;n:type:ShaderForge.SFN_Clamp01,id:6083,x:31009,y:32929,varname:node_6083,prsc:2|IN-2765-OUT;n:type:ShaderForge.SFN_OneMinus,id:1654,x:31166,y:32955,varname:node_1654,prsc:2|IN-6083-OUT;n:type:ShaderForge.SFN_Slider,id:1764,x:31316,y:32623,ptovrint:False,ptlb:ControlDeath,ptin:_ControlDeath,varname:node_1616,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,min:0,cur:0.493608,max:1;n:type:ShaderForge.SFN_Multiply,id:4835,x:31727,y:32560,varname:node_4835,prsc:2|A-1764-OUT,B-6186-OUT;n:type:ShaderForge.SFN_Add,id:8879,x:32533,y:32812,varname:node_8879,prsc:2|A-4835-OUT,B-4442-OUT;n:type:ShaderForge.SFN_Multiply,id:6186,x:31431,y:32788,varname:node_6186,prsc:2|A-7076-RGB,B-8723-OUT;n:type:ShaderForge.SFN_Vector1,id:8723,x:31153,y:32815,varname:node_8723,prsc:2,v1:1.5;n:type:ShaderForge.SFN_Lerp,id:5848,x:31548,y:32265,varname:node_5848,prsc:2|A-9068-UVOUT,B-2269-R,T-7715-OUT;n:type:ShaderForge.SFN_TexCoord,id:9068,x:31227,y:32030,varname:node_9068,prsc:2,uv:0,uaff:False;n:type:ShaderForge.SFN_Tex2d,id:2269,x:31227,y:32264,ptovrint:False,ptlb:node_7414_copy,ptin:_node_7414_copy,varname:_node_7414_copy,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,tex:2831029d8313be24c973a0d12c5f17a2,ntxv:0,isnm:False|UVIN-7426-UVOUT;n:type:ShaderForge.SFN_Panner,id:7426,x:31007,y:32264,varname:node_7426,prsc:2,spu:1,spv:1|UVIN-3890-UVOUT;n:type:ShaderForge.SFN_Slider,id:7715,x:31095,y:32469,ptovrint:False,ptlb:DisplacementDeath,ptin:_DisplacementDeath,varname:node_7057,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,min:0,cur:1,max:1;n:type:ShaderForge.SFN_UVTile,id:3890,x:30872,y:32264,varname:node_3890,prsc:2|WDT-8441-OUT,HGT-8441-OUT,TILE-8441-OUT;n:type:ShaderForge.SFN_Vector1,id:8441,x:30643,y:32339,varname:node_8441,prsc:2,v1:5;n:type:ShaderForge.SFN_Multiply,id:2612,x:32335,y:33091,varname:node_2612,prsc:2;proporder:3274-5203-1090-7648-6447-1764;pass:END;sub:END;*/

Shader "Shader Forge/Test4" {
    Properties {
        [PerRendererData]_MainTex ("MainTex", 2D) = "white" {}
        _Color ("Color", Color) = (1,1,1,1)
        _Displacement ("Displacement", Range(0, 1)) = 1
        _node_7414 ("node_7414", 2D) = "white" {}
        _node_7526 ("node_7526", 2D) = "white" {}
        _ControlDeath ("ControlDeath", Range(0, 1)) = 0.493608
    }
    SubShader {
        Tags {
            "RenderType"="Opaque"
        }
        Pass {
            Name "FORWARD"
            Tags {
                "LightMode"="ForwardBase"
            }
            
            
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag
            #define UNITY_PASS_FORWARDBASE
            #define _GLOSSYENV 1
            #include "UnityCG.cginc"
            #include "UnityPBSLighting.cginc"
            #include "UnityStandardBRDF.cginc"
            #pragma multi_compile_fwdbase_fullshadows
            #pragma multi_compile_fog
            #pragma only_renderers d3d9 d3d11 glcore gles 
            #pragma target 3.0
            uniform sampler2D _MainTex; uniform float4 _MainTex_ST;
            uniform float4 _Color;
            uniform float _Displacement;
            uniform sampler2D _node_7414; uniform float4 _node_7414_ST;
            uniform sampler2D _node_7526; uniform float4 _node_7526_ST;
            uniform float _ControlDeath;
            struct VertexInput {
                float4 vertex : POSITION;
                float3 normal : NORMAL;
                float2 texcoord0 : TEXCOORD0;
                float4 vertexColor : COLOR;
            };
            struct VertexOutput {
                float4 pos : SV_POSITION;
                float2 uv0 : TEXCOORD0;
                float4 posWorld : TEXCOORD1;
                float3 normalDir : TEXCOORD2;
                float4 vertexColor : COLOR;
                UNITY_FOG_COORDS(3)
            };
            VertexOutput vert (VertexInput v) {
                VertexOutput o = (VertexOutput)0;
                o.uv0 = v.texcoord0;
                o.vertexColor = v.vertexColor;
                o.normalDir = UnityObjectToWorldNormal(v.normal);
                o.posWorld = mul(unity_ObjectToWorld, v.vertex);
                o.pos = UnityObjectToClipPos( v.vertex );
                UNITY_TRANSFER_FOG(o,o.pos);
                return o;
            }
            float4 frag(VertexOutput i) : COLOR {
                i.normalDir = normalize(i.normalDir);
                float3 viewDirection = normalize(_WorldSpaceCameraPos.xyz - i.posWorld.xyz);
                float3 normalDirection = i.normalDir;
                float3 viewReflectDirection = reflect( -viewDirection, normalDirection );
////// Lighting:
////// Emissive:
                float4 node_1203 = tex2D(_node_7526,TRANSFORM_TEX(i.uv0, _node_7526));
                float4 _MainTex_var = tex2D(_MainTex,TRANSFORM_TEX(i.uv0, _MainTex));
                float node_9943 = 5.0;
                float2 node_3686_tc_rcp = float2(1.0,1.0)/float2( node_9943, node_9943 );
                float node_3686_ty = floor(node_9943 * node_3686_tc_rcp.x);
                float node_3686_tx = node_9943 - node_9943 * node_3686_ty;
                float2 node_3686 = (i.uv0 + float2(node_3686_tx, node_3686_ty)) * node_3686_tc_rcp;
                float4 _node_7414_var = tex2D(_node_7414,TRANSFORM_TEX(node_3686, _node_7414));
                float3 node_9918 = saturate((((1.0 - _Displacement)*2.0+-1.0)+_node_7414_var.rgb));
                float3 emissive = ((_ControlDeath*(node_1203.rgb*1.5))+((_MainTex_var.rgb*_Color.rgb*i.vertexColor.rgb)*(_MainTex_var.a*_Color.a*i.vertexColor.a*node_9918)));
                float3 finalColor = emissive;
                fixed4 finalRGBA = fixed4(finalColor,1);
                UNITY_APPLY_FOG(i.fogCoord, finalRGBA);
                return finalRGBA;
            }
            ENDCG
        }
        Pass {
            Name "Meta"
            Tags {
                "LightMode"="Meta"
            }
            Cull Off
            
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag
            #define UNITY_PASS_META 1
            #define _GLOSSYENV 1
            #include "UnityCG.cginc"
            #include "UnityPBSLighting.cginc"
            #include "UnityStandardBRDF.cginc"
            #include "UnityMetaPass.cginc"
            #pragma fragmentoption ARB_precision_hint_fastest
            #pragma multi_compile_shadowcaster
            #pragma multi_compile_fog
            #pragma only_renderers d3d9 d3d11 glcore gles 
            #pragma target 3.0
            uniform sampler2D _MainTex; uniform float4 _MainTex_ST;
            uniform float4 _Color;
            uniform float _Displacement;
            uniform sampler2D _node_7414; uniform float4 _node_7414_ST;
            uniform sampler2D _node_7526; uniform float4 _node_7526_ST;
            uniform float _ControlDeath;
            struct VertexInput {
                float4 vertex : POSITION;
                float2 texcoord0 : TEXCOORD0;
                float2 texcoord1 : TEXCOORD1;
                float2 texcoord2 : TEXCOORD2;
                float4 vertexColor : COLOR;
            };
            struct VertexOutput {
                float4 pos : SV_POSITION;
                float2 uv0 : TEXCOORD0;
                float4 vertexColor : COLOR;
            };
            VertexOutput vert (VertexInput v) {
                VertexOutput o = (VertexOutput)0;
                o.uv0 = v.texcoord0;
                o.vertexColor = v.vertexColor;
                o.pos = UnityMetaVertexPosition(v.vertex, v.texcoord1.xy, v.texcoord2.xy, unity_LightmapST, unity_DynamicLightmapST );
                return o;
            }
            float4 frag(VertexOutput i) : SV_Target {
                UnityMetaInput o;
                UNITY_INITIALIZE_OUTPUT( UnityMetaInput, o );
                
                float4 node_1203 = tex2D(_node_7526,TRANSFORM_TEX(i.uv0, _node_7526));
                float4 _MainTex_var = tex2D(_MainTex,TRANSFORM_TEX(i.uv0, _MainTex));
                float node_9943 = 5.0;
                float2 node_3686_tc_rcp = float2(1.0,1.0)/float2( node_9943, node_9943 );
                float node_3686_ty = floor(node_9943 * node_3686_tc_rcp.x);
                float node_3686_tx = node_9943 - node_9943 * node_3686_ty;
                float2 node_3686 = (i.uv0 + float2(node_3686_tx, node_3686_ty)) * node_3686_tc_rcp;
                float4 _node_7414_var = tex2D(_node_7414,TRANSFORM_TEX(node_3686, _node_7414));
                float3 node_9918 = saturate((((1.0 - _Displacement)*2.0+-1.0)+_node_7414_var.rgb));
                o.Emission = ((_ControlDeath*(node_1203.rgb*1.5))+((_MainTex_var.rgb*_Color.rgb*i.vertexColor.rgb)*(_MainTex_var.a*_Color.a*i.vertexColor.a*node_9918)));
                
                float3 diffColor = float3(0,0,0);
                float specularMonochrome;
                float3 specColor;
                diffColor = DiffuseAndSpecularFromMetallic( diffColor, 0, specColor, specularMonochrome );
                o.Albedo = diffColor;
                
                return UnityMetaFragment( o );
            }
            ENDCG
        }
    }
    FallBack "Diffuse"
    CustomEditor "ShaderForgeMaterialInspector"
}
