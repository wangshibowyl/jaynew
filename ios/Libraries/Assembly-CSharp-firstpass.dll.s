#if defined(__arm__)
.text
	.align 3
methods:
	.space 16
	.align 2
Lm_0:
m_IOSUtils__ctor:
_m_0:

	.byte 13,192,160,225,128,64,45,233,13,112,160,225,0,89,45,233,8,208,77,226,13,176,160,225,0,0,139,229,8,208,139,226
	.byte 0,9,189,232,8,112,157,229,0,160,157,232

Lme_0:
	.align 2
Lm_7:
m_IOSUtils_Feedback:
_m_7:

	.byte 13,192,160,225,128,64,45,233,13,112,160,225,0,89,45,233,13,176,160,225
bl p_1

	.byte 0,0,80,227,0,0,0,10
bl p_2

	.byte 0,208,139,226,0,9,189,232,8,112,157,229,0,160,157,232

Lme_7:
	.align 2
Lm_8:
m_IOSUtils_StartLookup_string_string:
_m_8:

	.byte 13,192,160,225,128,64,45,233,13,112,160,225,0,89,45,233,8,208,77,226,13,176,160,225,0,0,139,229,4,16,139,229
bl p_1

	.byte 0,0,80,227,2,0,0,10,0,0,155,229,4,16,155,229
bl p_3

	.byte 8,208,139,226,0,9,189,232,8,112,157,229,0,160,157,232

Lme_8:
	.align 2
Lm_9:
m_IOSUtils_StopLookup:
_m_9:

	.byte 13,192,160,225,128,64,45,233,13,112,160,225,0,89,45,233,13,176,160,225
bl p_1

	.byte 0,0,80,227,0,0,0,10
bl p_4

	.byte 0,208,139,226,0,9,189,232,8,112,157,229,0,160,157,232

Lme_9:
	.align 2
Lm_a:
m_IOSUtils_GetLookupStatus:
_m_a:

	.byte 13,192,160,225,128,64,45,233,13,112,160,225,0,89,45,233,13,176,160,225
bl p_1

	.byte 0,0,80,227,1,0,0,10
bl p_5

	.byte 3,0,0,234,0,0,159,229,0,0,0,234
	.long mono_aot_Assembly_CSharp_firstpass_got - . -4
	.byte 0,0,159,231,0,208,139,226,0,9,189,232,8,112,157,229,0,160,157,232

Lme_a:
	.align 2
Lm_b:
m_IOSUtils_GetServiceNames:
_m_b:

	.byte 13,192,160,225,128,64,45,233,13,112,160,225,64,93,45,233,24,208,77,226,13,176,160,225
bl p_1

	.byte 0,0,80,227,21,0,0,10
bl p_6

	.byte 0,16,160,225,0,0,159,229,0,0,0,234
	.long mono_aot_Assembly_CSharp_firstpass_got - .
	.byte 0,0,159,231
bl p_7

	.byte 0,160,160,225,0,96,160,227,6,0,0,234,6,0,160,225
bl p_8

	.byte 0,32,160,225,10,0,160,225,6,16,160,225
bl p_9

	.byte 1,96,134,226,12,0,154,229,0,0,86,225,245,255,255,186,10,0,160,225,42,0,0,234,0,0,159,229,0,0,0,234
	.long mono_aot_Assembly_CSharp_firstpass_got - .
	.byte 0,0,159,231,4,16,160,227
bl p_7

	.byte 0,16,160,225,20,16,139,229,0,32,159,229,0,0,0,234
	.long mono_aot_Assembly_CSharp_firstpass_got - . + 4
	.byte 2,32,159,231,0,16,160,227
bl p_9

	.byte 20,0,155,229,0,16,160,225,16,16,139,229,0,32,159,229,0,0,0,234
	.long mono_aot_Assembly_CSharp_firstpass_got - . + 8
	.byte 2,32,159,231,1,16,160,227
bl p_9

	.byte 16,0,155,229,0,16,160,225,12,16,139,229,0,32,159,229,0,0,0,234
	.long mono_aot_Assembly_CSharp_firstpass_got - . + 12
	.byte 2,32,159,231,2,16,160,227
