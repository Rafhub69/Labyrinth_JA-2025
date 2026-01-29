.data

error db 0,0
currentPoint db 0
newMovCostItem db 0,0
tablica DB 10 DUP(0)

.code
SolveLAB proc
    push rbx
    push rdi
    push rbp
    push r12
    push r13
    push r14
    push r15
    
    xor rdi, rdi
    xor rbp, rbp
    xor rbx, rbx; index = 0
    xor rax, rax

    mov dl, [rsp+104]   ;startY
    mov dh, [rsp+96]    ;startX

Mainloop:   
    mov bl, dl          ;First neighbor
    mov bh, dh

    inc bl

    sub bh, [rsp+112]
    sub bl, [rsp+120]
    add bl, bh
    mov ax, bx

    cmp ax,bx
    jge fn
    xchg eax,edx
fn:  
    sub eax, edx

    mov bl, al          ;Second neighbor
    mov bh, ah

    dec bl

    sub bh, [rsp+112]
    sub bl, [rsp+120]
    add bl, bh
    mov ax, bx

    cdq
    xor eax, edx
    sub eax, edx

    cmp ebp, eax
    jna firstIsBigger1
    
Next1:
    mov bl, al          ;Third neighbor
    mov bh, ah

    inc bh

    sub bh, [rsp+112]
    sub bl, [rsp+120]
    add bl, bh
    mov ax, bx

    cdq
    xor eax, edx
    sub eax, edx

cmp ebp, eax
    jna firstIsBigger2
    
Next2:

    mov bl, al          ;Fourth neighbor
    mov bh, ah

    dec bh

    sub bh, [rsp+112]
    sub bl, [rsp+120]
    add bl, bh
    mov ax, bx

    cdq
    xor eax, edx
    sub eax, edx

    cmp ebp, eax
    jna firstIsBigger3
    
Next3:
    cmp r9, 0
    je isOne
    cmp r9, 1
    je isOne
    cmp r9, 2
    je isTwo
    cmp r9, 3
    je isThree

Return:
    inc rbp      
    cmp rbp,rdx   
    jle Mainloop

    movd xmm0, rbx
    movlhps xmm0, xmm0
    addps xmm1, xmm0
    shufps xmm0, xmm0, 93h
    rsqrtss xmm2, xmm0
    minss xmm2, xmm1

    pop r15
    pop r14
    pop r13
    pop r12
    pop rbp
    pop rdi
    pop rbx
ret

firstIsBigger1:
   mov ebp, eax
   mov r9, 1
   jmp Next1
firstIsBigger2:
   mov ebp, eax
   mov r9, 2
   jmp Next2
firstIsBigger3:
   mov ebp, eax
   mov r9, 3
   jmp Next3

isZero:
    mov bl, dl
    mov bh, dh

    inc bl
    mov dl, bl
    mov dh, bh
jmp Return
isOne:
    mov bl, dl
    mov bh, dh

    dec bl
    mov dl, bl
    mov dh, bh
jmp Return

isTwo:
    mov bl, dl
    mov bh, dh

    inc bh
    mov dl, bl
    mov dh, bh
jmp Return

isThree:
    mov bl, dl
    mov bh, dh

    dec bh
    mov dl, bl
    mov dh, bh
jmp Return
SolveLAB endp
end