using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movimentacao : MonoBehaviour
{
    private CharacterController character;
    private Animator animator;
    private Vector3 input;
    public float velocidade = 5f;

    // Start is called before the first frame update
    void Start()
    {
        character = GetComponent<CharacterController>();
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        //Setando valores no vector3 de acordo com o que é enviado pelo jogador através de controles(teclado, touch ou controle)
        input.Set(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));

        // aqui estamos utilizando o vector 3 para setar a nova posição do personagem a cada frame onde o botão é pressionado x um tempo x uma velocida
        character.Move(input * Time.deltaTime * velocidade);

        //Para simular uma gravidade no personagem vamos colocar uma força empurrando para baixo
        character.Move(Vector3.down * Time.deltaTime);

        //baseado nos inputs serem diferentes de zero vamos tomar algumas ações para a movimentação do personagem
        if(input != Vector3.zero){
            //Se o valor for diferente de zero, vamos passar uma nova direção para o personagem olhar para esse lado
            //Estamos utilizando um método de interpolação Slerp para suavizar os valores entre um vector3 e outro.
            transform.forward = Vector3.Slerp(transform.forward, input, Time.deltaTime * 10);

            //Dando play na animação de andando
            animator.SetBool("andando", true);
        } else {
            //Dando stop na animação de andando e play na movimentação de parado
            animator.SetBool("andando", false);
        }

    }
}