bl p_9

	.byte 12,0,155,229,0,16,160,225,8,16,139,229,0,32,159,229,0,0,0,234
	.long mono_aot_Assembly_CSharp_firstpass_got - . + 16
	.byte 2,32,159,231,3,16,160,227
bl p_9

	.byte 8,0,155,229,0,0,139,229,24,208,139,226,64,13,189,232,8,112,157,229,0,160,157,232

Lme_b:
	.align 2
Lm_d:
m_wrapper_managed_to_native_System_Array_GetGenericValueImpl_int_object_:
_m_d:

	.byte 13,192,160,225,240,95,45,233,120,208,77,226,13,176,160,225,0,0,139,229,4,16,139,229,8,32,139,229
bl p_10

	.byte 16,16,141,226,4,0,129,229,0,32,144,229,0,32,129,229,0,16,128,229,16,208,129,229,15,32,160,225,20,32,129,229
	.byte 0,0,155,229,0,0,80,227,16,0,0,10,0,0,155,229,4,16,155,229,8,32,155,229
bl p_11

	.byte 0,0,159,229,0,0,0,234
	.long mono_aot_Assembly_CSharp_firstpass_got - . + 20
	.byte 0,0,159,231,0,0,144,229,0,0,80,227,10,0,0,26,16,32,139,226,0,192,146,229,4,224,146,229,0,192,142,229
	.byte 104,208,130,226,240,175,157,232,39,0,160,227,1,12,128,226,2,4,128,226
bl p_12
bl p_13
bl p_14

	.byte 242,255,255,234

Lme_d:
	.align 2
Lm_e:
m_wrapper_managed_to_native_IOSUtils__Feedback:
_m_e:

	.byte 13,192,160,225,240,95,45,233,104,208,77,226,13,176,160,225
bl p_10

	.byte 0,16,141,226,4,0,129,229,0,32,144,229,0,32,129,229,0,16,128,229,16,208,129,229,15,32,160,225,20,32,129,229
bl p_15

	.byte 0,0,159,229,0,0,0,234
	.long mono_aot_Assembly_CSharp_firstpass_got - . + 20
	.byte 0,0,159,231,0,0,144,229,0,0,80,227,5,0,0,26,0,32,139,226,0,192,146,229,4,224,146,229,0,192,142,229
	.byte 104,208,130,226,240,175,157,232
bl p_14

	.byte 247,255,255,234

Lme_e:
	.align 2
Lm_f:
m_wrapper_managed_to_native_IOSUtils__StartLookup_string_string:
_m_f:

	.byte 13,192,160,225,240,95,45,233,104,208,77,226,13,176,160,225,0,96,160,225,1,160,160,225
bl p_10

	.byte 0,16,141,226,4,0,129,229,0,32,144,229,0,32,129,229,0,16,128,229,16,208,129,229,15,32,160,225,20,32,129,229
	.byte 6,0,160,225
bl p_16

	.byte 0,96,160,225,10,0,160,225
bl p_16

	.byte 0,160,160,225,6,0,160,225,10,16,160,225
bl p_17

	.byte 0,0,159,229,0,0,0,234
	.long mono_aot_Assembly_CSharp_firstpass_got - . + 20
	.byte 0,0,159,231,0,0,144,229,0,0,80,227,9,0,0,26,6,0,160,225
bl p_18

	.byte 10,0,160,225
bl p_18

	.byte 0,32,139,226,0,192,146,229,4,224,146,229,0,192,142,229,104,208,130,226,240,175,157,232
bl p_14

	.byte 243,255,255,234

Lme_f:
	.align 2
Lm_10:
m_wrapper_managed_to_native_IOSUtils__GetLookupStatus:
_m_10:

	.byte 13,192,160,225,240,95,45,233,120,208,77,226,13,176,160,225
bl p_10

	.byte 16,16,141,226,4,0,129,229,0,32,144,229,0,32,129,229,0,16,128,229,16,208,129,229,15,32,160,225,20,32,129,229
bl p_19

	.byte 8,0,139,229
bl p_20

	.byte 0,16,160,225,8,0,155,229,0,16,139,229
