/*
CORS (security)

O padrão Cross-Origin Resource Sharing trabalha adicionando novos cabeçalhos HTTP
 que permitem que os servidores descrevam um conjunto de origens que possuem 
 permissão a ler uma informação usando o navegador. 

    Senha:
    - Criptografia simétrica
        Os dois lados precisam de uma mesma chave para a criptografia, por isso simétrica (AES)

    - Hashing
        Pega um texto e transfoma em outro menor
        * vários podem chegar na mesma saída => não reversível
    
    - Salting 
        hasing = senha + salt 
    
    - Slow Hash
        ALgoritmo de hash só que lento, muitas contas matemáticas propositalmente lentas
        * Bcrypt
        * Scrypt
    
    * Eavesdroppping
    * Man in the middle: consegue alterar os dados enviados

    - Criptografia Assimétrica (RSA)
        Duas chaves: uma de criptografia (pública) e uma de descritografia (privada)

    - HTTPS
        Criptografa toda a comunicação no canal entre você e o servidor (mistura simétrica e assimétrica) 
    
    - Tolken de Autentificação
    - JWT
        Assinatura Digital
        * não pode modificar a mensagem e nem criar uma nova
*/