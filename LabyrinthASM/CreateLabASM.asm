.code
CreateLAB proc
    push rdi
    push rbx

    xor rdi, rdi    ; index = 0
    add rdi, 2      ; index = 2
    xor r10, r10

loopThird:
    mov bl, [r8 + rdi]
    and bl, 11001111b
    RDRAND rax
    and al, 00110000b
    cmp al, 48
    jne checkIsEmpty
NextNumber:
    or al, bl
    mov [r8 + rdi], al

    add rdi, r9
    cmp rdi, rdx
    jl loopThird

    pop rbx
    pop rdi
    mov rax,rdi
    ret

checkIsEmpty:
    cmp al, 0
    je NextNumber
    cmp al, 00010000b
    je setWall
    mov al, 00000000b
    JMP NextNumber

setWall:
    mov al, 00110000b
    JMP NextNumber
CreateLAB endp
end