bl p_18

	.byte 0,0,159,229,0,0,0,234
	.long mono_aot_Assembly_CSharp_firstpass_got - . + 20
	.byte 0,0,159,231,0,0,144,229,0,0,80,227,6,0,0,26,0,0,155,229,16,32,139,226,0,192,146,229,4,224,146,229
	.byte 0,192,142,229,104,208,130,226,240,175,157,232
bl p_14

	.byte 246,255,255,234

Lme_10:
	.align 2
Lm_11:
m_wrapper_managed_to_native_IOSUtils__GetServiceCount:
_m_11:

	.byte 13,192,160,225,240,95,45,233,112,208,77,226,13,176,160,225
bl p_10

	.byte 8,16,141,226,4,0,129,229,0,32,144,229,0,32,129,229,0,16,128,229,16,208,129,229,15,32,160,225,20,32,129,229
bl p_21

	.byte 0,0,139,229,0,0,159,229,0,0,0,234
	.long mono_aot_Assembly_CSharp_firstpass_got - . + 20
	.byte 0,0,159,231,0,0,144,229,0,0,80,227,6,0,0,26,0,0,155,229,8,32,139,226,0,192,146,229,4,224,146,229
	.byte 0,192,142,229,104,208,130,226,240,175,157,232
bl p_14

	.byte 246,255,255,234

Lme_11:
	.align 2
Lm_12:
m_wrapper_managed_to_native_IOSUtils__Stop:
_m_12:

	.byte 13,192,160,225,240,95,45,233,104,208,77,226,13,176,160,225
bl p_10

	.byte 0,16,141,226,4,0,129,229,0,32,144,229,0,32,129,229,0,16,128,229,16,208,129,229,15,32,160,225,20,32,129,229
bl p_22

	.byte 0,0,159,229,0,0,0,234
	.long mono_aot_Assembly_CSharp_firstpass_got - . + 20
	.byte 0,0,159,231,0,0,144,229,0,0,80,227,5,0,0,26,0,32,139,226,0,192,146,229,4,224,146,229,0,192,142,229
	.byte 104,208,130,226,240,175,157,232
bl p_14

	.byte 247,255,255,234

Lme_12:
	.align 2
Lm_13:
m_wrapper_managed_to_native_IOSUtils__GetServiceName_int:
_m_13:

	.byte 13,192,160,225,240,95,45,233,112,208,77,226,13,176,160,225,0,160,160,225
bl p_10

	.byte 8,16,141,226,4,0,129,229,0,32,144,229,0,32,129,229,0,16,128,229,16,208,129,229,15,32,160,225,20,32,129,229
	.byte 10,0,160,225
bl p_23

	.byte 0,0,139,229
bl p_20

	.byte 0,160,160,225,0,0,155,229
bl p_18

	.byte 0,0,159,229,0,0,0,234
	.long mono_aot_Assembly_CSharp_firstpass_got - . + 20
	.byte 0,0,159,231,0,0,144,229,0,0,80,227,6,0,0,26,10,0,160,225,8,32,139,226,0,192,146,229,4,224,146,229
	.byte 0,192,142,229,104,208,130,226,240,175,157,232
bl p_14

	.byte 246,255,255,234

Lme_13:
.text
	.align 3
method_addresses:
	.align 2
	.long _m_0
	.align 2
	.long 0
	.align 2
	.long 0
	.align 2
	.long 0
	.align 2
	.long 0
	.align 2
	.long 0
	.align 2
	.long 0
	.align 2
	.long _m_7
	.align 2
	.long _m_8
	.align 2
	.long _m_9
	.align 2
	.long _m_a
	.align 2
	.long _m_b
	.align 2
	.long 0
	.align 2
	.long _m_d
	.align 2
	.long _m_e
	.align 2
	.long _m_f
	.align 2
	.long _m_10
	.align 2
	.long _m_11
	.align 2
	.long _m_12
	.align 2
	.long _m_13
.text
	.align 3
methods_end:
.text
	.align 3
