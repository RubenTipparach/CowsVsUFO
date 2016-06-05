Shader "Unlit/SuperSimpleVertexShader"
{

 Properties {
 }
     SubShader {
			 ZWrite Off
			 Blend SrcAlpha OneMinusSrcAlpha
             Pass {
                     ColorMaterial AmbientAndDiffuse
             }
     } 
 
}
