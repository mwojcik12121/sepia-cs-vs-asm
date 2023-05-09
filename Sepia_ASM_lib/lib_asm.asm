;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;
;;
;;	Project: "Sepia"
;;	Author: Marta Wójcik
;;	Date: 02.02.2023, 5th term, year 2022/2023
;;
;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;

.data
n dq ?							; number of pixels
intensity dd ?					; intensity of the effect
zero dd 0						; to clear the xmm2
i dd ?							; loop variable
product dd ?					; single product
original_value dd ?				; to handle intensity application
byte_max_value dd 255			; if sum of products is > 255, then assign 255

.code

convert_asm proc

 MOVQ R10, xmm6					; Save xmm6 value
 MOVHLPS xmm6, xmm6
 MOVQ R11, xmm6

 mov n, R8						; Number of pixels. Variable later used in loops
 VMOVUPS xmm4, [R9]				; Factors for blue
 VMOVUPS xmm5, [R9 + 12]		; Factors for green
 VMOVUPS xmm6, [R9 + 24]		; Factors for red
 MOVSS intensity, xmm0			; Intensity of the effect
  
iterate_over_pixels:			; Main loop to iterate over pixels
 cmp n, 1 
 jle iterate_over_pixels_done
 sub n, 1

; Place in XMM0 3 subsequent floating point values, each of them representing single color (B, G, R)
 MOVUPS xmm0, [rcx]

; New blue
 VMULPS xmm1, xmm0, xmm4		; Multiply color values by proper factors 

; Add products
 MOVUPS [rdx], xmm1				; Move floats representing colors to memory
 mov i, 3						; Init loop variable
 cvtsi2ss xmm2, zero			; Clear the xmm2, which will hold the sum of products
 
add_products_b:
 cmp i, 0
 jle add_products_done_b
 sub i, 1
 mov eax, [rdx]
 mov product, eax
 ADDSS xmm2, product
 ADD rdx, 4
 JMP add_products_b

add_products_done_b:
 sub rdx, 12					; Restore rdx

cvtsi2ss xmm3, byte_max_value	; If sum of products is > 255, then assign 255 (XMM3 holds 255)
MINPS xmm2, xmm3

; Apply intensity
mov eax, [rcx]					; Copy original value
mov original_value, eax
SUBSS xmm2, original_value		; Calculate the difference between new value and original value
MULSS xmm2, intensity			; Multiply the difference by intensity
ADDSS xmm2, original_value		; Add the product to the original value

 MOVUPS [rdx], xmm2				; Place new color in memory (pointed by newRgbValuesFloat in HL)

; New green
 VMULPS xmm1, xmm0, xmm5		; Multiply color values by proper factor 

; Add products
 MOVUPS [rdx + 4], xmm1			; Move floats representing colors to memory
 mov i, 3						; Init loop variable
 cvtsi2ss xmm2, zero			; Clear the xmm2, which will hold the sum of products
 
add_products_g:
 cmp i, 0
 jle add_products_done_g
 sub i, 1
 mov eax, [rdx + 4]
 mov product, eax
 ADDSS xmm2, product
 ADD rdx, 4
 JMP add_products_g

add_products_done_g:
 sub rdx, 12					; Restore rdx

cvtsi2ss xmm3, byte_max_value	; If sum of products is > 255, then assign 255 (XMM3 holds 255)
MINPS xmm2, xmm3

; Apply intensity
mov eax, [rcx + 4]				; Copy original value
mov original_value, eax
SUBSS xmm2, original_value		; Calculate the difference between new value and original value
MULSS xmm2, intensity			; Multiply the difference by intensity
ADDSS xmm2, original_value		; Add the product to the original value

 MOVUPS [rdx + 4], xmm2			; Place new color in memory (pointed by newRgbValuesFloat in HL)

; New red
 VMULPS xmm1, xmm0, xmm6		; Multiply color values by proper factors 

; Add products
 MOVUPS [rdx + 8], xmm1			; Move floats representing colors to memory
 mov i, 3						; Init loop variable
 cvtsi2ss xmm2, zero			; Clear the xmm2, which will hold the sum of products
 
add_products_r:
 cmp i, 0
 jle add_products_done_r
 sub i, 1
 mov eax, [rdx + 8]
 mov product, eax
 ADDSS xmm2, product
 ADD rdx, 4
 JMP add_products_r

add_products_done_r:
 sub rdx, 12					; Restore rdx

cvtsi2ss xmm3, byte_max_value	; If sum of products is > 255, then assign 255 (XMM3 holds 255)
MINPS xmm2, xmm3

; Apply intensity
mov eax, [rcx + 8]				; Copy original value
mov original_value, eax
SUBSS xmm2, original_value		; Calculate the difference between new value and original value
MULSS xmm2, intensity			; Multiply the difference by intensity
ADDSS xmm2, original_value		; Add the product to the original value

 MOVUPS [rdx + 8], xmm2			; Place new color in memory (pointed by newRgbValuesFloat in HL)

 add rcx, 12					; Point to the next pixel
 add rdx, 12

 JMP iterate_over_pixels

iterate_over_pixels_done:		; End of conversion

 MOVQ xmm6, R11					; Restore xmm6 value
 MOVLHPS xmm6, xmm6
 MOVQ R10, xmm6

ret

convert_asm endp
end