method_offsets:

	.long Lm_0 - methods,-1,-1,-1,-1,-1,-1,Lm_7 - methods
	.long Lm_8 - methods,Lm_9 - methods,Lm_a - methods,Lm_b - methods,-1,Lm_d - methods,Lm_e - methods,Lm_f - methods
	.long Lm_10 - methods,Lm_11 - methods,Lm_12 - methods,Lm_13 - methods

.text
	.align 3
method_info:
mi:
Lm_0_p:

	.byte 0,0
Lm_7_p:

	.byte 0,0
Lm_8_p:

	.byte 0,0
Lm_9_p:

	.byte 0,0
Lm_a_p:

	.byte 0,1,2
Lm_b_p:

	.byte 0,6,3,3,4,5,6,7
Lm_d_p:

	.byte 0,1,8
Lm_e_p:

	.byte 0,1,8
Lm_f_p:

	.byte 0,1,8
Lm_10_p:

	.byte 0,1,8
Lm_11_p:

	.byte 0,1,8
Lm_12_p:

	.byte 0,1,8
Lm_13_p:

	.byte 0,1,8
.text
	.align 3
method_info_offsets:

	.long Lm_0_p - mi,0,0,0,0,0,0,Lm_7_p - mi
	.long Lm_8_p - mi,Lm_9_p - mi,Lm_a_p - mi,Lm_b_p - mi,0,Lm_d_p - mi,Lm_e_p - mi,Lm_f_p - mi
	.long Lm_10_p - mi,Lm_11_p - mi,Lm_12_p - mi,Lm_13_p - mi

.text
	.align 3
extra_method_info:

	.byte 0,1,6,83,121,115,116,101,109,46,65,114,114,97,121,58,71,101,116,71,101,110,101,114,105,99,86,97,108,117,101,73
	.byte 109,112,108,32,40,105,110,116,44,111,98,106,101,99,116,38,41,0,1,6,73,79,83,85,116,105,108,115,58,95,70,101
	.byte 101,100,98,97,99,107,32,40,41,0,1,6,73,79,83,85,116,105,108,115,58,95,83,116,97,114,116,76,111,111,107,117
	.byte 112,32,40,115,116,114,105,110,103,44,115,116,114,105,110,103,41,0,1,6,73,79,83,85,116,105,108,115,58,95,71,101
	.byte 116,76,111,111,107,117,112,83,116,97,116,117,115,32,40,41,0,1,6,73,79,83,85,116,105,108,115,58,95,71,101,116
	.byte 83,101,114,118,105,99,101,67,111,117,110,116,32,40,41,0,1,6,73,79,83,85,116,105,108,115,58,95,83,116,111,112
	.byte 32,40,41,0,1,6,73,79,83,85,116,105,108,115,58,95,71,101,116,83,101,114,118,105,99,101,78,97,109,101,32,40
	.byte 105,110,116,41,0

.text
	.align 3
extra_method_table:

	.long 11,0,0,0,1,13,0,74
	.long 15,0,196,19,0,0,0,0
	.long 114,16,0,0,0,0,0,0
	.long 0,50,14,11,176,18,0,0
	.long 0,0,145,17,0
.text
	.align 3
extra_method_info_offsets:

	.long 7,13,1,14,50,15,74,16
	.long 114,17,145,18,176,19,196
.text
	.align 3
method_order:

	.long 0,16777215,0,7,8,9,10,11
	.long 13,14,15,16,17,18,19

.text
method_order_end:
.text
	.align 3
class_name_table:

	.short 11, 1, 11, 0, 0, 0, 0, 0
	.short 0, 0, 0, 0, 0, 0, 0, 0
	.short 0, 0, 0, 0, 0, 0, 0, 2
	.short 0
.text
	.align 3
got_info:

	.byte 12,0,39,17,0,1,14,194,0,0,0,1,1,130,110,1,17,0,11,17,0,31,17,0,51,17,0,71,33,3,194,0
	.byte 0,163,3,2,3,3,3,6,3,4,3,5,7,23,109,111,110,111,95,97,114,114,97,121,95,110,101,119,95,115,112,101
	.byte 99,105,102,105,99,0,3,7,3,255,253,0,0,0,21,7,17,109,111,110,111,95,103,101,116,95,108,109,102,95,97,100
	.byte 100,114,0,31,255,254,0,0,0,60,1,1,198,0,1,96,0,1,1,129,42,1,7,30,109,111,110,111,95,99,114,101
	.byte 97,116,101,95,99,111,114,108,105,98,95,101,120,99,101,112,116,105,111,110,95,48,0,7,25,109,111,110,111,95,97,114
	.byte 99,104,95,116,104,114,111,119,95,101,120,99,101,112,116,105,111,110,0,7,35,109,111,110,111,95,116,104,114,101,97,100
	.byte 95,105,110,116,101,114,114,117,112,116,105,111,110,95,99,104,101,99,107,112,111,105,110,116,0,31,2,7,20,109,111,110
	.byte 111,95,115,116,114,105,110,103,95,116,111,95,108,112,115,116,114,0,31,3,7,17,109,111,110,111,95,109,97,114,115,104
	.byte 97,108,95,102,114,101,101,0,31,4,7,23,109,111,110,111,95,115,116,114,105,110,103,95,110,101,119,95,119,114,97,112
	.byte 112,101,114,0,31,5,31,6,31,7
.text
	.align 3
got_info_offsets:

	.long 0,2,3,6,16,19,22,25
	.long 28
.text
	.align 3
ex_info:
ex:
Le_0_p:

	.byte 44,2,0,0
Le_7_p:

	.byte 52,2,26,0
Le_8_p:

	.byte 72,2,0,0
Le_9_p:

	.byte 52,2,26,0
Le_a_p:

	.byte 72,2,26,0
Le_b_p:

	.byte 129,56,2,49,0
Le_d_p:

	.byte 128,172,2,79,0
Le_e_p:

	.byte 116,2,113,0
Le_f_p:

	.byte 128,172,2,113,0
Le_10_p:

	.byte 128,144,2,79,0
Le_11_p:

	.byte 124,2,128,147,0
Le_12_p:

	.byte 116,2,113,0
Le_13_p:

	.byte 128,148,2,128,147,0
.text
	.align 3
ex_info_offsets:

	.long Le_0_p - ex,0,0,0,0,0,0,Le_7_p - ex
	.long Le_8_p - ex,Le_9_p - ex,Le_a_p - ex,Le_b_p - ex,0,Le_d_p - ex,Le_e_p - ex,Le_f_p - ex
	.long Le_10_p - ex,Le_11_p - ex,Le_12_p - ex,Le_13_p - ex

.text
	.align 3
unwind_info:

	.byte 25,12,13,0,76,14,8,135,2,68,14,24,136,6,139,5,140,4,142,3,68,14,32,68,13,11,22,12,13,0,76,14
	.byte 8,135,2,68,14,24,136,6,139,5,140,4,142,3,68,13,11,29,12,13,0,76,14,8,135,2,68,14,32,134,8,136
	.byte 7,138,6,139,5,140,4,142,3,68,14,56,68,13,11,33,12,13,0,72,14,40,132,10,133,9,134,8,135,7,136,6
	.byte 137,5,138,4,139,3,140,2,142,1,68,14,160,1,68,13,11,33,12,13,0,72,14,40,132,10,133,9,134,8,135,7
	.byte 136,6,137,5,138,4,139,3,140,2,142,1,68,14,144,1,68,13,11,33,12,13,0,72,14,40,132,10,133,9,134,8
	.byte 135,7,136,6,137,5,138,4,139,3,140,2,142,1,68,14,152,1,68,13,11
.text
	.align 3
class_info:
LK_I_0:

	.byte 0,128,144,8,0,0,1
LK_I_1:

	.byte 4,128,144,8,0,0,1,193,0,11,58,193,0,11,55,193,0,11,54,193,0,11,52
.text
	.align 3
class_info_offsets:

	.long LK_I_0 - class_info,LK_I_1 - class_info


.text
	.align 4
plt:
mono_aot_Assembly_CSharp_firstpass_plt:

	.byte 0,192,159,229,12,240,159,231
	.long mono_aot_Assembly_CSharp_firstpass_got - . + 32,0
p_1:
plt_UnityEngine_Application_get_platform:

	.byte 0,192,159,229,12,240,159,231
	.long mono_aot_Assembly_CSharp_firstpass_got - . + 36,29
p_2:
plt_IOSUtils__Feedback:

	.byte 0,192,159,229,12,240,159,231
	.long mono_aot_Assembly_CSharp_firstpass_got - . + 40,34
p_3:
plt_IOSUtils__StartLookup_string_string:

	.byte 0,192,159,229,12,240,159,231
	.long mono_aot_Assembly_CSharp_firstpass_got - . + 44,36
p_4:
plt_IOSUtils__Stop:

	.byte 0,192,159,229,12,240,159,231
	.long mono_aot_Assembly_CSharp_firstpass_got - . + 48,38
p_5:
plt_IOSUtils__GetLookupStatus:

	.byte 0,192,159,229,12,240,159,231
	.long mono_aot_Assembly_CSharp_firstpass_got - . + 52,40
p_6:
plt_IOSUtils__GetServiceCount:

	.byte 0,192,159,229,12,240,159,231
	.long mono_aot_Assembly_CSharp_firstpass_got - . + 56,42
p_7:
plt__jit_icall_mono_array_new_specific:

	.byte 0,192,159,229,12,240,159,231
	.long mono_aot_Assembly_CSharp_firstpass_got - . + 60,44
p_8:
plt_IOSUtils__GetServiceName_int:

	.byte 0,192,159,229,12,240,159,231
	.long mono_aot_Assembly_CSharp_firstpass_got - . + 64,70
p_9:
plt_wrapper_stelemref_object_stelemref_object_intptr_object:

	.byte 0,192,159,229,12,240,159,231
	.long mono_aot_Assembly_CSharp_firstpass_got - . + 68,72
p_10:
plt__jit_icall_mono_get_lmf_addr:

	.byte 0,192,159,229,12,240,159,231
	.long mono_aot_Assembly_CSharp_firstpass_got - . + 72,79
p_11:
plt__icall_native_System_Array_GetGenericValueImpl_object_int_object_:

	.byte 0,192,159,229,12,240,159,231
	.long mono_aot_Assembly_CSharp_firstpass_got - . + 76,99
p_12:
plt__jit_icall_mono_create_corlib_exception_0:

	.byte 0,192,159,229,12,240,159,231
	.long mono_aot_Assembly_CSharp_firstpass_got - . + 80,118
p_13:
plt__jit_icall_mono_arch_throw_exception:

	.byte 0,192,159,229,12,240,159,231
	.long mono_aot_Assembly_CSharp_firstpass_got - . + 84,151
p_14:
plt__jit_icall_mono_thread_interruption_checkpoint:

	.byte 0,192,159,229,12,240,159,231
	.long mono_aot_Assembly_CSharp_firstpass_got - . + 88,179
p_15:
plt__icall_native_IOSUtils__Feedback:

	.byte 0,192,159,229,12,240,159,231
	.long mono_aot_Assembly_CSharp_firstpass_got - . + 92,217
p_16:
plt__jit_icall_mono_string_to_lpstr:

	.byte 0,192,159,229,12,240,159,231
	.long mono_aot_Assembly_CSharp_firstpass_got - . + 96,219
p_17:
plt__icall_native_IOSUtils__StartLookup_string_string:

	.byte 0,192,159,229,12,240,159,231
	.long mono_aot_Assembly_CSharp_firstpass_got - . + 100,242
p_18:
plt__jit_icall_mono_marshal_free:

	.byte 0,192,159,229,12,240,159,231
	.long mono_aot_Assembly_CSharp_firstpass_got - . + 104,244
p_19:
plt__icall_native_IOSUtils__GetLookupStatus:

	.byte 0,192,159,229,12,240,159,231
	.long mono_aot_Assembly_CSharp_firstpass_got - . + 108,264
p_20:
plt__jit_icall_mono_string_new_wrapper:

	.byte 0,192,159,229,12,240,159,231
	.long mono_aot_Assembly_CSharp_firstpass_got - . + 112,266
p_21:
plt__icall_native_IOSUtils__GetServiceCount:

	.byte 0,192,159,229,12,240,159,231
	.long mono_aot_Assembly_CSharp_firstpass_got - . + 116,292
p_22:
plt__icall_native_IOSUtils__Stop:

	.byte 0,192,159,229,12,240,159,231
	.long mono_aot_Assembly_CSharp_firstpass_got - . + 120,294
p_23:
plt__icall_native_IOSUtils__GetServiceName_int:

	.byte 0,192,159,229,12,240,159,231
	.long mono_aot_Assembly_CSharp_firstpass_got - . + 124,296
plt_end:
.text
	.align 3
mono_image_table:

	.long 3
	.asciz "Assembly-CSharp-firstpass"
	.asciz "13088D47-DBFB-495F-B099-5EDB2DC020B2"
	.asciz ""
	.asciz ""
	.align 3

	.long 0,0,0,0,0
	.asciz "mscorlib"
	.asciz "27644DE5-9E07-4BB4-8287-2B902F36EADC"
	.asciz ""
	.asciz "7cec85d7bea7798e"
	.align 3

	.long 1,2,0,5,0
	.asciz "UnityEngine"
	.asciz "8A430BBC-5FF5-4323-A7BA-8DD059694AF8"
	.asciz ""
	.asciz ""
	.align 3

	.long 0,0,0,0,0
.data
	.align 3
mono_aot_Assembly_CSharp_firstpass_got:
	.space 132
got_end:
.data
	.align 3
mono_aot_got_addr:
	.align 2
	.long mono_aot_Assembly_CSharp_firstpass_got
.data
	.align 3
mono_aot_file_info:

	.long 9,132,24,20,1024,1024,128,0
	.long 0,0,0,0,0
.text
	.align 2
mono_assembly_guid:
	.asciz "13088D47-DBFB-495F-B099-5EDB2DC020B2"
.text
	.align 2
mono_aot_version:
	.asciz "66"
.text
	.align 2
mono_aot_opt_flags:
	.asciz "55650815"
.text
	.align 2
mono_aot_full_aot:
	.asciz "TRUE"
.text
	.align 2
mono_runtime_version:
	.asciz ""
.text
	.align 2
mono_aot_assembly_name:
	.asciz "Assembly-CSharp-firstpass"
.text
	.align 3
Lglobals_hash:

	.short 73, 27, 0, 0, 0, 0, 0, 0
	.short 0, 15, 0, 19, 0, 0, 0, 0
	.short 0, 6, 0, 0, 0, 2, 0, 0
	.short 0, 0, 0, 0, 0, 0, 0, 29
	.short 0, 13, 0, 5, 0, 0, 0, 0
	.short 0, 4, 0, 28, 0, 0, 0, 9
	.short 0, 0, 0, 0, 0, 0, 0, 14
	.short 0, 1, 0, 0, 0, 0, 0, 12
	.short 74, 0, 0, 0, 0, 0, 0, 30
	.short 0, 3, 75, 0, 0, 0, 0, 0
	.short 0, 0, 0, 0, 0, 0, 0, 0
	.short 0, 22, 0, 0, 0, 0, 0, 0
	.short 0, 11, 0, 17, 0, 8, 0, 0
	.short 0, 0, 0, 0, 0, 0, 0, 0
	.short 0, 0, 0, 0, 0, 0, 0, 0
	.short 0, 0, 0, 0, 0, 16, 0, 20
	.short 0, 7, 73, 24, 0, 10, 0, 0
	.short 0, 0, 0, 0, 0, 0, 0, 0
	.short 0, 21, 0, 18, 76, 23, 0, 25
	.short 0, 26, 0
.text
	.align 2
name_0:
	.asciz "methods"
.text
	.align 2
name_1:
	.asciz "method_addresses"
.text
	.align 2
name_2:
	.asciz "methods_end"
.text
	.align 2
name_3:
	.asciz "method_offsets"
.text
	.align 2
name_4:
	.asciz "method_info"
.text
	.align 2
name_5:
	.asciz "method_info_offsets"
.text
	.align 2
name_6:
	.asciz "extra_method_info"
.text
	.align 2
name_7:
	.asciz "extra_method_table"
.text
	.align 2
name_8:
	.asciz "extra_method_info_offsets"
.text
	.align 2
name_9:
	.asciz "method_order"
.text
	.align 2
name_10:
	.asciz "method_order_end"
.text
	.align 2
name_11:
	.asciz "class_name_table"
.text
	.align 2
name_12:
	.asciz "got_info"
.text
	.align 2
name_13:
	.asciz "got_info_offsets"
.text
	.align 2
name_14:
	.asciz "ex_info"
.text
	.align 2
name_15:
	.asciz "ex_info_offsets"
.text
	.align 2
name_16:
	.asciz "unwind_info"
.text
	.align 2
name_17:
	.asciz "class_info"
.text
	.align 2
name_18:
	.asciz "class_info_offsets"
.text
	.align 2
name_19:
	.asciz "plt"
.text
	.align 2
name_20:
	.asciz "plt_end"
.text
	.align 2
name_21:
	.asciz "mono_image_table"
.text
	.align 2
name_22:
	.asciz "mono_aot_got_addr"
.text
	.align 2
name_23:
	.asciz "mono_aot_file_info"
.text
	.align 2
name_24:
	.asciz "mono_assembly_guid"
.text
	.align 2
name_25:
	.asciz "mono_aot_version"
.text
	.align 2
name_26:
	.asciz "mono_aot_opt_flags"
.text
	.align 2
name_27:
	.asciz "mono_aot_full_aot"
.text
	.align 2
name_28:
	.asciz "mono_runtime_version"
.text
	.align 2
name_29:
	.asciz "mono_aot_assembly_name"
.data
	.align 3
Lglobals:
	.align 2
	.long Lglobals_hash
	.align 2
	.long name_0
	.align 2
	.long methods
	.align 2
	.long name_1
	.align 2
	.long method_addresses
	.align 2
	.long name_2
	.align 2
	.long methods_end
	.align 2
	.long name_3
	.align 2
	.long method_offsets
	.align 2
	.long name_4
	.align 2
	.long method_info
	.align 2
	.long name_5
	.align 2
	.long method_info_offsets
	.align 2
	.long name_6
	.align 2
	.long extra_method_info
	.align 2
	.long name_7
	.align 2
	.long extra_method_table
	.align 2
	.long name_8
	.align 2
	.long extra_method_info_offsets
	.align 2
	.long name_9
	.align 2
	.long method_order
	.align 2
	.long name_10
	.align 2
	.long method_order_end
	.align 2
	.long name_11
	.align 2
	.long class_name_table
	.align 2
	.long name_12
	.align 2
	.long got_info
	.align 2
	.long name_13
	.align 2
	.long got_info_offsets
	.align 2
	.long name_14
	.align 2
	.long ex_info
	.align 2
	.long name_15
	.align 2
	.long ex_info_offsets
	.align 2
	.long name_16
	.align 2
	.long unwind_info
	.align 2
	.long name_17
	.align 2
	.long class_info
	.align 2
	.long name_18
	.align 2
	.long class_info_offsets
	.align 2
	.long name_19
	.align 2
	.long plt
	.align 2
	.long name_20
	.align 2
	.long plt_end
	.align 2
	.long name_21
	.align 2
	.long mono_image_table
	.align 2
	.long name_22
	.align 2
	.long mono_aot_got_addr
	.align 2
	.long name_23
	.align 2
	.long mono_aot_file_info
	.align 2
	.long name_24
	.align 2
	.long mono_assembly_guid
	.align 2
	.long name_25
	.align 2
	.long mono_aot_version
	.align 2
	.long name_26
	.align 2
	.long mono_aot_opt_flags
	.align 2
	.long name_27
	.align 2
	.long mono_aot_full_aot
	.align 2
	.long name_28
	.align 2
	.long mono_runtime_version
	.align 2
	.long name_29
	.align 2
	.long mono_aot_assembly_name

	.long 0,0
	.globl _mono_aot_module_Assembly_CSharp_firstpass_info
	.align 3
_mono_aot_module_Assembly_CSharp_firstpass_info:
	.align 2
	.long Lglobals
.text
	.align 3
mem_end:
#endif
